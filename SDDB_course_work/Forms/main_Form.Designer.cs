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
            this.manufacture_button = new System.Windows.Forms.Button();
            this.databases_dataGrid = new System.Windows.Forms.DataGridView();
            this.open_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.databases_dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // manufacture_button
            // 
            this.manufacture_button.Location = new System.Drawing.Point(328, 192);
            this.manufacture_button.Name = "manufacture_button";
            this.manufacture_button.Size = new System.Drawing.Size(75, 23);
            this.manufacture_button.TabIndex = 1;
            this.manufacture_button.Text = "Manufacture";
            this.manufacture_button.UseVisualStyleBackColor = true;
            this.manufacture_button.Click += new System.EventHandler(this.manufacture_button_Click);
            // 
            // databases_dataGrid
            // 
            this.databases_dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.databases_dataGrid.Location = new System.Drawing.Point(12, 12);
            this.databases_dataGrid.Name = "databases_dataGrid";
            this.databases_dataGrid.Size = new System.Drawing.Size(391, 174);
            this.databases_dataGrid.TabIndex = 2;
            // 
            // open_button
            // 
            this.open_button.Location = new System.Drawing.Point(12, 192);
            this.open_button.Name = "open_button";
            this.open_button.Size = new System.Drawing.Size(75, 23);
            this.open_button.TabIndex = 3;
            this.open_button.Text = "Open Cafe";
            this.open_button.UseVisualStyleBackColor = true;
            this.open_button.Click += new System.EventHandler(this.open_button_Click);
            // 
            // main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 227);
            this.Controls.Add(this.open_button);
            this.Controls.Add(this.databases_dataGrid);
            this.Controls.Add(this.manufacture_button);
            this.Name = "main_Form";
            this.Text = "Main";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.main_Form_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.databases_dataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button manufacture_button;
        private System.Windows.Forms.DataGridView databases_dataGrid;
        private System.Windows.Forms.Button open_button;
    }
}