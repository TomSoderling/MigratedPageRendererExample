using Microsoft.Extensions.Logging;
using Microsoft.Maui.Handlers;

namespace MigratedPageRendererExample;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			})
			.ConfigureMauiHandlers(handlers =>
			{
				#if IOS
                PageHandler.PlatformViewFactory = (handler) =>
                {
					var vc = new Renderers.ExtendedPageViewController(handler.VirtualView, handler.MauiContext);
					handler.ViewController = vc;
					return null;
                };
				#endif

				#if ANDROID
                PageHandler.PlatformViewFactory = (handler) =>
                {
                    var cvg = new Renderers.ExtendedPageContentViewGroup(handler.Context);
					return cvg;
                };
				#endif

            });

		#if DEBUG
		builder.Logging.AddDebug();
		#endif

		return builder.Build();
	}
}

