namespace Pogoda_264254
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
            textBox1 = new TextBox();
            city_name_label = new Label();
            lon_cords = new TextBox();
            button1 = new Button();
            lat_cords = new TextBox();
            lon_label = new Label();
            sort_asc = new Button();
            sort_desc = new Button();
            textBox2 = new TextBox();
            data_base_label = new Label();
            loc_label = new Label();
            lat_label = new Label();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(600, 88);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Size = new Size(359, 517);
            textBox1.TabIndex = 0;
            // 
            // city_name_label
            // 
            city_name_label.AutoSize = true;
            city_name_label.BackColor = Color.Transparent;
            city_name_label.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            city_name_label.Location = new Point(485, 9);
            city_name_label.Name = "city_name_label";
            city_name_label.Size = new Size(0, 32);
            city_name_label.TabIndex = 1;
            // 
            // lon_cords
            // 
            lon_cords.Location = new Point(731, 696);
            lon_cords.Name = "lon_cords";
            lon_cords.PlaceholderText = "lon";
            lon_cords.Size = new Size(76, 23);
            lon_cords.TabIndex = 5;
            lon_cords.Tag = "";
            // 
            // button1
            // 
            button1.Location = new Point(909, 696);
            button1.Name = "button1";
            button1.Size = new Size(115, 23);
            button1.TabIndex = 9;
            button1.Text = "Check weather";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // lat_cords
            // 
            lat_cords.Location = new Point(813, 696);
            lat_cords.Name = "lat_cords";
            lat_cords.PlaceholderText = "lat";
            lat_cords.Size = new Size(76, 23);
            lat_cords.TabIndex = 10;
            // 
            // lon_label
            // 
            lon_label.AutoSize = true;
            lon_label.Location = new Point(617, 21);
            lon_label.Name = "lon_label";
            lon_label.Size = new Size(0, 15);
            lon_label.TabIndex = 11;
            // 
            // sort_asc
            // 
            sort_asc.Location = new Point(656, 611);
            sort_asc.Name = "sort_asc";
            sort_asc.Size = new Size(111, 23);
            sort_asc.TabIndex = 12;
            sort_asc.Text = "Sortuj malejąco";
            sort_asc.UseVisualStyleBackColor = true;
            sort_asc.Click += sort_asc_Click;
            // 
            // sort_desc
            // 
            sort_desc.Location = new Point(796, 611);
            sort_desc.Name = "sort_desc";
            sort_desc.Size = new Size(111, 23);
            sort_desc.TabIndex = 13;
            sort_desc.Text = "Sortuj rosnąco";
            sort_desc.UseVisualStyleBackColor = true;
            sort_desc.Click += sort_desc_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(83, 88);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.ScrollBars = ScrollBars.Vertical;
            textBox2.Size = new Size(359, 517);
            textBox2.TabIndex = 14;
            // 
            // data_base_label
            // 
            data_base_label.AutoSize = true;
            data_base_label.Location = new Point(751, 48);
            data_base_label.Name = "data_base_label";
            data_base_label.Size = new Size(73, 15);
            data_base_label.TabIndex = 15;
            data_base_label.Text = "Baza danych";
            // 
            // loc_label
            // 
            loc_label.AutoSize = true;
            loc_label.Location = new Point(213, 48);
            loc_label.Name = "loc_label";
            loc_label.Size = new Size(111, 15);
            loc_label.TabIndex = 16;
            loc_label.Text = "Aktualna lokalizacja";
            // 
            // lat_label
            // 
            lat_label.AutoSize = true;
            lat_label.Location = new Point(708, 21);
            lat_label.Name = "lat_label";
            lat_label.Size = new Size(0, 15);
            lat_label.TabIndex = 17;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1036, 731);
            Controls.Add(lat_label);
            Controls.Add(loc_label);
            Controls.Add(data_base_label);
            Controls.Add(textBox2);
            Controls.Add(sort_desc);
            Controls.Add(sort_asc);
            Controls.Add(lon_label);
            Controls.Add(lat_cords);
            Controls.Add(button1);
            Controls.Add(lon_cords);
            Controls.Add(city_name_label);
            Controls.Add(textBox1);
            MaximumSize = new Size(1595, 883);
            MinimumSize = new Size(1040, 507);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Label city_name_label;
        private TextBox lon_cords;
        private Button button1;
        private TextBox lat_cords;
        private Label lon_label;
        private Button sort_asc;
        private Button sort_desc;
        private TextBox textBox2;
        private Label data_base_label;
        private Label loc_label;
        private Label lat_label;
    }
}
