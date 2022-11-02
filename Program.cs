namespace diary
{
    internal class Program
    {
        static List<note> notes = new List<note>();
        static List<note> notesByDate = new List<note>();
        static DateTime usingDate = DateTime.Today;
        static int QPosition = 1;

        static void Main(string[] args)
        {
            Notes();
            int position = Fix(1);
            while (true)
            {

                Menu();
                Console.SetCursorPosition(0, position);
                Console.WriteLine("->");
                ConsoleKeyInfo key = Console.ReadKey();
                while (key.Key != ConsoleKey.Enter)
                {
                    if (key.Key == ConsoleKey.UpArrow)
                    {
                        position = Fix(position - 1);
                    }
                    if (key.Key == ConsoleKey.DownArrow)
                    {
                        position = Fix(position + 1);
                    }
                    if (key.Key == ConsoleKey.LeftArrow)
                    {
                        position = 1;
                        usingDate = usingDate.AddDays(-1);
                    }
                    if (key.Key == ConsoleKey.RightArrow)
                    {
                        position = 1;
                        usingDate = usingDate.AddDays(1);
                    }
                    if (key.Key == ConsoleKey.F2)
                    {
                        Console.Clear();
                        Console.WriteLine("\n\tДобавление новой записи:");
                        Console.WriteLine("________________________________________________________________________________________\n");
                        for (int i = 0; i < 1; i++)
                        {
                            note newNote = new note();
                            newNote = new note();
                            Console.WriteLine("Введите дату в формате yyyy.mm.dd");
                            newNote.Date = Convert.ToDateTime(Console.ReadLine());

                            Console.WriteLine("Введите название");
                            newNote.Name = Console.ReadLine();

                            Console.WriteLine("Введите текст записи");
                            newNote.Text = Console.ReadLine();

                            notes.Add(newNote);
                            Console.WriteLine("\n");
                        }
                    }
                    Console.Clear();
                    Menu();
                    Console.SetCursorPosition(0, position);
                    Console.WriteLine("->");

                    key = Console.ReadKey();

                }
                Console.Clear();
                infoNote(position);
                Console.ReadKey();
                Console.Clear();
            }
        }

        static void infoNote(int position)
        {
            Console.WriteLine("\n\t" + notesByDate[position - 1].Date + " - " + notesByDate[position - 1].Name);
            Console.WriteLine("________________________________________________________________________________________\n");
            Console.WriteLine(notesByDate[position - 1].Text);
            Console.WriteLine("________________________________________________________________________________________");
            Console.WriteLine("Для выхода в меню нажмите любую клавишу");
        }

        static void Menu()
        {
            Console.WriteLine("Выбрана дата: " + usingDate);
            notesByDate.Clear();
            for (int i = 0; i < notes.Count(); i++)
            {
                if (notes[i].Date == usingDate)
                {
                    notesByDate.Add(notes[i]);
                }
            }
            QPosition = notesByDate.Count();
            for (int j = 0; j < notesByDate.Count(); j++)
            {
                Console.WriteLine("  " + notesByDate[j].Name);
            }
            Console.WriteLine("____________________________________");
            Console.WriteLine("Для добавления записи нажмите \"F2\"");
        }

        static void Notes()
        {
            note note1 = new();
            note1.Date = new DateTime(2022, 11, 01);
            note1.Name = "Сходить на пары";
            note1.Text = "10.10-11.40 2 Основы алгоритмизации и программирования\tИ.Д. Буканов\r\n" +
                "12.00-13.30 3 Основы алгоритмизации и программирования\tИ.Д. Буканов\r\n" +
                "14.00-15.30 4 Архитектура аппаратных средств\tД.В. Мысев\r\n" +
                "15.40-17.10 5 Физическая культура\tВ.В. Григорьев\r\n";

            notes.Add(note1);

            note note2 = new();
            note2.Date = new DateTime(2022, 11, 01);
            note2.Name = "Позвонить маме";
            note2.Text = "Обещал позвонить";

            notes.Add(note2);

            note note3 = new();
            note3.Date = new DateTime(2022, 11, 02);
            note3.Name = "Сходить на пары";
            note3.Text = "08.30-10.00 1 Основы философии\tВ.О. Никишин\r\n" +
                "10.10-11.40 2 Компьютерные сети\tК.А. Дзюба\r\n" +
                "12.00-13.30 3 Информационные технологии\tА.Г. Молодцова\r\n" +
                "14.00-15.30 4 Дискретная математика с элементами математической логики\tК.В. Мотыльков\r\n";

            notes.Add(note3);

            note note4 = new();
            note4.Date = new DateTime(2022, 11, 02);
            note4.Name = "Съездить к сестре";
            note4.Text = "Отвезти пакет";

            notes.Add(note4);

            note note5 = new();
            note5.Date = new DateTime(2022, 11, 03);
            note5.Name = "Сходить на пары";
            note5.Text = "08.30-10.00 1 Элементы высшей математики\tМ.В. Черемных\r\n" +
                "10.10-11.40 2 Информационные технологии\tА.Г. Молодцова\r\n" +
                "12.00-13.30 3 Основы алгоритмизации и программирования\tС.А. Скорогудаева\r\n";

            notes.Add(note5);
        }

        static int Fix(int position)
        {


            if (position < 1)
            {
                position = QPosition;
            }
            else if (position > QPosition)
            {
                position = 1;
            }
            return position;
        }
    }
}