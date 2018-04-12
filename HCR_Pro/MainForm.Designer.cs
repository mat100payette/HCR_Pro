namespace HCR_Pro
{
    partial class MainForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tb_Sigma = new System.Windows.Forms.TrackBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tb_Kernel = new System.Windows.Forms.TrackBar();
            this.lbl_Sigma = new System.Windows.Forms.Label();
            this.lbl_SigmaVal = new System.Windows.Forms.Label();
            this.lbl_KernelVal = new System.Windows.Forms.Label();
            this.lbl_Kernel = new System.Windows.Forms.Label();
            this.lbl_PreThreshVal = new System.Windows.Forms.Label();
            this.lbl_PreThresh = new System.Windows.Forms.Label();
            this.tb_PreThresh = new System.Windows.Forms.TrackBar();
            this.btn_Undo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_Sigma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_Kernel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PreThresh)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(12, 78);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(587, 700);
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1191, 24);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.loadImageToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(50, 20);
            this.toolStripMenuItem1.Text = "Menu";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // loadImageToolStripMenuItem
            // 
            this.loadImageToolStripMenuItem.Name = "loadImageToolStripMenuItem";
            this.loadImageToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.loadImageToolStripMenuItem.Text = "Load Image";
            this.loadImageToolStripMenuItem.Click += new System.EventHandler(this.loadImageToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            // 
            // tb_Sigma
            // 
            this.tb_Sigma.LargeChange = 1;
            this.tb_Sigma.Location = new System.Drawing.Point(424, 27);
            this.tb_Sigma.Maximum = 5;
            this.tb_Sigma.Minimum = 1;
            this.tb_Sigma.Name = "tb_Sigma";
            this.tb_Sigma.Size = new System.Drawing.Size(111, 45);
            this.tb_Sigma.TabIndex = 3;
            this.tb_Sigma.Value = 3;
            this.tb_Sigma.ValueChanged += new System.EventHandler(this.tb_Sigma_ValueChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(613, 78);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(566, 700);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // tb_Kernel
            // 
            this.tb_Kernel.LargeChange = 2;
            this.tb_Kernel.Location = new System.Drawing.Point(614, 25);
            this.tb_Kernel.Maximum = 15;
            this.tb_Kernel.Minimum = 1;
            this.tb_Kernel.Name = "tb_Kernel";
            this.tb_Kernel.Size = new System.Drawing.Size(190, 45);
            this.tb_Kernel.SmallChange = 2;
            this.tb_Kernel.TabIndex = 5;
            this.tb_Kernel.Value = 11;
            this.tb_Kernel.ValueChanged += new System.EventHandler(this.tb_Kernel_ValueChanged);
            // 
            // lbl_Sigma
            // 
            this.lbl_Sigma.AutoSize = true;
            this.lbl_Sigma.Location = new System.Drawing.Point(374, 27);
            this.lbl_Sigma.Name = "lbl_Sigma";
            this.lbl_Sigma.Size = new System.Drawing.Size(44, 13);
            this.lbl_Sigma.TabIndex = 6;
            this.lbl_Sigma.Text = "SIGMA:";
            // 
            // lbl_SigmaVal
            // 
            this.lbl_SigmaVal.AutoSize = true;
            this.lbl_SigmaVal.Location = new System.Drawing.Point(405, 49);
            this.lbl_SigmaVal.Name = "lbl_SigmaVal";
            this.lbl_SigmaVal.Size = new System.Drawing.Size(13, 13);
            this.lbl_SigmaVal.TabIndex = 7;
            this.lbl_SigmaVal.Text = "3";
            // 
            // lbl_KernelVal
            // 
            this.lbl_KernelVal.AutoSize = true;
            this.lbl_KernelVal.Location = new System.Drawing.Point(589, 49);
            this.lbl_KernelVal.Name = "lbl_KernelVal";
            this.lbl_KernelVal.Size = new System.Drawing.Size(19, 13);
            this.lbl_KernelVal.TabIndex = 9;
            this.lbl_KernelVal.Text = "11";
            // 
            // lbl_Kernel
            // 
            this.lbl_Kernel.AutoSize = true;
            this.lbl_Kernel.Location = new System.Drawing.Point(555, 27);
            this.lbl_Kernel.Name = "lbl_Kernel";
            this.lbl_Kernel.Size = new System.Drawing.Size(53, 13);
            this.lbl_Kernel.TabIndex = 8;
            this.lbl_Kernel.Text = "KERNEL:";
            // 
            // lbl_PreThreshVal
            // 
            this.lbl_PreThreshVal.AutoSize = true;
            this.lbl_PreThreshVal.Location = new System.Drawing.Point(89, 45);
            this.lbl_PreThreshVal.Name = "lbl_PreThreshVal";
            this.lbl_PreThreshVal.Size = new System.Drawing.Size(25, 13);
            this.lbl_PreThreshVal.TabIndex = 12;
            this.lbl_PreThreshVal.Text = "200";
            // 
            // lbl_PreThresh
            // 
            this.lbl_PreThresh.AutoSize = true;
            this.lbl_PreThresh.Location = new System.Drawing.Point(12, 27);
            this.lbl_PreThresh.Name = "lbl_PreThresh";
            this.lbl_PreThresh.Size = new System.Drawing.Size(102, 13);
            this.lbl_PreThresh.TabIndex = 11;
            this.lbl_PreThresh.Text = "PRE-THRESHOLD:";
            // 
            // tb_PreThresh
            // 
            this.tb_PreThresh.LargeChange = 10;
            this.tb_PreThresh.Location = new System.Drawing.Point(120, 25);
            this.tb_PreThresh.Maximum = 255;
            this.tb_PreThresh.Name = "tb_PreThresh";
            this.tb_PreThresh.Size = new System.Drawing.Size(237, 45);
            this.tb_PreThresh.SmallChange = 5;
            this.tb_PreThresh.TabIndex = 10;
            this.tb_PreThresh.TickFrequency = 5;
            this.tb_PreThresh.Value = 200;
            this.tb_PreThresh.ValueChanged += new System.EventHandler(this.tb_PreThresh_ValueChanged);
            // 
            // btn_Undo
            // 
            this.btn_Undo.Location = new System.Drawing.Point(844, 25);
            this.btn_Undo.Name = "btn_Undo";
            this.btn_Undo.Size = new System.Drawing.Size(42, 33);
            this.btn_Undo.TabIndex = 13;
            this.btn_Undo.Text = "Undo";
            this.btn_Undo.UseVisualStyleBackColor = true;
            this.btn_Undo.Click += new System.EventHandler(this.btn_Undo_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1191, 790);
            this.Controls.Add(this.btn_Undo);
            this.Controls.Add(this.lbl_PreThreshVal);
            this.Controls.Add(this.lbl_PreThresh);
            this.Controls.Add(this.tb_PreThresh);
            this.Controls.Add(this.lbl_KernelVal);
            this.Controls.Add(this.lbl_Kernel);
            this.Controls.Add(this.lbl_SigmaVal);
            this.Controls.Add(this.lbl_Sigma);
            this.Controls.Add(this.tb_Kernel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tb_Sigma);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "HCR Pro";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_Sigma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_Kernel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PreThresh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.TrackBar tb_Sigma;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TrackBar tb_Kernel;
        private System.Windows.Forms.Label lbl_Sigma;
        private System.Windows.Forms.Label lbl_SigmaVal;
        private System.Windows.Forms.Label lbl_KernelVal;
        private System.Windows.Forms.Label lbl_Kernel;
        private System.Windows.Forms.Label lbl_PreThreshVal;
        private System.Windows.Forms.Label lbl_PreThresh;
        private System.Windows.Forms.TrackBar tb_PreThresh;
        private System.Windows.Forms.Button btn_Undo;
    }
}

