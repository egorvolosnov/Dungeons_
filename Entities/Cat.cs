using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dungeons_.Cameras;
using Dungeons_.Interface;
using Dungeons_.Maps;

namespace Dungeons_.Entities
{
    public class Cat : IDisposable
    {
        private Image catSprite;
        private Image keySprite;
        private int catX; 
        private int catY;
        private int keyX;
        private int keyY;
        private int catWidth;
        private int catHeight;
        private int keyWidth;
        private int keyHeight;
        private int catFrame;
        private int keyFrame;
        private bool IsEating;
        private bool WasEating;
        private bool IsVisible;
        private int count;
        private MapEntity catCol;
        private TextRender text;

        public Cat(int x, int y, Image sprite, Image sprite2)
        {
            catX = x;
            catY = y;
            keyX = x + 42;
            keyY = y + 10;
            catSprite = sprite;
            keySprite = sprite2;
            catWidth = 32;
            catHeight = 32;
            keyWidth = 21;
            keyHeight = 20;
            IsEating = false;
            WasEating = false;
            IsVisible = false;
            catFrame = 0;
            keyFrame = 0;
            count = 0;
            catCol = new MapEntity(new PointF(x, y), new Size(catWidth, catHeight), 1);
            text = new TextRender();
        }

        public void updateCat()
        {
            catFrame = (catFrame + 1) % 2;
            
        }
        public void updateKey()
        {
            keyFrame = (keyFrame + 1) % 2;
        }
        public void draw(Graphics g, Camera camera, Student student)
        {
            FirstMap.mapObj.Add(catCol);
            if(IsEating)
            {
                if (count == 10)
                {
                    IsEating = false;
                    WasEating = true;
                    IsVisible=true;
                }
                   
                if (catFrame == 1)
                {
                    count++;
                    g.DrawImage(catSprite, new Rectangle(new Point(catX + camera.X, catY + camera.Y), new Size(catWidth, catHeight)), catWidth * catFrame + 128, 0, catWidth, catHeight, GraphicsUnit.Pixel);
                }
                else
                    g.DrawImage(catSprite, new Rectangle(new Point(catX + camera.X, catY + camera.Y), new Size(catWidth, catHeight)), catWidth * catFrame + 128, 0, catWidth, catHeight, GraphicsUnit.Pixel);
            }
            else
            {
                if (CheckCollisionCat(student) && !WasEating)
                {
                    g.DrawImage(catSprite, new Rectangle(new Point(catX + camera.X, catY + camera.Y), new Size(catWidth, catHeight)), catWidth * catFrame + 64, 0, catWidth, catHeight, GraphicsUnit.Pixel);
                    if (student.countOfSausages == 0)
                        text.HelpText("Найдите еду, чтобы\n покормить кошку", g, camera);
                    else
                        text.HelpText("Нажмите E, чтобы\n покормить кошку", g, camera);
                }
                
                else
                    g.DrawImage(catSprite, new Rectangle(new Point(catX + camera.X, catY + camera.Y), new Size(catWidth, catHeight)), catWidth * catFrame, 0, catWidth, catHeight, GraphicsUnit.Pixel);
            }
            if(IsVisible)
            {
                if (CheckCollisionKey(student))
                {
                    g.DrawImage(keySprite, new Rectangle(new Point(keyX + camera.X, keyY + camera.Y), new Size(keyWidth, keyHeight)), keyWidth * keyFrame + 42, 0, keyWidth, keyHeight, GraphicsUnit.Pixel);
                    text.HelpText("Нажмите E, чтобы\n подобрать ключик", g, camera);
                }
                else
                    g.DrawImage(keySprite, new Rectangle(new Point(keyX + camera.X, keyY + camera.Y), new Size(keyWidth, keyHeight)), keyWidth * keyFrame, 0, keyWidth, keyHeight, GraphicsUnit.Pixel);
            }
        }
        public bool CheckCollisionCat(Student student)
        {
            Rectangle studentBounds = new Rectangle(student.PosX, student.PosY, student.SizeX, student.SizeY);
            Rectangle CatBounds = new Rectangle(catX, catY, catWidth, catHeight);

            return studentBounds.IntersectsWith(CatBounds);
        }
        public void HandleInteractionCat(Student student)
        {
            if (CheckCollisionCat(student) && !WasEating && student.countOfSausages != 0)
            {
                // Обработка взаимодействия с оружием
                IsEating = true;
                student.countOfSausages--;
            }
        }
        public bool CheckCollisionKey(Student student)
        {
            Rectangle studentBounds = new Rectangle(student.PosX, student.PosY, student.SizeX, student.SizeY);
            Rectangle KeyBounds = new Rectangle(keyX, keyY, keyWidth, keyHeight);

            return studentBounds.IntersectsWith(KeyBounds) && IsVisible;
        }
        public void Dispose()
        {
            // Освобождение ресурсов, если необходимо
            catSprite?.Dispose();
            keySprite?.Dispose();
            text?.Dispose();
        }
        public void HandleInteractionKey(Student student)
        {
            if (CheckCollisionKey(student))
            {
                IsVisible = false;
                student.countOfKeys++;
                
            }
        }
    }
}
