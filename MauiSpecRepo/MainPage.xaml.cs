namespace MauiSpecRepo;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;
		CounterLabel.Text = $"Current count: {count}";
		img.Behaviors.Clear();
		SemanticScreenReader.Announce(CounterLabel.Text);
	}
}

