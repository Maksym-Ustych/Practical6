using System;
using System.Drawing;
using System.Windows.Forms;

namespace Practical6_Ustych
{
    public partial class Form1 : Form
    {
        // Базова точка машинки
        int x0 = 600;
        int y0 = 170;

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Переміщення машинки вліво
            x0 -= 5;

            // Після виходу за ліву межу
            // машинка знову з'являється справа
            if (x0 < -270)
            {
                x0 = ClientSize.Width;
            }

            // Перемалювання форми
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // Кузов
            g.FillRectangle(Brushes.Gray, x0 + 100, y0, 160, 90);
            g.DrawRectangle(Pens.Black, x0 + 100, y0, 160, 90);

            // Кабіна
            Point[] cabin =
            {
                new Point(x0, y0 + 35),
                new Point(x0 + 35, y0),
                new Point(x0 + 95, y0),
                new Point(x0 + 95, y0 + 90),
                new Point(x0, y0 + 90)
            };

            g.FillPolygon(Brushes.Black, cabin);
            g.DrawPolygon(Pens.Black, cabin);

            // Вікно
            Point[] window =
            {
                new Point(x0 + 35, y0 + 12),
                new Point(x0 + 70, y0 + 12),
                new Point(x0 + 82, y0 + 48),
                new Point(x0 + 20, y0 + 48)
            };

            g.FillPolygon(Brushes.Yellow, window);
            g.DrawPolygon(Pens.Black, window);

            // Колеса
            g.FillEllipse(Brushes.White, x0 + 35, y0 + 75, 45, 45);
            g.DrawEllipse(
                new Pen(Color.Black, 3),
                x0 + 35, y0 + 75, 45, 45
            );

            g.FillEllipse(Brushes.White, x0 + 190, y0 + 75, 45, 45);
            g.DrawEllipse(
                new Pen(Color.Black, 3),
                x0 + 190, y0 + 75, 45, 45
            );

            // Середина коліс
            g.FillEllipse(Brushes.Gray, x0 + 49, y0 + 89, 17, 17);
            g.FillEllipse(Brushes.Gray, x0 + 204, y0 + 89, 17, 17);
        }
    }
}