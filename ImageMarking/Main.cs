using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageMarking
{
    public struct ObjectData
    {
        public int xMin, yMin;
        public int xMax, yMax;
        public string name;
        
        public ObjectData(int _xMin, int _yMin, int _xMax, int _yMax, string _name)
        {
            xMin = _xMin;
            yMin = _yMin;
            xMax = _xMax;
            yMax = _yMax;
            name = _name;
        }
    }

    public partial class Main : Form
    {
        protected DataKeeper data;
        protected Bitmap bmp, bm;
        protected bool IsSelecting;
        protected int X0, Y0, X1, Y1;

        public Main(string path)
        {
            InitializeComponent();
            data = new DataKeeper(path);
            NextImage();
           
        }

        private void Add_Click(object sender, EventArgs e)
        {
            comboObjName.Items.Add(objName.Text);
        }

        void NextImage()
        {
            bmp = new Bitmap(data.Next());
            Images.Image = bmp;
            Images.Width = bmp.Width;
            Images.Height = bmp.Height;
            Images.Show();

            //for xml data
            data.ImgWidth = bmp.Width;
            data.ImgHeight = bmp.Height;
        }

        private void Next_Click(object sender, EventArgs e)
        {
            if(data.Empty)
            {
                MessageBox.Show("Marking done");
                data.CreateTxtData();
                this.Close();
            }
            else
                NextImage();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            data.Parse();
            Next_Click(sender, e);
        }

        private void Select_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(bm);
            data.SetData(new ObjectData(X0, Y0, X1, Y1, comboObjName.Text));
        }

        private void Images_MouseUp(object sender, MouseEventArgs e)
        {
            // Do nothing it we're not selecting an area.
            if (!IsSelecting) return;
            IsSelecting = false;

            Point firstLocation = new Point(X0, Y0);
            

            using (Graphics graphics = Graphics.FromImage(bm))
            {
                using (Font arialFont = new Font("Arial", 10))
                {
                    graphics.DrawString(comboObjName.Text, arialFont, Brushes.Blue, firstLocation);
                }
            }

            // Display the original image.
            Images.Image = bm;
        }

        private void Images_MouseMove(object sender, MouseEventArgs e)
        {
            // Do nothing it we're not selecting an area.
            if (!IsSelecting) return;

            // Save the new point.
            X1 = e.X;
            Y1 = e.Y;

            // Make a Bitmap to display the selection rectangle.
            bm = new Bitmap(bmp); //bmp - OriginalImage

            // Draw the rectangle.
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.DrawRectangle(Pens.Red,
                    Math.Min(X0, X1), Math.Min(Y0, Y1),
                    Math.Abs(X0 - X1), Math.Abs(Y0 - Y1));
            }

            // Display the temporary bitmap.
            Images.Image = bm; //picOriginal
        }

        private void Images_MouseDown(object sender, MouseEventArgs e)
        {
            IsSelecting = true;

            // Save the start point.
            X0 = e.X;
            Y0 = e.Y;
        }
    }
}
