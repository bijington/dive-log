using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace DiveLog.ViewModels;

public partial class AddDiveLogViewModel : ObservableObject
{
    ICommand validateCommand;

    [ObservableProperty]
    double progress;

    [ObservableProperty]
    int previousBest;

    [ObservableProperty]
    int newBest;

    [ObservableProperty]
    int depth;

    [ObservableProperty]
    DateTime date = DateTime.Today;

    [ObservableProperty]
    string location;

    [ObservableProperty]
    TimeSpan time = DateTime.Now.TimeOfDay;

    private readonly DiveRepository diveRepository;

    public ICommand ValidateCommand { get => validateCommand; set => SetProperty(ref validateCommand, value); }

    public event EventHandler<EventArgs> TriggerValidation;

    public event EventHandler<EventArgs> ShowPersonalBest;

    public event EventHandler<EventArgs> ShowSaveSuccess;

    public AddDiveLogViewModel(DiveRepository diveRepository)
    {
        this.diveRepository = diveRepository;
    }

    [ICommand]
    public async void Save()
    {
        if (string.IsNullOrWhiteSpace(Location) ||
            Location.Length < 10)
        {
            TriggerValidation.Invoke(this, EventArgs.Empty);
            //ValidateCommand.Execute(nameof(Location));
            return;
        }

        PreviousBest = diveRepository.BestDiveDepth;

        await diveRepository.Save(new Dive
        {
            Location = location,
            Date = date,
            Depth = depth,
            Time = time
        });

        if (Depth > PreviousBest)
        {
            ShowPersonalBest.Invoke(this, EventArgs.Empty);
            await Task.Delay(1000);

            NewBest = Depth;

            Progress = 0.75;
            return;
        }

        ShowSaveSuccess.Invoke(this, EventArgs.Empty);
    }

    [ICommand]
    public async void Done()
    {
        await Shell.Current.GoToAsync("..");
    }
}
