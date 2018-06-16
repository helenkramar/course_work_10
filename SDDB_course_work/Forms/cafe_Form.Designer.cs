namespace Forms
{
    partial class cafe_Form
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
            this.cafe_dataGrid = new System.Windows.Forms.DataGridView();
            this.sell_button = new System.Windows.Forms.Button();
            this.positionsAmount_textBox = new System.Windows.Forms.TextBox();
            this.positionCost_textBox = new System.Windows.Forms.TextBox();
            this.positionsName_textBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.cafe_dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // cafe_dataGrid
            // 
            this.cafe_dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cafe_dataGrid.Location = new System.Drawing.Point(13, 13);
            this.cafe_dataGrid.Name = "cafe_dataGrid";
            this.cafe_dataGrid.Size = new System.Drawing.Size(398, 253);
            this.cafe_dataGrid.TabIndex = 0;
            // 
            // sell_button
            // 
            this.sell_button.Location = new System.Drawing.Point(13, 336);
            this.sell_button.Name = "sell_button";
            this.sell_button.Size = new System.Drawing.Size(75, 23);
            this.sell_button.TabIndex = 1;
            this.sell_button.Text = "Sell";
            this.sell_button.UseVisualStyleBackColor = true;
            this.sell_button.Click += new System.EventHandler(this.sell_button_Click);
            // 
            // positionsAmount_textBox
            // 
            this.positionsAmount_textBox.Location = new System.Drawing.Point(141, 286);
            this.positionsAmount_textBox.Name = "positionsAmount_textBox";
            this.positionsAmount_textBox.Size = new System.Drawing.Size(100, 20);
            this.positionsAmount_textBox.TabIndex = 3;
            // 
            // positionCost_textBox
            // 
            this.positionCost_textBox.Location = new System.Drawing.Point(274, 286);
            this.positionCost_textBox.Name = "positionCost_textBox";
            this.positionCost_textBox.ReadOnly = true;
            this.positionCost_textBox.Size = new System.Drawing.Size(100, 20);
            this.positionCost_textBox.TabIndex = 4;
            // 
            // positionsName_textBox
            // 
            this.positionsName_textBox.Location = new System.Drawing.Point(13, 286);
            this.positionsName_textBox.Name = "positionsName_textBox";
            this.positionsName_textBox.Size = new System.Drawing.Size(100, 20);
            this.positionsName_textBox.TabIndex = 5;
            // 
            // cafe_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 384);
            this.Controls.Add(this.positionsName_textBox);
            this.Controls.Add(this.positionCost_textBox);
            this.Controls.Add(this.positionsAmount_textBox);
            this.Controls.Add(this.sell_button);
            this.Controls.Add(this.cafe_dataGrid);
            this.Name = "cafe_Form";
            this.Text = "Cafe";
            this.Load += new System.EventHandler(this.cafe_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cafe_dataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView cafe_dataGrid;
        private System.Windows.Forms.Button sell_button;
        private System.Windows.Forms.TextBox positionsAmount_textBox;
        private System.Windows.Forms.TextBox positionCost_textBox;
        private System.Windows.Forms.TextBox positionsName_textBox;
    }
}