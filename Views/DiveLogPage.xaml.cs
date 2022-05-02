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
}