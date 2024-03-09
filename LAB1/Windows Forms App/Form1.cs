using LAB1_problem_plecakowy;

namespace Windows_Forms_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool textBox1Valid = int.TryParse(textBox1.Text, out int n);
            textBox1.BackColor = textBox1Valid ? System.Drawing.Color.Green : System.Drawing.Color.Red;

            bool textBox2Valid = int.TryParse(textBox2.Text, out int seed);
            textBox2.BackColor = textBox2Valid ? System.Drawing.Color.Green : System.Drawing.Color.Red;

            bool textBox3Valid = int.TryParse(textBox3.Text, out int capacity);
            textBox3.BackColor = textBox3Valid ? System.Drawing.Color.Green : System.Drawing.Color.Red;

            if (!textBox1Valid || !textBox2Valid || !textBox3Valid)
                return;

            problem mc = new(n, seed);
            Result result = mc.Solve(capacity);
            Console.WriteLine(mc.ToString());
            Console.WriteLine(result.ToString());

            textBox4.Text = result.ToString();
            textBox5.Text = mc.ToString();
        }
    }
}