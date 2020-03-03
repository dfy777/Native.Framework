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
        private const string des_folder = @"C:\tools\CQP-xiaoi\酷Q Pro\data\image\";
        private const int width = 100;
        private const int height = 100;
        private const int PRODUCE_NUM = 10;

        #endregion


        #region --属性--

        int[] Avator { get; set; }

        #endregion


        #region --构造函数--

        public CombineGraph(int [] _avator)
        {
            Avator = _avator;
        }

        #endregion


        #region --公有方法--

        public void CombineAvator()
        {
            //int[] avator = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            List<Image> image = new List<Image>();
            List<Bitmap> bitmap = new List<Bitmap>();

            for(int i = 0; i < Avator.Length; i++)
            {
                string str = Avator[i].ToString();
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
        
            for (int i = 0; i < PRODUCE_NUM/2; i++)
            {
                g1.DrawImage(bitmap[i], ptx, pty, width, height);
                ptx = ptx + width + 5;
            }

            pty = pty + height + 5;
            ptx = 0;

            for (int i = PRODUCE_NUM/2; i < PRODUCE_NUM; i++)
            {
                g1.DrawImage(bitmap[i], ptx, pty, width, height);
                ptx = ptx + width + 5;
            }

            string des_str = des_folder + "new.png";

            Image img = new_bitmap;
            img.Save(des_str);
        }

        #endregion
    }
}
