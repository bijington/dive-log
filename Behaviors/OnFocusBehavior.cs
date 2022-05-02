namespace DiveLog.Behaviors;

public class OnFocusBehavior : Behavior<VisualElement>
{
    private VisualElement visualElement;

    private double originalTitleOpacity = 0.6;
    private double originalFooterOpacity = 0;

    public VisualElement TitleElement
    {
        get => (VisualElement)GetValue(TitleElementProperty);
        set => SetValue(TitleElementProperty, value);
    }

    public static readonly BindableProperty TitleElementProperty =
        BindableProperty.Create(
            nameof(TitleElement),
            typeof(VisualElement),
            typeof(OnFocusBehavior),
            null);

    public VisualElement FooterElement
    {
        get => (VisualElement)GetValue(FooterElementProperty);
        set => SetValue(FooterElementProperty, value);
    }

    public static readonly BindableProperty FooterElementProperty =
        BindableProperty.Create(
            nameof(FooterElement),
            typeof(VisualElement),
            typeof(OnFocusBehavior),
            null);

    protected override void OnAttachedTo(VisualElement bindable)
    {
        base.OnAttachedTo(bindable);

        visualElement = bindable;

        visualElement.Focused += OnFocused;
        visualElement.Unfocused += OnUnfocused;
    }

    protected override void OnDetachingFrom(VisualElement bindable)
    {
        base.OnDetachingFrom(bindable);

        visualElement.Focused -= OnFocused;
        visualElement.Unfocused -= OnUnfocused;
    }

    private async void OnUnfocused(object sender, FocusEventArgs e)
    {
        List<Task> animations = new();

        if (TitleElement is not null)
        {
            animations.Add(TitleElement.FadeTo(originalTitleOpacity));
        }

        if (FooterElement is not null)
        {
            animations.Add(FooterElement.FadeTo(originalFooterOpacity));
        }

        if (animations.Any())
        {
            await Task.WhenAll(animations);
        }
    }

    private async void OnFocused(object sender, FocusEventArgs e)
    {
        List<Task> animations = new();

        if (TitleElement is not null)
        {
            animations.Add(TitleElement.FadeTo(1.0));
        }

        if (FooterElement is not null)
        {
            animations.Add(FooterElement.FadeTo(1.0));
        }

        if (animations.Any())
        {
            await Task.WhenAll(animations);
        }
    }
}
