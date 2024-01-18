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

namespace Dungeons_
{
    
    public partial class Form2 : Form
    {
        private Image ButtonHover;
        private Image Rules;
        public Form2()
        {
            ButtonHover = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\buttonhover.png"));
            Rules = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\rules.png"));
            InitializeComponent();
            ApplyHoverStyles(rulesgame, ButtonHover, Color.White, true);
            ApplyHoverStyles(startgame, ButtonHover, Color.White, true);
            ApplyHoverStyles(exit, ButtonHover, Color.White, true);
        }

        private Form active;
        public void Panelform(Form fm)
        {
            if (active != null && !active.IsDisposed)
            {
                active.Close();
                active.Dispose();
            }

            active = fm;
            fm.TopLevel = false;
            fm.FormBorderStyle = FormBorderStyle.None;
            fm.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(fm);
            this.panel1.Tag = fm;
            fm.BringToFront();
            fm.Show();
            
        }
        public void returnmenu()
        {
            this.Show();
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
        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void rulesgame_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Rules;
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void startgame_Click(object sender, EventArgs e)
        {
            
            Panelform(new Form1(this, 1, null));
        }
    }
}
