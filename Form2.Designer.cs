namespace Dungeons_
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.exit = new System.Windows.Forms.Button();
            this.rulesgame = new System.Windows.Forms.Button();
            this.startgame = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.exit);
            this.panel1.Controls.Add(this.rulesgame);
            this.panel1.Controls.Add(this.startgame);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(-126, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.MaximumSize = new System.Drawing.Size(3000, 3000);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2050, 1055);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(925, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1125, 1055);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // exit
            // 
            this.exit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("exit.BackgroundImage")));
            this.exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.exit.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.exit.FlatAppearance.BorderSize = 0;
            this.exit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.exit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exit.Font = new System.Drawing.Font("Press Start 2P", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.exit.Location = new System.Drawing.Point(355, 671);
            this.exit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(349, 150);
            this.exit.TabIndex = 6;
            this.exit.Text = "ВЫЙТИ";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // rulesgame
            // 
            this.rulesgame.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rulesgame.BackgroundImage")));
            this.rulesgame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.rulesgame.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.rulesgame.FlatAppearance.BorderSize = 0;
            this.rulesgame.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.rulesgame.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.rulesgame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rulesgame.Font = new System.Drawing.Font("Press Start 2P", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rulesgame.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.rulesgame.Location = new System.Drawing.Point(156, 442);
            this.rulesgame.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rulesgame.Name = "rulesgame";
            this.rulesgame.Size = new System.Drawing.Size(349, 150);
            this.rulesgame.TabIndex = 5;
            this.rulesgame.Text = "ПРАВИЛА ИГРЫ";
            this.rulesgame.UseVisualStyleBackColor = true;
            this.rulesgame.Click += new System.EventHandler(this.rulesgame_Click);
            // 
            // startgame
            // 
            this.startgame.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("startgame.BackgroundImage")));
            this.startgame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.startgame.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.startgame.FlatAppearance.BorderSize = 0;
            this.startgame.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.startgame.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.startgame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startgame.Font = new System.Drawing.Font("Press Start 2P", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.startgame.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.startgame.Location = new System.Drawing.Point(27, 170);
            this.startgame.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.startgame.Name = "startgame";
            this.startgame.Size = new System.Drawing.Size(349, 150);
            this.startgame.TabIndex = 4;
            this.startgame.Text = "НАЧАТЬ ИГРУ";
            this.startgame.UseVisualStyleBackColor = true;
            this.startgame.Click += new System.EventHandler(this.startgame_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form2";
            this.Text = "DangeousDungeons";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form2_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button startgame;
        private System.Windows.Forms.Button rulesgame;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button exit;
    }
}