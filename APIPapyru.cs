using APIPapyru.Core.RenderHelper;
using Terraria.Graphics.Effects;

namespace APIPapyru
{
    // Please read https://github.com/tModLoader/tModLoader/wiki/Basic-tModLoader-Modding-Guide#mod-skeleton-contents for more information about the various files in a mod.
    public class APIPapyru : Mod
    {
        public static RenderTarget2D render1;
        public static RenderTarget2D render2;
        public static RenderHelperSystem renderHelperSystem;
        public override void Load()
        {
            On_FilterManager.EndCapture += On_FilterManager_EndCapture;
            On_Main.LoadWorlds += On_Main_LoadWorlds;
            Main.OnResolutionChanged += Main_OnResolutionChanged;
        }
        private static void Main_OnResolutionChanged(Vector2 obj)
        {
            Main.QueueMainThreadAction(() =>
            {
                render1 = new(Main.graphics.GraphicsDevice, Main.screenWidth, Main.screenHeight);
                render2 = new(Main.graphics.GraphicsDevice, Main.screenWidth, Main.screenHeight);
            });
        }

        private static void On_Main_LoadWorlds(On_Main.orig_LoadWorlds orig)
        {
            Main.QueueMainThreadAction(() =>
            {
                render1 = new(Main.graphics.GraphicsDevice, Main.screenWidth, Main.screenHeight);
                render2 = new(Main.graphics.GraphicsDevice, Main.screenWidth, Main.screenHeight);
            });
            orig.Invoke();
        }
        public static void On_FilterManager_EndCapture(On_FilterManager.orig_EndCapture orig, FilterManager self, RenderTarget2D finalTexture, RenderTarget2D screenTarget1, RenderTarget2D screenTarget2, Color clearColor)
        {
            renderHelperSystem.Draw(render1,render2);
            orig.Invoke(self, finalTexture, screenTarget1, screenTarget2, clearColor);
        }
    }
}
