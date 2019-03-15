namespace Project
{
    partial class Form2
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
            this.save_reg = new System.Windows.Forms.Button();
            this.reg_login = new System.Windows.Forms.TextBox();
            this.reg_password = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.reg_positions = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.back_to_start = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // save_reg
            // 
            this.save_reg.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.save_reg.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.save_reg.Location = new System.Drawing.Point(0, 286);
            this.save_reg.Name = "save_reg";
            this.save_reg.Size = new System.Drawing.Size(421, 71);
            this.save_reg.TabIndex = 0;
            this.save_reg.Text = "Зарегистрироваться";
            this.save_reg.UseVisualStyleBackColor = true;
            this.save_reg.Click += new System.EventHandler(this.save_reg_Click);
            // 
            // reg_login
            // 
            this.reg_login.Location = new System.Drawing.Point(25, 61);
            this.reg_login.Name = "reg_login";
            this.reg_login.Size = new System.Drawing.Size(197, 20);
            this.reg_login.TabIndex = 1;
            // 
            // reg_password
            // 
            this.reg_password.Location = new System.Drawing.Point(25, 117);
            this.reg_password.Name = "reg_password";
            this.reg_password.Size = new System.Drawing.Size(197, 20);
            this.reg_password.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(231, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Введите логин";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(231, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Введите пароль";
            // 
            // reg_positions
            // 
            this.reg_positions.FormattingEnabled = true;
            this.reg_positions.Items.AddRange(new object[] {
            "Director",
            "Manager",
            "Seller"});
            this.reg_positions.Location = new System.Drawing.Point(25, 185);
            this.reg_positions.Name = "reg_positions";
            this.reg_positions.Size = new System.Drawing.Size(197, 21);
            this.reg_positions.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(231, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(190, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Выберите Вашу должность";
            // 
            // back_to_start
            // 
            this.back_to_start.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.back_to_start.Location = new System.Drawing.Point(327, 12);
            this.back_to_start.Name = "back_to_start";
            this.back_to_start.Size = new System.Drawing.Size(82, 37);
            this.back_to_start.TabIndex = 7;
            this.back_to_start.Text = "Вернуться";
            this.back_to_start.UseVisualStyleBackColor = true;
            this.back_to_start.Click += new System.EventHandler(this.back_to_start_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(103)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(421, 357);
            this.Controls.Add(this.back_to_start);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.reg_positions);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reg_password);
            this.Controls.Add(this.reg_login);
            this.Controls.Add(this.save_reg);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form2";
            this.Text = "Form2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button save_reg;
        private System.Windows.Forms.TextBox reg_login;
        private System.Windows.Forms.TextBox reg_password;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox reg_positions;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button back_to_start;
    }
}