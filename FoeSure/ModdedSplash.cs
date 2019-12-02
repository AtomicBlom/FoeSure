using System.Reflection;
using FoeFrenzy.Guis;
using FoeFrenzy.Main;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MLEM.Extended.Extensions;
using MonoGame.Extended;

namespace FoeSure
{
	public class ModdedSplash : GuiSplash
	{
		private Texture2D Ellpeck;

		public ModdedSplash()
		{
			Ellpeck = (Texture2D)typeof(GuiSplash).GetField("Ellpeck", BindingFlags.NonPublic | BindingFlags.Static)
				.GetValue(null);
		}

		public override void Draw(GameTime time, SpriteBatch batch, Color modifier)
		{
			var scaledViewport = Gui.GetScaledViewport();
			batch.FillRectangle(Vector2.Zero, scaledViewport, Color.Black, 0);
			batch.DrawCenteredString(GameImpl.RegularFont, "By Game", new Vector2(scaledViewport.Width / 2f, (scaledViewport.Height / 2f) + 2f), 1f, modifier, false, true, 0f);
			batch.DrawCenteredString(GameImpl.RegularFont, "An Ellpeck", new Vector2(scaledViewport.Width / 2f, (scaledViewport.Height / 2f) -12), 1.5f, modifier, false, true, 0f);
			batch.Draw(Ellpeck, new Vector2(((scaledViewport.Width / 2f) - (Ellpeck.Width * 3f)) - 5f, ((scaledViewport.Height / 2f) - ((Ellpeck.Height * 3f) / 2f)) - 5f), null, modifier, 0f, Vector2.Zero, (float)3f, SpriteEffects.None, 0f);

			batch.DrawCenteredString(GameImpl.RegularFont, "lol Mods!", new Vector2(scaledViewport.Width / 2f + 4f, (scaledViewport.Height / 2f) + 16f), 1.5f, modifier, false, true, 0f);
		}
	}
}