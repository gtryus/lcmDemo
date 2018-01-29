namespace lcmDemo
{
    partial class ChooseProject
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
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.Ok = new System.Windows.Forms.Button();
			this.Cancel = new System.Windows.Forms.Button();
			this.AnotherLocationLink = new System.Windows.Forms.LinkLabel();
			this.SuspendLayout();
			// 
			// listBox1
			// 
			this.listBox1.FormattingEnabled = true;
			this.listBox1.ItemHeight = 16;
			this.listBox1.Location = new System.Drawing.Point(38, 29);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(289, 340);
			this.listBox1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(35, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(169, 17);
			this.label1.TabIndex = 1;
			this.label1.Text = "Select FieldWorks Project";
			// 
			// Ok
			// 
			this.Ok.Location = new System.Drawing.Point(252, 375);
			this.Ok.Name = "Ok";
			this.Ok.Size = new System.Drawing.Size(75, 23);
			this.Ok.TabIndex = 2;
			this.Ok.Text = "Ok";
			this.Ok.UseVisualStyleBackColor = true;
			this.Ok.Click += new System.EventHandler(this.Ok_Click);
			// 
			// Cancel
			// 
			this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Cancel.Location = new System.Drawing.Point(171, 375);
			this.Cancel.Name = "Cancel";
			this.Cancel.Size = new System.Drawing.Size(75, 23);
			this.Cancel.TabIndex = 3;
			this.Cancel.Text = "Cancel";
			this.Cancel.UseVisualStyleBackColor = true;
			// 
			// AnotherLocationLink
			// 
			this.AnotherLocationLink.AutoSize = true;
			this.AnotherLocationLink.Location = new System.Drawing.Point(35, 378);
			this.AnotherLocationLink.Name = "AnotherLocationLink";
			this.AnotherLocationLink.Size = new System.Drawing.Size(116, 17);
			this.AnotherLocationLink.TabIndex = 4;
			this.AnotherLocationLink.TabStop = true;
			this.AnotherLocationLink.Text = "Another Location";
			this.AnotherLocationLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.AnotherLocationLink_LinkClicked);
			// 
			// ChooseProject
			// 
			this.AcceptButton = this.Ok;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.Cancel;
			this.ClientSize = new System.Drawing.Size(386, 432);
			this.Controls.Add(this.AnotherLocationLink);
			this.Controls.Add(this.Cancel);
			this.Controls.Add(this.Ok);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.listBox1);
			this.Name = "ChooseProject";
			this.Text = "Choose Project";
			this.Load += new System.EventHandler(this.ChooseProject_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Ok;
        private System.Windows.Forms.Button Cancel;
		private System.Windows.Forms.LinkLabel AnotherLocationLink;
	}
}

