using Dungeons_.Cameras;
using Dungeons_.Entities;
using Dungeons_.Interface;
using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace Dungeons_.Maps
{
    public class HPBaff
    {
        private int x;
        private int y;
        private int width;
        private int height;
        private int currFrame;
        private bool IsVisible;
        private bool WasTaken;
        private Image Sprite;
        private TextRender helpText;
        private MapEntity fontaincol;
        public HPBaff(int x, int y, int w, int h, Image sprite) 
        {
            this.x = x;
            this.y = y; 
            width = w;
            height = h;
            currFrame = 0;
            IsVisible = false;
            WasTaken = false;
            helpText = new TextRender();
            Sprite = sprite;
            fontaincol = new MapEntity(new PointF(x, y), new Size(width, height), 1);

        }
        public void Update(Bot bot)
        {
            if (width == 32)
            {
                if (!bot.IsAlive)
                {
                    IsVisible = true;
                    currFrame = (currFrame + 1) % 2;
                }
                else
                {
                    x = bot.PosX;
                    y = bot.PosY;
                }
            }
            else
            {
                IsVisible = true;
                currFrame = (currFrame + 1) % 2;
            }
                
        }
        public void Draw(Graphics g, Camera camera, Student student)
        {
            if (width == 32)
            {
                if (IsVisible && !WasTaken)
                {
                    if (CheckCollision(student))
                    {
                        g.DrawImage(Sprite, new Rectangle(new Point(x + camera.X, y + camera.Y), new Size(width, height)), width * currFrame + 64, 0, width, height, GraphicsUnit.Pixel);
                        helpText.HelpText("Нажмите на E, чтобы\nподнять зелье здоровья\n     +10 HP", g, camera);
                    }
                    else
                    {
                        g.DrawImage(Sprite, new Rectangle(new Point(x + camera.X, y + camera.Y), new Size(width, height)), width * currFrame, 0, width, height, GraphicsUnit.Pixel);
                    }
                }
            }
            else
            {
                if (CheckCollision(student))
                {
                    FirstMap.mapObj.Add(fontaincol);
                    g.DrawImage(Sprite, new Rectangle(new Point(x + camera.X, y + camera.Y), new Size(width, height)), width * currFrame + 336, 0, width, height, GraphicsUnit.Pixel);
                    helpText.HelpText("Нажмите на E, чтобы\n воспользоваться \n фонтаном жизни :\n FULL HP", g, camera);
                }
                else
                {
                    g.DrawImage(Sprite, new Rectangle(new Point(x + camera.X, y + camera.Y), new Size(width, height)), width * currFrame, 0, width, height, GraphicsUnit.Pixel);
                }
            }
        }
        public bool CheckCollision(Student student)
        {
            Rectangle studentBounds = new Rectangle(student.PosX, student.PosY, student.SizeX, student.SizeY);
            Rectangle sausageBounds = new Rectangle(x, y, width, height);

            return studentBounds.IntersectsWith(sausageBounds) && IsVisible;
        }

        public void HandleInteraction(Student student)
        {
            if (CheckCollision(student))
            {
                // Обработка взаимодействия с оружием
                if (width == 32)
                {
                    IsVisible = false;
                    if (student.HealthPoint <= 90)
                        student.HealthPoint += 10;
                    else
                        student.HealthPoint += (100 - student.HealthPoint);
                    WasTaken = true;
                }
                else
                    student.HealthPoint = 100;
            }
        }
    }
}
