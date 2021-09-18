using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;
using System.Threading;
using FireEngine.FireEngine.Logs;
using System.Diagnostics;

namespace FireEngine.FireEngine
{
    class EngineForm : Form
    {
        public EngineForm()
        {
            DoubleBuffered = true;
        }
    }
    public abstract class Engine
    {
        // Screen Size Of The Screen
        private Vector2 Screensize = new Vector2(512,512);
        private string WindowName = "My New Fire Engine Game";
        // For Now We Set This To Null.
        private EngineForm Window = null;
        // Re-draw Everything (Force Program To Redraw Our Graphics!)
        private Thread Loop = null;
        /// <summary>
        /// Current Background Color Of The Form/Game.
        /// </summary>
        public Color BackgroundColor = Color.Black;

        public static List<Shape> allShapes = new List<Shape>();
        public static List<Sprite> allSprites = new List<Sprite>();
        public Vector2 CameraPos = Vector2.Zero();
        public Engine(Vector2 screenSize, string windowName)
        {
            Log.LogInfo("Loading Assets...");
            this.Screensize = screenSize;
            WindowName = windowName;
            Window = new EngineForm();
            // Here It's Trying To Convert That Into Floats, So We Make A (int) So It Know's We Aren't Trying To Do That.
            Window.Size = new Size((int)Screensize.X, (int)Screensize.Y);
            Window.Text = WindowName;
            Window.Paint += Render;
            Window.KeyDown += Window_KeyDown;
            Window.KeyUp += Window_KeyUp;
            Loop = new Thread(GameLoop);
            Loop.Start();

            Application.Run(Window);
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            GetKeyUp(e);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            GetKeyDown(e);
        }

        /// <summary>
        /// Adds a new Shape To the Game.
        /// </summary>
        public static void AddShape(Shape shape)
        {
            allShapes.Add(shape);
        }
        public static void RemoveShape(Shape shape)
        {
            allShapes.Remove(shape);
        }
        public static void AddSprite(Sprite sprite)
        {
            allSprites.Add(sprite);
        }
        public static void RemoveSprites(Sprite sprite)
        {
            allSprites.Remove(sprite);
        }

        private void Render(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.Clear(BackgroundColor);
            graphics.TranslateTransform(CameraPos.X, CameraPos.Y);
            foreach (Shape shape in allShapes)
            {
                graphics.FillRectangle(new SolidBrush(Color.Red),shape.Pos.X, shape.Pos.Y, shape.Scale.X, shape.Scale.Y);
            }
            foreach (Sprite sprite in allSprites)
            {
                graphics.DrawImage(sprite.SpriteCharacter, sprite.Pos.X, sprite.Pos.Y, sprite.Scale.X, sprite.Scale.Y);
            } 
        }
        public void Won()
        {
            Process.Start(Environment.CurrentDirectory + "\\Assets\\Sprites\\Goals\\WonScreen.png");
            Environment.Exit(0);
        }
        void GameLoop()
        {
            OnLoad();
            while (Loop.IsAlive)
            {
                try
                {
                    OnDraw();
                    Window.BeginInvoke((MethodInvoker)
                        delegate { Window.Refresh(); });
                    OnUpdate();
                    Thread.Sleep(1);
                }
                catch 
                {
                    Log.LogError("Window Can't Be Found!");
                }
            }
        }
        public abstract void OnLoad();
        public abstract void OnUpdate();
        public abstract void OnDraw();
        public abstract void GetKeyDown(KeyEventArgs e);
        public abstract void GetKeyUp(KeyEventArgs e);
    }
}
