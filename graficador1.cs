using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private Pen lapiz, lapiz2;//inicialización de los dos lapices para dibujar
        private Graphics linea, vector;//inicializacion de el grafico para poder dibujar
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            {
                textBox1.Text = "0";
                textBox2.Text = "0";
                textBox3.Text = "0";
                textBox4.Text = "0";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            float x1, x2, y1, y2, m;
            string t;
            x1 = (float)Convert.ToDouble(textBox1.Text);
            x2 = (float)Convert.ToDouble(textBox2.Text);
            y1 = (float)Convert.ToDouble(textBox3.Text);
            y2 = (float)Convert.ToDouble(textBox4.Text);
 m = (y2 - y1) / (x2 - x1);
 textBox5.Text = (m.ToString("N2"));//se usa el N2 para que solo se muestren dos decimales
 t = Tipo(x1, x2, y1, y2, m);//se manda a llamar la funcion donde nos dira el tipo de linea que es
 textBox6.Text = t;//se imprime el tipo
 Dibujar(x1, x2, y1, y2, m, t);//se manda a llamar la funcion para dibujar la linea
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            int xcentro = pictureBox1.Width / 2;
 int ycentro = pictureBox1.Height / 2;
 Pen lapiz = new Pen(Color.Black, 2);
 e.Graphics.TranslateTransform(xcentro, ycentro);//convierte las coordenadas a la forma de la grafica
 e.Graphics.ScaleTransform(1, -1);//se convierten a coordenadas normales
 e.Graphics.DrawLine(lapiz, xcentro * -1, 0, xcentro * 2, 0);
 e.Graphics.DrawLine(lapiz, 0, ycentro, 0, ycentro * -1);
 using (Font myFont = new Font("Arial", 14))
 for (int i = -xcentro; i < xcentro; i += 10)
 {
 e.Graphics.DrawLine(lapiz, 5, i, -5, i);//division de las y
 e.Graphics.DrawLine(lapiz, i, 5, i, -5);//division de las x
 }
 int j = -450, k=300, m=22;
 for (int l = 50; l<960; l+=50)
 {

 using (Font font = new Font("Times New Roman", 10, FontStyle.Bold,
GraphicsUnit.Pixel))
 {
 Point point1 = new Point(l - 10, ycentro + 10);
 if(j!=0)
 {
 TextRenderer.DrawText(e.Graphics, Convert.ToString(j), font, point1,
Color.Blue);
 }
     Point point2 = new Point(xcentro + 10, m);
 if(k!=0)
 {
 TextRenderer.DrawText(e.Graphics, Convert.ToString(k), font, point2,
Color.Blue);
 }
 }

 j += 50;
 k -= 50;
 m += 50;
 }
 }private static string Tipo(float x1, float x2, float y1, float y2, float m)
 {
 float xi, xf, yi, yf, x, y, m1;
 string tipo = "";
 xi = x1;
 xf = x2;
 yi = y1;
 yf = y2;
 m1 = m;
 x = xf - xi;
 y = yf - yi;
 if (m < 1.0 && m > 0.0)
 {
 if (xi < xf && yi < yf)
 {
 tipo = "caso 1";
 }
 else if (xi > xf && yi > yf)
 {
 tipo = "caso 2";
 }
 }
 else if (m > 1.0)
 {
 if (xi < xf && yi < yf)
 {
tipo = "caso 3";
 }
 else if (xi > xf && yi > yf)
 {
 tipo = "caso 4";
 }
 }
 else if (m == 1 || m == -1)
 {
 if (x > 0.0 && y > 0.0)
 {
 tipo = "caso 5.1";
 }
 else if (x > 0.0 && y < 0.0)
 {
 tipo = "caso 5.2";
 }
 else if (x < 0.0 && y > 0.0)
 {
 tipo = "caso 5.3";
 }
 else if (x < 0.0 && y < 0.0)
 {
 tipo = "caso 5.4";
 }
 }
 else if (m == 0)
 {
 if (x > 0.0)
 {
 tipo = "caso 6.1";
 }
 else if (x < 0.0)
 {
 tipo = "caso 6.2";
 }
 }
 else if (x == 0.0)
 {
 if(y2 < y1)
 {
 tipo = "caso 7.1";
 }else if(y2 > y1)
 {
     tipo = "caso 7.2";
 }
 }
 else if (m < 0.0 && m > -1.0)
 {
 if (x < 0.0)
 {
 tipo = "caso negativo 1";
 }
 else if (y < 0.0)
 {
 tipo = "caso negativo 2";
 }
 }
 else if (m < -1.0)
 {
 if (xi > xf && yi < yf)
 {
 tipo = "caso negativo 3";
 }
 else if (xi < xf && yi > yf)
 {
 tipo = "caso negativo 4";
 }
 }
 return tipo;
 }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
 vector = pictureBox1.CreateGraphics();
 int xcentro = pictureBox1.Width / 2;
 int ycentro = pictureBox1.Height / 2;
 Pen lapiz = new Pen(Color.Black, 2);
 vector.TranslateTransform(xcentro, ycentro);//convierte las coordenadas a la forma de la grafica
 vector.ScaleTransform(1, -1);//se convierten a coordenadas normales
            vector.DrawLine(lapiz, xcentro * -1, 0, xcentro * 2, 0);
 vector.DrawLine(lapiz, 0, ycentro, 0, ycentro * -1);
 for (int i = -xcentro; i < xcentro; i += 10)
 {
 vector.DrawLine(lapiz, 5, i, -5, i);//division de las y
 vector.DrawLine(lapiz, i, 5, i, -5);//division de las x
 }
 textBox1.Text = "0";
 textBox2.Text = "0";
 textBox3.Text = "0";
 textBox4.Text = "0";
 textBox5.Text = "";
 textBox6.Text = "";
 textBox7.Text = "";
        }
        void Dibujar(float x1, float x2, float y1, float y2, float m, string tipo)
 {
 float xi, xf, yi, yf, m1;
 xi = x1;
 xf = x2;
 yi = y1;
 yf = y2;
 m1 = m;
 string t = tipo;
 int xcentro = pictureBox1.Width / 2;
 int ycentro = pictureBox1.Height / 2;
 linea = pictureBox1.CreateGraphics();
 lapiz = new Pen(Color.Red,2);
 lapiz2 = new Pen(Color.Blue, 2);
 linea.TranslateTransform(xcentro, ycentro);//convierte las coordenadas a la forma de la grafica
 linea.ScaleTransform(1, -1);
 if ((tipo.Equals("caso 1")==true))
 {
 for(int i=(int)xi; i<(int)xf; i++)
 {
 linea.DrawRectangle(lapiz, new Rectangle(i, (int)yi, 1, 1));
 textBox7.Text += (i.ToString("N2")) + " - ";
 textBox7.Text += (yi.ToString("N2")) + "\r\n";
 yi += m1;
 }
 yi += m1;
 linea.DrawRectangle(lapiz2, new Rectangle((int)xf, (int)yi, 1, 1));
 textBox7.Text += (xf.ToString("N2")) + " - ";
 textBox7.Text += (yi.ToString("N2")) + "\r\n";
 }
 else if((tipo.Equals("caso 2") == true))
 {
 for (int i = (int)xi; i > (int)xf; i--)
 {
 linea.DrawRectangle(lapiz, i, (int)yi, 1, 1);
 textBox7.Text += (i.ToString("N2")) + " - ";
 textBox7.Text += (yi.ToString("N2")) + "\r\n";
 yi -= m1;
 }
 yi -= m1;
 linea.DrawRectangle(lapiz2, xf, (int)yi, 1, 1);
 textBox7.Text += (xf.ToString("N2")) + " - ";
 textBox7.Text += (yi.ToString("N2")) + "\r\n";
 }
 else if((tipo.Equals("caso 3") == true))
 {
 for (int i = (int)yi; i < (int)yf; i++)
 {
 linea.DrawRectangle(lapiz, (int)xi, i, 1, 1);
 textBox7.Text += (xi.ToString("N2")) + " - ";
 textBox7.Text += (i.ToString("N2")) + "\r\n";
 xi += 1/m1;
 }
 xi += (1/m1);
 linea.DrawRectangle(lapiz2, (int)xi, yf, 1, 1);
 textBox7.Text += (xi.ToString("N2")) + " - ";
 textBox7.Text += (yf.ToString("N2")) + "\r\n";
 }
 else if ((tipo.Equals("caso 4") == true))
 {
 for (int i = (int)yi; i > (int)yf; i--)
     {
 linea.DrawRectangle(lapiz, (int)xi, i, 1, 1);
 textBox7.Text += (xi.ToString("N2")) + " - ";
 textBox7.Text += (i.ToString("N2")) + "\r\n";
 xi -= (1/m1) ;
 }
 xi -= m1;
 linea.DrawRectangle(lapiz2, (int)xi, yf, 1, 1);
 textBox7.Text += (xi.ToString("N2")) + " - ";
 textBox7.Text += (yf.ToString("N2")) + "\r\n";
 }
 else if ((tipo.Equals("caso 5.1") == true))
 {
 for (int i = (int)xi; i < (int)xf; i++)
 {
 linea.DrawRectangle(lapiz, i, (int)yi, 1, 1);
 textBox7.Text += (i.ToString("N2")) + " - ";
 textBox7.Text += (yi.ToString("N2")) + "\r\n";
 yi += m1;
 }
 yi += m1;
 linea.DrawRectangle(lapiz2, xf, (int)yi, 1, 1);
 textBox7.Text += (xf.ToString("N2")) + " - ";
 textBox7.Text += (yi.ToString("N2")) + "\r\n";
 }
 else if ((tipo.Equals("caso 5.2") == true))
 {
 for (int i = (int)xi; i < (int)xf; i++)
 {
 linea.DrawRectangle(lapiz, i, (int)yi, 1, 1);
 textBox7.Text += (i.ToString("N2")) + " - ";
 textBox7.Text += (yi.ToString("N2")) + "\r\n";
 yi += m1;
 }
 yi -= m1;
 linea.DrawRectangle(lapiz2, xf, (int)yi, 1, 1);
 textBox7.Text += (xf.ToString("N2")) + " - ";
 textBox7.Text += (yi.ToString("N2")) + "\r\n";
 }
 else if ((tipo.Equals("caso 5.3") == true))
 {
 for (int i = (int)xi; i > (int)xf; i--)
 {
 linea.DrawRectangle(lapiz, i, (int)yi, 1, 1);
     textBox7.Text += (i.ToString("N2")) + " - ";
 textBox7.Text += (yi.ToString("N2")) + "\r\n";
 yi -= m1;
 }
 yi -= m1;
 linea.DrawRectangle(lapiz2, xf, (int)yi, 1, 1);
 textBox7.Text += (xf.ToString("N2")) + " - ";
 textBox7.Text += (yi.ToString("N2")) + "\r\n";
 }
 else if ((tipo.Equals("caso 5.4") == true))
 {
 for (int i = (int)xi; i > (int)xf; i--)
 {
 linea.DrawRectangle(lapiz, i, (int)yi, 1, 1);
 textBox7.Text += (i.ToString("N2")) + " - ";
 textBox7.Text += (yi.ToString("N2")) + "\r\n";
 yi -= m1;
 }
 yi -= m1;
 linea.DrawRectangle(lapiz2, xf, (int)yi, 1, 1);
 textBox7.Text += (xf.ToString("N2")) + " - ";
 textBox7.Text += (yi.ToString("N2")) + "\r\n";
 }
 else if ((tipo.Equals("caso 6.1") == true))
 {
 for (int i = (int)xi; i < (int)xf; i++)
 {
 linea.DrawRectangle(lapiz, i, (int)yi, 1, 1);
 textBox7.Text += (i.ToString("N2")) + " - ";
 textBox7.Text += (yi.ToString("N2")) + "\r\n";
 }
 linea.DrawRectangle(lapiz2, xf, (int)yi, 1, 1);
 textBox7.Text += (xf.ToString("N2")) + " - ";
 textBox7.Text += (yf.ToString("N2")) + "\r\n";
 }
 else if ((tipo.Equals("caso 6.2") == true))
 {
 for (int i = (int)xi; i > (int)xf; i--)
 {
 linea.DrawRectangle(lapiz, i, (int)yi, 1, 1);
 textBox7.Text += (i.ToString("N2")) + " - ";
 textBox7.Text += (yi.ToString("N2")) + "\r\n";
 }
 linea.DrawRectangle(lapiz2, xf, (int)yi, 1, 1);
     textBox7.Text += (xf.ToString("N2")) + " - ";
 textBox7.Text += (yf.ToString("N2")) + "\r\n";
 }
 else if ((tipo.Equals("caso 7.1") == true))
 {
 for (int i = (int)yi; i > (int)yf; i--)
 {
 linea.DrawRectangle(lapiz, xi, i, 1, 1);
 textBox7.Text += (xi.ToString("N2")) + " - ";
 textBox7.Text += (i.ToString("N2")) + "\r\n";
 }
 linea.DrawRectangle(lapiz2, xf, yf, 1, 1);
 textBox7.Text += (xf.ToString("N2")) + " - ";
 textBox7.Text += (yf.ToString("N2")) + "\r\n";
 }
 else if ((tipo.Equals("caso 7.2") == true))
 {
 for (int i = (int)yi; i < (int)yf; i++)
 {
 linea.DrawRectangle(lapiz, xi, i, 1, 1);
 textBox7.Text += (xi.ToString("N2")) + " - ";
 textBox7.Text += (i.ToString("N2")) + "\r\n";
 }
 linea.DrawRectangle(lapiz2, xf, yf, 1, 1);
 textBox7.Text += (xf.ToString("N2")) + " - ";
 textBox7.Text += (yf.ToString("N2")) + "\r\n";
 }
 else if ((tipo.Equals("caso negativo 1") == true))
 {
 for (int i = (int)xi; i > (int)xf; i--)
 {
 linea.DrawRectangle(lapiz, i, yi, 1, 1);
 textBox7.Text += (i.ToString("N2")) + " - ";
 textBox7.Text += (yi.ToString("N2")) + "\r\n";
 yi -= m;
 }
 yi -= m;
 linea.DrawRectangle(lapiz2, xf, yi, 1, 1);
 textBox7.Text += (xf.ToString("N2")) + " - ";
 textBox7.Text += (yf.ToString("N2")) + "\r\n";
 }
 else if ((tipo.Equals("caso negativo 2") == true))
 {
 for (int i = (int)xi; i < (int)xf; i++)
     {
 linea.DrawRectangle(lapiz, i, yi, 1, 1);
 textBox7.Text += (i.ToString("N2")) + " - ";
 textBox7.Text += (yi.ToString("N2")) + "\r\n";
 yi += m;
 }
 yi += m;
 linea.DrawRectangle(lapiz2, xf, yi, 1, 1);
 textBox7.Text += (xf.ToString("N2")) + " - ";
 textBox7.Text += (yf.ToString("N2")) + "\r\n";
 }
 else if ((tipo.Equals("caso negativo 3") == true))
 {
 for (int i = (int)yi; i < (int)yf; i++)
 {
 linea.DrawRectangle(lapiz, xi, i, 1, 1);
 textBox7.Text += (xi.ToString("N2")) + " - ";
 textBox7.Text += (i.ToString("N2")) + "\r\n";
 xi += (1/m);
 }
 xi -= (1/m);
 linea.DrawRectangle(lapiz2, xi, yf, 1, 1);
 textBox7.Text += (xi.ToString("N2")) + " - ";
 textBox7.Text += (yf.ToString("N2")) + "\r\n";
 }
 else if ((tipo.Equals("caso negativo 4") == true))
 {
 for (int i = (int)yi; i > (int)yf; i--)
 {
 linea.DrawRectangle(lapiz, xi, i, 1, 1);
 textBox7.Text += (xi.ToString("N2")) + " - ";
 textBox7.Text += (i.ToString("N2")) + "\r\n";
 xi -= (1/m);
 }
 xi -= (1/m);
 linea.DrawRectangle(lapiz2, xi, yf, 1, 1);
 textBox7.Text += (xi.ToString("N2")) + " - ";
 textBox7.Text += (yf.ToString("N2")) + "\r\n";
 }


        }
    }
}
