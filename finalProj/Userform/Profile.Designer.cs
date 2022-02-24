namespace Userform
{
    partial class Profile
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
            this.label1 = new System.Windows.Forms.Label();
            this.labelDate = new System.Windows.Forms.Label();
            this.EntryBox = new System.Windows.Forms.ListBox();
            this.newEntry = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.Welcome = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.GameBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Logout = new System.Windows.Forms.Button();
            this.View = new System.Windows.Forms.Button();
            this.Delete2 = new System.Windows.Forms.Button();
            this.View2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(285, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 0;
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Location = new System.Drawing.Point(498, 33);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(81, 13);
            this.labelDate.TabIndex = 1;
            this.labelDate.Text = "To Display date";
            // 
            // EntryBox
            // 
            this.EntryBox.FormattingEnabled = true;
            this.EntryBox.Location = new System.Drawing.Point(86, 160);
            this.EntryBox.Name = "EntryBox";
            this.EntryBox.Size = new System.Drawing.Size(198, 121);
            this.EntryBox.TabIndex = 2;
            // 
            // newEntry
            // 
            this.newEntry.Location = new System.Drawing.Point(86, 107);
            this.newEntry.Name = "newEntry";
            this.newEntry.Size = new System.Drawing.Size(75, 23);
            this.newEntry.TabIndex = 3;
            this.newEntry.Text = "New Entry";
            this.newEntry.UseVisualStyleBackColor = true;
            this.newEntry.Click += new System.EventHandler(this.newEntry_Click);
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(200, 310);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(75, 23);
            this.Delete.TabIndex = 5;
            this.Delete.Text = "Delete";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // Welcome
            // 
            this.Welcome.AutoSize = true;
            this.Welcome.Location = new System.Drawing.Point(83, 33);
            this.Welcome.Name = "Welcome";
            this.Welcome.Size = new System.Drawing.Size(14, 13);
            this.Welcome.TabIndex = 6;
            this.Welcome.Text = "\' \'";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(323, 107);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 7;
            this.button4.Text = "New Game";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // GameBox
            // 
            this.GameBox.FormattingEnabled = true;
            this.GameBox.Location = new System.Drawing.Point(323, 160);
            this.GameBox.Name = "GameBox";
            this.GameBox.Size = new System.Drawing.Size(198, 121);
            this.GameBox.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(83, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "\' \'";
            // 
            // Logout
            // 
            this.Logout.Location = new System.Drawing.Point(86, 359);
            this.Logout.Name = "Logout";
            this.Logout.Size = new System.Drawing.Size(75, 23);
            this.Logout.TabIndex = 10;
            this.Logout.Text = "Log Out";
            this.Logout.UseVisualStyleBackColor = true;
            this.Logout.Click += new System.EventHandler(this.Logout_Click);
            // 
            // View
            // 
            this.View.Location = new System.Drawing.Point(89, 310);
            this.View.Name = "View";
            this.View.Size = new System.Drawing.Size(75, 23);
            this.View.TabIndex = 4;
            this.View.Text = "View/Edit";
            this.View.UseVisualStyleBackColor = true;
            this.View.Click += new System.EventHandler(this.View_Click);
            // 
            // Delete2
            // 
            this.Delete2.Location = new System.Drawing.Point(434, 310);
            this.Delete2.Name = "Delete2";
            this.Delete2.Size = new System.Drawing.Size(75, 23);
            this.Delete2.TabIndex = 12;
            this.Delete2.Text = "Delete";
            this.Delete2.UseVisualStyleBackColor = true;
            this.Delete2.Click += new System.EventHandler(this.Delete2_Click);
            // 
            // View2
            // 
            this.View2.Location = new System.Drawing.Point(323, 310);
            this.View2.Name = "View2";
            this.View2.Size = new System.Drawing.Size(75, 23);
            this.View2.TabIndex = 11;
            this.View2.Text = "View/Edit";
            this.View2.UseVisualStyleBackColor = true;
            this.View2.Click += new System.EventHandler(this.View2_Click);
            // 
            // Profile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 450);
            this.Controls.Add(this.Delete2);
            this.Controls.Add(this.View2);
            this.Controls.Add(this.Logout);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.GameBox);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.Welcome);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.View);
            this.Controls.Add(this.newEntry);
            this.Controls.Add(this.EntryBox);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.label1);
            this.Name = "Profile";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.ListBox EntryBox;
        private System.Windows.Forms.Button newEntry;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Label Welcome;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ListBox GameBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Logout;
        private System.Windows.Forms.Button View;
        private System.Windows.Forms.Button Delete2;
        private System.Windows.Forms.Button View2;
    }
}