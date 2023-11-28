namespace ProyectoEscuela
{
    partial class TomarAsistencia
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
            this.btn_presente = new System.Windows.Forms.Button();
            this.lbl_alumno = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_buscarAlumno = new System.Windows.Forms.Button();
            this.btn_prese = new System.Windows.Forms.Button();
            this.btn_ausente = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_presente
            // 
            this.btn_presente.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_presente.Location = new System.Drawing.Point(727, 143);
            this.btn_presente.Margin = new System.Windows.Forms.Padding(4);
            this.btn_presente.Name = "btn_presente";
            this.btn_presente.Size = new System.Drawing.Size(156, 39);
            this.btn_presente.TabIndex = 0;
            this.btn_presente.Text = "Siguiente";
            this.btn_presente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_presente.UseVisualStyleBackColor = true;
            this.btn_presente.Click += new System.EventHandler(this.btn_presente_Click);
            // 
            // lbl_alumno
            // 
            this.lbl_alumno.AutoSize = true;
            this.lbl_alumno.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.25F);
            this.lbl_alumno.Location = new System.Drawing.Point(323, 31);
            this.lbl_alumno.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_alumno.Name = "lbl_alumno";
            this.lbl_alumno.Size = new System.Drawing.Size(434, 55);
            this.lbl_alumno.TabIndex = 1;
            this.lbl_alumno.Text = "Nombre de alumno";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(113, 108);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(132, 22);
            this.textBox1.TabIndex = 2;
            // 
            // btn_buscarAlumno
            // 
            this.btn_buscarAlumno.Location = new System.Drawing.Point(33, 106);
            this.btn_buscarAlumno.Margin = new System.Windows.Forms.Padding(4);
            this.btn_buscarAlumno.Name = "btn_buscarAlumno";
            this.btn_buscarAlumno.Size = new System.Drawing.Size(72, 28);
            this.btn_buscarAlumno.TabIndex = 3;
            this.btn_buscarAlumno.Text = "Buscar";
            this.btn_buscarAlumno.UseVisualStyleBackColor = true;
            this.btn_buscarAlumno.Click += new System.EventHandler(this.btn_buscarAlumno_Click);
            // 
            // btn_prese
            // 
            this.btn_prese.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_prese.Location = new System.Drawing.Point(523, 143);
            this.btn_prese.Margin = new System.Windows.Forms.Padding(4);
            this.btn_prese.Name = "btn_prese";
            this.btn_prese.Size = new System.Drawing.Size(156, 39);
            this.btn_prese.TabIndex = 4;
            this.btn_prese.Text = "Presente";
            this.btn_prese.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_prese.UseVisualStyleBackColor = true;
            this.btn_prese.Click += new System.EventHandler(this.btn_prese_Click);
            // 
            // btn_ausente
            // 
            this.btn_ausente.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.btn_ausente.Location = new System.Drawing.Point(333, 143);
            this.btn_ausente.Margin = new System.Windows.Forms.Padding(4);
            this.btn_ausente.Name = "btn_ausente";
            this.btn_ausente.Size = new System.Drawing.Size(148, 39);
            this.btn_ausente.TabIndex = 6;
            this.btn_ausente.Text = "Ausente";
            this.btn_ausente.UseVisualStyleBackColor = true;
            this.btn_ausente.Click += new System.EventHandler(this.btn_ausente_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 71);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Fecha";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(99, 64);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(195, 22);
            this.dateTimePicker1.TabIndex = 8;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(99, 31);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(160, 24);
            this.comboBox1.TabIndex = 9;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombre,
            this.apellido,
            this.fechaDataGridViewTextBoxColumn,
            this.estado});
            this.dataGridView1.DataSource = this.bindingSource1;
            this.dataGridView1.Location = new System.Drawing.Point(33, 229);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(1017, 310);
            this.dataGridView1.TabIndex = 10;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // nombre
            // 
            this.nombre.DataPropertyName = "nombre";
            this.nombre.HeaderText = "nombre";
            this.nombre.MinimumWidth = 6;
            this.nombre.Name = "nombre";
            // 
            // apellido
            // 
            this.apellido.DataPropertyName = "apellido";
            this.apellido.HeaderText = "apellido";
            this.apellido.MinimumWidth = 6;
            this.apellido.Name = "apellido";
            // 
            // fechaDataGridViewTextBoxColumn
            // 
            this.fechaDataGridViewTextBoxColumn.DataPropertyName = "fecha";
            this.fechaDataGridViewTextBoxColumn.HeaderText = "fecha";
            this.fechaDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.fechaDataGridViewTextBoxColumn.Name = "fechaDataGridViewTextBoxColumn";
            // 
            // estado
            // 
            this.estado.DataPropertyName = "estado";
            this.estado.HeaderText = "estado";
            this.estado.MinimumWidth = 6;
            this.estado.Name = "estado";
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(EntidadAlumno.Faltas);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 41);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Curso";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.label1.Location = new System.Drawing.Point(327, 85);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 30);
            this.label1.TabIndex = 5;
            this.label1.Text = "DNI del alumno";
            // 
            // TomarAsistencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1236, 558);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_ausente);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_prese);
            this.Controls.Add(this.btn_buscarAlumno);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lbl_alumno);
            this.Controls.Add(this.btn_presente);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TomarAsistencia";
            this.Text = "Registro de asistencia";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_presente;
        private System.Windows.Forms.Label lbl_alumno;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_buscarAlumno;
        private System.Windows.Forms.Button btn_prese;
        private System.Windows.Forms.Button btn_ausente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn estado;
        private System.Windows.Forms.Label label1;
    }
}