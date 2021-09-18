using FireEngine.FireEngine.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireEngine.FireEngine
{
    public class Shape
    {
        public Vector2 Pos = null;
        public Vector2 Scale = null;
        public string Tag = "";

        public Shape(Vector2 pos, Vector2 scale, string tag)
        {
            this.Pos = pos;
            this.Scale = scale;
            this.Tag = tag;
            Log.LogInfo(Tag + " Has been added.");
            Engine.AddShape(this);
        }

        public void Destroy()
        {
            Log.LogInfo(Tag + " Has been added.");
            Engine.RemoveShape(this);
        }
    }
}
