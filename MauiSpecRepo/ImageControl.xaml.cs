namespace MauiSpecRepo;

public partial class ImageControl : ContentPage
{
    int count = 0;

    public ImageControl()
	{
		InitializeComponent();
	}


	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;
		CounterLabel.Text = $"Current count: {count}";
		img.TintColor = null;
		SemanticScreenReader.Announce(CounterLabel.Text);
	}
}