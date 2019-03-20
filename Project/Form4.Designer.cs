namespace Project
{
    partial class Form4
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
            this.back = new System.Windows.Forms.Button();
            this.grid = new System.Windows.Forms.DataGridView();
            this.del_button = new System.Windows.Forms.Button();
            this.id_box = new System.Windows.Forms.TextBox();
            this.log_box = new System.Windows.Forms.TextBox();
            this.password_box = new System.Windows.Forms.TextBox();
            this.id_label = new System.Windows.Forms.Label();
            this.login_label = new System.Windows.Forms.Label();
            this.password_label = new System.Windows.Forms.Label();
            this.update_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // back
            // 
            this.back.Location = new System.Drawing.Point(904, 12);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(75, 23);
            this.back.TabIndex = 0;
            this.back.Text = "Вернуться";
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // grid
            // 
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Location = new System.Drawing.Point(12, 12);
            this.grid.Name = "grid";
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(872, 246);
            this.grid.TabIndex = 1;
            this.grid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellClick);
            // 
            // del_button
            // 
            this.del_button.Location = new System.Drawing.Point(12, 288);
            this.del_button.Name = "del_button";
            this.del_button.Size = new System.Drawing.Size(138, 45);
            this.del_button.TabIndex = 2;
            this.del_button.Text = "Удалить пользователя";
            this.del_button.UseVisualStyleBackColor = true;
            this.del_button.Click += new System.EventHandler(this.del_button_Click);
            // 
            // id_box
            // 
            this.id_box.Location = new System.Drawing.Point(274, 301);
            this.id_box.Name = "id_box";
            this.id_box.Size = new System.Drawing.Size(100, 20);
            this.id_box.TabIndex = 3;
            // 
            // log_box
            // 
            this.log_box.Location = new System.Drawing.Point(429, 301);
            this.log_box.Name = "log_box";
            this.log_box.Size = new System.Drawing.Size(100, 20);
            this.log_box.TabIndex = 4;
            // 
            // password_box
            // 
            this.password_box.Location = new System.Drawing.Point(614, 301);
            this.password_box.Name = "password_box";
            this.password_box.Size = new System.Drawing.Size(100, 20);
            this.password_box.TabIndex = 5;
            // 
            // id_label
            // 
            this.id_label.AutoSize = true;
            this.id_label.Location = new System.Drawing.Point(250, 304);
            this.id_label.Name = "id_label";
            this.id_label.Size = new System.Drawing.Size(18, 13);
            this.id_label.TabIndex = 6;
            this.id_label.Text = "ID";
            // 
            // login_label
            // 
            this.login_label.AutoSize = true;
            this.login_label.Location = new System.Drawing.Point(390, 304);
            this.login_label.Name = "login_label";
            this.login_label.Size = new System.Drawing.Size(33, 13);
            this.login_label.TabIndex = 7;
            this.login_label.Text = "Login";
            // 
            // password_label
            // 
            this.password_label.AutoSize = true;
            this.password_label.Location = new System.Drawing.Point(555, 304);
            this.password_label.Name = "password_label";
            this.password_label.Size = new System.Drawing.Size(53, 13);
            this.password_label.TabIndex = 8;
            this.password_label.Text = "Password";
            // 
            // update_button
            // 
            this.update_button.Location = new System.Drawing.Point(841, 288);
            this.update_button.Name = "update_button";
            this.update_button.Size = new System.Drawing.Size(138, 45);
            this.update_button.TabIndex = 9;
            this.update_button.Text = "Изменить данные";
            this.update_button.UseVisualStyleBackColor = true;
            this.update_button.Click += new System.EventHandler(this.update_button_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 345);
            this.Controls.Add(this.update_button);
            this.Controls.Add(this.password_label);
            this.Controls.Add(this.login_label);
            this.Controls.Add(this.id_label);
            this.Controls.Add(this.password_box);
            this.Controls.Add(this.log_box);
            this.Controls.Add(this.id_box);
            this.Controls.Add(this.del_button);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.back);
            this.Name = "Form4";
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.Form4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button back;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Button del_button;
        private System.Windows.Forms.TextBox id_box;
        private System.Windows.Forms.TextBox log_box;
        private System.Windows.Forms.TextBox password_box;
        private System.Windows.Forms.Label id_label;
        private System.Windows.Forms.Label login_label;
        private System.Windows.Forms.Label password_label;
        private System.Windows.Forms.Button update_button;
    }
}