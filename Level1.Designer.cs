namespace Project
{
    partial class Level1
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
            this.exit_level1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // exit_level1
            // 
            this.exit_level1.BackColor = System.Drawing.Color.Transparent;
            this.exit_level1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exit_level1.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exit_level1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.exit_level1.Location = new System.Drawing.Point(713, 12);
            this.exit_level1.Name = "exit_level1";
            this.exit_level1.Size = new System.Drawing.Size(75, 33);
            this.exit_level1.TabIndex = 0;
            this.exit_level1.Text = "END";
            this.exit_level1.UseVisualStyleBackColor = false;
            this.exit_level1.Click += new System.EventHandler(this.exit_level1_Click);
            // 
            // Level1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Project.Properties.Resources.holden_decor_holden_intergalactic_stars_pattern_childrens_wallpaper_space_planets_astronaut_12500_p4862_13099_image;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.exit_level1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(0, -1);
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Level1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Level1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button exit_level1;
    }
}