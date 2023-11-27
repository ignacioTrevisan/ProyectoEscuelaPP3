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
            this.btn_presente = new System.Windows.Forms.Button();
            this.lbl_alumno = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_buscarAlumno = new System.Windows.Forms.Button();
            this.btn_prese = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_ausente = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btn_presente
            // 
            this.btn_presente.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_presente.Location = new System.Drawing.Point(563, 89);
            this.btn_presente.Name = "btn_presente";
            this.btn_presente.Size = new System.Drawing.Size(117, 32);
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
            this.lbl_alumno.Location = new System.Drawing.Point(4, 89);
            this.lbl_alumno.Name = "lbl_alumno";
            this.lbl_alumno.Size = new System.Drawing.Size(343, 44);
            this.lbl_alumno.TabIndex = 1;
            this.lbl_alumno.Text = "Nombre de alumno";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(223, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 2;
            // 
            // btn_buscarAlumno
            // 
            this.btn_buscarAlumno.Location = new System.Drawing.Point(342, 10);
            this.btn_buscarAlumno.Name = "btn_buscarAlumno";
            this.btn_buscarAlumno.Size = new System.Drawing.Size(75, 23);
            this.btn_buscarAlumno.TabIndex = 3;
            this.btn_buscarAlumno.Text = "Buscar";
            this.btn_buscarAlumno.UseVisualStyleBackColor = true;
            this.btn_buscarAlumno.Click += new System.EventHandler(this.btn_buscarAlumno_Click);
            // 
            // btn_prese
            // 
            this.btn_prese.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_prese.Location = new System.Drawing.Point(427, 225);
            this.btn_prese.Name = "btn_prese";
            this.btn_prese.Size = new System.Drawing.Size(117, 32);
            this.btn_prese.TabIndex = 4;
            this.btn_prese.Text = "Presente";
            this.btn_prese.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_prese.UseVisualStyleBackColor = true;
            this.btn_prese.Click += new System.EventHandler(this.btn_prese_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.label1.Location = new System.Drawing.Point(130, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "DNI del alumno";
            // 
            // btn_ausente
            // 
            this.btn_ausente.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.btn_ausente.Location = new System.Drawing.Point(133, 225);
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
            this.label2.Location = new System.Drawing.Point(133, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Fecha";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(176, 52);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(147, 20);
            this.dateTimePicker1.TabIndex = 8;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 28);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 9;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // TomarAsistencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
            this.Name = "TomarAsistencia";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_presente;
        private System.Windows.Forms.Label lbl_alumno;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_buscarAlumno;
        private System.Windows.Forms.Button btn_prese;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_ausente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}