using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace _2DGame.Items
{
    class RendererComponent
    {
        BaseEntity holder;

        #region fields
        private Texture2D animStrip;
        private float timebetweenframes;
        private int width, height;
        private int frames;
        private bool looping;
        private int currentframe;
        private double elapsedtime = 0;
        private Vector2 Position;
        private Rectangle sourceRec;
        private Rectangle destRec;

        public Color colortint;
        public bool active;
        #endregion
        public int getWidth() => width;
        public int getHeight() => height;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="content">the content manager</param> 
        /// <param name="path">The path of the animationsheet (should progress along the x-axis)</param> 
        /// <param name="frames">The number of loopable frames in the animsheet</param> 
        /// <param name="playspeed">How fast the animation should loop</param> 
        /// <param name="width">width of the animationsheet's sprites</param> 
        /// <param name="height">height of the animationsheet's sprites</param> 
        /// <param name="looping">Is this a one time animation, or a continually looping one?</param> 
        /// <param name="active">Is this animation active currently?</param> 
        /// <param name="coordX">The starting coords(upper left) of the animation</param> 
        /// <param name="coordY">The starting coords of the animation</param> 
        /// <param name="startingframe"> What frame of the animation does this start at?</param>



            //eventually make this require a render component, and move drawing functionallity to the renderer
        public RendererComponent(BaseEntity holder, ContentManager content, string path, int frames, float playspeed,
            int width, int height, bool looping, bool active, Color tint, int startingframe = 0)
        {
            this.holder = holder;
            animStrip = content.Load<Texture2D>(path);
            timebetweenframes = playspeed;
            this.width = width;
            this.height = height;
            this.frames = frames;
            this.looping = looping;
            this.active = active;
            colortint = tint;
            currentframe = startingframe;
        }

       
        public void Update(GameTime gtime)
        {
            //update the position for the draw method
            Position = holder.GetPosition();
         


            if ((elapsedtime >= timebetweenframes) && active)
            {
                //setting the current frame to zero if it is at the ebnd of the strip, and moving it up one if it is not.

                if (currentframe >= frames)
                {
                    currentframe = 0;
                }
                else { currentframe++; }
                elapsedtime = 0;

                //sourceRectangle updates if the frame changes, and the destination rectangle changes all the time, because the play could have moved
                sourceRec = new Rectangle(currentframe * width, 0, width, height);
            }
            elapsedtime += gtime.ElapsedGameTime.TotalSeconds;
            destRec = new Rectangle((int)Position.X, (int)Position.Y, width * 4, height * 4);
        }
        public void Draw(SpriteBatch sbatch)
        {
            sbatch.Draw(animStrip, destRec, sourceRec, colortint);           
        }

    }
}

