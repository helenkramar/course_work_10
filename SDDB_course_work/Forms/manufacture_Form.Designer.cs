namespace Forms
{
    partial class manufacture_Form
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
            this.send_button = new System.Windows.Forms.Button();
            this.manufacture_dataGrid = new System.Windows.Forms.DataGridView();
            this.positionsName_comboBox = new System.Windows.Forms.ComboBox();
            this.cook_button = new System.Windows.Forms.Button();
            this.positionsAmount_textBox = new System.Windows.Forms.TextBox();
            this.positionsCost_textBox = new System.Windows.Forms.TextBox();
            this.cafes_comboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.manufacture_dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // send_button
            // 
            this.send_button.Location = new System.Drawing.Point(319, 335);
            this.send_button.Name = "send_button";
            this.send_button.Size = new System.Drawing.Size(91, 23);
            this.send_button.TabIndex = 5;
            this.send_button.Text = "Send to Cafe";
            this.send_button.UseVisualStyleBackColor = true;
            this.send_button.Click += new System.EventHandler(this.send_button_Click);
            // 
            // manufacture_dataGrid
            // 
            this.manufacture_dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.manufacture_dataGrid.Location = new System.Drawing.Point(12, 12);
            this.manufacture_dataGrid.Name = "manufacture_dataGrid";
            this.manufacture_dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.manufacture_dataGrid.Size = new System.Drawing.Size(398, 253);
            this.manufacture_dataGrid.TabIndex = 4;
            // 
            // positionsName_comboBox
            // 
            this.positionsName_comboBox.FormattingEnabled = true;
            this.positionsName_comboBox.Location = new System.Drawing.Point(12, 289);
            this.positionsName_comboBox.Name = "positionsName_comboBox";
            this.positionsName_comboBox.Size = new System.Drawing.Size(121, 21);
            this.positionsName_comboBox.TabIndex = 6;
            // 
            // cook_button
            // 
            this.cook_button.Location = new System.Drawing.Point(12, 335);
            this.cook_button.Name = "cook_button";
            this.cook_button.Size = new System.Drawing.Size(75, 23);
            this.cook_button.TabIndex = 7;
            this.cook_button.Text = "Cook";
            this.cook_button.UseVisualStyleBackColor = true;
            this.cook_button.Click += new System.EventHandler(this.cook_button_Click);
            // 
            // positionsAmount_textBox
            // 
            this.positionsAmount_textBox.Location = new System.Drawing.Point(160, 289);
            this.positionsAmount_textBox.Name = "positionsAmount_textBox";
            this.positionsAmount_textBox.Size = new System.Drawing.Size(100, 20);
            this.positionsAmount_textBox.TabIndex = 8;
            // 
            // positionsCost_textBox
            // 
            this.positionsCost_textBox.Location = new System.Drawing.Point(287, 289);
            this.positionsCost_textBox.Name = "positionsCost_textBox";
            this.positionsCost_textBox.Size = new System.Drawing.Size(100, 20);
            this.positionsCost_textBox.TabIndex = 9;
            this.positionsCost_textBox.Text = "3";
            // 
            // cafes_comboBox
            // 
            this.cafes_comboBox.FormattingEnabled = true;
            this.cafes_comboBox.Location = new System.Drawing.Point(192, 335);
            this.cafes_comboBox.Name = "cafes_comboBox";
            this.cafes_comboBox.Size = new System.Drawing.Size(121, 21);
            this.cafes_comboBox.TabIndex = 10;
            // 
            // manufacture_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 383);
            this.Controls.Add(this.cafes_comboBox);
            this.Controls.Add(this.positionsCost_textBox);
            this.Controls.Add(this.positionsAmount_textBox);
            this.Controls.Add(this.cook_button);
            this.Controls.Add(this.positionsName_comboBox);
            this.Controls.Add(this.send_button);
            this.Controls.Add(this.manufacture_dataGrid);
            this.Name = "manufacture_Form";
            this.Text = "Manufacture";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.manufacture_Form_FormClosing);
            this.Load += new System.EventHandler(this.manufacture_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.manufacture_dataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button send_button;
        private System.Windows.Forms.DataGridView manufacture_dataGrid;
        private System.Windows.Forms.ComboBox positionsName_comboBox;
        private System.Windows.Forms.Button cook_button;
        private System.Windows.Forms.TextBox positionsAmount_textBox;
        private System.Windows.Forms.TextBox positionsCost_textBox;
        private System.Windows.Forms.ComboBox cafes_comboBox;
    }
}