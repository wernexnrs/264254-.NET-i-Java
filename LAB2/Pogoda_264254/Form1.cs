using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Windows.Forms;

using System.Text.Json;
namespace Pogoda_264254
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeFormBackground();
            LoadWeatherDataAsync();
        }
        public static async Task GetWeatherAsync()
        {
            HttpClient client = new HttpClient();
            string apiUrl = "https://api.openweathermap.org/data/2.5/weather?lat=51.107883&lon=17.038538&appid=196db3870975458e76528bce29610b2c";
            string response = await client.GetStringAsync(apiUrl);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            WeatherData weatherData = JsonSerializer.Deserialize<WeatherData>(response, options);



            using (var context = new DatabaseContext())
            {
                context.WeatherData.Add(weatherData);

                await context.SaveChangesAsync();
            }

        }

        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            using (var brush = new SolidBrush(Color.FromArgb(90, 0, 0, 0)))
            {
                e.Graphics.FillRectangle(brush, new Rectangle(0, 0, ((PictureBox)sender).Width - 50, ((PictureBox)sender).Height - 50));
            }

        }

        private void InitializeFormBackground()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            PictureBox pictureBox = new PictureBox();
            pictureBox.Dock = DockStyle.Fill;
            pictureBox.Image = Image.FromFile("background.jpg");
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;


            pictureBox.Paint += (sender, e) =>
            {
                int paddingSize = 70;

                using (var brush = new SolidBrush(Color.FromArgb(90, 0, 0, 0)))
                {
                    int x = paddingSize;
                    int y = paddingSize;
                    int width = ((PictureBox)sender).Width - (2 * paddingSize);
                    int height = ((PictureBox)sender).Height - (2 * paddingSize);
                    e.Graphics.FillRectangle(brush, new Rectangle(x, y, width, height));
                }
            };
            this.Controls.Add(pictureBox);
            pictureBox.SendToBack();
        }

        private async void LoadWeatherDataAsync()
        {
            await GetWeatherAsync();

            
            using (var context = new DatabaseContext())
            {
                var weatherData = await context.WeatherData.FirstOrDefaultAsync();

                if (weatherData != null)
                {
                    this.Invoke(new Action(() => {
                        label1.Text = weatherData.name;
                        label2.Text = weatherData.coord.lon.ToString();
                        label2.Text = weatherData.coord.lat.ToString();
                    }));
                }
                else
                {
                    label1.Text = "Dane nie zostaly znalezione.";
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }

}
