using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace HCR_Pro
{
    public static class ImgExtensions
    {
        /// <summary>
        /// Resize the image to the specified width and height.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        public static Bitmap ResizeImage(this Bitmap image, int width, int height)
        {
            Rectangle destRect = new Rectangle(0, 0, width, height);
            Bitmap destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (Graphics graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (ImageAttributes wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        public static Image ProcessImage(this Bitmap image)
        {
            Bitmap b = new Bitmap(image);

            BitmapData bData = b.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadWrite, b.PixelFormat);

            /*the size of the image in bytes */
            int size = bData.Stride * bData.Height;
            int nbPixels = bData.Width * bData.Height;
            Debug.WriteLine(bData.Stride + " " + bData.Width);

            /*Allocate buffer for image*/
            byte[] data = new byte[size];

            /*This overload copies data of /size/ into /data/ from location specified (/Scan0/)*/
            Marshal.Copy(bData.Scan0, data, 0, size);

            bool isShape = false;
            for (int i = 0; i < nbPixels; i++)
            {
                int loc = i * 4;
                // There is color
                if (!(data[loc] == 0 && data[loc + 1] == 0 && data[loc + 2] == 0))
                {
                    if (!isShape)
                    {
                        data[loc] = 255;
                        data[loc + 1] = 255;
                        data[loc + 2] = 255;
                    }
                    isShape = true;
                }
                // There is no color
                else
                {
                    if (isShape)
                    {
                        int pLoc = loc - 4;
                        data[pLoc] = 255;
                        data[pLoc + 1] = 255;
                        data[pLoc + 2] = 255;
                    }
                    isShape = false;
                }
            }

            /* This override copies the data back into the location specified */
            Marshal.Copy(data, 0, bData.Scan0, data.Length);

            b.UnlockBits(bData);

            return b;
        }
    }
}
