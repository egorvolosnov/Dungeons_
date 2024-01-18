using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Dungeons_.Cameras;
using Dungeons_.Entities;
using System.Runtime.CompilerServices;

namespace Dungeons_.Interface
{
    public class TextRender:IDisposable
    {
        private Point location;
        private int fontSize;
        private string text;
        private Font font;
        private PrivateFontCollection fontCollection;
        private Color textColor;
        private Image helpSheet;
        public TextRender()
        {
            location.X = 0;
            location.Y = 0;
            fontSize = 14;
            text = string.Empty;
            fontCollection = new PrivateFontCollection();
            LoadFont();
            font = new Font(fontCollection.Families[0], fontSize);
            textColor = Color.Black;
            helpSheet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\help.png"));

        }
        public TextRender(Point location, int fontSize, string text, Color textColor)
        {
            this.location = location;
            this.fontSize = fontSize;
            this.text = text;
            fontCollection = new PrivateFontCollection();
            LoadFont();
            font = new Font(fontCollection.Families[0], fontSize);
            this.textColor = textColor;
        }

        private void LoadFont()
        {
            string fontFilePath = "C:\\D\\voenmeh\\c#\\curs\\Dungeons_\\videotype.ttf";
            fontCollection.AddFontFile(fontFilePath);
        }
        public void Dispose()
        {
            // Освобождаем ресурсы Font
            font?.Dispose();

            // Освобождаем ресурсы PrivateFontCollection
            fontCollection?.Dispose();

            // Освобождаем ресурсы Image
            helpSheet?.Dispose();
        }
        public void HelpText(string text, Graphics g, Camera camera)
        {
            this.text = text;
            location.X = 1140;
            location.Y = 150;
           

            g.DrawImage(helpSheet, new Rectangle(new Point((int)(1050*1/camera.Scale), 0), new Size((int)(373.5/camera.Scale), (int)(339/camera.Scale))), 0, 0, 249, 226, GraphicsUnit.Pixel);
            TextRenderer.DrawText(g, text, font, location, this.textColor);
        }
        public void DrawText(Graphics g)
        {
            TextRenderer.DrawText(g, this.text, this.font, this.location, this.textColor);
        }
    }

}
