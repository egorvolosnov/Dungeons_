using Dungeons_.Cameras;
using Dungeons_.Entities;
using Dungeons_.Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace Dungeons_.Maps
{
    public class Door
    {
        private int X;
        private int Y;
        private int width;
        private int height;
        private int curFrame;
        private int currAnimation;
        private int Type;
        private Image DoorSprite;
        public bool isOpen;
        public bool isOpening;
        public bool isClosing;
        public bool wasOpened;
        public int counter;
        private MapEntity doorcol;
        private TextRender text;
        public Door(int x, int y, Image door, int type)
        {
            X = x;
            Y = y;
            Type = type;
            DoorSprite = door;
            if (Type == 1)
            {
                this.width = 57;
                this.height = 57;
                currAnimation = 0;
                counter = 0;
            }
            else if (Type == 2)
            {
                this.width = 35;
                this.height = 57;
                currAnimation = 0;
                counter = 0;
            }
            else if(Type == 3)
            {
                this.width = 34;
                this.height = 58;
                currAnimation = 1;
                counter = 0;
            }
            else
            {
                this.width = 57;
                this.height = 57;
                currAnimation = 0;
                counter = 3;
            }
            if (Type == 4)
                this.curFrame = 3;
            else
                this.curFrame = 0;
            this.isOpen = false;
            this.isClosing = false;
            this.isOpening = false;
            this.wasOpened = false;
            doorcol = new MapEntity(new PointF(X, Y), new Size(width, height), 1);
            text = new TextRender();
        }
        public void Draw(Graphics g, Camera camera, Student student)
        {
            if(counter == 0 && Type == 4)
            {
                if (!isOpen)
                {
                    if(isOpening)
                    {
                        if(curFrame  < 6)
                        {
                            if(CheckCollision(student))
                                g.DrawImage(DoorSprite, new Rectangle(new Point(X + camera.X, Y + camera.Y), new Size(width, height)), width * curFrame + 7 * width, 
                                    height * currAnimation, width, height, GraphicsUnit.Pixel);
                            else
                                g.DrawImage(DoorSprite, new Rectangle(new Point(X + camera.X, Y + camera.Y), new Size(width, height)), width * curFrame,
                                    height * currAnimation, width, height, GraphicsUnit.Pixel);
                            curFrame++;
                        }
                        else if(curFrame == 6)
                        {
                            if (CheckCollision(student))
                                g.DrawImage(DoorSprite, new Rectangle(new Point(X + camera.X, Y + camera.Y), new Size(width, height)), width * curFrame + 7 * width,
                                    height * currAnimation, width, height, GraphicsUnit.Pixel);
                            else
                                g.DrawImage(DoorSprite, new Rectangle(new Point(X + camera.X, Y + camera.Y), new Size(width, height)), width * curFrame,
                                    height * currAnimation, width, height, GraphicsUnit.Pixel);
                            wasOpened = true;
                        }
                    }
                    else
                    {
                        if (CheckCollision(student))
                        {
                            g.DrawImage(DoorSprite, new Rectangle(new Point(X + camera.X, Y + camera.Y), new Size(width, height)), width * curFrame + 7 * width,
                                height * currAnimation, width, height, GraphicsUnit.Pixel);
                            text.HelpText("Нажмите E, чтобы \n открыть дверь на \n следующий уровень", g, camera);
                        }
                        else
                            g.DrawImage(DoorSprite, new Rectangle(new Point(X + camera.X, Y + camera.Y), new Size(width, height)), width * curFrame,
                                height * currAnimation, width, height, GraphicsUnit.Pixel);
                    }
                }
            }
            else if(counter == 0 && Type != 4)
            {
                if (!isOpen)
                {
                    if (isOpening)
                    {
                        if (curFrame < 3)
                        {
                            curFrame++;
                            if (CheckCollision(student))
                                g.DrawImage(DoorSprite, new Rectangle(new Point(X + camera.X, Y + camera.Y), new Size(width, height)), width * curFrame + 4 * width,
                                    height * currAnimation, width, height, GraphicsUnit.Pixel);
                            else
                                g.DrawImage(DoorSprite, new Rectangle(new Point(X + camera.X, Y + camera.Y), new Size(width, height)), width * curFrame,
                                    height * currAnimation, width, height, GraphicsUnit.Pixel);
                            
                        }
                        else if (curFrame == 3)
                        {
                            isOpen = true;
                            isOpening = false;
                            if (CheckCollision(student))
                                g.DrawImage(DoorSprite, new Rectangle(new Point(X + camera.X, Y + camera.Y), new Size(width, height)), width * curFrame + 4 * width,
                                    height * currAnimation, width, height, GraphicsUnit.Pixel);
                            else
                                g.DrawImage(DoorSprite, new Rectangle(new Point(X + camera.X, Y + camera.Y), new Size(width, height)), width * curFrame,
                                    height * currAnimation, width, height, GraphicsUnit.Pixel);
                            if(FirstMap.mapObjDel.Contains(doorcol))
                                FirstMap.mapObjDel.Remove(doorcol);
                            
                        }
                    }
                    else
                    {
                        if (CheckCollision(student))
                        {
                            g.DrawImage(DoorSprite, new Rectangle(new Point(X + camera.X, Y + camera.Y), new Size(width, height)), width * curFrame + 4 * width,
                                height * currAnimation, width, height, GraphicsUnit.Pixel);
                            text.HelpText("Нажмите E, чтобы \n открыть дверь", g, camera);
                            FirstMap.mapObjDel.Add(doorcol);
                        }
                        else
                            g.DrawImage(DoorSprite, new Rectangle(new Point(X + camera.X, Y + camera.Y), new Size(width, height)), width * curFrame,
                                height * currAnimation, width, height, GraphicsUnit.Pixel);
                    }
                }
                else
                {
                    if(isClosing)
                    {
                        if(curFrame > 0)
                        {
                            curFrame--;
                            if (CheckCollision(student))
                                g.DrawImage(DoorSprite, new Rectangle(new Point(X + camera.X, Y + camera.Y), new Size(width, height)), width * curFrame + 4 * width,
                                    height * currAnimation, width, height, GraphicsUnit.Pixel);
                            else
                                g.DrawImage(DoorSprite, new Rectangle(new Point(X + camera.X, Y + camera.Y), new Size(width, height)), width * curFrame,
                                    height * currAnimation, width, height, GraphicsUnit.Pixel);
                            
                        }
                        else if(curFrame == 0)
                        {
                            isOpen = false;
                            isClosing = false;
                            if (CheckCollision(student))
                            {
                                g.DrawImage(DoorSprite, new Rectangle(new Point(X + camera.X, Y + camera.Y), new Size(width, height)), width * curFrame + 4 * width,
                                    height * currAnimation, width, height, GraphicsUnit.Pixel);
                                FirstMap.mapObjDel.Add(doorcol);
                            }
                            else
                                g.DrawImage(DoorSprite, new Rectangle(new Point(X + camera.X, Y + camera.Y), new Size(width, height)), width * curFrame,
                                    height * currAnimation, width, height, GraphicsUnit.Pixel);
                            
                        }

                    }
                    else
                    {
                        if (CheckCollision(student))
                        {
                            g.DrawImage(DoorSprite, new Rectangle(new Point(X + camera.X, Y + camera.Y), new Size(width, height)), width * curFrame + 4 * width,
                                height * currAnimation, width, height, GraphicsUnit.Pixel);
                            text.HelpText("Нажмите E, чтобы \n закрыть дверь", g, camera);
                        }
                        else
                            g.DrawImage(DoorSprite, new Rectangle(new Point(X + camera.X, Y + camera.Y), new Size(width, height)), width * curFrame,
                                height * currAnimation, width, height, GraphicsUnit.Pixel);

                        
                        if (FirstMap.mapObjDel.Contains(doorcol))
                            FirstMap.mapObjDel.Remove(doorcol);
                    }
                }
            }

            else if(counter == 1)
            {
                if(CheckCollision(student))
                {
                    g.DrawImage(DoorSprite, new Rectangle(new Point(X + camera.X, Y + camera.Y), new Size(width, height)),
                          9 * width, height * currAnimation, width, height, GraphicsUnit.Pixel);
                    if(student.countOfKeys != 0)
                        text.HelpText("Нажмите E, чтобы \n открыть последний замок", g, camera);
                    else
                        text.HelpText("Найдите ключик\n их оберегают кошки", g, camera);
                }
                else
                    g.DrawImage(DoorSprite, new Rectangle(new Point(X + camera.X, Y + camera.Y), new Size(width, height)),
                           width * 2, height * currAnimation, width, height, GraphicsUnit.Pixel);
            }
            else if (counter == 2)
            {
                if (CheckCollision(student))
                {
                    g.DrawImage(DoorSprite, new Rectangle(new Point(X + camera.X, Y + camera.Y), new Size(width, height)),
                          8 * width, height * currAnimation, width, height, GraphicsUnit.Pixel);
                    if( student.countOfKeys != 0)
                        text.HelpText("Нажмите E, чтобы \n открыть второй замок", g, camera);
                    else
                        text.HelpText("Найдите ключик\n их оберегают кошки", g, camera);
                }
                else
                    g.DrawImage(DoorSprite, new Rectangle(new Point(X + camera.X, Y + camera.Y), new Size(width, height)),
                           width * 1, height * currAnimation, width, height, GraphicsUnit.Pixel);
            }
            else if (counter == 3)
            {
                if (CheckCollision(student))
                {
                    g.DrawImage(DoorSprite, new Rectangle(new Point(X + camera.X, Y + camera.Y), new Size(width, height)),
                           7 * width, height * currAnimation, width, height, GraphicsUnit.Pixel);
                    if(student.countOfKeys != 0)
                        text.HelpText("Нажмите E, чтобы \n открыть первый замок", g, camera);
                    else
                        text.HelpText("Найдите ключик\n их оберегают кошки", g, camera);
                }
                else
                    g.DrawImage(DoorSprite, new Rectangle(new Point(X + camera.X, Y + camera.Y), new Size(width, height)),
                           0, height * currAnimation, width, height, GraphicsUnit.Pixel);
            }


        }
            private bool CheckCollision(Student student)
        {
            Rectangle studentBounds = new Rectangle(student.PosX, student.PosY, student.SizeX, student.SizeY);
            Rectangle DoorBounds = new Rectangle(X, Y, width, height);

            return studentBounds.IntersectsWith(DoorBounds);
        }
        public void HandleInteractionDoor(Student student)
        {
            if (CheckCollision(student))
            {
                if (counter == 0)
                {
                    if (!isOpen && !isOpening && !isClosing)
                    {
                        isOpening = true;
                        if(Type != 4)
                            wasOpened = true;
                    }
                    else if (isOpen && !isOpening && !isClosing)
                        isClosing = true;
                    else
                    {
                        isClosing = false;
                        isOpening = false;
                    }
                }
                else if(student.countOfKeys > 0)
                {
                    counter--;
                    student.countOfKeys--;
                }
            }
        }
    }
}
