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
            this.txt_modificacion = new System.Windows.Forms.ComboBox();
            this.lbl_modificacion = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_etapa = new System.Windows.Forms.Label();
            this.txt_etapa = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txt_opcion
            // 
            this.txt_opcion.FormattingEnabled = true;
            this.txt_opcion.Items.AddRange(new object[] {
            "Cambiar permiso para profesor y materia particular",
            "Cambiar permiso para curso completo",
            "Cambiar permiso para todos los cursos"});
            this.txt_opcion.Location = new System.Drawing.Point(45, 28);
            this.txt_opcion.Name = "txt_opcion";
            this.txt_opcion.Size = new System.Drawing.Size(211, 21);
            this.txt_opcion.TabIndex = 0;
            this.txt_opcion.SelectedIndexChanged += new System.EventHandler(this.txt_opcion_SelectedIndexChanged);
            // 
            // txt_curso
            // 
            this.txt_curso.FormattingEnabled = true;
            this.txt_curso.Location = new System.Drawing.Point(45, 189);
            this.txt_curso.Name = "txt_curso";
            this.txt_curso.Size = new System.Drawing.Size(211, 21);
            this.txt_curso.TabIndex = 1;
            this.txt_curso.Visible = false;
            this.txt_curso.SelectedIndexChanged += new System.EventHandler(this.txt_curso_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Seleccione opcion";
            // 
            // lbl_curso
            // 
            this.lbl_curso.AutoSize = true;
            this.lbl_curso.Location = new System.Drawing.Point(44, 173);
            this.lbl_curso.Name = "lbl_curso";
            this.lbl_curso.Size = new System.Drawing.Size(89, 13);
            this.lbl_curso.TabIndex = 3;
            this.lbl_curso.Text = "Seleccione curso";
            this.lbl_curso.Visible = false;
            // 
            // lbl_profesor
            // 
            this.lbl_profesor.AutoSize = true;
            this.lbl_profesor.Location = new System.Drawing.Point(44, 119);
            this.lbl_profesor.Name = "lbl_profesor";
            this.lbl_profesor.Size = new System.Drawing.Size(101, 13);
            this.lbl_profesor.TabIndex = 4;
            this.lbl_profesor.Text = "Seleccione profesor";
            this.lbl_profesor.Visible = false;
            // 
            // lbl_materia
            // 
            this.lbl_materia.AutoSize = true;
            this.lbl_materia.Location = new System.Drawing.Point(44, 223);
            this.lbl_materia.Name = "lbl_materia";
            this.lbl_materia.Size = new System.Drawing.Size(97, 13);
            this.lbl_materia.TabIndex = 5;
            this.lbl_materia.Text = "Seleccione materia";
            this.lbl_materia.Visible = false;
            // 
            // txt_profesor
            // 
            this.txt_profesor.FormattingEnabled = true;
            this.txt_profesor.Location = new System.Drawing.Point(45, 134);
            this.txt_profesor.Name = "txt_profesor";
            this.txt_profesor.Size = new System.Drawing.Size(208, 21);
            this.txt_profesor.TabIndex = 6;
            this.txt_profesor.Visible = false;
            this.txt_profesor.SelectedIndexChanged += new System.EventHandler(this.txt_profesor_SelectedIndexChanged);
            // 
            // txt_materia
            // 
            this.txt_materia.FormattingEnabled = true;
            this.txt_materia.Location = new System.Drawing.Point(45, 239);
            this.txt_materia.Name = "txt_materia";
            this.txt_materia.Size = new System.Drawing.Size(211, 21);
            this.txt_materia.TabIndex = 7;
            this.txt_materia.Visible = false;
            // 
            // txt_modificacion
            // 
            this.txt_modificacion.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.txt_modificacion.FormattingEnabled = true;
            this.txt_modificacion.Items.AddRange(new object[] {
            "Habilitado",
            "Deshabilitado"});
            this.txt_modificacion.Location = new System.Drawing.Point(382, 138);
            this.txt_modificacion.Name = "txt_modificacion";
            this.txt_modificacion.Size = new System.Drawing.Size(200, 21);
            this.txt_modificacion.TabIndex = 8;
            this.txt_modificacion.UseWaitCursor = true;
            // 
            // lbl_modificacion
            // 
            this.lbl_modificacion.AutoSize = true;
            this.lbl_modificacion.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.lbl_modificacion.Location = new System.Drawing.Point(382, 119);
            this.lbl_modificacion.Name = "lbl_modificacion";
            this.lbl_modificacion.Size = new System.Drawing.Size(122, 13);
            this.lbl_modificacion.TabIndex = 9;
            this.lbl_modificacion.Text = "Seleccione modificacion";
            this.lbl_modificacion.UseWaitCursor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(507, 237);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Confirmar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.UseWaitCursor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(379, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Desde";
            this.label2.UseWaitCursor = true;
            this.label2.Visible = false;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.dateTimePicker1.CustomFormat = "";
            this.dateTimePicker1.Location = new System.Drawing.Point(382, 28);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 12;
            this.dateTimePicker1.UseWaitCursor = true;
            this.dateTimePicker1.Visible = false;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.dateTimePicker2.Location = new System.Drawing.Point(382, 75);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 13;
            this.dateTimePicker2.UseWaitCursor = true;
            this.dateTimePicker2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(382, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Hasta";
            this.label3.UseWaitCursor = true;
            this.label3.Visible = false;
            // 
            // lbl_etapa
            // 
            this.lbl_etapa.AutoSize = true;
            this.lbl_etapa.Location = new System.Drawing.Point(44, 62);
            this.lbl_etapa.Name = "lbl_etapa";
            this.lbl_etapa.Size = new System.Drawing.Size(35, 13);
            this.lbl_etapa.TabIndex = 15;
            this.lbl_etapa.Text = "Etapa";
            // 
            // txt_etapa
            // 
            this.txt_etapa.FormattingEnabled = true;
            this.txt_etapa.Items.AddRange(new object[] {
            "Primer trimestre",
            "Segundo trimestre",
            "Tercer trimestre",
            "Semana extra"});
            this.txt_etapa.Location = new System.Drawing.Point(45, 78);
            this.txt_etapa.Name = "txt_etapa";
            this.txt_etapa.Size = new System.Drawing.Size(205, 21);
            this.txt_etapa.TabIndex = 16;
            // 
            // PermisosParaRegistrarNotas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txt_etapa);
            this.Controls.Add(this.lbl_etapa);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbl_modificacion);
            this.Controls.Add(this.txt_modificacion);
            this.Controls.Add(this.txt_materia);
            this.Controls.Add(this.txt_profesor);
            this.Controls.Add(this.lbl_materia);
            this.Controls.Add(this.lbl_profesor);
            this.Controls.Add(this.lbl_curso);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_curso);
            this.Controls.Add(this.txt_opcion);
            this.Name = "PermisosParaRegistrarNotas";
            this.Text = "PermisosParaRegistrarNotas";
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.ComboBox txt_modificacion;
        private System.Windows.Forms.Label lbl_modificacion;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_etapa;
        private System.Windows.Forms.ComboBox txt_etapa;
    }
}