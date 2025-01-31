namespace SistemaCursosOnline.Views
{
    partial class MenuPrincipal
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnProfesores = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnInscripciones = new System.Windows.Forms.Button();
            this.btnEstudiantes = new System.Windows.Forms.Button();
            this.btnCursos = new System.Windows.Forms.Button();
            this.pnlGeneral = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnReportes = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlGeneral.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.CadetBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnReportes);
            this.panel1.Controls.Add(this.btnProfesores);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btnInscripciones);
            this.panel1.Controls.Add(this.btnEstudiantes);
            this.panel1.Controls.Add(this.btnCursos);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(403, 964);
            this.panel1.TabIndex = 0;
            // 
            // btnProfesores
            // 
            this.btnProfesores.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnProfesores.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProfesores.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnProfesores.Image = global::SistemaCursosOnline.Properties.Resources.teacher;
            this.btnProfesores.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProfesores.Location = new System.Drawing.Point(22, 701);
            this.btnProfesores.Name = "btnProfesores";
            this.btnProfesores.Size = new System.Drawing.Size(354, 93);
            this.btnProfesores.TabIndex = 4;
            this.btnProfesores.Text = "Profesores";
            this.btnProfesores.UseVisualStyleBackColor = false;
            this.btnProfesores.Click += new System.EventHandler(this.btnProfesores_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SistemaCursosOnline.Properties.Resources.online_course__2_;
            this.pictureBox1.Location = new System.Drawing.Point(61, 140);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(255, 221);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btnInscripciones
            // 
            this.btnInscripciones.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnInscripciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInscripciones.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnInscripciones.Image = global::SistemaCursosOnline.Properties.Resources.contract;
            this.btnInscripciones.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInscripciones.Location = new System.Drawing.Point(22, 602);
            this.btnInscripciones.Name = "btnInscripciones";
            this.btnInscripciones.Size = new System.Drawing.Size(354, 93);
            this.btnInscripciones.TabIndex = 2;
            this.btnInscripciones.Text = "Inscripciones";
            this.btnInscripciones.UseVisualStyleBackColor = false;
            this.btnInscripciones.Click += new System.EventHandler(this.btnInscripciones_Click);
            // 
            // btnEstudiantes
            // 
            this.btnEstudiantes.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnEstudiantes.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEstudiantes.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnEstudiantes.Image = global::SistemaCursosOnline.Properties.Resources.graduated;
            this.btnEstudiantes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEstudiantes.Location = new System.Drawing.Point(22, 503);
            this.btnEstudiantes.Name = "btnEstudiantes";
            this.btnEstudiantes.Size = new System.Drawing.Size(354, 93);
            this.btnEstudiantes.TabIndex = 1;
            this.btnEstudiantes.Text = "Estudiantes";
            this.btnEstudiantes.UseVisualStyleBackColor = false;
            this.btnEstudiantes.Click += new System.EventHandler(this.btnEstudiantes_Click);
            // 
            // btnCursos
            // 
            this.btnCursos.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnCursos.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCursos.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCursos.Image = global::SistemaCursosOnline.Properties.Resources.course;
            this.btnCursos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCursos.Location = new System.Drawing.Point(22, 404);
            this.btnCursos.Name = "btnCursos";
            this.btnCursos.Size = new System.Drawing.Size(354, 93);
            this.btnCursos.TabIndex = 0;
            this.btnCursos.Text = "Cursos";
            this.btnCursos.UseVisualStyleBackColor = false;
            this.btnCursos.Click += new System.EventHandler(this.btnCursos_Click);
            // 
            // pnlGeneral
            // 
            this.pnlGeneral.Controls.Add(this.label1);
            this.pnlGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGeneral.Location = new System.Drawing.Point(403, 0);
            this.pnlGeneral.Name = "pnlGeneral";
            this.pnlGeneral.Size = new System.Drawing.Size(1097, 964);
            this.pnlGeneral.TabIndex = 1;
            this.pnlGeneral.MouseHover += new System.EventHandler(this.btnCursos_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(307, 387);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(430, 91);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bienvenido";
            // 
            // btnReportes
            // 
            this.btnReportes.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnReportes.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportes.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnReportes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReportes.Location = new System.Drawing.Point(22, 800);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Size = new System.Drawing.Size(354, 93);
            this.btnReportes.TabIndex = 5;
            this.btnReportes.Text = "Reportes";
            this.btnReportes.UseVisualStyleBackColor = false;
            this.btnReportes.Click += new System.EventHandler(this.btnReportes_Click);
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1500, 964);
            this.Controls.Add(this.pnlGeneral);
            this.Controls.Add(this.panel1);
            this.Name = "MenuPrincipal";
            this.Text = "MenuPrincipal";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlGeneral.ResumeLayout(false);
            this.pnlGeneral.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlGeneral;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnInscripciones;
        private System.Windows.Forms.Button btnEstudiantes;
        private System.Windows.Forms.Button btnCursos;
        private System.Windows.Forms.Button btnProfesores;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnReportes;
    }
}