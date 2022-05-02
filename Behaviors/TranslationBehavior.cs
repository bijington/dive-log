namespace DiveLog.Behaviors;

public class TranslationBehavior : Behavior<VisualElement>
{
    VisualElement visualElement;
    double hiddenY;

    public double DestinationY
    {
        get => (double)GetValue(DestinationYProperty);
        set => SetValue(DestinationYProperty, value);
    }

    public static readonly BindableProperty DestinationYProperty =
        BindableProperty.Create(
            nameof(DestinationY),
            typeof(double),
            typeof(TranslationBehavior),
            0.0);

    public bool IsOpen
    {
        get => (bool)GetValue(IsOpenProperty);
        set => SetValue(IsOpenProperty, value);
    }

    public static readonly BindableProperty IsOpenProperty =
        BindableProperty.Create(
            nameof(IsOpen),
            typeof(bool),
            typeof(TranslationBehavior),
            false,
            propertyChanged: OnIsOpenPropertyChanged);

    async static void OnIsOpenPropertyChanged(
        BindableObject bindable,
        object oldValue,
        object newValue)
    {
        if (bindable is TranslationBehavior translationBehavior &&
            newValue is bool isOpen)
        {
            await translationBehavior.Animate(isOpen);
        }
    }

    protected override void OnAttachedTo(VisualElement bindable)
    {
        base.OnAttachedTo(bindable);

        visualElement = bindable;

        bindable.SizeChanged += Bindable_SizeChanged;
    }

    private void Bindable_SizeChanged(object sender, EventArgs e)
    {
        visualElement.TranslationY = visualElement.Height;
        hiddenY = visualElement.Height;
    }

    protected override void OnDetachingFrom(VisualElement bindable)
    {
        base.OnDetachingFrom(bindable);
    }

    Task Animate(bool isOpen)
    {
        return visualElement.TranslateTo(0, isOpen ? DestinationY : hiddenY);
    }
}
