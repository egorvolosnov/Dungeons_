using Dungeons_.Cameras;
using Dungeons_.Interface;
using Dungeons_.Maps;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Dungeons_.Entities
{
    public class Bot : IEntity
    {
        public int PosX { get; set; }
        public int PosY { get; set; }
        public int SizeX { get; set; }
        public int SizeY { get; set; }
        public int Layer { get; set; }
        public int DirX { get; set; }
        public int DirY { get; set; }
        public int HealthPoint { get; set; }
        public bool IsMoving { get; set; }
        public bool IsAlive { get; set; }
        public bool IsHurted { get; set; }
        public bool IsAtacking { get; set; }
        public Image IdleSprite { get; set; }
        public Image Health { get; set; }
        public int CurrAnimation { get; set; }
        public int CurrFrame { get; set; }
        public int CurrLimit { get; set; }
        public Image CurrImage { get; set; }
        public int DeathFrames { get; set; }
        public int IdleFrames { get; set; }
        public int RunFrames { get; set; }
        public int AttackFrames { get; set; }
        public int CurrDeathFrame {get; set;}
        public MapEntity botCol;
        public Node Room;
        public int damage { get; set; }
        public int CurrHurtFrame {  get; set; }
        public int Kostyl {  get; set; }
        public Bot(int posX, int posY, int sizeX, int sizeY, Image idleSprite, Image health, int idleFrames, int runFrames, int attackFrames, int deathFrames, int Layer, Node Room) 
        {
            PosX = posX;
            PosY = posY;
            SizeX = sizeX;
            SizeY = sizeY;
            Health = health;
            IdleFrames = idleFrames;
            RunFrames = runFrames;
            AttackFrames = attackFrames;
            DeathFrames = deathFrames;
            CurrFrame = 0;
            CurrLimit = IdleFrames;
            CurrAnimation = 0;
            if (SizeX == 64)
                HealthPoint = 100;
            else
                HealthPoint = 400;
            CurrImage = idleSprite;
            IsMoving = false;
            IsAlive = true;
            IsHurted = false;
            CurrDeathFrame = 0;
            IsAtacking = false;
            this.Layer = Layer;
            this.Room = Room;
            DirX = 0;
            DirY = 0;
            if (SizeX == 64)
                damage = 3;
            else
                damage = 15;
            Kostyl = 0;
        }
        
        public void Move()
        {

            PosX += DirX;
            PosY += DirY;
        }
        public void ChangeDir(Student student)
        {
            int deltaX = student.PosX - PosX;
            int deltaY = student.PosY - PosY;

            double length = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
            double normalizedDeltaX = deltaX / length;
            double normalizedDeltaY = deltaY / length;

            DirX = (int)(normalizedDeltaX * 5); 
            DirY = (int)(normalizedDeltaY * 5);
            if (DirX >= 0)
                CurrAnimation = 0;
            if (DirX < 0)
                CurrAnimation = 1;
        }
        public void IsHurting(Student student)
        {
            if (IsAlive)
            {
                bool Dir = false;
                // Рассчитываем вектор от бота к персонажу
                Point delta = new Point(student.DirX, student.DirY);
                delta.X = (student.PosX + student.SizeX / 2) - (PosX + SizeX / 2 + 5);
                delta.Y = (student.PosY + student.SizeY / 2) - (PosY + SizeY / 2 + 5 * 2);

                if (Math.Abs(delta.X) <= student.SizeX / 2 + SizeX / 2 - 2 * 5 &&
                    Math.Abs(delta.Y) <= student.SizeY / 2 + SizeY / 2 - 4 * 5)
                {
                    float overlapX = student.SizeX / 2 + SizeX / 2 - Math.Abs(delta.X);
                    float overlapY = student.SizeY / 2 + SizeY / 2 - Math.Abs(delta.Y);

                    if (overlapX < overlapY)
                    {
                        if (delta.X <= 0 && student.DirX > 0)
                            Dir = true;
                        else if (delta.X > 0 && student.DirX < 0)
                            Dir = true;
                    }
                    else
                    {
                        if (delta.Y < 0 && student.DirY > 0)
                            Dir = true;
                        else if (delta.Y > 0 && student.DirY < 0)
                            Dir = true;
                    }
                }
                // Если векторное произведение положительное, персонаж смотрит на бота
                if (CheckCollision(student) && student.IsAttacking && student.CurrFrame == 3 && Dir)
                {
                    IsHurted = true;
                    if (HealthPoint < student.Damage)
                        HealthPoint = 0;
                    else
                        HealthPoint -= student.Damage;
                }
                else if (CheckCollision(student) && student.IsAttacking && student.IsComplected && student.CurrFrame ==3 && Dir)
                {
                    IsHurted = true;
                    if (HealthPoint < student.DamageComplected)
                        HealthPoint = 0;
                    else
                        HealthPoint -= student.DamageComplected;
                }
                else
                    IsHurted = false;
            }
        }

        public void Update(Student student)
        {
            if (IsAlive)
            {
                if (CurrFrame < CurrLimit - 1)
                    CurrFrame++;
                else
                    CurrFrame = 0;
            }
            else
            {
                if (CurrDeathFrame < CurrLimit - 1)
                    CurrDeathFrame++;
                else
                {
                    CurrDeathFrame = CurrLimit - 1;
                    Kostyl += 1;
                }
            }
            ChangeDir(student);
        }
        public void PlayAnimation(Graphics g, Camera camera, Student student)
        {
            if(SizeX == 64)
            {
                if (IsAlive)
                {
                    if (FirstMap.mapEnemy.Contains(botCol))
                        FirstMap.RemoveEnemy(botCol);
                    botCol = new MapEntity(new PointF(PosX, PosY), new Size(SizeX, SizeY), 2);
                    FirstMap.mapEnemy.Add(botCol);

                    if (IsHurted)
                        g.DrawImage(CurrImage, new Rectangle(new Point(PosX + camera.X, PosY + camera.Y), new Size(SizeX, SizeY)), 0, 0, SizeX, SizeY, GraphicsUnit.Pixel);
                    else if (IsAtacking)
                        g.DrawImage(CurrImage, new Rectangle(new Point(PosX + camera.X, PosY + camera.Y), new Size(SizeX, SizeY + 3)), 64 * CurrFrame, 67 * CurrAnimation, SizeX, SizeY + 3, GraphicsUnit.Pixel);
                    else
                        g.DrawImage(CurrImage, new Rectangle(new Point(PosX + camera.X, PosY + camera.Y), new Size(SizeX, SizeY)), 64 * CurrFrame, 64 * CurrAnimation, SizeX, SizeY, GraphicsUnit.Pixel);
                    if (CheckCollision(student))
                    {
                        DrawBar(g, camera, student);
                    }
                }
                else
                {
                    FirstMap.RemoveEnemy(botCol);
                    g.DrawImage(CurrImage, new Rectangle(new Point(PosX + camera.X, PosY + camera.Y), new Size(SizeX, SizeY)), 64 * CurrDeathFrame, 0, SizeX, SizeY, GraphicsUnit.Pixel);

                }
            }
            else
            {
                if (IsAlive)
                {
                    if (FirstMap.mapEnemy.Contains(botCol))
                        FirstMap.RemoveEnemy(botCol);
                    botCol = new MapEntity(new PointF(PosX, PosY), new Size(SizeX, SizeY), 2);
                    FirstMap.mapEnemy.Add(botCol);

                    if (IsHurted)
                        g.DrawImage(CurrImage, new Rectangle(new Point(PosX + camera.X, PosY + camera.Y), new Size(SizeX, SizeY)), 0, 0, SizeX, SizeY, GraphicsUnit.Pixel);
                    else if (IsAtacking)
                        g.DrawImage(CurrImage, new Rectangle(new Point(PosX + camera.X, PosY + camera.Y), new Size(SizeX, SizeY + 3)), 256 * CurrFrame, 268 * CurrAnimation, SizeX, SizeY + 3, GraphicsUnit.Pixel);
                    else
                        g.DrawImage(CurrImage, new Rectangle(new Point(PosX + camera.X, PosY + camera.Y), new Size(SizeX, SizeY)), 256 * CurrFrame, 256 * CurrAnimation, SizeX, SizeY, GraphicsUnit.Pixel);
                    if (CheckCollision(student))
                    {
                        DrawBar(g, camera, student);
                    }
                }
                else
                {
                    FirstMap.RemoveEnemy(botCol);
                    g.DrawImage(CurrImage, new Rectangle(new Point(PosX + camera.X, PosY + camera.Y), new Size(SizeX, SizeY)), 256 * CurrDeathFrame, 0, SizeX, SizeY, GraphicsUnit.Pixel);

                }
            }
        }
        public void SetCurrImage(Image img, Image imghurted, int kostyl)
        {
            if (IsHurted && HealthPoint != 0)
            {
                CurrImage = imghurted;
                CurrLimit = 1;
            }
            else
            {
                CurrImage = img;
                IsHurted = false;
                switch (kostyl)
                {
                    case 0:
                        CurrLimit = IdleFrames;
                        break;
                    case 1:
                        CurrLimit = RunFrames;
                        break;
                    case 2:
                        CurrLimit = AttackFrames;
                        break;
                    case 3:
                        CurrLimit = DeathFrames;
                        break;
                }
            }
        }
        public bool CheckCollision(Student student)
        {
            Rectangle studentBounds = new Rectangle(student.PosX, student.PosY, student.SizeX, student.SizeY);
            Rectangle botBounds = new Rectangle(PosX, PosY, SizeX, SizeY);
            return studentBounds.IntersectsWith(botBounds);
        }
        public void DrawBar(Graphics g, Camera camera, Student student)
        {
            if (student.level == 1)
            {
                if (SizeX == 64)
                {
                    if (HealthPoint <= 100 && HealthPoint > 80)
                        g.DrawImage(Health, new Rectangle(new Point(PosX + camera.X, PosY + camera.Y - 15), new Size(SizeX, 13)), 0, 0, SizeX, 13, GraphicsUnit.Pixel);
                    else if (HealthPoint <= 80 && HealthPoint > 60)
                        g.DrawImage(Health, new Rectangle(new Point(PosX + camera.X, PosY + camera.Y - 15), new Size(SizeX, 13)), 0, 13, SizeX, 13, GraphicsUnit.Pixel);
                    else if (HealthPoint <= 60 && HealthPoint > 40)
                        g.DrawImage(Health, new Rectangle(new Point(PosX + camera.X, PosY + camera.Y - 15), new Size(SizeX, 13)), 0, 26, SizeX, 13, GraphicsUnit.Pixel);
                    else if (HealthPoint <= 40 && HealthPoint > 20)
                        g.DrawImage(Health, new Rectangle(new Point(PosX + camera.X, PosY + camera.Y - 15), new Size(SizeX, 13)), 0, 39, SizeX, 13, GraphicsUnit.Pixel);
                    else if (HealthPoint <= 20 && HealthPoint > 0)
                        g.DrawImage(Health, new Rectangle(new Point(PosX + camera.X, PosY + camera.Y - 15), new Size(SizeX, 13)), 0, 52, SizeX, 13, GraphicsUnit.Pixel);
                }
                else
                {
                    if (HealthPoint <= 400 && HealthPoint > 320)
                        g.DrawImage(Health, new Rectangle(new Point(PosX + camera.X, PosY + camera.Y - 15), new Size(SizeX, 13 * 4)), 0, 0, SizeX, 13 * 4, GraphicsUnit.Pixel);
                    else if (HealthPoint <= 320 && HealthPoint > 240)
                        g.DrawImage(Health, new Rectangle(new Point(PosX + camera.X, PosY + camera.Y - 15), new Size(SizeX, 13 * 4)), 0, 13 * 4, SizeX, 13 * 4, GraphicsUnit.Pixel);
                    else if (HealthPoint <= 240 && HealthPoint > 160)
                        g.DrawImage(Health, new Rectangle(new Point(PosX + camera.X, PosY + camera.Y - 15), new Size(SizeX, 13 * 4)), 0, 26 * 4, SizeX, 13 * 4, GraphicsUnit.Pixel);
                    else if (HealthPoint <= 160 && HealthPoint > 80)
                        g.DrawImage(Health, new Rectangle(new Point(PosX + camera.X, PosY + camera.Y - 15), new Size(SizeX, 13 * 4)), 0, 39 * 4, SizeX, 13 * 4, GraphicsUnit.Pixel);
                    else if (HealthPoint <= 80 && HealthPoint > 0)
                        g.DrawImage(Health, new Rectangle(new Point(PosX + camera.X, PosY + camera.Y - 15), new Size(SizeX, 13 * 4)), 0, 52 * 4, SizeX, 13 * 4, GraphicsUnit.Pixel);
                }
            }
            else if (student.level == 2)
            {
                if (SizeX == 64)
                {
                    if (HealthPoint <= 200 && HealthPoint > 160)
                        g.DrawImage(Health, new Rectangle(new Point(PosX + camera.X, PosY + camera.Y - 15), new Size(SizeX, 13)), 0, 0, SizeX, 13, GraphicsUnit.Pixel);
                    else if (HealthPoint <= 160 && HealthPoint > 120)
                        g.DrawImage(Health, new Rectangle(new Point(PosX + camera.X, PosY + camera.Y - 15), new Size(SizeX, 13)), 0, 13, SizeX, 13, GraphicsUnit.Pixel);
                    else if (HealthPoint <= 120 && HealthPoint > 80)
                        g.DrawImage(Health, new Rectangle(new Point(PosX + camera.X, PosY + camera.Y - 15), new Size(SizeX, 13)), 0, 26, SizeX, 13, GraphicsUnit.Pixel);
                    else if (HealthPoint <= 80 && HealthPoint > 40)
                        g.DrawImage(Health, new Rectangle(new Point(PosX + camera.X, PosY + camera.Y - 15), new Size(SizeX, 13)), 0, 39, SizeX, 13, GraphicsUnit.Pixel);
                    else if (HealthPoint <= 40 && HealthPoint > 0)
                        g.DrawImage(Health, new Rectangle(new Point(PosX + camera.X, PosY + camera.Y - 15), new Size(SizeX, 13)), 0, 52, SizeX, 13, GraphicsUnit.Pixel);
                }
                else
                {
                    if (HealthPoint <= 800 && HealthPoint > 640)
                        g.DrawImage(Health, new Rectangle(new Point(PosX + camera.X, PosY + camera.Y - 15), new Size(SizeX, 13 * 4)), 0, 0, SizeX, 13 * 4, GraphicsUnit.Pixel);
                    else if (HealthPoint <=  640 && HealthPoint > 480)
                        g.DrawImage(Health, new Rectangle(new Point(PosX + camera.X, PosY + camera.Y - 15), new Size(SizeX, 13 * 4)), 0, 13 * 4, SizeX, 13 * 4, GraphicsUnit.Pixel);
                    else if (HealthPoint <= 480 && HealthPoint > 320)
                        g.DrawImage(Health, new Rectangle(new Point(PosX + camera.X, PosY + camera.Y - 15), new Size(SizeX, 13 * 4)), 0, 26 * 4, SizeX, 13 * 4, GraphicsUnit.Pixel);
                    else if (HealthPoint <= 320 && HealthPoint > 160)
                        g.DrawImage(Health, new Rectangle(new Point(PosX + camera.X, PosY + camera.Y - 15), new Size(SizeX, 13 * 4)), 0, 39 * 4, SizeX, 13 * 4, GraphicsUnit.Pixel);
                    else if (HealthPoint <= 160 && HealthPoint > 0)
                        g.DrawImage(Health, new Rectangle(new Point(PosX + camera.X, PosY + camera.Y - 15), new Size(SizeX, 13 * 4)), 0, 52 * 4, SizeX, 13 * 4, GraphicsUnit.Pixel);
                }
            }
            else if(student.level == 3)
            {
                if (SizeX == 64)
                {
                    if (HealthPoint <= 300 && HealthPoint > 240)
                        g.DrawImage(Health, new Rectangle(new Point(PosX + camera.X, PosY + camera.Y - 15), new Size(SizeX, 13)), 0, 0, SizeX, 13, GraphicsUnit.Pixel);
                    else if (HealthPoint <= 240 && HealthPoint > 180)
                        g.DrawImage(Health, new Rectangle(new Point(PosX + camera.X, PosY + camera.Y - 15), new Size(SizeX, 13)), 0, 13, SizeX, 13, GraphicsUnit.Pixel);
                    else if (HealthPoint <= 180 && HealthPoint > 120)
                        g.DrawImage(Health, new Rectangle(new Point(PosX + camera.X, PosY + camera.Y - 15), new Size(SizeX, 13)), 0, 26, SizeX, 13, GraphicsUnit.Pixel);
                    else if (HealthPoint <= 120 && HealthPoint > 60)
                        g.DrawImage(Health, new Rectangle(new Point(PosX + camera.X, PosY + camera.Y - 15), new Size(SizeX, 13)), 0, 39, SizeX, 13, GraphicsUnit.Pixel);
                    else if (HealthPoint <= 60 && HealthPoint > 0)
                        g.DrawImage(Health, new Rectangle(new Point(PosX + camera.X, PosY + camera.Y - 15), new Size(SizeX, 13)), 0, 52, SizeX, 13, GraphicsUnit.Pixel);
                }
                else
                {
                    if (HealthPoint <= 1000 && HealthPoint > 800)
                        g.DrawImage(Health, new Rectangle(new Point(PosX + camera.X, PosY + camera.Y - 15), new Size(SizeX, 13 * 4)), 0, 0, SizeX, 13 * 4, GraphicsUnit.Pixel);
                    else if (HealthPoint <= 800 && HealthPoint > 600)
                        g.DrawImage(Health, new Rectangle(new Point(PosX + camera.X, PosY + camera.Y - 15), new Size(SizeX, 13 * 4)), 0, 13 * 4, SizeX, 13 * 4, GraphicsUnit.Pixel);
                    else if (HealthPoint <= 600 && HealthPoint > 400)
                        g.DrawImage(Health, new Rectangle(new Point(PosX + camera.X, PosY + camera.Y - 15), new Size(SizeX, 13 * 4)), 0, 26 * 4, SizeX, 13 * 4, GraphicsUnit.Pixel);
                    else if (HealthPoint <= 400 && HealthPoint > 200)
                        g.DrawImage(Health, new Rectangle(new Point(PosX + camera.X, PosY + camera.Y - 15), new Size(SizeX, 13 * 4)), 0, 39 * 4, SizeX, 13 * 4, GraphicsUnit.Pixel);
                    else if (HealthPoint <= 200 && HealthPoint > 0)
                        g.DrawImage(Health, new Rectangle(new Point(PosX + camera.X, PosY + camera.Y - 15), new Size(SizeX, 13 * 4)), 0, 52 * 4, SizeX, 13 * 4, GraphicsUnit.Pixel);
                }
            }
        }
    }
}
