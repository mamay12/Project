namespace Project
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Login = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.TextBox();
            this.login_label = new System.Windows.Forms.Label();
            this.password_label = new System.Windows.Forms.Label();
            this.Enter_but = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // Login
            // 
            this.Login.Location = new System.Drawing.Point(119, 63);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(225, 20);
            this.Login.TabIndex = 0;
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(119, 124);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(225, 20);
            this.Password.TabIndex = 1;
            // 
            // login_label
            // 
            this.login_label.AutoSize = true;
            this.login_label.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.login_label.Location = new System.Drawing.Point(37, 63);
            this.login_label.Name = "login_label";
            this.login_label.Size = new System.Drawing.Size(46, 16);
            this.login_label.TabIndex = 2;
            this.login_label.Text = "Логин";
            // 
            // password_label
            // 
            this.password_label.AutoSize = true;
            this.password_label.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.password_label.Location = new System.Drawing.Point(37, 124);
            this.password_label.Name = "password_label";
            this.password_label.Size = new System.Drawing.Size(57, 16);
            this.password_label.TabIndex = 3;
            this.password_label.Text = "Пароль";
            // 
            // Enter_but
            // 
            this.Enter_but.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Enter_but.Location = new System.Drawing.Point(40, 196);
            this.Enter_but.Name = "Enter_but";
            this.Enter_but.Size = new System.Drawing.Size(303, 50);
            this.Enter_but.TabIndex = 4;
            this.Enter_but.Text = "Войти";
            this.Enter_but.UseVisualStyleBackColor = true;
            this.Enter_but.Click += new System.EventHandler(this.Enter_but_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(103)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(404, 311);
            this.Controls.Add(this.Enter_but);
            this.Controls.Add(this.password_label);
            this.Controls.Add(this.login_label);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.Login);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Авторизация";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Login;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.Label login_label;
        private System.Windows.Forms.Label password_label;
        private System.Windows.Forms.Button Enter_but;
        private System.Windows.Forms.Timer timer1;
    }
}

