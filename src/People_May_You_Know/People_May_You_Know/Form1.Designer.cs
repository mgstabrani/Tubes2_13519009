namespace People_May_You_Know
{
    partial class main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.browseButton = new System.Windows.Forms.Button();
            this.dfsRadioButton = new System.Windows.Forms.RadioButton();
            this.bfsRadioButton = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.accountNodeDropDown = new System.Windows.Forms.ComboBox();
            this.exploreNodeDropDown = new System.Windows.Forms.ComboBox();
            this.submitButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textFriendRecommendationLabel = new System.Windows.Forms.Label();
            this.recLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.exploreLabel = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.algorithmPanel = new System.Windows.Forms.Panel();
            this.bfsDfsPanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.graphVisualizationPanel = new System.Windows.Forms.Panel();
            this.visGraphLabel = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.algorithmPanel.SuspendLayout();
            this.bfsDfsPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.graphVisualizationPanel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Graph File";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Algorithm";
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(6, 21);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 23);
            this.browseButton.TabIndex = 5;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // dfsRadioButton
            // 
            this.dfsRadioButton.AutoSize = true;
            this.dfsRadioButton.Location = new System.Drawing.Point(3, 5);
            this.dfsRadioButton.Name = "dfsRadioButton";
            this.dfsRadioButton.Size = new System.Drawing.Size(46, 17);
            this.dfsRadioButton.TabIndex = 7;
            this.dfsRadioButton.TabStop = true;
            this.dfsRadioButton.Text = "DFS";
            this.dfsRadioButton.UseVisualStyleBackColor = true;
            this.dfsRadioButton.CheckedChanged += new System.EventHandler(this.dfsRadionButton_CheckedChanged);
            // 
            // bfsRadioButton
            // 
            this.bfsRadioButton.AutoSize = true;
            this.bfsRadioButton.Location = new System.Drawing.Point(152, 3);
            this.bfsRadioButton.Name = "bfsRadioButton";
            this.bfsRadioButton.Size = new System.Drawing.Size(45, 17);
            this.bfsRadioButton.TabIndex = 8;
            this.bfsRadioButton.TabStop = true;
            this.bfsRadioButton.Text = "BFS";
            this.bfsRadioButton.UseVisualStyleBackColor = true;
            this.bfsRadioButton.CheckedChanged += new System.EventHandler(this.bfsRadioButton_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Choose Account";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(194, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Explore friends with";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // accountNodeDropDown
            // 
            this.accountNodeDropDown.BackColor = System.Drawing.SystemColors.Window;
            this.accountNodeDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.accountNodeDropDown.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.accountNodeDropDown.FormattingEnabled = true;
            this.accountNodeDropDown.Location = new System.Drawing.Point(3, 16);
            this.accountNodeDropDown.MaxDropDownItems = 50;
            this.accountNodeDropDown.Name = "accountNodeDropDown";
            this.accountNodeDropDown.Size = new System.Drawing.Size(150, 21);
            this.accountNodeDropDown.TabIndex = 14;
            this.accountNodeDropDown.SelectedIndexChanged += new System.EventHandler(this.accountNodeDropDown_SelectedIndexChanged);
            // 
            // exploreNodeDropDown
            // 
            this.exploreNodeDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.exploreNodeDropDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exploreNodeDropDown.FormattingEnabled = true;
            this.exploreNodeDropDown.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D"});
            this.exploreNodeDropDown.Location = new System.Drawing.Point(197, 16);
            this.exploreNodeDropDown.MaxDropDownItems = 50;
            this.exploreNodeDropDown.Name = "exploreNodeDropDown";
            this.exploreNodeDropDown.Size = new System.Drawing.Size(150, 21);
            this.exploreNodeDropDown.TabIndex = 15;
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(0, 5);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(100, 40);
            this.submitButton.TabIndex = 18;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Explore : ";
            // 
            // textFriendRecommendationLabel
            // 
            this.textFriendRecommendationLabel.AutoSize = true;
            this.textFriendRecommendationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textFriendRecommendationLabel.Location = new System.Drawing.Point(3, 0);
            this.textFriendRecommendationLabel.Name = "textFriendRecommendationLabel";
            this.textFriendRecommendationLabel.Size = new System.Drawing.Size(157, 13);
            this.textFriendRecommendationLabel.TabIndex = 20;
            this.textFriendRecommendationLabel.Text = "Friends Recommendation :";
            // 
            // recLayout
            // 
            this.recLayout.AutoScroll = true;
            this.recLayout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.recLayout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.recLayout.Location = new System.Drawing.Point(6, 26);
            this.recLayout.Name = "recLayout";
            this.recLayout.Size = new System.Drawing.Size(471, 395);
            this.recLayout.TabIndex = 21;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel9);
            this.panel1.Controls.Add(this.panel8);
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.algorithmPanel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(508, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 729);
            this.panel1.TabIndex = 22;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel9.Controls.Add(this.textFriendRecommendationLabel);
            this.panel9.Controls.Add(this.recLayout);
            this.panel9.Location = new System.Drawing.Point(8, 293);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(480, 424);
            this.panel9.TabIndex = 26;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel8.Controls.Add(this.exploreLabel);
            this.panel8.Controls.Add(this.label6);
            this.panel8.Location = new System.Drawing.Point(8, 224);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(480, 50);
            this.panel8.TabIndex = 25;
            // 
            // exploreLabel
            // 
            this.exploreLabel.AutoSize = true;
            this.exploreLabel.Location = new System.Drawing.Point(3, 27);
            this.exploreLabel.Name = "exploreLabel";
            this.exploreLabel.Size = new System.Drawing.Size(42, 13);
            this.exploreLabel.TabIndex = 20;
            this.exploreLabel.Text = "Explore";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.submitButton);
            this.panel7.Location = new System.Drawing.Point(8, 151);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(480, 50);
            this.panel7.TabIndex = 24;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel6.Controls.Add(this.panel5);
            this.panel6.Location = new System.Drawing.Point(8, 76);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(480, 50);
            this.panel6.TabIndex = 23;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label8);
            this.panel5.Controls.Add(this.exploreNodeDropDown);
            this.panel5.Controls.Add(this.accountNodeDropDown);
            this.panel5.Controls.Add(this.label7);
            this.panel5.Location = new System.Drawing.Point(65, 5);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(350, 40);
            this.panel5.TabIndex = 24;
            // 
            // algorithmPanel
            // 
            this.algorithmPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.algorithmPanel.Controls.Add(this.bfsDfsPanel);
            this.algorithmPanel.Controls.Add(this.label3);
            this.algorithmPanel.Location = new System.Drawing.Point(8, 12);
            this.algorithmPanel.Name = "algorithmPanel";
            this.algorithmPanel.Size = new System.Drawing.Size(480, 50);
            this.algorithmPanel.TabIndex = 22;
            // 
            // bfsDfsPanel
            // 
            this.bfsDfsPanel.Controls.Add(this.dfsRadioButton);
            this.bfsDfsPanel.Controls.Add(this.bfsRadioButton);
            this.bfsDfsPanel.Location = new System.Drawing.Point(140, 12);
            this.bfsDfsPanel.Name = "bfsDfsPanel";
            this.bfsDfsPanel.Size = new System.Drawing.Size(200, 25);
            this.bfsDfsPanel.TabIndex = 24;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.graphVisualizationPanel);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(500, 729);
            this.panel2.TabIndex = 23;
            // 
            // graphVisualizationPanel
            // 
            this.graphVisualizationPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.graphVisualizationPanel.Controls.Add(this.visGraphLabel);
            this.graphVisualizationPanel.Location = new System.Drawing.Point(12, 76);
            this.graphVisualizationPanel.Name = "graphVisualizationPanel";
            this.graphVisualizationPanel.Size = new System.Drawing.Size(480, 641);
            this.graphVisualizationPanel.TabIndex = 11;
            // 
            // visGraphLabel
            // 
            this.visGraphLabel.AutoSize = true;
            this.visGraphLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.visGraphLabel.Location = new System.Drawing.Point(182, 314);
            this.visGraphLabel.Name = "visGraphLabel";
            this.visGraphLabel.Size = new System.Drawing.Size(116, 13);
            this.visGraphLabel.TabIndex = 0;
            this.visGraphLabel.Text = "Graph Visualization";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel3.Controls.Add(this.textBox1);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.browseButton);
            this.panel3.Location = new System.Drawing.Point(12, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(480, 50);
            this.panel3.TabIndex = 10;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(87, 23);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(380, 20);
            this.textBox1.TabIndex = 6;
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximumSize = new System.Drawing.Size(1024, 768);
            this.MinimumSize = new System.Drawing.Size(1024, 768);
            this.Name = "main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "People May You Know";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.algorithmPanel.ResumeLayout(false);
            this.algorithmPanel.PerformLayout();
            this.bfsDfsPanel.ResumeLayout(false);
            this.bfsDfsPanel.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.graphVisualizationPanel.ResumeLayout(false);
            this.graphVisualizationPanel.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.RadioButton dfsRadioButton;
        private System.Windows.Forms.RadioButton bfsRadioButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox accountNodeDropDown;
        private System.Windows.Forms.ComboBox exploreNodeDropDown;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label textFriendRecommendationLabel;
        private System.Windows.Forms.FlowLayoutPanel recLayout;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel graphVisualizationPanel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel algorithmPanel;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel bfsDfsPanel;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label exploreLabel;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label visGraphLabel;
    }
}

