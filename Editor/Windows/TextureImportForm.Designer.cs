namespace Editor
{
    partial class TextureImportForm
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.TexLocation = new System.Windows.Forms.TextBox();
            this.Submit = new System.Windows.Forms.Button();
            this.SingleTexIn = new System.Windows.Forms.RadioButton();
            this.TexSheetIn = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.TSizeInX = new System.Windows.Forms.TextBox();
            this.SizeSelPanel = new System.Windows.Forms.Panel();
            this.TSizeInY = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.TexSheetName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SizeSelPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please Enter Texture Location";
            // 
            // TexLocation
            // 
            this.TexLocation.Location = new System.Drawing.Point(5, 17);
            this.TexLocation.Name = "TexLocation";
            this.TexLocation.Size = new System.Drawing.Size(186, 20);
            this.TexLocation.TabIndex = 1;
            // 
            // Submit
            // 
            this.Submit.Location = new System.Drawing.Point(132, 189);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(75, 20);
            this.Submit.TabIndex = 2;
            this.Submit.Text = "Submit";
            this.Submit.UseVisualStyleBackColor = true;
            this.Submit.Click += new System.EventHandler(this.Submit_Click);
            // 
            // SingleTexIn
            // 
            this.SingleTexIn.AutoSize = true;
            this.SingleTexIn.Location = new System.Drawing.Point(16, 38);
            this.SingleTexIn.Name = "SingleTexIn";
            this.SingleTexIn.Size = new System.Drawing.Size(93, 17);
            this.SingleTexIn.TabIndex = 3;
            this.SingleTexIn.TabStop = true;
            this.SingleTexIn.Text = "Single Texture";
            this.SingleTexIn.UseVisualStyleBackColor = true;
            this.SingleTexIn.CheckedChanged += new System.EventHandler(this.SingleTexIn_CheckedChanged);
            // 
            // TexSheetIn
            // 
            this.TexSheetIn.AutoSize = true;
            this.TexSheetIn.Location = new System.Drawing.Point(115, 38);
            this.TexSheetIn.Name = "TexSheetIn";
            this.TexSheetIn.Size = new System.Drawing.Size(92, 17);
            this.TexSheetIn.TabIndex = 4;
            this.TexSheetIn.TabStop = true;
            this.TexSheetIn.Text = "Texture Sheet";
            this.TexSheetIn.UseVisualStyleBackColor = true;
            this.TexSheetIn.CheckedChanged += new System.EventHandler(this.TexSheetIn_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.TexLocation);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(16, 121);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(267, 42);
            this.panel1.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(198, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(66, 21);
            this.button1.TabIndex = 2;
            this.button1.Text = "Browse";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TSizeInX
            // 
            this.TSizeInX.BackColor = System.Drawing.SystemColors.Window;
            this.TSizeInX.Location = new System.Drawing.Point(3, 18);
            this.TSizeInX.Name = "TSizeInX";
            this.TSizeInX.Size = new System.Drawing.Size(32, 20);
            this.TSizeInX.TabIndex = 6;
            // 
            // SizeSelPanel
            // 
            this.SizeSelPanel.Controls.Add(this.TSizeInY);
            this.SizeSelPanel.Controls.Add(this.label3);
            this.SizeSelPanel.Controls.Add(this.label2);
            this.SizeSelPanel.Controls.Add(this.TSizeInX);
            this.SizeSelPanel.Location = new System.Drawing.Point(18, 62);
            this.SizeSelPanel.Name = "SizeSelPanel";
            this.SizeSelPanel.Size = new System.Drawing.Size(108, 53);
            this.SizeSelPanel.TabIndex = 7;
            // 
            // TSizeInY
            // 
            this.TSizeInY.Location = new System.Drawing.Point(61, 18);
            this.TSizeInY.Name = "TSizeInY";
            this.TSizeInY.Size = new System.Drawing.Size(32, 20);
            this.TSizeInY.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Texture Size";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(10, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 16);
            this.label5.TabIndex = 8;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // TexSheetName
            // 
            this.TexSheetName.Location = new System.Drawing.Point(21, 189);
            this.TexSheetName.Name = "TexSheetName";
            this.TexSheetName.Size = new System.Drawing.Size(100, 20);
            this.TexSheetName.TabIndex = 9;
            
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Texture Sheet Name";
            // 
            // TextureImportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 221);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TexSheetName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.SizeSelPanel);
            this.Controls.Add(this.Submit);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.TexSheetIn);
            this.Controls.Add(this.SingleTexIn);
            this.Name = "TextureImportForm";
            this.Text = "Select A Texture";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.SizeSelPanel.ResumeLayout(false);
            this.SizeSelPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TexLocation;
        private System.Windows.Forms.Button Submit;
        private System.Windows.Forms.RadioButton SingleTexIn;
        private System.Windows.Forms.RadioButton TexSheetIn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox TSizeInX;
        private System.Windows.Forms.Panel SizeSelPanel;
        private System.Windows.Forms.TextBox TSizeInY;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TextBox TexSheetName;
        private System.Windows.Forms.Label label4;
    }
}