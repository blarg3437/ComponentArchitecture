using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace _2DGame.Map
{
    class Dungeon
    {
        /*each dungeon will have a texture list that it cycles through
            * This means that when a new 'level' is loaded, the dungeon will hold onto the active texture
            * Each individual level(of which a dungeon contains a set amount), will be randomly generated
            * and will contain a map.
            * The map will have an int[] designated as the floor tiles.
            * CurrentDungeon->CurrentLevel->RandomMap->FloorLayout[]
            * */


        Level CurrentLevel;
        List<Texture2D> AvailableTextures;
        Texture2D CurrentTexture;
        int numberoflevels;
        int currentlevelnumber;//which level is this, used to track how many
        public Dungeon(List<Texture2D> textures, int levelnum)
        {
            AvailableTextures = textures;
            numberoflevels = levelnum;
            CurrentLevel = new Level();
            currentlevelnumber = 1;
        }

        public void StartNewLevel()
        {

        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spritebatch)
        {

        }
    }
}
