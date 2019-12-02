using FoeFrenzy.Maps.Tiles;
using Microsoft.Xna.Framework;
using MonoGame.Extended;

namespace AtomicMod
{
	public class ExampleTile : Tile
	{
		public ExampleTile(string name, Color color, Point textureCoord, float movementSpeed = 0.04f, RectangleF? collisionBounds = null, bool swimIn = false, int damage = 0, bool slippery = false, float grassDecorationChance = 0, bool isWall = false) : base(name, color, textureCoord, movementSpeed, collisionBounds, swimIn, damage, slippery, grassDecorationChance, isWall)
		{
		}
	}
}
