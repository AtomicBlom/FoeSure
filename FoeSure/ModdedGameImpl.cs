using FoeFrenzy.Main;

namespace FoeSure
{
	public class ModdedGameImpl : GameImpl
	{
		public ModdedGameImpl(string[] args) : base(args)
		{
		}

		protected override void LoadContent()
		{
			base.LoadContent();
			Fade(1f, delegate {
				SetGui(new ModdedSplash(), false);
				Fade(-0.02f, null);
			});
		}
	}
}