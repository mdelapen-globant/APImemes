using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Models;

namespace TodoApi
{
    public class MemeService
    {
        ImageService imageHandler = new ImageService();

        //receive meme image with path and text
        public string CreateMeme(MemeImage memeImage, List<TextCoordinates> coordinates, List<string> texts)
        {
            string newMemePath = "";
            int[,] arrayCoordinates = CoordinatesToArray(coordinates);//translate model to array
            newMemePath = imageHandler.CreateMeme(memeImage.Path, texts, arrayCoordinates);//call image builder and concatenate text with image

            return newMemePath;
        }

        //translate model object to primitive type
        private int[,] CoordinatesToArray(List<TextCoordinates> coordinates)
        {
            int listSize = coordinates.Count;
            int[,] arrayCoordinates = new int[listSize, 2];//create int array to hold coordinates
            for(int i = 0; i < listSize; i++)
            {
                arrayCoordinates[i, 0] = coordinates[i].HorizontalPoint;
                arrayCoordinates[i, 1] = coordinates[i].VerticalPoint;
            }

            return arrayCoordinates;
        }

    }
}
