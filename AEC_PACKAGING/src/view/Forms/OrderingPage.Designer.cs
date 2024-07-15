using System.Windows.Forms;

namespace AEC_PACKAGING.src.view.Forms
{
    partial class OrderingPage
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cboSearch = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lbTitle = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabDisplay = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabSearchResult = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.btnDelete2 = new System.Windows.Forms.Button();
            this.btnEdit2 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabDisplay.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabSearchResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Yellow;
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1.323251F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.466919F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.96408F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.2949F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.797101F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.49068F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.46584F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1.035197F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbSearch, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSearch, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cboSearch, 6, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 4, 0, 2);
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1087, 51);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(675, 4);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.label2.Size = new System.Drawing.Size(119, 45);
            this.label2.TabIndex = 4;
            this.label2.Text = "Search by:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbSearch
            // 
            this.tbSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearch.Location = new System.Drawing.Point(217, 7);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(389, 38);
            this.tbSearch.TabIndex = 1;
            this.tbSearch.Text = "select ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(98, 4);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.label1.Size = new System.Drawing.Size(113, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Ivory;
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSearch.FlatAppearance.BorderSize = 2;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(17, 7);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 39);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cboSearch
            // 
            this.cboSearch.BackColor = System.Drawing.Color.White;
            this.cboSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSearch.FormattingEnabled = true;
            this.cboSearch.Items.AddRange(new object[] {
            "Order ID",
            "Date",
            "Status"});
            this.cboSearch.Location = new System.Drawing.Point(800, 7);
            this.cboSearch.Name = "cboSearch";
            this.cboSearch.Size = new System.Drawing.Size(271, 39);
            this.cboSearch.TabIndex = 5;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Ivory;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel2.Controls.Add(this.lbTitle, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 51);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1087, 35);
            this.tableLayoutPanel2.TabIndex = 14;
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.Location = new System.Drawing.Point(492, 0);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.lbTitle.Size = new System.Drawing.Size(211, 35);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "Order Table";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.Ivory;
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.15475F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 97.84525F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel3.Controls.Add(this.tabControl1, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 86);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 96.33868F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1087, 476);
            this.tableLayoutPanel3.TabIndex = 15;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabDisplay);
            this.tabControl1.Controls.Add(this.tabSearchResult);
            this.tabControl1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(25, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(10, 10);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1027, 470);
            this.tabControl1.TabIndex = 1;
            // 
            // tabDisplay
            // 
            this.tabDisplay.BackColor = System.Drawing.Color.Ivory;
            this.tabDisplay.Controls.Add(this.tableLayoutPanel4);
            this.tabDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabDisplay.ForeColor = System.Drawing.Color.Black;
            this.tabDisplay.Location = new System.Drawing.Point(4, 48);
            this.tabDisplay.Name = "tabDisplay";
            this.tabDisplay.Padding = new System.Windows.Forms.Padding(3);
            this.tabDisplay.Size = new System.Drawing.Size(1019, 418);
            this.tabDisplay.TabIndex = 0;
            this.tabDisplay.Text = "Display";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel5, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.dataGridView1, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1013, 412);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel5.ColumnCount = 3;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel6, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel5.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 353);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(1007, 56);
            this.tableLayoutPanel5.TabIndex = 4;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 5;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel6.Controls.Add(this.btnDelete, 4, 0);
            this.tableLayoutPanel6.Controls.Add(this.btnEdit, 2, 0);
            this.tableLayoutPanel6.Controls.Add(this.btnAdd, 0, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(204, 3);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(598, 50);
            this.tableLayoutPanel6.TabIndex = 1;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDelete.FlatAppearance.BorderSize = 2;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Location = new System.Drawing.Point(479, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(116, 44);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEdit.FlatAppearance.BorderSize = 2;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Location = new System.Drawing.Point(241, 3);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(113, 44);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAdd.FlatAppearance.BorderSize = 2;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Location = new System.Drawing.Point(3, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(113, 44);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.GridColor = System.Drawing.Color.Black;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1007, 344);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            // 
            // tabSearchResult
            // 
            this.tabSearchResult.BackColor = System.Drawing.Color.Ivory;
            this.tabSearchResult.Controls.Add(this.dataGridView2);
            this.tabSearchResult.Controls.Add(this.tableLayoutPanel7);
            this.tabSearchResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabSearchResult.Location = new System.Drawing.Point(4, 48);
            this.tabSearchResult.Name = "tabSearchResult";
            this.tabSearchResult.Padding = new System.Windows.Forms.Padding(3);
            this.tabSearchResult.Size = new System.Drawing.Size(1019, 418);
            this.tabSearchResult.TabIndex = 1;
            this.tabSearchResult.Text = "Search Result";
            // 
            // dataGridView2
            // 
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.GridColor = System.Drawing.Color.Black;
            this.dataGridView2.Location = new System.Drawing.Point(3, 3);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(1013, 356);
            this.dataGridView2.TabIndex = 4;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 3;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel7.Controls.Add(this.tableLayoutPanel8, 1, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(3, 359);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(1013, 56);
            this.tableLayoutPanel7.TabIndex = 3;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 3;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel8.Controls.Add(this.btnDelete2, 2, 0);
            this.tableLayoutPanel8.Controls.Add(this.btnEdit2, 0, 0);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(306, 3);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 1;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(399, 50);
            this.tableLayoutPanel8.TabIndex = 0;
            // 
            // btnDelete2
            // 
            this.btnDelete2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnDelete2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDelete2.FlatAppearance.BorderSize = 2;
            this.btnDelete2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete2.Location = new System.Drawing.Point(269, 3);
            this.btnDelete2.Name = "btnDelete2";
            this.btnDelete2.Size = new System.Drawing.Size(127, 44);
            this.btnDelete2.TabIndex = 7;
            this.btnDelete2.Text = "Delete";
            this.btnDelete2.UseVisualStyleBackColor = false;
            this.btnDelete2.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit2
            // 
            this.btnEdit2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnEdit2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEdit2.FlatAppearance.BorderSize = 2;
            this.btnEdit2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit2.Location = new System.Drawing.Point(3, 3);
            this.btnEdit2.Name = "btnEdit2";
            this.btnEdit2.Size = new System.Drawing.Size(127, 44);
            this.btnEdit2.TabIndex = 5;
            this.btnEdit2.Text = "Edit";
            this.btnEdit2.UseVisualStyleBackColor = false;
            this.btnEdit2.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // OrderingPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1087, 562);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "OrderingPage";
            this.Text = "Order";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabDisplay.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabSearchResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cboSearch;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabDisplay;
        private System.Windows.Forms.TabPage tabSearchResult;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.Button btnDelete2;
        private System.Windows.Forms.Button btnEdit2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}