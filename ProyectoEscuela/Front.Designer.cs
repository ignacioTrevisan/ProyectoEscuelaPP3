namespace ProyectoEscuela
{
    partial class Front
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_nuevoAlumno = new System.Windows.Forms.Button();
            this.btn_asistencias = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_nuevoAlumno
            // 
            this.btn_nuevoAlumno.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_nuevoAlumno.Location = new System.Drawing.Point(15, 25);
            this.btn_nuevoAlumno.Name = "btn_nuevoAlumno";
            this.btn_nuevoAlumno.Size = new System.Drawing.Size(187, 57);
            this.btn_nuevoAlumno.TabIndex = 0;
            this.btn_nuevoAlumno.Text = "Alumnos";
            this.btn_nuevoAlumno.UseVisualStyleBackColor = true;
            this.btn_nuevoAlumno.Click += new System.EventHandler(this.btn_nuevoAlumno_Click);
            // 
            // btn_asistencias
            // 
            this.btn_asistencias.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_asistencias.Location = new System.Drawing.Point(15, 115);
            this.btn_asistencias.Name = "btn_asistencias";
            this.btn_asistencias.Size = new System.Drawing.Size(187, 57);
            this.btn_asistencias.TabIndex = 1;
            this.btn_asistencias.Text = "Tomar asistencia";
            this.btn_asistencias.UseVisualStyleBackColor = true;
            this.btn_asistencias.Click += new System.EventHandler(this.btn_asistencias_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(15, 200);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(187, 57);
            this.button2.TabIndex = 5;
            this.button2.Text = "Consultar alumno";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(238, 115);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(187, 57);
            this.button3.TabIndex = 6;
            this.button3.Text = "Registrar notas";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(238, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(187, 57);
            this.button1.TabIndex = 7;
            this.button1.Text = "Espacios y recursos";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(238, 200);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(187, 57);
            this.button5.TabIndex = 9;
            this.button5.Text = "Noticias";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(274, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 36);
            this.label1.TabIndex = 10;
            this.label1.Text = "Bienvenido";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.btn_nuevoAlumno);
            this.panel1.Controls.Add(this.btn_asistencias);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button1);
            this.panel1.ForeColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(37, 94);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(666, 286);
            this.panel1.TabIndex = 11;
            // 
            // button4
            // 
            this.button4.Enabled = false;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(461, 25);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(187, 57);
            this.button4.TabIndex = 10;
            this.button4.Text = "Inscripciones";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(9, 31);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(733, 46);
            this.panel2.TabIndex = 12;
            // 
            // Front
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(753, 391);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Front";
            this.Text = "Asociacion Integral Vuriloche";
            this.Load += new System.EventHandler(this.Front_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_nuevoAlumno;
        private System.Windows.Forms.Button btn_asistencias;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button4;
    }
}

