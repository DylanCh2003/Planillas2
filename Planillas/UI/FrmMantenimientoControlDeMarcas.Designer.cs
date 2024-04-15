namespace Planillas.UI
{
    partial class FrmMantenimientoControlDeMarcas
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
            this.cmbArchivo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvPersonas = new System.Windows.Forms.DataGridView();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.HoraSalida = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.HoraEntrada = new System.Windows.Forms.NumericUpDown();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.linklblmenu = new System.Windows.Forms.LinkLabel();
            this.label6 = new System.Windows.Forms.Label();
            this.mtxId = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HoraSalida)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HoraEntrada)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbArchivo
            // 
            this.cmbArchivo.FormattingEnabled = true;
            this.cmbArchivo.Location = new System.Drawing.Point(506, 60);
            this.cmbArchivo.Name = "cmbArchivo";
            this.cmbArchivo.Size = new System.Drawing.Size(119, 21);
            this.cmbArchivo.TabIndex = 29;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(414, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Archivo";
            // 
            // dgvPersonas
            // 
            this.dgvPersonas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPersonas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPersonas.Location = new System.Drawing.Point(48, 245);
            this.dgvPersonas.Name = "dgvPersonas";
            this.dgvPersonas.Size = new System.Drawing.Size(577, 150);
            this.dgvPersonas.TabIndex = 27;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(530, 197);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(95, 42);
            this.btnGuardar.TabIndex = 26;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // HoraSalida
            // 
            this.HoraSalida.Location = new System.Drawing.Point(133, 150);
            this.HoraSalida.Name = "HoraSalida";
            this.HoraSalida.Size = new System.Drawing.Size(120, 20);
            this.HoraSalida.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Hora salida";
            // 
            // HoraEntrada
            // 
            this.HoraEntrada.Location = new System.Drawing.Point(133, 116);
            this.HoraEntrada.Name = "HoraEntrada";
            this.HoraEntrada.Size = new System.Drawing.Size(120, 20);
            this.HoraEntrada.TabIndex = 23;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(133, 84);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(200, 20);
            this.dtpFecha.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Hora Entrada";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Fecha ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Identificación";
            // 
            // linklblmenu
            // 
            this.linklblmenu.AutoSize = true;
            this.linklblmenu.Location = new System.Drawing.Point(684, 9);
            this.linklblmenu.Name = "linklblmenu";
            this.linklblmenu.Size = new System.Drawing.Size(77, 13);
            this.linklblmenu.TabIndex = 64;
            this.linklblmenu.TabStop = true;
            this.linklblmenu.Text = "Menu Principal";
            this.linklblmenu.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblmenu_LinkClicked);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(276, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(150, 19);
            this.label6.TabIndex = 70;
            this.label6.Text = "Control De Marcas";
            // 
            // mtxId
            // 
            this.mtxId.Location = new System.Drawing.Point(133, 53);
            this.mtxId.Mask = "0-0000-0000";
            this.mtxId.Name = "mtxId";
            this.mtxId.Size = new System.Drawing.Size(172, 20);
            this.mtxId.TabIndex = 71;
            // 
            // FrmMantenimientoControlDeMarcas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 426);
            this.Controls.Add(this.mtxId);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.linklblmenu);
            this.Controls.Add(this.cmbArchivo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgvPersonas);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.HoraSalida);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.HoraEntrada);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmMantenimientoControlDeMarcas";
            this.Text = "FrmControlDeMarcas";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HoraSalida)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HoraEntrada)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbArchivo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvPersonas;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.NumericUpDown HoraSalida;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown HoraEntrada;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linklblmenu;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox mtxId;
    }
}