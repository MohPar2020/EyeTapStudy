namespace EyeTapStudy
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.difficultyLevelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.level1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.level2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.level3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.level4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.level5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testingModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mouseOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dwellTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.voiceRecognitionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eyeTAPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smoothPursuitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.lblCurrentLevel = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.lblUserId = new System.Windows.Forms.Label();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.menuStrip1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.difficultyLevelToolStripMenuItem,
            this.testingModeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(905, 27);
            this.menuStrip1.TabIndex = 20;
            this.menuStrip1.Text = "Difficulty Level";
            // 
            // difficultyLevelToolStripMenuItem
            // 
            this.difficultyLevelToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.level1ToolStripMenuItem,
            this.level2ToolStripMenuItem,
            this.level3ToolStripMenuItem,
            this.level4ToolStripMenuItem,
            this.level5ToolStripMenuItem});
            this.difficultyLevelToolStripMenuItem.Name = "difficultyLevelToolStripMenuItem";
            this.difficultyLevelToolStripMenuItem.Size = new System.Drawing.Size(109, 23);
            this.difficultyLevelToolStripMenuItem.Text = "Difficulty Level";
            // 
            // level1ToolStripMenuItem
            // 
            this.level1ToolStripMenuItem.Name = "level1ToolStripMenuItem";
            this.level1ToolStripMenuItem.Size = new System.Drawing.Size(88, 24);
            this.level1ToolStripMenuItem.Text = "1";
            this.level1ToolStripMenuItem.Click += new System.EventHandler(this.level1ToolStripMenuItem_Click);
            // 
            // level2ToolStripMenuItem
            // 
            this.level2ToolStripMenuItem.Name = "level2ToolStripMenuItem";
            this.level2ToolStripMenuItem.Size = new System.Drawing.Size(88, 24);
            this.level2ToolStripMenuItem.Text = "2";
            this.level2ToolStripMenuItem.Click += new System.EventHandler(this.level2ToolStripMenuItem_Click);
            // 
            // level3ToolStripMenuItem
            // 
            this.level3ToolStripMenuItem.Name = "level3ToolStripMenuItem";
            this.level3ToolStripMenuItem.Size = new System.Drawing.Size(88, 24);
            this.level3ToolStripMenuItem.Text = "3";
            this.level3ToolStripMenuItem.Click += new System.EventHandler(this.level3ToolStripMenuItem_Click);
            // 
            // level4ToolStripMenuItem
            // 
            this.level4ToolStripMenuItem.Name = "level4ToolStripMenuItem";
            this.level4ToolStripMenuItem.Size = new System.Drawing.Size(88, 24);
            this.level4ToolStripMenuItem.Text = "4";
            this.level4ToolStripMenuItem.Click += new System.EventHandler(this.level4ToolStripMenuItem_Click);
            // 
            // level5ToolStripMenuItem
            // 
            this.level5ToolStripMenuItem.Name = "level5ToolStripMenuItem";
            this.level5ToolStripMenuItem.Size = new System.Drawing.Size(88, 24);
            this.level5ToolStripMenuItem.Text = "5";
            this.level5ToolStripMenuItem.Click += new System.EventHandler(this.level5ToolStripMenuItem_Click);
            // 
            // testingModeToolStripMenuItem
            // 
            this.testingModeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mouseOnlyToolStripMenuItem,
            this.dwellTimeToolStripMenuItem,
            this.voiceRecognitionToolStripMenuItem,
            this.eyeTAPToolStripMenuItem,
            this.smoothPursuitToolStripMenuItem,
            this.resetToolStripMenuItem});
            this.testingModeToolStripMenuItem.Name = "testingModeToolStripMenuItem";
            this.testingModeToolStripMenuItem.Size = new System.Drawing.Size(104, 23);
            this.testingModeToolStripMenuItem.Text = "Testing Mode";
            // 
            // mouseOnlyToolStripMenuItem
            // 
            this.mouseOnlyToolStripMenuItem.Name = "mouseOnlyToolStripMenuItem";
            this.mouseOnlyToolStripMenuItem.Size = new System.Drawing.Size(188, 24);
            this.mouseOnlyToolStripMenuItem.Text = "Mouse Only";
            this.mouseOnlyToolStripMenuItem.Click += new System.EventHandler(this.mouseOnlyToolStripMenuItem_Click);
            // 
            // dwellTimeToolStripMenuItem
            // 
            this.dwellTimeToolStripMenuItem.Name = "dwellTimeToolStripMenuItem";
            this.dwellTimeToolStripMenuItem.Size = new System.Drawing.Size(188, 24);
            this.dwellTimeToolStripMenuItem.Text = "Dwell-Time";
            this.dwellTimeToolStripMenuItem.Click += new System.EventHandler(this.dwellTimeToolStripMenuItem_Click);
            // 
            // voiceRecognitionToolStripMenuItem
            // 
            this.voiceRecognitionToolStripMenuItem.Name = "voiceRecognitionToolStripMenuItem";
            this.voiceRecognitionToolStripMenuItem.Size = new System.Drawing.Size(188, 24);
            this.voiceRecognitionToolStripMenuItem.Text = "Voice Recognition";
            this.voiceRecognitionToolStripMenuItem.Click += new System.EventHandler(this.voiceRecognitionToolStripMenuItem_Click);
            // 
            // eyeTAPToolStripMenuItem
            // 
            this.eyeTAPToolStripMenuItem.Name = "eyeTAPToolStripMenuItem";
            this.eyeTAPToolStripMenuItem.Size = new System.Drawing.Size(188, 24);
            this.eyeTAPToolStripMenuItem.Text = "EyeTAP";
            this.eyeTAPToolStripMenuItem.Click += new System.EventHandler(this.eyeTAPToolStripMenuItem_Click);
            // 
            // smoothPursuitToolStripMenuItem
            // 
            this.smoothPursuitToolStripMenuItem.Name = "smoothPursuitToolStripMenuItem";
            this.smoothPursuitToolStripMenuItem.Size = new System.Drawing.Size(188, 24);
            this.smoothPursuitToolStripMenuItem.Text = "SmoothPursuit";
            this.smoothPursuitToolStripMenuItem.Click += new System.EventHandler(this.smoothPursuitToolStripMenuItem_Click);
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(188, 24);
            this.resetToolStripMenuItem.Text = "Reset";
            this.resetToolStripMenuItem.Click += new System.EventHandler(this.resetToolStripMenuItem_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPanel.AutoSize = true;
            this.mainPanel.Location = new System.Drawing.Point(12, 27);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Padding = new System.Windows.Forms.Padding(10);
            this.mainPanel.Size = new System.Drawing.Size(881, 522);
            this.mainPanel.TabIndex = 21;
            // 
            // lblCurrentLevel
            // 
            this.lblCurrentLevel.AutoSize = true;
            this.lblCurrentLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.150944F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentLevel.Location = new System.Drawing.Point(300, 6);
            this.lblCurrentLevel.Name = "lblCurrentLevel";
            this.lblCurrentLevel.Size = new System.Drawing.Size(51, 16);
            this.lblCurrentLevel.TabIndex = 22;
            this.lblCurrentLevel.Text = "label1";
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(494, 0);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 23;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // lblUserId
            // 
            this.lblUserId.AutoSize = true;
            this.lblUserId.Location = new System.Drawing.Point(696, 6);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(51, 15);
            this.lblUserId.TabIndex = 24;
            this.lblUserId.Text = "User ID:";
            // 
            // txtUserId
            // 
            this.txtUserId.Location = new System.Drawing.Point(752, 4);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(58, 20);
            this.txtUserId.TabIndex = 25;
            // 
            // Form1
            // 
            this.AcceptButton = this.btnNext;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 561);
            this.Controls.Add(this.txtUserId);
            this.Controls.Add(this.lblUserId);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.lblCurrentLevel);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EyeTAP User Study";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem difficultyLevelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem level1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem level2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem level3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem level4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem level5ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testingModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mouseOnlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dwellTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem voiceRecognitionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eyeTAPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.ToolStripMenuItem smoothPursuitToolStripMenuItem;
        private System.Windows.Forms.Label lblCurrentLevel;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lblUserId;
        private System.Windows.Forms.TextBox txtUserId;
    }
}

