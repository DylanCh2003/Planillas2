namespace Planillas.UI
{
    partial class Planilla
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
            this.txtSupervisorID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnCrearEmpleado = new System.Windows.Forms.Button();
            this.dvgColaborador = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dvgColaborador)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Image = global::Planillas.Properties.Resources.Consultar;
            this.button1.Location = new System.Drawing.Point(305, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 37);
            this.button1.TabIndex = 77;
            this.button1.Text = "Buscar";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // txtSupervisorID
            // 
            this.txtSupervisorID.Location = new System.Drawing.Point(157, 52);
            this.txtSupervisorID.Name = "txtSupervisorID";
            this.txtSupervisorID.Size = new System.Drawing.Size(133, 20);
            this.txtSupervisorID.TabIndex = 76;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 16);
            this.label2.TabIndex = 75;
            this.label2.Text = "Buscar Planilla :";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(697, 214);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(91, 44);
            this.button3.TabIndex = 114;
            this.button3.Text = "Limpiar";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(425, 214);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(99, 44);
            this.btnActualizar.TabIndex = 113;
            this.btnActualizar.Text = "Recalcular";
            this.btnActualizar.UseVisualStyleBackColor = true;
            // 
            // btnCrearEmpleado
            // 
            this.btnCrearEmpleado.Location = new System.Drawing.Point(579, 214);
            this.btnCrearEmpleado.Name = "btnCrearEmpleado";
            this.btnCrearEmpleado.Size = new System.Drawing.Size(91, 44);
            this.btnCrearEmpleado.TabIndex = 112;
            this.btnCrearEmpleado.Text = "Guardar";
            this.btnCrearEmpleado.UseVisualStyleBackColor = true;
            // 
            // dvgColaborador
            // 
            this.dvgColaborador.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgColaborador.Location = new System.Drawing.Point(-7, 264);
            this.dvgColaborador.Name = "dvgColaborador";
            this.dvgColaborador.Size = new System.Drawing.Size(808, 174);
            this.dvgColaborador.TabIndex = 111;
            // 
            // Planilla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnCrearEmpleado);
            this.Controls.Add(this.dvgColaborador);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtSupervisorID);
            this.Controls.Add(this.label2);
            this.Name = "Planilla";
            this.Text = "Planilla";
            ((System.ComponentModel.ISupportInitialize)(this.dvgColaborador)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtSupervisorID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnCrearEmpleado;
        private System.Windows.Forms.DataGridView dvgColaborador;
    }
}