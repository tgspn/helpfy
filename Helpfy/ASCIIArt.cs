using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Helpfy
{
    public class ASCIIArt
    {
        private const int _asciiWidth = 150;

        private readonly string[] _asciiChars = { "#", "#", "@", "%", "=", "+", "*", ":", "-", ".", " " };
        public string Convert(string filename)
        {
            Image image = Bitmap.FromFile(filename);

            string ascii = ConvertImageToAsciiArt((Bitmap)image);
            Console.Write(ascii);
			return ascii;
        }
        private  string ConvertImageToAsciiArt(Bitmap image)
        {
            image = GetReSizedImage(image, _asciiWidth);

            //Convert the resized image into ASCII
            string ascii = ConvertToAscii(image);
            return ascii;
        }

		private  Bitmap GetReSizedImage(Bitmap inputBitmap, int asciiWidth)
		{
			int asciiHeight = 0;
			//Calculate the new Height of the image from its width
			asciiHeight = (int)Math.Ceiling((double)inputBitmap.Height * asciiWidth / inputBitmap.Width);

			//Create a new Bitmap and define its resolution
			Bitmap result = new Bitmap(asciiWidth, asciiHeight);
			Graphics g = Graphics.FromImage((Image)result);
			//The interpolation mode produces high quality images 
			g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
			g.DrawImage(inputBitmap, 0, 0, asciiWidth, asciiHeight);
			g.Dispose();
			return result;
		}


		private  string ConvertToAscii(Bitmap image)
		{
			Boolean toggle = false;
			StringBuilder sb = new StringBuilder();

			for (int h = 0; h < image.Height; h++)
			{
				for (int w = 0; w < image.Width; w++)
				{
					Color pixelColor = image.GetPixel(w, h);
					//Average out the RGB components to find the Gray Color
					int red = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
					int green = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
					int blue = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
					Color grayColor = Color.FromArgb(red, green, blue);

					//Use the toggle flag to minimize height-wise stretch
					if (!toggle)
					{
						int index = (grayColor.R * 10) / 255;
						sb.Append(_asciiChars[index]);
					}
				}

				if (!toggle)
				{
					sb.Append(Environment.NewLine);
					toggle = true;
				}
				else
				{
					toggle = false;
				}
			}

			return sb.ToString();
		}
	}
}
