using System;
using System.Drawing; // Добавлено пространство имен для типа Image
using System.Runtime.CompilerServices;
using Dungeons_.Cameras;
using Dungeons_.Interface;
using Dungeons_.Maps;

namespace Dungeons_.Entities
{
    public class Student : IEntity, IDisposable
    {
        // Реализация свойств интерфейса IEntity
        public int PosX { get; set; }
        public int PosY { get; set; }
        public int SizeX { get; set; }
        public int SizeY { get; set; }
        public int DirX { get; set; }
        public int DirY { get; set; }
        public int HealthPoint { get; set; }
        public bool IsMoving { get; set; }
        public bool IsAlive { get; set; }
        public bool IsHurted { get; set; }
        public Image IdleSprite { get; set; }
        public Image ShieldSprite { get; set; }
        public Image Health { get; set; }
        public Image Sausage { get; set; }
        public Image Key { get; set; }
        public Image damageSprite { get; set; }
        public Image LevelSprite { get; set; }
        public bool IsBlocking { get; set; }
        public int ShieldPosX { get; set; }
        public int ShieldPosY { get; set; }
        public bool IsAttacking { get; set; }
        public bool IsComplected { get; set; }
        public int CurrAnimation { get; set; }
        public int CurrFrame { get; set; }
        public int CurrDeathFrame { get; set; }
        public int CurrLimit { get; set; }
        public Image CurrImage { get; set; }
        public int Layer { get; set; }
        public int IdleFrames { get; set; }
        public int RunFrames { get; set; }
        public int AttackFrames { get; set; }
        public int DeathFrames { get; set; }
        public int Damage {  get; set; }
        public int DamageComplected { get; set; }
        public int countOfSausages { get; set; }
        public int countOfKeys { get; set; }
        public TextRender healthtext;
        public TextRender keytext;
        public TextRender sausagetext;
        public TextRender damagetext;
        public TextRender leveltext;
        public int level;

        public Student(int posX, int posY, int sizeX, int sizeY, Image idleSprite, Image health, Image sausage, Image key, Image damagesp, Image levelsp, int idleFrames, int runFrames, int attackFrames, int deathFrames, int Layer, int Level)
        {
            PosX = posX;
            PosY = posY;
            SizeX = sizeX;
            SizeY = sizeY;
            Health = health;
            Key = key;
            Sausage = sausage;
            damageSprite = damagesp;
            LevelSprite =levelsp;
            IsBlocking = false;
            ShieldPosX = posX;
            ShieldPosY = posY;
            IsAttacking = false;
            CurrAnimation = 0;
            CurrFrame = 0;
            CurrDeathFrame = 0;
            HealthPoint = 100;
            CurrLimit = idleFrames;
            CurrImage = idleSprite;
            IdleFrames = idleFrames;
            RunFrames = runFrames;
            AttackFrames = attackFrames;
            DeathFrames = deathFrames;
            IsComplected = false;
            IsAlive = true;
            IsHurted = false;
            this.Layer = Layer;
            countOfSausages = 0;
            countOfKeys = 0;
            Damage = 7;
            DamageComplected = 17;
            DirX = 0;
            DirY = 0;
            this.level = Level;
        }
        public void Move()
        {
           PosX += DirX;
           PosY += DirY;
        }
        public void CenterShield()
        {
            // Рассчитываем центр щита относительно персонажа
            int shieldCenterX = PosX + (SizeX / 2) - (ShieldSprite.Width / 2);
            int shieldCenterY = PosY + (SizeY / 2) - (ShieldSprite.Height / 2);

            // Устанавливаем координаты щита
            ShieldPosX = shieldCenterX;
            ShieldPosY = shieldCenterY;
        }

        public void SetShieldSprite(Image shield)
        {
            ShieldSprite = shield;
        }
        public void IsHurting(Bot bot)
        {
            if (IsAlive && bot.IsAlive)
            {
                if (CheckCollision(bot) && bot.IsAtacking && bot.CurrFrame == bot.CurrLimit - 3)
                {
                    IsHurted = true;
                }
                else
                {
                    IsHurted = false;
                }
            }
            else
                IsHurted = false;
        }
        public void UpgrateHealthBar(Bot bot)
        {
            if (IsAlive && bot.IsAlive)
            {
                if (CheckCollision(bot) && bot.IsAtacking && bot.CurrFrame == bot.CurrLimit - 3 && IsBlocking)
                {
                    if (HealthPoint < (int)(bot.damage / 2))
                        HealthPoint = 0;
                    else
                        HealthPoint -= (int)(bot.damage / 2);
                }
                else if (CheckCollision(bot) && bot.IsAtacking && bot.CurrFrame == bot.CurrLimit - 3)
                {
                    if (HealthPoint < bot.damage)
                        HealthPoint = 0;
                    else
                        HealthPoint -= bot.damage;
                }
            }
        }
        public void PlayAnimation(Graphics g, Camera camera, Student student)
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
                    CurrDeathFrame = CurrLimit - 1;
            }
            if (!IsAlive)
            {
                g.DrawImage(CurrImage, new Rectangle(new Point(PosX + camera.X, PosY + camera.Y - 120), new Size(164, 350)), 164 * CurrDeathFrame, 0, 164, 350, GraphicsUnit.Pixel);
                
            }
            else
            {
                g.DrawImage(CurrImage, new Rectangle(new Point(PosX + camera.X, PosY + camera.Y), new Size(SizeX, SizeY)), 60 * CurrFrame, 64 * CurrAnimation, SizeX, SizeY, GraphicsUnit.Pixel);
                Bar(g, camera);
                if (IsBlocking && ShieldSprite != null)
                {
                    CenterShield();
                    g.DrawImage(ShieldSprite, new Rectangle(new Point(ShieldPosX + camera.X, ShieldPosY + camera.Y), new Size(90, 90)), 0, 0, 90, 90, GraphicsUnit.Pixel);
                }
            }
        }   
                
            

        public void SetCurrImage(Image img, Image imgHurted, int kostyl)
        {
            if (IsHurted && HealthPoint != 0)
            {
                CurrImage = imgHurted;    
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
        public void Bar(Graphics g, Camera camera)
        {
            keytext = new TextRender(new Point(100, 435), 30, countOfKeys.ToString(), Color.White);
            sausagetext = new TextRender(new Point(100, 550), 30, countOfSausages.ToString(), Color.White);
            damagetext = new TextRender(new Point(595, 695), 30, ": " + (this.IsComplected ? DamageComplected.ToString() : Damage.ToString()), Color.FromArgb(251,190,88));
            leveltext = new TextRender(new Point(192, 0), 30, ": " + level.ToString(), Color.FromArgb(251, 190, 88));
            g.DrawImage(LevelSprite, new Rectangle(new Point((int)(15 * 1 / camera.Scale), (int)(17 * 1 / camera.Scale)), new Size((int)(184 / camera.Scale), (int)(24 / camera.Scale))), 0, 0, 184, 24, GraphicsUnit.Pixel);
            leveltext.DrawText(g);
            g.DrawImage(damageSprite, new Rectangle(new Point((int)(465 * 1/ camera.Scale), (int)(710 * 1 / camera.Scale)), new Size((int)(122 / camera.Scale), (int)(28 / camera.Scale))), 0, 0, 122, 28, GraphicsUnit.Pixel);
            damagetext.DrawText(g);
            g.DrawImage(Key, new Rectangle(new Point(0, (int)(420 * 1 / camera.Scale)), new Size((int)(74 / camera.Scale), (int)(100 / camera.Scale))), 0, 0, 74, 100, GraphicsUnit.Pixel);
            keytext.DrawText(g);
            g.DrawImage(Sausage, new Rectangle(new Point(0, (int)(535 * 1 / camera.Scale)), new Size((int)(82 / camera.Scale), (int)(100 / camera.Scale))), 0, 0, 82, 100, GraphicsUnit.Pixel);
            sausagetext.DrawText (g);
            if (HealthPoint <= 100 && HealthPoint > 90)
                g.DrawImage(Health, new Rectangle(new Point(0, (int)(650 * 1 / camera.Scale)), new Size((int)(371 / camera.Scale), (int)(112 / camera.Scale))), 0, 0, 371, 112, GraphicsUnit.Pixel);
            else if (HealthPoint <= 90 && HealthPoint > 80)
                g.DrawImage(Health, new Rectangle(new Point(0, (int)(650 * 1 / camera.Scale)), new Size((int)(371 / camera.Scale), (int)(112 / camera.Scale))), 0, 112, 371, 112, GraphicsUnit.Pixel);
            else if (HealthPoint <= 80 && HealthPoint > 70)
                g.DrawImage(Health, new Rectangle(new Point(0, (int)(650 * 1 / camera.Scale)), new Size((int)(371 / camera.Scale), (int)(112 / camera.Scale))), 0, 224, 371, 112, GraphicsUnit.Pixel);
            else if (HealthPoint <= 70 && HealthPoint > 60)
                g.DrawImage(Health, new Rectangle(new Point(0, (int)(650 * 1 / camera.Scale)), new Size((int)(371 / camera.Scale), (int)(112 / camera.Scale))), 0, 336, 371, 112, GraphicsUnit.Pixel);
            else if (HealthPoint <= 60 && HealthPoint > 50)
                g.DrawImage(Health, new Rectangle(new Point(0, (int)(650 * 1 / camera.Scale)), new Size((int)(371 / camera.Scale), (int)(112 / camera.Scale))), 0, 448, 371, 112, GraphicsUnit.Pixel);
            else if (HealthPoint <= 50 && HealthPoint > 40)
                g.DrawImage(Health, new Rectangle(new Point(0, (int)(650 * 1 / camera.Scale)), new Size((int)(371 / camera.Scale), (int)(112 / camera.Scale))), 0, 560, 371, 112, GraphicsUnit.Pixel);
            else if (HealthPoint <= 40 && HealthPoint > 30)
                g.DrawImage(Health, new Rectangle(new Point(0, (int)(650 * 1 / camera.Scale)), new Size((int)(371 / camera.Scale), (int)(112 / camera.Scale))), 0, 672, 371, 112, GraphicsUnit.Pixel);
            else if (HealthPoint <= 30 && HealthPoint > 20)
                g.DrawImage(Health, new Rectangle(new Point(0, (int)(650 * 1 / camera.Scale)), new Size((int)(371 / camera.Scale), (int)(112 / camera.Scale))), 0, 784, 371, 112, GraphicsUnit.Pixel);
            else if (HealthPoint <= 20 && HealthPoint > 10)
                g.DrawImage(Health, new Rectangle(new Point(0, (int)(650 * 1 / camera.Scale)), new Size((int)(371 / camera.Scale), (int)(112 / camera.Scale))), 0, 896, 371, 112, GraphicsUnit.Pixel);
            else if (HealthPoint <= 10 && HealthPoint > 0)
                g.DrawImage(Health, new Rectangle(new Point(0, (int)(650 * 1 / camera.Scale)), new Size((int)(371 / camera.Scale), (int)(112 / camera.Scale))), 0, 1008, 371, 112, GraphicsUnit.Pixel);
            else if (HealthPoint == 0)
                g.DrawImage(Health, new Rectangle(new Point(0, (int)(650 * 1 / camera.Scale)), new Size((int)(371 / camera.Scale), (int)(112 / camera.Scale))), 0, 1120, 371, 112, GraphicsUnit.Pixel);
            healthtext = new TextRender(new Point(370, 700), 22, HealthPoint.ToString(), Color.White);
            healthtext.DrawText(g);
        }
        public void Dispose()
        {
            // Освобождаем ресурсы Image
            IdleSprite?.Dispose();
            ShieldSprite?.Dispose();
            Health?.Dispose();
            Sausage?.Dispose();
            Key?.Dispose();
            damageSprite?.Dispose();

            // Освобождаем объекты TextRender, если они используют IDisposable
            healthtext?.Dispose();
            keytext?.Dispose();
            sausagetext?.Dispose();
            damagetext?.Dispose();
            leveltext?.Dispose();
        }

        public bool CheckCollision(Bot bot)
        {
            Rectangle studentBounds = new Rectangle(PosX, PosY, SizeX, SizeY);
            Rectangle botBounds = new Rectangle(bot.PosX, bot.PosY, bot.SizeX, bot.SizeY);
            return studentBounds.IntersectsWith(botBounds);
        }
        public bool CheckCollision(Node Room)
        {
            Rectangle studentBounds = new Rectangle(PosX, PosY, SizeX, SizeY);
            Rectangle RoomBounds = new Rectangle(Room.Position.X, Room.Position.Y, Room.Size.Width * Room.cellSize, Room.Size.Height * Room.cellSize);
            return studentBounds.IntersectsWith(RoomBounds);
        }
    }
}