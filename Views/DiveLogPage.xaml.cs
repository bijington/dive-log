using DiveLog.Behaviors;
using DiveLog.ViewModels;

namespace DiveLog.Views;

public partial class DiveLogPage : ContentPage
{
	private DiveLogViewModel viewModel;

	public DiveLogPage(DiveLogViewModel diveLogViewModel)
	{
		InitializeComponent();

		BindingContext = viewModel = diveLogViewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

		viewModel.LoadDives();
    }

    protected override void OnSizeAllocated(double width, double height)
    {
        base.OnSizeAllocated(width, height);

        //AddPopup.TranslationY = height;
    }

    async void Button_Clicked(System.Object sender, System.EventArgs e)
    {
        //await AddPopup.TranslateTo(0, 100);
        ((TranslationBehavior)AddPopup.Behaviors.First()).IsOpen = true;
    }
}