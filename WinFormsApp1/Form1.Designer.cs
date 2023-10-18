namespace WinFormsApp1
{
    partial class Luncher
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Luncher));
            PlayBtn = new Button();
            txt_username = new TextBox();
            versionLabel = new Label();
            updateButton = new Button();
            pictureBox2 = new PictureBox();
            mutebtn = new Button();
            nameBtn = new Button();
            pictureBox1 = new PictureBox();
            progressBar1 = new ProgressBar();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // PlayBtn
            // 
            PlayBtn.BackgroundImage = (Image)resources.GetObject("PlayBtn.BackgroundImage");
            PlayBtn.BackgroundImageLayout = ImageLayout.Stretch;
            PlayBtn.Cursor = Cursors.Hand;
            PlayBtn.FlatAppearance.BorderColor = Color.White;
            PlayBtn.FlatAppearance.BorderSize = 3;
            PlayBtn.FlatStyle = FlatStyle.Flat;
            PlayBtn.Font = new Font("Times New Roman", 24.75F, FontStyle.Bold, GraphicsUnit.Point);
            PlayBtn.ImageAlign = ContentAlignment.MiddleRight;
            PlayBtn.Location = new Point(859, 628);
            PlayBtn.Margin = new Padding(3, 4, 3, 4);
            PlayBtn.Name = "PlayBtn";
            PlayBtn.Padding = new Padding(5);
            PlayBtn.Size = new Size(363, 90);
            PlayBtn.TabIndex = 1;
            PlayBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            PlayBtn.UseVisualStyleBackColor = true;
            PlayBtn.Click += button1_Click;
            // 
            // txt_username
            // 
            txt_username.BackColor = Color.CadetBlue;
            txt_username.BorderStyle = BorderStyle.None;
            txt_username.Cursor = Cursors.IBeam;
            txt_username.Font = new Font("Times New Roman", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            txt_username.ForeColor = Color.White;
            txt_username.Location = new Point(834, 531);
            txt_username.Margin = new Padding(3, 4, 3, 4);
            txt_username.Name = "txt_username";
            txt_username.Size = new Size(405, 39);
            txt_username.TabIndex = 2;
            txt_username.Text = "Tên Whitelist";
            txt_username.TextAlign = HorizontalAlignment.Center;
            // 
            // versionLabel
            // 
            versionLabel.BackColor = Color.White;
            versionLabel.BorderStyle = BorderStyle.FixedSingle;
            versionLabel.FlatStyle = FlatStyle.Flat;
            versionLabel.Font = new Font("Arial Black", 10.8000011F, FontStyle.Bold, GraphicsUnit.Point);
            versionLabel.ForeColor = SystemColors.ButtonHighlight;
            versionLabel.Image = (Image)resources.GetObject("versionLabel.Image");
            versionLabel.Location = new Point(1079, 784);
            versionLabel.Name = "versionLabel";
            versionLabel.Size = new Size(282, 52);
            versionLabel.TabIndex = 5;
            versionLabel.Text = "Version: 0.0.1";
            versionLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // updateButton
            // 
            updateButton.BackgroundImage = (Image)resources.GetObject("updateButton.BackgroundImage");
            updateButton.BackgroundImageLayout = ImageLayout.Stretch;
            updateButton.Cursor = Cursors.Hand;
            updateButton.FlatAppearance.BorderColor = Color.White;
            updateButton.FlatAppearance.BorderSize = 3;
            updateButton.Font = new Font("Times New Roman", 15F, FontStyle.Bold, GraphicsUnit.Point);
            updateButton.Location = new Point(731, 784);
            updateButton.Margin = new Padding(3, 4, 3, 4);
            updateButton.Name = "updateButton";
            updateButton.Size = new Size(282, 52);
            updateButton.TabIndex = 6;
            updateButton.UseVisualStyleBackColor = true;
            updateButton.Click += updateButton_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = (Image)resources.GetObject("pictureBox2.BackgroundImage");
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.Location = new Point(821, 485);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(432, 126);
            pictureBox2.TabIndex = 8;
            pictureBox2.TabStop = false;
            // 
            // mutebtn
            // 
            mutebtn.BackgroundImage = (Image)resources.GetObject("mutebtn.BackgroundImage");
            mutebtn.FlatAppearance.BorderColor = Color.White;
            mutebtn.FlatAppearance.BorderSize = 5;
            mutebtn.Location = new Point(12, 793);
            mutebtn.Name = "mutebtn";
            mutebtn.Size = new Size(44, 44);
            mutebtn.TabIndex = 10;
            mutebtn.UseVisualStyleBackColor = true;
            mutebtn.Click += mutebtn_Click;
            // 
            // nameBtn
            // 
            nameBtn.Location = new Point(707, 531);
            nameBtn.Name = "nameBtn";
            nameBtn.Size = new Size(94, 29);
            nameBtn.TabIndex = 11;
            nameBtn.Text = "Đặt Tên";
            nameBtn.UseVisualStyleBackColor = true;
            nameBtn.Click += registBtn_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(181, 179);
            pictureBox1.TabIndex = 12;
            pictureBox1.TabStop = false;
            // 
            // progressBar1
            // 
            progressBar1.BackColor = SystemColors.ActiveCaptionText;
            progressBar1.ForeColor = Color.DarkGreen;
            progressBar1.Location = new Point(154, 785);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(479, 52);
            progressBar1.TabIndex = 13;
            // 
            // Luncher
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1378, 849);
            Controls.Add(progressBar1);
            Controls.Add(pictureBox1);
            Controls.Add(nameBtn);
            Controls.Add(mutebtn);
            Controls.Add(updateButton);
            Controls.Add(versionLabel);
            Controls.Add(txt_username);
            Controls.Add(PlayBtn);
            Controls.Add(pictureBox2);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Luncher";
            Text = "Dayz ROD Viet Nam";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button PlayBtn;
        private TextBox txt_username;
        private Label versionLabel;
        private Button updateButton;
        private PictureBox pictureBox2;
        private Button mutebtn;
        private Button nameBtn;
        private PictureBox pictureBox1;
        private ProgressBar progressBar1;
    }
}