using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace text1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Bitmap origin;
        private void open_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image != null) pictureBox2.Image = null;
            OpenFileDialog ofd = new OpenFileDialog();//定义一个打开文件类
            ofd.Filter = "所有图像文件 | *.bmp; *.pcx; *.png; *.jpg; *.gif;" +
                "*.tif; *.ico; *.dxf; *.cgm; *.cdr; *.wmf; *.eps; *.emf|" +
                "位图( *.bmp; *.jpg; *.png;...) | *.bmp; *.pcx; *.png; *.jpg; *.gif; *.tif; *.ico|" +
                "矢量图( *.wmf; *.eps; *.emf;...) | *.dxf; *.cgm; *.cdr; *.wmf; *.eps; *.emf";
            ofd.FilterIndex = 2; //打开文件的对话框将弹出，供使用者选择
            if (ofd.ShowDialog() == DialogResult.OK) //如果选择了某个文件，并点击了OK后，那么将选择的文件返回
            {
                pictureBox1.Image = System.Drawing.Image.FromFile(ofd.FileName.ToString());//将图像文件赋给图片框“pictureBox1”
                //pictureBox1.Width = pictureBox1.Image.Width; //设定图片框的宽度与图片一致
                //pictureBox1.Height = pictureBox1.Image.Height; //设定图片框的高度与图片一致
                 origin = new Bitmap(pictureBox1.Image);
            }
        }

        private void 直方图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("错误，没有导入图片！");
                return;
            }
            Bitmap bt;
            bt = new Bitmap(pictureBox1.Image);
            histForm histoGram = new histForm(bt);
            histoGram.ShowDialog();
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            textBox1 .Text = trackBar1.Value.ToString();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            textBox2.Text = trackBar2.Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("错误，没有导入图片！");
                return;
            }
            Color ColorOrigin = new Color();//定义一个色彩变量对象
            double Red, Green, Blue, Y; //定义红、绿、蓝三色和亮度
            Bitmap Bmp1;
            Bmp1 = new Bitmap(origin);
            int brightThreshole = new int();//定义整型的二值化阈值
            brightThreshole = trackBar1.Value; //根据滑动条的大小给该阈值赋值，也可以直接赋值
            for (int i = 0; i <= Bmp1.Width - 1; i++)
            {
                for (int j = 0; j <= Bmp1.Height - 1; j++)//循环处理图像中的每一个像素点
                {
                    ColorOrigin = Bmp1.GetPixel(i, j); //获取当前像素点的色彩信息
                    Red = ColorOrigin.R; //获取当前像素点的红色分量
                    Green = ColorOrigin.G; //获取当前像素点的绿色分量
                    Blue = ColorOrigin.B; //获取当前像素点的蓝色分量
                    Y = 0.59 * Red + 0.3 * Green + 0.11 * Blue; //计算当前像素点的亮度
                    if (Y > brightThreshole) //如果当前像素点的亮度大于指定阈值
                    {
                        Color ColorProcessed = Color.FromArgb(255, 255, 255); //那么定义一个纯白的色彩变量，即各分量均为255
                        Bmp1.SetPixel(i, j, ColorProcessed); //将白色变量赋给当前像素点
                    }
                    if (Y <= brightThreshole) //如果当前像素点的亮度小于指定阈值
                    {
                        Color ColorProcessed = Color.FromArgb(0, 0, 0); //那么定义一个纯黑的色彩变量，即各分量均为0
                        Bmp1.SetPixel(i, j, ColorProcessed); //将黑色变量赋给当前像素点
                    }
                }
                

                pictureBox1.Refresh();//刷新图片框
                pictureBox1.Image = Bmp1; //将重新生成的图片赋值给图片框
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("错误，没有导入图片！");
                return;
            }
            Color ColorOrigin = new Color();//定义一个色彩变量对象
            double Red, Green, Blue, Y; //定义红、绿、蓝三色和亮度
            Bitmap Bmp1;
            Bmp1 = new Bitmap(origin);
            int brightThreshole = new int();//定义整型的二值化阈值
            brightThreshole = trackBar2.Value; //根据滑动条的大小给该阈值赋值，也可以直接赋值
            for (int i = 0; i <= Bmp1.Width - 1; i++)
            {
                for (int j = 0; j <= Bmp1.Height - 1; j++)//循环处理图像中的每一个像素点
                {
                    ColorOrigin = Bmp1.GetPixel(i, j); //获取当前像素点的色彩信息
                    Red = ColorOrigin.R; //获取当前像素点的红色分量
                    Green = ColorOrigin.G; //获取当前像素点的绿色分量
                    Blue = ColorOrigin.B; //获取当前像素点的蓝色分量
                    Y = 0.59 * Red + 0.3 * Green + 0.11 * Blue; //计算当前像素点的亮度
                    if (Y > brightThreshole) //如果当前像素点的亮度大于指定阈值
                    {
                        Color ColorProcessed = Color.FromArgb(255, 255, 255); //那么定义一个纯白的色彩变量，即各分量均为255
                        Bmp1.SetPixel(i, j, ColorProcessed); //将白色变量赋给当前像素点
                    }
                    if (Y <= brightThreshole) //如果当前像素点的亮度小于指定阈值
                    {
                        Color ColorProcessed = Color.FromArgb(0, 0, 0); //那么定义一个纯黑的色彩变量，即各分量均为0
                        Bmp1.SetPixel(i, j, ColorProcessed); //将黑色变量赋给当前像素点
                    }
                }
                pictureBox2.Refresh();//刷新图片框
                pictureBox2.Image = Bmp1; //将重新生成的图片赋值给图片框
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("错误，没有导入图片！");
                return;
            }
            Bitmap bt1;
            bt1 = new Bitmap(pictureBox2.Image);
            int Binaryzation(Color color)
            {
                int a = (int)(color.R + color.G + color.B)/3;
                a = a > 128 ? 255 : 0;
                return a;
            }
            int width = bt1.Width;
            int height = bt1.Height;
            double pixelnum = 0;
            for (int x = 1; x < width - 1; x++)
            {
                for (int y = 1; y < height - 1; y++)
                {
                    int a = Binaryzation(bt1.GetPixel(x, y));
                    if (a == 255)
                    {
                        
                            pixelnum++;
                        
                        
                    }
                }
            }
            double cankao = new double();
            cankao =  Convert.ToDouble(textBox3.Text);
            double pixelm = new double();
            pixelm = cankao / pixelnum;
            /*
            Bitmap bt2;
            bt2 = new Bitmap(pictureBox1.Image);
            int Binaryzation1(Color color)
            {
                int a0 = (int)(0.7 * color.R + 0.2 * color.G + 0.1 * color.B);
                a0 = a0 > 128 ? 255 : 0;
                return a0;
            }
            int width1 = bt2.Width;
            int height1 = bt2.Height;
            double pixelnum1 = 0;
            for (int x1 = 1; x1 < width1 - 1; x1++)
            {
                for (int y1 = 1; y1 < height1 - 1; y1++)
                {
                    int a0 = Binaryzation1(bt1.GetPixel(x1, y1));
                    if (a0 == 0)
                    {
                        int a1 = Binaryzation1(bt1.GetPixel(x1, y1));

                        if (a0 == 0)
                        {
                            pixelnum1++;
                        }

                    }
                }
            }
            double jieguo = new double();
            jieguo = pixelm * pixelnum1;*/
            textBox4.Text = pixelm.ToString();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("错误，没有导入图片！");
                return;
            }
            Bitmap bt2;
            bt2 = new Bitmap(pictureBox1.Image);
            int Binaryzation(Color color)
            {
                int a = (int)(0.7 * color.R + 0.2 * color.G + 0.1 * color.B);
                a = a > 128 ? 255 : 0;
                return a;
            }
            int width1 = bt2.Width;
            int height1 = bt2.Height;
            double pixelnum1 = 0;
            for (int x1 = 1; x1 < width1 - 1; x1++)
            {
                for (int y1 = 1; y1 < height1 - 1; y1++)
                {
                    int a = Binaryzation(bt2.GetPixel(x1, y1));
                    if (a == 0)
                    {
                        
                            pixelnum1++;
                        

                    }
                }
            }

            double jieguo = new double();
            double pixelm = new double();
            pixelm = Convert.ToDouble(textBox4.Text);
            
            jieguo = pixelm * pixelnum1 ;
            textBox5.Text = jieguo.ToString();
        }
        //膨胀函数
        private void BinaryDilation()//二值图像的膨胀函数(膨胀白色)
        {
            Bitmap bt1;
            Bitmap bt2;
            
                bt1 = new Bitmap(pictureBox1.Image);
                bt2 = new Bitmap(pictureBox1.Image);
            
            int R;
            for (int i = 1; i < bt1.Width - 1; i++)
            {
                for (int j = 1; j < bt1.Height - 1; j++)
                {
                    R = bt1.GetPixel(i, j).R;
                    if (R == 255)
                    {
                        bt2.SetPixel(i, j, Color.FromArgb(255, 255, 255));
                        bt2.SetPixel(i - 1, j - 1, Color.FromArgb(255, 255, 255));
                        bt2.SetPixel(i, j - 1, Color.FromArgb(255, 255, 255));
                        bt2.SetPixel(i + 1, j - 1, Color.FromArgb(255, 255, 255));
                        bt2.SetPixel(i - 1, j, Color.FromArgb(255, 255, 255));
                        bt2.SetPixel(i + 1, j, Color.FromArgb(255, 255, 255));
                        bt2.SetPixel(i - 1, j + 1, Color.FromArgb(255, 255, 255));
                        bt2.SetPixel(i, j + 1, Color.FromArgb(255, 255, 255));
                        bt2.SetPixel(i + 1, j + 1, Color.FromArgb(255, 255, 255));
                    }
                }
                pictureBox1.Refresh();//刷新图片框
                pictureBox1.Image = bt2;
            }
        }
        //膨胀函数end


        //腐蚀函数
        private void BinaryErosion()//二值图像的腐蚀函数(腐蚀白色)
        {
            Bitmap bt1;
            Bitmap bt2;
           
                bt1 = new Bitmap(pictureBox1.Image);
                bt2 = new Bitmap(pictureBox1.Image);
           
            int R1, R2, R3;
            for (int i = 0; i < bt1.Width - 1; i++)
            {
                for (int j = 0; j < bt1.Height - 1; j++)
                {
                    R1 = bt1.GetPixel(i, j).R;
                    if (R1 == 255)
                    {
                        R2 = bt1.GetPixel(i, j + 1).R;
                        R3 = bt1.GetPixel(i + 1, j).R;
                        if (R2 == 255 && R3 == 255)
                        {
                            bt2.SetPixel(i, j, Color.FromArgb(255, 255, 255));
                        }
                        else
                        {
                            bt2.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                        }
                    }
                }
                pictureBox1.Refresh();//刷新图片框
                pictureBox1.Image = bt2;
            }
        }
        //腐蚀函数end
        private void 膨胀ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("错误，没有导入图片！");//判断图片框是否有图片，如果无图片，则给出错误信息
                return;
            }
            BinaryDilation();
        }

        private void 腐蚀ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("错误，没有导入图片！");//判断图片框是否有图片，如果无图片，则给出错误信息
                return;
            }
            BinaryErosion();
        }

        private void 中值滤波ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("错误，没有导入图片！");
                return;
            }
            Color c = new Color();
            Bitmap bt1;
            Bitmap bt2;
           
                bt1 = new Bitmap(pictureBox1.Image);
                bt2 = new Bitmap(pictureBox1.Image);
            
            int rr, r1, dm, m;
            //设置一个数组用于储存3×3像素快的r分量值
            int[] dt = new int[20];
            for (int i = 1; i < bt1.Width - 1; i++)
            {
                for (int j = 1; j < bt1.Height - 1; j++)
                {
                    rr = 0; m = 0;
                    for (int k = -1; k < 2; k++)
                    {
                        for (int n = -1; n < 2; n++)
                        {
                            //获取该坐标的像素并存入数组dt[]中
                            c = bt1.GetPixel(i + k, j + n);
                            r1 = c.R;
                            dt[m++] = r1;
                        }
                    }
                    for (int p = 0; p < m - 1; p++)
                    {
                        for (int q = p + 1; q < m; q++)
                        {
                            //对存与数组里的数据进行从大到小的排序
                            if (dt[p] > dt[q])
                            {
                                dm = dt[p];
                                dt[p] = dt[q];
                                dt[q] = dm;
                            }
                        }
                    }
                    //获取数值所有存储数据的中间值
                    rr = dt[(int)(m / 2)];
                    bt2.SetPixel(i, j, Color.FromArgb(rr, rr, rr));
                }
                pictureBox1.Refresh();
                pictureBox1.Image = bt2;
            }
        }
    }
}
