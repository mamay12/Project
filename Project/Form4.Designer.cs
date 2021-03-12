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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            this.grid = new System.Windows.Forms.DataGridView();
            this.del_button = new System.Windows.Forms.Button();
            this.id_box = new System.Windows.Forms.TextBox();
            this.id_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // grid
            // 
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Location = new System.Drawing.Point(12, 12);
            this.grid.Name = "grid";
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(397, 235);
            this.grid.TabIndex = 1;
            this.grid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellClick);
            // 
            // del_button
            // 
            this.del_button.Location = new System.Drawing.Point(165, 294);
            this.del_button.Name = "del_button";
            this.del_button.Size = new System.Drawing.Size(158, 24);
            this.del_button.TabIndex = 2;
            this.del_button.Text = "Удалить пользователя";
            this.del_button.UseVisualStyleBackColor = true;
            this.del_button.Click += new System.EventHandler(this.del_button_Click);
            // 
            // id_box
            // 
            this.id_box.Location = new System.Drawing.Point(49, 297);
            this.id_box.Name = "id_box";
            this.id_box.Size = new System.Drawing.Size(100, 20);
            this.id_box.TabIndex = 3;
            // 
            // id_label
            // 
            this.id_label.AutoSize = true;
            this.id_label.Location = new System.Drawing.Point(25, 301);
            this.id_label.Name = "id_label";
            this.id_label.Size = new System.Drawing.Size(18, 13);
            this.id_label.TabIndex = 6;
            this.id_label.Text = "ID";
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(421, 357);
            this.Controls.Add(this.id_label);
            this.Controls.Add(this.id_box);
            this.Controls.Add(this.del_button);
            this.Controls.Add(this.grid);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form4";
            this.Text = "Пользователи";
            this.Load += new System.EventHandler(this.Form4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Button del_button;
        private System.Windows.Forms.TextBox id_box;
        private System.Windows.Forms.Label id_label;
    }
}