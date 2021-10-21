﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;

namespace TodoApi
{
    public class ImageService
    {
        //load the image file
        private Bitmap RenderImage(string imagePath)
        {
            Bitmap image = (Bitmap)Image.FromFile(imagePath);
            return image;
        }

        //Concatenate text and image with x and y coordinates
        public void AddTextToImage(Bitmap image, string text, int xCoordinate, int yCoordinate)
        {
            Point point = new Point(xCoordinate, yCoordinate); //combine coordinates

            using (Graphics graphics = Graphics.FromImage(image))
            {
                using (Font arialFont = new Font("Arial", 10))
                {
                    graphics.DrawString(text, arialFont, Brushes.Black, point); //add text to given image
                }
            }
        }

        //save image in wwwroot
        public string SaveImageInRoot(Bitmap image, string imageName)
        {
            string path = "~/wwroot/img/created_memes/" + imageName;
            image.Save(path);
            return path;
        }


        public string CreateMeme(string imagePath, List<string> textColection, int[,] coordinatesCollection)
        {
            Bitmap meme = RenderImage(imagePath);

            for (int i = 0; i < textColection.Count; i++) //add all the text inputs to single image
            {
                AddTextToImage(meme, textColection[i], coordinatesCollection[i, 0], coordinatesCollection[i, 1]);
            }

            return SaveImageInRoot(meme,"meme1.jpg");
        }
    }
}
