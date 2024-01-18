using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dungeons_.Cameras;
using Dungeons_.Interface;
namespace Dungeons_.Entities
{
    public interface IEntity 
    {
        int PosX { get; set; }
        int PosY { get; set; }
        int SizeX { get; set; }
        int SizeY { get; set; }
        int Layer { get; set; }
        int DirX { get; set; }
        int DirY { get; set; }
        int HealthPoint { get; set; }
        bool IsMoving { get; set; }
        bool IsAlive { get; set; }
        bool IsHurted {  get; set; }
        Image IdleSprite { get; set; }
        Image Health { get; set; }
        int CurrAnimation { get; set; }
        int CurrFrame { get; set; }
        int CurrLimit { get; set; }
        Image CurrImage { get; set; }

        int IdleFrames { get; set; }
        int RunFrames { get; set; }
        int AttackFrames { get; set; }
        int DeathFrames { get; set; }

        void Move();
        void PlayAnimation(Graphics g, Camera camera, Student student);
        void SetCurrImage(Image img, Image imgHurted, int kostyl);
    }
}
