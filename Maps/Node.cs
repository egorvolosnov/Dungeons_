using Dungeons_.Cameras;
using Dungeons_.Entities;
using Dungeons_.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Dungeons_.Maps
{
    public class Node
    {
        public int Id { get; }
        public Point Position { get; }
        public Size Size { get; }
        public Image SpriteSheet;
        public int cellSize;
        public int[,] map;
        public bool enter;
        public int level;
        public Node(int id, Point position, Size size, bool enter, int Level)
        {
            this.enter = enter;
            Id = id;
            Position = position;
            Size = size;
            map = GenerateFullMap();
            this.level = Level;
            if(level == 1)
                SpriteSheet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\map2.png"));
            else if(level == 2)
                SpriteSheet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\map.png"));
            else
                SpriteSheet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\map3.png"));
            cellSize = 19;
            
        }
        public void update(bool eneter)
        {
            this.enter = eneter;
        }
        public int[,] GenerateInnerMap()
        {
            int[,] innerMap = new int[Size.Height, Size.Width];

            Random random = new Random();
            for (int i = 1; i < Size.Height - 1; i++)
            {
                for (int j = 1; j < Size.Width - 1; j++)
                {
                    int randomIndex = random.Next(2, 7); // Генерация случайного числа от 1 до 5
                    innerMap[i, j] = randomIndex;
                }
            }

            return innerMap;
        }

        public int[,] GenerateFullMap()
        {
            int[,] fullMap = new int[Size.Height, Size.Width];
            int[,] innerMap = GenerateInnerMap();
            for (int i = 0; i < Size.Height; i++)
            {
                for (int j = 0; j < Size.Width; j++)
                {
                    fullMap[i, j] = innerMap[i, j];
                }
            }
            for (int j = 0; j < Size.Width; j++)
            {
                fullMap[0, j] = fullMap[Size.Height - 1, j] = 1;
                fullMap[1, j] = 1;
                fullMap[2, j] = 7;
            }
            for (int i = 0; i < Size.Height; i++)
            {
                fullMap[i, 0] = fullMap[i, Size.Width - 1] = 1;
            }

            //Верхний выход
            if (Id == 1 || Id == 2 || Id == 3 || Id == 5 || Id == 7 || Id == 8 || Id == 14 || Id == 16 || Id == 20 || Id == 15 || Id == 13 || Id == 17 )
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = Size.Width / 2 - 1; j < Size.Width / 2 + 2; j++)
                        fullMap[i, j] = 3;
                }
            }
            //Нижний выход
            if (Id == 2 || Id == 5 || Id == 3 || Id ==8 || Id == 14 || Id == 16 || Id == 20 || Id == 9 || Id == 11 || Id == 13 || Id==15 || Id == 21)
            {
                fullMap[19, Size.Width / 2] = fullMap[19, Size.Width / 2 - 1] = fullMap[19, Size.Width / 2 + 1] = 3;

            }
            //Левый выход
            if(Id == 3 || Id == 4 || Id == 10 || Id == 6 || Id == 11 || Id == 12 || Id == 13 || Id == 15 || Id == 18 || Id == 19 || Id == 22 || Id == 23)
            {
                if(Size.Height == 9)
                    fullMap[Size.Height / 2, 0] = fullMap[Size.Height / 2 + 1, 0] = fullMap[Size.Height / 2 + 2, 0] = 3;
                else
                    fullMap[Size.Height / 2, 0] = fullMap[Size.Height / 2 - 1, 0] = fullMap[Size.Height / 2 + 1, 0] = 3;
               
            }
            //Правый выход
            if (Id == 3 || Id == 4 || Id == 6 || Id == 7 || Id == 9 || Id == 10 || Id == 11 || Id == 12 || Id == 17 || Id == 18 || Id == 21 || Id == 22)
            {
                if(Size.Height == 9)
                    fullMap[Size.Height / 2, Size.Width - 1] = fullMap[Size.Height / 2 + 1, Size.Width - 1] = fullMap[Size.Height / 2 + 2, Size.Width - 1] = 3;
                else
                    fullMap[Size.Height / 2, Size.Width - 1] = fullMap[Size.Height / 2 - 1, Size.Width - 1] = fullMap[Size.Height / 2 + 1, Size.Width - 1] = 3;
            }

            return fullMap;
        }
       
        public void DrawMap(Graphics g, Camera camera, int screenX, int screenY)
        {
            for (int i = 0; i < Size.Height; i++)
            {
                for (int j = 0; j < Size.Width; j++)
                {
                    if (i >= 0 && i < Size.Height && j >= 0 && j < Size.Width)
                    {
                        if (map[i, j] == 1)
                        {
                            g.DrawImage(SpriteSheet, new Rectangle(new Point(j * cellSize + screenX, i * cellSize + screenY), new Size(cellSize, cellSize)), 0, 0, 19, 19, GraphicsUnit.Pixel);
                            MapEntity mapEntity = new MapEntity(new Point(j * cellSize + Position.X, i * cellSize + Position.Y), new Size(cellSize, cellSize), 0);
                            FirstMap.mapObj.Add(mapEntity);
                        }
                        else if (map[i, j] == 2)
                            g.DrawImage(SpriteSheet, new Rectangle(new Point(j * cellSize + screenX, i * cellSize + screenY), new Size(cellSize, cellSize)), 19, 0, 19, 19, GraphicsUnit.Pixel);
                        else if (map[i, j] == 3)
                            g.DrawImage(SpriteSheet, new Rectangle(new Point(j * cellSize + screenX, i * cellSize + screenY), new Size(cellSize, cellSize)), 38, 0, 19, 19, GraphicsUnit.Pixel);
                        else if (map[i, j] == 4)
                            g.DrawImage(SpriteSheet, new Rectangle(new Point(j * cellSize + screenX, i * cellSize + screenY), new Size(cellSize, cellSize)), 57, 0, 19, 19, GraphicsUnit.Pixel);
                        else if (map[i, j] == 5)
                            g.DrawImage(SpriteSheet, new Rectangle(new Point(j * cellSize + screenX, i * cellSize + screenY), new Size(cellSize, cellSize)), 76, 0, 19, 19, GraphicsUnit.Pixel);
                        else if (map[i, j] == 6)
                            g.DrawImage(SpriteSheet, new Rectangle(new Point(j * cellSize + screenX, i * cellSize + screenY), new Size(cellSize, cellSize)), 95, 0, 19, 19, GraphicsUnit.Pixel);
                        if (map[i, j] == 7)
                        {
                            g.DrawImage(SpriteSheet, new Rectangle(new Point(j * cellSize + screenX, i * cellSize + screenY), new Size(cellSize, cellSize)), 114, 0, 19, 19, GraphicsUnit.Pixel);
                        }

                    }
                }
            }
        }

   

    public int GetWidth()
        {
            return Hero.ScreenWidth;
        }

        public int GetHeight()
        {
            return Hero.ScreenHeight;
        }
    }
}
   