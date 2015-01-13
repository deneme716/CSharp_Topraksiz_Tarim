namespace ReminderApp
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
            this.themeColorPicker1 = new System.Windows.Forms.ThemeColorPicker();
            this.SuspendLayout();
            // 
            // themeColorPicker1
            // 
            this.themeColorPicker1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("themeColorPicker1.BackgroundImage")));
            this.themeColorPicker1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.themeColorPicker1.Color = System.Drawing.Color.Empty;
            this.themeColorPicker1.CustomColors = new int[0];
            this.themeColorPicker1.Location = new System.Drawing.Point(0, 0);
            this.themeColorPicker1.Name = "themeColorPicker1";
            this.themeColorPicker1.Size = new System.Drawing.Size(174, 166);
            this.themeColorPicker1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(226, 203);
            this.Controls.Add(this.themeColorPicker1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ThemeColorPicker themeColorPicker1;
    }
}