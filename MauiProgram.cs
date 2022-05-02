using DiveLog.ViewModels;
using DiveLog.Views;
using CommunityToolkit.Maui;

namespace DiveLog;

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
			});

		builder.Services.AddTransient<AddDiveLogPage>();
		builder.Services.AddTransient<AddDiveLogViewModel>();
		builder.Services.AddTransient<DiveLogPage>();
		builder.Services.AddTransient<DiveLogViewModel>();

		builder.Services.AddSingleton<DiveRepository>();

		return builder.Build();
	}
}
