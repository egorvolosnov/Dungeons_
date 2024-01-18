using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dungeons_.Cameras;
using Dungeons_.Entities;
using Dungeons_.Interface;

namespace Dungeons_.Maps
{
    public class Sausage
    {
        private int x;
        private int y;
        private int width;
        private int height;
        private int currFrame;
        public int count;
        public bool IsVisible;
        public bool wasTaken;
        public Image Sprite;
        private TextRender text;
        Box box;
        public Sausage(int x, int y, Image sprite, Image boxSprite, bool box) 
        { 
            this.x = x;
            this.y = y;
            this.width = 30;
            this.height = 30;
            Sprite = sprite;
            currFrame = 0;
            if (box)
            {
                this.box = new Box(x, y, boxSprite);
                IsVisible = false;
            }
            else
            {
                this.box = null;
                IsVisible = true;
            }
            text = new TextRender();
            wasTaken = false;
        }
        public void Update()
        {
            currFrame = (currFrame + 1) % 2; 
        }
        public void Draw(Graphics g, Camera camera, Student student) 
        {
            if(box != null)
            {
                if (box.isBoxVisible)
                    box.Draw(g, student, camera);
                else if(!wasTaken)
                    IsVisible = true;
            }
            if(IsVisible)
            {
                if (CheckCollision(student))
                {
                    g.DrawImage(Sprite, new Rectangle(new Point(x + camera.X, y + camera.Y), new Size(width, height)), width * currFrame + 60, 0, width, height, GraphicsUnit.Pixel);
                    text.HelpText("Нажмите на E, чтобы\n поднять сосиску", g, camera);
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
                IsVisible = false;
                wasTaken = true;
                student.countOfSausages += 1;
            }
        }
    }

}
