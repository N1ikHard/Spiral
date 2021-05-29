using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spiral
{
    public partial class Form1 : Form
    {
        Bitmap bitmap;                      //Битмап - это пиксельное поле
        Graphics graphics;                  //Класс для рисования
        Pen pen;                            //Класс для рисования
        public Form1()
        {
            InitializeComponent();
        }
        void Init()
        {
            bitmap = new Bitmap(Width, Height);
            graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.White);
            BackgroundImage = bitmap;
             pen = new Pen(Color.Black);
        }
        void Draw()
        {
            NextSpiral(10, 10, 400, 400, 10);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Init();
            Draw();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Init();
            Draw();
            Debug.WriteLine(Width + "x" + Height);
        }
        void NextSpiral( int x1 , int y1 , int x2 , int y2 , int s)
        {
            if (x2 <= 0 || y2 <= 0)
                return;
            graphics.DrawLine(pen, x1, y1, x1 + x2, y1);
            graphics.DrawLine(pen, x1+x2, y1, x1 + x2, y1 + y2);
            graphics.DrawLine(pen, x1+x2, y1+y2, x1+s, y1 + y2);
            graphics.DrawLine(pen, x1+s, y1+y2, x1 + s, y1 + s);
            
            NextSpiral(x1 + s, y1 + s, x2 - 2 * s, y2 - 2 * s,s);
        }
    }
}
