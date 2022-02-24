namespace Userform
{
    partial class Entry
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
            this.Ldate = new System.Windows.Forms.Label();
            this.UserEntry = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Back = new System.Windows.Forms.Button();
            this.Title = new System.Windows.Forms.TextBox();
            this.Message = new System.Windows.Forms.Label();
            this.Edit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(110, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Title";
            // 
            // Ldate
            // 
            this.Ldate.AutoSize = true;
            this.Ldate.Location = new System.Drawing.Point(479, 66);
            this.Ldate.Name = "Ldate";
            this.Ldate.Size = new System.Drawing.Size(30, 13);
            this.Ldate.TabIndex = 1;
            this.Ldate.Text = "Date";
            // 
            // UserEntry
            // 
            this.UserEntry.Location = new System.Drawing.Point(83, 109);
            this.UserEntry.Name = "UserEntry";
            this.UserEntry.Size = new System.Drawing.Size(426, 213);
            this.UserEntry.TabIndex = 3;
            this.UserEntry.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(149, 360);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Back
            // 
            this.Back.Location = new System.Drawing.Point(368, 360);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(75, 23);
            this.Back.TabIndex = 5;
            this.Back.Text = "Back";
            this.Back.UseVisualStyleBackColor = true;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // Title
            // 
            this.Title.Location = new System.Drawing.Point(83, 66);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(100, 20);
            this.Title.TabIndex = 6;
            // 
            // Message
            // 
            this.Message.AutoSize = true;
            this.Message.Location = new System.Drawing.Point(276, 337);
            this.Message.Name = "Message";
            this.Message.Size = new System.Drawing.Size(20, 13);
            this.Message.TabIndex = 7;
            this.Message.Text = "\" \"";
            // 
            // Edit
            // 
            this.Edit.Location = new System.Drawing.Point(258, 360);
            this.Edit.Name = "Edit";
            this.Edit.Size = new System.Drawing.Size(75, 23);
            this.Edit.TabIndex = 8;
            this.Edit.Text = "Save Edit";
            this.Edit.UseVisualStyleBackColor = true;
            this.Edit.Click += new System.EventHandler(this.Edit_Click);
            // 
            // Entry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 450);
            this.Controls.Add(this.Edit);
            this.Controls.Add(this.Message);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.UserEntry);
            this.Controls.Add(this.Ldate);
            this.Controls.Add(this.label1);
            this.Name = "Entry";
            this.Text = "Form3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Ldate;
        private System.Windows.Forms.RichTextBox UserEntry;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.TextBox Title;
        private System.Windows.Forms.Label Message;
        private System.Windows.Forms.Button Edit;
    }
}