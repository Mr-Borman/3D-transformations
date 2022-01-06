using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Лб5
{
    public partial class Form1 : Form
    {
        private int x, y;
        private float[,] F = new float[5,4];
        private float[,] a = new float[4, 4];
        private int i = 0;
        float[] w = new float[4];       
        public Form1()
        {
            InitializeComponent();
            this.ResizeRedraw = true;
        }

        private bool algorithmRoberts(int v1, int v2, int v3)
        {            
            float[,] Vec = new float[2, 3];
            float A, B, C, D, m;
            float[] P = new float[3] { 1, 1, 1};

            for (int i = 0; i < F.GetLength(1); i++)
            {
                w[i] = 0;
                for(int j = 0; j < F.GetLength(0); j++)
                {
                    w[i] += F[j, i];
                }
                w[i] /= 5;
            }
         
                            
            for (int i = 0; i< 3; i++)
            {
                Vec[0, i] = F[v1, i] - F[v2, i];
                Vec[1, i] = F[v3, i] - F[v2, i];
            }
            A = Vec[0, 1] * Vec[1, 2] - Vec[1, 1] * Vec[0, 2];
            B = Vec[0, 2] * Vec[1, 0] - Vec[1, 2] * Vec[0, 0];
            C = Vec[0, 0] * Vec[1, 1] - Vec[1, 0] * Vec[0, 1];
            D = -(A* F[v1,0] + B* F[v1, 1] + C* F[v1, 2]);
            m = -Math.Sign(A * w[0] + B * w[1] + C * w[2]);
            
            A *= m;
            B *= m;
            C *= m;
            
            
            
            
            if ((A * P[0] + B * P[1] + C * P[2] + D) > 0)
            {
                return true;
            } else
            {
                return false;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {           
            if(i == 0)
            {
                getRotation('X');
                rotation();           
                getRotation('X');
                rotation();
                getRotation('X');
                rotation();               
                getRotation('Y');
                rotation();
                getRotation('Y');
                rotation();
                i++;
            }                   
            x = ClientSize.Width/2;
            y = ClientSize.Height/2;
            Graphics g = e.Graphics;
            Pen B = new Pen(Color.DeepSkyBlue);
            Pen Bl = new Pen(Color.Black);

            SolidBrush G = new SolidBrush(Color.Green);            
            SolidBrush Blu = new SolidBrush(Color.DeepSkyBlue);
            SolidBrush Br = new SolidBrush(Color.Brown);
            SolidBrush Y = new SolidBrush(Color.Yellow);
            SolidBrush R = new SolidBrush(Color.Red);

            g.DrawLine(B, x, 0, x, 2*y);
            g.DrawLine(B, 0, y, 2*x, y);
            g.DrawLine(B, 2*x, 0, 0, 2 * y);

            Point[] point =
            {
                new Point((int)(x + F[0, 0]), (int)(y - F[0, 1])),
                new Point((int)(x + F[1, 0]), (int)(y - F[1, 1])),
                new Point((int)(x + F[2, 0]), (int)(y - F[2, 1])),
                new Point((int)(x + F[3, 0]), (int)(y - F[3, 1]))
            };
            Point[] point1 =
            {
                new Point((int)(x + F[0, 0]), (int)(y - F[0, 1])),
                new Point((int)(x + F[1, 0]), (int)(y - F[1, 1])),
                new Point((int)(x + F[4, 0]), (int)(y - F[4, 1]))                
            };
            Point[] point2 =
            {
                new Point((int)(x + F[0, 0]), (int)(y - F[0, 1])),
                new Point((int)(x + F[3, 0]), (int)(y - F[3, 1])),
                new Point((int)(x + F[4, 0]), (int)(y - F[4, 1]))
            };
            Point[] point3 =
            {
                new Point((int)(x + F[2, 0]), (int)(y - F[2, 1])),
                new Point((int)(x + F[3, 0]), (int)(y - F[3, 1])),
                new Point((int)(x + F[4, 0]), (int)(y - F[4, 1]))
            };           
            Point[] point5 =
            {
                new Point((int)(x + F[1, 0]), (int)(y - F[1, 1])),
                new Point((int)(x + F[2, 0]), (int)(y - F[2, 1])),
                new Point((int)(x + F[4, 0]), (int)(y - F[4, 1]))
            };

            
            //g.FillPolygon(Br, point);
                       
            g.DrawLine(Bl, (int)(x + F[2, 0]), (int)(y - F[2, 1]), (int)(x + F[3, 0]), (int)(y - F[3, 1]));                                    
            g.DrawLine(Bl, (int)(x + F[3, 0]), (int)(y - F[3, 1]), (int)(x + F[0, 0]), (int)(y - F[0, 1]));

                       

            //g.FillPolygon(Blu, point1);
            g.DrawLine(Bl, (int)(x + F[0, 0]), (int)(y - F[0, 1]), (int)(x + F[4, 0]), (int)(y - F[4, 1]));
            g.DrawLine(Bl, (int)(x + F[4, 0]), (int)(y - F[4, 1]), (int)(x + F[1, 0]), (int)(y - F[1, 1]));
            
            
           
            //g.FillPolygon(G, point3);
            g.DrawLine(Bl, (int)(x + F[2, 0]), (int)(y - F[2, 1]), (int)(x + F[4, 0]), (int)(y - F[4, 1]));
            g.DrawLine(Bl, (int)(x + F[4, 0]), (int)(y - F[4, 1]), (int)(x + F[3, 0]), (int)(y - F[3, 1]));
            
            
            
            
            //g.FillPolygon(Y, point5);
            g.DrawLine(Bl, (int)(x + F[1, 0]), (int)(y - F[1, 1]), (int)(x + F[4, 0]), (int)(y - F[4, 1]));
            g.DrawLine(Bl, (int)(x + F[4, 0]), (int)(y - F[4, 1]), (int)(x + F[2, 0]), (int)(y - F[2, 1]));
            
           
            //g.FillPolygon(R, point2);
            g.DrawLine(Bl, (int)(x + F[0, 0]), (int)(y - F[0, 1]), (int)(x + F[4, 0]), (int)(y - F[4, 1]));
            g.DrawLine(Bl, (int)(x + F[4, 0]), (int)(y - F[4, 1]), (int)(x + F[3, 0]), (int)(y - F[3, 1]));

            

            
           //g.FillPolygon(Br, point);
           g.DrawLine(Bl, (int)(x + F[0, 0]), (int)(y - F[0, 1]), (int)(x + F[1, 0]), (int)(y - F[1, 1]));
           g.DrawLine(Bl, (int)(x + F[1, 0]), (int)(y - F[1, 1]), (int)(x + F[2, 0]), (int)(y - F[2, 1]));
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            point();
        }

        private void point()
        {
            F[0, 0] = 0;
            F[0, 1] = 0;
            F[0, 2] = 0;
            F[0, 3] = 1;

            F[1, 0] = 0;
            F[1, 1] = 0;
            F[1, 2] = 50;
            F[1, 3] = 1;

            F[2, 0] = 50;
            F[2, 1] = 0;
            F[2, 2] = 50;
            F[2, 3] = 1;

            F[3, 0] = 50;
            F[3, 1] = 0;
            F[3, 2] = 0;
            F[3, 3] = 1;

            F[4, 0] = 25;
            F[4, 1] = 60;
            F[4, 2] = 50;
            F[4, 3] = 1;



            a[0, 0] = 1;
            a[0, 1] = 0;
            a[0, 2] = 0;
            a[0, 3] = 0;

            a[1, 0] = 0;
            a[1, 1] = 1;
            a[1, 2] = 0;
            a[1, 3] = 0;

            a[2, 0] = 0;
            a[2, 1] = 0;
            a[2, 2] = 1;
            a[2, 3] = 0;

            a[3, 0] = 0;
            a[3, 1] = 0;
            a[3, 2] = 0;
            a[3, 3] = 1;

        }
        private void getMoving(char direction, char type)
        {
            switch (direction)
            {
                case 'X':
                    if (type == '+')
                    {
                        a[0, 0] = 1;
                        a[0, 1] = 0;
                        a[0, 2] = 0;
                        a[0, 3] = 0;

                        a[1, 0] = 0;
                        a[1, 1] = 1;
                        a[1, 2] = 0;
                        a[1, 3] = 0;

                        a[2, 0] = 0;
                        a[2, 1] = 0;
                        a[2, 2] = 1;
                        a[2, 3] = 0;

                        a[3, 0] = 5;
                        a[3, 1] = 0;
                        a[3, 2] = 0;
                        a[3, 3] = 1;
                    }
                    else if (type == '-')
                    {
                        a[0, 0] = 1;
                        a[0, 1] = 0;
                        a[0, 2] = 0;
                        a[0, 3] = 0;

                        a[1, 0] = 0;
                        a[1, 1] = 1;
                        a[1, 2] = 0;
                        a[1, 3] = 0;

                        a[2, 0] = 0;
                        a[2, 1] = 0;
                        a[2, 2] = 1;
                        a[2, 3] = 0;

                        a[3, 0] = -5;
                        a[3, 1] = 0;
                        a[3, 2] = 0;
                        a[3, 3] = 1;
                    }
                    break;
                case 'Y':
                    if (type == '+')
                    {
                        a[0, 0] = 1;
                        a[0, 1] = 0;
                        a[0, 2] = 0;
                        a[0, 3] = 0;

                        a[1, 0] = 0;
                        a[1, 1] = 1;
                        a[1, 2] = 0;
                        a[1, 3] = 0;

                        a[2, 0] = 0;
                        a[2, 1] = 0;
                        a[2, 2] = 1;
                        a[2, 3] = 0;

                        a[3, 0] = 0;
                        a[3, 1] = 5;
                        a[3, 2] = 0;
                        a[3, 3] = 1;
                    }
                    else if (type == '-')
                    {
                        a[0, 0] = 1;
                        a[0, 1] = 0;
                        a[0, 2] = 0;
                        a[0, 3] = 0;

                        a[1, 0] = 0;
                        a[1, 1] = 1;
                        a[1, 2] = 0;
                        a[1, 3] = 0;

                        a[2, 0] = 0;
                        a[2, 1] = 0;
                        a[2, 2] = 1;
                        a[2, 3] = 0;

                        a[3, 0] = 0;
                        a[3, 1] = -5;
                        a[3, 2] = 0;
                        a[3, 3] = 1;
                    }
                    break;
                case 'Z':
                    if (type == '+')
                    {
                        a[0, 0] = 1;
                        a[0, 1] = 0;
                        a[0, 2] = 0;
                        a[0, 3] = 0;

                        a[1, 0] = 0;
                        a[1, 1] = 1;
                        a[1, 2] = 0;
                        a[1, 3] = 0;

                        a[2, 0] = 0;
                        a[2, 1] = 0;
                        a[2, 2] = 1;
                        a[2, 3] = 0;

                        a[3, 0] = 3;
                        a[3, 1] = 2;
                        a[3, 2] = 5;
                        a[3, 3] = 1;
                    }
                    else if (type == '-')
                    {
                        a[0, 0] = 1;
                        a[0, 1] = 0;
                        a[0, 2] = 0;
                        a[0, 3] = 0;

                        a[1, 0] = 0;
                        a[1, 1] = 1;
                        a[1, 2] = 0;
                        a[1, 3] = 0;

                        a[2, 0] = 0;
                        a[2, 1] = 0;
                        a[2, 2] = 1;
                        a[2, 3] = 0;

                        a[3, 0] = -3;
                        a[3, 1] = -2;
                        a[3, 2] = -5;
                        a[3, 3] = 1;
                    }
                    break;
            }           
        }
        private void moving()
        {
            float[] b = new float[4];
            for (int i = 0; i < 5; i++)
            {
                b[0] = F[i, 0];
                b[1] = F[i, 1];
                b[2] = F[i, 2];
                b[3] = F[i, 3];
                for (int j = 0; j < 4; j++)
                {
                    F[i, j] = b[0] * a[0, j] + b[1] * a[1, j] + b[2] * a[2, j] + b[3] * a[3, j];
                }

            }
            for (int i = 0; i < 5; i++)
            {
                F[i, 0] = F[i, 0] / F[i, 3];
                F[i, 1] = F[i, 1] / F[i, 3];
                F[i, 2] = F[i, 2] / F[i, 3];
                F[i, 3] = 1;
            }
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            getMoving('Z', '-');
            moving();
            Refresh();
        }
        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            getMoving('Z', '+');
            moving();
            Refresh();
        }
        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            getMoving('X', '-');
            moving();
            Refresh();
        }
        private void pictureBox4_MouseDown(object sender, MouseEventArgs e)
        {
            getMoving('X', '+');
            moving();
            Refresh();
        }
        private void pictureBox5_MouseDown(object sender, MouseEventArgs e)
        {
            getMoving('Y', '+');
            moving();
            Refresh();
        }
        private void pictureBox6_MouseDown(object sender, MouseEventArgs e)
        {
            getMoving('Y', '-');
            moving();
            Refresh();
        }
        private void getRotation(char type)
        {
            switch(type)
            {
                case 'X':
                    float fi = 0;
                    fi += 10;
                    float firad = (float)(fi * Math.PI / 180);

                    a[0, 0] = 1;
                    a[0, 1] = 0;
                    a[0, 2] = 0;
                    a[0, 3] = 0;

                    a[1, 0] = 0;
                    a[1, 1] = (float)Math.Cos(firad);
                    a[1, 2] = -(float)Math.Sin(firad);
                    a[1, 3] = 0;

                    a[2, 0] = 0;
                    a[2, 1] = (float)Math.Sin(firad);
                    a[2, 2] = (float)Math.Cos(firad);
                    a[2, 3] = 0;

                    a[3, 0] = 0;
                    a[3, 1] = 0;
                    a[3, 2] = 0;
                    a[3, 3] = 1;
                    break;
                case 'Y':
                    float alpha = 0;
                    alpha += 10;
                    float alpharad = (float)(alpha * Math.PI / 180);

                    a[0, 0] = (float)Math.Cos(alpharad);
                    a[0, 1] = 0;
                    a[0, 2] = (float)Math.Sin(alpharad);
                    a[0, 3] = 0;

                    a[1, 0] = 0;
                    a[1, 1] = 1;
                    a[1, 2] = 0;
                    a[1, 3] = 0;

                    a[2, 0] = -(float)Math.Sin(alpharad);
                    a[2, 1] = 0;
                    a[2, 2] = (float)Math.Cos(alpharad);
                    a[2, 3] = 0;

                    a[3, 0] = 0;
                    a[3, 1] = 0;
                    a[3, 2] = 0;
                    a[3, 3] = 1;
                    break;
                case 'Z':
                    float beta = 0;
                    beta += 10;
                    float betarad = (float)(beta * Math.PI / 180);

                    a[0, 0] = (float)Math.Cos(betarad);
                    a[0, 1] = -(float)Math.Sin(betarad);
                    a[0, 2] = 0;
                    a[0, 3] = 0;

                    a[1, 0] = (float)Math.Sin(betarad);
                    a[1, 1] = (float)Math.Cos(betarad);
                    a[1, 2] = 0;
                    a[1, 3] = 0;

                    a[2, 0] = 0;
                    a[2, 1] = 0;
                    a[2, 2] = 1;
                    a[2, 3] = 0;

                    a[3, 0] = 0;
                    a[3, 1] = 0;
                    a[3, 2] = 0;
                    a[3, 3] = 1;
                    break;
            }
            
        }

        private void pictureBox8_MouseDown(object sender, MouseEventArgs e)
        {
            getRotation('X');
            rotation();
            Refresh();
        }

        private void pictureBox9_MouseDown(object sender, MouseEventArgs e)
        {
            getRotation('Y');
            rotation();
            Refresh();
        }

        private void pictureBox10_MouseDown(object sender, MouseEventArgs e)
        {
            getRotation('Z');
            rotation();
            Refresh();
        }

        private void pictureBox7_MouseDown(object sender, MouseEventArgs e)
        {
            i = 0;
            point();
            Refresh();
        }

        private void getScale()
        {
            float[] b = new float[4];
            for (int i = 0; i < 5; i++)
            {
                b[0] = F[i, 0];
                b[1] = F[i, 1];
                b[2] = F[i, 2];
                b[3] = F[i, 3];
                for (int j = 0; j < 4; j++)
                {
                    F[i, j] = b[0] * a[0, j] + b[1] * a[1, j] + b[2] * a[2, j] + b[3] * a[3, j];
                }
            }

            for (int i = 0; i < 5; i++)
            {
                F[i, 0] = F[i, 0] / F[i, 3];
                F[i, 1] = F[i, 1] / F[i, 3];
                F[i, 2] = F[i, 2] / F[i, 3];
                F[i, 3] = 1;
            }
        }
        private void scale(char type)
        {
            if(type == '+')
            {
                a[0, 0] = 1;
                a[0, 1] = 0;
                a[0, 2] = 0;
                a[0, 3] = 0;

                a[1, 0] = 0;
                a[1, 1] = 1;
                a[1, 2] = 0;
                a[1, 3] = 0;

                a[2, 0] = 0;
                a[2, 1] = 0;
                a[2, 2] = 1;
                a[2, 3] = 0;

                a[3, 0] = 0;
                a[3, 1] = 0;
                a[3, 2] = 0;
                a[3, 3] = (float)0.5;

            } else if (type == '-')
            {
                a[0, 0] = 1;
                a[0, 1] = 0;
                a[0, 2] = 0;
                a[0, 3] = 0;

                a[1, 0] = 0;
                a[1, 1] = 1;
                a[1, 2] = 0;
                a[1, 3] = 0;

                a[2, 0] = 0;
                a[2, 1] = 0;
                a[2, 2] = 1;
                a[2, 3] = 0;

                a[3, 0] = 0;
                a[3, 1] = 0;
                a[3, 2] = 0;
                a[3, 3] = 2;

            }
        }

        private void pictureBox12_MouseDown(object sender, MouseEventArgs e)
        {
            scale('+');
            getScale();
            Refresh();
        }

        private void pictureBox11_MouseDown(object sender, MouseEventArgs e)
        {
            scale('-');
            getScale();
            Refresh();
        }

        private void perspective(int type)
        {
            switch (type)
            {
                case 1: //одноточечная проекция
                    float k = 10;
                    float r = 1 / k;
                    a[0, 0] = 1;
                    a[0, 1] = 0;
                    a[0, 2] = 0;
                    a[0, 3] = 0;

                    a[1, 0] = 0;
                    a[1, 1] = 1;
                    a[1, 2] = 0;
                    a[1, 3] = 0;

                    a[2, 0] = 0;
                    a[2, 1] = 0;
                    a[2, 2] = 0;
                    a[2, 3] = r;

                    a[3, 0] = 0;
                    a[3, 1] = 0;
                    a[3, 2] = 0;
                    a[3, 3] = 1;
                    break;
                case 2: //Косоугольная
                    float l = 1;
                    float alpha = (float)45;                    
                    float alpharad = (float)(alpha * Math.PI/180);
                    a[0, 0] = 1;
                    a[0, 1] = 0;
                    a[0, 2] = 0;
                    a[0, 3] = 0;

                    a[1, 0] = 0;
                    a[1, 1] = 1;
                    a[1, 2] = 0;
                    a[1, 3] = 0;

                    a[2, 0] = (float)(l * Math.Cos(alpharad));
                    a[2, 1] = (float)(l * Math.Sin(alpharad));
                    a[2, 2] = 0;
                    a[2, 3] = 0;

                    a[3, 0] = 0;
                    a[3, 1] = 0;
                    a[3, 2] = 0;
                    a[3, 3] = 1;
                    break;
                case 3: //Вид спереди
                    a[0, 0] = 1;
                    a[0, 1] = 0;
                    a[0, 2] = 0;
                    a[0, 3] = 0;

                    a[1, 0] = 0;
                    a[1, 1] = 1;
                    a[1, 2] = 0;
                    a[1, 3] = 0;

                    a[2, 0] = 0;
                    a[2, 1] = 0;
                    a[2, 2] = 0;
                    a[2, 3] = 0;

                    a[3, 0] = 0;
                    a[3, 1] = 0;
                    a[3, 2] = 0;
                    a[3, 3] = 1;
                    break;
            }
            
        }

        private void getPerspective()
        {
            float[] b = new float[4];
            for (int i = 0; i < 5; i++)
            {
                b[0] = F[i, 0];
                b[1] = F[i, 1];
                b[2] = F[i, 2];
                b[3] = F[i, 3];
                for (int j = 0; j < 4; j++)
                {
                    F[i, j] = b[0] * a[0, j] + b[1] * a[1, j] + b[2] * a[2, j] + b[3] * a[3, j];
                }
            }

            for (int i = 0; i < 5; i++)
            {
                F[i, 0] = F[i, 0] / F[i, 3];
                F[i, 1] = F[i, 1] / F[i, 3];
                F[i, 2] = F[i, 2] / F[i, 3];
                F[i, 3] = 1;
            }
        }

        private void pictureBox14_MouseDown(object sender, MouseEventArgs e)
        {
            perspective(1);
            getPerspective();
            Refresh();
        }

        private void pictureBox15_MouseDown(object sender, MouseEventArgs e)
        {
            perspective(2);
            getPerspective();
            Refresh();
        }

        private void pictureBox16_MouseDown(object sender, MouseEventArgs e)
        {
            perspective(3);
            getPerspective();
            Refresh();
        }

        private void rotation()
        {
            float[] b = new float[4];
            for (int i = 0; i < 5; i++)
            {
                b[0] = F[i, 0];
                b[1] = F[i, 1];
                b[2] = F[i, 2];
                b[3] = F[i, 3];
                for (int j = 0; j < 4; j++)
                {
                    F[i, j] = b[0] * a[0, j] + b[1] * a[1, j] + b[2] * a[2, j] + b[3] * a[3, j];
                }               
            }
            
            for (int i = 0; i < 5; i++)
            {
                F[i, 0] = F[i, 0] / F[i, 3];
                F[i, 1] = F[i, 1] / F[i, 3];
                F[i, 2] = F[i, 2] / F[i, 3];
                F[i, 3] = 1;
            }                        
        }
    }
}
