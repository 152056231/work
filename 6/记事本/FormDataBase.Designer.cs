namespace 记事本
{
    partial class FormDataBase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDataBase));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.noteBookDataSet = new 记事本.NoteBookDataSet();
            this.noteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.noteTableAdapter = new 记事本.NoteBookDataSetTableAdapters.NoteTableAdapter();
            this.notePathNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noteNotesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noteDateTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.noteBookDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.noteBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.notePathNameDataGridViewTextBoxColumn,
            this.noteNotesDataGridViewTextBoxColumn,
            this.noteDateTimeDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.noteBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(59, 49);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(626, 196);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // noteBookDataSet
            // 
            this.noteBookDataSet.DataSetName = "NoteBookDataSet";
            this.noteBookDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // noteBindingSource
            // 
            this.noteBindingSource.DataMember = "Note";
            this.noteBindingSource.DataSource = this.noteBookDataSet;
            // 
            // noteTableAdapter
            // 
            this.noteTableAdapter.ClearBeforeFill = true;
            // 
            // notePathNameDataGridViewTextBoxColumn
            // 
            this.notePathNameDataGridViewTextBoxColumn.DataPropertyName = "Note_PathName";
            this.notePathNameDataGridViewTextBoxColumn.HeaderText = "Note_PathName";
            this.notePathNameDataGridViewTextBoxColumn.Name = "notePathNameDataGridViewTextBoxColumn";
            // 
            // noteNotesDataGridViewTextBoxColumn
            // 
            this.noteNotesDataGridViewTextBoxColumn.DataPropertyName = "Note_Notes";
            this.noteNotesDataGridViewTextBoxColumn.HeaderText = "Note_Notes";
            this.noteNotesDataGridViewTextBoxColumn.Name = "noteNotesDataGridViewTextBoxColumn";
            // 
            // noteDateTimeDataGridViewTextBoxColumn
            // 
            this.noteDateTimeDataGridViewTextBoxColumn.DataPropertyName = "Note_DateTime";
            this.noteDateTimeDataGridViewTextBoxColumn.HeaderText = "Note_DateTime";
            this.noteDateTimeDataGridViewTextBoxColumn.Name = "noteDateTimeDataGridViewTextBoxColumn";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Window;
            this.richTextBox1.Location = new System.Drawing.Point(59, 254);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(626, 220);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(59, 518);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 39);
            this.button1.TabIndex = 2;
            this.button1.Text = "Update";
            this.button1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Red;
            this.button2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Location = new System.Drawing.Point(579, 518);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(106, 39);
            this.button2.TabIndex = 3;
            this.button2.Text = "Delete";
            this.button2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FormDataBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(738, 582);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormDataBase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormDataBase";
            this.Load += new System.EventHandler(this.FormDataBase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.noteBookDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.noteBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private NoteBookDataSet noteBookDataSet;
        private System.Windows.Forms.BindingSource noteBindingSource;
        private NoteBookDataSetTableAdapters.NoteTableAdapter noteTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn notePathNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn noteNotesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn noteDateTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}