using FoeSure;
using Microsoft.Xna.Framework;

namespace AtomicMod
{
	public class AtomicMod : FoeFrenzyMod
	{
		public AtomicMod()
		{
			new ExampleTile("Test", Color.AntiqueWhite, new Point(0, 0)).Register();
		}
	}
}