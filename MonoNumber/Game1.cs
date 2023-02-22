using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Runtime.CompilerServices;

namespace MonoNumber
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        string numberinput = ""; // inputed number

        bool minaccept = false; // is minval confirmed
        bool maxaccept = false; // is maxval confirmed

        int min;  // minvalue
        int max;  // maxvalue

        int[] res = { 480, 720, 1080, 1440, 2160 }; //resolutions

        int curres = 0; // current resolution

        bool pressed = false; // is key pressed

        bool[] rnds = new bool[1000]; // states of numbers

        int rand = 0; // current generated number
        int currand = -1; // current generated number for UI

        public SpriteFont arial; // font
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = res[curres];
            _graphics.PreferredBackBufferHeight = (int)(res[curres] * 0.5625);
            _graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
           base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            arial = Content.Load<SpriteFont>("arial");
           
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))  // exit on escape or controller back
                Exit();


            if (pressed == false) 
            {
                if (numberinput.Length < 3)
                {
                    if (Keyboard.GetState().IsKeyDown(Keys.D0) || Keyboard.GetState().IsKeyDown(Keys.NumPad0))
                    {
                        numberinput += "0";
                        pressed = true;
                        Console.WriteLine("PRESS");
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.D1) || Keyboard.GetState().IsKeyDown(Keys.NumPad1))
                    {                                                                                                      // checking numbers and adding to numberinput
                        numberinput += "1";
                        pressed = true;
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.D2) || Keyboard.GetState().IsKeyDown(Keys.NumPad2))
                    {
                        numberinput += "2";
                        pressed = true;
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.D3) || Keyboard.GetState().IsKeyDown(Keys.NumPad3))
                    {
                        numberinput += "3";
                        pressed = true;
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.D4) || Keyboard.GetState().IsKeyDown(Keys.NumPad4))
                    {
                        numberinput += "4";
                        pressed = true;
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.D5) || Keyboard.GetState().IsKeyDown(Keys.NumPad5))
                    {
                        numberinput += "5";
                        pressed = true;
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.D6) || Keyboard.GetState().IsKeyDown(Keys.NumPad6))
                    {
                        numberinput += "6";
                        pressed = true;
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.D7) || Keyboard.GetState().IsKeyDown(Keys.NumPad7))
                    {
                        numberinput += "7";
                        pressed = true;
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.D8) || Keyboard.GetState().IsKeyDown(Keys.NumPad8))
                    {
                        numberinput += "8";
                        pressed = true;
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.D9) || Keyboard.GetState().IsKeyDown(Keys.NumPad9))
                    {
                        numberinput += "9";
                        pressed = true;
                    }
                    

                }
                if (Keyboard.GetState().IsKeyDown(Keys.Enter))     // confirm number on enter
                {
                    if (!minaccept)
                    {
                        if (numberinput != "")
                        {
                            min = int.Parse(numberinput);
                            minaccept = true;
                            numberinput = "";
                        }
                        else if (numberinput == "") 
                        {
                            min = 0;
                            minaccept = true;
                            numberinput = "";
                        }
                        
                    }
                    else if (minaccept && !maxaccept)
                    {
                        if (numberinput != "")
                        {
                            max = int.Parse(numberinput);
                            maxaccept = true;
                        }
                    }
                   
                    pressed = true;

                }
                if (Keyboard.GetState().IsKeyDown(Keys.Space)) // randomize number on space
                {
                    bool search = false;
                    for (int i = min; i < max + 1; i++)
                    {
                        if (rnds[i] == false)
                        {
                            search = true;
                        }

                    }
                    if (search)
                    {
                        while (true)
                        {
                            Random rnd = new Random();
                            rand = rnd.Next(min, max + 1);
                            if (rnds[rand] == false)
                            {
                                currand = rand;
                                rnds[rand] = true;
                                break;
                            }
                            else
                            {

                            }
                        }
                    }
                    else
                    {
                        currand = -1;
                    }
                    pressed = true;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.F4))  // reset program on F4
                {
                    rnds.Initialize();
                    currand = 0;
                    numberinput = "";

                    minaccept = false;
                    maxaccept = false;

                    min = 0;
                    max = 0;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.Back))  // backspace
                {
                    if (numberinput.Length > 1) 
                    {
                        numberinput = numberinput.Remove(numberinput.Length - 1);
                        if (!minaccept)
                        {
                            min = int.Parse(numberinput);

                        }
                        else if (!maxaccept)
                        {
                            max = int.Parse(numberinput);

                        }

                    }
                    else if (numberinput.Length > 0)
                    {
                        numberinput = "";
                        if (!minaccept)
                        {
                            min = 0;

                        }
                        else if (!maxaccept)
                        {
                            max = 0;

                        }
                    }
                    pressed = true;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.F1)) // change resolution on F1
                {
                    if (curres < res.Length - 1) { curres++; _graphics.PreferredBackBufferWidth = res[curres]; _graphics.PreferredBackBufferHeight = (int)(res[curres] * 0.5625); _graphics.ApplyChanges(); }
                    else { curres = 0; _graphics.PreferredBackBufferWidth = res[curres]; _graphics.PreferredBackBufferHeight = (int)(res[curres] * 0.5625); _graphics.ApplyChanges(); }
                    pressed = true;
                }
                
            }
            if(Keyboard.GetState().GetPressedKeyCount() == 0) { pressed = false; } // check if any key is pressed, if not pressed = false

            if (numberinput != "")
            {
                if (!minaccept)
                {
                    min = int.Parse(numberinput);

                }
                else if (!maxaccept)
                {
                    max = int.Parse(numberinput);

                }
            }
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();
            _spriteBatch.DrawString(arial, "Welcome to MonoNumber - Random Number Generator", new Vector2(10, 2), Color.Green, 0f, Vector2.One, (curres + 1) * 0.8f, SpriteEffects.None, 0f);
            _spriteBatch.DrawString(arial, "Enter - confirm number, space - generate new number", new Vector2(10, _graphics.PreferredBackBufferHeight / 9), Color.Green, 0f, Vector2.One, (curres + 1) * 0.8f, SpriteEffects.None, 0f);
            _spriteBatch.DrawString(arial, "F4 - reset values, F1 - change resolution, ESC - exit", new Vector2(10, _graphics.PreferredBackBufferHeight / 6), Color.Green, 0f, Vector2.One, (curres + 1) * 0.8f, SpriteEffects.None, 0f);
            _spriteBatch.DrawString(arial, "lowest random value:", new Vector2(10, _graphics.PreferredBackBufferHeight / 3), Color.Green, 0f, Vector2.One, (curres + 1), SpriteEffects.None, 0f);
            if (!minaccept)
            {
                _spriteBatch.DrawString(arial, "                                " + min, new Vector2(10, _graphics.PreferredBackBufferHeight / 3), Color.Blue, 0f, Vector2.One, (curres + 1), SpriteEffects.None, 0f);
            }
            else
            {
                _spriteBatch.DrawString(arial, "                                " + min, new Vector2(10, _graphics.PreferredBackBufferHeight / 3), Color.Green, 0f, Vector2.One, (curres + 1), SpriteEffects.None, 0f);
            }
            
            _spriteBatch.DrawString(arial, "highest random value:", new Vector2(10, _graphics.PreferredBackBufferHeight / 2.5f), Color.Green, 0f, Vector2.One , (curres+1), SpriteEffects.None, 0f);
            if (minaccept && !maxaccept)
            {
                _spriteBatch.DrawString(arial, "                                 " + max, new Vector2(10, _graphics.PreferredBackBufferHeight / 2.5f), Color.Blue, 0f, Vector2.One, (curres + 1), SpriteEffects.None, 0f);
            }
            else
            {
                _spriteBatch.DrawString(arial, "                                 " + max, new Vector2(10, _graphics.PreferredBackBufferHeight / 2.5f), Color.Green, 0f, Vector2.One, (curres + 1), SpriteEffects.None, 0f);
            }

            _spriteBatch.DrawString(arial, "Generated number:", new Vector2(10, _graphics.PreferredBackBufferHeight / 1.5f), Color.White, 0f, Vector2.One, (curres + 1), SpriteEffects.None, 0f);
            _spriteBatch.DrawString(arial, "                              " + currand, new Vector2(10, _graphics.PreferredBackBufferHeight / 1.5f), Color.White, 0f, Vector2.One, (curres + 1), SpriteEffects.None, 0f);

            _spriteBatch.DrawString(arial, "Made by Drenewoo (WW) using MonoGame C#", new Vector2(10, _graphics.PreferredBackBufferHeight - 20 * (curres + 1)), Color.Red, 0f, Vector2.One, (curres + 1) * 0.8f, SpriteEffects.None, 0f);

            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
        
       
    }
}