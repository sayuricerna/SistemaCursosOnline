namespace SistemaCursosOnline.Views.Reportes
{
    partial class frmReportes
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.vistaCursosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sistemaCursosOnlineDataSet = new SistemaCursosOnline.SistemaCursosOnlineDataSet();
            this.vistaCursosTableAdapter = new SistemaCursosOnline.SistemaCursosOnlineDataSetTableAdapters.VistaCursosTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.vistaCursosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sistemaCursosOnlineDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.BackColor = System.Drawing.Color.WhiteSmoke;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.vistaCursosBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SistemaCursosOnline.Views.Reportes.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 109);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1460, 682);
            this.reportViewer1.TabIndex = 0;
            // 
            // txtBuscar
            // 
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(167, 30);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(524, 34);
            this.txtBuscar.TabIndex = 1;
            this.txtBuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscar_KeyPress);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnBuscar.Image = global::SistemaCursosOnline.Properties.Resources.search__5_;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(705, 25);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(229, 51);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel4.Location = new System.Drawing.Point(167, 66);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(524, 10);
            this.panel4.TabIndex = 4;
            // 
            // vistaCursosBindingSource
            // 
            this.vistaCursosBindingSource.DataMember = "VistaCursos";
            this.vistaCursosBindingSource.DataSource = this.sistemaCursosOnlineDataSet;
            // 
            // sistemaCursosOnlineDataSet
            // 
            this.sistemaCursosOnlineDataSet.DataSetName = "SistemaCursosOnlineDataSet";
            this.sistemaCursosOnlineDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // vistaCursosTableAdapter
            // 
            this.vistaCursosTableAdapter.ClearBeforeFill = true;
            // 
            // frmReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1484, 803);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmReportes";
            this.Text = "frmReportes";
            this.Load += new System.EventHandler(this.frmReportes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.vistaCursosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sistemaCursosOnlineDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Panel panel4;
        private SistemaCursosOnlineDataSet sistemaCursosOnlineDataSet;
        private System.Windows.Forms.BindingSource vistaCursosBindingSource;
        private SistemaCursosOnlineDataSetTableAdapters.VistaCursosTableAdapter vistaCursosTableAdapter;
    }
}