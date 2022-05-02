namespace DiveLog;

public class DiveRepository
{
    readonly IList<Dive> dives;

    public int BestDiveDepth => dives.Select(d => d.Depth).Max();

    public DiveRepository()
    {
        dives = new List<Dive>
        {
            new Dive
            {
                Date = DateTime.Now.AddHours(-1),
                Depth = 10,
                Location = "Lanai Cathedrals, Maui",
                Time = new TimeSpan(11, 45, 00)
            },
            new Dive
            {
                Date = DateTime.Now.AddHours(-1),
                Depth = 15,
                Location = "Honolua Bay, Maui",
                Time = new TimeSpan(11, 45, 00)
            }
        };
    }

	public IList<Dive> GetDives()
    {
        return dives;
    }

    public async Task Save(Dive dive)
    {
        await Task.Delay(1000);

        dives.Add(dive);
    }
}
