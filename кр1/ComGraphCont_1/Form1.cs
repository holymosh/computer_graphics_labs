using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ComGraphCont_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        float[,] Bxy = { { 0, 60 }, { 30, 0 }, { 60, 60 }, { 90, 0 }, { 120, 60 }, { 150, 0 }, { 180, 60 } };
        private static int[] x = new []{ 1, 1, 1, 1, 1, 2, 3, 4, 4, 4, 4, 4 };

        static float RecurMetod(int ind, int k, float par)
        {
            //if (k == 1)
            //{
            //    //if ((x[ind] <= par) && (par <= x[ind + 1]))
            //    //    return 1;
            //    //return 0;
            //    return 1;
            //}
            if (k <= 1)
            {
                if ((x[ind] <= par) && (par <= x[ind + 1]))
                    return 1;
                return 0;
            }
            return ((par - x[ind])*RecurMetod(ind,k-1,par)/(x[ind+k-1] -x[ind]) + ((x[ind+k]-par)*RecurMetod(ind+1,k-1,par))/(x[ind+k]-x[ind+1]))

            ;
            //if ((x[ind + k - 1] - x[ind]) == 0)
            //    return ((x[ind + k] - par) * RecurMetod(ind + 1, k - 1, par)) / (x[ind + k] - x[ind + 1]);
            //if ((x[ind + k] - x[ind + 1]) == 0)
            //    return ((par - x[ind]) * RecurMetod(ind, k - 1, par)) / (x[ind + k - 1] - x[ind]);
            //return ((par - x[ind]) * RecurMetod(ind, k - 1, par)) / (x[ind + k - 1] - x[ind]) + ((x[ind + k] - par) * RecurMetod(ind + 1, k - 1, par)) / (x[ind + k] - x[ind + 1]);

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.TranslateTransform(25, 25);
            for (int i = 0; i < 7; i++)
                g.DrawEllipse((new Pen(Color.Black)), Bxy[i, 0], Bxy[i, 1], 6, 6);

            float N, x, y;
            for (float p = 2; p <= 7; p = p + 0.01f)
            {
                x = 0; y = 0;
                for (int i = 0; i < 7; i++)
                {
                    N = RecurMetod(i, 6, p);
                    x = x + Bxy[i, 0] * N;
                    y = y + Bxy[i, 1] * N;
                }
                g.DrawEllipse((new Pen(Color.LimeGreen)), x, y, 2, 2);
            }
            double[] f = new double[4];
            g.TranslateTransform(400, 0);
            //for (float p = 2; p <= 8; p = p + 0.01f)
            //{
            //    x = 0; y = 0;
            //    f[0] = (2 * (p / 8) * (p / 8) * (p / 8) - 3 * (p / 8) * (p / 8) + 1);
            //    f[1] = -2 * (p / 8) * (p / 8) * (p / 8) + 3 * (p / 8) * (p / 8);
            //    f[2] = (p / 8) * ((p / 8) * (p / 8) - 2 * (p / 8) + 1) * 8;
            //    f[3] = (p / 8) * ((p / 8) * (p / 8) - (p / 8)) * 8;
            //    for (int i = 0; i < 4; i++)
            //    {
            //        N = RecurMetod(i, 3, p);
            //        x = x + Bxy[i, 0] * N*(float)f[i];
            //        y = y + Bxy[i, 1] * N*(float)f[i];
            //    }
            //    g.DrawEllipse((new Pen(Color.Red)), x, y, 2, 2);
            //}
            for (int i = 0; i < 7; i++)
            {
                for (float t = 2; t < 7; t += 0.01f)
                {
                    g.DrawEllipse(new Pen(Color.GreenYellow), t * 100 * (-1) + 300, (RecurMetod(i, 6, t) * -100) + 300, 2, 2);
                }
            }
        }
    }
}
