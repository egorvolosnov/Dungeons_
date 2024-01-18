using Dungeons_.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dungeons_.Models;
using static System.Windows.Forms.AxHost;
using System.Data;

namespace Dungeons_.Cameras
{
    public class Camera
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public float Scale { get; set; } = 1.5f; // Добавляем коэффициент масштабирования

        public Camera(Student student, int formWidth, int formHeight)
        {
            X = (int)(-student.PosX + formWidth / (2.6666666 * Scale));
            Y = (int)(-student.PosY + formHeight / (2.6666666 * Scale));
        }
        public void Update(Student student, int formWidth, int formHeight)
        {
            X = (int)(-student.PosX + formWidth / (2.6666666 * Scale));
            Y = (int)(-student.PosY + formHeight / (2.6666666 * Scale));
        }
    }

}
