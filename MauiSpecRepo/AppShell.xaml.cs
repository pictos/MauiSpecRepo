namespace MauiSpecRepo;

public partial class AppShell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
		Routing.RegisterRoute(nameof(MapperPage), typeof(MapperPage));
		Routing.RegisterRoute(nameof(ImageControl), typeof(ImageControl));
	}
}