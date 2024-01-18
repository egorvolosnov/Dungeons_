using Dungeons_.Cameras;
using Dungeons_.Entities;
using Dungeons_.Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeons_.Maps
{
    public class Box:IDisposable
    {
        private Image boxImage;
        private int boxX;
        private int boxY;
        private int boxWidth;
        private int boxHeight;
        private double currFramebox;
        public bool isBoxVisible;
        private MapEntity boxCol;
        private TextRender helpText;
        public Box(int x, int y, Image image)
        {
            this.boxX = x;
            this.boxY = y;
            this.boxWidth = 36;
            this.boxHeight = 36;
            this.boxImage = image;
            isBoxVisible = true;
            currFramebox = 0;
            boxCol = new MapEntity(new PointF(boxX, boxY), new Size(boxWidth, boxHeight), 1);
            helpText = new TextRender();
        }

        public void Draw(Graphics g, Student student, Camera camera)
        {
            if (isBoxVisible)
                FirstMap.mapObjDel.Add(boxCol);
            else if (!isBoxVisible && FirstMap.mapObjDel.Contains(boxCol))
                FirstMap.RemoveItem(boxCol);
            if (isBoxVisible)
            {

                if (CheckCollisionBox(student) && student.IsAttacking)
                {
                    currFramebox += 0.1;
                }
                if (Math.Floor(currFramebox) == 3)
                {
                    isBoxVisible = false;
                }
                if (Math.Floor(currFramebox) == 0)
                {
                    if (CheckCollisionBox(student))
                    {
                        g.DrawImage(boxImage, new Rectangle(new Point(boxX + camera.X, boxY + camera.Y), new Size(boxWidth, boxHeight)), boxWidth * 0 + 108, 0, boxWidth, boxHeight, GraphicsUnit.Pixel);
                        helpText.HelpText("Нажмите ЛКМ, чтобы\n разрушить коробку", g, camera);

                    }
                    else
                    {
                        g.DrawImage(boxImage, new Rectangle(new Point(boxX + camera.X, boxY + camera.Y), new Size(boxWidth, boxHeight)), boxWidth * 0, 0, boxWidth, boxHeight, GraphicsUnit.Pixel);
                    }
                }


                else if (Math.Floor(currFramebox) == 1)
                {
                    if (CheckCollisionBox(student))
                        g.DrawImage(boxImage, new Rectangle(new Point(boxX + camera.X, boxY + camera.Y), new Size(boxWidth, boxHeight)), boxWidth * 1 + 108, 0, boxWidth, boxHeight, GraphicsUnit.Pixel);
                    else
                        g.DrawImage(boxImage, new Rectangle(new Point(boxX + camera.X, boxY + camera.Y), new Size(boxWidth, boxHeight)), boxWidth * 1, 0, boxWidth, boxHeight, GraphicsUnit.Pixel);
                }

                else if (Math.Floor(currFramebox) == 2)
                {
                    if (CheckCollisionBox(student))
                        g.DrawImage(boxImage, new Rectangle(new Point(boxX + camera.X, boxY + camera.Y), new Size(boxWidth, boxHeight)), boxWidth * 2 + 108, 0, boxWidth, boxHeight, GraphicsUnit.Pixel);
                    else
                        g.DrawImage(boxImage, new Rectangle(new Point(boxX + camera.X, boxY + camera.Y), new Size(boxWidth, boxHeight)), boxWidth * 2, 0, boxWidth, boxHeight, GraphicsUnit.Pixel);
                }

            }
        }
        public void Dispose()
        {
            // Освобождение ресурсов, если необходимо
            boxImage?.Dispose();
            helpText?.Dispose();
        }
        public bool CheckCollisionBox(Student student)
        {
            Rectangle studentBounds = new Rectangle(student.PosX, student.PosY, student.SizeX, student.SizeY);
            Rectangle boxBounds = new Rectangle(boxX, boxY, boxWidth, boxHeight);

            return studentBounds.IntersectsWith(boxBounds) && isBoxVisible;
        }
    }
}
