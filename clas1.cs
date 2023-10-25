namespace SHASBIPOSPATANEETOVSE;

internal class main
{
    static void Main(string[] args)
    {
        Diary.init();
        Diary.launchMenu();
    }
}
public class Note
{
    public string name { get; set; }
    public string text { get; set; }
    public DateTime date { get; set; }


    public Note(string name, string text, DateTime date)
    {
        this.name = name;
        this.text = text;
        this.date = date;

    }
}
