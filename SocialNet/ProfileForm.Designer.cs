namespace SocialNet
{
    partial class ProfileForm
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
            System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
            System.Windows.Forms.GroupBox groupBox3;
            System.Windows.Forms.GroupBox groupBox2;
            System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
            System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
            System.Windows.Forms.GroupBox groupBox1;
            this.PostsLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.PicturesLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.UniversityLabel = new System.Windows.Forms.Label();
            this.SchoolLabel = new System.Windows.Forms.Label();
            this.MaritalStatusLabel = new System.Windows.Forms.Label();
            this.GenderLabel = new System.Windows.Forms.Label();
            this.BirthdayLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.AvatarPicture = new System.Windows.Forms.PictureBox();
            this.FriendsLayout = new System.Windows.Forms.FlowLayoutPanel();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            groupBox3 = new System.Windows.Forms.GroupBox();
            groupBox2 = new System.Windows.Forms.GroupBox();
            tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            groupBox1 = new System.Windows.Forms.GroupBox();
            tableLayoutPanel1.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AvatarPicture)).BeginInit();
            groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(groupBox3, 0, 3);
            tableLayoutPanel1.Controls.Add(groupBox2, 0, 2);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Controls.Add(groupBox1, 0, 1);
            tableLayoutPanel1.Location = new System.Drawing.Point(13, 13);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 263F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 117F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 102F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            tableLayoutPanel1.Size = new System.Drawing.Size(900, 722);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(this.PostsLayout);
            groupBox3.Location = new System.Drawing.Point(3, 485);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new System.Drawing.Size(675, 108);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "Новости";
            // 
            // PostsLayout
            // 
            this.PostsLayout.Location = new System.Drawing.Point(20, 19);
            this.PostsLayout.Name = "PostsLayout";
            this.PostsLayout.Size = new System.Drawing.Size(545, 60);
            this.PostsLayout.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(this.PicturesLayout);
            groupBox2.Location = new System.Drawing.Point(3, 383);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(571, 96);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Изображения";
            // 
            // PicturesLayout
            // 
            this.PicturesLayout.Location = new System.Drawing.Point(20, 19);
            this.PicturesLayout.Name = "PicturesLayout";
            this.PicturesLayout.Size = new System.Drawing.Size(692, 60);
            this.PicturesLayout.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 1, 0);
            tableLayoutPanel2.Controls.Add(this.AvatarPicture, 0, 0);
            tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new System.Drawing.Size(675, 194);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(this.UniversityLabel, 0, 5);
            tableLayoutPanel3.Controls.Add(this.SchoolLabel, 0, 4);
            tableLayoutPanel3.Controls.Add(this.MaritalStatusLabel, 0, 3);
            tableLayoutPanel3.Controls.Add(this.GenderLabel, 0, 2);
            tableLayoutPanel3.Controls.Add(this.BirthdayLabel, 0, 1);
            tableLayoutPanel3.Controls.Add(this.NameLabel, 0, 0);
            tableLayoutPanel3.Location = new System.Drawing.Point(340, 3);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 6;
            tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            tableLayoutPanel3.Size = new System.Drawing.Size(200, 188);
            tableLayoutPanel3.TabIndex = 0;
            // 
            // UniversityLabel
            // 
            this.UniversityLabel.AutoSize = true;
            this.UniversityLabel.Location = new System.Drawing.Point(3, 159);
            this.UniversityLabel.Name = "UniversityLabel";
            this.UniversityLabel.Size = new System.Drawing.Size(95, 13);
            this.UniversityLabel.TabIndex = 5;
            this.UniversityLabel.Text = "Университет: %%";
            // 
            // SchoolLabel
            // 
            this.SchoolLabel.AutoSize = true;
            this.SchoolLabel.Location = new System.Drawing.Point(3, 134);
            this.SchoolLabel.Name = "SchoolLabel";
            this.SchoolLabel.Size = new System.Drawing.Size(62, 13);
            this.SchoolLabel.TabIndex = 4;
            this.SchoolLabel.Text = "Школа: %%";
            // 
            // MaritalStatusLabel
            // 
            this.MaritalStatusLabel.AutoSize = true;
            this.MaritalStatusLabel.Location = new System.Drawing.Point(3, 103);
            this.MaritalStatusLabel.Name = "MaritalStatusLabel";
            this.MaritalStatusLabel.Size = new System.Drawing.Size(139, 13);
            this.MaritalStatusLabel.TabIndex = 3;
            this.MaritalStatusLabel.Text = "Семейное положение: %%";
            // 
            // GenderLabel
            // 
            this.GenderLabel.AutoSize = true;
            this.GenderLabel.Location = new System.Drawing.Point(3, 66);
            this.GenderLabel.Name = "GenderLabel";
            this.GenderLabel.Size = new System.Drawing.Size(43, 13);
            this.GenderLabel.TabIndex = 2;
            this.GenderLabel.Text = "%Пол%";
            // 
            // BirthdayLabel
            // 
            this.BirthdayLabel.AutoSize = true;
            this.BirthdayLabel.Location = new System.Drawing.Point(3, 33);
            this.BirthdayLabel.Name = "BirthdayLabel";
            this.BirthdayLabel.Size = new System.Drawing.Size(109, 13);
            this.BirthdayLabel.TabIndex = 1;
            this.BirthdayLabel.Text = "День рождения: %%";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(3, 0);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(45, 13);
            this.NameLabel.TabIndex = 0;
            this.NameLabel.Text = "%Имя%";
            // 
            // AvatarPicture
            // 
            this.AvatarPicture.Location = new System.Drawing.Point(3, 3);
            this.AvatarPicture.Name = "AvatarPicture";
            this.AvatarPicture.Size = new System.Drawing.Size(234, 188);
            this.AvatarPicture.TabIndex = 1;
            this.AvatarPicture.TabStop = false;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(this.FriendsLayout);
            groupBox1.Location = new System.Drawing.Point(3, 266);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(571, 96);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Друзья";
            // 
            // FriendsLayout
            // 
            this.FriendsLayout.Location = new System.Drawing.Point(20, 19);
            this.FriendsLayout.Name = "FriendsLayout";
            this.FriendsLayout.Size = new System.Drawing.Size(692, 60);
            this.FriendsLayout.TabIndex = 0;
            // 
            // ProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 762);
            this.Controls.Add(tableLayoutPanel1);
            this.Name = "ProfileForm";
            this.Text = "ProfileForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProfileForm_FormClosing);
            this.Load += new System.EventHandler(this.ProfileForm_Load);
            tableLayoutPanel1.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AvatarPicture)).EndInit();
            groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label UniversityLabel;
        private System.Windows.Forms.Label SchoolLabel;
        private System.Windows.Forms.Label MaritalStatusLabel;
        private System.Windows.Forms.Label GenderLabel;
        private System.Windows.Forms.Label BirthdayLabel;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.PictureBox AvatarPicture;
        private System.Windows.Forms.FlowLayoutPanel PostsLayout;
        private System.Windows.Forms.FlowLayoutPanel PicturesLayout;
        private System.Windows.Forms.FlowLayoutPanel FriendsLayout;
    }
}