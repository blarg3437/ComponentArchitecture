using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2DGame.Actors;
using _2DGame.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Components
{
    class Animation:BaseComponent
    {
        #region fields
        private Texture2D animStrip;
       private float timebetweenframes;
       private int width, height;
       private int frames;
       private bool looping;       
       private int currentframe;
       private double elapsedtime = 0;
       private int x, y;
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
        /// 

        public Animation(IComponentHolder parent) : base(parent)
        {

        }
        public void Initialize(ContentManager content, string path, int frames, float playspeed,
            int width, int height, bool looping, bool active, int coordX, int coordY, Color tint, int startingframe=0)
        {
            animStrip = content.Load<Texture2D>(path);
            timebetweenframes = playspeed;
            this.width = width;
            this.height = height;
            this.frames = frames;
            this.looping = looping;
            x = coordX;
            y = coordY;
            this.active = active;
            colortint = tint;
            currentframe = startingframe;
           
        }
        public void Update(GameTime gtime, int x, int y)
        {
            //update the position for the draw method
            this.x = x;
            this.y = y;
           
      
            if((elapsedtime >= timebetweenframes) && active)
            {
                //setting the current frame to zero if it is at the ebnd of the strip, and moving it up one if it is not.
                
                if(currentframe >= frames)
                {
                    currentframe = 0;
                }
                else { currentframe++; }
                elapsedtime = 0;

                //sourceRectangle updates if the frame changes, and the destination rectangle changes all the time, because the play could have moved
                sourceRec = new Rectangle(currentframe * width, 0, width, height);
            }
            elapsedtime += gtime.ElapsedGameTime.TotalSeconds;
            destRec = new Rectangle(x, y, width * 4, height* 4);
        }
       
        public void Draw(SpriteBatch sbatch)
        {
            sbatch.Draw(animStrip, destRec, sourceRec, colortint);
        }

    }
}
