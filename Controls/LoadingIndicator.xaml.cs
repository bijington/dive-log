namespace DiveLog.Controls;

public partial class LoadingIndicator : ContentView
{
    const string LoadingAnimationName = "LoadingAnimation";

    public bool IsAnimating
    {
        get => (bool)GetValue(IsAnimatingProperty);
        set => SetValue(IsAnimatingProperty, value);
    }

    public static readonly BindableProperty IsAnimatingProperty =
        BindableProperty.Create(
            nameof(IsAnimating),
            typeof(bool),
            typeof(LoadingIndicator),
            false,
            propertyChanged: OnIsOpenPropertyChanged);

    static void OnIsOpenPropertyChanged(
        BindableObject bindable,
        object oldValue,
        object newValue)
    {
        if (bindable is LoadingIndicator loadingIndicator &&
            newValue is bool isAnimating)
        {
            loadingIndicator.Animate(isAnimating);
        }
    }

    public LoadingIndicator()
	{
		InitializeComponent();
	}

    protected async override void OnSizeAllocated(double width, double height)
    {
        base.OnSizeAllocated(width, height);

        Animate(true);

        //Dispatcher.DispatchDelayed(TimeSpan.FromSeconds(4), () => Animate(false));
    }

    void Animate(bool isAnimating)
    {
        this.AbortAnimation(LoadingAnimationName);

        if (!isAnimating)
        {
            return;
        }

        var animation = new Animation();

        animation.Add(0.2, 0.8, new Animation((v) => Icon.Rotation = v, 0, 360));

        animation.Commit(
            this,
            LoadingAnimationName,
            length: 750,
            easing: Easing.SinInOut,
            repeat: () => true);
    }
}