namespace DiveLog;

public class Dive
{
	public DateTime Date { get; init; }
    public int Depth { get; init; }
    public string Location { get; init; }
    public TimeSpan Time { get; init; }
}
