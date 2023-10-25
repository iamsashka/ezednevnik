namespace SHASBIPOSPATANEETOVSE; 
using System.Globalization;

using System.Runtime.InteropServices;






public class Diary
{
    // Пишу этот код в 2 ночи(утра 25 числа) ошибок нет и слава богу
    // щас бы пиццы...
    public static ConsoleKeyInfo key;
    public static List<Note> notes = new List<Note>();
    public static List<Note> dailyNotes;
    public static bool notebool = true;
    //я заказала пиццу
    static DateTime dt = DateTime.Now;
    static int pos = 1;

    static Note note = new Note("Сделать практос по ОПБД", "Не забыть отправить!!!", DateTime.Today);
    //я поела пиццу
    static Note note2 = new Note("Сдать ЭТОТ  практос хотя бы на 4 :)", "ЭХ...щас бы на море..",
        DateTime.Today);

    static Note note3 = new Note("Записаться на кератиновое выпрямление", "Записаться к Екатерине на 18:00", new DateTime(2023, 11, 20));

    static Note note4 = new Note("Пойти гулять","Пойти с Лерой, Соней и Лизой в наше любимое кафе и поесть синабоны ", new DateTime(2023, 11, 23));

    static Note note5 = new Note("День рождения Лизы", "Купить подарок + нужно купить билет до Чебоксар", new DateTime(2023, 10, 26));
    public static void init()
    {
        dailyNotes = new List<Note>();
        notes.Add(note);
        notes.Add(note2);
        notes.Add(note3);
        notes.Add(note4);
        notes.Add(note5);
    }

    public static void moving()
    {

        do
        {
            Console.SetCursorPosition(0, pos);
            Console.WriteLine("  ");
            if (key.Key == ConsoleKey.UpArrow && pos != 1)
            {
                pos--;
            }
            else if (key.Key == ConsoleKey.DownArrow && pos != notes.Count) 
            {
                pos++;
            }
            else if (key.Key == ConsoleKey.LeftArrow)
            {
                Console.Clear();
                dailyNotes = new List<Note>();
                dt = dt.AddDays(-1);
                menu();


            }
            //шел 3 час ночи а я все пытаюсь разобраться с отправкой на гитхаб
            else if (key.Key == ConsoleKey.RightArrow)
            {
                Console.Clear();
                dailyNotes = new List<Note>();
                dt = dt.AddDays(1);
                menu();


            }
          
            else if (key.Key == ConsoleKey.P)
            {
                if (notebool)
                {
                    Console.Clear();
                    addNote();
                }
            }
            Console.SetCursorPosition(0, pos);
            Console.WriteLine("->");
            key = Console.ReadKey();
        } while (key.Key != ConsoleKey.Enter);
        Console.SetCursorPosition(0, 8); 
        choice();
    }

    public static void launchMenu()
    {
        menu();

        Diary.moving();
    }

    public static void menu()
    {
        Console.Clear();

        Console.WriteLine("Выбрана дата: " + dt.ToString("D") + " Для создания заметки нажмите P...PIZZA");
        getAllNotes(notes);


    }
    public static void getAllNotes(List<Note> notes)
    {

        int i = 1;

        foreach (Note note in notes)
        {
            if (note.date.Date == dt.Date)
            {
                Console.Write("  " + i + ". ");
                Console.WriteLine(note.name);

                dailyNotes.Add(note);
                i++;
            }
        }
    }


    public static void choice()
    {
        if (notes.Count > 0)
        {
            infoMenu(dailyNotes[pos - 1]);
        }
    }


    public static void infoMenu(Note note)
    {
        Console.Clear();
        Console.WriteLine("Название: " + note.name + "\n" + "Описание: " + note.text + "\n" + "Дата: " + note.date);
        ConsoleKeyInfo secondkey = Console.ReadKey();
        if (secondkey.Key == ConsoleKey.Escape)
        {

            launchMenu();

        }


        Console.ReadLine();


    }//Я РАЗОБРАЛАСЬ С ГИТХАБОМ!!!

    public static void addNote()
    {
        var info = new CultureInfo("ru-RU");
        Console.WriteLine("Введите краткое имя заметки");
        String a = Console.ReadLine();
        Console.WriteLine("Введите текст в заметке");
        String b = Console.ReadLine();
        Console.WriteLine("                                   [                  ````   ````   ]");
        Console.WriteLine("                                   [ 23 ноября 2023    ___    ___   ]");
        Console.WriteLine("                                   [     ЭТО           | |    | |   ]");
        Console.WriteLine("                                   [     МОЙ           ---    ---   ]");
        Console.WriteLine("                                   [     ДЕНЬ            _____      ]");
        Console.WriteLine("                                   [    РОЖДЕНИЯ        /   /       ]");
        Console.WriteLine("                                   [       !!!         /___/        ]");
        String c = Console.ReadLine();
        DateTime d = DateTime.Parse(c, info, DateTimeStyles.NoCurrentDateDefault);//НЕ НУ ЭТО ШЕДЕВР Я СЧИТАЮ
        Note x = new Note(a, b, d);
        notes.Add(x);
        Console.WriteLine(x);

        notebool = false;
        dailyNotes = new List<Note>();
        launchMenu();
    }


}
