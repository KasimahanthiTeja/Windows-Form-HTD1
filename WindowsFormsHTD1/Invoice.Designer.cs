namespace WindowsFormsHTD1
{
    partial class Invoice
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtClient_Name = new System.Windows.Forms.TextBox();
            this.txtPayment_Mode = new System.Windows.Forms.TextBox();
            this.txtInvoice_Type = new System.Windows.Forms.TextBox();
            this.txtDepartment_name = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(350, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Invoice";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Client_Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Payment_Mode";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "DOP";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(42, 256);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Invoice_Type";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(42, 310);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(145, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Department_Name";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(272, 366);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(174, 72);
            this.button1.TabIndex = 6;
            this.button1.Text = "Save Invoice";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtClient_Name
            // 
            this.txtClient_Name.Location = new System.Drawing.Point(241, 68);
            this.txtClient_Name.Name = "txtClient_Name";
            this.txtClient_Name.Size = new System.Drawing.Size(307, 26);
            this.txtClient_Name.TabIndex = 7;
            // 
            // txtPayment_Mode
            // 
            this.txtPayment_Mode.Location = new System.Drawing.Point(241, 136);
            this.txtPayment_Mode.Name = "txtPayment_Mode";
            this.txtPayment_Mode.Size = new System.Drawing.Size(305, 26);
            this.txtPayment_Mode.TabIndex = 8;
            // 
            // txtInvoice_Type
            // 
            this.txtInvoice_Type.Location = new System.Drawing.Point(241, 250);
            this.txtInvoice_Type.Name = "txtInvoice_Type";
            this.txtInvoice_Type.Size = new System.Drawing.Size(288, 26);
            this.txtInvoice_Type.TabIndex = 9;
            // 
            // txtDepartment_name
            // 
            this.txtDepartment_name.Location = new System.Drawing.Point(241, 304);
            this.txtDepartment_name.Name = "txtDepartment_name";
            this.txtDepartment_name.Size = new System.Drawing.Size(291, 26);
            this.txtDepartment_name.TabIndex = 10;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(241, 192);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(293, 26);
            this.dateTimePicker1.TabIndex = 11;
            // 
            // Invoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.txtDepartment_name);
            this.Controls.Add(this.txtInvoice_Type);
            this.Controls.Add(this.txtPayment_Mode);
            this.Controls.Add(this.txtClient_Name);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Invoice";
            this.Text = "Invoice";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtClient_Name;
        private System.Windows.Forms.TextBox txtPayment_Mode;
        private System.Windows.Forms.TextBox txtInvoice_Type;
        private System.Windows.Forms.TextBox txtDepartment_name;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}