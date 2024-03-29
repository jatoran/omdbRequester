﻿
namespace OMDB_Requester {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
			this.searchButton = new System.Windows.Forms.Button();
			this.inputTextbox = new System.Windows.Forms.TextBox();
			this.csvButton = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.apiTextbox = new System.Windows.Forms.TextBox();
			this.editApiButton = new System.Windows.Forms.Button();
			this.omdbLink = new System.Windows.Forms.LinkLabel();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.folderMatchButton = new System.Windows.Forms.Button();
			this.messageBoxListView = new System.Windows.Forms.ListView();
			this.label2 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// searchButton
			// 
			this.searchButton.Location = new System.Drawing.Point(459, 12);
			this.searchButton.Margin = new System.Windows.Forms.Padding(4);
			this.searchButton.Name = "searchButton";
			this.searchButton.Size = new System.Drawing.Size(112, 32);
			this.searchButton.TabIndex = 0;
			this.searchButton.Text = "Search";
			this.searchButton.UseVisualStyleBackColor = true;
			this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
			// 
			// inputTextbox
			// 
			this.inputTextbox.Location = new System.Drawing.Point(13, 17);
			this.inputTextbox.Margin = new System.Windows.Forms.Padding(4);
			this.inputTextbox.Name = "inputTextbox";
			this.inputTextbox.Size = new System.Drawing.Size(435, 26);
			this.inputTextbox.TabIndex = 2;
			// 
			// csvButton
			// 
			this.csvButton.Location = new System.Drawing.Point(12, 495);
			this.csvButton.Margin = new System.Windows.Forms.Padding(4);
			this.csvButton.Name = "csvButton";
			this.csvButton.Size = new System.Drawing.Size(112, 32);
			this.csvButton.TabIndex = 4;
			this.csvButton.Text = "Create CSV";
			this.csvButton.UseVisualStyleBackColor = true;
			this.csvButton.Click += new System.EventHandler(this.csvButton_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(939, 45);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(115, 18);
			this.label3.TabIndex = 6;
			this.label3.Text = "OMDB API Key";
			// 
			// apiTextbox
			// 
			this.apiTextbox.Enabled = false;
			this.apiTextbox.Location = new System.Drawing.Point(942, 18);
			this.apiTextbox.Margin = new System.Windows.Forms.Padding(4);
			this.apiTextbox.Name = "apiTextbox";
			this.apiTextbox.Size = new System.Drawing.Size(148, 26);
			this.apiTextbox.TabIndex = 8;
			// 
			// editApiButton
			// 
			this.editApiButton.Location = new System.Drawing.Point(1098, 14);
			this.editApiButton.Margin = new System.Windows.Forms.Padding(4);
			this.editApiButton.Name = "editApiButton";
			this.editApiButton.Size = new System.Drawing.Size(75, 32);
			this.editApiButton.TabIndex = 9;
			this.editApiButton.Text = "Edit";
			this.editApiButton.UseVisualStyleBackColor = true;
			this.editApiButton.Click += new System.EventHandler(this.editApiButton_Click);
			// 
			// omdbLink
			// 
			this.omdbLink.AutoSize = true;
			this.omdbLink.Location = new System.Drawing.Point(897, 81);
			this.omdbLink.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.omdbLink.Name = "omdbLink";
			this.omdbLink.Size = new System.Drawing.Size(144, 18);
			this.omdbLink.TabIndex = 10;
			this.omdbLink.TabStop = true;
			this.omdbLink.Text = "Get OMDB API Key";
			this.omdbLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.omdbLink_LinkClicked);
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(12, 66);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(878, 422);
			this.dataGridView1.TabIndex = 11;
			// 
			// folderMatchButton
			// 
			this.folderMatchButton.Location = new System.Drawing.Point(896, 102);
			this.folderMatchButton.Name = "folderMatchButton";
			this.folderMatchButton.Size = new System.Drawing.Size(148, 51);
			this.folderMatchButton.TabIndex = 13;
			this.folderMatchButton.Text = "Automatic Folder Match";
			this.folderMatchButton.UseVisualStyleBackColor = true;
			this.folderMatchButton.Click += new System.EventHandler(this.folderMatchButton_Click);
			// 
			// messageBoxListView
			// 
			this.messageBoxListView.HideSelection = false;
			this.messageBoxListView.Location = new System.Drawing.Point(896, 199);
			this.messageBoxListView.Name = "messageBoxListView";
			this.messageBoxListView.Size = new System.Drawing.Size(301, 335);
			this.messageBoxListView.TabIndex = 14;
			this.messageBoxListView.UseCompatibleStateImageBehavior = false;
			this.messageBoxListView.View = System.Windows.Forms.View.List;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(1003, 177);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(87, 19);
			this.label2.TabIndex = 15;
			this.label2.Text = "Event Log";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1209, 546);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.messageBoxListView);
			this.Controls.Add(this.folderMatchButton);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.omdbLink);
			this.Controls.Add(this.editApiButton);
			this.Controls.Add(this.apiTextbox);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.csvButton);
			this.Controls.Add(this.inputTextbox);
			this.Controls.Add(this.searchButton);
			this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "Form1";
			this.Text = "OMDB Requester";
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TextBox inputTextbox;
        private System.Windows.Forms.Button csvButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox apiTextbox;
        private System.Windows.Forms.Button editApiButton;
        private System.Windows.Forms.LinkLabel omdbLink;
        private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Button folderMatchButton;
		private System.Windows.Forms.ListView messageBoxListView;
		private System.Windows.Forms.Label label2;
	}
}

