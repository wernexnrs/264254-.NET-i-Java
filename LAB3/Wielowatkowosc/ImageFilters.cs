using System;
using System.Drawing;

public class ImageFilters
{
    public static Bitmap ConvertToGrayscale(Bitmap img)
    {
        Bitmap newImg = new Bitmap(img.Width, img.Height);

        for (int i = 0; i < img.Width; i++)
        {
            for (int j = 0; j < img.Height; j++)
            {
                Color pixelColor = img.GetPixel(i, j);
                int grayScale = (int)((pixelColor.R * 0.3) + (pixelColor.G * 0.59) + (pixelColor.B * 0.11));
                Color newColor = Color.FromArgb(pixelColor.A, grayScale, grayScale, grayScale);
                newImg.SetPixel(i, j, newColor);
            }
        }
        return newImg;
    }

    public static Bitmap ConvertToNegative(Bitmap img)
    {
        Bitmap newImg = new Bitmap(img.Width, img.Height);

        for (int i = 0; i < img.Width; i++)
        {
            for (int j = 0; j < img.Height; j++)
            {
                Color pixelColor = img.GetPixel(i, j);
                Color newColor = Color.FromArgb(pixelColor.A, 255 - pixelColor.R, 255 - pixelColor.G, 255 - pixelColor.B);
                newImg.SetPixel(i, j, newColor);
            }
        }
        return newImg;
    }

    public static Bitmap ApplyThreshold(Bitmap img, int threshold)
    {
        Bitmap newImg = new Bitmap(img.Width, img.Height);

        for (int i = 0; i < img.Width; i++)
        {
            for (int j = 0; j < img.Height; j++)
            {
                Color pixelColor = img.GetPixel(i, j);
                int grayScale = (int)((pixelColor.R * 0.3) + (pixelColor.G * 0.59) + (pixelColor.B * 0.11));
                Color newColor = grayScale < threshold ? Color.Black : Color.White;
                newImg.SetPixel(i, j, newColor);
            }
        }
        return newImg;
    }

    public static Bitmap MirrorImage(Bitmap img)
    {
        Bitmap newImg = new Bitmap(img.Width, img.Height);

        for (int i = 0; i < img.Width; i++)
        {
            for (int j = 0; j < img.Height; j++)
            {
                newImg.SetPixel(img.Width - 1 - i, j, img.GetPixel(i, j));
            }
        }
        return newImg;
    }
}
