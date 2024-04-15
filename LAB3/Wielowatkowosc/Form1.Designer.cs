namespace Wielowatkowosc
{
    partial class Form1
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
            matrix_text_output = new TextBox();
            matrix_size_input = new TextBox();
            threads_count_input = new TextBox();
            label1 = new Label();
            label2 = new Label();
            matrix_generate_button = new Button();
            execution_time_label_ll = new Label();
            label3 = new Label();
            matrix_right_output = new TextBox();
            matrix_left_output = new TextBox();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            reapet_count = new TextBox();
            label7 = new Label();
            label8 = new Label();
            execution_time_label_hl = new Label();
            label9 = new Label();
            label10 = new Label();
            seedLeft_input = new TextBox();
            maxvalue_input = new TextBox();
            seedRight_input = new TextBox();
            label11 = new Label();
            label12 = new Label();
            time_s = new Label();
            image_open_button = new Button();
            openFileDialog1 = new OpenFileDialog();
            original = new PictureBox();
            label13 = new Label();
            grayScaleImage = new PictureBox();
            negativeImage = new PictureBox();
            ThresholdImage = new PictureBox();
            MirrorImage = new PictureBox();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)original).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grayScaleImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)negativeImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ThresholdImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MirrorImage).BeginInit();
            SuspendLayout();
            // 
            // matrix_text_output
            // 
            matrix_text_output.Location = new Point(1128, 596);
            matrix_text_output.Multiline = true;
            matrix_text_output.Name = "matrix_text_output";
            matrix_text_output.ScrollBars = ScrollBars.Both;
            matrix_text_output.Size = new Size(400, 300);
            matrix_text_output.TabIndex = 0;
            matrix_text_output.WordWrap = false;
            matrix_text_output.TextChanged += Matrix_text_output_TextChanged;
            // 
            // matrix_size_input
            // 
            matrix_size_input.Location = new Point(51, 644);
            matrix_size_input.Name = "matrix_size_input";
            matrix_size_input.Size = new Size(100, 23);
            matrix_size_input.TabIndex = 1;
            matrix_size_input.TextChanged += Matrix_size_input_TextChanged;
            // 
            // threads_count_input
            // 
            threads_count_input.Location = new Point(51, 688);
            threads_count_input.Name = "threads_count_input";
            threads_count_input.PlaceholderText = "1";
            threads_count_input.Size = new Size(100, 23);
            threads_count_input.TabIndex = 2;
            threads_count_input.TextChanged += Threads_count_input_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(51, 621);
            label1.Name = "label1";
            label1.Size = new Size(100, 15);
            label1.TabIndex = 3;
            label1.Text = "Rozmiar macierzy";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(63, 670);
            label2.Name = "label2";
            label2.Size = new Size(75, 15);
            label2.TabIndex = 4;
            label2.Text = "Ilość wątków";
            // 
            // matrix_generate_button
            // 
            matrix_generate_button.Location = new Point(63, 824);
            matrix_generate_button.Name = "matrix_generate_button";
            matrix_generate_button.Size = new Size(75, 23);
            matrix_generate_button.TabIndex = 5;
            matrix_generate_button.Text = "Generuj";
            matrix_generate_button.UseVisualStyleBackColor = true;
            matrix_generate_button.Click += Matrix_generate_button_Click;
            // 
            // execution_time_label_ll
            // 
            execution_time_label_ll.AutoSize = true;
            execution_time_label_ll.Location = new Point(125, 931);
            execution_time_label_ll.Name = "execution_time_label_ll";
            execution_time_label_ll.Size = new Size(0, 15);
            execution_time_label_ll.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 916);
            label3.Name = "label3";
            label3.Size = new Size(110, 15);
            label3.TabIndex = 7;
            label3.Text = "Uśredniony czas LL:";
            label3.Click += Label3_Click;
            // 
            // matrix_right_output
            // 
            matrix_right_output.Location = new Point(694, 596);
            matrix_right_output.Multiline = true;
            matrix_right_output.Name = "matrix_right_output";
            matrix_right_output.ScrollBars = ScrollBars.Both;
            matrix_right_output.Size = new Size(400, 300);
            matrix_right_output.TabIndex = 8;
            matrix_right_output.WordWrap = false;
            // 
            // matrix_left_output
            // 
            matrix_left_output.Location = new Point(258, 596);
            matrix_left_output.Multiline = true;
            matrix_left_output.Name = "matrix_left_output";
            matrix_left_output.ScrollBars = ScrollBars.Both;
            matrix_left_output.Size = new Size(400, 300);
            matrix_left_output.TabIndex = 9;
            matrix_left_output.WordWrap = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(410, 578);
            label4.Name = "label4";
            label4.Size = new Size(64, 15);
            label4.TabIndex = 10;
            label4.Text = "Left matrix";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(865, 578);
            label5.Name = "label5";
            label5.Size = new Size(72, 15);
            label5.TabIndex = 11;
            label5.Text = "Right matrix";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(1303, 578);
            label6.Name = "label6";
            label6.Size = new Size(76, 15);
            label6.TabIndex = 12;
            label6.Text = "Result matrix";
            // 
            // reapet_count
            // 
            reapet_count.Location = new Point(52, 736);
            reapet_count.Name = "reapet_count";
            reapet_count.PlaceholderText = "1";
            reapet_count.Size = new Size(100, 23);
            reapet_count.TabIndex = 13;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(56, 718);
            label7.Name = "label7";
            label7.Size = new Size(90, 15);
            label7.TabIndex = 14;
            label7.Text = "Ilość powtórzeń";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(12, 931);
            label8.Name = "label8";
            label8.Size = new Size(113, 15);
            label8.TabIndex = 16;
            label8.Text = "Uśredniony czas HL:";
            // 
            // execution_time_label_hl
            // 
            execution_time_label_hl.AutoSize = true;
            execution_time_label_hl.Location = new Point(122, 916);
            execution_time_label_hl.Name = "execution_time_label_hl";
            execution_time_label_hl.Size = new Size(0, 15);
            execution_time_label_hl.TabIndex = 15;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(47, 762);
            label9.Name = "label9";
            label9.Size = new Size(118, 30);
            label9.TabIndex = 17;
            label9.Text = "Maksymalna wartość\r\nelementu";
            label9.TextAlign = ContentAlignment.TopCenter;
            label9.Click += label9_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(425, 908);
            label10.Name = "label10";
            label10.Size = new Size(32, 15);
            label10.TabIndex = 18;
            label10.Text = "Seed";
            // 
            // seedLeft_input
            // 
            seedLeft_input.Location = new Point(389, 926);
            seedLeft_input.Name = "seedLeft_input";
            seedLeft_input.PlaceholderText = "1";
            seedLeft_input.Size = new Size(100, 23);
            seedLeft_input.TabIndex = 19;
            // 
            // maxvalue_input
            // 
            maxvalue_input.Location = new Point(54, 795);
            maxvalue_input.Name = "maxvalue_input";
            maxvalue_input.PlaceholderText = "10";
            maxvalue_input.Size = new Size(100, 23);
            maxvalue_input.TabIndex = 20;
            // 
            // seedRight_input
            // 
            seedRight_input.Location = new Point(854, 928);
            seedRight_input.Name = "seedRight_input";
            seedRight_input.PlaceholderText = "1";
            seedRight_input.Size = new Size(100, 23);
            seedRight_input.TabIndex = 21;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(888, 910);
            label11.Name = "label11";
            label11.Size = new Size(32, 15);
            label11.TabIndex = 22;
            label11.Text = "Seed";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(12, 901);
            label12.Name = "label12";
            label12.Size = new Size(104, 15);
            label12.TabIndex = 23;
            label12.Text = "Uśredniony czas S:";
            // 
            // time_s
            // 
            time_s.AutoSize = true;
            time_s.Location = new Point(122, 901);
            time_s.Name = "time_s";
            time_s.Size = new Size(0, 15);
            time_s.TabIndex = 24;
            // 
            // image_open_button
            // 
            image_open_button.Location = new Point(12, 853);
            image_open_button.Name = "image_open_button";
            image_open_button.Size = new Size(96, 26);
            image_open_button.TabIndex = 25;
            image_open_button.Text = "Otwórz zdjęcie";
            image_open_button.UseVisualStyleBackColor = true;
            image_open_button.Click += image_open_button_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // original
            // 
            original.Location = new Point(12, 42);
            original.Name = "original";
            original.Size = new Size(512, 512);
            original.TabIndex = 26;
            original.TabStop = false;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(224, 24);
            label13.Name = "label13";
            label13.Size = new Size(49, 15);
            label13.TabIndex = 27;
            label13.Text = "Original";
            // 
            // grayScaleImage
            // 
            grayScaleImage.Location = new Point(530, 42);
            grayScaleImage.MaximumSize = new Size(256, 256);
            grayScaleImage.MinimumSize = new Size(256, 256);
            grayScaleImage.Name = "grayScaleImage";
            grayScaleImage.Size = new Size(256, 256);
            grayScaleImage.TabIndex = 28;
            grayScaleImage.TabStop = false;
            // 
            // negativeImage
            // 
            negativeImage.Location = new Point(792, 42);
            negativeImage.MaximumSize = new Size(256, 256);
            negativeImage.MinimumSize = new Size(256, 256);
            negativeImage.Name = "negativeImage";
            negativeImage.Size = new Size(256, 256);
            negativeImage.SizeMode = PictureBoxSizeMode.AutoSize;
            negativeImage.TabIndex = 30;
            negativeImage.TabStop = false;
            // 
            // ThresholdImage
            // 
            ThresholdImage.Location = new Point(1054, 42);
            ThresholdImage.MaximumSize = new Size(256, 256);
            ThresholdImage.MinimumSize = new Size(256, 256);
            ThresholdImage.Name = "ThresholdImage";
            ThresholdImage.Size = new Size(256, 256);
            ThresholdImage.SizeMode = PictureBoxSizeMode.AutoSize;
            ThresholdImage.TabIndex = 31;
            ThresholdImage.TabStop = false;
            // 
            // MirrorImage
            // 
            MirrorImage.Location = new Point(1316, 42);
            MirrorImage.MaximumSize = new Size(256, 256);
            MirrorImage.MinimumSize = new Size(256, 256);
            MirrorImage.Name = "MirrorImage";
            MirrorImage.Size = new Size(256, 256);
            MirrorImage.SizeMode = PictureBoxSizeMode.AutoSize;
            MirrorImage.TabIndex = 32;
            MirrorImage.TabStop = false;
            // 
            // button1
            // 
            button1.Location = new Point(114, 853);
            button1.Name = "button1";
            button1.Size = new Size(96, 26);
            button1.TabIndex = 36;
            button1.Text = "Zastosuj filtry";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1784, 961);
            Controls.Add(button1);
            Controls.Add(MirrorImage);
            Controls.Add(ThresholdImage);
            Controls.Add(negativeImage);
            Controls.Add(grayScaleImage);
            Controls.Add(label13);
            Controls.Add(original);
            Controls.Add(image_open_button);
            Controls.Add(time_s);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(seedRight_input);
            Controls.Add(maxvalue_input);
            Controls.Add(seedLeft_input);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(execution_time_label_hl);
            Controls.Add(label7);
            Controls.Add(reapet_count);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(matrix_left_output);
            Controls.Add(matrix_right_output);
            Controls.Add(label3);
            Controls.Add(execution_time_label_ll);
            Controls.Add(matrix_generate_button);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(threads_count_input);
            Controls.Add(matrix_size_input);
            Controls.Add(matrix_text_output);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)original).EndInit();
            ((System.ComponentModel.ISupportInitialize)grayScaleImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)negativeImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)ThresholdImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)MirrorImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox matrix_text_output;
        private TextBox matrix_size_input;
        private TextBox threads_count_input;
        private Label label1;
        private Label label2;
        private Button matrix_generate_button;
        private Label execution_time_label_ll;
        private Label label3;
        private TextBox matrix_right_output;
        private TextBox matrix_left_output;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox reapet_count;
        private Label label7;
        private Label label8;
        private Label execution_time_label_hl;
        private Label label9;
        private Label label10;
        private TextBox seedLeft_input;
        private TextBox maxvalue_input;
        private TextBox seedRight_input;
        private Label label11;
        private Label label12;
        private Label time_s;
        private Button image_open_button;
        private OpenFileDialog openFileDialog1;
        private PictureBox original;
        private Label label13;
        private PictureBox grayScaleImage;
        private PictureBox negativeImage;
        private PictureBox ThresholdImage;
        private PictureBox MirrorImage;
        private Button button1;
    }
}
