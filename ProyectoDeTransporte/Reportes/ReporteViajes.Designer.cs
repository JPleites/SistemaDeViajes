
namespace ProyectoDeTransporte.Reportes
{
    partial class ReporteViajes
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
            this.reporte = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.cbfiltrans = new System.Windows.Forms.ComboBox();
            this.searchbtn = new System.Windows.Forms.Button();
            this.cleanbtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.fechaini = new System.Windows.Forms.DateTimePicker();
            this.fechafin = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txttotal = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.reporte)).BeginInit();
            this.SuspendLayout();
            // 
            // reporte
            // 
            this.reporte.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.reporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.reporte.Location = new System.Drawing.Point(0, 177);
            this.reporte.Name = "reporte";
            this.reporte.Size = new System.Drawing.Size(724, 274);
            this.reporte.TabIndex = 0;
            this.reporte.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.reporte_CellClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Filtrar por transportista";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // cbfiltrans
            // 
            this.cbfiltrans.FormattingEnabled = true;
            this.cbfiltrans.Location = new System.Drawing.Point(15, 39);
            this.cbfiltrans.Name = "cbfiltrans";
            this.cbfiltrans.Size = new System.Drawing.Size(200, 21);
            this.cbfiltrans.TabIndex = 4;
            // 
            // searchbtn
            // 
            this.searchbtn.BackColor = System.Drawing.Color.Navy;
            this.searchbtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.searchbtn.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchbtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.searchbtn.Location = new System.Drawing.Point(497, 131);
            this.searchbtn.Name = "searchbtn";
            this.searchbtn.Size = new System.Drawing.Size(100, 40);
            this.searchbtn.TabIndex = 5;
            this.searchbtn.Text = "Buscar";
            this.searchbtn.UseVisualStyleBackColor = false;
            this.searchbtn.Click += new System.EventHandler(this.searchbtn_Click);
            // 
            // cleanbtn
            // 
            this.cleanbtn.BackColor = System.Drawing.Color.Navy;
            this.cleanbtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cleanbtn.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cleanbtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.cleanbtn.Location = new System.Drawing.Point(612, 131);
            this.cleanbtn.Name = "cleanbtn";
            this.cleanbtn.Size = new System.Drawing.Size(100, 40);
            this.cleanbtn.TabIndex = 7;
            this.cleanbtn.Text = "Limpiar";
            this.cleanbtn.UseVisualStyleBackColor = false;
            this.cleanbtn.Click += new System.EventHandler(this.cleanbtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Fecha Inicio";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(224, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Fecha Fin";
            // 
            // fechaini
            // 
            this.fechaini.Location = new System.Drawing.Point(12, 113);
            this.fechaini.Name = "fechaini";
            this.fechaini.Size = new System.Drawing.Size(200, 20);
            this.fechaini.TabIndex = 10;
            this.fechaini.Value = new System.DateTime(2023, 1, 1, 0, 0, 0, 0);
            // 
            // fechafin
            // 
            this.fechafin.Location = new System.Drawing.Point(227, 113);
            this.fechafin.Name = "fechafin";
            this.fechafin.Size = new System.Drawing.Size(200, 20);
            this.fechafin.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(494, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(205, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "Total de Costo de la búsqueda";
            // 
            // txttotal
            // 
            this.txttotal.Location = new System.Drawing.Point(497, 39);
            this.txttotal.Name = "txttotal";
            this.txttotal.Size = new System.Drawing.Size(215, 20);
            this.txttotal.TabIndex = 13;
            // 
            // ReporteViajes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(724, 450);
            this.Controls.Add(this.txttotal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.fechafin);
            this.Controls.Add(this.fechaini);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cleanbtn);
            this.Controls.Add(this.searchbtn);
            this.Controls.Add(this.cbfiltrans);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.reporte);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "ReporteViajes";
            this.Text = "ReporteViajes";
            this.Load += new System.EventHandler(this.ReporteViajes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.reporte)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView reporte;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbfiltrans;
        private System.Windows.Forms.Button searchbtn;
        private System.Windows.Forms.Button cleanbtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker fechaini;
        private System.Windows.Forms.DateTimePicker fechafin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txttotal;
    }
}