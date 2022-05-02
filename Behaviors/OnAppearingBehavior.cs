namespace DiveLog.Behaviors;

public class OnAppearingBehavior : Behavior<VisualElement>
{
    VisualElement visualElement;

    protected override void OnAttachedTo(VisualElement bindable)
    {
        base.OnAttachedTo(bindable);

        visualElement = bindable;

        bindable.Loaded += Bindable_Loaded;
    }

    private async void Bindable_Loaded(object sender, EventArgs e)
    {
        await Animate();
    }

    protected override void OnDetachingFrom(VisualElement bindable)
    {
        base.OnDetachingFrom(bindable);
    }

    Task Animate()
    {
        return SlideInCustom();
    }

    private Task FadeAndScale()
    {
        visualElement.Scale = 0;
        visualElement.Opacity = 0;

        List<Task> DiveLog = new();

        DiveLog.Add(visualElement.ScaleTo(1.0, 500, easing: Easing.BounceOut));
        DiveLog.Add(visualElement.FadeTo(1.0, 500, easing: Easing.BounceOut));

        return Task.WhenAll(DiveLog);
    }

    private Task SlideInBasic()
    {
        visualElement.TranslationY = 1000;

        List<Task> DiveLog = new();

        DiveLog.Add(visualElement.TranslateTo(0, 0, 500, easing: Easing.BounceOut));

        return Task.WhenAll(DiveLog);
    }

    private async Task SlideInCustom()
    {
        visualElement.TranslationY = 1000;

        await Task.Delay(200);
        await visualElement.TranslateTo(0, -20, 250, easing: Easing.Linear);
        await visualElement.TranslateTo(0, 10, 150, easing: Easing.Linear);
        await visualElement.TranslateTo(0, 0, 100, easing: Easing.Linear);
    }
}
