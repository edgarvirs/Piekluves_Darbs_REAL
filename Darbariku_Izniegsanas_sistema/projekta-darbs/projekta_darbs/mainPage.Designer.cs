namespace projekta_darbs
{
    partial class mainPage
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainPage));
            materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            tabPage1 = new TabPage();
            materialButton1 = new MaterialSkin.Controls.MaterialButton();
            textBox1 = new TextBox();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            tabPage2 = new TabPage();
            AtjIzdotieBtn = new MaterialSkin.Controls.MaterialButton();
            AtjNoliktavuBtn = new MaterialSkin.Controls.MaterialButton();
            NodotBtn = new MaterialSkin.Controls.MaterialButton();
            SanemtBtn = new MaterialSkin.Controls.MaterialButton();
            label2 = new Label();
            label1 = new Label();
            comboBox2 = new ComboBox();
            comboBox1 = new ComboBox();
            dataGridView2 = new DataGridView();
            imageList1 = new ImageList(components);
            materialTabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // materialTabControl1
            // 
            materialTabControl1.Controls.Add(tabPage1);
            materialTabControl1.Controls.Add(tabPage2);
            materialTabControl1.Depth = 0;
            materialTabControl1.ImageList = imageList1;
            materialTabControl1.Location = new Point(6, 67);
            materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            materialTabControl1.Multiline = true;
            materialTabControl1.Name = "materialTabControl1";
            materialTabControl1.SelectedIndex = 0;
            materialTabControl1.Size = new Size(929, 502);
            materialTabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.White;
            tabPage1.Controls.Add(materialButton1);
            tabPage1.Controls.Add(textBox1);
            tabPage1.Controls.Add(materialLabel2);
            tabPage1.Controls.Add(materialLabel1);
            tabPage1.ImageKey = "icons8-log-24.png";
            tabPage1.Location = new Point(4, 39);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(921, 459);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Darbarīku žurnāls";
            // 
            // materialButton1
            // 
            materialButton1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton1.Depth = 0;
            materialButton1.HighEmphasis = true;
            materialButton1.Icon = null;
            materialButton1.Location = new Point(728, -1);
            materialButton1.Margin = new Padding(4, 6, 4, 6);
            materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton1.Name = "materialButton1";
            materialButton1.NoAccentTextColor = Color.Empty;
            materialButton1.Size = new Size(186, 36);
            materialButton1.TabIndex = 6;
            materialButton1.Text = "Doties uz admin page";
            materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            materialButton1.UseAccentColor = false;
            materialButton1.UseVisualStyleBackColor = true;
            materialButton1.Visible = false;
            materialButton1.Click += materialButton1_Click;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.None;
            textBox1.BackColor = SystemColors.Info;
            textBox1.Location = new Point(113, 38);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(802, 415);
            textBox1.TabIndex = 5;
            // 
            // materialLabel2
            // 
            materialLabel2.Anchor = AnchorStyles.None;
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.Location = new Point(113, 16);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(5, 19);
            materialLabel2.TabIndex = 4;
            materialLabel2.Text = " ";
            // 
            // materialLabel1
            // 
            materialLabel1.Anchor = AnchorStyles.None;
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(483, 16);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(55, 19);
            materialLabel1.TabIndex = 2;
            materialLabel1.Text = "Žurnāls";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(AtjIzdotieBtn);
            tabPage2.Controls.Add(AtjNoliktavuBtn);
            tabPage2.Controls.Add(NodotBtn);
            tabPage2.Controls.Add(SanemtBtn);
            tabPage2.Controls.Add(label2);
            tabPage2.Controls.Add(label1);
            tabPage2.Controls.Add(comboBox2);
            tabPage2.Controls.Add(comboBox1);
            tabPage2.Controls.Add(dataGridView2);
            tabPage2.ImageKey = "icons8-key-30.png";
            tabPage2.Location = new Point(4, 39);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(921, 459);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Saņemt/nodot darbarīku";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // AtjIzdotieBtn
            // 
            AtjIzdotieBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            AtjIzdotieBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            AtjIzdotieBtn.Depth = 0;
            AtjIzdotieBtn.HighEmphasis = true;
            AtjIzdotieBtn.Icon = null;
            AtjIzdotieBtn.Location = new Point(650, 337);
            AtjIzdotieBtn.Margin = new Padding(4, 6, 4, 6);
            AtjIzdotieBtn.MouseState = MaterialSkin.MouseState.HOVER;
            AtjIzdotieBtn.Name = "AtjIzdotieBtn";
            AtjIzdotieBtn.NoAccentTextColor = Color.Empty;
            AtjIzdotieBtn.Size = new Size(154, 36);
            AtjIzdotieBtn.TabIndex = 14;
            AtjIzdotieBtn.Text = "Izdotie darbarīki";
            AtjIzdotieBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            AtjIzdotieBtn.UseAccentColor = false;
            AtjIzdotieBtn.UseVisualStyleBackColor = true;
            AtjIzdotieBtn.Click += AtjIzdotieBtn_Click;
            // 
            // AtjNoliktavuBtn
            // 
            AtjNoliktavuBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            AtjNoliktavuBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            AtjNoliktavuBtn.Depth = 0;
            AtjNoliktavuBtn.HighEmphasis = true;
            AtjNoliktavuBtn.Icon = null;
            AtjNoliktavuBtn.Location = new Point(365, 337);
            AtjNoliktavuBtn.Margin = new Padding(4, 6, 4, 6);
            AtjNoliktavuBtn.MouseState = MaterialSkin.MouseState.HOVER;
            AtjNoliktavuBtn.Name = "AtjNoliktavuBtn";
            AtjNoliktavuBtn.NoAccentTextColor = Color.Empty;
            AtjNoliktavuBtn.Size = new Size(179, 36);
            AtjNoliktavuBtn.TabIndex = 13;
            AtjNoliktavuBtn.Text = "Darbarīki noliktavā";
            AtjNoliktavuBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            AtjNoliktavuBtn.UseAccentColor = false;
            AtjNoliktavuBtn.UseVisualStyleBackColor = true;
            AtjNoliktavuBtn.Click += AtjNoliktavuBtn_Click;
            // 
            // NodotBtn
            // 
            NodotBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            NodotBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            NodotBtn.Depth = 0;
            NodotBtn.HighEmphasis = true;
            NodotBtn.Icon = null;
            NodotBtn.Location = new Point(135, 230);
            NodotBtn.Margin = new Padding(4, 6, 4, 6);
            NodotBtn.MouseState = MaterialSkin.MouseState.HOVER;
            NodotBtn.Name = "NodotBtn";
            NodotBtn.NoAccentTextColor = Color.Empty;
            NodotBtn.Size = new Size(154, 36);
            NodotBtn.TabIndex = 12;
            NodotBtn.Text = "Nodot darbarīku";
            NodotBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            NodotBtn.UseAccentColor = false;
            NodotBtn.UseVisualStyleBackColor = true;
            NodotBtn.Click += NodotBtn_Click;
            // 
            // SanemtBtn
            // 
            SanemtBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            SanemtBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            SanemtBtn.Depth = 0;
            SanemtBtn.HighEmphasis = true;
            SanemtBtn.Icon = null;
            SanemtBtn.Location = new Point(135, 109);
            SanemtBtn.Margin = new Padding(4, 6, 4, 6);
            SanemtBtn.MouseState = MaterialSkin.MouseState.HOVER;
            SanemtBtn.Name = "SanemtBtn";
            SanemtBtn.NoAccentTextColor = Color.Empty;
            SanemtBtn.Size = new Size(164, 36);
            SanemtBtn.TabIndex = 11;
            SanemtBtn.Text = "Saņemt darbarīku";
            SanemtBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            SanemtBtn.UseAccentColor = false;
            SanemtBtn.UseVisualStyleBackColor = true;
            SanemtBtn.Click += SanemtBtn_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(135, 164);
            label2.Name = "label2";
            label2.Size = new Size(71, 15);
            label2.TabIndex = 10;
            label2.Text = "Darbarīka ID";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(135, 41);
            label1.Name = "label1";
            label1.Size = new Size(71, 15);
            label1.TabIndex = 9;
            label1.Text = "Darbarīka ID";
            // 
            // comboBox2
            // 
            comboBox2.Anchor = AnchorStyles.None;
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(135, 182);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(184, 23);
            comboBox2.TabIndex = 8;
            // 
            // comboBox1
            // 
            comboBox1.Anchor = AnchorStyles.None;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(135, 59);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(184, 23);
            comboBox1.TabIndex = 4;
            // 
            // dataGridView2
            // 
            dataGridView2.Anchor = AnchorStyles.None;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(381, 6);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.Size = new Size(409, 269);
            dataGridView2.TabIndex = 1;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "icons8-key-30.png");
            imageList1.Images.SetKeyName(1, "icons8-log-24.png");
            imageList1.Images.SetKeyName(2, "icons8-file-explorer-32.png");
            imageList1.Images.SetKeyName(3, "icons8-admin-24.png");
            // 
            // mainPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(941, 575);
            Controls.Add(materialTabControl1);
            DrawerShowIconsWhenHidden = true;
            DrawerTabControl = materialTabControl1;
            Name = "mainPage";
            Text = "Darbarīki";
            materialTabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private ImageList imageList1;
        private DataGridView dataGridView2;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private TextBox textBox1;
        private MaterialSkin.Controls.MaterialButton materialButton1;
        private Label label2;
        private Label label1;
        private MaterialSkin.Controls.MaterialButton SanemtBtn;
        private MaterialSkin.Controls.MaterialButton NodotBtn;
        private MaterialSkin.Controls.MaterialButton AtjNoliktavuBtn;
        private MaterialSkin.Controls.MaterialButton AtjIzdotieBtn;
    }
}