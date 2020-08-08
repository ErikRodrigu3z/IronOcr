using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IronOcr;

namespace TextoImagen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Abrir Archivo";
            open.Filter = "jpg files (*.jpg)|*.jpg|Png files (*.png)|*.png";
              
            if (open.ShowDialog() == DialogResult.OK)
            {
                String fileName = open.FileName;
                Bitmap picture = new Bitmap(fileName);
                pictureBox1.Image = (System.Drawing.Image)picture;
                String imageName = open.SafeFileName;


                var Ocr = new AutoOcr();
                //var Result = Ocr.Read(@"C:\path\to\image.png");
                var Result = Ocr.Read(open.FileName);
                Console.WriteLine(Result.Text);


                textBox1.Text = Result.Text;
            }

        }
    }
}
