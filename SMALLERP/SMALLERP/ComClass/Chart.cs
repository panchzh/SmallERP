using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace SMALLERP.ComClass
{
    public class Chart
    {
        /// <summary>
        ///   生成饼型图
        /// </summary>
        /// <param name="title"> 主标题 </param>
        /// <param name="subTitle"> 子标题 </param>
        /// <param name="width"> 位图的宽度 </param>
        /// <param name="height"> 位图的高度 </param>
        /// <param name="dt"> 数据源 </param>
        /// <param name="ColumnIndex"> 计算数据比例的列索引 </param>
        /// <returns> Image实例的引用 </returns>
        public Image CreatePieChart(string title, string subTitle, int width, int height, DataTable dt, int ColumnIndex)
        {
            const int SIDE_LENGTH = 400;
            const int PIE_DIAMETER = 200;
            //计算饼形图的计算总数值
            float sumData = 0;
            foreach (DataRow dr in dt.Rows)
            {
                sumData += Convert.ToSingle(dr[ColumnIndex]);
            }
            //创建位图及画布
            Bitmap bm = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bm);
            //设置g对象
            g.ScaleTransform((Convert.ToSingle(width))/SIDE_LENGTH, (Convert.ToSingle(height))/SIDE_LENGTH);
            g.SmoothingMode = SmoothingMode.Default;
            g.TextRenderingHint = TextRenderingHint.AntiAlias;
            //填充画布颜色，及描绘画布边框
            g.Clear(Color.White);
            g.DrawRectangle(Pens.Black, 0, 0, SIDE_LENGTH - 1, SIDE_LENGTH - 1);
            //饼型图的主标题
            g.DrawString(title, new Font("Tahoma", 14), Brushes.Black, new PointF(5, 5));
            //饼形图的子标题
            g.DrawString(subTitle, new Font("Tahoma", 10), Brushes.Black, new PointF(7, 35));
            //绘制饼形图
            float curAngle = 0;
            float totalAngle = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                curAngle = Convert.ToSingle(dt.Rows[i][ColumnIndex])/sumData*360;
                g.FillPie(new SolidBrush(GetChartItemColor(i)), 100, 65, PIE_DIAMETER, PIE_DIAMETER, totalAngle,
                          curAngle);
                g.DrawPie(Pens.Black, 100, 65, PIE_DIAMETER, PIE_DIAMETER, totalAngle, curAngle);
                totalAngle += curAngle;
            }
            //绘制饼形图的说明区域
            g.DrawRectangle(Pens.Black, 200, 300, 199, 99);
            g.DrawString("图表说明", new Font("Tahoma", 12, FontStyle.Bold), Brushes.Black, new PointF(200, 300));
            //绘制说明区域内部的详细信息
            PointF boxOrigin = new PointF(210, 330);
            PointF textOrigin = new PointF(235, 326);

            float percent = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                g.FillRectangle(new SolidBrush(GetChartItemColor(i)), boxOrigin.X, boxOrigin.Y, 20, 10);
                g.DrawRectangle(Pens.Black, boxOrigin.X, boxOrigin.Y, 20, 10);
                percent = Convert.ToSingle(dt.Rows[i][ColumnIndex])/sumData*100;
                g.DrawString(dt.Rows[i][1] + "—" + dt.Rows[i][2] + "(" + percent.ToString("0") + "%)",
                             new Font("Tahoma", 10), Brushes.Black, textOrigin);
                boxOrigin.Y += 15;
                textOrigin.Y += 15;
            }
            //释放资源，同时返回绘制的饼形图
            g.Dispose();
            return bm;
        }

        /// <summary>
        ///   为饼形图的扇区设置颜色
        /// </summary>
        /// <param name="itemIndex"> 某个扇区对应的数据行的索引 </param>
        /// <returns> Color实例的引用 </returns>
        private Color GetChartItemColor(int itemIndex)
        {
            Color selectedColor;

            switch (itemIndex)
            {
                case 0:

                    selectedColor = Color.Blue;
                    break;

                case 1:

                    selectedColor = Color.Red;
                    break;

                case 2:

                    selectedColor = Color.Yellow;
                    break;

                case 3:

                    selectedColor = Color.Purple;
                    break;

                case 4:

                    selectedColor = Color.Beige;
                    break;

                case 5:

                    selectedColor = Color.DarkCyan;
                    break;

                case 6:

                    selectedColor = Color.Crimson;
                    break;

                case 7:

                    selectedColor = Color.Chocolate;
                    break;

                default:

                    selectedColor = Color.Green;
                    break;
            }

            return selectedColor;
        }
    }
}