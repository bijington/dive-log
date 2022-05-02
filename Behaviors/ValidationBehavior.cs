using System.Windows.Input;

namespace DiveLog.Behaviors;

public class ValidationBehavior : Behavior<VisualElement>
{
    private VisualElement entry;

    public ICommand? ValidateCommand
    {
        get => (ICommand?)GetValue(ValidateCommandProperty);
        set => SetValue(ValidateCommandProperty, value);
    }

    public static readonly BindableProperty ValidateCommandProperty =
           BindableProperty.Create(
               nameof(ValidateCommand),
               typeof(ICommand),
               typeof(ValidationBehavior),
               default,
               defaultValueCreator: GetDefaultForceValidateCommand,
               defaultBindingMode: BindingMode.OneWayToSource,
               propertyChanged: OnValidateCommandPropertyChanged);

    static object GetDefaultForceValidateCommand(BindableObject bindable)
        => ((ValidationBehavior)bindable).DefaultValidateCommand;

    static void OnValidateCommandPropertyChanged(BindableObject bindale, object oldValue, object newValue)
    {

    }

    protected virtual ICommand DefaultValidateCommand { get; }

    public ValidationBehavior() => DefaultValidateCommand = new Command<string>(async (name) => await Validate(name).ConfigureAwait(false));

    protected override void OnAttachedTo(VisualElement bindable)
    {
        base.OnAttachedTo(bindable);

        entry = bindable;
    }

    private Task Validate(string propertyName)
    {
        return Task.CompletedTask;
    }
}
