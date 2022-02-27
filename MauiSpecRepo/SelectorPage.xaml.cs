namespace MauiSpecRepo;

public partial class SelectorPage : ContentPage
{
	public SelectorPage()
	{
		InitializeComponent();
	}

    private void ButtonBehavior_Clicked(object? sender, EventArgs args)
    {
		Shell.Current.GoToAsync(nameof(MainPage));
    }
    private void ButtonMapper_Clicked(object? sender, EventArgs args)
    {
        TintColorMapper.ApplyTintColor();
        Shell.Current.GoToAsync(nameof(MapperPage));
    }

    private void ButtonCustomControl_Clicked(object? sender, EventArgs args)
    {
        Shell.Current.GoToAsync(nameof(ImageControl));
    }
}