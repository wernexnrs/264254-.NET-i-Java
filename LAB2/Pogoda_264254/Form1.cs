using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Windows.Forms;

using System.Text.Json;
using Microsoft.VisualBasic.Logging;
using Pogoda_264254.Migrations;
using System.Text.RegularExpressions;
using System.Text;
namespace Pogoda_264254
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();
            InitializeFormBackground();
            this.Load += Form1_Load;

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadWeatherDataAsync();
        }
        public static async Task<WeatherData> GetWeatherAsync(double lat = 51.107883, double lon = 17.038538)
        {
            HttpClient client = new HttpClient();
            string apiUrl = $"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid=196db3870975458e76528bce29610b2c";
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

            return weatherData;
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


            Panel panel = new Panel();
            panel.Dock = DockStyle.Fill;
            panel.BackColor = Color.Transparent;


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
            pictureBox.Controls.Add(panel);



            city_name_label.BackColor = Color.Transparent;
            lat_label.BackColor = Color.Transparent;
            lon_label.BackColor = Color.Transparent;
            loc_label.BackColor = Color.Transparent;
            data_base_label.BackColor = Color.Transparent;


            panel.Controls.Add(city_name_label);
            panel.Controls.Add(lat_label);
            panel.Controls.Add(lon_label);
            panel.Controls.Add(loc_label);
            panel.Controls.Add(data_base_label);

            this.Controls.Add(pictureBox);
            pictureBox.SendToBack();
        }

        private async void LoadWeatherDataAsync(bool sortAscending = true)
        {
            using (var context = new DatabaseContext())
            {
                var query = context.WeatherData.AsQueryable();

                if (sortAscending)
                {
                    query = query.OrderBy(w => w.name);
                }
                else
                {
                    query = query.OrderByDescending(w => w.name);
                }

                var weatherDataList = await query.Include(w => w.coord)
                                             .Include(w => w.main)
                                             .Include(w => w.sys)
                                             .Include(w => w.weather)
                                             .Include(w => w.wind)
                                             .Include(w => w.clouds)
                                             .ToListAsync();

                if (weatherDataList.Any())
                {
                    this.Invoke(new Action(() =>
                    {
                        var stringBuilder = new StringBuilder();
                        foreach (var weatherData in weatherDataList)
                        {
                            stringBuilder.AppendLine(weatherData.ToString());
                            stringBuilder.AppendLine(Environment.NewLine);
                        }

                        textBox1.Text = stringBuilder.ToString();
                    }));
                }
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {

            string pattern = @"^\d+\.?\d*$";
            string lon = lon_cords.Text;
            string lat = lat_cords.Text;

            bool validLon = double.TryParse(lon, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double lonDouble);
            bool validLat = double.TryParse(lat, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double latDouble);

            lon_cords.BackColor = validLon ? Color.White : Color.Red;
            lat_cords.BackColor = validLat ? Color.White : Color.Red;

            if (validLon && validLat)
            {
                
                lat_label.Text = lat;
                lon_label.Text = lon;

                var weatherData = await GetWeatherAsync(latDouble, lonDouble);
                city_name_label.Text = weatherData.name;

                textBox2.Text = weatherData.ToString();
            }
        }

        private void sort_asc_Click(object sender, EventArgs e)
        {
            LoadWeatherDataAsync(sortAscending: true);
        }

        private void sort_desc_Click(object sender, EventArgs e)
        {
            LoadWeatherDataAsync(sortAscending: false);
        }
    }

}
