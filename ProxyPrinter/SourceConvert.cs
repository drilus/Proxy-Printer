using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;

namespace octgnPicTest
{
    class SourceConvert
    {

        public static System.Drawing.Bitmap BitmapFromUri(Uri uri)
        {
            BitmapImage src = new BitmapImage();
            src.BeginInit();
            src.UriSource = uri;
            src.CacheOption = BitmapCacheOption.OnLoad;
            src.EndInit();
            return BitmapSourceToBitmap(src);
        }

        public static System.Drawing.Bitmap BitmapSourceToBitmap(BitmapSource srs)
        {
            System.Drawing.Bitmap temp = null;
            System.Drawing.Bitmap result;
            System.Drawing.Graphics g;
            int width = srs.PixelWidth;
            int height = srs.PixelHeight;
            int stride = width * ((srs.Format.BitsPerPixel + 7) / 8);
            byte[] bits = new byte[height * stride];
            srs.CopyPixels(bits, stride, 0);
            unsafe
            {
                fixed (byte* pB = bits)
                {
                    IntPtr ptr = new IntPtr(pB);
                    temp = new System.Drawing.Bitmap(width, height, stride, System.Drawing.Imaging.PixelFormat.Format32bppPArgb, ptr);
                }
            }
            // Copy the image back into a safe structure
            result = new System.Drawing.Bitmap(width, height);
            g = System.Drawing.Graphics.FromImage(result);
            g.DrawImage(temp, 0, 0);
            g.Dispose();
            return result;
        }


    }
}
