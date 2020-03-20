namespace Project
{
    partial class FormMenu
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
            this.button_start = new System.Windows.Forms.Button();
            this.button_exit = new System.Windows.Forms.Button();
            this.check_sound = new System.Windows.Forms.CheckBox();
            this.picture_background = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picture_background)).BeginInit();
            this.SuspendLayout();
            // 
            // button_start
            // 
            this.button_start.BackColor = System.Drawing.Color.Transparent;
            this.button_start.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button_start.FlatAppearance.BorderSize = 0;
            this.button_start.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button_start.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button_start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_start.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_start.ForeColor = System.Drawing.Color.Blue;
            this.button_start.Location = new System.Drawing.Point(371, 245);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(87, 79);
            this.button_start.TabIndex = 0;
            this.button_start.Text = "START";
            this.button_start.UseCompatibleTextRendering = true;
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // button_exit
            // 
            this.button_exit.BackColor = System.Drawing.Color.Transparent;
            this.button_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_exit.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_exit.Location = new System.Drawing.Point(710, 540);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(78, 48);
            this.button_exit.TabIndex = 1;
            this.button_exit.Text = "Exit";
            this.button_exit.UseVisualStyleBackColor = false;
            this.button_exit.Click += new System.EventHandler(this.button_exit_Click);
            // 
            // check_sound
            // 
            this.check_sound.AutoSize = true;
            this.check_sound.BackColor = System.Drawing.Color.Transparent;
            this.check_sound.BackgroundImage = global::Project.Properties.Resources.orig;
            this.check_sound.Checked = true;
            this.check_sound.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_sound.Font = new System.Drawing.Font("Franklin Gothic Medium", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.check_sound.Location = new System.Drawing.Point(12, 480);
            this.check_sound.Name = "check_sound";
            this.check_sound.Size = new System.Drawing.Size(68, 24);
            this.check_sound.TabIndex = 2;
            this.check_sound.Text = "Sound";
            this.check_sound.UseVisualStyleBackColor = false;
            this.check_sound.CheckedChanged += new System.EventHandler(this.check_sound_CheckedChanged);
            // 
            // picture_background
            // 
            this.picture_background.BackColor = System.Drawing.Color.Transparent;
            this.picture_background.Image = global::Project.Properties.Resources.orig;
            this.picture_background.Location = new System.Drawing.Point(0, -1);
            this.picture_background.Name = "picture_background";
            this.picture_background.Size = new System.Drawing.Size(800, 600);
            this.picture_background.TabIndex = 3;
            this.picture_background.TabStop = false;
            this.picture_background.Click += new System.EventHandler(this.picture_background_Click);
            // 
            // FormMenu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.BackgroundImage = global::Project.Properties.Resources.orig;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.check_sound);
            this.Controls.Add(this.button_exit);
            this.Controls.Add(this.button_start);
            this.Controls.Add(this.picture_background);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GeometryGame";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picture_background)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_exit;
        private System.Windows.Forms.CheckBox check_sound;
        private System.Windows.Forms.PictureBox picture_background;
        private System.Windows.Forms.Button button_start;
    }
}

