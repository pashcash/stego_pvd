using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StegoPVD_Wu_Tsai
{
    public partial class Form1 : Form
    {
        List<int> pixels;
        string msg;
        string decode_msg;
        Image image;

        public Form1()
        {
            InitializeComponent();
            msg = "";
            decode_msg = "";
            pixels = new List<int> { };
        }

        public void ImgToGrayscale()
        {
            Bitmap c = new Bitmap(ImagePathTextBox.Text);
            Bitmap stego_image = new Bitmap(c.Width, c.Height, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
            int x, y;
            for (x = 0; x < c.Height; x++)
            {
                for (y = 0; y < c.Width; y++)
                {
                    Color pixelColor = c.GetPixel(y, x);
                    int avg = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                    pixels.Add(avg);
                    stego_image.SetPixel(y, x, Color.FromArgb(avg,avg,avg));
                }
            }
            image = stego_image;
        }

        public void TextToBinary()
        {
            string temp = EncryptMsgTextBox.Text;
            for (int i = 0; i < temp.Length; i++)
            {
                string tmp = Convert.ToString(Convert.ToInt32(temp[i]), 2);
                int bound = 8 - tmp.Length;
                for (int j = 0; j < bound; j++)
                {
                    tmp = "0" + tmp;
                }
                msg += tmp;
            }
        }

        public int [] EncryptPVD(int PixelLeft, int PixelRight, int i)
        {
            int DI = PixelRight - PixelLeft;
            int lower = LowerWidth(DI)[0];
            int width = LowerWidth(DI)[1];
            int upper = lower + width - 1;
            int len = (msg.Length - i >= (int) Math.Log(width, 2)) ? (int)Math.Log(width, 2) : msg.Length - i;
            if (LeftRightPixels(DI, PixelLeft, PixelRight, upper - DI)[0] >= 0 && LeftRightPixels(DI, PixelLeft, PixelRight, upper - DI)[0] <= 255)
            {
                if (LeftRightPixels(DI, PixelLeft, PixelRight, upper - DI)[1] >= 0 && LeftRightPixels(DI, PixelLeft, PixelRight, upper - DI)[1] <= 255)
                {
                    int DI2 = newD(DI, lower, Convert.ToInt32(msg.Substring(i, len), 2));
                    PixelLeft = LeftRightPixels(DI, PixelLeft, PixelRight, DI2 - DI)[0];
                    PixelRight = LeftRightPixels(DI, PixelLeft, PixelRight, DI2 - DI)[1];
                    i += len;
                }
            }
            int[] result = { PixelLeft, PixelRight, i };
            return result;
        }

        public int newD(int d, int lower, int b)
        {
            if (d >= 0)
            {
                return b + lower;
            }
            else
            {
                return -(b + lower);
            }
        }

        public void EncryptMessage()
        {
            TextToBinary();
            int j = 0;
            for (int i = 0; i < (image.Width * image.Height) / 2; i += 2)
            {
                int[] newPixels = EncryptPVD(pixels[i], pixels[i + 1], j);
                pixels[i] = newPixels[0];
                pixels[i + 1] = newPixels[1];
                j = newPixels[2];
                if (j == msg.Length)
                {
                    i = (image.Width * image.Height) / 2;
                }
            }
        }

        public int[] LowerWidth(int DI)
        {
            DI = Math.Abs(DI);
            int[] LowerWidth = new int[2];
            if (DI >= 0 && DI <= 7)
            {
                LowerWidth[0] = 0;
                LowerWidth[1] = 8;
            }
            else if (DI >= 8 && DI <= 15)
            {
                LowerWidth[0] = 8;
                LowerWidth[1] = 8;
            }
            else if (DI >= 16 && DI <= 31)
            {
                LowerWidth[0] = 16;
                LowerWidth[1] = 16;
            }
            else if (DI >= 32 && DI <= 63)
            {
                LowerWidth[0] = 32;
                LowerWidth[1] = 32;
            }
            else if (DI >= 64 && DI <= 127)
            {
                LowerWidth[0] = 64;
                LowerWidth[1] = 64;
            }
            else if (DI >= 128 && DI <= 255)
            {
                LowerWidth[0] = 128;
                LowerWidth[1] = 128;
            }
            return LowerWidth;
        }

        public int[] LeftRightPixels(int d, int PixelLeft, int PixelRight, int m)
        {
            int[] LeftRightPixels = new int[2];
            if (d % 2 == 1)
            {
                LeftRightPixels[0] = PixelLeft - (int)Math.Ceiling(m / 2f);
                LeftRightPixels[1] = PixelRight + (int)Math.Floor(m / 2f);
            }
            else
            {
                LeftRightPixels[0] = PixelLeft - (int)Math.Floor(m / 2f);
                LeftRightPixels[1] = PixelRight + (int)Math.Ceiling(m / 2f);
            }
            return LeftRightPixels;
        }

        public int DecryptPVD(int PixelLeft, int PixelRight, int i)
        {
            int DI = PixelRight - PixelLeft;
            int lower = LowerWidth(DI)[0];
            int width = LowerWidth(DI)[1];
            int upper = lower + width - 1;
            if (LeftRightPixels(DI, PixelLeft, PixelRight, upper - DI)[0] >= 0 && LeftRightPixels(DI, PixelLeft, PixelRight, upper - DI)[0] <= 255)
            {
                if (LeftRightPixels(DI, PixelLeft, PixelRight, upper - DI)[1] >= 0 && LeftRightPixels(DI, PixelLeft, PixelRight, upper - DI)[1] <= 255)
                {
                    int b = (msg.Length - i >= (int)Math.Log(width, 2)) ? (int)Math.Log(width, 2) : msg.Length - i;
                    int b2 = newB(DI, lower);
                    string decode_msg_temp = Convert.ToString(b2, 2);
                    while (decode_msg_temp.Length < b)
                    {
                        decode_msg_temp = "0" + decode_msg_temp;
                    }
                    i += b;
                    decode_msg += decode_msg_temp;
                }
            }
            return i;
        }

        public int newB(int DI, int lower)
        {
            if (DI>=0)
            {
                return DI - lower;
            }
            else
            {
                return -DI - lower;
            }
        }

        public void SetImage()
        {
            Bitmap stego_image = new Bitmap(image.Width, image.Height, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
            int index = 0;
            for (int x = 0; x < stego_image.Height; x++)
            {
                for (int y = 0; y < stego_image.Width; y++)
                {
                    stego_image.SetPixel(y, x, Color.FromArgb(pixels[index], pixels[index], pixels[index]));
                    index += 1;
                }
            }
            pictureBox1.Size = image.Size;
            pictureBox1.Image = image;
            pictureBox1.Invalidate();
            stego_image.Save(@"C:\ПНИПУ\6 семестр\ИБИЗИ\Курсовая\Примеры\Baboon_copy.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
            pictureBox2.Size = stego_image.Size;
            pictureBox2.Image = stego_image;
            pictureBox2.Invalidate();

        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ImagePathTextBox.Text = openFileDialog1.FileName;
            }
        }

        private void EncryptButton_Click(object sender, EventArgs e)
        {
            ImgToGrayscale();
            EncryptMessage();
            SetImage();
        }

        private void DecryptButton_Click(object sender, EventArgs e)
        {
            int j = 0;
            for (int i = 0; i < (image.Width * image.Height) / 2; i += 2)
            {
                j = DecryptPVD(pixels[i], pixels[i + 1], j);
                if (j == msg.Length)
                {
                    i = (image.Width * image.Height) / 2;
                }
            }
            string result = "";
            for (int i = 0; i < decode_msg.Length; i += 8)
            {
                result += Convert.ToChar(Convert.ToInt32(decode_msg.Substring(i, 8), 2));
            }
            DecryptMsgTextBox.Text = result;
        }
    }
}