using FireEngine.FireEngine;
using FireEngine.FireEngine.Logs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FireEngine.GameForm
{
    /// <summary>
    /// A New Fire Engine Game
    /// </summary>
    public class Game : Engine
    {

        bool UpJump;
        bool Left;
        bool Right;
        bool Down;
        Sprite playerShape = null;
        Sprite playerShape1 = null;
        Sprite Goal = null;
        // The G's Are The Stone Blocks The Other Things Are Null.
        string[,] Map =
            {
            { "g", ".", ".", ".", ".",".", ".", },
            { "g", ".", ".", ".", ".", ".", ".", },
            { "g", ".", ".", ".", ".", ".",".", },
            { "g", ".", ".", ".", ".", ".",".", },
            { "g", "g", "g", "g", "g", "g",".", },
            { ".", ".", ".", ".", ".", ".",".", }
            };
        /// <summary>
        /// Run's the Game.
        /// </summary>
        public Game() : base(new Vector2(615,515),"Fire Engine")
        {

        }

        public override void GetKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W) { UpJump = true; }
            if (e.KeyCode == Keys.A) { Left = true; }
            if (e.KeyCode == Keys.D) { Right = true; }
            if (e.KeyCode == Keys.S) { Down = true; }
        }

        public override void GetKeyUp(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W) { UpJump = false; }
            if (e.KeyCode == Keys.A) { Left = false; }
            if (e.KeyCode == Keys.D) { Right = false; }
            if (e.KeyCode == Keys.S) { Down = false; }
        }

        public override void OnDraw()
        {
            
        }
        // When The Window Loads
        public override void OnLoad()
        {
            Console.WriteLine((string)$@"
  ______ _              ______             _            
 |  ____(_)            |  ____|           (_)           
 | |__   _ _ __ ___    | |__   _ __   __ _ _ _ __   ___ 
 |  __| | | '__/ _ \   |  __| | '_ \ / _` | | '_ \ / _ \
 | |    | | | |  __/   | |____| | | | (_| | | | | |  __/
 |_|    |_|_|  \___|   |______|_| |_|\__, |_|_| |_|\___|
                                      __/ |             
                                     |___/              ");
            // Current Background Color Of The Game
            BackgroundColor = Color.Black;
            // New Player
            playerShape = new Sprite(new Vector2(10,10), new Vector2(30,40), "\\Character\\Skull", "playerCharacter");
            playerShape1 = new Sprite(new Vector2(50, 10), new Vector2(30, 40), "\\Character\\Skull", "playerCharacter1");
            Goal = new Sprite(new Vector2(200, 60), new Vector2(50, 50), "\\Goals\\Goal", "goal");
            for (int i = 0; i < Map.GetLength(1); i++)
            {
                for (int j = 0; j < Map.GetLength(0); j++)
                {
                    if (Map[j, i] == "g")
                    {
                        // Stone Map
                        new Sprite(new Vector2(i * 50, j * 50), new Vector2(50, 50), "Buildings/Stone", "Stone");
                    }
                }
            }
        }
        public override void OnUpdate()
        {
            if (UpJump) { playerShape.Pos.Y -= 1f;  }
            if (Left) { playerShape.Pos.X -= 1f; }
            if (Right) { playerShape.Pos.X += 1f; }
            if (Down) { playerShape.Pos.Y += 1f; }

            if (playerShape.IsColliding(playerShape, playerShape1))
            {
                Log.LogInfo("Colliding!");
            }
            if (playerShape.IsColliding(playerShape, Goal))
            {
                Won();
            }
        }
    }
}
