using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace com.dfy.demo.Code
{

    public class CombineGraph
    {
        #region --字段--

        private const string folder = @"C:\Projects\avator\";
        private const int width = 100;
        private const int height = 100;

        #endregion

        #region --构造函数--

        public CombineGraph()
        {

        }

        #endregion

        public void CombineAvator()
        {
            int[] avator = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            List<Image> image = new List<Image>();
            List<Bitmap> bitmap = new List<Bitmap>();

            for(int i = 0; i < avator.Length; i++)
            {
                string str = avator[i].ToString();
                str = folder + str + ".png";

                image.Add(Image.FromFile(str));
                bitmap.Add(new Bitmap(image[i]));
            }

            int map_width = (width + 5) * 5 - 5;
            int map_height = (height + 5) * 2 - 5;

            Bitmap new_bitmap = new Bitmap(map_width, map_height);
            Graphics g1 = Graphics.FromImage(new_bitmap);
            g1.FillRectangle(Brushes.White, new Rectangle(0, 0, map_width, map_height));

            int ptx = 0;
            int pty = 0;
        
            for (int i = 0; i < 5; i++)
            {
                g1.DrawImage(bitmap[i], ptx, pty, width, height);
                ptx = ptx + width + 5;
            }

            pty = pty + height + 5;
            ptx = 0;

            for (int i = 5; i < 10; i++)
            {
                g1.DrawImage(bitmap[i], ptx, pty, width, height);
                ptx = ptx + width + 5;
            }

            string str1 = folder + "new.png";

            Image img = new_bitmap;
            img.Save(str1);
            img.Dispose();
        }
    }
}
