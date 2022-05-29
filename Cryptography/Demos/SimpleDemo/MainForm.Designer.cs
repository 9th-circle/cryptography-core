
namespace SimpleDemo
{
    partial class MainForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.symmetricPlaintextBox = new System.Windows.Forms.TextBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.symmetricDecryptButton = new System.Windows.Forms.Button();
            this.symmetricEncryptButton = new System.Windows.Forms.Button();
            this.generateSymmetricKeyButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.symmetricKeyBox = new System.Windows.Forms.TextBox();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.symmetricCiphertextBox = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.hashInputBox = new System.Windows.Forms.TextBox();
            this.doHashButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.hashOutputBox = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.macInputBox = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.macKeyBox = new System.Windows.Forms.TextBox();
            this.macButton = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.macOutputBox = new System.Windows.Forms.TextBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.kdfInputBox = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.generateSaltButton = new System.Windows.Forms.Button();
            this.kdfSaltBox = new System.Windows.Forms.TextBox();
            this.kdfButton = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.kdfOutputBox = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 450);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer4);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 422);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "SymmetricBox";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(3, 3);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.groupBox9);
            this.splitContainer4.Panel1.Controls.Add(this.groupBox10);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.groupBox11);
            this.splitContainer4.Size = new System.Drawing.Size(786, 416);
            this.splitContainer4.SplitterDistance = 260;
            this.splitContainer4.TabIndex = 3;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.symmetricPlaintextBox);
            this.groupBox9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox9.Location = new System.Drawing.Point(0, 0);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(786, 180);
            this.groupBox9.TabIndex = 0;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Plaintext";
            // 
            // symmetricPlaintextBox
            // 
            this.symmetricPlaintextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.symmetricPlaintextBox.Location = new System.Drawing.Point(3, 19);
            this.symmetricPlaintextBox.Multiline = true;
            this.symmetricPlaintextBox.Name = "symmetricPlaintextBox";
            this.symmetricPlaintextBox.Size = new System.Drawing.Size(780, 158);
            this.symmetricPlaintextBox.TabIndex = 0;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.symmetricDecryptButton);
            this.groupBox10.Controls.Add(this.symmetricEncryptButton);
            this.groupBox10.Controls.Add(this.generateSymmetricKeyButton);
            this.groupBox10.Controls.Add(this.button1);
            this.groupBox10.Controls.Add(this.symmetricKeyBox);
            this.groupBox10.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox10.Location = new System.Drawing.Point(0, 180);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(786, 80);
            this.groupBox10.TabIndex = 2;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Secret Key";
            // 
            // symmetricDecryptButton
            // 
            this.symmetricDecryptButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.symmetricDecryptButton.Location = new System.Drawing.Point(391, 55);
            this.symmetricDecryptButton.Name = "symmetricDecryptButton";
            this.symmetricDecryptButton.Size = new System.Drawing.Size(389, 23);
            this.symmetricDecryptButton.TabIndex = 4;
            this.symmetricDecryptButton.Text = "Decrypt";
            this.symmetricDecryptButton.UseVisualStyleBackColor = true;
            this.symmetricDecryptButton.Click += new System.EventHandler(this.symmetricDecryptButton_Click);
            // 
            // symmetricEncryptButton
            // 
            this.symmetricEncryptButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.symmetricEncryptButton.Location = new System.Drawing.Point(3, 54);
            this.symmetricEncryptButton.Name = "symmetricEncryptButton";
            this.symmetricEncryptButton.Size = new System.Drawing.Size(389, 23);
            this.symmetricEncryptButton.TabIndex = 3;
            this.symmetricEncryptButton.Text = "Encrypt";
            this.symmetricEncryptButton.UseVisualStyleBackColor = true;
            this.symmetricEncryptButton.Click += new System.EventHandler(this.symmetricEncryptButton_Click);
            // 
            // generateSymmetricKeyButton
            // 
            this.generateSymmetricKeyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.generateSymmetricKeyButton.Location = new System.Drawing.Point(708, 19);
            this.generateSymmetricKeyButton.Name = "generateSymmetricKeyButton";
            this.generateSymmetricKeyButton.Size = new System.Drawing.Size(75, 29);
            this.generateSymmetricKeyButton.TabIndex = 2;
            this.generateSymmetricKeyButton.Text = "Generate";
            this.generateSymmetricKeyButton.UseVisualStyleBackColor = true;
            this.generateSymmetricKeyButton.Click += new System.EventHandler(this.generateSymmetricKeyButton_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(2083, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 26);
            this.button1.TabIndex = 1;
            this.button1.Text = "Generate";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // symmetricKeyBox
            // 
            this.symmetricKeyBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.symmetricKeyBox.Location = new System.Drawing.Point(3, 19);
            this.symmetricKeyBox.Multiline = true;
            this.symmetricKeyBox.Name = "symmetricKeyBox";
            this.symmetricKeyBox.Size = new System.Drawing.Size(703, 29);
            this.symmetricKeyBox.TabIndex = 0;
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.symmetricCiphertextBox);
            this.groupBox11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox11.Location = new System.Drawing.Point(0, 0);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(786, 152);
            this.groupBox11.TabIndex = 0;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Ciphertext";
            // 
            // symmetricCiphertextBox
            // 
            this.symmetricCiphertextBox.BackColor = System.Drawing.SystemColors.Window;
            this.symmetricCiphertextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.symmetricCiphertextBox.Location = new System.Drawing.Point(3, 19);
            this.symmetricCiphertextBox.Multiline = true;
            this.symmetricCiphertextBox.Name = "symmetricCiphertextBox";
            this.symmetricCiphertextBox.Size = new System.Drawing.Size(780, 130);
            this.symmetricCiphertextBox.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(792, 422);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "AsymmetricBox";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.splitContainer1);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(792, 422);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Hash";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.doHashButton);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(792, 422);
            this.splitContainer1.SplitterDistance = 264;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.hashInputBox);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(792, 241);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input";
            // 
            // hashInputBox
            // 
            this.hashInputBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hashInputBox.Location = new System.Drawing.Point(3, 19);
            this.hashInputBox.Multiline = true;
            this.hashInputBox.Name = "hashInputBox";
            this.hashInputBox.Size = new System.Drawing.Size(786, 219);
            this.hashInputBox.TabIndex = 0;
            // 
            // doHashButton
            // 
            this.doHashButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.doHashButton.Location = new System.Drawing.Point(0, 241);
            this.doHashButton.Name = "doHashButton";
            this.doHashButton.Size = new System.Drawing.Size(792, 23);
            this.doHashButton.TabIndex = 1;
            this.doHashButton.Text = "Hash";
            this.doHashButton.UseVisualStyleBackColor = true;
            this.doHashButton.Click += new System.EventHandler(this.doHashButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.hashOutputBox);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(792, 154);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Output";
            // 
            // hashOutputBox
            // 
            this.hashOutputBox.BackColor = System.Drawing.SystemColors.Window;
            this.hashOutputBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hashOutputBox.Location = new System.Drawing.Point(3, 19);
            this.hashOutputBox.Multiline = true;
            this.hashOutputBox.Name = "hashOutputBox";
            this.hashOutputBox.ReadOnly = true;
            this.hashOutputBox.Size = new System.Drawing.Size(786, 132);
            this.hashOutputBox.TabIndex = 1;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.splitContainer2);
            this.tabPage4.Location = new System.Drawing.Point(4, 24);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(792, 422);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "MAC";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox3);
            this.splitContainer2.Panel1.Controls.Add(this.groupBox5);
            this.splitContainer2.Panel1.Controls.Add(this.macButton);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox4);
            this.splitContainer2.Size = new System.Drawing.Size(792, 422);
            this.splitContainer2.SplitterDistance = 264;
            this.splitContainer2.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.macInputBox);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(792, 187);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Input";
            // 
            // macInputBox
            // 
            this.macInputBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.macInputBox.Location = new System.Drawing.Point(3, 19);
            this.macInputBox.Multiline = true;
            this.macInputBox.Name = "macInputBox";
            this.macInputBox.Size = new System.Drawing.Size(786, 165);
            this.macInputBox.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.macKeyBox);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox5.Location = new System.Drawing.Point(0, 187);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(792, 54);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Key";
            // 
            // macKeyBox
            // 
            this.macKeyBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.macKeyBox.Location = new System.Drawing.Point(3, 19);
            this.macKeyBox.Multiline = true;
            this.macKeyBox.Name = "macKeyBox";
            this.macKeyBox.Size = new System.Drawing.Size(786, 32);
            this.macKeyBox.TabIndex = 0;
            // 
            // macButton
            // 
            this.macButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.macButton.Location = new System.Drawing.Point(0, 241);
            this.macButton.Name = "macButton";
            this.macButton.Size = new System.Drawing.Size(792, 23);
            this.macButton.TabIndex = 1;
            this.macButton.Text = "Activate MAC";
            this.macButton.UseVisualStyleBackColor = true;
            this.macButton.Click += new System.EventHandler(this.macButton_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.macOutputBox);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(792, 154);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Output";
            // 
            // macOutputBox
            // 
            this.macOutputBox.BackColor = System.Drawing.SystemColors.Window;
            this.macOutputBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.macOutputBox.Location = new System.Drawing.Point(3, 19);
            this.macOutputBox.Multiline = true;
            this.macOutputBox.Name = "macOutputBox";
            this.macOutputBox.ReadOnly = true;
            this.macOutputBox.Size = new System.Drawing.Size(786, 132);
            this.macOutputBox.TabIndex = 1;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.splitContainer3);
            this.tabPage5.Location = new System.Drawing.Point(4, 24);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(792, 422);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "KDF";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.groupBox6);
            this.splitContainer3.Panel1.Controls.Add(this.groupBox7);
            this.splitContainer3.Panel1.Controls.Add(this.kdfButton);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.groupBox8);
            this.splitContainer3.Size = new System.Drawing.Size(792, 422);
            this.splitContainer3.SplitterDistance = 264;
            this.splitContainer3.TabIndex = 2;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.kdfInputBox);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Location = new System.Drawing.Point(0, 0);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(792, 187);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Input";
            // 
            // kdfInputBox
            // 
            this.kdfInputBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kdfInputBox.Location = new System.Drawing.Point(3, 19);
            this.kdfInputBox.Multiline = true;
            this.kdfInputBox.Name = "kdfInputBox";
            this.kdfInputBox.Size = new System.Drawing.Size(786, 165);
            this.kdfInputBox.TabIndex = 0;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.generateSaltButton);
            this.groupBox7.Controls.Add(this.kdfSaltBox);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox7.Location = new System.Drawing.Point(0, 187);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(792, 54);
            this.groupBox7.TabIndex = 2;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Salt";
            // 
            // generateSaltButton
            // 
            this.generateSaltButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.generateSaltButton.Location = new System.Drawing.Point(717, 18);
            this.generateSaltButton.Name = "generateSaltButton";
            this.generateSaltButton.Size = new System.Drawing.Size(75, 33);
            this.generateSaltButton.TabIndex = 1;
            this.generateSaltButton.Text = "Generate";
            this.generateSaltButton.UseVisualStyleBackColor = true;
            this.generateSaltButton.Click += new System.EventHandler(this.generateSaltButton_Click);
            // 
            // kdfSaltBox
            // 
            this.kdfSaltBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kdfSaltBox.Location = new System.Drawing.Point(3, 19);
            this.kdfSaltBox.Multiline = true;
            this.kdfSaltBox.Name = "kdfSaltBox";
            this.kdfSaltBox.Size = new System.Drawing.Size(715, 32);
            this.kdfSaltBox.TabIndex = 0;
            // 
            // kdfButton
            // 
            this.kdfButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kdfButton.Location = new System.Drawing.Point(0, 241);
            this.kdfButton.Name = "kdfButton";
            this.kdfButton.Size = new System.Drawing.Size(792, 23);
            this.kdfButton.TabIndex = 1;
            this.kdfButton.Text = "Activate KDF";
            this.kdfButton.UseVisualStyleBackColor = true;
            this.kdfButton.Click += new System.EventHandler(this.kdfButton_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.kdfOutputBox);
            this.groupBox8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox8.Location = new System.Drawing.Point(0, 0);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(792, 154);
            this.groupBox8.TabIndex = 0;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Output";
            // 
            // kdfOutputBox
            // 
            this.kdfOutputBox.BackColor = System.Drawing.SystemColors.Window;
            this.kdfOutputBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kdfOutputBox.Location = new System.Drawing.Point(3, 19);
            this.kdfOutputBox.Multiline = true;
            this.kdfOutputBox.Name = "kdfOutputBox";
            this.kdfOutputBox.ReadOnly = true;
            this.kdfOutputBox.Size = new System.Drawing.Size(786, 132);
            this.kdfOutputBox.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "MainForm";
            this.Text = "Cryptography Core Demo";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox hashInputBox;
        private System.Windows.Forms.Button doHashButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox hashOutputBox;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox macInputBox;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox macKeyBox;
        private System.Windows.Forms.Button macButton;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox macOutputBox;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox kdfInputBox;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button generateSaltButton;
        private System.Windows.Forms.TextBox kdfSaltBox;
        private System.Windows.Forms.Button kdfButton;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.TextBox kdfOutputBox;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.TextBox symmetricPlaintextBox;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Button symmetricDecryptButton;
        private System.Windows.Forms.Button symmetricEncryptButton;
        private System.Windows.Forms.Button generateSymmetricKeyButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox symmetricKeyBox;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.TextBox symmetricCiphertextBox;
    }
}

