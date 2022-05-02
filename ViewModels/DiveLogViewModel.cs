using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace DiveLog.ViewModels;

public partial class DiveLogViewModel : ObservableObject
{
	[ObservableProperty]
	bool isInAddMode;

	[ObservableProperty]
	string name;

	[ObservableProperty]
	DateTime date;

    private readonly DiveRepository diveRepository;

    public ObservableCollection<Dive> Dives { get; }

	public DiveLogViewModel(DiveRepository diveRepository)
	{
		Dives = new ObservableCollection<Dive>();

        this.diveRepository = diveRepository;
    }

	[ICommand]
	public async void AddDive()
    {
		//IsInAddMode = !IsInAddMode;
		await Shell.Current.GoToAsync(new ShellNavigationState("AddDiveLogPage"), true);
    }

	public void LoadDives()
    {
		foreach (var dive in diveRepository.GetDives())
		{
			if (Dives.Any(d => d.Location == dive.Location))
            {
				continue;
            }

			Dives.Add(dive);
		}
	}
}

