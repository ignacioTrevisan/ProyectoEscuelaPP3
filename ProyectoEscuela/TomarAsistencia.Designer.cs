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
            this.lbl_alumno = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_buscarAlumno = new System.Windows.Forms.Button();
            this.btn_prese = new System.Windows.Forms.Button();
            this.btn_ausente = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.nombreDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apellidoDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dniDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cursoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadoDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadFaltas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dniDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_alumno
            // 
            this.lbl_alumno.AutoSize = true;
            this.lbl_alumno.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.25F);
            this.lbl_alumno.Location = new System.Drawing.Point(242, 25);
            this.lbl_alumno.Name = "lbl_alumno";
            this.lbl_alumno.Size = new System.Drawing.Size(343, 44);
            this.lbl_alumno.TabIndex = 1;
            this.lbl_alumno.Text = "Nombre de alumno";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(85, 88);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 2;
            // 
            // btn_buscarAlumno
            // 
            this.btn_buscarAlumno.Location = new System.Drawing.Point(25, 86);
            this.btn_buscarAlumno.Name = "btn_buscarAlumno";
            this.btn_buscarAlumno.Size = new System.Drawing.Size(54, 23);
            this.btn_buscarAlumno.TabIndex = 3;
            this.btn_buscarAlumno.Text = "Buscar";
            this.btn_buscarAlumno.UseVisualStyleBackColor = true;
            this.btn_buscarAlumno.Click += new System.EventHandler(this.btn_buscarAlumno_Click);
            // 
            // btn_prese
            // 
            this.btn_prese.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_prese.Location = new System.Drawing.Point(392, 116);
            this.btn_prese.Name = "btn_prese";
            this.btn_prese.Size = new System.Drawing.Size(117, 32);
            this.btn_prese.TabIndex = 4;
            this.btn_prese.Text = "Presente";
            this.btn_prese.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_prese.UseVisualStyleBackColor = true;
            this.btn_prese.Click += new System.EventHandler(this.btn_prese_Click);
            // 
            // btn_ausente
            // 
            this.btn_ausente.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.btn_ausente.Location = new System.Drawing.Point(250, 116);
            this.btn_ausente.Name = "btn_ausente";
            this.btn_ausente.Size = new System.Drawing.Size(111, 32);
            this.btn_ausente.TabIndex = 6;
            this.btn_ausente.Text = "Ausente";
            this.btn_ausente.UseVisualStyleBackColor = true;
            this.btn_ausente.Click += new System.EventHandler(this.btn_ausente_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Fecha";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(74, 52);
            this.dateTimePicker1.MaxDate = new System.DateTime(2023, 12, 31, 0, 0, 0, 0);
            this.dateTimePicker1.MinDate = new System.DateTime(2023, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(147, 20);
            this.dateTimePicker1.TabIndex = 8;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(74, 25);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(162, 21);
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
            this.dataGridViewTextBoxColumn1,
            this.apellido,
            this.dniDataGridViewTextBoxColumn1});
            this.dataGridView1.DataSource = this.bindingSource1;
            this.dataGridView1.Location = new System.Drawing.Point(25, 191);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(271, 252);
            this.dataGridView1.TabIndex = 10;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(EntidadAlumno.Alumno);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Curso";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.label1.Location = new System.Drawing.Point(245, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "DNI del alumno";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.label4.Location = new System.Drawing.Point(21, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(223, 25);
            this.label4.TabIndex = 12;
            this.label4.Text = "Seleccione el alumno:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.label5.Location = new System.Drawing.Point(348, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(288, 25);
            this.label5.TabIndex = 13;
            this.label5.Text = "Estado de asistencia del día:";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombreDataGridViewTextBoxColumn1,
            this.apellidoDataGridViewTextBoxColumn1,
            this.dniDataGridViewTextBoxColumn,
            this.cursoDataGridViewTextBoxColumn,
            this.estadoDataGridViewTextBoxColumn1,
            this.cantidadFaltas});
            this.dataGridView2.DataSource = this.bindingSource2;
            this.dataGridView2.Location = new System.Drawing.Point(318, 191);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(600, 252);
            this.dataGridView2.TabIndex = 14;
            // 
            // nombreDataGridViewTextBoxColumn1
            // 
            this.nombreDataGridViewTextBoxColumn1.DataPropertyName = "Nombre";
            this.nombreDataGridViewTextBoxColumn1.HeaderText = "Nombre";
            this.nombreDataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.nombreDataGridViewTextBoxColumn1.Name = "nombreDataGridViewTextBoxColumn1";
            this.nombreDataGridViewTextBoxColumn1.Width = 125;
            // 
            // apellidoDataGridViewTextBoxColumn1
            // 
            this.apellidoDataGridViewTextBoxColumn1.DataPropertyName = "Apellido";
            this.apellidoDataGridViewTextBoxColumn1.HeaderText = "Apellido";
            this.apellidoDataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.apellidoDataGridViewTextBoxColumn1.Name = "apellidoDataGridViewTextBoxColumn1";
            this.apellidoDataGridViewTextBoxColumn1.Width = 125;
            // 
            // dniDataGridViewTextBoxColumn
            // 
            this.dniDataGridViewTextBoxColumn.DataPropertyName = "Dni";
            this.dniDataGridViewTextBoxColumn.HeaderText = "Dni";
            this.dniDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.dniDataGridViewTextBoxColumn.Name = "dniDataGridViewTextBoxColumn";
            this.dniDataGridViewTextBoxColumn.Width = 125;
            // 
            // cursoDataGridViewTextBoxColumn
            // 
            this.cursoDataGridViewTextBoxColumn.DataPropertyName = "Curso";
            this.cursoDataGridViewTextBoxColumn.HeaderText = "Curso";
            this.cursoDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.cursoDataGridViewTextBoxColumn.Name = "cursoDataGridViewTextBoxColumn";
            this.cursoDataGridViewTextBoxColumn.Width = 125;
            // 
            // estadoDataGridViewTextBoxColumn1
            // 
            this.estadoDataGridViewTextBoxColumn1.DataPropertyName = "estado";
            this.estadoDataGridViewTextBoxColumn1.HeaderText = "estado";
            this.estadoDataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.estadoDataGridViewTextBoxColumn1.Name = "estadoDataGridViewTextBoxColumn1";
            this.estadoDataGridViewTextBoxColumn1.Width = 125;
            // 
            // cantidadFaltas
            // 
            this.cantidadFaltas.DataPropertyName = "cantidadFaltas";
            this.cantidadFaltas.HeaderText = "cantidadFaltas";
            this.cantidadFaltas.MinimumWidth = 6;
            this.cantidadFaltas.Name = "cantidadFaltas";
            this.cantidadFaltas.Width = 125;
            // 
            // bindingSource2
            // 
            this.bindingSource2.DataSource = typeof(EntidadAlumno.Alumno);
            // 
            // nombre
            // 
            this.nombre.DataPropertyName = "nombre";
            this.nombre.HeaderText = "nombre";
            this.nombre.MinimumWidth = 6;
            this.nombre.Name = "nombre";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "cantidadFaltas";
            this.dataGridViewTextBoxColumn1.HeaderText = "cantidadFaltas";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // apellido
            // 
            this.apellido.DataPropertyName = "apellido";
            this.apellido.HeaderText = "apellido";
            this.apellido.MinimumWidth = 6;
            this.apellido.Name = "apellido";
            // 
            // dniDataGridViewTextBoxColumn1
            // 
            this.dniDataGridViewTextBoxColumn1.DataPropertyName = "Dni";
            this.dniDataGridViewTextBoxColumn1.HeaderText = "Dni";
            this.dniDataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dniDataGridViewTextBoxColumn1.Name = "dniDataGridViewTextBoxColumn1";
            // 
            // TomarAsistencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(927, 453);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
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
            this.Name = "TomarAsistencia";
            this.Text = "Registro de asistencia";
            this.Load += new System.EventHandler(this.TomarAsistencia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.BindingSource bindingSource2;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellidoDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dniDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cursoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadoDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadFaltas;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn dniDataGridViewTextBoxColumn1;
    }
}