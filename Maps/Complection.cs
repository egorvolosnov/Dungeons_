using Dungeons_.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ScrollBar;
using Dungeons_.Cameras;
using Dungeons_.Interface;

namespace Dungeons_.Maps
{
    public class Complection:IDisposable
    {
        private Image complectionImage;
        private Image boxImage;
        private int boxX;
        private int boxY;
        private int boxWidth;
        private int boxHeight; 
        private int complectionX;
        private int complectionY;
        private int complectionWidth;
        private int complectionHeight;
        private int currFramecomplect;
        private double currFramebox;
        private bool isComplectionVisible;
        public bool isBoxVisible;
        private MapEntity boxCol;
        private TextRender helpText;

        public Complection(int x, int y, Image complectionImage, Image boxImage)
        {
            complectionX = x;
            complectionY = y;
            complectionWidth = 36;
            complectionHeight = 36;
            boxHeight = 36;
            boxWidth = 36;
            boxX = x;
            boxY= y;
            this.complectionImage = complectionImage;
            this.boxImage = boxImage;
            isComplectionVisible = false;
            isBoxVisible = true;
            currFramecomplect = 0;
            currFramebox = 0;
            boxCol = new MapEntity(new PointF(boxX, boxY), new Size(boxWidth, boxHeight), 1);
            helpText = new TextRender();
        }

        public void Update(Student student)
        {
            currFramecomplect = (currFramecomplect + 1) % 2;
           
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
                    isComplectionVisible = true;
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
                    if(CheckCollisionBox(student))
                        g.DrawImage(boxImage, new Rectangle(new Point(boxX + camera.X, boxY + camera.Y), new Size(boxWidth, boxHeight)), boxWidth * 1 + 108, 0, boxWidth, boxHeight, GraphicsUnit.Pixel);
                    else
                        g.DrawImage(boxImage, new Rectangle(new Point(boxX + camera.X, boxY + camera.Y), new Size(boxWidth, boxHeight)), boxWidth * 1, 0, boxWidth, boxHeight, GraphicsUnit.Pixel);
                }
                    
                else if (Math.Floor(currFramebox) == 2)
                {
                    if(CheckCollisionBox(student))
                        g.DrawImage(boxImage, new Rectangle(new Point(boxX + camera.X, boxY + camera.Y), new Size(boxWidth, boxHeight)), boxWidth * 2 + 108, 0, boxWidth, boxHeight, GraphicsUnit.Pixel);
                    else
                        g.DrawImage(boxImage, new Rectangle(new Point(boxX + camera.X, boxY + camera.Y), new Size(boxWidth, boxHeight)), boxWidth * 2, 0, boxWidth, boxHeight, GraphicsUnit.Pixel);
                }
                    
            }

            if (isComplectionVisible)
            {
                if (CheckCollisionComplection(student))
                {
                    g.DrawImage(complectionImage, new Rectangle(new Point(complectionX + camera.X, complectionY + camera.Y), new Size(complectionWidth, complectionHeight)), complectionWidth * currFramecomplect + 72, 0, complectionWidth, complectionHeight, GraphicsUnit.Pixel);
                    helpText.HelpText(" Нажмите E, чтобы\nподнять снаряжение \n\n   УРОН: +10\nЩИТ: АКТИВАЦИЯ ПКМ", g, camera);
                }
                else
                    g.DrawImage(complectionImage, new Rectangle(new Point(complectionX + camera.X, complectionY + camera.Y), new Size(complectionWidth, complectionHeight)), complectionWidth * currFramecomplect, 0, complectionWidth, complectionHeight, GraphicsUnit.Pixel);
            }
        }
        public bool CheckCollisionBox(Student student)
        {
            Rectangle studentBounds = new Rectangle(student.PosX, student.PosY, student.SizeX, student.SizeY);
            Rectangle boxBounds = new Rectangle(boxX, boxY, boxWidth, boxHeight);

            return studentBounds.IntersectsWith(boxBounds) && isBoxVisible;
        }
        public bool CheckCollisionComplection(Student student)
        {
            Rectangle studentBounds = new Rectangle(student.PosX, student.PosY, student.SizeX, student.SizeY);
            Rectangle complectionBounds = new Rectangle(complectionX, complectionY, complectionWidth, complectionHeight);

            return studentBounds.IntersectsWith(complectionBounds) && isComplectionVisible;
        }

        public void HandleInteraction(Student student)
        {
            if (CheckCollisionComplection(student))
            {
                // Обработка взаимодействия с оружием
                isComplectionVisible = false;
                student.IsComplected = true;
            }
        }
        public void DropComplection(Student student)
        {
            if (!isComplectionVisible && student.IsComplected)
            {
                student.IsComplected = false;
                isComplectionVisible = true;
                complectionX = student.PosX + (student.SizeX / 2) - (complectionWidth / 2);
                complectionY = student.PosY + (student.SizeY / 2) - (complectionHeight / 2)+20;
                
            }
        }
        public void Dispose()
        {
            // Освобождение ресурсов, если необходимо
            complectionImage?.Dispose();
            boxImage?.Dispose();
            helpText?.Dispose();
        }

    }
}
