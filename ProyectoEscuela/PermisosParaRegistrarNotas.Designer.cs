namespace ProyectoEscuela
{
    partial class PermisosParaRegistrarNotas
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
            this.txt_opcion = new System.Windows.Forms.ComboBox();
            this.txt_curso = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_curso = new System.Windows.Forms.Label();
            this.lbl_profesor = new System.Windows.Forms.Label();
            this.lbl_materia = new System.Windows.Forms.Label();
            this.txt_profesor = new System.Windows.Forms.ComboBox();
            this.txt_materia = new System.Windows.Forms.ComboBox();
            this.lbl_modificacion = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lbl_etapa = new System.Windows.Forms.Label();
            this.txt_etapa = new System.Windows.Forms.ComboBox();
            this.txt_modificacion = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_opcion
            // 
            this.txt_opcion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txt_opcion.FormattingEnabled = true;
            this.txt_opcion.Items.AddRange(new object[] {
            "Cambiar permiso para profesor y materia particular",
            "Cambiar permiso para curso completo",
            "Cambiar permiso para todos los cursos"});
            this.txt_opcion.Location = new System.Drawing.Point(22, 38);
            this.txt_opcion.Name = "txt_opcion";
            this.txt_opcion.Size = new System.Drawing.Size(211, 21);
            this.txt_opcion.TabIndex = 0;
            this.txt_opcion.SelectedIndexChanged += new System.EventHandler(this.txt_opcion_SelectedIndexChanged);
            // 
            // txt_curso
            // 
            this.txt_curso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txt_curso.FormattingEnabled = true;
            this.txt_curso.Location = new System.Drawing.Point(329, 35);
            this.txt_curso.Name = "txt_curso";
            this.txt_curso.Size = new System.Drawing.Size(211, 21);
            this.txt_curso.TabIndex = 1;
            this.txt_curso.Visible = false;
            this.txt_curso.SelectedIndexChanged += new System.EventHandler(this.txt_curso_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Seleccione opcion";
            // 
            // lbl_curso
            // 
            this.lbl_curso.AutoSize = true;
            this.lbl_curso.Location = new System.Drawing.Point(328, 19);
            this.lbl_curso.Name = "lbl_curso";
            this.lbl_curso.Size = new System.Drawing.Size(89, 13);
            this.lbl_curso.TabIndex = 3;
            this.lbl_curso.Text = "Seleccione curso";
            this.lbl_curso.Visible = false;
            // 
            // lbl_profesor
            // 
            this.lbl_profesor.AutoSize = true;
            this.lbl_profesor.Location = new System.Drawing.Point(21, 129);
            this.lbl_profesor.Name = "lbl_profesor";
            this.lbl_profesor.Size = new System.Drawing.Size(101, 13);
            this.lbl_profesor.TabIndex = 4;
            this.lbl_profesor.Text = "Seleccione profesor";
            this.lbl_profesor.Visible = false;
            // 
            // lbl_materia
            // 
            this.lbl_materia.AutoSize = true;
            this.lbl_materia.Location = new System.Drawing.Point(328, 69);
            this.lbl_materia.Name = "lbl_materia";
            this.lbl_materia.Size = new System.Drawing.Size(97, 13);
            this.lbl_materia.TabIndex = 5;
            this.lbl_materia.Text = "Seleccione materia";
            this.lbl_materia.Visible = false;
            // 
            // txt_profesor
            // 
            this.txt_profesor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txt_profesor.FormattingEnabled = true;
            this.txt_profesor.Location = new System.Drawing.Point(22, 144);
            this.txt_profesor.Name = "txt_profesor";
            this.txt_profesor.Size = new System.Drawing.Size(208, 21);
            this.txt_profesor.TabIndex = 6;
            this.txt_profesor.Visible = false;
            this.txt_profesor.SelectedIndexChanged += new System.EventHandler(this.txt_profesor_SelectedIndexChanged);
            // 
            // txt_materia
            // 
            this.txt_materia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txt_materia.FormattingEnabled = true;
            this.txt_materia.Location = new System.Drawing.Point(329, 85);
            this.txt_materia.Name = "txt_materia";
            this.txt_materia.Size = new System.Drawing.Size(211, 21);
            this.txt_materia.TabIndex = 7;
            this.txt_materia.Visible = false;
            // 
            // lbl_modificacion
            // 
            this.lbl_modificacion.AutoSize = true;
            this.lbl_modificacion.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.lbl_modificacion.Location = new System.Drawing.Point(328, 129);
            this.lbl_modificacion.Name = "lbl_modificacion";
            this.lbl_modificacion.Size = new System.Drawing.Size(122, 13);
            this.lbl_modificacion.TabIndex = 9;
            this.lbl_modificacion.Text = "Seleccione modificacion";
            this.lbl_modificacion.UseWaitCursor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(581, 146);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Confirmar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.UseWaitCursor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbl_etapa
            // 
            this.lbl_etapa.AutoSize = true;
            this.lbl_etapa.Location = new System.Drawing.Point(21, 72);
            this.lbl_etapa.Name = "lbl_etapa";
            this.lbl_etapa.Size = new System.Drawing.Size(35, 13);
            this.lbl_etapa.TabIndex = 15;
            this.lbl_etapa.Text = "Etapa";
            // 
            // txt_etapa
            // 
            this.txt_etapa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txt_etapa.FormattingEnabled = true;
            this.txt_etapa.Items.AddRange(new object[] {
            "Primer trimestre",
            "Segundo trimestre",
            "Tercer trimestre",
            "Semana extra-diciembre",
            "Semana extra-febrero"});
            this.txt_etapa.Location = new System.Drawing.Point(22, 88);
            this.txt_etapa.Name = "txt_etapa";
            this.txt_etapa.Size = new System.Drawing.Size(205, 21);
            this.txt_etapa.TabIndex = 16;
            // 
            // txt_modificacion
            // 
            this.txt_modificacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txt_modificacion.FormattingEnabled = true;
            this.txt_modificacion.Items.AddRange(new object[] {
            "Habilitado",
            "Deshabilitado"});
            this.txt_modificacion.Location = new System.Drawing.Point(331, 146);
            this.txt_modificacion.Name = "txt_modificacion";
            this.txt_modificacion.Size = new System.Drawing.Size(209, 21);
            this.txt_modificacion.TabIndex = 17;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txt_modificacion);
            this.panel1.Controls.Add(this.txt_opcion);
            this.panel1.Controls.Add(this.txt_etapa);
            this.panel1.Controls.Add(this.txt_curso);
            this.panel1.Controls.Add(this.lbl_etapa);
            this.panel1.Controls.Add(this.lbl_curso);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.lbl_profesor);
            this.panel1.Controls.Add(this.lbl_modificacion);
            this.panel1.Controls.Add(this.lbl_materia);
            this.panel1.Controls.Add(this.txt_materia);
            this.panel1.Controls.Add(this.txt_profesor);
            this.panel1.Location = new System.Drawing.Point(45, 238);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(697, 181);
            this.panel1.TabIndex = 18;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.dateTimePicker1);
            this.panel2.Controls.Add(this.comboBox2);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(45, 26);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(697, 113);
            this.panel2.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "accion";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Habilitar",
            "Deshabilitar"});
            this.comboBox1.Location = new System.Drawing.Point(22, 42);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Primer trimestre",
            "Segundo trimestre",
            "Tercer trimestre",
            "Semana extra-diciembre",
            "Semana extra-febrero"});
            this.comboBox2.Location = new System.Drawing.Point(228, 42);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(156, 21);
            this.comboBox2.TabIndex = 2;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(458, 42);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(458, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Fecha";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(228, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Etapa";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(581, 69);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Confirmar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // PermisosParaRegistrarNotas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "PermisosParaRegistrarNotas";
            this.Text = "PermisosParaRegistrarNotas";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox txt_opcion;
        private System.Windows.Forms.ComboBox txt_curso;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_curso;
        private System.Windows.Forms.Label lbl_profesor;
        private System.Windows.Forms.Label lbl_materia;
        private System.Windows.Forms.ComboBox txt_profesor;
        private System.Windows.Forms.ComboBox txt_materia;
        private System.Windows.Forms.Label lbl_modificacion;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbl_etapa;
        private System.Windows.Forms.ComboBox txt_etapa;
        private System.Windows.Forms.ComboBox txt_modificacion;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
    }
}