using DiveLog.ViewModels;

namespace DiveLog.Views;

public partial class AddDiveLogPage : ContentPage
{
	public AddDiveLogPage(AddDiveLogViewModel addDiveLogViewModel)
	{
		InitializeComponent();

        BindingContext = addDiveLogViewModel;

        addDiveLogViewModel.TriggerValidation += AddDiveLogViewModel_TriggerValidation;
        addDiveLogViewModel.ShowSaveSuccess += AddDiveLogViewModel_ShowSaveSuccess;
        addDiveLogViewModel.ShowPersonalBest += AddDiveLogViewModel_ShowPersonalBest;
	}

    private async void AddDiveLogViewModel_ShowPersonalBest(object sender, EventArgs e)
    {
        PersonalBestPopup.Scale = 0;
        PersonalBestPopup.Opacity = 1;

        await PersonalBestPopup.ScaleTo(1.0, 500, easing: Easing.BounceOut);
    }

    private async void AddDiveLogViewModel_ShowSaveSuccess(object sender, EventArgs e)
    {
        SavePopup.Scale = 0;
        SavePopup.Opacity = 1;

        await SavePopup.ScaleTo(1.0, 500, easing: Easing.BounceOut);
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        SavePopup.Scale = 0;
        PersonalBestPopup.Scale = 0;
    }

    private async void AddDiveLogViewModel_TriggerValidation(object sender, EventArgs e)
    {
        await NameRulesLabel.FadeTo(1.0);
        await NameEntry.TranslateTo(-13, 0, 100);
        await NameEntry.TranslateTo(13, 0, 100);
        await NameEntry.TranslateTo(-5, 0, 100);
        await NameEntry.TranslateTo(5, 0, 100);
        await NameEntry.TranslateTo(0, 0, 100);
    }

    void ProgressBarAnimationBehavior_AnimationCompleted(System.Object sender, System.EventArgs e)
    {
        Animation animation = new Animation();

        var view = PersonalBestLabel;

        double rotationAngle = 3.0;
        double minimumScale = 0.9;
        double maximumScale = 1.1;

        animation.Add(0, 0.1, new Animation(v => view.Scale = v, 1, minimumScale));
        animation.Add(0.2, 0.3, new Animation(v => view.Scale = v, minimumScale, maximumScale));
        animation.Add(0.9, 1.0, new Animation(v => view.Scale = v, maximumScale, 1));

        animation.Add(0, 0.2, new Animation(v => view.Rotation = v, 0, -rotationAngle));
        animation.Add(0.2, 0.3, new Animation(v => view.Rotation = v, -rotationAngle, rotationAngle));
        animation.Add(0.3, 0.4, new Animation(v => view.Rotation = v, rotationAngle, -rotationAngle));
        animation.Add(0.4, 0.5, new Animation(v => view.Rotation = v, -rotationAngle, rotationAngle));
        animation.Add(0.5, 0.6, new Animation(v => view.Rotation = v, rotationAngle, -rotationAngle));
        animation.Add(0.6, 0.7, new Animation(v => view.Rotation = v, -rotationAngle, rotationAngle));
        animation.Add(0.7, 0.8, new Animation(v => view.Rotation = v, rotationAngle, -rotationAngle));
        animation.Add(0.8, 0.9, new Animation(v => view.Rotation = v, -rotationAngle, rotationAngle));
        animation.Add(0.9, 1.0, new Animation(v => view.Rotation = v, rotationAngle, 0));

        animation.Commit(
            owner: PersonalBestLabel,
            name: "Tada",
            length: 1000,
            easing: Easing.Linear, finished: (x, y) => { });

    }
}