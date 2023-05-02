using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

namespace WhatDidYouDraw;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Nice-Sugar.ttf", "NiceSugar");
                fonts.AddFont("RobotoMono-VariableFont_wght.ttf", "RobotoMono");


            });

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
