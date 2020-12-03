
namespace Baldi_s_Basics_Plus_Level_Saver
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.notesbtn = new System.Windows.Forms.Button();
            this.starbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(182, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(414, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please click the \"Read Notes\" button to read the notes, or this may not work corr" +
    "ectly.";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // notesbtn
            // 
            this.notesbtn.Location = new System.Drawing.Point(-2, 427);
            this.notesbtn.Name = "notesbtn";
            this.notesbtn.Size = new System.Drawing.Size(804, 23);
            this.notesbtn.TabIndex = 1;
            this.notesbtn.Text = "Read Notes";
            this.notesbtn.UseVisualStyleBackColor = true;
            this.notesbtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // starbtn
            // 
            this.starbtn.Location = new System.Drawing.Point(-2, 398);
            this.starbtn.Name = "starbtn";
            this.starbtn.Size = new System.Drawing.Size(804, 23);
            this.starbtn.TabIndex = 2;
            this.starbtn.Text = "Start";
            this.starbtn.UseVisualStyleBackColor = true;
            this.starbtn.Click += new System.EventHandler(this.starbtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.starbtn);
            this.Controls.Add(this.notesbtn);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "NOTICE";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button notesbtn;
        private System.Windows.Forms.Button starbtn;
    }
}

