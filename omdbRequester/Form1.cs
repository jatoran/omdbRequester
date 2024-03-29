﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http; //http requests
using Newtonsoft.Json; //for JsonConvert Deserialization (installed via nuget package)
using System.Xml.Serialization; //converting to/from xml
using System.IO; //read/write to files
using System.Linq;

//Curl to C# Converter https://curl.olsh.me/
//Check if JSON is valid https://jsonlint.com/
//Convert Json to C# Class: https://json2csharp.com/

//API LINKS
//OMDB API: http://www.omdbapi.com/

namespace OMDB_Requester {
	public partial class Form1 : Form {
		static HttpClient _client = new HttpClient();
		string apiKey = Properties.Settings.Default.API_Key;
		string OMDB_API_Address = @"http://www.omdbapi.com/apikey.aspx";

		string CSV = ":Title,Year,Genre,metaScore,imdb,rottenTomato,Director,Actors,Plot";
		string[] columnHeaders = {
			"Title", "Year", "Genre", "metaScore", "imdb", "rottenTomato", "Director", "Actors", "Plot"
		};
		DataTable sourceTable = new DataTable();

		public Form1() {
			InitializeComponent();

			//assign Enter key to searchButton
			AcceptButton = searchButton;

			//populate api key Textbox 
			apiTextbox.Text = apiKey;

			//handle inputTextbox focus
			inputTextbox.GotFocus += new EventHandler(inputTextbox_Focus);
			inputTextbox.ForeColor = Color.Gray;
			inputTextbox.Text = "Enter Movie Title(s)";
		}

		public async void omdb_API_Rquest_Async() {
			List<string> movieTitles = new List<string>();

			populateSourceTableColumnHeaders();

			splitMovieTitles(movieTitles);

			foreach (string movie in movieTitles) {
				OMDB_OBJECT deserializedResponse;
				string movieTitle = "";
				string yearString = "";
				bool responseSuccess = false;

				splitYearTitle(movie, ref movieTitle, ref yearString);
				
				var rawResponse = await _client.GetAsync("http://www.omdbapi.com/?apikey=" + apiKey + "&t=" + movieTitle + yearString);

				deserializedResponse = JsonConvert.DeserializeObject<OMDB_OBJECT>(rawResponse.Content.ReadAsStringAsync().Result);

				if (deserializedResponse.Response != "False") {
					responseSuccess = true;
					appendToCSV(deserializedResponse);
				}

				appendDiagLog(movie, responseSuccess);
				appendToSourceTable(deserializedResponse, movie, responseSuccess);

				inputTextbox.Invoke(new MethodInvoker(delegate {
					inputTextbox.ForeColor = Color.Gray;
					inputTextbox.Text = "";
				}));
			}

			if (dataGridView1.DataSource != sourceTable) {
				dataGridView1.Invoke(new MethodInvoker(() =>
					dataGridView1.DataSource = sourceTable)
						);

				dataGridView1.Invoke(new MethodInvoker(delegate {
					dataGridView1.Columns[0].Width = Properties.Settings.Default.column0Width;
					dataGridView1.Columns[1].Width = Properties.Settings.Default.column1Width;
					dataGridView1.Columns[2].Width = Properties.Settings.Default.column2Width;
					dataGridView1.Columns[3].Width = Properties.Settings.Default.column3Width;
					dataGridView1.Columns[4].Width = Properties.Settings.Default.column4Width;
					dataGridView1.Columns[5].Width = Properties.Settings.Default.column5Width;
					dataGridView1.Columns[6].Width = Properties.Settings.Default.column6Width;
					dataGridView1.Columns[7].Width = Properties.Settings.Default.column7Width;
					dataGridView1.Columns[8].Width = Properties.Settings.Default.column8Width;
				}));
			}
		}

		public void splitMovieTitles(List<string> movieTitles) {
			if (inputTextbox.Text.Contains(",")) {

				//remove trailing comma
				if (inputTextbox.Text.EndsWith(","))
					inputTextbox.Text = inputTextbox.Text.Substring(0, inputTextbox.Text.Length - 1);

				string[] tempRange = inputTextbox.Text.Split(',');

				for (int i = 0; i < tempRange.Length; i++) {
					while (tempRange[i].EndsWith(" ")) {
						tempRange[i] = tempRange[i].Remove(tempRange[i].Length - 1);
					}
					while (tempRange[i].StartsWith(" ")) {
						tempRange[i] = tempRange[i].Remove(0, 1);
					}
				}
				movieTitles.AddRange(tempRange);
			}
			else
				movieTitles.Add(inputTextbox.Text);
		}

		public void appendToCSV(OMDB_OBJECT movieInfo) {
			CSV += "\n"
				+ "\"" + (movieInfo.Title ?? "N/A") + "\","
				+ (movieInfo.Year ?? "N/A") + ","
				+ "\"" + (movieInfo.Genre ?? "N/A") + "\","
				+ (movieInfo.Metascore ?? "N/A") + ","
				+ (movieInfo.imdbRating ?? "N/A") + ","
				+ (movieInfo.Ratings.Count > 1 ? movieInfo.Ratings[1].Value : "N/A") + ","
				+ "\"" + (movieInfo.Director ?? "N/A") + "\","
				+ "\"" + (movieInfo.Actors ?? "N/A") + "\","
				+ "\"" + (movieInfo.Plot ?? "N/A") + "\"";
		}

		public void appendToSourceTable(OMDB_OBJECT movieInfo, string movie = "", bool success = true) {
			if (success == true) {
				string[] row = { movieInfo.Title, movieInfo.Year, movieInfo.Genre, movieInfo.Metascore ?? "N/A", movieInfo.imdbRating ?? "N/A", movieInfo.Ratings.Count > 1 ? movieInfo.Ratings[1].Value : "N/A", movieInfo.Director ?? "N/A", movieInfo.Actors ?? "N/A", movieInfo.Plot ?? "N/A" };

				dataGridView1.Invoke(new MethodInvoker(() =>
					sourceTable.Rows.Add(row)
						));
			}
			else {
				dataGridView1.Invoke(new MethodInvoker(() =>
					sourceTable.Rows.Add(movie, "", "Not Found")
						));
			}
		}

		public void appendDiagLog(string movie, bool success) {
			string listRow = "";
			if (success == true)
				listRow = "Success: " + movie + " found successfully.";
			else
				listRow = "Error: " + movie + " not found on OMDB";

			messageBoxListView.Invoke(new MethodInvoker(delegate {
				messageBoxListView.Items.Add(new ListViewItem(listRow));
				messageBoxListView.Items[messageBoxListView.Items.Count - 1].EnsureVisible();
			}));
		}

		public void populateSourceTableColumnHeaders() {
			if (sourceTable.Columns.Count <= 0)
				foreach (string headerString in columnHeaders)
					sourceTable.Columns.Add(headerString);
		}

		public void splitYearTitle(string movie, ref string movieTitle, ref string yearString) {
			movieTitle = movie;
			if (movie.Contains("(")) { 
				string year = movie.Substring(movie.IndexOf('(') + 1, 4);
				movieTitle = movie.Remove(movie.IndexOf('('));
				yearString = "&y = " + year;
			}
		}

		private void editApiButton_Click(object sender, EventArgs e) {
			//when it says Edit and is locked
			if (editApiButton.Text == "Edit") {
				apiTextbox.Enabled = true;
				editApiButton.Text = "Save";
			}

			else {
				//when it says Save and is unlocked
				apiTextbox.Enabled = false;
				apiKey = apiTextbox.Text;
				editApiButton.Text = "Edit";
				Properties.Settings.Default.API_Key = apiKey;
				Properties.Settings.Default.Save();
			}
		}

		private void omdbLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			System.Diagnostics.Process.Start(OMDB_API_Address);
		}


		private void folderMatchButton_Click(object sender, EventArgs e) {
			string[] subdirs = { "" };
			FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
			if (folderBrowserDialog1.ShowDialog() == DialogResult.OK) {
				subdirs = Directory.GetDirectories(folderBrowserDialog1.SelectedPath)
							.Select(Path.GetFileName)
							.ToArray();
			}

			string textBoxInput = "";
			foreach (string s in subdirs) {
				textBoxInput += s + ',';
			}
			inputTextbox.Text = textBoxInput;

			if (inputTextbox.Text != "Enter Movie Title(s)" && inputTextbox.Text != "" && inputTextbox.Text != ",") {
				Task.Run(new Action(omdb_API_Rquest_Async));
			}
		}

		protected void inputTextbox_Focus(Object sender, EventArgs e) {
			inputTextbox.Text = "";
			inputTextbox.ForeColor = Color.Black;
		}

		private void searchButton_Click(object sender, EventArgs e) {
			//Request movie data for specific movie
			if (inputTextbox.Text != "Enter Movie Title(s)" && inputTextbox.Text != "") {

				Task.Run(new Action(omdb_API_Rquest_Async));
			}
		}

		//creates CSV file with current time/date on users desktop
		private void csvButton_Click(object sender, EventArgs e) {
			string currTimeTag = DateTime.Now.ToString(@"yyyy-MM-dd-HHmm");
			string strPath = Environment.GetFolderPath(
						 System.Environment.SpecialFolder.DesktopDirectory);
			string path = strPath + @"\OMDB_Requester_Output - " + currTimeTag + ".csv";
			File.WriteAllText(path, CSV);
		}
	}

	//OMDB JSON CLASSES
	public class Movie {
		public string Source { get; set; }
		public string Value { get; set; }
	}
	public class OMDB_OBJECT {
		public string Title { get; set; }
		public string Year { get; set; }
		public string Rated { get; set; }
		public string Released { get; set; }
		public string Runtime { get; set; }
		public string Genre { get; set; }
		public string Director { get; set; }
		public string Writer { get; set; }
		public string Actors { get; set; }
		public string Plot { get; set; }
		public string Language { get; set; }
		public string Country { get; set; }
		public string Awards { get; set; }
		public string Poster { get; set; }
		public List<Movie> Ratings { get; set; }
		public string Metascore { get; set; }
		public string imdbRating { get; set; }
		public string imdbVotes { get; set; }
		public string imdbID { get; set; }
		public string Type { get; set; }
		public string DVD { get; set; }
		public string BoxOffice { get; set; }
		public string Production { get; set; }
		public string Website { get; set; }
		public string Response { get; set; }
		public string ToXML() {
			using (var stringwriter = new System.IO.StringWriter()) {
				var serializer = new XmlSerializer(this.GetType());
				serializer.Serialize(stringwriter, this);
				return stringwriter.ToString();
			}
		}
	}
}