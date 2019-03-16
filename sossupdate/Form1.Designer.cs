namespace sossupdate
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("");
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.OptionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.responce = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.M5ITCD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MZIZE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QTYINHAND = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtyOnWeb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Updated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LUUPDATEWEB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iTEMBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.oNLINEDBDataSet = new sossupdate.ONLINEDBDataSet();
            this.iTEMTableAdapter = new sossupdate.ONLINEDBDataSetTableAdapters.ITEMTableAdapter();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnsyncstart = new System.Windows.Forms.Button();
            this.btnsyncstop = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnopennilsonlinestore = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Code = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Qty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iTEMBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oNLINEDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OptionID,
            this.responce,
            this.ProductID,
            this.M5ITCD,
            this.MZIZE,
            this.QTYINHAND,
            this.QtyOnWeb,
            this.Updated,
            this.LUUPDATEWEB});
            this.dataGridView1.Location = new System.Drawing.Point(3, 122);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(889, 501);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            // 
            // OptionID
            // 
            this.OptionID.DataPropertyName = "OptionID";
            this.OptionID.HeaderText = "Option Value ID";
            this.OptionID.Name = "OptionID";
            this.OptionID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.OptionID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // responce
            // 
            this.responce.DataPropertyName = "responce";
            this.responce.HeaderText = "responce";
            this.responce.Name = "responce";
            this.responce.ReadOnly = true;
            // 
            // ProductID
            // 
            this.ProductID.DataPropertyName = "ProductID";
            this.ProductID.HeaderText = "ProductID";
            this.ProductID.Name = "ProductID";
            this.ProductID.ReadOnly = true;
            this.ProductID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // M5ITCD
            // 
            this.M5ITCD.DataPropertyName = "M5ITCD";
            this.M5ITCD.HeaderText = "M5ITCD";
            this.M5ITCD.Name = "M5ITCD";
            // 
            // MZIZE
            // 
            this.MZIZE.DataPropertyName = "MZIZE";
            this.MZIZE.HeaderText = "MZIZE";
            this.MZIZE.Name = "MZIZE";
            // 
            // QTYINHAND
            // 
            this.QTYINHAND.DataPropertyName = "QTYINHAND";
            this.QTYINHAND.HeaderText = "QTYINHAND";
            this.QTYINHAND.Name = "QTYINHAND";
            // 
            // QtyOnWeb
            // 
            this.QtyOnWeb.DataPropertyName = "QtyOnWeb";
            this.QtyOnWeb.HeaderText = "QtyOnWeb";
            this.QtyOnWeb.Name = "QtyOnWeb";
            this.QtyOnWeb.ReadOnly = true;
            // 
            // Updated
            // 
            this.Updated.DataPropertyName = "Updated";
            this.Updated.HeaderText = "Updated";
            this.Updated.Name = "Updated";
            this.Updated.ReadOnly = true;
            // 
            // LUUPDATEWEB
            // 
            this.LUUPDATEWEB.DataPropertyName = "LUUPDATEWEB";
            this.LUUPDATEWEB.HeaderText = "LUUPDATEWEB";
            this.LUUPDATEWEB.Name = "LUUPDATEWEB";
            // 
            // iTEMBindingSource
            // 
            this.iTEMBindingSource.DataMember = "ITEM";
            this.iTEMBindingSource.DataSource = this.oNLINEDBDataSet;
            // 
            // oNLINEDBDataSet
            // 
            this.oNLINEDBDataSet.DataSetName = "ONLINEDBDataSet";
            this.oNLINEDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // iTEMTableAdapter
            // 
            this.iTEMTableAdapter.ClearBeforeFill = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUpdate.Location = new System.Drawing.Point(157, 654);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(157, 28);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Update Data";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnsyncstart
            // 
            this.btnsyncstart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnsyncstart.Location = new System.Drawing.Point(323, 655);
            this.btnsyncstart.Margin = new System.Windows.Forms.Padding(4);
            this.btnsyncstart.Name = "btnsyncstart";
            this.btnsyncstart.Size = new System.Drawing.Size(136, 27);
            this.btnsyncstart.TabIndex = 2;
            this.btnsyncstart.Text = "Start Sync";
            this.btnsyncstart.UseVisualStyleBackColor = true;
            this.btnsyncstart.Click += new System.EventHandler(this.btnsyncstart_Click);
            // 
            // btnsyncstop
            // 
            this.btnsyncstop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnsyncstop.Enabled = false;
            this.btnsyncstop.Location = new System.Drawing.Point(467, 655);
            this.btnsyncstop.Margin = new System.Windows.Forms.Padding(4);
            this.btnsyncstop.Name = "btnsyncstop";
            this.btnsyncstop.Size = new System.Drawing.Size(136, 27);
            this.btnsyncstop.TabIndex = 3;
            this.btnsyncstop.Text = "Stop Sync";
            this.btnsyncstop.UseVisualStyleBackColor = true;
            this.btnsyncstop.Click += new System.EventHandler(this.btnsyncstop_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(516, 78);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 4;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(83, 78);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(424, 22);
            this.textBox1.TabIndex = 5;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(900, 122);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(589, 500);
            this.dataGridView2.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 78);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "M5ITCD";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.ErrorImage")));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(1199, 2);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(291, 112);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // btnopennilsonlinestore
            // 
            this.btnopennilsonlinestore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnopennilsonlinestore.Location = new System.Drawing.Point(1313, 593);
            this.btnopennilsonlinestore.Margin = new System.Windows.Forms.Padding(4);
            this.btnopennilsonlinestore.Name = "btnopennilsonlinestore";
            this.btnopennilsonlinestore.Size = new System.Drawing.Size(177, 28);
            this.btnopennilsonlinestore.TabIndex = 10;
            this.btnopennilsonlinestore.Text = "Open New Window";
            this.btnopennilsonlinestore.UseVisualStyleBackColor = true;
            this.btnopennilsonlinestore.Click += new System.EventHandler(this.btnopennilsonlinestore_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numericUpDown1.Location = new System.Drawing.Point(12, 658);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 22);
            this.numericUpDown1.TabIndex = 11;
            this.numericUpDown1.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Time,
            this.Code,
            this.Qty,
            this.Status});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3});
            this.listView1.Location = new System.Drawing.Point(3, 122);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1486, 501);
            this.listView1.TabIndex = 12;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.Visible = false;
            // 
            // Time
            // 
            this.Time.Text = "Time";
            this.Time.Width = 115;
            // 
            // Code
            // 
            this.Code.Text = "Code";
            this.Code.Width = 114;
            // 
            // Qty
            // 
            this.Qty.Text = "Qty";
            // 
            // Status
            // 
            this.Status.Text = "Status";
            this.Status.Width = 1053;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "Shopperz Inventery Update";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1507, 692);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.btnopennilsonlinestore);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnsyncstop);
            this.Controls.Add(this.btnsyncstart);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Shopperz Inventory sync";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iTEMBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oNLINEDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private ONLINEDBDataSet oNLINEDBDataSet;
        private System.Windows.Forms.BindingSource iTEMBindingSource;
        private ONLINEDBDataSetTableAdapters.ITEMTableAdapter iTEMTableAdapter;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnsyncstart;
        private System.Windows.Forms.Button btnsyncstop;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn OptionID;
        private System.Windows.Forms.DataGridViewTextBoxColumn responce;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn M5ITCD;
        private System.Windows.Forms.DataGridViewTextBoxColumn MZIZE;
        private System.Windows.Forms.DataGridViewTextBoxColumn QTYINHAND;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtyOnWeb;
        private System.Windows.Forms.DataGridViewTextBoxColumn Updated;
        private System.Windows.Forms.DataGridViewTextBoxColumn LUUPDATEWEB;
        private System.Windows.Forms.Button btnopennilsonlinestore;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader Time;
        private System.Windows.Forms.ColumnHeader Code;
        private System.Windows.Forms.ColumnHeader Qty;
        private System.Windows.Forms.ColumnHeader Status;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}

