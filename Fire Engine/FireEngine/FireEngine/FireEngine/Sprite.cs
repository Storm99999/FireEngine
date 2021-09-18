using FireEngine.FireEngine.Logs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireEngine.FireEngine
{
    public class Sprite
    {
        public Vector2 Pos = null;
        public Vector2 Scale = null;
        public string Directory = "";
        public string Tag = "";
        private string assetsDir = "Assets/";
        // Character Image
        public Bitmap SpriteCharacter = null;
        public Sprite(Vector2 pos, Vector2 scale, string dir, string tag)
        {
            this.Pos = pos;
            this.Scale = scale;
            this.Directory = dir;
            this.Tag = tag;
            Image tmp = Image.FromFile($"{assetsDir}Sprites/{Directory}.png");
            Bitmap spriteT = new Bitmap(tmp);
            SpriteCharacter = spriteT;
            Log.LogInfo(Tag + " Has been added.");
            Engine.AddSprite(this);
        }
        /// <summary>
        /// Simple Colliding Bool, Returns True Or False.
        /// </summary>
        public bool IsColliding(Sprite a, Sprite b)
        {
            if (a.Pos.X < b.Pos.X + b.Scale.X && a.Pos.X + a.Scale.X > b.Pos.X && a.Pos.Y < b.Pos.Y + b.Scale.Y && a.Pos.Y + a.Scale.Y > b.Pos.Y)
            {
                return true;
            }
            return false;
        }

        public void Destroy()
        {
            Engine.RemoveSprites(this);
        }

    }
}
