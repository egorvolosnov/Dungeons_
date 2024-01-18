using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dungeons_.Entities;
using Dungeons_.Models;
using Dungeons_.Maps;
using Dungeons_.Cameras;
using Dungeons_.Interface;
using System.Security.Policy;
namespace Dungeons_
{
    public partial class Form1 : Form
    {
        public Image studentRun;
        public Image studentIdle;
        public Image studentAttack;
        public Image studentRunComplected;
        public Image studentIdleComplected;
        public Image studentAttackComplected;
        public Image studentRunHurted;
        public Image studentIdleHurted;
        public Image studentAttackHurted;
        public Image studentRunComplectedHurted;
        public Image studentIdleComplectedHurted;
        public Image studentAttackComplectedHurted;

        public Image botRun;
        public Image botIdle;
        public Image botAttack;
        public Image botHurted;
        public Image botDeath;
        public Image botHP;

        public Image bossRun;
        public Image bossIdle;
        public Image bossAttack;
        public Image bossHurted;
        public Image bossDeath;
        public Image bossHP;
       
        public Image studentBlock;
        public Image studentDeath;
        public Image complectionSprite;
        public Image boxSprite;
        public Image doorSprite;
        public Image door2Sprite;
        public Image sausageSprite;
        public Image keySprite;
        public Student student;
        public Image CatSprite;
        public Image HealthSprite;
        public Image SausageBar;
        public Image KeyBar;
        public Image HPBaff;
        public Image DBaff;
        public Image DamageStudent;
        public Image Fontain;
        public Image Boss;
        public Image LevelDoor;
        public Image ButtonHover;
        public Image LevelSprite;
        public Image End;

        private List<Door> doors;
        private Door door1;
        private Door door2;
        private Door door3;
        private Door door4;
        private Door door5;
        private Door door6;
        private Door door7;
        private Door door8;
        private Door door9;
        private Door door10;
        private Door door11;
        private Door door12;
        private Door door13;
        private Door door14;
        private Door door15;
        private Door door16;
        private Door door17;
        private Door door18;
        private Door door19;
        private Door door20;
        private Door door21;
        private Door door22;
        private Door door23;
        private Door door24;
        private Door leveldoor;

        private Complection complection;
        private Timer objectAnimationTimer;
        private Camera camera;
        private Graph mapGraph;

        private Node firstRoom;
        private Node secondRoom;
        private Node thirdRoom;
        private Node firthRoom;
        private Node fifthRoom;
        private Node sixthRoom;
        private Node seventhRoom;
        private Node eighthRoom;
        private Node ninethRoom;
        private Node tenthRoom;
        private Node eleventhRoom;
        private Node twelfthRoom;
        private Node thirteenthRoom;
        private Node fourteenthRoom;
        private Node fifteenthRoom;
        private Node sixteenthRoom;
        private Node seventeenthRoom;
        private Node eighteenthRoom;
        private Node nineteenthRoom;
        private Node twentithRoom;
        private Node twentyfirstRoom;
        private Node twentysecondRoom;
        private Node twentythirdRoom;

        private List<Cat> cats;
        private Cat cat1;
        private Cat cat2;
        private Cat cat3;

        private List<Sausage> sausages;
        private Sausage sausage1;
        private Sausage sausage2;
        private Sausage sausage3;

        private List<Bot> bots;
        private Bot bot1;
        private Bot bot2;
        private Bot bot3;
        private Bot bot4;
        private Bot bot5;
        private Bot bot6;
        private Bot bot7;
        private Bot bot8;
        private Bot bot9;
        private Bot bot10;
        private Bot bot11;
        private Bot bot12;
        private Bot bot13;
        private Bot bot14;
        private Bot bot15;
        private Bot bot16;
        private Bot bot17;
        private Bot bot18;
        private Bot bot19;
        private Bot bot20;
        private Bot bot21;
        private Bot bot22;
        private Bot boss;

        private List<DamageBaff> damageBaffs;
        private DamageBaff db1;
        private DamageBaff db2;
        private DamageBaff db3;
        private DamageBaff db4;

        private List<HPBaff> hPBaffs;
        private HPBaff hp1;
        private HPBaff hp2;
        private HPBaff hp3;
        private HPBaff hp4;
        private HPBaff hp5;
        private HPBaff hp6;
        private HPBaff hp7;
        private HPBaff hp8;
        private HPBaff hp9;
        private HPBaff hp10;
        private HPBaff hp11;
        private HPBaff fontain;
        private HPBaff fontain1;
        private List<Node> RoomsWithEnemy;
        private Form2 fm;
        public  int Level;
        public Student laststud;

        public Form1(Form2 fm, int Level, Student last)
        {
            InitializeComponent();
            this.fm = fm;
            this.Level = Level;
            this.laststud = last;
            Init();
            
        }
        private void DisposeImages()
        {
            studentRun?.Dispose();
            studentIdle?.Dispose();
            studentAttack?.Dispose();
            studentRunComplected?.Dispose();
            studentIdleComplected?.Dispose();
            studentAttackComplected?.Dispose();
            studentRunHurted?.Dispose();
            studentIdleHurted?.Dispose();
            studentAttackHurted?.Dispose();
            studentRunComplectedHurted?.Dispose();
            studentIdleComplectedHurted?.Dispose();
            studentAttackComplectedHurted?.Dispose();

            botRun?.Dispose();
            botIdle?.Dispose();
            botAttack?.Dispose();
            botHurted?.Dispose();
            botDeath?.Dispose();
            botHP?.Dispose();

            bossRun?.Dispose();
            bossIdle?.Dispose();
            bossAttack?.Dispose();
            bossHurted?.Dispose();
            bossDeath?.Dispose();
            bossHP?.Dispose();

            studentBlock?.Dispose();
            studentDeath?.Dispose();
            complectionSprite?.Dispose();
            boxSprite?.Dispose();
            doorSprite?.Dispose();
            door2Sprite?.Dispose();
            sausageSprite?.Dispose();
            keySprite?.Dispose();
            LevelSprite?.Dispose();
            CatSprite?.Dispose();
            HealthSprite?.Dispose();
            SausageBar?.Dispose();
            KeyBar?.Dispose();
            HPBaff?.Dispose();
            DBaff?.Dispose();
            DamageStudent?.Dispose();
            Fontain?.Dispose();
            Boss?.Dispose();
            LevelDoor?.Dispose();
            ButtonHover?.Dispose();
            RoomsWithEnemy?.Clear();
            Reset();
            student?.Dispose();
            laststud?.Dispose();
            cat1?.Dispose();
            cat2?.Dispose();
            cat3?.Dispose();
           
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Вызываем метод DisposeImages при закрытии формы
            DisposeImages();
        }
        private void ApplyHoverStyles(Button button, Image hoverImage, Color hoverTextColor, bool SubOrUn)
        {
            // Сохраняем оригинальные изображение и цвет текста кнопки
            Image originalImage = button.BackgroundImage;
            Color originalTextColor = button.ForeColor;
            if (SubOrUn)
            {
                button.MouseEnter += (sender, e) =>
                {
                // Устанавливаем изображение и цвет текста при наведении
                button.BackgroundImage = hoverImage;
                button.ForeColor = hoverTextColor;
                };

                button.MouseLeave += (sender, e) =>
                {
                    // Возвращаем оригинальное изображение и цвет текста после ухода указателя мыши
                    button.BackgroundImage = originalImage;
                    button.ForeColor = originalTextColor;
                };
            }
            else
            {
                button.MouseEnter -= (sender, e) =>
                {
                    // Устанавливаем изображение и цвет текста при наведении
                    button.BackgroundImage = hoverImage;
                    button.ForeColor = hoverTextColor;
                };

                button.MouseLeave -= (sender, e) =>
                {
                    // Возвращаем оригинальное изображение и цвет текста после ухода указателя мыши
                    button.BackgroundImage = originalImage;
                    button.ForeColor = originalTextColor;
                };
            }
        }
        

        private void OnMouseWheel(object sender, MouseEventArgs e)
        {
            if (student.IsAlive)
            {
                // Изменяем масштаб камеры при вращении колеса мыши
                if (e.Delta > 0)
                    camera.Scale += 0.1f;
                else if (e.Delta < 0 && camera.Scale > 0.1f)
                    camera.Scale -= 0.1f;

                
            }
            // Обновляем координаты камеры после изменения масштаба
            camera.Update(student, this.Width, this.Height);
            Invalidate();
        }
        private void OnMouseup(object sender, MouseEventArgs e)
        {
            if(student.IsAlive)
            {
                if (e.Button == MouseButtons.Left)
                {
                    student.DirX = 0;
                    student.DirY = 0;
                    student.IsMoving = false;
                    studentTimer.Interval = 1500;
                    if (!student.IsComplected)
                        student.SetCurrImage(studentIdle, studentIdleHurted, 0);
                    else
                        student.SetCurrImage(studentIdleComplected, studentIdleComplectedHurted, 0);
                    student.IsAttacking = false;
                }
                else if (e.Button == MouseButtons.Right)
                    student.IsBlocking = false;
            }
            
        }

        public void OnMouseClick(object sender, MouseEventArgs e)
        {
            if(student.IsAlive)
            {
                if (e.Button == MouseButtons.Left)
                {
                    studentTimer.Interval = 100;
                    student.DirY = 0;
                    student.DirX = 0;
                    student.IsMoving = false;
                    if (!student.IsComplected)
                        student.SetCurrImage(studentAttack, studentAttackHurted, 2);
                    else
                        student.SetCurrImage(studentAttackComplected, studentAttackComplectedHurted, 2);
                    student.IsAttacking = true;
                }
                else if (e.Button == MouseButtons.Right && student.IsComplected)
                {
                    student.SetShieldSprite(studentBlock);
                    student.IsBlocking = true;
                }
            }
            
        }

        public void OnKeyup(object sender, KeyEventArgs e)
        {
            if (student.IsAlive)
            {
                switch (e.KeyCode)
                {
                    case Keys.W:
                        student.DirY = 0;
                        break;
                    case Keys.S:
                        student.DirY = 0;
                        break;
                    case Keys.A:
                        student.DirX = 0;
                        break;
                    case Keys.D:
                        student.DirX = 0;
                        break;
                }
                student.IsMoving = false;
                if (student.IsAttacking == false)
                    studentTimer.Interval = 1500;
                if (!student.IsComplected)
                    student.SetCurrImage(studentIdle, studentIdleHurted, 0);
                else
                    student.SetCurrImage(studentIdleComplected, studentIdleComplectedHurted, 0);
                
            }
        }

        public void OnPress(object sender, KeyEventArgs e)
        {
            if(student.IsAlive)
            {
                switch (e.KeyCode)
                {
                    case Keys.W:

                        studentTimer.Interval = 50;
                        student.DirY = -7;
                        student.IsMoving = true;
                        if (!student.IsComplected)
                            student.SetCurrImage(studentRun, studentRunHurted, 1);
                        else
                            student.SetCurrImage(studentRunComplected, studentRunComplectedHurted, 1);
                        student.CurrAnimation = 3;
                        break;
                    case Keys.A:

                        studentTimer.Interval = 50;
                        student.DirX = -7;
                        student.IsMoving = true;
                        if (!student.IsComplected)
                            student.SetCurrImage(studentRun, studentRunHurted, 1);
                        else
                            student.SetCurrImage(studentRunComplected, studentRunComplectedHurted, 1);
                        student.CurrAnimation = 1;
                        break;
                    case Keys.S:

                        studentTimer.Interval = 50;
                        student.DirY = 7;
                        student.IsMoving = true;
                        if (!student.IsComplected)
                            student.SetCurrImage(studentRun, studentRunHurted, 1);
                        else
                            student.SetCurrImage(studentRunComplected, studentRunComplectedHurted, 1);
                        student.CurrAnimation = 0;
                        break;
                    case Keys.D:

                        studentTimer.Interval = 50;
                        student.DirX = 7;
                        student.IsMoving = true;
                        if (!student.IsComplected)
                            student.SetCurrImage(studentRun, studentRunHurted, 1);
                        else
                            student.SetCurrImage(studentRunComplected, studentRunComplectedHurted, 1);
                        student.CurrAnimation = 2;
                        break;

                    case Keys.E:
                        if(Level == 1)
                            complection.HandleInteraction(student);
                        foreach(var door in doors)
                            door.HandleInteractionDoor(student);
                        foreach(var sausage in sausages)
                            sausage.HandleInteraction(student);
                        foreach(var cat in cats)
                        {
                            cat.HandleInteractionCat(student);
                            cat.HandleInteractionKey(student);
                        }    
                        foreach(var hp in hPBaffs)
                            hp.HandleInteraction(student);
                        foreach(var db in damageBaffs)
                            db.HandleInteraction(student);
                        break;
                    case Keys.G:
                        complection.DropComplection(student);
                        break;
                }
            }
            
        }
        public void updateStudent(object sender, EventArgs e)
        {
            if (student.HealthPoint == 0)
            {
                student.SetCurrImage(studentDeath, studentDeath, 3);
                student.IsAlive = false;
                studentTimer.Interval = 300;
                camera.Scale = 2.2f;
            }
            else
            {
                if (student.IsAttacking)
                {
                    student.IsMoving = false; // Останавливаем персонажа во время атаки
                    if (!student.IsComplected)
                        student.SetCurrImage(studentAttack, studentAttackHurted, 2);
                    else
                        student.SetCurrImage(studentAttackComplected, studentAttackComplectedHurted, 2);

                }
                else
                {
                    Collizia.IsColide(student, new Point(student.DirX, student.DirY), 5, FirstMap.mapObjDel);
                    Collizia.IsColide(student, new Point(student.DirX, student.DirY), 5, FirstMap.mapObj);
                    Collizia.IsColide(student, new Point(student.DirX, student.DirY), 10, FirstMap.mapEnemy);
                    if (student.IsMoving)
                    {
                        student.Move();  
                    }
                    
                }
                
            }
            foreach (var bot in bots)
                student.IsHurting(bot);
            camera.Update(student, this.Width, this.Height);
            student.level = Level;
            Invalidate();
        }
        public void UpgrateBot(Bot bot)
        {
            if (bot.HealthPoint == 0)
            {
                bool flag = false;
                foreach(var botes in bots)
                {
                    if(botes.Room == bot.Room)
                        flag = true;
                }
                if (!flag)
                    objectAnimationTimer.Interval = 300;
                if(bot.SizeX == 64)
                    bot.SetCurrImage(botDeath, botDeath, 3);
                else
                    bot.SetCurrImage(bossDeath, bossDeath, 3);
                bot.IsAlive = false;

            }
            else if(bot.HealthPoint != 0)
            {
                bot.IsHurting(student);
                RoomsWithEnemy.Add(bot.Room);
                if (student.CheckCollision(bot.Room))
                {
                    if (!bot.CheckCollision(student))
                    {
                        Collizia.IsColide(bot, new Point(bot.DirX, bot.DirY), 5, FirstMap.mapObjDel);
                        Collizia.IsColide(bot, new Point(bot.DirX, bot.DirY), 5, FirstMap.mapObj);
                        bot.IsMoving = true;
                        bot.IsAtacking = false;
                        bot.Move();
                        objectAnimationTimer.Interval = 90;
                        if(bot.SizeX == 64)
                            bot.SetCurrImage(botRun, botHurted, 1);
                        else
                            bot.SetCurrImage(bossRun, bossHurted, 1);
                    }
                    else
                    {
                        bot.IsMoving = false;
                        bot.IsAtacking = true;
                        objectAnimationTimer.Interval = 140;
                        if (bot.SizeX == 64)
                            bot.SetCurrImage(botAttack, botHurted, 2);
                        else
                            bot.SetCurrImage(bossAttack, bossHurted, 2);
                    }
                }
                else 
                {
                    bool interect = false;
                    bot.IsMoving = false;
                    bot.IsAtacking = false;
                    if (bot.SizeX == 64)
                        bot.SetCurrImage(botIdle, botHurted, 0);
                    else
                        bot.SetCurrImage(bossIdle, botHurted, 0);
                    foreach (var room in RoomsWithEnemy)
                    {
                        if (student.CheckCollision(room))
                        {
                            interect = true;
                        }
                        
                    }
                    if(!interect)
                        objectAnimationTimer.Interval = 300;
                }
                
            }
            
           
        }
        public void objectUpdate(object sender, EventArgs e)
        {
            foreach(var bot in bots)
            {
                UpgrateBot(bot);
                student.UpgrateHealthBar(bot);
                bot.Update(student);
            }
            
            hp1.Update(bot1);
            hp2.Update(bot3);
            hp3.Update(bot4);
            hp4.Update(bot5);
            hp5.Update(bot8);
            hp6.Update(bot10);
            hp7.Update(bot13);
            hp8.Update(bot17);
            hp9.Update(bot18);
            hp10.Update(bot19);
            hp11.Update(bot20);
            fontain.Update(null);
            if (Level == 2 || Level == 3)
                fontain1.Update(null);
            foreach (var cat in cats)
            {
                cat.updateCat();
                cat.updateKey();
            }    
            foreach(var sausage in sausages)
                sausage.Update();
            foreach (var db in damageBaffs)
                db.Update();
            
            if(leveldoor.wasOpened && Level < 3)
            {
                Level++;
                fm.Panelform(new Form1(fm, Level, student));
            }
            if (Level == 1)
                complection.Update(student);
            foreach(var node in mapGraph.nodes)
            {
                node.level = Level;
            }
            secondRoom.update(door1.wasOpened);
            thirdRoom.update(door2.wasOpened);
            fifthRoom.update(door3.wasOpened || door7.wasOpened);
            firthRoom.update(door4.wasOpened || door6.wasOpened);
            sixthRoom.update(door5.wasOpened || door8.wasOpened);
            seventhRoom.update(door6.wasOpened || door9.wasOpened);
            eighthRoom.update(door9.wasOpened|| door10.wasOpened);
            ninethRoom.update(door10.wasOpened|| door11.wasOpened);
            tenthRoom.update(door11.wasOpened|| door12.wasOpened);
            eleventhRoom.update(door12.wasOpened|| door13.wasOpened || door7.wasOpened);
            twelfthRoom.update(door13.wasOpened || door14.wasOpened);
            thirteenthRoom.update(door14.wasOpened|| door15.wasOpened);
            fourteenthRoom.update(door15.wasOpened|| door16.wasOpened);
            fifteenthRoom.update(door16.wasOpened|| door8.wasOpened);
            sixteenthRoom.update(door17.wasOpened);
            seventeenthRoom.update(door18.wasOpened);
            eighteenthRoom.update(door19.wasOpened);
            nineteenthRoom.update(door20.wasOpened);
            twentithRoom.update(door21.wasOpened);
            twentyfirstRoom.update(door22.wasOpened);
            twentysecondRoom.update(door23.wasOpened);
            twentythirdRoom.update(door24.wasOpened);
            FirstMap.ClearLists();
            Invalidate();
        }
        
        public void Reset()
        {
            FirstMap.ClearLists();
            mapGraph.nodes.Clear();
            doors.Clear();
            cats.Clear();
            sausages.Clear();
            bots.Clear();
            hPBaffs.Clear();
            damageBaffs.Clear();
            RoomsWithEnemy.Clear();
            studentTimer.Stop();
            objectAnimationTimer.Stop();
        }
        public void Init()
        {
            studentRun = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\movement\\student.png"));
            studentIdle = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\silent\\studentsilent.png"));
            studentAttack = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\fight\\student_fight.png"));
            studentRunComplected = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\movement\\student_complected.png"));
            studentIdleComplected = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\silent\\studentsilent_complected.png"));
            studentAttackComplected = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\fight\\student_fight_complected.png"));
            studentRunHurted = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\hurt\\student_hurted.png"));
            studentIdleHurted = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\hurt\\studentsilent_hurted.png"));
            studentAttackHurted = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\hurt\\student_fight_hurted.png"));
            studentRunComplectedHurted = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\hurt\\student_complected_hurted.png"));
            studentIdleComplectedHurted = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\hurt\\studentsilent_complected_hurted.png"));
            studentAttackComplectedHurted = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\hurt\\student_fight_complected_hurted.png"));
            studentBlock = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\shield3.png"));
            studentDeath = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\death\\student_death.png"));
            if(Level == 1 || Level == 3)
            {
                botRun = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\movement\\bot.png"));
                botIdle = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\silent\\bot_silent.png"));
                botAttack = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\fight\\bot_fight.png"));
                botDeath = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\death\\bot_death.png"));
                botHurted = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\hurt\\bot_hurted.png"));
                

                bossRun = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\movement\\boss.png"));
                bossIdle = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\silent\\boss_silent.png"));
                bossAttack = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\fight\\boss_fight.png"));
                bossDeath = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\death\\boss_death.png"));
                bossHurted = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\hurt\\boss_hurted.png"));
                
            }
            else if(Level == 2)
            {
                botRun = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\movement\\bot1.png"));
                botIdle = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\silent\\bot1_silent.png"));
                botAttack = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\fight\\bot1_fight.png"));
                botDeath = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\death\\bot1_death.png"));
                botHurted = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\hurt\\bot1_hurted.png"));
                

                bossRun = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\movement\\boss1.png"));
                bossIdle = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\silent\\boss1_silent.png"));
                bossAttack = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\fight\\boss1_fight.png"));
                bossDeath = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\death\\boss1_death.png"));
                bossHurted = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\hurt\\boss1_hurted.png"));
            }
            botHP = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\botHP.png"));
            bossHP = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\bossHP.png"));


            complectionSprite = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\animation_of_complection.png"));
            boxSprite = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\box.png"));
            doorSprite = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\door.png"));
            door2Sprite = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\door2.png"));
            CatSprite = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\Cat.png"));
            sausageSprite = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\sousageAnim.png"));
            keySprite = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\KeyAnim.png"));
            HealthSprite = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\healthbar.png"));
            SausageBar = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\SausageBar.png"));
            KeyBar = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\KeyBar.png"));
            HPBaff = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\HPBAFF.png"));
            DBaff = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\damagebaff.png"));
            DamageStudent = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\DAMAGE.png"));
            Fontain = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\fontain.png"));
            LevelDoor = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\leveldoor.png"));
            ButtonHover = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\buttonhover.png"));
            LevelSprite = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\Level.png"));
            End = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\end.png"));

            KeyDown += OnPress;
            KeyUp += OnKeyup;
            MouseDown += OnMouseClick;
            MouseUp += OnMouseup;
            MouseWheel += OnMouseWheel;
            ApplyHoverStyles(button1, ButtonHover, Color.White, true);
            ApplyHoverStyles(button2, ButtonHover, Color.White, true);
            ApplyHoverStyles(button3, ButtonHover, Color.White, true);
            FirstMap.Init();
            mapGraph = new Graph();
            doors = new List<Door>();
            cats = new List<Cat>();
            sausages = new List<Sausage>();
            bots = new List<Bot>();
            hPBaffs = new List<HPBaff>();
            damageBaffs = new List<DamageBaff>();
            RoomsWithEnemy = new List<Node>();
            student = new Student(100, 100, 60, 64, studentIdle, HealthSprite, SausageBar, KeyBar, DamageStudent, LevelSprite, Hero.idleFrames, Hero.runFrames, Hero.attackFrames, Hero.deathFrames, 2, Level);
            if(laststud != null)
            {
                if (laststud.IsComplected)
                    student.IsComplected = true;
                student.HealthPoint = laststud.HealthPoint;
                student.Damage = laststud.Damage;
                student.DamageComplected = laststud.DamageComplected;
            }
            if (Level == 1)
                complection = new Complection(200, 200, complectionSprite, boxSprite);
            else if(Level == 2 || Level == 3)
            {
                fontain1 = new HPBaff(300, 100, 168, 150, Fontain);
                hPBaffs.Add(fontain1);
            }
                

            firstRoom = new Node(1, new Point(0, 0), new Size(30, 20), true, Level);
            mapGraph.nodes.Add(firstRoom);

            secondRoom = new Node(2, new Point(208,-380), new Size(9, 20), false, Level);
            mapGraph.nodes.Add(secondRoom);

            thirdRoom = new Node(3, new Point(0, -760), new Size(30, 20), false , Level);
            mapGraph.nodes.Add(thirdRoom);

            firthRoom = new Node(4, new Point(-380, -665), new Size(20, 9), false, Level);
            mapGraph.nodes.Add(firthRoom);

            fifthRoom = new Node(5, new Point(208, -1140), new Size(9, 20), false, Level);
            mapGraph.nodes.Add(fifthRoom);

            sixthRoom = new Node(6, new Point(570, -665), new Size(20, 9), false, Level);
            mapGraph.nodes.Add(sixthRoom);

            seventhRoom = new Node(7, new Point(-950, -760), new Size(30, 20), false, Level);
            mapGraph.nodes.Add(seventhRoom);

            eighthRoom = new Node(8, new Point(-742, -1140), new Size(9, 20), false, Level);
            mapGraph.nodes.Add(eighthRoom);

            ninethRoom = new Node(9, new Point(-950, -1520), new Size(30, 20), false, Level);
            mapGraph.nodes.Add(ninethRoom);

            tenthRoom = new Node(10, new Point(-380, -1425), new Size(20, 9), false, Level);
            mapGraph.nodes.Add(tenthRoom);

            eleventhRoom = new Node(11, new Point(0, -1520), new Size(30, 20), false, Level);
            mapGraph.nodes.Add(eleventhRoom);

            twelfthRoom = new Node(12, new Point(570, -1425), new Size(20, 9), false, Level);
            mapGraph.nodes.Add(twelfthRoom);

            thirteenthRoom = new Node(13, new Point(950, -1520), new Size(30, 20), false, Level);
            mapGraph.nodes.Add(thirteenthRoom);

            fourteenthRoom = new Node(14, new Point(1158, -1140), new Size(9, 20), false, Level);
            mapGraph.nodes.Add(fourteenthRoom);

            fifteenthRoom = new Node(15, new Point(950, -760), new Size(30, 20), false, Level);
            mapGraph.nodes.Add(fifteenthRoom);

            sixteenthRoom = new Node(16, new Point(1158, -380), new Size(9, 20), false, Level);
            mapGraph.nodes.Add(sixteenthRoom);

            seventeenthRoom = new Node(17, new Point(950, 0), new Size(30, 20), false, Level);
            mapGraph.nodes.Add(seventeenthRoom);

            eighteenthRoom = new Node(18, new Point(1520, 95), new Size(20, 9), false, Level);
            mapGraph.nodes.Add(eighteenthRoom);

            nineteenthRoom = new Node(19, new Point(1900, 0), new Size(30, 20), false, Level);
            mapGraph.nodes.Add(nineteenthRoom);

            twentithRoom = new Node(20, new Point(1158, -1900), new Size(9, 20), false, Level);
            mapGraph.nodes.Add(twentithRoom);

            twentyfirstRoom = new Node(21, new Point(950, -2280), new Size(30, 20), false, Level);
            mapGraph.nodes.Add(twentyfirstRoom);

            twentysecondRoom = new Node(22, new Point(1520, -2185), new Size(20, 9), false, Level);
            mapGraph.nodes.Add(twentysecondRoom);

            twentythirdRoom = new Node(23, new Point(1900, -2280), new Size(30, 20), false, Level);
            mapGraph.nodes.Add(twentythirdRoom);

            this.Width = firstRoom.GetWidth()+19;
            this.Height = firstRoom.GetHeight()+38;
            camera = new Camera(student, this.Width, this.Height);


            door1 = new Door(firstRoom.Position.X + (firstRoom.Size.Width * firstRoom.cellSize) / 2 - 19, firstRoom.Position.Y, doorSprite, 1);
            doors.Add(door1);

            door2 = new Door((secondRoom.Size.Width * secondRoom.cellSize) / 2 - 29 + secondRoom.Position.X, secondRoom.Position.Y, doorSprite, 1);
            doors.Add((door2));

            door3 = new Door(thirdRoom.Position.X + (thirdRoom.Size.Width * thirdRoom.cellSize) / 2 - 19, thirdRoom.Position.Y, doorSprite, 1);
            doors.Add(door3);

            door4 = new Door(thirdRoom.Position.X - 19, thirdRoom.Position.Y + (thirdRoom.Size.Height * thirdRoom.cellSize) / 2 - 19,  door2Sprite, 2);
            doors.Add(door4);

            door5 = new Door(thirdRoom.Position.X + thirdRoom.Size.Width * thirdRoom.cellSize - 19, thirdRoom.Position.Y + (thirdRoom.Size.Height * thirdRoom.cellSize) / 2 - 19,  door2Sprite, 3);
            doors.Add(door5);

            door6 = new Door(firthRoom.Position.X - 19, thirdRoom.Position.Y + (thirdRoom.Size.Height * thirdRoom.cellSize) / 2 - 19, door2Sprite, 2);
            doors.Add(door6);

            door7 = new Door((fifthRoom.Size.Width * fifthRoom.cellSize) / 2 - 29 + fifthRoom.Position.X, fifthRoom.Position.Y, doorSprite, 1);
            doors.Add(door7);

            door8 = new Door(sixthRoom.Size.Width * sixthRoom.cellSize + sixthRoom.Position.X - 19, sixthRoom.Position.Y + (sixthRoom.Size.Height * sixthRoom.cellSize) / 2 - 10, door2Sprite, 3);
            doors.Add(door8);

            door9 = new Door(seventhRoom.Position.X + (seventhRoom.Size.Width * seventhRoom.cellSize) / 2 - 19, seventhRoom.Position.Y, doorSprite, 1);
            doors.Add(door9);

            door10 = new Door(eighthRoom.Position.X + (eighthRoom.Size.Width * eighthRoom.cellSize) / 2 - 29, eighthRoom.Position.Y, doorSprite, 1);
            doors.Add(door10);

            door11 = new Door(ninethRoom.Position.X + thirdRoom.Size.Width * thirdRoom.cellSize - 19, ninethRoom.Position.Y + (thirdRoom.Size.Height * thirdRoom.cellSize) / 2 - 19, door2Sprite, 3);
            doors.Add(door11);

            door12 = new Door(sixthRoom.Size.Width * sixthRoom.cellSize + tenthRoom.Position.X - 19, tenthRoom.Position.Y + (sixthRoom.Size.Height * sixthRoom.cellSize) / 2 - 10, door2Sprite, 3);
            doors.Add(door12);

            door13 = new Door(eleventhRoom.Position.X + thirdRoom.Size.Width * thirdRoom.cellSize - 19, eleventhRoom.Position.Y + (thirdRoom.Size.Height * thirdRoom.cellSize) / 2 - 19, door2Sprite, 3);
            doors.Add(door13);

            door14 = new Door(sixthRoom.Size.Width * sixthRoom.cellSize + twelfthRoom.Position.X - 19, twelfthRoom.Position.Y + (sixthRoom.Size.Height * sixthRoom.cellSize) / 2 - 10, door2Sprite, 3);
            doors.Add(door14);

            door15 = new Door(fourteenthRoom.Position.X + (eighthRoom.Size.Width * eighthRoom.cellSize) / 2 - 29, fourteenthRoom.Position.Y, doorSprite, 1);
            doors.Add(door15);

            door16 = new Door(fifteenthRoom.Position.X + (thirdRoom.Size.Width * thirdRoom.cellSize) / 2 - 19, fifteenthRoom.Position.Y, doorSprite, 1);
            doors.Add(door16);

            door17 = new Door(sixteenthRoom.Position.X + (sixteenthRoom.Size.Width * sixteenthRoom.cellSize) / 2 - 29, sixteenthRoom.Position.Y - 29, doorSprite, 1);
            doors.Add(door17);

            door18 = new Door(seventeenthRoom.Position.X + (thirdRoom.Size.Width * thirdRoom.cellSize) / 2 - 19, seventeenthRoom.Position.Y - 29, doorSprite, 1);
            doors.Add(door18);

            door19 = new Door(seventeenthRoom.Position.X + thirdRoom.Size.Width * thirdRoom.cellSize - 19, seventeenthRoom.Position.Y + (thirdRoom.Size.Height * thirdRoom.cellSize) / 2 - 19, door2Sprite, 3);
            doors.Add(door19);

            door20 = new Door(sixthRoom.Size.Width * sixthRoom.cellSize + eighteenthRoom.Position.X - 19, eighteenthRoom.Position.Y + (sixthRoom.Size.Height * sixthRoom.cellSize) / 2 - 10, door2Sprite, 3);
            doors.Add(door20);

            door21 = new Door(thirteenthRoom.Position.X + (thirdRoom.Size.Width * thirdRoom.cellSize) / 2 - 19, thirteenthRoom.Position.Y, doorSprite, 1);
            doors.Add(door21);

            door22 = new Door(twentithRoom.Position.X + (eighthRoom.Size.Width * eighthRoom.cellSize) / 2 - 29, twentithRoom.Position.Y, doorSprite, 1);
            doors.Add(door22);

            door23 = new Door(twentyfirstRoom.Position.X + thirdRoom.Size.Width * thirdRoom.cellSize - 19, twentyfirstRoom.Position.Y + (thirdRoom.Size.Height * thirdRoom.cellSize) / 2 - 19, door2Sprite, 3);
            doors.Add(door23);

            door24 = new Door(sixthRoom.Size.Width * sixthRoom.cellSize + twentysecondRoom.Position.X - 19, twentysecondRoom.Position.Y + (sixthRoom.Size.Height * sixthRoom.cellSize) / 2 - 10, door2Sprite, 3);
            doors.Add(door24);
            leveldoor = new Door(twentythirdRoom.Position.X + (twentythirdRoom.Size.Width * twentythirdRoom.cellSize) / 2 - 29, twentythirdRoom.Position.Y, LevelDoor, 4);
            doors.Add(leveldoor);
            

            bot1 = new Bot(300, -600, 64, 64, botIdle, botHP, Hero.idleFrames, Hero.runFrames + 2, Hero.attackFrames, Hero.deathFrames - 6, 2, thirdRoom);
            bots.Add(bot1);
            bot2 = new Bot(-850, -650, 64, 64, botIdle, botHP, Hero.idleFrames, Hero.runFrames + 2, Hero.attackFrames, Hero.deathFrames - 6, 2, seventhRoom);
            bots.Add(bot2);
            bot3 = new Bot(-650, -650, 64, 64, botIdle, botHP, Hero.idleFrames, Hero.runFrames + 2, Hero.attackFrames, Hero.deathFrames - 6, 2, seventhRoom);
            bots.Add(bot3);
            bot4 = new Bot(-750, -550, 64, 64, botIdle, botHP, Hero.idleFrames, Hero.runFrames + 2, Hero.attackFrames, Hero.deathFrames - 6, 2, seventhRoom);
            bots.Add(bot4);
            bot5 = new Bot(-850, -1350, 64, 64, botIdle, botHP, Hero.idleFrames, Hero.runFrames + 2, Hero.attackFrames, Hero.deathFrames - 6, 2, ninethRoom);
            bots.Add(bot5);
            bot6 = new Bot(-650, -1350, 64, 64, botIdle, botHP, Hero.idleFrames, Hero.runFrames + 2, Hero.attackFrames, Hero.deathFrames - 6, 2, ninethRoom);
            bots.Add(bot6);
            bot7 = new Bot(eleventhRoom.Position.X + 200, eleventhRoom.Position.Y + 200, 64, 64, botIdle, botHP, Hero.idleFrames, Hero.runFrames + 2, Hero.attackFrames, Hero.deathFrames - 6, 2, eleventhRoom);
            bots.Add(bot7);
            bot8 = new Bot(eleventhRoom.Position.X + 400, eleventhRoom.Position.Y + 100, 64, 64, botIdle, botHP, Hero.idleFrames, Hero.runFrames + 2, Hero.attackFrames, Hero.deathFrames - 6, 2, eleventhRoom);
            bots.Add(bot8);
            bot9 = new Bot(thirteenthRoom.Position.X + 100, thirteenthRoom.Position.Y + 100, 64, 64, botIdle, botHP, Hero.idleFrames, Hero.runFrames + 2, Hero.attackFrames, Hero.deathFrames - 6, 2, thirteenthRoom);
            bots.Add(bot9);
            bot10 = new Bot(thirteenthRoom.Position.X + 100, thirteenthRoom.Position.Y + 200, 64, 64, botIdle, botHP, Hero.idleFrames, Hero.runFrames + 2, Hero.attackFrames, Hero.deathFrames - 6, 2, thirteenthRoom);
            bots.Add(bot10);
            bot11 = new Bot(thirteenthRoom.Position.X + 300, thirteenthRoom.Position.Y + 150, 64, 64, botIdle, botHP, Hero.idleFrames, Hero.runFrames + 2, Hero.attackFrames, Hero.deathFrames - 6, 2, thirteenthRoom);
            bots.Add(bot11);
            bot12 = new Bot(fifteenthRoom.Position.X + 300, fifteenthRoom.Position.Y + 100, 64, 64, botIdle, botHP, Hero.idleFrames, Hero.runFrames + 2, Hero.attackFrames, Hero.deathFrames - 6, 2, fifteenthRoom);
            bots.Add(bot12);
            bot13 = new Bot(fifteenthRoom.Position.X + 150, fifteenthRoom.Position.Y + 200, 64, 64, botIdle, botHP, Hero.idleFrames, Hero.runFrames + 2, Hero.attackFrames, Hero.deathFrames - 6, 2, fifteenthRoom);
            bots.Add(bot13);
            bot14 = new Bot(seventeenthRoom.Position.X + 350, seventeenthRoom.Position.Y + 100, 64, 64, botIdle, botHP, Hero.idleFrames, Hero.runFrames + 2, Hero.attackFrames, Hero.deathFrames - 6, 2, seventeenthRoom);
            bots.Add(bot14);
            bot15 = new Bot(seventeenthRoom.Position.X + 100, seventeenthRoom.Position.Y + 250, 64, 64, botIdle, botHP, Hero.idleFrames, Hero.runFrames + 2, Hero.attackFrames, Hero.deathFrames - 6, 2, seventeenthRoom);
            bots.Add(bot15);
            bot16 = new Bot(seventeenthRoom.Position.X + 350, seventeenthRoom.Position.Y + 250, 64, 64, botIdle, botHP, Hero.idleFrames, Hero.runFrames + 2, Hero.attackFrames, Hero.deathFrames - 6, 2, seventeenthRoom);
            bots.Add(bot16);
            bot17 = new Bot(twentyfirstRoom.Position.X + 250, twentyfirstRoom.Position.Y + 200, 64, 64, botIdle, botHP, Hero.idleFrames, Hero.runFrames + 2, Hero.attackFrames, Hero.deathFrames - 6, 2, twentyfirstRoom);
            bots.Add(bot17);
            bot18 = new Bot(twentythirdRoom.Position.X + 100, twentythirdRoom.Position.Y + 100, 64, 64, botIdle, botHP, Hero.idleFrames, Hero.runFrames + 2, Hero.attackFrames, Hero.deathFrames - 6, 2, twentythirdRoom);
            bots.Add(bot18);
            bot19 = new Bot(twentythirdRoom.Position.X + 200, twentythirdRoom.Position.Y + 100, 64, 64, botIdle, botHP, Hero.idleFrames, Hero.runFrames + 2, Hero.attackFrames, Hero.deathFrames - 6, 2, twentythirdRoom);
            bots.Add(bot19);
            bot20 = new Bot(twentythirdRoom.Position.X + 300, twentythirdRoom.Position.Y + 100, 64, 64, botIdle, botHP, Hero.idleFrames, Hero.runFrames + 2, Hero.attackFrames, Hero.deathFrames - 6, 2, twentythirdRoom);
            bots.Add(bot20);
            bot21 = new Bot(twentythirdRoom.Position.X + 200, twentythirdRoom.Position.Y + 200, 64, 64, botIdle, botHP, Hero.idleFrames, Hero.runFrames + 2, Hero.attackFrames, Hero.deathFrames - 6, 2, twentythirdRoom);
            bots.Add(bot21);
            bot22 = new Bot(twentythirdRoom.Position.X + 400, twentythirdRoom.Position.Y + 200, 64, 64, botIdle, botHP, Hero.idleFrames, Hero.runFrames + 2, Hero.attackFrames, Hero.deathFrames - 6, 2, twentythirdRoom);
            bots.Add(bot22);
            boss = new Bot(twentythirdRoom.Position.X + 200, twentythirdRoom.Position.Y + 100, 256, 256, bossIdle, bossHP, Hero.idleFrames, Hero.runFrames + 2, Hero.attackFrames, Hero.deathFrames - 6, 2, twentythirdRoom);
            if (Level == 2)
            {
                boss.HealthPoint = 800;
                foreach (var bot in bots)
                {
                    bot.HealthPoint = 200;
                    bot.damage *= 2;
                }
            }
            else if (Level == 3)
            {
                boss.HealthPoint = 1000;
                foreach (var bot in bots)
                {
                    bot.HealthPoint = 300;
                    bot.damage *= 3;
                }
            }
            hp1 = new HPBaff(bot1.PosX, bot1.PosY, 32, 32, HPBaff);
            hPBaffs.Add(hp1);
            hp2 = new HPBaff(bot3.PosX, bot3.PosY, 32, 32, HPBaff);
            hPBaffs.Add(hp2);
            hp3 = new HPBaff(bot4.PosX, bot4.PosY, 32, 32, HPBaff);
            hPBaffs.Add(hp3);
            hp4 = new HPBaff(bot5.PosX, bot6.PosY, 32, 32, HPBaff);
            hPBaffs.Add(hp4);
            hp5 = new HPBaff(bot8.PosX, bot8.PosY, 32, 32, HPBaff);
            hPBaffs.Add(hp5);
            hp6 = new HPBaff(bot10.PosX, bot10.PosY, 32, 32, HPBaff);
            hPBaffs.Add(hp6);
            hp7 = new HPBaff(bot13.PosX, bot13.PosY, 32, 32, HPBaff);
            hPBaffs.Add(hp7);
            hp8 = new HPBaff (bot17.PosX, bot17.PosY, 32, 32, HPBaff);
            hPBaffs.Add(hp8);
            hp9 = new HPBaff(bot18.PosX, bot18.PosY, 32, 32, HPBaff);
            hPBaffs.Add(hp9);
            hp10 = new HPBaff(bot19.PosX, bot19.PosY, 32, 32, HPBaff);
            hPBaffs.Add(hp10);
            hp11 = new HPBaff(bot20.PosX, bot20.PosY, 32, 32, HPBaff);
            hPBaffs.Add(hp11);
            fontain = new HPBaff(nineteenthRoom.Position.X + 201, nineteenthRoom.Position.Y + 110, 168, 150, Fontain);
            hPBaffs.Add(fontain);

            
            cat1 = new Cat(secondRoom.Position.X + (secondRoom.Size.Width * secondRoom.cellSize) / 2 - 64, secondRoom.Position.Y + (secondRoom.Size.Width * secondRoom.cellSize) / 2 + 40, CatSprite, keySprite);
            cats.Add(cat1);
            cat2 = new Cat(ninethRoom.Position.X + ninethRoom.Size.Width * ninethRoom.cellSize - 120, ninethRoom.Position.Y + ninethRoom.Size.Height * ninethRoom.cellSize - 60, CatSprite, keySprite);
            cats.Add(cat2);
            cat3 = new Cat(fifteenthRoom.Position.X + 38, fifteenthRoom.Position.Y + 38, CatSprite, keySprite);
            cats.Add(cat3);

            sausage1 = new Sausage(secondRoom.Position.X + (secondRoom.Size.Width * secondRoom.cellSize) / 2 - 10, secondRoom.Position.Y + (secondRoom.Size.Width * secondRoom.cellSize) / 2 + 200, sausageSprite, boxSprite, false);
            sausages.Add(sausage1);
            sausage2 = new Sausage(eighthRoom.Position.X + 100, eighthRoom.Position.Y + 200, sausageSprite, boxSprite, true);
            sausages.Add(sausage2);
            sausage3 = new Sausage(seventeenthRoom.Position.X + 100, seventeenthRoom.Position.Y + 100, sausageSprite,boxSprite, true);
            sausages.Add(sausage3);

            db1 = new DamageBaff(firthRoom.Position.X + 190, firthRoom.Position.Y + 50, DBaff, boxSprite, true);
            damageBaffs.Add(db1);
            db2 = new DamageBaff(eleventhRoom.Position.X + eleventhRoom.Size.Width * eleventhRoom.cellSize - 100, eleventhRoom.Position.Y + 100, DBaff, boxSprite, true);
            damageBaffs.Add(db2);
            db3 = new DamageBaff(fourteenthRoom.Position.X + 100, fourteenthRoom.Position.Y + 190, DBaff, boxSprite, true);
            damageBaffs.Add(db3);
            db4 = new DamageBaff(twentyfirstRoom.Position.X + 100, twentyfirstRoom.Position.Y + 100, DBaff, boxSprite, true);
            damageBaffs.Add(db4);
           
            studentTimer.Interval = 1500;
            studentTimer.Tick += updateStudent;
            studentTimer.Start();

            objectAnimationTimer = new Timer();
            objectAnimationTimer.Interval = 300;
            objectAnimationTimer.Tick += objectUpdate;
            objectAnimationTimer.Start();
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            if(Level == 3 && leveldoor.wasOpened)
            {
                e.Graphics.Clear(Color.Black);
                e.Graphics.DrawImage(End, new Rectangle(new Point(20, 100), new Size(1054, 634)), 0, 0, 1054, 634, GraphicsUnit.Pixel);
                
                button1.Visible = true;
                button2.Visible = true;
                button3.Visible = true;
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
            }
            else
            {
                if (student.IsAlive)
                {
                    e.Graphics.ScaleTransform(camera.Scale, camera.Scale);
                    e.Graphics.Clear(Color.Black);

                    mapGraph.DrawGraph(e.Graphics, camera);
                    student.PlayAnimation(e.Graphics, camera, student);
                    if (Level == 1)
                        complection.Draw(e.Graphics, student, camera);
                    else if (Level == 2 || Level ==3)
                        fontain1.Draw(e.Graphics, camera, student);
                    door1.Draw(e.Graphics, camera, student);
                    if (door1.wasOpened)
                    {
                        door2.Draw(e.Graphics, camera, student);
                        cat1.draw(e.Graphics, camera, student);
                        sausage1.Draw(e.Graphics, camera, student);
                    }
                    if (door2.wasOpened)
                    {
                        door3.Draw(e.Graphics, camera, student);
                        door4.Draw(e.Graphics, camera, student);
                        door5.Draw(e.Graphics, camera, student);
                        if (bot1.Kostyl < 10)
                            bot1.PlayAnimation(e.Graphics, camera, student);
                        else
                            bots.Remove(bot1);
                        hp1.Draw(e.Graphics, camera, student);
                    }
                    if (door4.wasOpened || door9.wasOpened)
                        door6.Draw(e.Graphics, camera, student);
                    if (door3.wasOpened || door12.wasOpened || door13.wasOpened)
                        door7.Draw(e.Graphics, camera, student);
                    if (door5.wasOpened || door16.wasOpened)
                        door8.Draw(e.Graphics, camera, student);
                    if (door6.wasOpened || door10.wasOpened)
                        door9.Draw(e.Graphics, camera, student);
                    if (door9.wasOpened || door11.wasOpened)
                        door10.Draw(e.Graphics, camera, student);
                    if (door10.wasOpened || door12.wasOpened)
                        door11.Draw(e.Graphics, camera, student);
                    if (door7.wasOpened || door11.wasOpened || door13.wasOpened)
                        door12.Draw(e.Graphics, camera, student);
                    if (door7.wasOpened || door12.wasOpened || door14.wasOpened)
                        door13.Draw(e.Graphics, camera, student);
                    if (door15.wasOpened || door13.wasOpened)
                        door14.Draw(e.Graphics, camera, student);
                    if (door14.wasOpened || door16.wasOpened)
                        door15.Draw(e.Graphics, camera, student);
                    if (door8.wasOpened || door15.wasOpened)
                        door16.Draw(e.Graphics, camera, student);
                    if (door8.wasOpened || door16.wasOpened)
                        door17.Draw(e.Graphics, camera, student);
                    if (door17.wasOpened)
                        door18.Draw(e.Graphics, camera, student);
                    if (door18.wasOpened)
                        door19.Draw(e.Graphics, camera, student);
                    if (door19.wasOpened)
                        door20.Draw(e.Graphics, camera, student);
                    if (door14.wasOpened || door15.wasOpened)
                        door21.Draw(e.Graphics, camera, student);
                    if (door21.wasOpened)
                        door22.Draw(e.Graphics, camera, student);
                    if (door22.wasOpened)
                        door23.Draw(e.Graphics, camera, student);
                    if (door23.wasOpened)
                        door24.Draw(e.Graphics, camera, student);
                    if (door4.wasOpened || door6.wasOpened)
                        db1.Draw(e.Graphics, camera, student);
                    if (door9.wasOpened || door10.wasOpened)
                        sausage2.Draw(e.Graphics, camera, student);
                    if (door6.wasOpened || door9.wasOpened)
                    {
                        if (bot2.Kostyl < 10)
                            bot2.PlayAnimation(e.Graphics, camera, student);
                        else
                            bots.Remove(bot2);
                        if (bot3.Kostyl < 10)
                            bot3.PlayAnimation(e.Graphics, camera, student);
                        else
                            bots.Remove(bot3);
                        if (bot4.Kostyl < 10)
                            bot4.PlayAnimation(e.Graphics, camera, student);
                        else
                            bots.Remove(bot4);
                        hp2.Draw(e.Graphics, camera, student);
                        hp3.Draw(e.Graphics, camera, student);
                    }
                    if (door10.wasOpened || door11.wasOpened)
                    {
                        if (bot5.Kostyl < 10)
                            bot5.PlayAnimation(e.Graphics, camera, student);
                        else
                            bots.Remove(bot5);
                        if (bot6.Kostyl < 10)
                            bot6.PlayAnimation(e.Graphics, camera, student);
                        else
                            bots.Remove(bot6);
                        if (!bot5.IsAlive && !bot6.IsAlive)
                            cat2.draw(e.Graphics, camera, student);
                        hp4.Draw(e.Graphics, camera, student);
                    }
                    if (door13.wasOpened || door12.wasOpened || door7.wasOpened)
                    {
                        if (bot7.Kostyl < 10)
                            bot7.PlayAnimation(e.Graphics, camera, student);
                        else
                            bots.Remove(bot7);
                        if (bot8.Kostyl < 10)
                            bot8.PlayAnimation(e.Graphics, camera, student);
                        else
                            bots.Remove(bot8);
                        if (!bot7.IsAlive && !bot8.IsAlive)
                            db2.Draw(e.Graphics, camera, student);
                        hp5.Draw(e.Graphics, camera, student);
                    }
                    if (door14.wasOpened || door15.wasOpened)
                    {
                        if (bot9.Kostyl < 10)
                            bot9.PlayAnimation(e.Graphics, camera, student);
                        else
                            bots.Remove(bot9);
                        if (bot10.Kostyl < 10)
                            bot10.PlayAnimation(e.Graphics, camera, student);
                        else
                            bots.Remove(bot10);
                        if (bot11.Kostyl < 10)
                            bot11.PlayAnimation(e.Graphics, camera, student);
                        else
                            bots.Remove(bot11);
                        hp6.Draw(e.Graphics, camera, student);
                    }
                    if (door15.wasOpened || door16.wasOpened)
                    {
                        db3.Draw(e.Graphics, camera, student);
                    }
                    if (door16.wasOpened || door8.wasOpened)
                    {
                        if (bot12.Kostyl < 10)
                            bot12.PlayAnimation(e.Graphics, camera, student);
                        else
                            bots.Remove(bot12);
                        if (bot13.Kostyl < 10)
                            bot13.PlayAnimation(e.Graphics, camera, student);
                        else
                            bots.Remove(bot13);
                        if (!bot12.IsAlive && !bot13.IsAlive)
                            cat3.draw(e.Graphics, camera, student);
                        hp7.Draw(e.Graphics, camera, student);

                    }
                    if (door18.wasOpened)
                    {
                        if (bot15.Kostyl < 10)
                            bot15.PlayAnimation(e.Graphics, camera, student);
                        else
                            bots.Remove(bot15);
                        if (bot14.Kostyl < 10)
                            bot14.PlayAnimation(e.Graphics, camera, student);
                        else
                            bots.Remove(bot14);
                        if (bot16.Kostyl < 10)
                            bot16.PlayAnimation(e.Graphics, camera, student);
                        else
                            bots.Remove(bot16);
                        if (!bot14.IsAlive && !bot15.IsAlive && !bot16.IsAlive)
                            sausage3.Draw(e.Graphics, camera, student);
                        hp7.Draw(e.Graphics, camera, student);

                    }

                    if (door20.wasOpened)
                        fontain.Draw(e.Graphics, camera, student);
                    if (door22.wasOpened)
                    {
                        if (bot17.Kostyl < 10)
                            bot17.PlayAnimation(e.Graphics, camera, student);
                        else
                            bots.Remove(bot17);
                        if (!bot17.IsAlive)
                            db4.Draw(e.Graphics, camera, student);
                        hp8.Draw(e.Graphics, camera, student);
                    }
                    if (door24.wasOpened)
                    {
                        if (bot18.Kostyl < 10)
                            bot18.PlayAnimation(e.Graphics, camera, student);
                        else
                            bots.Remove(bot18);
                        if (bot19.Kostyl < 10)
                            bot19.PlayAnimation(e.Graphics, camera, student);
                        else
                            bots.Remove(bot19);
                        if (bot20.Kostyl < 10)
                            bot20.PlayAnimation(e.Graphics, camera, student);
                        else
                            bots.Remove(bot20);
                        if (bot21.Kostyl < 10)
                            bot21.PlayAnimation(e.Graphics, camera, student);
                        else
                            bots.Remove(bot21);
                        if (bot22.Kostyl < 10)
                            bot22.PlayAnimation(e.Graphics, camera, student);
                        else
                            bots.Remove(bot22);
                        if (!bot18.IsAlive && !bot19.IsAlive && !bot20.IsAlive && !bot21.IsAlive && !bot22.IsAlive)
                        {
                            if (!bots.Contains(boss) && boss.IsAlive)
                            {

                                bots.Add(boss);
                            }

                            else if (boss.Kostyl < 10)
                                boss.PlayAnimation(e.Graphics, camera, student);
                            else
                            {
                                bots.Remove(boss);
                                leveldoor.Draw(e.Graphics, camera, student);
                            }
                        }
                        hp9.Draw(e.Graphics, camera, student);
                        hp10.Draw(e.Graphics, camera, student);
                        hp11.Draw(e.Graphics, camera, student);

                    }
                }
                else
                {
                    e.Graphics.ScaleTransform(camera.Scale, camera.Scale);
                    e.Graphics.Clear(Color.Black);
                    student.PlayAnimation(e.Graphics, camera, student);
                    button1.Visible = true;
                    button2.Visible = true;
                    button3.Visible = true;
                    button1.Enabled = true;
                    button2.Enabled = true;
                    button3.Enabled = true;
                }
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            fm.Panelform(new Form1(fm, 1, null));
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            fm.returnmenu();
        }
    }
}