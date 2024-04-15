namespace Planillas.UI
{
    partial class FrmCalculoPlanilla
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
            this.button1 = new System.Windows.Forms.Button();
            this.linklblmenu = new System.Windows.Forms.LinkLabel();
            this.dvgColaborador = new System.Windows.Forms.DataGridView();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnCrearEmpleado = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dvgColaborador)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(705, 54);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(74, 33);
            this.button1.TabIndex = 0;
            this.button1.Text = "Calculadora";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // linklblmenu
            // 
            this.linklblmenu.AutoSize = true;
            this.linklblmenu.Location = new System.Drawing.Point(702, 28);
            this.linklblmenu.Name = "linklblmenu";
            this.linklblmenu.Size = new System.Drawing.Size(77, 13);
            this.linklblmenu.TabIndex = 75;
            this.linklblmenu.TabStop = true;
            this.linklblmenu.Text = "Menu Principal";
            this.linklblmenu.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblmenu_LinkClicked);
            // 
            // dvgColaborador
            // 
            this.dvgColaborador.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgColaborador.Location = new System.Drawing.Point(10, 285);
            this.dvgColaborador.Name = "dvgColaborador";
            this.dvgColaborador.Size = new System.Drawing.Size(769, 174);
            this.dvgColaborador.TabIndex = 107;
            this.dvgColaborador.SelectionChanged += new System.EventHandler(this.dvgColaborador_SelectionChanged);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(486, 235);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(99, 44);
            this.btnActualizar.TabIndex = 109;
            this.btnActualizar.Text = "Calcular";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnCrearEmpleado
            // 
            this.btnCrearEmpleado.Location = new System.Drawing.Point(591, 235);
            this.btnCrearEmpleado.Name = "btnCrearEmpleado";
            this.btnCrearEmpleado.Size = new System.Drawing.Size(91, 44);
            this.btnCrearEmpleado.TabIndex = 108;
            this.btnCrearEmpleado.Text = "Guardar";
            this.btnCrearEmpleado.UseVisualStyleBackColor = true;
            this.btnCrearEmpleado.Click += new System.EventHandler(this.btnCrearEmpleado_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(688, 235);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(91, 44);
            this.button3.TabIndex = 110;
            this.button3.Text = "Limpiar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // FrmCalculoPlanilla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 603);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnCrearEmpleado);
            this.Controls.Add(this.dvgColaborador);
            this.Controls.Add(this.linklblmenu);
            this.Controls.Add(this.button1);
            this.Name = "FrmCalculoPlanilla";
            this.Text = "FrmCalculoPlanilla";
            this.Load += new System.EventHandler(this.FrmCalculoPlanilla_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvgColaborador)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.LinkLabel linklblmenu;
        private System.Windows.Forms.DataGridView dvgColaborador;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnCrearEmpleado;
        private System.Windows.Forms.Button button3;
    }
}