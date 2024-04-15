using System.Diagnostics;
using System.Windows.Forms;

namespace Wielowatkowosc
{
    public partial class Form1 : Form
    {
        private Bitmap? img;

        public Form1()
        {
            InitializeComponent();
        }

        private void Matrix_text_output_TextChanged(object sender, EventArgs e)
        {

        }

        private void Threads_count_input_TextChanged(object sender, EventArgs e)
        {

        }

        private void Matrix_size_input_TextChanged(object sender, EventArgs e)
        {

        }

        private void Matrix_generate_button_Click(object sender, EventArgs e)
        {

            var n = int.TryParse(matrix_size_input.Text, out var tempN) ? tempN : 2;
            var threads = int.TryParse(threads_count_input.Text, out var tempThreads) ? tempThreads : 1;
            var count_number = int.TryParse(reapet_count.Text, out var tempCount) ? tempCount : 1;

            var seedLeft = int.TryParse(seedLeft_input.Text, out var tempSeedLeft) ? tempSeedLeft : 1;
            var seedRight = int.TryParse(seedRight_input.Text, out var tempSeedRight) ? tempSeedRight : 1;
            var maxvalue = int.TryParse(maxvalue_input.Text, out var TempMaxValue) ? TempMaxValue : 10;

            var time_taken_LL = 0.0;

            Stopwatch stopwatch_LL = new();

            for (var i = 0; i < count_number; i++)
            {
                stopwatch_LL.Restart();
                _ = new LL(n, threads, seedLeft, maxvalue);

                stopwatch_LL.Stop();
                time_taken_LL += stopwatch_LL.Elapsed.TotalMilliseconds;

                //matrix_left_output.Text = LL.leftMatrix.ToString();
                //matrix_right_output.Text = LL.rightMatrix.ToString();
                //matrix_text_output.Text = LL.resultMatrix.ToString();
            }

            execution_time_label_ll.Text = $"{Math.Round(time_taken_LL / count_number / 1000, 4)} s";



            var time_taken_HL = 0.0;

            Stopwatch stopwatch_HL = new();

            for (var i = 0; i < count_number; i++)
            {
                stopwatch_HL.Restart();
                var HL = new HL(n, threads, seedRight, maxvalue);

                stopwatch_HL.Stop();
                time_taken_HL += stopwatch_HL.Elapsed.TotalMilliseconds;

                matrix_left_output.Text = HL.LeftMatrix.ToString();
                matrix_right_output.Text = HL.RightMatrix.ToString();
                
                matrix_text_output.Text = HL.ResultMatrix.ToString();
            }

            execution_time_label_hl.Text = $"{Math.Round(time_taken_HL / count_number / 1000, 4)} s";



            var time_taken_S = 0.0;

            Stopwatch stopwatch_S = new();

            for (var i = 0; i < count_number; i++)
            {
                stopwatch_S.Restart();
                var S = new S(n, threads, seedRight, maxvalue);

                stopwatch_S.Stop();
                time_taken_S += stopwatch_S.Elapsed.TotalMilliseconds;

                //matrix_left_output.Text = S.LeftMatrix.ToString();
                //matrix_right_output.Text = S.RightMatrix.ToString();
                //matrix_text_output.Text = S.ResultMatrix.ToString();
            }

            time_s.Text = $"{Math.Round(time_taken_S / count_number / 1000, 4)} s";
        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void image_open_button_Click(object sender, EventArgs e)
        {

            openFileDialog1.ShowDialog();
            var file = openFileDialog1.FileName;
            if (file == null) return;

            img = new Bitmap(file);
            original.Image = img;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            grayScaleImage.SizeMode = PictureBoxSizeMode.Zoom;
            negativeImage.SizeMode = PictureBoxSizeMode.Zoom;
            ThresholdImage.SizeMode = PictureBoxSizeMode.Zoom;
            MirrorImage.SizeMode = PictureBoxSizeMode.Zoom;

            Bitmap grayScaleClone = (Bitmap)img.Clone();
            Bitmap negativeClone = (Bitmap)img.Clone();
            Bitmap thresholdClone = (Bitmap)img.Clone();
            Bitmap mirrorClone = (Bitmap)img.Clone();

            Bitmap grayImage = null;
            Bitmap negativeImageBitmap = null;
            Bitmap thresholdImageBitmap = null;
            Bitmap mirrorImageBitmap = null;

            Parallel.Invoke(
                () => grayImage = ImageFilters.ConvertToGrayscale(grayScaleClone),
                () => negativeImageBitmap = ImageFilters.ConvertToNegative(negativeClone),
                () => thresholdImageBitmap = ImageFilters.ApplyThreshold(thresholdClone, 200),
                () => mirrorImageBitmap = ImageFilters.MirrorImage(mirrorClone)
            );

            grayScaleImage.Image = grayImage;
            negativeImage.Image = negativeImageBitmap;
            ThresholdImage.Image = thresholdImageBitmap;
            MirrorImage.Image = mirrorImageBitmap;
        }

    }
}
