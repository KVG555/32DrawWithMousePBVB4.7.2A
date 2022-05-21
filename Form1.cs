using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.Windows.Forms;

namespace Draw
{
    public partial class Form1 : Form
    {

        private Random Random = new Random();

        private Bitmap ContrastBtmp;


        private Bitmap m_Bm;


        private readonly Pen pen1 = new Pen(Color.Black);

      //  private readonly Pen pen2 = new Pen(Color.Black);

        private readonly Pen pen3 = new Pen(Color.Black);



        double s; //step of changing of the opacity

        // The Graphics object on which we are drawing.
        private Graphics graphics;


        // True when we are drawing.
        private bool isDrawing = false;




        // The last point we drew.
        private Point lastPoint;

        private int n3 = 0;

        // for draw items

        public int x_MD_1, y_MD_1;

        public int xMD_1, yMD_1;

        PointF MD_1_, MD_2_, MD_3_, MD_4_, MD_5_, MD_6_, MD_7_, MD_8_, MD_9_, MD_10_;

        private readonly PointF[] m_Points3 = new PointF[10];




        PointF MD_1, MD_2, MD_3, MD_4, MD_5, MD_6, MD_7;

        private readonly PointF[] m_Points1 = new PointF[7];



        PointF _MD_1, _MD_2, _MD_3, _MD_4;

        private readonly PointF[] m_Points = new PointF[4];


        PointF _MD_1_, _MD_2_, _MD_3_;

        private readonly PointF[] m_Points4 = new PointF[3];


        private int NextPoint = 0;



        //DashCap lines
        public LineCap StartCap { get; private set; }
        public LineCap EndCap { get; private set; }

        public DashCap DashCap { get; private set; }
        public DashStyle DashStyle { get; private set; }

        public float a, b, x_min, x_max;

        //eversome function for graph
        float Function_of_graph(float x)
        {
            float Function;

            Function = a * x + b;
            return Function;
        }



        //Step of graph:
        public int Npoints = 100;



        //x,y places of system
        public float O_x_pix;
        public float O_y_pix;


        // variables for scale of the system: width, height of squares
        public float M_x;

        public float M_y;




        // for open file 
        //   Image bmp;
        //  private int y;

        public Form1()
        {
            InitializeComponent();

       
        }
//For Form1 Load
        #region
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {

           


                radioButton1.Checked = true;



                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
                radioButton5.Checked = false;
                radioButton6.Checked = false;
                radioButton7.Checked = false;
                radioButton8.Checked = false;
                radioButton9.Checked = false;
                radioButton10.Checked = false;
                radioButton11.Checked = false;
                radioButton12.Checked = false;
                radioButton13.Checked = false;
                radioButton14.Checked = false;
                radioButton15.Checked = false;
                radioButton16.Checked = false;
                radioButton17.Checked = false;
                radioButton18.Checked = false;
                radioButton19.Checked = false;
                radioButton20.Checked = false;
                radioButton21.Checked = false;
                radioButton22.Checked = false;
                radioButton25.Checked = false;
                radioButton27.Checked = false;
                s = 0.1;


                StartNewDrawing();


                var LineCapItems = new List<LineCap> { LineCap.Flat, LineCap.Square, LineCap.Round, LineCap.Triangle, LineCap.NoAnchor, LineCap.NoAnchor, LineCap.RoundAnchor, LineCap.DiamondAnchor, LineCap.ArrowAnchor, LineCap.AnchorMask, LineCap.Custom };

                foreach (LineCap element in LineCapItems)
                {

                    comboBox26.Items.Add(element);

                }

                comboBox26.SelectedItem = LineCap.Flat;

                var LineCapItems1 = new List<LineCap> { LineCap.Flat, LineCap.Square, LineCap.Round, LineCap.Triangle, LineCap.NoAnchor, LineCap.NoAnchor, LineCap.RoundAnchor, LineCap.DiamondAnchor, LineCap.ArrowAnchor, LineCap.AnchorMask, LineCap.Custom };


                foreach (LineCap element in LineCapItems1)
                {

                    comboBox27.Items.Add(element);

                }

                comboBox27.SelectedItem = LineCap.Flat;


                var LineCapItems2 = new List<DashCap> { DashCap.Flat, DashCap.Round, DashCap.Triangle };

                foreach (DashCap element in LineCapItems2)
                {

                    comboBox28.Items.Add(element);

                }

                comboBox28.SelectedItem = DashCap.Flat;


                var LineCapItems3 = new List<DashStyle> { DashStyle.Solid, DashStyle.Dash, DashStyle.Dot, DashStyle.DashDot, DashStyle.DashDotDot, DashStyle.Custom };

                foreach (DashStyle element in LineCapItems3)
                {

                    comboBox29.Items.Add(element);

                }

                comboBox29.SelectedItem = DashStyle.Dash;

//cokor/width window

                for (int i1 = 0; i1 <= 50; i1++)

                {

                    comboBox31.Items.Add(i1);
                }

                comboBox31.SelectedItem = 10;





                int n = 0;

            
                do
                {

                    toolStripComboBox2.Items.Add(Color.FromKnownColor((KnownColor)n));

                    n++;


                } while (n <= 167);


                toolStripComboBox2.SelectedItem = Color.Green;


                int n1 = 0;

                do
                {

                    toolStripComboBox5.Items.Add(Color.FromKnownColor((KnownColor)n1));

                    n1++;


                } while (n1 <= 167);


                toolStripComboBox5.SelectedItem = Color.Navy;



                int n109 = 0;

                do
                {

                    comboBox30.Items.Add(Color.FromKnownColor((KnownColor)n109));

                    n109++;


                } while (n109 <= 167);


                comboBox30.SelectedItem = Color.Black;

                int n111 = 0;

                do
                {

                    comboBox32.Items.Add(Color.FromKnownColor((KnownColor)n111));

                    n111++;


                } while (n111 <= 167);


                comboBox32.SelectedItem = Color.Black;


                int n115 = 0;

                do
                {

                    comboBox33.Items.Add(Color.FromKnownColor((KnownColor)n115));

                    n115++;


                } while (n115 <= 167);


                comboBox33.SelectedItem = Color.Navy;



                do
                {

                    comboBox1.Items.Add(Color.FromKnownColor((KnownColor)n3));

                    n3++;


                } while (n3 <= 167);


                comboBox1.SelectedItem = Color.Red;


                int n4 = 0;

                do
                {

                    comboBox2.Items.Add(Color.FromKnownColor((KnownColor)n4));

                    n4++;


                } while (n4 <= 167);


                comboBox2.SelectedItem = Color.LavenderBlush;

                int n5 = 0;

                do
                {

                    comboBox3.Items.Add(Color.FromKnownColor((KnownColor)n5));

                    n5++;


                } while (n5 <= 167);

                comboBox3.SelectedItem = Color.Transparent;

                int n6 = 0;
                do
                {

                    comboBox4.Items.Add(Color.FromKnownColor((KnownColor)n6));

                    n6++;


                } while (n6 <= 167);


                comboBox4.SelectedItem = Color.DarkOliveGreen;

                int n7 = 0;
                do
                {

                    comboBox5.Items.Add(Color.FromKnownColor((KnownColor)n7));

                    n7++;


                } while (n7 <= 167);


                comboBox5.SelectedItem = Color.DarkCyan;

               
                int n8 = 0;

                do
                {

                    comboBox6.Items.Add(Color.FromKnownColor((KnownColor)n8));

                    n8++;


                } while (n8 <= 167);


                comboBox6.SelectedItem = Color.ForestGreen;

                int n9 = 0;
                do
                {

                    comboBox7.Items.Add(Color.FromKnownColor((KnownColor)n9));

                    n9++;


                } while (n9 <= 167);


                comboBox7.SelectedItem = Color.Aqua;

                int n10 = 0;

                do
                {

                    comboBox8.Items.Add(Color.FromKnownColor((KnownColor)n10));

                    n10++;


                } while (n10 <= 167);


                comboBox8.SelectedItem = Color.Bisque;

                int n11 = 0;

                do
                {

                    comboBox9.Items.Add(Color.FromKnownColor((KnownColor)n11));

                    n11++;


                } while (n11 <= 167);


                comboBox9.SelectedItem = Color.Lime;


                int n12 = 0;

                do
                {

                    comboBox10.Items.Add(Color.FromKnownColor((KnownColor)n12));

                    n12++;


                } while (n12 <= 167);


                comboBox10.SelectedItem = Color.Blue;


                n12 = 0;

                do
                {

                    comboBox11.Items.Add(Color.FromKnownColor((KnownColor)n12));

                    n12++;


                } while (n12 <= 167);


                comboBox11.SelectedItem = Color.Aqua;


                n12 = 0;
                ///////////////////

                do
                {

                    comboBox12.Items.Add(Color.FromKnownColor((KnownColor)n12));

                    n12++;


                } while (n12 <= 167);


                comboBox12.SelectedItem = Color.OldLace;



                n12 = 0;

                do
                {

                    comboBox13.Items.Add(Color.FromKnownColor((KnownColor)n12));

                    n12++;


                } while (n12 <= 167);


                comboBox13.SelectedItem = Color.Navy;



                n12 = 0;

                do
                {

                    comboBox15.Items.Add(Color.FromKnownColor((KnownColor)n12));

                    n12++;


                } while (n12 <= 167);


                comboBox15.SelectedItem = Color.Cyan;

                //888888888888888888888888888888888888888888888888888888888

                n1 = 0;

                do
                {

                    comboBox14.Items.Add(Color.FromKnownColor((KnownColor)n1));

                    n1++;


                } while (n1 <= 167);


                comboBox14.SelectedItem = Color.Fuchsia;
                n1 = 0;

                do
                {

                    comboBox16.Items.Add(Color.FromKnownColor((KnownColor)n1));

                    n1++;


                } while (n1 <= 167);


                comboBox16.SelectedItem = Color.Navy;


                n1 = 0;

                do
                {

                    comboBox17.Items.Add(Color.FromKnownColor((KnownColor)n1));

                    n1++;


                } while (n1 <= 167);


                comboBox17.SelectedItem = Color.Green;


                n1 = 0;

                do
                {

                    comboBox18.Items.Add(Color.FromKnownColor((KnownColor)n1));

                    n1++;


                } while (n1 <= 167);


                comboBox18.SelectedItem = Color.Red;

                n1 = 0;

                do
                {

                    comboBox19.Items.Add(Color.FromKnownColor((KnownColor)n1));

                    n1++;


                } while (n1 <= 167);


                comboBox19.SelectedItem = Color.Gold;

                n1 = 0;

                do
                {

                    comboBox20.Items.Add(Color.FromKnownColor((KnownColor)n1));

                    n1++;


                } while (n1 <= 167);


                comboBox20.SelectedItem = Color.Crimson;


                n1 = 0;

                do
                {

                    comboBox21.Items.Add(Color.FromKnownColor((KnownColor)n1));

                    n1++;


                } while (n1 <= 167);


                comboBox21.SelectedItem = Color.Lime;


                n1 = 0;

                do
                {

                    comboBox22.Items.Add(Color.FromKnownColor((KnownColor)n1));

                    n1++;


                } while (n1 <= 167);


                comboBox22.SelectedItem = Color.DarkGreen;

                n1 = 0;

                do
                {

                    comboBox23.Items.Add(Color.FromKnownColor((KnownColor)n1));

                    n1++;


                } while (n1 <= 167);


                comboBox23.SelectedItem = Color.Cyan;

                n1 = 0;

                do
                {

                    comboBox24.Items.Add(Color.FromKnownColor((KnownColor)n1));

                    n1++;


                } while (n1 <= 167);


                comboBox24.SelectedItem = Color.Coral;


                n1 = 0;


                do
                {

                    comboBox25.Items.Add(Color.FromKnownColor((KnownColor)n1));

                    n1++;


                } while (n1 <= 167);


                comboBox25.SelectedItem = Color.Blue;
                ////////////////
                ///

                comboBox34.SelectedItem = "Times New Roman";

                int i;

                for (i = 0; i < 100; i++)
                {

                    comboBox35.Items.Add(i);
                }

                comboBox35.SelectedItem = 20;


                n1 = 0;

                do
                {

                    comboBox36.Items.Add(Color.FromKnownColor((KnownColor)n1));

                    n1++;


                } while (n1 <= 167);


                comboBox36.SelectedItem = Color.Black;



            }
            catch (Exception Исключение)
            {
                // Отчет о других ошибках:
                MessageBox.Show(Исключение.Message, "ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        #endregion

        //Object of drawing (canvas)
        #region
        private void StartNewDrawing()
        {
            // Make a new Bitmap;
            Bitmap bm = new Bitmap(pictureBox1.ClientRectangle.Width, pictureBox1.ClientRectangle.Height);

            // Make an associated Graphics object.
            graphics = Graphics.FromImage(bm);

            // Clear the new Bitmap.
            graphics.Clear(BackColor);

            // Display the new bitmap in the PictureBox.
            pictureBox1.Image = bm;

            // Refresh.
            pictureBox1.Refresh();
        }

     
        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                StartNewDrawing();
            }
            catch (Exception Исключение)
            {
                // Отчет о других ошибках:
                MessageBox.Show(Исключение.Message, "ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

      

  //      private void PictureBox1_Paint_1(object sender, PaintEventArgs e)
  //      {
            //CopyPixels1(e);
  //      }


   //     private void CopyPixels1(PaintEventArgs e)
   //     {
          //  e.Graphics.CopyFromScreen(this.Location,
            //    new Point(40, 40), new Size(100, 100));
   //     }


        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (radioButton2.Checked)
                    {

                        isDrawing = true;

                        // Save the current point.
                        lastPoint = e.Location;
                    }

                    if (radioButton3.Checked)
                    {

                        isDrawing = true;

                        x_MD_1 = e.X;

                        y_MD_1 = e.Y;
                    }

                    if (radioButton4.Checked)
                    {
                        isDrawing = true;

                        x_MD_1 = e.X;

                        y_MD_1 = e.Y;
                    }
                    if (radioButton5.Checked)
                    {
                        isDrawing = true;

                        x_MD_1 = e.X;

                        y_MD_1 = e.Y;

                    }
                    if (radioButton6.Checked)
                    {
                        isDrawing = true;

                        x_MD_1 = e.X;

                        y_MD_1 = e.Y;

                    }

                    if (radioButton7.Checked)
                    {

                        isDrawing = true;

                    }

                    if (radioButton8.Checked)
                    {
                        isDrawing = true;
                    }

                    if (radioButton9.Checked)
                    {
                        isDrawing = true;

                        x_MD_1 = e.X;

                        y_MD_1 = e.Y;

                    }
                    if (radioButton10.Checked)
                    {
                        isDrawing = true;

                        x_MD_1 = e.X;

                        y_MD_1 = e.Y;

                    }

                    if (radioButton11.Checked)
                    {
                        isDrawing = true;

                        x_MD_1 = e.X;

                        y_MD_1 = e.Y;
                    }

                    if (radioButton12.Checked)
                    {
                        isDrawing = true;

                        x_MD_1 = e.X;

                        y_MD_1 = e.Y;
                    }

                    if (radioButton13.Checked)
                    {
                        isDrawing = true;

                        x_MD_1 = e.X;

                        y_MD_1 = e.Y;
                    }

                    if (radioButton14.Checked)
                    {
                        isDrawing = true;

                        x_MD_1 = e.X;

                        y_MD_1 = e.Y;
                    }


                    if (radioButton15.Checked)
                    {
                        isDrawing = true;
                        if (isDrawing == true)
                        {
                            if (NextPoint > 3) NextPoint = 0;
                            {

                                // Let's save this point 
                                m_Points[NextPoint].X = e.X;
                                m_Points[NextPoint].Y = e.Y;

                                //Let's move to the next point. 
                                NextPoint++;




                                _MD_1 = m_Points[0];

                                _MD_2 = m_Points[1];

                                _MD_3 = m_Points[2];

                                _MD_4 = m_Points[3];


                                pictureBox1.Invalidate();

                                if (controlPointsToolStripMenuItem.BackColor == Color.Green)
                                {
                                    // Let's draw some control points. 
                                    for (int i = 0; i < NextPoint; i++)
                                    {
                                        using Graphics graphics = Graphics.FromImage(pictureBox1.Image);
                                        graphics.SmoothingMode = SmoothingMode.AntiAlias;
                                        graphics.FillRectangle(Brushes.Transparent,
                                        m_Points[i].X - 1, m_Points[i].Y - 1, 1, 1);
                                        graphics.DrawRectangle(Pens.Black,
                                             m_Points[i].X - 1, m_Points[i].Y - 1, 1, 1);


                                    }

                                }




                            }




                        }

                    }

                    if (radioButton16.Checked)
                    {

                        isDrawing = true;

                        if (isDrawing == true)
                        {

                            if (NextPoint > 6) NextPoint = 0;

                            // Let`s save this point.
                            m_Points1[NextPoint].X = e.X;
                            m_Points1[NextPoint].Y = e.Y;

                            // Let`s move to another point
                            NextPoint++;

                            MD_1 = m_Points1[0];
                            MD_2 = m_Points1[1];
                            MD_3 = m_Points1[2];
                            MD_4 = m_Points1[3];
                            MD_5 = m_Points1[4];
                            MD_6 = m_Points1[5];
                            MD_7 = m_Points1[6];


                            if (controlPointsToolStripMenuItem.BackColor == Color.Green)
                            {
                                // Let's draw some control points. 
                                for (int i = 0; i < NextPoint; i++)
                                {
                                    using Graphics graphics = Graphics.FromImage(pictureBox1.Image);
                                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
                                    graphics.FillRectangle(Brushes.Transparent,
                                    m_Points1[i].X - 1, m_Points1[i].Y - 1, 1, 1);
                                    graphics.DrawRectangle(pen3,
                                         m_Points1[i].X - 1, m_Points1[i].Y - 1, 1, 1);

                                }

                            }


                        }

                        // ReDraw.
                        pictureBox1.Refresh();


                    }

                    if (radioButton17.Checked)
                    {
                        isDrawing = true;

                        if (isDrawing == true)
                        {

                            if (NextPoint > 6) NextPoint = 0;

                            // Let`s save this point.

                            m_Points1[NextPoint].X = e.X;
                            m_Points1[NextPoint].Y = e.Y;

                            // Let`s move to another point
                            NextPoint++;

                            MD_1 = m_Points1[0];
                            MD_2 = m_Points1[1];
                            MD_3 = m_Points1[2];
                            MD_4 = m_Points1[3];
                            MD_5 = m_Points1[4];
                            MD_6 = m_Points1[5];
                            MD_7 = m_Points1[6];


                            if (controlPointsToolStripMenuItem.BackColor == Color.Green)
                            {
                                // Let's draw some control points. 
                                for (int i = 0; i < NextPoint; i++)
                                {
                                    using Graphics graphics = Graphics.FromImage(pictureBox1.Image);
                                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
                                    graphics.FillRectangle(Brushes.Transparent,
                                    m_Points1[i].X - 1, m_Points1[i].Y - 1, 1, 1);
                                    graphics.DrawRectangle(pen3,
                                         m_Points1[i].X - 1, m_Points1[i].Y - 1, 1, 1);

                                }

                            }
                            //ReDraw
                            pictureBox1.Refresh();


                        }



                    }

                    if (radioButton18.Checked)
                    {

                        isDrawing = true;

                        if (isDrawing == true)
                        {

                            if (NextPoint > 6) NextPoint = 0;

                            // Let`s save this point.
                            m_Points1[NextPoint].X = e.X;
                            m_Points1[NextPoint].Y = e.Y;

                            // Let`s move to another point

                            NextPoint++;

                            MD_1 = m_Points1[0];
                            MD_2 = m_Points1[1];
                            MD_3 = m_Points1[2];
                            MD_4 = m_Points1[3];
                            MD_5 = m_Points1[4];
                            MD_6 = m_Points1[5];
                            MD_7 = m_Points1[6];


                            if (controlPointsToolStripMenuItem.BackColor == Color.Green)
                            {
                                // Let's draw some control points. 
                                for (int i = 0; i < NextPoint; i++)
                                {
                                    using Graphics graphics = Graphics.FromImage(pictureBox1.Image);
                                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
                                    graphics.FillRectangle(Brushes.Transparent,
                                    m_Points1[i].X - 1, m_Points1[i].Y - 1, 1, 1);
                                    graphics.DrawRectangle(pen3,
                                         m_Points1[i].X - 1, m_Points1[i].Y - 1, 1, 1);

                                }

                            }
                            // ReDraw
                            pictureBox1.Refresh();


                        }



                    }

                    if (radioButton19.Checked)

                    {

                        isDrawing = true;

                        if (isDrawing == true)
                        {


                            if (NextPoint > 6) NextPoint = 0;

                            // Let's save this point.
                            m_Points1[NextPoint].X = e.X;
                            m_Points1[NextPoint].Y = e.Y;

                            // Let's move to other points.
                            NextPoint++;

                            MD_1 = m_Points1[0];
                            MD_2 = m_Points1[1];
                            MD_3 = m_Points1[2];
                            MD_4 = m_Points1[3];
                            MD_5 = m_Points1[4];
                            MD_6 = m_Points1[5];
                            MD_7 = m_Points1[6];





                            if (controlPointsToolStripMenuItem.BackColor == Color.Green)
                            {
                                // Let's draw some control points. 
                                for (int i = 0; i < NextPoint; i++)
                                {
                                    using Graphics graphics = Graphics.FromImage(pictureBox1.Image);
                                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
                                    graphics.FillRectangle(Brushes.Transparent,
                                    m_Points1[i].X - 1, m_Points1[i].Y - 1, 1, 1);
                                    graphics.DrawRectangle(pen3,
                                         m_Points1[i].X - 1, m_Points1[i].Y - 1, 1, 1);

                                }
                            }

                            // ReDraw.
                            pictureBox1.Refresh();


                        }


                    }

                    if (radioButton20.Checked)
                    {
                        isDrawing = true;

                        if (isDrawing == true)
                        {


                            if (NextPoint > 6) NextPoint = 0;

                            // Let's save this point.
                            m_Points1[NextPoint].X = e.X;
                            m_Points1[NextPoint].Y = e.Y;

                            // Let's move to other points.
                            NextPoint++;

                            MD_1 = m_Points1[0];
                            MD_2 = m_Points1[1];
                            MD_3 = m_Points1[2];
                            MD_4 = m_Points1[3];
                            MD_5 = m_Points1[4];
                            MD_6 = m_Points1[5];
                            MD_7 = m_Points1[6];





                            if (controlPointsToolStripMenuItem.BackColor == Color.Green)
                            {
                                // Let's draw some control points. 
                                for (int i = 0; i < NextPoint; i++)
                                {
                                    using Graphics graphics = Graphics.FromImage(pictureBox1.Image);
                                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
                                    graphics.FillRectangle(Brushes.Transparent,
                                    m_Points1[i].X - 1, m_Points1[i].Y - 1, 1, 1);
                                    graphics.DrawRectangle(pen3,
                                         m_Points1[i].X - 1, m_Points1[i].Y - 1, 1, 1);

                                }
                            }

                            // ReDraw.
                            pictureBox1.Refresh();


                        }


                    }

                    if (radioButton21.Checked)
                    {
                        isDrawing = true;

                        if (isDrawing == true)
                        {


                            if (NextPoint > 3) NextPoint = 0; //6

                            // Let's save this point.
                            m_Points[NextPoint].X = e.X;
                            m_Points[NextPoint].Y = e.Y;

                            // Let's move to other points.
                            NextPoint++;

                            _MD_1 = m_Points[0];
                            _MD_2 = m_Points[1];
                            _MD_3 = m_Points[2];
                            _MD_4 = m_Points[3];






                            if (controlPointsToolStripMenuItem.BackColor == Color.Green)
                            {
                                // Let's draw some control points. 
                                for (int i = 0; i < NextPoint; i++)
                                {
                                    using Graphics graphics = Graphics.FromImage(pictureBox1.Image);
                                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
                                    graphics.FillRectangle(Brushes.Transparent,
                                    m_Points[i].X - 1, m_Points[i].Y - 1, 1, 1);
                                    graphics.DrawRectangle(pen3,
                                         m_Points[i].X - 1, m_Points[i].Y - 1, 1, 1);

                                }
                            }

                            // ReDraw.
                            pictureBox1.Refresh();

                        }


                    }

                    if (radioButton22.Checked)
                    {
                        isDrawing = true;

                        if (isDrawing == true)
                        {
                            if (NextPoint > 3) NextPoint = 0; //6

                            // Let's save this point.
                            m_Points[NextPoint].X = e.X;
                            m_Points[NextPoint].Y = e.Y;

                            // Let's move to other points.
                            NextPoint++;

                            _MD_1 = m_Points[0];
                            _MD_2 = m_Points[1];
                            _MD_3 = m_Points[2];
                            _MD_4 = m_Points[3];






                            if (controlPointsToolStripMenuItem.BackColor == Color.Green)
                            {
                                // Let's draw some control points. 
                                for (int i = 0; i < NextPoint; i++)
                                {
                                    using Graphics graphics = Graphics.FromImage(pictureBox1.Image);
                                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
                                    graphics.FillRectangle(Brushes.Transparent,
                                    m_Points[i].X - 1, m_Points[i].Y - 1, 1, 1);
                                    graphics.DrawRectangle(pen3,
                                         m_Points[i].X - 1, m_Points[i].Y - 1, 1, 1);

                                }
                            }

                            // ReDraw.
                            pictureBox1.Refresh();

                        }

                    }


                    if (radioButton25.Checked)
                    {

                        isDrawing = true;


                        x_MD_1 = e.X;

                        y_MD_1 = e.Y;



                    }

                    if (radioButton27.Checked)
                    {
                        isDrawing = true;

                        if (isDrawing == true)
                        {

                            if (NextPoint > 9) NextPoint = 0;

                            
                            m_Points3[NextPoint].X = e.X;
                            m_Points3[NextPoint].Y = e.Y;

                           
                            NextPoint++;

                            MD_1_ = m_Points3[0];
                            MD_2_ = m_Points3[1];
                            MD_3_ = m_Points3[2];
                            MD_4_ = m_Points3[3];
                            MD_5_ = m_Points3[4];
                            MD_6_ = m_Points3[5];
                            MD_7_ = m_Points3[6];
                            MD_8_ = m_Points3[7];
                            MD_9_ = m_Points3[8];
                            MD_10_ = m_Points3[9];





                            if (controlPointsToolStripMenuItem.BackColor == Color.Green)
                            {
                                // Let's draw some control points. 
                                for (int i = 0; i < NextPoint; i++)
                                {
                                    using Graphics graphics = Graphics.FromImage(pictureBox1.Image);
                                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
                                    graphics.FillRectangle(Brushes.Transparent,
                                    m_Points3[i].X - 1, m_Points3[i].Y - 1, 1, 1);
                                    graphics.DrawRectangle(pen3,
                                         m_Points3[i].X - 1, m_Points3[i].Y - 1, 1, 1);

                                }

                            }

                            pictureBox1.Refresh();

                        }


                    }

                    if (radioButton28.Checked)
                    {

                        isDrawing = true;

                        if (isDrawing == true)
                        {

                            x_MD_1 = e.X;

                            y_MD_1 = e.Y;
                        }



                    }

                    if (radioButton29.Checked)
                    {

                        isDrawing = true;


                        x_MD_1 = e.X;

                        y_MD_1 = e.Y;



                    }

                    if (radioButton30.Checked)
                    {

                        isDrawing = true;


                        x_MD_1 = e.X;

                        y_MD_1 = e.Y;



                    }

                    if (radioButton31.Checked)
                    {
                        isDrawing = true;
                        if (isDrawing == true)
                        {
                            if (NextPoint > 2) NextPoint = 0;
                            {

                                // Let's save this point 
                                m_Points4[NextPoint].X = e.X;
                                m_Points4[NextPoint].Y = e.Y;

                                //Let's move to the next point. 
                                NextPoint++;




                                _MD_1_ = m_Points4[0];

                                _MD_2_ = m_Points4[1];

                                _MD_3_ = m_Points4[2];



                                pictureBox1.Invalidate();




                                //     pictureBox1.Invalidate();

                                if (controlPointsToolStripMenuItem.BackColor == Color.Green)
                                {
                                    // Let's draw some control points. 
                                    for (int i = 0; i < NextPoint; i++)
                                    {
                                        using Graphics graphics = Graphics.FromImage(pictureBox1.Image);
                                        graphics.SmoothingMode = SmoothingMode.AntiAlias;
                                        graphics.FillRectangle(Brushes.Transparent,
                                        m_Points4[i].X - 1, m_Points4[i].Y - 1, 1, 1);
                                        graphics.DrawRectangle(Pens.Black,
                                             m_Points4[i].X - 1, m_Points4[i].Y - 1, 1, 1);


                                    }

                                }




                            }

                            pictureBox1.Refresh();


                        }

                    }


                    if (radioButton32.Checked)
                    {
                        isDrawing = true;
                        if (isDrawing == true)
                        {
                            if (NextPoint > 2) NextPoint = 0;
                            {

                                // Let's save this point 
                                m_Points4[NextPoint].X = e.X;
                                m_Points4[NextPoint].Y = e.Y;

                                //Let's move to the next point. 
                                NextPoint++;




                                _MD_1_ = m_Points4[0];

                                _MD_2_ = m_Points4[1];

                                _MD_3_ = m_Points4[2];



                                pictureBox1.Invalidate();




                                //     pictureBox1.Invalidate();

                                if (controlPointsToolStripMenuItem.BackColor == Color.Green)
                                {
                                    // Let's draw some control points. 
                                    for (int i = 0; i < NextPoint; i++)
                                    {
                                        using Graphics graphics = Graphics.FromImage(pictureBox1.Image);
                                        graphics.SmoothingMode = SmoothingMode.AntiAlias;
                                        graphics.FillRectangle(Brushes.Transparent,
                                        m_Points4[i].X - 1, m_Points4[i].Y - 1, 1, 1);
                                        graphics.DrawRectangle(Pens.Black,
                                             m_Points4[i].X - 1, m_Points4[i].Y - 1, 1, 1);


                                    }

                                }




                            }

                            pictureBox1.Refresh();


                        }


                    }



                    if (radioButton34.Checked)
                    {

                        isDrawing = true;

                        if (isDrawing == true)
                        {
                            if (NextPoint > 3) NextPoint = 0;

                            // Let's save this point.
                            m_Points[NextPoint].X = e.X;
                            m_Points[NextPoint].Y = e.Y;

                            // Let's move to other points.
                            NextPoint++;

                            _MD_1 = m_Points[0];
                            _MD_2 = m_Points[1];
                            _MD_3 = m_Points[2];
                            _MD_4 = m_Points[3];






                            if (controlPointsToolStripMenuItem.BackColor == Color.Green)
                            {
                                // Let's draw some control points. 
                                for (int i = 0; i < NextPoint; i++)
                                {
                                    using Graphics graphics = Graphics.FromImage(pictureBox1.Image);
                                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
                                    graphics.FillRectangle(Brushes.Transparent,
                                    m_Points[i].X - 1, m_Points[i].Y - 1, 1, 1);
                                    graphics.DrawRectangle(pen3,
                                         m_Points[i].X - 1, m_Points[i].Y - 1, 1, 1);

                                }
                            }

                            // ReDraw.
                            pictureBox1.Refresh();

                        }


                    }


                    if (radioButton35.Checked)
                    {
                        isDrawing = true;

                        if (isDrawing == true)
                        {

                            if (NextPoint > 6) NextPoint = 0;

                          
                            m_Points1[NextPoint].X = e.X;
                            m_Points1[NextPoint].Y = e.Y;

                           
                            NextPoint++;

                            MD_1 = m_Points1[0];
                            MD_2 = m_Points1[1];
                            MD_3 = m_Points1[2];
                            MD_4 = m_Points1[3];
                            MD_5 = m_Points1[4];
                            MD_6 = m_Points1[5];
                            MD_7 = m_Points1[6];


                            if (controlPointsToolStripMenuItem.BackColor == Color.Green)
                            {
                                // Let's draw some control points. 
                                for (int i = 0; i < NextPoint; i++)
                                {
                                    using Graphics graphics = Graphics.FromImage(pictureBox1.Image);
                                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
                                    graphics.FillRectangle(Brushes.Transparent,
                                    m_Points1[i].X - 1, m_Points1[i].Y - 1, 1, 1);
                                    graphics.DrawRectangle(pen3,
                                         m_Points1[i].X - 1, m_Points1[i].Y - 1, 1, 1);

                                }

                            }
                            // ReDraw
                            pictureBox1.Refresh();


                        }



                    }

                    if (radioButton37.Checked)
                    {

                        isDrawing = true;

                        x_MD_1 = e.X;

                        y_MD_1 = e.Y;

                        pictureBox1.Refresh();

                    }

                    if (radioButton41.Checked)
                    {

                        isDrawing = true;


                        xMD_1 = e.X;

                        yMD_1 = e.Y;


                        pictureBox1.Refresh();

                    }



                    }
            }
            catch (Exception Exclamation)
            {
                // Report about others mistakes:
                MessageBox.Show(Exclamation.Message, "Mistake",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {

                if (e.Button == MouseButtons.Left)
                {
                    if (radioButton2.Checked)
                    {

                        if (!isDrawing) return;

                        using (Graphics graphics = Graphics.FromImage(pictureBox1.Image))
                        {
                            graphics.SmoothingMode = SmoothingMode.AntiAlias;
                            // Draw to the new point.
                            graphics.DrawLine(pen1, lastPoint, e.Location);
                        }


                        // Refresh.
                        pictureBox1.Refresh();

                        // Save the current point.
                        lastPoint = e.Location;
                    }

                    if (radioButton3.Checked)
                    {
                        if (!isDrawing) return;
                    }

                    if (radioButton4.Checked)
                    {

                        using (Graphics graphics = Graphics.FromImage(pictureBox1.Image))
                        {
                            graphics.SmoothingMode = SmoothingMode.AntiAlias;


                            graphics.DrawLine(pen1, x_MD_1, y_MD_1,
                            e.X, e.Y);

                        }

                        pictureBox1.Refresh();

                    }
                    if (radioButton5.Checked)
                    {
                        if (!isDrawing) return;
                    }


                    if (radioButton6.Checked)
                    {
                        if (!isDrawing) return;
                    }

                    if (radioButton7.Checked)
                    {
                        // Make sure we are drawing.
                        isDrawing = true;

                        using (Graphics graphics = Graphics.FromImage(pictureBox1.Image))
                        {
                            graphics.SmoothingMode = SmoothingMode.AntiAlias;
                            // Draw to the new point.

                            graphics.FillEllipse(
                                     new SolidBrush((Color)toolStripComboBox2.SelectedItem), e.X, e.Y, (int)numericUpDown2.Value, (int)numericUpDown3.Value);

                        }
                        // Refresh.
                        pictureBox1.Refresh();
                    }

                    if (radioButton8.Checked)
                    {
                        // Make sure we are drawing.
                        if (!isDrawing) return;

                        using (Graphics graphics = Graphics.FromImage(pictureBox1.Image))
                        {
                            graphics.SmoothingMode = SmoothingMode.AntiAlias;
                            // Draw to the new point.

                            graphics.FillRectangle(
                                     new SolidBrush((Color)toolStripComboBox2.SelectedItem), e.X, e.Y, (int)numericUpDown2.Value, (int)numericUpDown3.Value);
                        }

                        // Refresh.
                        pictureBox1.Refresh();


                    }

                    if (radioButton9.Checked)
                    {
                        if (!isDrawing) return;
                    }

                    if (radioButton10.Checked)
                    {
                        if (!isDrawing) return;
                    }


                    if (radioButton11.Checked)
                    {
                        if (!isDrawing) return;
                    }

                    if (radioButton12.Checked)
                    {
                        if (!isDrawing) return;
                    }

                    if (radioButton13.Checked)
                    {
                        if (isDrawing == true)
                        {

                            using Graphics g = Graphics.FromImage(pictureBox1.Image);
                            g.SmoothingMode = SmoothingMode.AntiAlias;


                            Rectangle Rect = new Rectangle(e.X, e.Y, (int)numericUpDown2.Value, (int)numericUpDown3.Value);
                            LinearGradientBrush GrBrush;
                            GrBrush = new LinearGradientBrush(Rect, (Color)toolStripComboBox2.SelectedItem, (Color)toolStripComboBox5.SelectedItem, (int)numericUpDown4.Value);

                            g.FillRectangle(GrBrush, Rect);

                        }

                        pictureBox1.Refresh();

                    }

                    if (radioButton14.Checked)
                    {
                        if (isDrawing == true)
                        {
                            //simple using without {}
                            using Graphics g = Graphics.FromImage(pictureBox1.Image);
                            g.SmoothingMode = SmoothingMode.AntiAlias;


                            Rectangle Rect = new Rectangle(e.X, e.Y, (int)numericUpDown2.Value, (int)numericUpDown3.Value);
                            LinearGradientBrush GrBrush;
                            GrBrush = new LinearGradientBrush(Rect, (Color)toolStripComboBox2.SelectedItem, (Color)toolStripComboBox5.SelectedItem, (int)numericUpDown4.Value);

                            g.FillEllipse(GrBrush, Rect);

                        }

                        pictureBox1.Refresh();

                    }

                    if (radioButton15.Checked)
                    {
                        if (!isDrawing) return;

                    }
                    if (radioButton16.Checked)
                    {

                        if (!isDrawing) return;

                    }

                    if (radioButton17.Checked)
                    {


                        if (!isDrawing) return;

                    }

                    if (radioButton18.Checked)
                    {

                        if (!isDrawing) return;


                    }

                    if (radioButton19.Checked)

                    {
                        if (!isDrawing) return;

                    }

                    if (radioButton20.Checked)
                    {

                        if (!isDrawing) return;

                    }

                    if (radioButton21.Checked)
                    {
                        if (!isDrawing) return;

                    }
                    if (radioButton22.Checked)

                    {
                        if (!isDrawing) return;
                    }

                    if (radioButton25.Checked)
                    {

                        // Make sure we are drawing.
                        if (!isDrawing) return;


                    }

                    if (radioButton27.Checked)
                    {


                        // Make sure we are drawing.
                        if (!isDrawing) return;
                    }


                    if (radioButton28.Checked)
                    {

                        // Make sure we are drawing.
                        if (!isDrawing) return;


                    }

                    if (radioButton29.Checked)
                    {

                        // Make sure we are drawing.
                        if (!isDrawing) return;

                    }


                    if (radioButton30.Checked)
                    {

                        // Make sure we are drawing.
                        if (!isDrawing) return;

                    }

                    if (radioButton31.Checked)
                    {

                        // Make sure we are drawing.
                        if (!isDrawing) return;

                    }


                    if (radioButton32.Checked)
                    {
                        // Make sure we are drawing.
                        if (!isDrawing) return;



                    }


                    if (radioButton32.Checked)
                    {
                        // Make sure we are drawing.
                        if (!isDrawing) return;



                    }

                    if (radioButton34.Checked)
                    {
                        // Make sure we are drawing.
                        if (!isDrawing) return;



                    }


                    if (radioButton35.Checked)
                    {


                        if (!isDrawing) return;


                    }

                    if (radioButton37.Checked)
                    {

                        isDrawing = true;

                    }


                    if (radioButton41.Checked)
                    {


                        if (!isDrawing) return;

                    }



                }
            }
            catch (Exception Исключение)
            {
                // Отчет о других ошибках:
                MessageBox.Show(Исключение.Message, "ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

       

        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {

            try
            {

                Clipboard.SetImage(pictureBox1.Image);


                if (e.Button == MouseButtons.Left)
                {

                    if (radioButton2.Checked)
                    {
                        isDrawing = false;
                    }

                    if (radioButton3.Checked)
                    {


                        using (Graphics graphics = Graphics.FromImage(pictureBox1.Image))
                        {
                            graphics.SmoothingMode = SmoothingMode.AntiAlias;

                            graphics.DrawLine(pen1, x_MD_1, y_MD_1, e.X, e.Y);

                        }

                        // Refresh.
                        pictureBox1.Refresh();
                    }

                    if (radioButton4.Checked)
                    {
                        isDrawing = false;
                    }

                    if (radioButton5.Checked)
                    {

                        using (Graphics graphics = Graphics.FromImage(pictureBox1.Image))
                        {
                            graphics.SmoothingMode = SmoothingMode.AntiAlias;

                            graphics.DrawRectangle(pen1, x_MD_1, y_MD_1,
                          e.X - x_MD_1, e.Y - y_MD_1);


                        }

                        // Refresh.
                        pictureBox1.Refresh();

                    }

                    if (radioButton6.Checked)
                    {

                        using (Graphics graphics = Graphics.FromImage(pictureBox1.Image))
                        {
                            graphics.SmoothingMode = SmoothingMode.AntiAlias;

                            graphics.DrawEllipse(pen1, x_MD_1, y_MD_1,
                          e.X - x_MD_1, e.Y - y_MD_1);


                        }

                        // Refresh.
                        pictureBox1.Refresh();


                    }


                    if (radioButton7.Checked)
                    {
                        isDrawing = false;

                    }


                    if (radioButton8.Checked)
                    {
                        isDrawing = false;


                    }

                    if (radioButton9.Checked)
                    {

                        // Make sure we are drawing.
                        isDrawing = true;

                        using (Graphics graphics = Graphics.FromImage(pictureBox1.Image))
                        {

                            graphics.SmoothingMode = SmoothingMode.AntiAlias;
                            // Draw to the new point.

                            // Create rectangle.
                            Rectangle Rect = new Rectangle(new Point(x_MD_1, y_MD_1), new Size(e.X - x_MD_1, e.Y - y_MD_1));

                            graphics.FillRectangle(
                                     new SolidBrush((Color)toolStripComboBox2.SelectedItem), Rect);
                        }

                        pictureBox1.Refresh();


                    }

                    if (radioButton10.Checked)
                    {
                        // Make sure we are drawing.
                        isDrawing = true;

                        using (Graphics graphics = Graphics.FromImage(pictureBox1.Image))
                        {


                            graphics.SmoothingMode = SmoothingMode.AntiAlias;
                            // Draw to the new point.

                            // Create rectangle.
                            Rectangle Rect = new Rectangle(new Point(x_MD_1, y_MD_1), new Size(e.X - x_MD_1, e.Y - y_MD_1));

                            graphics.FillEllipse(
                                     new SolidBrush((Color)toolStripComboBox2.SelectedItem), Rect);
                        }

                        pictureBox1.Refresh();

                    }

                    if (radioButton11.Checked)
                    {
                        isDrawing = true;
                        using (Graphics graphics = Graphics.FromImage(pictureBox1.Image))
                        {
                            graphics.SmoothingMode = SmoothingMode.AntiAlias;

                            Rectangle Rect = new Rectangle(new Point(x_MD_1, y_MD_1), new Size(e.X - x_MD_1, e.Y - y_MD_1));

                            LinearGradientBrush GrBrush;
                            GrBrush = new LinearGradientBrush(Rect, (Color)toolStripComboBox2.SelectedItem, (Color)toolStripComboBox5.SelectedItem, (int)numericUpDown4.Value);

                            graphics.FillRectangle(GrBrush, Rect);

                        }

                        pictureBox1.Refresh();
                    }



                    if (radioButton12.Checked)
                    {
                        isDrawing = true;
                        using (Graphics graphics = Graphics.FromImage(pictureBox1.Image))
                        {
                            graphics.SmoothingMode = SmoothingMode.AntiAlias;

                            Rectangle Rect = new Rectangle(new Point(x_MD_1, y_MD_1), new Size(e.X - x_MD_1, e.Y - y_MD_1));

                            LinearGradientBrush GrBrush;
                            GrBrush = new LinearGradientBrush(Rect, (Color)toolStripComboBox2.SelectedItem, (Color)toolStripComboBox5.SelectedItem, (int)numericUpDown4.Value);

                            graphics.FillEllipse(GrBrush, Rect);

                        }

                        pictureBox1.Refresh();
                    }

                    if (radioButton13.Checked)
                    {
                        isDrawing = false;
                    }

                    if (radioButton14.Checked)
                    {
                        isDrawing = false;
                    }

                    if (radioButton15.Checked)
                    {

                        isDrawing = true;



                        if (isDrawing == true)
                        {



                            if (NextPoint >= 4)
                            {

                                using (Graphics graphics = Graphics.FromImage(pictureBox1.Image))
                                {
                                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
                                    Pen DrawBZPen = new Pen((Color)toolStripComboBox2.SelectedItem, (int)numericUpDown1.Value);

                                    graphics.DrawBezier(DrawBZPen, _MD_1, _MD_2, _MD_3, _MD_4);

                                }

                                if (controlPointsToolStripMenuItem.BackColor == Color.Green)
                                {

                                    for (int i = 0; i < NextPoint; i++)
                                    {
                                        using Graphics graphics = Graphics.FromImage(pictureBox1.Image);
                                        graphics.SmoothingMode = SmoothingMode.AntiAlias;
                                        graphics.FillRectangle(Brushes.Transparent,
                                        m_Points[i].X - 1, m_Points[i].Y - 1, 1, 1);
                                        graphics.DrawRectangle(Pens.Black,
                                             m_Points[i].X - 1, m_Points[i].Y - 1, 1, 1);

                                    }
                                }

                                pictureBox1.Refresh();
                                Clipboard.SetImage(pictureBox1.Image);
                            }



                        }


                    }

                    if (radioButton16.Checked)
                    {
                        isDrawing = true;




                        if (isDrawing == true)
                        {



                            if (NextPoint >= 7)

                            {

                                using (Graphics graphics = Graphics.FromImage(pictureBox1.Image))
                                {

                                    graphics.SmoothingMode = SmoothingMode.AntiAlias;


                                    Pen DrawPolygon = new Pen((Color)toolStripComboBox2.SelectedItem, (int)numericUpDown1.Value);



                                    PointF[] curvePoints =
                                    {

                                        MD_1,
                                        MD_2,
                                        MD_3,
                                        MD_4,
                                        MD_5,
                                        MD_6,
                                        MD_7,

                                     };


                                    graphics.DrawPolygon(DrawPolygon, curvePoints);



                                }

                                if (controlPointsToolStripMenuItem.BackColor == Color.Green)
                                {

                                    for (int i = 0; i < NextPoint; i++)
                                    {
                                        using Graphics graphics = Graphics.FromImage(pictureBox1.Image);
                                        graphics.SmoothingMode = SmoothingMode.AntiAlias;
                                        graphics.FillRectangle(Brushes.Red,
                                        m_Points1[i].X - 1, m_Points1[i].Y - 1, 1, 1);
                                        graphics.DrawRectangle(pen3,
                                             m_Points1[i].X - 1, m_Points1[i].Y - 1, 1, 1);

                                    }
                                }



                                pictureBox1.Refresh();
                                Clipboard.SetImage(pictureBox1.Image);

                            }

                        }

                    }


                    if (radioButton17.Checked)
                    {
                        isDrawing = true;



                        if (isDrawing == true)
                        {



                            if (NextPoint >= 7)

                            {

                                using (Graphics graphics = Graphics.FromImage(pictureBox1.Image))
                                {

                                    graphics.SmoothingMode = SmoothingMode.AntiAlias;


                                    SolidBrush BrushP = new SolidBrush((Color)toolStripComboBox2.SelectedItem);


                                    PointF[] curvePoints =
                                    {

                                        MD_1,
                                        MD_2,
                                        MD_3,
                                        MD_4,
                                        MD_5,
                                        MD_6,
                                        MD_7,

                                     };


                                    graphics.FillPolygon(BrushP, curvePoints);



                                }

                                if (controlPointsToolStripMenuItem.BackColor == Color.Green)
                                {

                                    for (int i = 0; i < NextPoint; i++)
                                    {
                                        using Graphics graphics = Graphics.FromImage(pictureBox1.Image);
                                        graphics.SmoothingMode = SmoothingMode.AntiAlias;
                                        graphics.FillRectangle(Brushes.Red,
                                        m_Points1[i].X - 1, m_Points1[i].Y - 1, 1, 1);
                                        graphics.DrawRectangle(pen3,
                                             m_Points1[i].X - 1, m_Points1[i].Y - 1, 1, 1);

                                    }
                                }



                                pictureBox1.Refresh();
                                Clipboard.SetImage(pictureBox1.Image);

                            }

                        }

                    }

                    if (radioButton18.Checked)
                    {

                        isDrawing = true;



                        if (isDrawing == true)
                        {



                            if (NextPoint >= 7)

                            {

                                using (Graphics graphics = Graphics.FromImage(pictureBox1.Image))
                                {

                                    graphics.SmoothingMode = SmoothingMode.AntiAlias;




                                    PointF[] curvePoints =
                                    {

                                        MD_1,
                                        MD_2,
                                        MD_3,
                                        MD_4,
                                        MD_5,
                                        MD_6,
                                        MD_7,

                                     };

                                    LinearGradientBrush GrBrush;



                                    GrBrush = new LinearGradientBrush(MD_1, MD_5, (Color)toolStripComboBox2.SelectedItem, (Color)toolStripComboBox5.SelectedItem);



                                    graphics.FillPolygon(GrBrush, curvePoints);


                                }

                                if (controlPointsToolStripMenuItem.BackColor == Color.Green)
                                {

                                    for (int i = 0; i < NextPoint; i++)
                                    {
                                        using Graphics graphics = Graphics.FromImage(pictureBox1.Image);
                                        graphics.SmoothingMode = SmoothingMode.AntiAlias;
                                        graphics.FillRectangle(Brushes.Transparent,
                                        m_Points1[i].X - 1, m_Points1[i].Y - 1, 1, 1);
                                        graphics.DrawRectangle(pen3,
                                             m_Points1[i].X - 1, m_Points1[i].Y - 1, 1, 1);

                                    }
                                }



                                pictureBox1.Refresh();
                                Clipboard.SetImage(pictureBox1.Image);
                            }


                        }

                    }

                    if (radioButton19.Checked)

                    {

                        isDrawing = true;



                        if (isDrawing == true)
                        {

                            if (NextPoint >= 7)

                            {

                                using (Graphics graphics = Graphics.FromImage(pictureBox1.Image))
                                {

                                    graphics.SmoothingMode = SmoothingMode.AntiAlias;


                                    PointF[] curvePoints =
                                    {
                                          MD_1,
                                          MD_2,
                                          MD_3,
                                          MD_4,
                                          MD_5,
                                          MD_6,
                                          MD_7,
                                                  };





                                    Pen Pen1 = new Pen((Color)toolStripComboBox2.SelectedItem, (int)numericUpDown1.Value);

                                    Pen Pen2 = new Pen((Color)toolStripComboBox5.SelectedItem, (int)numericUpDown5.Value);




                                    graphics.DrawLines(Pen1, curvePoints);


                                    graphics.DrawCurve(Pen2, curvePoints);


                                }


                                if (controlPointsToolStripMenuItem.BackColor == Color.Green)
                                {

                                    for (int i = 0; i < NextPoint; i++)
                                    {
                                        using Graphics graphics = Graphics.FromImage(pictureBox1.Image);
                                        graphics.SmoothingMode = SmoothingMode.AntiAlias;
                                        graphics.FillRectangle(Brushes.Red,
                                        m_Points1[i].X - 1, m_Points1[i].Y - 1, 1, 1);
                                        graphics.DrawRectangle(pen3,
                                             m_Points1[i].X - 1, m_Points1[i].Y - 1, 1, 1);

                                    }
                                }

                                pictureBox1.Refresh();
                                Clipboard.SetImage(pictureBox1.Image);

                            }

                        }

                    }

                    if (radioButton20.Checked)
                    {
                        isDrawing = true;



                        if (isDrawing == true)
                        {

                            if (NextPoint >= 7)

                            {

                                using (Graphics graphics = Graphics.FromImage(pictureBox1.Image))
                                {

                                    graphics.SmoothingMode = SmoothingMode.AntiAlias;


                                    PointF[] curvePoints =
                                    {
                                          MD_1,
                                          MD_2,
                                          MD_3,
                                          MD_4,
                                          MD_5,
                                          MD_6,
                                          MD_7,
                                                  };





                                    Pen Pen1 = new Pen((Color)toolStripComboBox2.SelectedItem, (int)numericUpDown1.Value);

                                    Pen Pen2 = new Pen((Color)toolStripComboBox5.SelectedItem, (int)numericUpDown5.Value);




                                    graphics.DrawLines(Pen1, curvePoints);


                                    graphics.DrawClosedCurve(Pen2, curvePoints);


                                }


                                if (controlPointsToolStripMenuItem.BackColor == Color.Green)
                                {

                                    for (int i = 0; i < NextPoint; i++)
                                    {
                                        using Graphics graphics = Graphics.FromImage(pictureBox1.Image);
                                        graphics.SmoothingMode = SmoothingMode.AntiAlias;
                                        graphics.FillRectangle(Brushes.Red,
                                        m_Points1[i].X - 1, m_Points1[i].Y - 1, 1, 1);
                                        graphics.DrawRectangle(pen3,
                                             m_Points1[i].X - 1, m_Points1[i].Y - 1, 1, 1);

                                    }
                                }

                                pictureBox1.Refresh();
                                Clipboard.SetImage(pictureBox1.Image);

                            }

                        }



                    }

                    if (radioButton21.Checked)
                    {
                        isDrawing = true;



                        if (isDrawing == true)
                        {


                            if (NextPoint >= 4)

                            {

                                using (Graphics graphics = Graphics.FromImage(pictureBox1.Image))
                                {


                                    graphics.SmoothingMode = SmoothingMode.AntiAlias;

                                    PointF[] curvePoints =
                                    {
                                          _MD_1,
                                          _MD_2,
                                          _MD_3,
                                          _MD_4,

                                                  };

                                    SolidBrush BrushClCu = new SolidBrush((Color)toolStripComboBox2.SelectedItem);



                                    graphics.FillClosedCurve(BrushClCu, curvePoints);


                                }


                                if (controlPointsToolStripMenuItem.BackColor == Color.Green)
                                {

                                    for (int i = 0; i < NextPoint; i++)
                                    {
                                        using Graphics graphics = Graphics.FromImage(pictureBox1.Image);
                                        graphics.SmoothingMode = SmoothingMode.AntiAlias;
                                        graphics.FillRectangle(Brushes.Red,
                                        m_Points[i].X - 1, m_Points[i].Y - 1, 1, 1);
                                        graphics.DrawRectangle(pen3,
                                             m_Points[i].X - 1, m_Points[i].Y - 1, 1, 1);

                                    }
                                }

                                pictureBox1.Refresh();
                                Clipboard.SetImage(pictureBox1.Image);

                            }

                        }


                    }

                    if (radioButton22.Checked)
                    {

                        isDrawing = true;

                        if (isDrawing == true)
                        {
                            if (NextPoint >= 4)

                            {

                                using (Graphics graphics = Graphics.FromImage(pictureBox1.Image))
                                {


                                    graphics.SmoothingMode = SmoothingMode.AntiAlias;

                                    PointF[] curvePoints =
                                    {
                                          _MD_1,
                                          _MD_2,
                                          _MD_3,
                                          _MD_4,

                                                  };


                                    LinearGradientBrush GrBrush;



                                    GrBrush = new LinearGradientBrush(_MD_1, _MD_3, (Color)toolStripComboBox2.SelectedItem, (Color)toolStripComboBox5.SelectedItem);



                                    graphics.FillClosedCurve(GrBrush, curvePoints);


                                }


                                if (controlPointsToolStripMenuItem.BackColor == Color.Green)
                                {

                                    for (int i = 0; i < NextPoint; i++)
                                    {
                                        using Graphics graphics = Graphics.FromImage(pictureBox1.Image);
                                        graphics.SmoothingMode = SmoothingMode.AntiAlias;
                                        graphics.FillRectangle(Brushes.Red,
                                        m_Points[i].X - 1, m_Points[i].Y - 1, 1, 1);
                                        graphics.DrawRectangle(pen3,
                                             m_Points[i].X - 1, m_Points[i].Y - 1, 1, 1);

                                    }
                                }

                                pictureBox1.Refresh();

                                Clipboard.SetImage(pictureBox1.Image);



                            }

                        }

                    }

                    if (radioButton25.Checked)
                    {

                        isDrawing = true;


                        using (Graphics g = Graphics.FromImage(pictureBox1.Image))
                        {

                            // graphics.SmoothingMode = SmoothingMode.AntiAlias;


                            Rectangle Rect = new Rectangle(new Point(x_MD_1, y_MD_1), new Size(e.X - x_MD_1, e.Y - y_MD_1));




                            // Create a path that consists of a single ellipse.
                            GraphicsPath path = new GraphicsPath();
                            path.AddEllipse(Rect);


                            // path.AddRectangle(Rect);
                            // Use the path to construct a brush.

                            PathGradientBrush pthGrBrush = new PathGradientBrush(path)
                            {




                                // Set the color at the center of the path to blue.
                                CenterColor = (Color)toolStripComboBox2.SelectedItem
                            };

                            // Set the color along the entire boundary 
                            // of the path to aqua.
                            Color[] colors = { (Color)toolStripComboBox5.SelectedItem };
                            pthGrBrush.SurroundColors = colors;

                            //e.Graphics.FillRectangle(pthGrBrush, 35, 35, 140, 140);

                            graphics.FillEllipse(pthGrBrush, Rect);// строку можно оставить при прямоугольнике сходящиеся к центру оси градиентов.


                        }

                        pictureBox1.Refresh();

                        Clipboard.SetImage(pictureBox1.Image);


                    }

                    if (radioButton27.Checked)
                    {
                        isDrawing = true;



                        if (isDrawing == true)
                        {



                            if (NextPoint >= 10)

                            {

                                using (Graphics graphics = Graphics.FromImage(pictureBox1.Image))
                                {


                                    // Put the points of a polygon in an array.
                                    PointF[] points = {
                                        MD_1_,
                                        MD_2_,
                                        MD_3_,
                                        MD_4_,
                                        MD_5_,
                                        MD_6_,
                                        MD_7_,
                                        MD_8_,
                                        MD_9_,
                                        MD_10_,};

                                    // Use the array of points to construct a path.
                                    GraphicsPath path = new GraphicsPath();
                                    path.AddLines(points);

                                    // Use the path to construct a path gradient brush.
                                    PathGradientBrush pthGrBrush = new PathGradientBrush(path)
                                    {

                                        // Set the color at the center of the path to red.
                                        CenterColor = (Color)toolStripComboBox2.SelectedItem
                                    };


                                    // Set the colors of the points in the array.
                                    Color[] colors = {
                                    (Color)comboBox1.SelectedItem,
                                    (Color)comboBox2.SelectedItem,
                                    (Color)comboBox3.SelectedItem,
                                    (Color)comboBox4.SelectedItem,
                                    (Color)comboBox5.SelectedItem,
                                    (Color)comboBox6.SelectedItem,
                                    (Color)comboBox7.SelectedItem,
                                    (Color)comboBox8.SelectedItem,
                                    (Color)comboBox9.SelectedItem,
                                    (Color)toolStripComboBox5.SelectedItem};


                                    pthGrBrush.SurroundColors = colors;

                                    // Fill the path with the path gradient brush.
                                    graphics.FillPath(pthGrBrush, path);

                                    // Refresh.
                                    pictureBox1.Refresh();
                                }

                                Clipboard.SetImage(pictureBox1.Image);

                            }


                        }



                    }
                    if (radioButton28.Checked)
                    {

                        isDrawing = true;


                        using Graphics g = Graphics.FromImage(pictureBox1.Image);

                      


                        Rectangle Rect = new Rectangle(new Point(x_MD_1, y_MD_1), new Size(e.X - x_MD_1, e.Y - y_MD_1));




                        // Create a path that consists of a single ellipse.
                        GraphicsPath path = new GraphicsPath();
                        path.AddEllipse(Rect);


                        // path.AddRectangle(Rect);
                        // Use the path to construct a brush.

                        PathGradientBrush pthGrBrush = new PathGradientBrush(path)
                        {
                            CenterPoint = new PointF((int)numericUpDown6.Value, (int)numericUpDown7.Value),

                            // Set the color at the center of the path to blue.
                            CenterColor = (Color)toolStripComboBox2.SelectedItem
                        };

                        // Set the color along the entire boundary 
                        // of the path to aqua.
                        Color[] colors = { (Color)toolStripComboBox5.SelectedItem };
                        pthGrBrush.SurroundColors = colors;



                        graphics.FillEllipse(pthGrBrush, Rect);// строку можно оставить при прямоугольнике сходящиеся к центру оси градиентов.


                        if (controlPointsToolStripMenuItem.BackColor == Color.Green)
                        {

                            graphics.DrawRectangle(pen3, (int)numericUpDown6.Value, (int)numericUpDown7.Value - 1, 1, 1);
                        }

                        pictureBox1.Refresh();

                        Clipboard.SetImage(pictureBox1.Image);



                    }

                    if (radioButton29.Checked)

                    {
                        isDrawing = true;


                        using Graphics g = Graphics.FromImage(pictureBox1.Image);

                    


                        Rectangle Rect = new Rectangle(new Point(x_MD_1, y_MD_1), new Size(e.X - x_MD_1, e.Y - y_MD_1));




                        // Create a path that consists of a single ellipse.
                        GraphicsPath path = new GraphicsPath();
                        path.AddEllipse(Rect);


                        // path.AddRectangle(Rect);
                        // Use the path to construct a brush.

                        PathGradientBrush pthGrBrush = new PathGradientBrush(path)
                        {
                            CenterPoint = new PointF(e.X, e.Y),

                            // Set the color at the center of the path to blue.
                            CenterColor = (Color)toolStripComboBox2.SelectedItem
                        };

                        // Set the color along the entire boundary 
                        // of the path to aqua.
                        Color[] colors = { (Color)toolStripComboBox5.SelectedItem };
                        pthGrBrush.SurroundColors = colors;

                        //e.Graphics.FillRectangle(pthGrBrush, 35, 35, 140, 140);

                        graphics.FillEllipse(pthGrBrush, Rect);// строку можно оставить при прямоугольнике сходящиеся к центру оси градиентов.


                        if (controlPointsToolStripMenuItem.BackColor == Color.Green)
                        {

                            graphics.DrawRectangle(pen3, e.X, e.Y, 1, 1);
                        }

                        pictureBox1.Refresh();

                        Clipboard.SetImage(pictureBox1.Image);

                    }


                    if (radioButton30.Checked)

                    {
                        isDrawing = true;


                        using Graphics g = Graphics.FromImage(pictureBox1.Image);

                  


                        Rectangle Rect = new Rectangle(new Point(x_MD_1, y_MD_1), new Size(e.X - x_MD_1, e.Y - y_MD_1));




                        // Create a path that consists of a single ellipse.
                        GraphicsPath path = new GraphicsPath();
                        path.AddEllipse(Rect);


                        // path.AddRectangle(Rect);
                        // Use the path to construct a brush.

                        PathGradientBrush pthGrBrush = new PathGradientBrush(path)

                        {
                            CenterPoint = new PointF(e.X, e.Y),

                            // Set the color at the center of the path to blue.
                            CenterColor = (Color)toolStripComboBox2.SelectedItem
                        };

                        // Set the color along the entire boundary 
                        // of the path to aqua.
                        Color[] colors = { (Color)toolStripComboBox5.SelectedItem };
                        pthGrBrush.SurroundColors = colors;



                        graphics.FillRectangle(pthGrBrush, Rect);// строку можно оставить при прямоугольнике сходящиеся к центру оси градиентов.


                        if (controlPointsToolStripMenuItem.BackColor == Color.Green)
                        {

                            graphics.DrawRectangle(pen3, e.X, e.Y, 1, 1);
                        }

                        pictureBox1.Refresh();

                        Clipboard.SetImage(pictureBox1.Image);


                    }


                    if (radioButton31.Checked)
                    {



                        using Graphics g = Graphics.FromImage(pictureBox1.Image);

                        PointF[] points =
                                {
                                          _MD_1_,
                                          _MD_2_,
                                          _MD_3_,


                                                  };

                        GraphicsPath path = new GraphicsPath();
                        path.AddLines(points);


                        // No GraphicsPath object is created. The PathGradientBrush
                        // object is constructed directly from the array of points.
                        PathGradientBrush pthGrBrush = new PathGradientBrush(points);

                        Color[] colors = {
      (Color)toolStripComboBox2.SelectedItem,
       (Color)toolStripComboBox5.SelectedItem,
       (Color)comboBox10.SelectedItem};




                        float[] relativePositions = {
       (float)numericUpDown8.Value,       // Dark green is at the boundary of the triangle.
       (float)numericUpDown9.Value,     // Aqua is 40 percent of the way from the boundary
                 // to the center point.
      (float)numericUpDown10.Value};    // Blue is at the center point.

                        ColorBlend colorBlend = new ColorBlend
                        {
                            Colors = colors,
                            Positions = relativePositions
                        };
                        pthGrBrush.InterpolationColors = colorBlend;

                        // Fill a rectangle that is larger than the triangle
                        // specified in the Point array. The portion of the
                        // rectangle outside the triangle will not be painted.
                        g.FillPath(pthGrBrush, path);

                        // Refresh.
                        pictureBox1.Refresh();

                        if (controlPointsToolStripMenuItem.BackColor == Color.Green)
                        {
                            // Let's draw some control points. 
                            for (int i = 0; i < NextPoint; i++)
                            {
                                using Graphics graphics = Graphics.FromImage(pictureBox1.Image);
                                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                                graphics.FillRectangle(Brushes.Transparent,
                                m_Points4[i].X - 1, m_Points4[i].Y - 1, 1, 1);
                                graphics.DrawRectangle(Pens.Black,
                                     m_Points4[i].X - 1, m_Points4[i].Y - 1, 1, 1);


                            }

                        }








                        Clipboard.SetImage(pictureBox1.Image);
                    }



                    if (radioButton32.Checked)
                    {
                        if (NextPoint >= 3)

                        {
                            using Graphics g = Graphics.FromImage(pictureBox1.Image);

                            PointF[] points =
                                    {
                                          _MD_1_,
                                          _MD_2_,
                                          _MD_3_,


                                                  };

                            GraphicsPath path = new GraphicsPath();
                            path.AddLines(points);


                            // No GraphicsPath object is created. The PathGradientBrush
                            // object is constructed directly from the array of points.
                            PathGradientBrush pthGrBrush = new PathGradientBrush(points);

                            Color[] colors = {
      (Color)toolStripComboBox2.SelectedItem,
       (Color)toolStripComboBox5.SelectedItem,
       (Color)comboBox10.SelectedItem};




                            float[] relativePositions = {
       (float)numericUpDown8.Value,       // Dark green is at the boundary of the triangle.
       (float)numericUpDown9.Value,     // Aqua is 40 percent of the way from the boundary
                 // to the center point.
      (float)numericUpDown10.Value};    // Blue is at the center point.

                            ColorBlend colorBlend = new ColorBlend
                            {
                                Colors = colors,
                                Positions = relativePositions
                            };
                            pthGrBrush.InterpolationColors = colorBlend;

                            // Fill a rectangle that is larger than the triangle
                            // specified in the Point array. The portion of the
                            // rectangle outside the triangle will not be painted.
                            g.FillPath(pthGrBrush, path);



                            if (controlPointsToolStripMenuItem.BackColor == Color.Green)
                            {
                                // Let's draw some control points. 
                                for (int i = 0; i < NextPoint; i++)
                                {
                                    using Graphics graphics = Graphics.FromImage(pictureBox1.Image);
                                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
                                    graphics.FillRectangle(Brushes.Transparent,
                                    m_Points4[i].X - 1, m_Points4[i].Y - 1, 1, 1);
                                    graphics.DrawRectangle(Pens.Black,
                                         m_Points4[i].X - 1, m_Points4[i].Y - 1, 1, 1);


                                }

                            }




                            // Refresh.
                            pictureBox1.Refresh();



                            Clipboard.SetImage(pictureBox1.Image);
                        }

                    }

                    if (radioButton34.Checked)
                    {
                        isDrawing = true;

                        if (isDrawing == true)
                        {
                            if (NextPoint >= 4)

                            {

                                using (Graphics graphics = Graphics.FromImage(pictureBox1.Image))
                                {


                                    graphics.SmoothingMode = SmoothingMode.AntiAlias;

                                    PointF[] curvePoints =
                                    {
                                          _MD_1,
                                          _MD_2,
                                          _MD_3,
                                          _MD_4,

                                                  };



                                    GraphicsPath path = new GraphicsPath();
                                    path.AddLines(curvePoints);


                                    // No GraphicsPath object is created. The PathGradientBrush
                                    // object is constructed directly from the array of points.
                                    PathGradientBrush pthGrBrush = new PathGradientBrush(curvePoints);

                                    Color[] colors = {
      (Color)toolStripComboBox2.SelectedItem,
      (Color)toolStripComboBox5.SelectedItem,
      (Color)comboBox11.SelectedItem};




                                    float[] relativePositions = {
       (float)numericUpDown13.Value,       // Dark green is at the boundary of the triangle.
       (float)numericUpDown12.Value,     // Aqua is 40 percent of the way from the boundary
                 // to the center point.
      (float)numericUpDown11.Value};    // Blue is at the center point.

                                    ColorBlend colorBlend = new ColorBlend
                                    {
                                        Colors = colors,
                                        Positions = relativePositions
                                    };
                                    pthGrBrush.InterpolationColors = colorBlend;

                                    // Fill a rectangle that is larger than the triangle
                                    // specified in the Point array. The portion of the
                                    // rectangle outside the triangle will not be painted.
                                    graphics.FillPath(pthGrBrush, path);



                                }


                                if (controlPointsToolStripMenuItem.BackColor == Color.Green)
                                {

                                    for (int i = 0; i < NextPoint; i++)
                                    {
                                        using Graphics graphics = Graphics.FromImage(pictureBox1.Image);
                                        graphics.SmoothingMode = SmoothingMode.AntiAlias;
                                        graphics.FillRectangle(Brushes.Red,
                                        m_Points[i].X - 1, m_Points[i].Y - 1, 1, 1);
                                        graphics.DrawRectangle(pen3,
                                             m_Points[i].X - 1, m_Points[i].Y - 1, 1, 1);

                                    }
                                }

                                pictureBox1.Refresh();


                                Clipboard.SetImage(pictureBox1.Image);


                            }



                        }

                    }


                    if (radioButton35.Checked)
                    {

                        isDrawing = true;



                        if (isDrawing == true)
                        {



                            if (NextPoint >= 7)

                            {

                                using (Graphics graphics = Graphics.FromImage(pictureBox1.Image))
                                {

                                    graphics.SmoothingMode = SmoothingMode.AntiAlias;


                                    SolidBrush BrushP = new SolidBrush((Color)toolStripComboBox2.SelectedItem);


                                    PointF[] curvePoints =
                                    {

                                        MD_1,
                                        MD_2,
                                        MD_3,
                                        MD_4,
                                        MD_5,
                                        MD_6,
                                        MD_7,

                                     };


                                    GraphicsPath path = new GraphicsPath();


                                    path.AddLines(curvePoints);


                                    //   path.AddClosedCurve(curvePoints);


                                    // No GraphicsPath object is created. The PathGradientBrush
                                    // object is constructed directly from the array of points.
                                    PathGradientBrush pthGrBrush = new PathGradientBrush(curvePoints);

                                    Color[] colors = {
      (Color)toolStripComboBox2.SelectedItem,
      (Color)toolStripComboBox5.SelectedItem,
      (Color)comboBox11.SelectedItem};




                                    float[] relativePositions = {
       (float)numericUpDown13.Value,       // Dark green is at the boundary of the triangle.
       (float)numericUpDown12.Value,     // Aqua is 40 percent of the way from the boundary
                 // to the center point.
      (float)numericUpDown11.Value};    // Blue is at the center point.

                                    ColorBlend colorBlend = new ColorBlend
                                    {
                                        Colors = colors,
                                        Positions = relativePositions
                                    };
                                    pthGrBrush.InterpolationColors = colorBlend;

                                    // Fill a rectangle that is larger than the triangle
                                    // specified in the Point array. The portion of the
                                    // rectangle outside the triangle will not be painted.
                                    graphics.FillPath(pthGrBrush, path);



                                }

                                if (controlPointsToolStripMenuItem.BackColor == Color.Green)
                                {

                                    for (int i = 0; i < NextPoint; i++)
                                    {
                                        using Graphics graphics = Graphics.FromImage(pictureBox1.Image);
                                        graphics.SmoothingMode = SmoothingMode.AntiAlias;
                                        graphics.FillRectangle(Brushes.Transparent,
                                        m_Points1[i].X - 1, m_Points1[i].Y - 1, 1, 1);
                                        graphics.DrawRectangle(pen3,
                                             m_Points1[i].X - 1, m_Points1[i].Y - 1, 1, 1);

                                    }
                                }



                                pictureBox1.Refresh();

                                Clipboard.SetImage(pictureBox1.Image);

                            }


                        }







                    }



                    if (radioButton37.Checked)
                    {


                        isDrawing = true;


                        using (Graphics graphics = Graphics.FromImage(pictureBox1.Image))
                        {
                            graphics.SmoothingMode = SmoothingMode.AntiAlias;




                            Pen ArrowPen = new Pen((Color)comboBox30.SelectedItem, (int)comboBox31.SelectedItem)
                            {

                                StartCap = (LineCap)comboBox26.SelectedItem,
                                EndCap = (LineCap)comboBox27.SelectedItem,
                                DashCap = (DashCap)comboBox28.SelectedItem,
                                DashStyle = (DashStyle)comboBox29.SelectedItem

                            };



                            graphics.DrawLine(ArrowPen, x_MD_1, y_MD_1, e.X, e.Y);

                        }

                        // Refresh.
                        pictureBox1.Refresh();

                    }


                    if (radioButton41.Checked)
                    {



                        using (Graphics g = Graphics.FromImage(pictureBox1.Image))
                        {



                            g.SmoothingMode = SmoothingMode.AntiAlias;


                            



                            g.CopyFromScreen(new Point((int)numericUpDown22.Value, (int)numericUpDown23.Value),
                  new Point(xMD_1, yMD_1), new Size((int)numericUpDown24.Value, (int)numericUpDown25.Value), CopyPixelOperation.MergePaint);
                        }


                        pictureBox1.Refresh();


                    }

                }
                
                }
            catch 
            {
              
            }
        }

      

        #endregion
//option of Main Menu

        #region

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string s = openFileDialog1.FileName;
                    try
                    {
                        Image bm1 = new Bitmap(s);
                        // Make an associated Graphics object.
                        graphics = Graphics.FromImage(bm1);


                        // Display the new bitmap in the PictureBox.
                        pictureBox1.Image = bm1;

                        // bmp = bm1;

                        //     toolStripProgressBar1.Value = 0;
                        //    for (y = 0; y < bmp.Height; y++)
                        //    {
                        //        int jump = bmp.Height / 100;
                        //      if (y % jump == jump - 1) toolStripProgressBar1.PerformStep();


                        //   toolStripStatusLabel1.Text = "Opened image:" + s;

                        Text = "Opened image:" + s;

                        graphics.Dispose();

                       // }

                    }
                    catch
                    {
                        MessageBox.Show("File " + s + " has a wrong format.", "Error");
                        return;
                    }
                //    toolStripStatusLabel1.Text = "DrawWithMousePB19 - " + s;

                    openFileDialog1.FileName = "";

                }
                // toolStripProgressBar1.Value = 0;
            }
            catch (Exception Exclamation)
            {
                // Report about auther mistakes:
                MessageBox.Show(Exclamation.Message, "Mistake",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }



        }

     
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {

                    ContrastBtmp = new Bitmap(pictureBox1.Image);



                    if (saveFileDialog1.FileName.Contains(".bmp")) ContrastBtmp.Save(saveFileDialog1.FileName, ImageFormat.Bmp);
                    else
                          if (saveFileDialog1.FileName.Contains(".jpeg")) ContrastBtmp.Save(saveFileDialog1.FileName, ImageFormat.Jpeg);
                    else
                           if (saveFileDialog1.FileName.Contains(".gif")) ContrastBtmp.Save(saveFileDialog1.FileName, ImageFormat.Gif);
                    else
                     if (saveFileDialog1.FileName.Contains(".tiff")) ContrastBtmp.Save(saveFileDialog1.FileName, ImageFormat.Tiff);
                    else
                       if (saveFileDialog1.FileName.Contains(".png")) ContrastBtmp.Save(saveFileDialog1.FileName, ImageFormat.Png);
                    else
                    {
                        MessageBox.Show("The file " + saveFileDialog1.FileName + " has an inappropriate extension. Returning.");
                        return;
                    }
                }
                MessageBox.Show("The result image saved under " + saveFileDialog1.FileName);

            }
            catch (Exception Исключение)
            {
                // Отчет о других ошибках:
                MessageBox.Show(Исключение.Message, "ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

     
        private void Pen1ColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {


                ToolStripMenuItem PCL = sender as ToolStripMenuItem;
                colorDialog1.Color = PCL.BackColor;
                if (colorDialog1.ShowDialog() == DialogResult.OK)
                    PCL.BackColor = colorDialog1.Color;



            }
            catch (Exception Exclamation)
            {
                // Report about others mistakes:
                MessageBox.Show(Exclamation.Message, "Mistake",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void BackColorGrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (Graphics g = Graphics.FromImage(pictureBox1.Image))
                {

                    graphics.SmoothingMode = SmoothingMode.AntiAlias;


                    Rectangle Rect = new Rectangle(0, 0, pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height);

                    LinearGradientBrush GrBrush;

                    using (GrBrush = new LinearGradientBrush(Rect, (Color)comboBox12.SelectedItem, (Color)comboBox13.SelectedItem, (int)numericUpDown14.Value))
                    {

                        graphics.FillRectangle(GrBrush, Rect);

                    }
                }
                pictureBox1.Refresh();


            }
            catch (Exception Exclamation)
            {
                // Report about others mistakes:
                MessageBox.Show(Exclamation.Message, "Mistake",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void RadioButton39_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                button1.Enabled = true;

            }
            catch (Exception Exclamation)
            {
                // Report about others mistakes:
                MessageBox.Show(Exclamation.Message, "Mistake",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }

        private void RandomMultBackColorGrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioButton42.Checked)
                {

                    timer2.Enabled = true; 
                }

                }
            catch (Exception Exclamation)
            {
                // Report about others mistakes:
                MessageBox.Show(Exclamation.Message, "Mistake",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {


                DialogResult result = MessageBox.Show("If changers was maid, then would you like to save this changers or not?", "OK!",
MessageBoxButtons.YesNo);
                // в зависимости от результата нажатия кнопки пользователем в окне MessageBox
                switch (result)
                {
                   
                    case DialogResult.No:
                   // close
                         Form1 F = new Form1(); 
                        
                        F.Close();
                        break;
                    case DialogResult.Yes:
                        // save
                        if (saveFileDialog2.ShowDialog() == DialogResult.OK)
                        {
                            m_Bm = new Bitmap(pictureBox1.Image);
                            m_Bm.Save(saveFileDialog2.FileName);
                            string filename = saveFileDialog2.FileName;
                            string extension = filename[filename.LastIndexOf(".")..];
                            switch (extension)
                            {
                                case ".bmp":
                                    m_Bm.Save(filename, ImageFormat.Bmp);
                                    break;
                                case ".jpg":
                                case ".jpeg":
                                    m_Bm.Save(filename, ImageFormat.Jpeg);
                                    break;
                                case ".gif":
                                    m_Bm.Save(filename, ImageFormat.Gif);
                                    break;
                                case ".png":
                                    m_Bm.Save(filename, ImageFormat.Png);
                                    break;
                                case ".tif":
                                case ".tiff":
                                    m_Bm.Save(filename, ImageFormat.Tiff);
                                    break;
                            }

                        }
                        break;
                }
            }
            catch (Exception Exclamation)
            {
                // Report about others mistakes:
                MessageBox.Show(Exclamation.Message, "Mistake",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                isDrawing = true;



                if (isDrawing == true)
                {

                    if (radioButton42.Checked)
                    {


                        using (Graphics graphics = Graphics.FromImage(pictureBox1.Image))
                        {



                            MD_1_ = new Point(0, 0);
                            MD_2_ = new Point(pictureBox1.ClientSize.Width / 6, 0);
                            MD_3_ = new Point(pictureBox1.ClientSize.Width / 3, 0);


                            MD_4_ = new Point(pictureBox1.ClientSize.Width, 0);

                            MD_5_ = new Point(pictureBox1.ClientSize.Width, 388);



                            MD_6_ = new Point(pictureBox1.ClientSize.Width, 776);


                            MD_7_ = new Point(pictureBox1.ClientSize.Width / 6, 776);


                            MD_8_ = new Point(pictureBox1.ClientSize.Width / 3, 776);


                            MD_9_ = new Point(0, pictureBox1.ClientSize.Height);


                            MD_10_ = new Point(0, 338);


                            // Put the points of a polygon in an array.
                            PointF[] points = {
                                        MD_1_,
                                        MD_2_,
                                        MD_3_,
                                        MD_4_,
                                        MD_5_,
                                        MD_6_,
                                        MD_7_,
                                        MD_8_,
                                        MD_9_,
                                        MD_10_,};

                            // Use the array of points to construct a path.
                            GraphicsPath path = new GraphicsPath();
                            path.AddLines(points);

                            // Use the path to construct a path gradient brush.
                            PathGradientBrush pthGrBrush = new PathGradientBrush(path)
                            {

                                // Set the color at the center of the path to red.
                                CenterColor = Color.FromArgb(Random.Next(256), Random.Next(256), Random.Next(256))
                            };


                            // Set the colors of the points in the array.
                            Color[] colors = {
                                    Color.FromArgb (Random.Next(256), Random.Next(256), Random.Next(256)),
                                    Color.FromArgb (Random.Next(256), Random.Next(256), Random.Next(256)),
                                    Color.FromArgb (Random.Next(256), Random.Next(256), Random.Next(256)),
                                    Color.FromArgb (Random.Next(256), Random.Next(256), Random.Next(256)),
                                    Color.FromArgb (Random.Next(256), Random.Next(256), Random.Next(256)),
                                    Color.FromArgb (Random.Next(256), Random.Next(256), Random.Next(256)),
                                    Color.FromArgb (Random.Next(256), Random.Next(256), Random.Next(256)),
                                    Color.FromArgb (Random.Next(256), Random.Next(256), Random.Next(256)),
                                    Color.FromArgb (Random.Next(256), Random.Next(256), Random.Next(256)),
                                    Color.FromArgb (Random.Next(256), Random.Next(256), Random.Next(256))};


                            pthGrBrush.SurroundColors = colors;

                            // Fill the path with the path gradient brush.
                            graphics.FillPath(pthGrBrush, path);

                            // Refresh.
                            pictureBox1.Refresh();
                        }

                        Clipboard.SetImage(pictureBox1.Image);

                    }
                }

            }
            catch (Exception Exclamation)
            {
                // Report about others mistakes:
                MessageBox.Show(Exclamation.Message, "Mistake",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void RadioButton44_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                radioButton44.BackColor = Color.Green;
               
            }
            catch (Exception Exclamation)
            {
                // Report about others mistakes:
                MessageBox.Show(Exclamation.Message, "Mistake",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void PictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox1.Text.Length == 0) return;

            if (e.Button == MouseButtons.Right)
            {

                if ((radioButton44.Checked)|| (tabControl1.Visible == false)==true)

            {

                
                    if (radioButton44.BackColor == Color.Green)
                    {

                        using (Graphics graphics = Graphics.FromImage(pictureBox1.Image))
                        {


                            // Create font and brush.
                            Font drawFont = new Font((string)comboBox34.SelectedItem, (int)comboBox35.SelectedItem);


                            SolidBrush drawBrush = new SolidBrush((Color)comboBox36.SelectedItem);



                            // Set format of string.
                            StringFormat drawFormat = new StringFormat
                            {
                                FormatFlags = StringFormatFlags.DisplayFormatControl
                            };

                            // Draw string to screen.
                            graphics.DrawString(textBox1.Text, drawFont, drawBrush, e.X, e.Y, drawFormat);


                        }

                        pictureBox1.Refresh();

                    }

                }

            }


        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                InputLanguage myCurrentLanguage = InputLanguage.FromCulture(new CultureInfo("ru-RU"));

                InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("en-US"));



            }
            catch (Exception Exclamation)
            {
                // Report about others mistakes:
                MessageBox.Show(Exclamation.Message, "Mistake",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                // InputLanguage myDefaultLanguage = InputLanguage.DefaultInputLanguage;
                // InputLanguage.CurrentInputLanguage = myDefaultLanguage;

                InputLanguage myCurrentLanguage = InputLanguage.FromCulture(new CultureInfo("en-US"));

                InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("ru-RU"));


            }
            catch (Exception Exclamation)
            {
                // Report about others mistakes:
                MessageBox.Show(Exclamation.Message, "Mistake",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void RadioButton38_Click(object sender, EventArgs e)
        {
            try
            {
                button1.Enabled = false;

            }
            catch (Exception Exclamation)
            {
                // Report about others mistakes:
                MessageBox.Show(Exclamation.Message, "Mistake",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }

    
        private void BackColorGrInterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                isDrawing = true;

                if (isDrawing == true)
                {
                    using (Graphics graphics = Graphics.FromImage(pictureBox1.Image))
                    {


                        graphics.SmoothingMode = SmoothingMode.AntiAlias;

                        _MD_1 = new Point(0, 53);
                        _MD_2 = new Point(pictureBox1.ClientSize.Width, 53);
                        _MD_3 = new Point(pictureBox1.ClientSize.Width, 776);
                        _MD_4 = new Point(0, pictureBox1.ClientSize.Height);

                        PointF[] curvePoints =
                            {
                                          _MD_1,
                                          _MD_2,
                                          _MD_3,
                                          _MD_4,

                                                  };



                        GraphicsPath path = new GraphicsPath();
                        path.AddLines(curvePoints);


                        // No GraphicsPath object is created. The PathGradientBrush
                        // object is constructed directly from the array of points.
                        PathGradientBrush pthGrBrush = new PathGradientBrush(curvePoints);

                        Color[] colors = {
      (Color)comboBox12.SelectedItem,
      (Color)comboBox13.SelectedItem,
      (Color)comboBox15.SelectedItem};




                        float[] relativePositions = {
       (float)numericUpDown13.Value,       // Dark green is at the boundary of the triangle.
       (float)numericUpDown12.Value,     // Aqua is 40 percent of the way from the boundary
                 // to the center point.
      (float)numericUpDown11.Value};    // Blue is at the center point.

                        ColorBlend colorBlend = new ColorBlend
                        {
                            Colors = colors,
                            Positions = relativePositions
                        };
                        pthGrBrush.InterpolationColors = colorBlend;

                        // Fill a rectangle that is larger than the triangle
                        // specified in the Point array. The portion of the
                        // rectangle outside the triangle will not be painted.
                        graphics.FillPath(pthGrBrush, path);



                    }




                    pictureBox1.Refresh();


                    Clipboard.SetImage(pictureBox1.Image);


                }




            }
            catch (Exception Exclamation)
            {
                // Report about others mistakes:
                MessageBox.Show(Exclamation.Message, "Mistake",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void MultBackColorGrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                isDrawing = true;



                if (isDrawing == true)
                {





                    using (Graphics graphics = Graphics.FromImage(pictureBox1.Image))
                    {



                        MD_1_ = new Point(0, 53);
                        MD_2_ = new Point(pictureBox1.ClientSize.Width / 6, 53);
                        MD_3_ = new Point(pictureBox1.ClientSize.Width / 3, 53);


                        MD_4_ = new Point(pictureBox1.ClientSize.Width, 53);

                        MD_5_ = new Point(pictureBox1.ClientSize.Width, 388);



                        MD_6_ = new Point(pictureBox1.ClientSize.Width, 776);


                        MD_7_ = new Point(pictureBox1.ClientSize.Width / 6, 776);


                        MD_8_ = new Point(pictureBox1.ClientSize.Width / 3, 776);


                        MD_9_ = new Point(0, pictureBox1.ClientSize.Height);


                        MD_10_ = new Point(0, 338);


                        // Put the points of a polygon in an array.
                        PointF[] points = {
                                        MD_1_,
                                        MD_2_,
                                        MD_3_,
                                        MD_4_,
                                        MD_5_,
                                        MD_6_,
                                        MD_7_,
                                        MD_8_,
                                        MD_9_,
                                        MD_10_,};

                        // Use the array of points to construct a path.
                        GraphicsPath path = new GraphicsPath();
                        path.AddLines(points);

                        // Use the path to construct a path gradient brush.
                        PathGradientBrush pthGrBrush = new PathGradientBrush(path)
                        {

                            // Set the color at the center of the path to red.
                            CenterColor = (Color)comboBox14.SelectedItem
                        };


                        // Set the colors of the points in the array.
                        Color[] colors = {
                                    (Color)comboBox16.SelectedItem,
                                    (Color)comboBox17.SelectedItem,
                                    (Color)comboBox18.SelectedItem,
                                    (Color)comboBox19.SelectedItem,
                                    (Color)comboBox20.SelectedItem,
                                    (Color)comboBox21.SelectedItem,
                                    (Color)comboBox22.SelectedItem,
                                    (Color)comboBox23.SelectedItem,
                                    (Color)comboBox24.SelectedItem,
                                    (Color)comboBox25.SelectedItem};


                        pthGrBrush.SurroundColors = colors;

                        // Fill the path with the path gradient brush.
                        graphics.FillPath(pthGrBrush, path);

                        // Refresh.
                        pictureBox1.Refresh();
                    }

                    Clipboard.SetImage(pictureBox1.Image);

                }






            }
            catch (Exception Exclamation)
            {
                // Report about others mistakes:
                MessageBox.Show(Exclamation.Message, "Mistake",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {

                if (radioButton39.Checked)
                {



                    using (graphics = Graphics.FromImage(pictureBox1.Image))
                    {
                        graphics.SmoothingMode = SmoothingMode.AntiAlias;


                        // X,Y of system, grid

                        O_x_pix = (float)numericUpDown16.Value;

                        O_y_pix = (float)numericUpDown17.Value;

                        //Width.Hieght of squares

                        M_x = (float)numericUpDown18.Value;

                        M_y = (float)numericUpDown19.Value;





                        float step_x = (x_max - x_min) / Npoints;

                        float y_min, y_max;

                        float x_max_abs = Math.Abs(x_max);
                        if (x_max_abs < Math.Abs(x_min)) x_max_abs = Math.Abs(x_min);
                        //Промежуточные локальные переменные:
                        float x_0, y_0, x_1, y_1;// x_0_pix, y_0_pix, x_1_pix, y_1_pix;
                                                 //Расчет минимального y_min и максимального y_max
                                                 //действительных значений функции:


                        //Присваиваем y_min, y_max значение y_0
                        //для нулевой точки (i=0):
                        x_0 = x_min; y_0 = Function_of_graph(x_0);
                        y_min = y_0; y_max = y_0; int i;


                        //Организовываем цикл по всем точкам, начиная с i=1:
                        for (i = 1; i <= (Npoints - 1); i++)
                        {
                            x_1 = x_min + i * step_x;
                            y_1 = Function_of_graph(x_1);
                            //Расчет минимального и максимального значений функции:
                            if (y_min > y_1) y_min = y_1;
                            if (y_max < y_1) y_max = y_1;
                        }
                        //Т.к. в последней точке i = Npoints
                        //значение x_1 = x_min + Npoints * step_x
                        //может отличаться от заданного значения x_max

                        //(из-за накапливания погрешности в цикле), то проверяем,
                        //может быть y_min или y_max находится в последней
                        //точке при точном задании нами значения x_max:
                        x_1 = x_max; y_1 = Function_of_graph(x_1);
                        //Проверка минимального и максимального
                        //значений функции в последней точке:
                        if (y_min > y_1) y_min = y_1;
                        if (y_max < y_1) y_max = y_1;
                        //Наибольшее абсолютное значение функции y_max_abs
                        //из двух значений y_min и y_max:
                        float y_max_abs = Math.Abs(y_max);
                        if (y_max_abs < Math.Abs(y_min)) y_max_abs = Math.Abs(y_min);




                        //Строим сетку координат:
                        //Сначала строим ось абсцисс "x" от x = -1 до x = 1:
                        //Задаем абсциссу последней точки оси абсцисс "x"
                        //при x = 1:
                        float x_point_end, x_point_end_pix; x_point_end = 1;
                        x_point_end_pix = x_point_end * M_x + O_x_pix;
                        //Выбираем зеленое перо толщиной 2:



                        Pen greenPen_x = new Pen((Color)comboBox32.SelectedItem, (float)numericUpDown20.Value);





                        //Задаем координаты двух граничных точек оси:
                        PointF point1 = new PointF(-1 * M_x + O_x_pix, O_y_pix);
                        PointF point2 = new PointF(x_point_end_pix, O_y_pix);
                        //Строим линию через две заданные граничные точки:


                        graphics.DrawLine(greenPen_x, point1, point2);
                        //Строим горизонтальные линии сетки координат
                        //(кроме оси "x"):
                        //Ширина (размах) графика по оси ординат "y":
                        float span_y = y_max - y_min;
                        //Число шагов по всей высоте сетки (по оси "y"):


                        int N_step_grid_y = (int)numericUpDown15.Value;



                        //Шаг сетки в направлении оси "y"
                        //(высота всей сетки равна 2 единицам):
                        float step_grid_y, step_grid_y_pix;
                        //Преобразование типов переменных:
                        step_grid_y = (float)2 / N_step_grid_y;
                        step_grid_y_pix = step_grid_y * M_y;
                        //Выбираем красное перо толщиной 1:


                        Pen redPen = new Pen((Color)comboBox33.SelectedItem, (float)numericUpDown21.Value);




                        //Строим сетку от нулевой линии в одну сторону (вниз):
                        int j_y; float y1, y1_pix;
                        for (j_y = 1; j_y <= (N_step_grid_y / 2); j_y++)
                        {
                            y1 = j_y * step_grid_y;
                            y1_pix = O_y_pix + j_y * step_grid_y_pix;
                            //Задаем координаты двух граничных точек линии сетки:
                            PointF point3 = new PointF(-1 * M_x + O_x_pix, y1_pix);
                            PointF point4 = new PointF(x_point_end_pix, y1_pix);
                            //Строим линию через две заданные граничные точки:

                            graphics.DrawLine(redPen, point3, point4);
                        }
                        //Строим сетку от нулевой линии в другую сторону (вверх):
                        for (j_y = 1; j_y <= (N_step_grid_y / 2); j_y++)
                        {
                            y1_pix = O_y_pix - j_y * step_grid_y * M_y;
                            //Задаем координаты двух граничных точек линии сетки:
                            PointF point5 = new PointF(-1 * M_x + O_x_pix, y1_pix);
                            PointF point6 = new PointF(x_point_end_pix, y1_pix);
                            //Строим прямую линию через две заданные точки:
                            graphics.DrawLine(redPen, point5, point6);
                        }
                        //Строим ось ординат "y" от y= -1 до y = 1:
                        //Задаем ординату последней точки оси ординат "y" при y = 1:
                        float y_point_end, y_point_end_pix; y_point_end = 1;
                        y_point_end_pix = y_point_end * M_y + O_y_pix;
                        //Выбираем зеленое перо толщиной 2:


                        Pen greenPen_y = new Pen((Color)comboBox32.SelectedItem, (float)numericUpDown20.Value);




                        //Задаем координаты двух граничных точек оси:
                        PointF point7 = new PointF(O_x_pix, -1 * M_y + O_y_pix);
                        PointF point8 = new PointF(O_x_pix, y_point_end_pix);
                        //Строим линию через две заданные граничные точки:
                        graphics.DrawLine(greenPen_y, point7, point8);
                        //Строим вертикальные линии сетки координат (кроме оси "y"):

                        //Ширина (размах) графика по оси абсцисс "x":
                        float span_x = x_max - x_min;
                        //Число шагов по всей ширине сетки по обе стороны от оси y:


                        int N_step_grid_x = (int)numericUpDown15.Value;


                        //Шаг сетки в направлении оси "y"
                        //(высота всей сетки равна 2 единицам):
                        float step_grid_x, step_grid_x_pix;
                        //Преобразование типов переменных:
                        step_grid_x = (float)2 / N_step_grid_x;
                        step_grid_x_pix = step_grid_y * M_x;
                        //Выбираем красное перо толщиной 1:



                        //Шаг сетки в направлении оси "x"
                        //(ширина всей сетки равна 2 единицам):
                        //   float step_grid_x = 0.1F, step_grid_x_pix;
                        // step_grid_x_pix = step_grid_x * M_x;
                        //Выбираем красное перо толщиной 1:
                        Pen redPen_y = new Pen((Color)comboBox33.SelectedItem, (float)numericUpDown21.Value);
                        //Строим сетку от нулевой линии в одну сторону (вправо):
                        int j_x; float x1, x1_pix;
                        for (j_x = 1; j_x <= (N_step_grid_x / 2); j_x++)
                        {
                            x1 = j_x * step_grid_x;
                            x1_pix = O_x_pix + j_x * step_grid_x_pix;
                            //Задаем координаты двух граничных точек линии сетки:
                            PointF point9 = new PointF(x1_pix, -1 * M_y + O_y_pix);
                            PointF point10 = new PointF(x1_pix, y_point_end_pix);
                            //Строим линию через две заданные граничные точки:
                            graphics.DrawLine(greenPen_y, point9, point10);
                        }
                        //Строим сетку от нулевой линии в другую сторону (влево):
                        for (j_x = 1; j_x <= (N_step_grid_x / 2); j_x++)
                        {
                            x1 = j_x * step_grid_x;
                            x1_pix = O_x_pix - j_x * step_grid_x_pix;
                            //Задаем координаты двух граничных точек линии сетки:
                            PointF point11 = new PointF(x1_pix, -1 * M_y +
                            O_y_pix);
                            PointF point12 = new PointF(x1_pix, y_point_end_pix);
                            //Строим прямую линию через две заданные точки:
                            graphics.DrawLine(greenPen_y, point11, point12);
                        }

                    }

                    pictureBox1.Refresh();
                }

            }
            catch (Exception Exclamation)
            {
                // Report about others mistakes:
                MessageBox.Show(Exclamation.Message, "Mistake",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void Pen1ColorToolStripMenuItem_BackColorChanged(object sender, EventArgs e)
        {
            try
            {

                pen1.Color = pen1ColorToolStripMenuItem.BackColor;
                pen1ColorToolStripMenuItem.Invalidate();


            }
            catch (Exception Exclamation)
            {
                // Report about others mistakes:
                MessageBox.Show(Exclamation.Message, "Mistake",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


    
        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                //turn off or swich of the timer

                timer1.Enabled = !timer1.Enabled;

            }
            catch (Exception Exclamation)
            {
                // Report about others mistakes:
                MessageBox.Show(Exclamation.Message, "Mistake",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        private void ToolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                Opacity = 1;

            }
            catch (Exception Exclamation)
            {
                // Report about others mistakes:
                MessageBox.Show(Exclamation.Message, "Mistake",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                // If the opacity strp over the limit of interval then
                // 0 < Opacity < 1, some change the sign of the interval to the inverse:
                if (Opacity <= 0 || Opacity >= 1) s = -s;
                // Every 0.1 second change the norm of opacity of
                // form for s = 0.1:
                Opacity += s;

            }
            catch (Exception Исключение)
            {
                // Отчет о других ошибках:
                MessageBox.Show(Исключение.Message, "ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void BackColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //  if (colorDialog1.ShowDialog() == DialogResult.OK)
                //   BackColor = colorDialog1.Color;
                //  pictureBox1.BackColor = BackColor;

                if (colorDialog1.ShowDialog() == DialogResult.OK)
                    using (Graphics graphics = Graphics.FromImage(pictureBox1.Image))
                    {
                        graphics.Clear(pictureBox1.BackColor = colorDialog1.Color);
                    }
            }
            catch (Exception Exclamation)
            {
                // Report about others mistakes:
                MessageBox.Show(Exclamation.Message, "Mistake",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

    
     

        private void NumericUpDown1_ValueChanged_1(object sender, EventArgs e)
        {
            try
            {
                pen1.Width = (int)numericUpDown1.Value;

            }
            catch (Exception Exclamation)
            {
                // Report about others mistakes:
                MessageBox.Show(Exclamation.Message, "Mistake",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void InformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var Inf = new Form2();
                Inf.Show();

            }
            catch (Exception Exclamation)
            {
                // Report about others mistakes:
                MessageBox.Show(Exclamation.Message, "Mistake",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void ColorControlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripMenuItem PCL = sender as ToolStripMenuItem;

                //  colorDialog1.Color = PCL.BackColor;
                //  if (colorDialog1.ShowDialog() == DialogResult.OK)
                //      PCL.BackColor = colorDialog1.Color;

                PCL.BackColor = (Color)toolStripComboBox2.SelectedItem;


            }
            catch (Exception Exclamation)
            {
                // Report about others mistakes:
                MessageBox.Show(Exclamation.Message, "Mistake",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void ColorControlToolStripMenuItem_BackColorChanged(object sender, EventArgs e)
        {
            try
            {
                ToolStripMenuItem PCL = sender as ToolStripMenuItem;

                pen3.Color = PCL.BackColor;

                PCL.BackColor = (Color)toolStripComboBox2.SelectedItem;


            }
            catch (Exception Exclamation)
            {
                // Report about others mistakes:
                MessageBox.Show(Exclamation.Message, "Mistake",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // if (Clipboard.ContainsImage())
                // {
                //   Clipboard.Clear();

                Clipboard.SetImage(pictureBox1.Image);
                // }
            }
            catch (Exception Exclamation)
            {
                // Report about auther mistakes:
                MessageBox.Show(Exclamation.Message, "Mistake",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void PastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //startPt = nullPt;

                if (Clipboard.ContainsImage())

                {

                    if (pictureBox1.Image != null)
                        pictureBox1.Image.Dispose();

                    Image bm1 = Clipboard.GetImage();
                    // Make an associated Graphics object.


                    graphics = Graphics.FromImage(bm1);


                    // Display the new bitmap in the PictureBox.
                    pictureBox1.Image = bm1;


                }

            }
            catch (Exception Exclamation)
            {
                // Report about auther mistakes:
                MessageBox.Show(Exclamation.Message, "Mistake",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                throw;
            }


        }

        private void CopyScrineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SendKeys.Send("%{PRTSC}");

            }
            catch (Exception Exclamation)
            {
                // Report about auther mistakes:
                MessageBox.Show(Exclamation.Message, "Mistake",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }



        private void ToolStripButton4_Click(object sender, EventArgs e)
        {
            try
            {
                tabControl1.Visible = false;

            }
            catch (Exception Exclamation)
            {
                // Report about others mistakes:
                MessageBox.Show(Exclamation.Message, "Mistake",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }



        private void VisibleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                tabControl1.Visible = true;
            }
            catch (Exception Exclamation)
            {
                // Report about others mistakes:
                MessageBox.Show(Exclamation.Message, "Mistake",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }

        private void PictureBox1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                SendKeys.Send("%{PRTSC}");

            }
            catch (Exception Exclamation)
            {
                // Report about auther mistakes:
                MessageBox.Show(Exclamation.Message, "Mistake",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void PictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (tabControl1.Visible == true) return;
                    if ((radioButton44.BackColor == Color.Green)& (tabControl1.Visible == true) == true) return;
                // if (tabControl1.Visible == true) return;

                if (e.Button == MouseButtons.Left)
                {



                    ContrastBtmp = new Bitmap(pictureBox1.Image);

                         if (saveFileDialog1.ShowDialog() == DialogResult.OK)


                        if (saveFileDialog1.FileName.Contains(".jpeg")) ContrastBtmp.Save(saveFileDialog1.FileName, ImageFormat.Jpeg);
                        else
                                  if (saveFileDialog1.FileName.Contains(".bmp")) ContrastBtmp.Save(saveFileDialog1.FileName, ImageFormat.Bmp);
                        else
                                   if (saveFileDialog1.FileName.Contains(".gif")) ContrastBtmp.Save(saveFileDialog1.FileName, ImageFormat.Gif);
                        else
                             if (saveFileDialog1.FileName.Contains(".tiff")) ContrastBtmp.Save(saveFileDialog1.FileName, ImageFormat.Tiff);
                        else
                               if (saveFileDialog1.FileName.Contains(".png")) ContrastBtmp.Save(saveFileDialog1.FileName, ImageFormat.Png);
                        else
                            MessageBox.Show("The result image saved under " + saveFileDialog1.FileName);

                    toolStrip1.Visible = true;
                    menuStrip1.Visible = true;
                    tabControl1.Visible = true;
                    FormBorderStyle = FormBorderStyle.Fixed3D;

                }


                toolStrip1.Visible = true;
                menuStrip1.Visible = true;
                tabControl1.Visible = true;
                FormBorderStyle = FormBorderStyle.Fixed3D;




            }
            catch (Exception)
            {

                {
                    MessageBox.Show("The file " + saveFileDialog1.FileName + " has an inappropriate extension. Returning.");
                    return;



                }


            }

        }

        private void AllScrineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                toolStrip1.Visible = false;
                menuStrip1.Visible = false;
                tabControl1.Visible = false;
                FormBorderStyle = FormBorderStyle.None;

            //    radioButton44.BackColor = Color.Green;


            }
            catch (Exception Exclamation)
            {
                // Report about others mistakes:
                MessageBox.Show(Exclamation.Message, "Mistake",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

    
        private void AboutProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var AB = new AboutBox1();
                AB.Show();

            }
            catch (Exception Exclamation)
            {
                // Report about others mistakes:
                MessageBox.Show(Exclamation.Message, "Mistake",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

      


        private void ControlPointsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            try
            {
                controlPointsToolStripMenuItem.BackColor = Color.Green;

            }
            catch (Exception Exclamation)
            {
                // Report about others mistakes:
                MessageBox.Show(Exclamation.Message, "Mistake",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

           
        }

        private void ControlPointsRelaxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                controlPointsToolStripMenuItem.BackColor = Color.Red;

            }
            catch (Exception Exclamation)
            {
                // Report about others mistakes:
                MessageBox.Show(Exclamation.Message, "Mistake",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }



     

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Close();

            }
            catch (Exception Exclamation)
            {
                // Report about others mistakes:
                MessageBox.Show(Exclamation.Message, "Mistake",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        #endregion

    }
}
