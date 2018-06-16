namespace Forms
{
    partial class main_Form
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
            this.cafe_button = new System.Windows.Forms.Button();
            this.manufacture_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cafe_button
            // 
            this.cafe_button.Location = new System.Drawing.Point(23, 45);
            this.cafe_button.Name = "cafe_button";
            this.cafe_button.Size = new System.Drawing.Size(75, 23);
            this.cafe_button.TabIndex = 0;
            this.cafe_button.Text = "Cafe";
            this.cafe_button.UseVisualStyleBackColor = true;
            this.cafe_button.Click += new System.EventHandler(this.cafe_button_Click);
            // 
            // manufacture_button
            // 
            this.manufacture_button.Location = new System.Drawing.Point(147, 45);
            this.manufacture_button.Name = "manufacture_button";
            this.manufacture_button.Size = new System.Drawing.Size(75, 23);
            this.manufacture_button.TabIndex = 1;
            this.manufacture_button.Text = "Manufacture";
            this.manufacture_button.UseVisualStyleBackColor = true;
            this.manufacture_button.Click += new System.EventHandler(this.manufacture_button_Click);
            // 
            // main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 227);
            this.Controls.Add(this.manufacture_button);
            this.Controls.Add(this.cafe_button);
            this.Name = "main_Form";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.main_Form_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cafe_button;
        private System.Windows.Forms.Button manufacture_button;
    }
}