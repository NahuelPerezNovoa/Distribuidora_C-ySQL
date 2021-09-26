
namespace FormsDistribuidora
{
    partial class FormAdmin_Pedidos
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
            this.lblAdministrativo = new System.Windows.Forms.Label();
            this.rtbARealizar = new System.Windows.Forms.RichTextBox();
            this.rtbRealizados = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbCliente = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbtnRealizado = new System.Windows.Forms.RadioButton();
            this.rdbtnARealizar = new System.Windows.Forms.RadioButton();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnNuevoPedido = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAdministrativo
            // 
            this.lblAdministrativo.AutoSize = true;
            this.lblAdministrativo.Font = new System.Drawing.Font("Niagara Engraved", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdministrativo.Location = new System.Drawing.Point(320, 14);
            this.lblAdministrativo.Name = "lblAdministrativo";
            this.lblAdministrativo.Size = new System.Drawing.Size(432, 68);
            this.lblAdministrativo.TabIndex = 3;
            this.lblAdministrativo.Text = "Administrativo -> Pedidos";
            this.lblAdministrativo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // rtbARealizar
            // 
            this.rtbARealizar.Enabled = false;
            this.rtbARealizar.Location = new System.Drawing.Point(29, 98);
            this.rtbARealizar.Name = "rtbARealizar";
            this.rtbARealizar.Size = new System.Drawing.Size(446, 374);
            this.rtbARealizar.TabIndex = 4;
            this.rtbARealizar.Text = "";
            // 
            // rtbRealizados
            // 
            this.rtbRealizados.Enabled = false;
            this.rtbRealizados.Location = new System.Drawing.Point(601, 98);
            this.rtbRealizados.Name = "rtbRealizados";
            this.rtbRealizados.Size = new System.Drawing.Size(453, 374);
            this.rtbRealizados.TabIndex = 5;
            this.rtbRealizados.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Pedidos a realizar";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(603, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Pedidos realizados";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(287, 24);
            this.label3.TabIndex = 8;
            this.label3.Text = "Seleccione el nombre del cliente";
            // 
            // cmbCliente
            // 
            this.cmbCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.Location = new System.Drawing.Point(17, 93);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(201, 21);
            this.cmbCliente.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbtnRealizado);
            this.groupBox1.Controls.Add(this.rdbtnARealizar);
            this.groupBox1.Controls.Add(this.btnGenerar);
            this.groupBox1.Controls.Add(this.cmbCliente);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(81, 497);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(329, 144);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Generar documento de pedido";
            // 
            // rdbtnRealizado
            // 
            this.rdbtnRealizado.AutoSize = true;
            this.rdbtnRealizado.Location = new System.Drawing.Point(176, 56);
            this.rdbtnRealizado.Name = "rdbtnRealizado";
            this.rdbtnRealizado.Size = new System.Drawing.Size(108, 17);
            this.rdbtnRealizado.TabIndex = 15;
            this.rdbtnRealizado.TabStop = true;
            this.rdbtnRealizado.Text = "Pedido Realizado";
            this.rdbtnRealizado.UseVisualStyleBackColor = true;
            this.rdbtnRealizado.CheckedChanged += new System.EventHandler(this.rdbtnRealizado_CheckedChanged);
            // 
            // rdbtnARealizar
            // 
            this.rdbtnARealizar.AutoSize = true;
            this.rdbtnARealizar.Location = new System.Drawing.Point(34, 56);
            this.rdbtnARealizar.Name = "rdbtnARealizar";
            this.rdbtnARealizar.Size = new System.Drawing.Size(108, 17);
            this.rdbtnARealizar.TabIndex = 14;
            this.rdbtnARealizar.TabStop = true;
            this.rdbtnARealizar.Text = "Pedido a Realizar";
            this.rdbtnARealizar.UseVisualStyleBackColor = true;
            this.rdbtnARealizar.CheckedChanged += new System.EventHandler(this.rdbtnARealizar_CheckedChanged);
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(224, 88);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(86, 28);
            this.btnGenerar.TabIndex = 10;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(56, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(200, 24);
            this.label4.TabIndex = 11;
            this.label4.Text = "Ingresar nuevo pedido";
            // 
            // btnNuevoPedido
            // 
            this.btnNuevoPedido.Location = new System.Drawing.Point(76, 72);
            this.btnNuevoPedido.Name = "btnNuevoPedido";
            this.btnNuevoPedido.Size = new System.Drawing.Size(159, 42);
            this.btnNuevoPedido.TabIndex = 12;
            this.btnNuevoPedido.Text = "Nuevo";
            this.btnNuevoPedido.UseVisualStyleBackColor = true;
            this.btnNuevoPedido.Click += new System.EventHandler(this.btnNuevoPedido_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnNuevoPedido);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(668, 497);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(322, 143);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Nuevo pedido";
            // 
            // FormAdmin_Pedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1094, 662);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtbRealizados);
            this.Controls.Add(this.rtbARealizar);
            this.Controls.Add(this.lblAdministrativo);
            this.MaximizeBox = false;
            this.Name = "FormAdmin_Pedidos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormAdmin_Pedidos";
            this.Load += new System.EventHandler(this.FormAdmin_Pedidos_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAdministrativo;
        private System.Windows.Forms.RichTextBox rtbARealizar;
        private System.Windows.Forms.RichTextBox rtbRealizados;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbCliente;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnNuevoPedido;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdbtnRealizado;
        private System.Windows.Forms.RadioButton rdbtnARealizar;
    }
}