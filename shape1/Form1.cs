using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace shape1
{
    public partial class Form1 : Form
    {
        private List<Point> points = new List<Point>();

        public Form1()
        {
            this.Text = "Цэгүүдийг шугамаар холбох";
            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.DoubleBuffered = true;
            this.BackColor = Color.White;

            this.MouseClick += Form1_MouseClick;
        }

        private void Form1_MouseClick(object? sender, MouseEventArgs e)
        {
            points.Add(e.Location);
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.SmoothingMode =
                System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Энд зөвхөн Color.Black гэж бичнэ
            using (Pen pen = new Pen(Color.Black, 2))
            {
                int pointRadius = 4;

                if (points.Count > 1)
                {
                    e.Graphics.DrawLines(pen, points.ToArray());
                }

                foreach (Point pt in points)
                {
                    e.Graphics.FillEllipse(
                        Brushes.Red,
                        pt.X - pointRadius,
                        pt.Y - pointRadius,
                        pointRadius * 2,
                        pointRadius * 2
                    );
                }
            }
        }
    }
}