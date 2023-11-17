namespace picture_shop
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
            pictureBox1 = new PictureBox();
            buttonDraw = new Button();
            trackBarTolerance = new TrackBar();
            labelTolerance = new Label();
            buttonSave = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarTolerance).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.White;
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Location = new Point(10, 10);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(458, 374);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // buttonDraw
            // 
            buttonDraw.Location = new Point(317, 405);
            buttonDraw.Name = "buttonDraw";
            buttonDraw.Size = new Size(132, 38);
            buttonDraw.TabIndex = 1;
            buttonDraw.Text = "Draw";
            buttonDraw.UseVisualStyleBackColor = true;
            // 
            // trackBarTolerance
            // 
            trackBarTolerance.Location = new Point(13, 409);
            trackBarTolerance.Maximum = 100;
            trackBarTolerance.Name = "trackBarTolerance";
            trackBarTolerance.Size = new Size(289, 69);
            trackBarTolerance.TabIndex = 2;
            trackBarTolerance.Value = 10;
            trackBarTolerance.Visible = false;
            // 
            // labelTolerance
            // 
            labelTolerance.AutoSize = true;
            labelTolerance.Location = new Point(101, 449);
            labelTolerance.Name = "labelTolerance";
            labelTolerance.Size = new Size(85, 25);
            labelTolerance.TabIndex = 3;
            labelTolerance.Text = "Tolerance";
            labelTolerance.Visible = false;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(317, 444);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(132, 38);
            buttonSave.TabIndex = 1;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(478, 484);
            Controls.Add(labelTolerance);
            Controls.Add(buttonSave);
            Controls.Add(buttonDraw);
            Controls.Add(trackBarTolerance);
            Controls.Add(pictureBox1);
            Name = "MainForm";
            Padding = new Padding(10, 10, 10, 100);
            Text = "PictureShop";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarTolerance).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Button buttonDraw;
        private TrackBar trackBarTolerance;
        private Label labelTolerance;
        private Button buttonSave;
    }
}
