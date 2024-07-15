namespace AEC_PACKAGING.src.view.Forms
{
    partial class ProductItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductItem));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbProductName = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.53846F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 76.92308F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.53846F));
            this.tableLayoutPanel1.Controls.Add(this.lbProductName, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.48951F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 69.93008F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.48951F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(205, 205);
            this.tableLayoutPanel1.TabIndex = 6;
            this.tableLayoutPanel1.Click += new System.EventHandler(this.ProductItem_Click);
            this.tableLayoutPanel1.DoubleClick += new System.EventHandler(this.ProductItem_DoubleClick);
            this.tableLayoutPanel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListItem_MouseClick);
            this.tableLayoutPanel1.MouseEnter += new System.EventHandler(this.ListItem_MouseEnter);
            this.tableLayoutPanel1.MouseLeave += new System.EventHandler(this.ListItem_MouseLeave);
            // 
            // lbProductName
            // 
            this.lbProductName.AutoSize = true;
            this.lbProductName.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbProductName.Location = new System.Drawing.Point(34, 158);
            this.lbProductName.Name = "lbProductName";
            this.lbProductName.Size = new System.Drawing.Size(130, 19);
            this.lbProductName.TabIndex = 0;
            this.lbProductName.Text = "ProductName";
            this.lbProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbProductName.Click += new System.EventHandler(this.ProductItem_Click);
            this.lbProductName.DoubleClick += new System.EventHandler(this.ProductItem_DoubleClick);
            this.lbProductName.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListItem_MouseClick);
            this.lbProductName.MouseEnter += new System.EventHandler(this.ListItem_MouseEnter);
            this.lbProductName.MouseLeave += new System.EventHandler(this.ListItem_MouseLeave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(34, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(136, 123);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.ProductItem_Click);
            this.pictureBox1.DoubleClick += new System.EventHandler(this.ProductItem_DoubleClick);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListItem_MouseClick);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.ListItem_MouseEnter);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.ListItem_MouseLeave);
            // 
            // ProductItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ProductItem";
            this.Size = new System.Drawing.Size(205, 205);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbProductName;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
