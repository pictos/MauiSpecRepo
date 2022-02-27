namespace MauiSpecRepo;

public partial class MapperPage : ContentPage
{

	int count = 0;

	public MapperPage()
	{
		InitializeComponent();
	}


	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;
		CounterLabel.Text = $"Current count: {count}";
		SemanticScreenReader.Announce(CounterLabel.Text);
		TintColorMapper.SetTintColor(img, null);
	}
}