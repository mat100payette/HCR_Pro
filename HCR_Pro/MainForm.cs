using AForge.Imaging;
using AForge.Imaging.Filters;
using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace HCR_Pro
{
    public partial class MainForm : Form
    {
        private string fileName = "";

        private int gaussianSigma = 3, gaussianKernel = 11, prethreshold = 200, threshold = 245;
        private Bitmap preprocessCopy;

        private Point firstPoint = new Point(int.MaxValue, 0);
        private Stack<Tuple<Point, Point>> splits = new Stack<Tuple<Point, Point>>();

        private Pen splitPen = new Pen(Color.White, 2);

        public MainForm()
        {
            InitializeComponent();
        }

        private void loadImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Image";
                dlg.Filter = "Image Files (*.png *.jpg *.bmp) |*.png; *.jpg; *.bmp";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    splits.Clear();
                    firstPoint = new Point(int.MaxValue, 0);
                    fileName = dlg.FileName;
                    PreProcess();
                }
            }
        }

        private void PreProcess()
        {
            using (Bitmap img = new Image<Gray, byte>(new Bitmap(fileName)).Bitmap)
            {
                if (pictureBox1.Image != null) pictureBox1.Image.Dispose();
                pictureBox1.Image = Clone(img);

                Threshold filterPreThreshold = new Threshold(prethreshold);
                using (Bitmap imgPreBinarized = filterPreThreshold.Apply(img))
                {
                    GaussianBlur filterGaussian = new GaussianBlur(gaussianSigma, gaussianKernel);
                    using (Bitmap imgGaussian = filterGaussian.Apply(imgPreBinarized))
                    {
                        Threshold filterThreshold = new Threshold(threshold);
                        using (Bitmap imgBinarized = filterThreshold.Apply(imgGaussian))
                        {
                            Invert filterInvert = new Invert();
                            using (Bitmap imgInverted = filterInvert.Apply(imgBinarized))
                            {
                                using (Bitmap rgbInverted = new Bitmap(imgInverted.Width, imgInverted.Height, PixelFormat.Format32bppPArgb))
                                {
                                    using (Graphics gr = Graphics.FromImage(rgbInverted))
                                    {
                                        gr.DrawImage(imgInverted, new Rectangle(0, 0, rgbInverted.Width, rgbInverted.Height));
                                    }

                                    if (preprocessCopy != null) preprocessCopy.Dispose();
                                    preprocessCopy = Clone(rgbInverted);

                                    ComputeBlobs();
                                }
                            }
                        }
                    }
                }
            }
        }
        
        private void ComputeBlobs(bool applySplits = true)
        {
            ConnectedComponentsLabeling filterConnected = new ConnectedComponentsLabeling();
            using (Bitmap imgColored = filterConnected.Apply(ApplySplits()))
            {
                BlobCounter blobCounter = new BlobCounter();
                blobCounter.ObjectsOrder = ObjectsOrder.XY;
                blobCounter.ProcessImage(imgColored);
                Blob[] blobs = blobCounter.GetObjects(imgColored, false);

                foreach (Blob b in blobs.Take(3))
                {
                    b.Image.ToManagedImage();
                }

                if (pictureBox.Image != null) pictureBox.Image.Dispose();
                pictureBox.Image = Clone(imgColored);
                
                if (pictureBox1.Image != null) pictureBox1.Image.Dispose();
                pictureBox1.Image = Clone(imgColored);
            }
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (pictureBox.Image != null)
            {
                if (firstPoint.X == int.MaxValue)
                {
                    firstPoint = new Point(e.X, e.Y);
                }
                else
                {
                    splits.Push(new Tuple<Point, Point>(firstPoint, e.Location));
                    firstPoint.X = int.MaxValue;
                    ComputeBlobs();
                    pictureBox.Refresh();
                }
            }
        }

        private Bitmap ApplySplits()
        {
            Bitmap blankImg = new Bitmap(preprocessCopy.Width, preprocessCopy.Height, preprocessCopy.PixelFormat);
            using (Graphics g = Graphics.FromImage(blankImg))
            {
                g.FillRectangle(Brushes.Black, 0, 0, blankImg.Width, blankImg.Height);
                foreach (Tuple<Point, Point> line in splits)
                {
                    g.DrawLine(splitPen, line.Item1, line.Item2);
                }
            }
            Subtract sub = new Subtract(blankImg);
            
            return sub.Apply(preprocessCopy);
        }

        private Bitmap GetStitchLayer()
        {
            Bitmap img = new Bitmap(pictureBox.Image.Width, pictureBox.Image.Height);
            using (Graphics g = Graphics.FromImage(img))
            {
                foreach (Tuple<Point, Point> line in splits)
                {
                    g.DrawLine(splitPen, line.Item1, line.Item2);
                }
            }
            return img;
        }

        private void tb_PreThresh_ValueChanged(object sender, EventArgs e)
        {
            prethreshold = tb_PreThresh.Value;
            lbl_PreThreshVal.Text = tb_PreThresh.Value.ToString();
            if (pictureBox.Image != null)
                PreProcess();
        }

        private void btn_Undo_Click(object sender, EventArgs e)
        {
            if (splits.Count > 0)
            {
                Tuple<Point, Point> line = splits.Pop();
                pictureBox.Refresh();
                // Optimized way
                /*pictureBox.Invalidate(new Region(new Rectangle(Math.Min(line.Item1.X, line.Item2.X), Math.Min(line.Item1.Y, line.Item2.Y), 
                    Math.Abs(line.Item1.X - line.Item2.X), Math.Abs(line.Item1.Y - line.Item2.Y))));*/
            }
        }

        private void tb_Kernel_ValueChanged(object sender, EventArgs e)
        {
            gaussianKernel = tb_Kernel.Value;
            lbl_KernelVal.Text = tb_Kernel.Value.ToString();
            if (pictureBox.Image != null)
                PreProcess();
        }

        private void tb_Sigma_ValueChanged(object sender, EventArgs e)
        {
            gaussianSigma = tb_Sigma.Value;
            lbl_SigmaVal.Text = tb_Sigma.Value.ToString();
            if (pictureBox.Image != null)
                PreProcess();
        }

        public static T Clone<T>(T source)
        {
            if (!typeof(T).IsSerializable)
            {
                throw new ArgumentException("The type must be serializable.", "source");
            }

            // Don't serialize a null object, simply return the default for that object
            if (Object.ReferenceEquals(source, null))
            {
                return default(T);
            }

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();
            using (stream)
            {
                formatter.Serialize(stream, source);
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }
        }
    }
}
