using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Works;
using Items;
using System.Security.Cryptography.X509Certificates;

namespace Survival
{
    internal class Program
    {

        public static void Main(string[] args)
        {
            Player player = new Player();
            Job[] jobs = { new GarbageCollector(), new Security(), new Salesman(), new Manager(),
              new Director(), new CEO(), new SmallBusinessman(), new AverageBusinessman(), new BigBusinessman(),
              new Mer(), new Official(), new Deputy(), new VicePresident(), new President()};
            ItemShop ishop = new ItemShop();
            Item[] items = {new Bag(), new Wallet(), new Watch(), new ButtonTelephone(), new Suit(), new Apartment(), new Phone(),
            new Laptop(), new Moped(), new Garage(), new Assistant(), new Car(), new Computer(), new BigApartment(), new Yacht(),
            new Helicopter(), new Mansion()};
            Random rand = new Random();
            JobShop jshop = new JobShop();


            Console.WriteLine(new string('=', 30));
            Console.WriteLine("Добро, пожаловать в игру про выживание!");
            Console.Write("Введите свое Имя: ");
            player.Name = Console.ReadLine();
            Console.WriteLine("Чтобы ознакомиться с сюжетом и начать игру нажмите Enter  ");
            bool isWork = true;

            while (isWork)
            {
                switch (Console.ReadKey().Key)
                {

                    case ConsoleKey.Enter:
                        Console.Clear();
                        Console.WriteLine("Вы играете за бомжа который решил стать богачом\nВаша цель купить дом за десять миллионов \n" +
                            "Чтобы достигнуть этой цели вам нужно устраиваться на все более престижные работы и" +
                            "\nпокупать акссесуары которые будут увеличивать ваш зароботок.\n");
                        Console.WriteLine($"{player.Name} чтобы начать игру нажмите любую клавишу.");
                        Console.ReadKey();
                        isWork = false;

                        isWork = false;
                        break;
                }
            }
            isWork = true;
            while (isWork)
            {

                Console.Clear();
                Console.WriteLine("1-Магазин и Биржа Труда\n\n2-Работа\n\n3-Статистика");
                ChangeTextColor("0-Выход", ConsoleColor.Red, 10, 5);
                Console.WriteLine();
                Console.Write("Выберите действие: ");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        Console.WriteLine("Для просмотра списка работ Нажмите 1\n\nМагазин аксесуаров Нажмите 2\n");
                        ChangeTextColor("0-Выход", ConsoleColor.Red, 10, 5);
                        switch (Console.ReadKey().Key)
                        {
                            case ConsoleKey.D1:
                                jshop.Sell(player.Balance, player.Exp);
                                if (JobShop.isBuyJob)
                                {
                                    player.job = jobs[JobShop.IndexJob];
                                    JobShop.isBuyJob = false;
                                    player.Balance -= jobs[JobShop.IndexJob].Price;
                                    player.Exp -= jobs[JobShop.IndexJob].ExpPrice;
                                }
                                break;

                            case ConsoleKey.D2:
                                ishop.Sell(player.Balance);
                                if (ItemShop.isBuyItem)
                                {
                                    player.item = items[ItemShop.IndexItem];
                                    ItemShop.isBuyItem = false;
                                    player.Balance -= items[ItemShop.IndexItem].Price;
                                }
                                break;

                        }
                        break;
                    case ConsoleKey.D2:
                        Console.Clear();
                        Work.StartWork();

                        player.Balance += (player.job.Salary * player.item.Factor * Work.WorkDays);
                        player.Exp += (player.job.ExpSalary * player.item.Factor * Work.WorkDays);
                        break;
                    case ConsoleKey.D3:
                        Console.Clear();
                        player.ShowInfo(player.Name, player.job, player.Balance, player.Exp, player.item);
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D0:
                        Console.Clear();
                        Console.WriteLine("Конец игры");
                        isWork = false;
                        break;


                    default:
                        break;
                }

            }
        }

        public static void ChangeTextColor(string text, ConsoleColor color = ConsoleColor.Red, int BeforeY = 0, int AfterY = 0)
        {
            ConsoleColor fcolor = Console.ForegroundColor;
            if (BeforeY == 0 & AfterY == 0)
            {

                Console.ForegroundColor = color;
                Console.WriteLine(text);
                Console.ForegroundColor = fcolor;
            }
            else
            {
                Console.SetCursorPosition(0, BeforeY);
                Console.ForegroundColor = color;
                Console.WriteLine(text);
                Console.ForegroundColor = fcolor;
                Console.SetCursorPosition(0, AfterY);
            }

        }




    }


    public class Player
    {
        public string Name;
        public Job job;
        public float Balance;
        public Item item;
        public float Exp;

        public Player()
        {
            Job[] jobs = { new GarbageCollector(), new Security(), new Salesman(), new Manager(),
              new Director(), new CEO(), new SmallBusinessman(), new AverageBusinessman(), new BigBusinessman(),
              new Mer(), new Official(), new Deputy(), new VicePresident(), new President()};
            Nothing nothing = new Nothing();
            item = nothing;
            job = jobs[0];
            Balance = 100;
            Exp = 0;

        }

        public void ShowInfo(string name, Job job, float bal, float Exp, Item item)
        {
            string[] statusA = { "Бомж", "Нищий", "Бедный", "Малоимущий", "Cреднестатестический", "Cостоятельный", "Зажиточный", "Богатый", "Милионер" };

            string status = "";
            if (bal < 100)
            {
                status = statusA[0];
            }
            else if (bal >= 100 & bal < 500)
            {
                status = statusA[1];
            }
            else if (bal >= 500 & bal < 5000)
            {
                status = statusA[2];
            }
            else if (bal >= 5000 & bal < 10000)
            {
                status = statusA[3];
            }
            else if (bal >= 10000 & bal < 30000)
            {
                status = statusA[4];
            }
            else if (bal >= 30000 & bal < 60000)
            {
                status = statusA[5];
            }
            else if (bal >= 60000 & bal < 100000)
            {
                status = statusA[6];
            }
            else if (bal >= 100000 & bal < 250000)
            {
                status = statusA[7];
            }
            else if (bal >= 250000 & bal <= 1000000)
            {
                status = statusA[8];
            }
            else if (bal > 1000000)
            {
                status = statusA[8];
            }
            Console.WriteLine($"    Имя:   {name}\n\n Работа:  {job.JobName}\n\n Баланс:  {bal}\n\nПредмет:  {item.ItemName}" +
                $"\n\n   Опыт:  {Exp}\n\n Статус:  {status}");
        }

    }
    class Work
    {
        public static float WorkDays;
        public static int СountOfWorkingDays(int score)
        {
            int WorkDays = score / 3;
            return WorkDays;
        }
        private static void Rules()
        {
            Console.Clear();
            Console.WriteLine("Ваша задача делать математические вычесления с данными вам числами 1 рабочий день 3 " +
                "Правильно Решенных  задачи");
            Console.WriteLine("Нажмите любую клавишу для начала рабочего дня");
            Console.ReadKey();
            Console.Clear();
        }
        public static void StartWork()
        {

            int Wscore = 0;
            int a, b;
            Random rand = new Random();
            Console.WriteLine("Нажмите Enter чтобы ознакомиться с правилами работы\n\nНажмите Пробел для начала рабочего дня\n\n" +
            "Нажмите Backspace чтобы окончить рабочий день");
            int result = 0;
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.Enter:
                    Rules();
                    break;
                case ConsoleKey.Backspace:
                    result = -99999;
                    break;
            }

            for (bool isWork = true; isWork;)
            {

                a = rand.Next(1, 101);
                b = rand.Next(1, 101);
                switch (rand.Next(0, 4))
                {
                    case 0:


                        Console.Clear();
                        Console.WriteLine(a + " + " + b + " =...\n");
                        Console.WriteLine($"Счет: {Wscore}\n");
                        Program.ChangeTextColor("0-Выход", ConsoleColor.Red);
                        Console.WriteLine();
                        if (result == -99999)
                        {
                            isWork = false;
                            break;
                        }
                        result = int.Parse(Console.ReadLine());
                        if (result == 0)
                        {
                            isWork = false;
                            break;
                        }
                        if (result == a + b)
                        {
                            Wscore++;
                            Program.ChangeTextColor("Правильно!", ConsoleColor.Green);
                            Console.ReadKey();

                        }
                        else
                        {
                            Program.ChangeTextColor("Неправильно попробуй еще раз!");
                            Console.ReadKey();

                        }
                        break;
                    case 1:
                        Console.Clear();

                        Console.WriteLine(a + " - " + b + " =...\n");
                        Console.WriteLine($"Счет: {Wscore}\n");
                        Program.ChangeTextColor("0-Выход", ConsoleColor.Red);
                        Console.WriteLine();
                        if (result == -99999)
                        {
                            isWork = false;
                            break;
                        }
                        result = int.Parse(Console.ReadLine());
                        if (result == 0)
                        {
                            isWork = false;
                            break;
                        }
                        if (result == a - b)
                        {
                            Wscore++;
                            Program.ChangeTextColor("Правильно!", ConsoleColor.Green);
                            Console.ReadKey();

                        }
                        else
                        {
                            Program.ChangeTextColor("Неправильно попробуй еще раз!");
                            Console.ReadKey();

                        }
                        break;
                    case 2:
                        Console.Clear();

                        Console.WriteLine(a + " * " + b + " =...\n");
                        Console.WriteLine($"Счет: {Wscore}\n");
                        Program.ChangeTextColor("0-Выход", ConsoleColor.Red);
                        Console.WriteLine();
                        if (result == -99999)
                        {
                            isWork = false;
                            break;
                        }
                        result = int.Parse(Console.ReadLine());
                        if (result == 0)
                        {
                            isWork = false;
                            break;
                        }
                        if (result == a * b)
                        {
                            Wscore++;
                            Program.ChangeTextColor("Правильно!", ConsoleColor.Green);
                            Console.ReadKey();

                        }
                        else
                        {
                            Program.ChangeTextColor("Неправильно попробуй еще раз!");
                            Console.ReadKey();

                        }
                        break;
                    case 3:
                        Console.Clear();

                        if (a >= b)
                        {
                            Console.WriteLine(a + " : " + b + " =...\n");
                            Console.WriteLine($"Счет: {Wscore}\n");
                            Program.ChangeTextColor("0-Выход", ConsoleColor.Red);
                            Console.WriteLine();
                            if (result == -99999)
                            {
                                isWork = false;
                                break;
                            }
                            result = int.Parse(Console.ReadLine());
                            if (result == 0)
                            {
                                isWork = false;
                                break;
                            }

                            if (result == a / b)
                            {
                                Wscore++;
                                Program.ChangeTextColor("Правильно!", ConsoleColor.Green);
                                Console.ReadKey();
                            }
                            else
                            {
                                Program.ChangeTextColor("Неправильно попробуй еще раз!");
                                Console.ReadKey();
                            }
                        }
                        else
                        {
                            Console.WriteLine(b + " : " + a + " =...\n");
                            Console.WriteLine($"Счет: {Wscore}\n");
                            Program.ChangeTextColor("0-Выход", ConsoleColor.Red);
                            Console.WriteLine();
                            if (result == -99999)
                            {
                                isWork = false;
                                break;
                            }
                            result = int.Parse(Console.ReadLine());
                            if (result == 0)
                            {
                                isWork = false;
                                break;
                            }
                            if (result == b / a)
                            {
                                Wscore++;
                                Program.ChangeTextColor("Правильно!", ConsoleColor.Green);
                                Console.ReadKey();
                            }
                            else
                            {
                                Program.ChangeTextColor("Неправильно попробуй еще раз!");
                                Console.ReadKey();

                            }
                        }

                        break;
                }
                WorkDays = СountOfWorkingDays(Wscore);

            }
        }
    }








    public class Shop
    {
        public virtual void Sell(float bal, float Exp)
        {

        }
    }
    public class JobShop : Shop
    {
        Job[] jobs = { new GarbageCollector(), new Security(), new Salesman(), new Manager(),
              new Director(), new CEO(), new SmallBusinessman(), new AverageBusinessman(), new BigBusinessman(),
              new Mer(), new Official(), new Deputy(), new VicePresident(), new President()};
        public static int IndexJob;
        public static bool isBuyJob = false;

        private void JobInfo(int index, float bal, float Exp)
        {
            Console.Clear();
            Console.WriteLine($"Название: {jobs[index].JobName} \n\nЗарплата: {jobs[index].Salary}\n\n" +
                $"Дает Опыта: {jobs[index].ExpSalary}\n\nЦена: {jobs[index].Price}\n\nТребуется Опыта: {jobs[index].ExpPrice}");
            Console.WriteLine();
            Console.WriteLine($"Ваш баланс: {bal} Ваш опыт: {Exp}\n");

        }
        private void JobSell(float balance, int index, float Exp)
        {
            if (balance >= jobs[index].Price & Exp >= jobs[index].ExpPrice)
            {
                IndexJob = index;
                isBuyJob = true;
            }
            else
            {
                Program.ChangeTextColor("Недостаточно средств или опыта");
                Console.ReadLine();
            }

        }
        public override void Sell(float bal, float Exp)
        {
            bool isWork = true;
            while (isWork)
            {
                Console.Clear();
                if (isBuyJob)
                {
                    Program.ChangeTextColor("Успешно", ConsoleColor.Green);

                    isWork = false;
                    Console.ReadKey();
                    break;
                }
                Console.WriteLine("№  Название  Цена");
                for (int i = 0; i < jobs.Length; i++)
                {
                    Console.WriteLine((i + 1) + ". " + jobs[i].JobName + " " + jobs[i].Price);
                }
                Console.WriteLine();
                Console.WriteLine("Если хотите подробнее узнать о работе введите его номер");
                Console.WriteLine();
                Program.ChangeTextColor("0-Выход", ConsoleColor.Red);
                Console.WriteLine();
                Console.Write("Ввод: ");
                int index = 0;
                while (int.TryParse(Console.ReadLine(), out index) == false)
                {
                    Console.WriteLine("Ошибка. Пожалуйста попробуйте снова.");
                }
                index -= 1;
                if (index == -1)
                {
                    Console.Clear();
                    Console.WriteLine();
                    isWork = false;
                    break;
                }
                else if (index >= 0 & index <= jobs.Length)
                {
                    JobInfo(index, bal, Exp);
                    Console.WriteLine("Нажмите Пробел чтобы вернутся\n\nНажмите Enter чтобы устроиться на работу");
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.Enter:
                            JobSell(bal, index, Exp);
                            continue;
                        default:
                            break;
                    }

                }

            }

        }

    }
    public class ItemShop : Shop
    {
        public static int IndexItem;
        public static bool isBuyItem = false;
        Item[] items = {new Bag(), new Wallet(), new Watch(), new ButtonTelephone(), new Suit(), new Apartment(), new Phone(),
            new Laptop(), new Moped(), new Garage(), new Assistant(), new Car(), new Computer(), new BigApartment(), new Yacht(),
            new Helicopter(), new Mansion()};
        private void ItemInfo(int index, float bal)
        {
            Console.Clear();
            Console.WriteLine($"Название: {items[index].ItemName} \n\n" +
                $"Цена: {items[index].Price}\n\nКоофицент: {items[index].Factor}");
            Console.WriteLine(new string('=', 25));
            Console.WriteLine($"Ваш баланс: {bal}\n");
        }
        private void ItemSell(float balance, int index)
        {
            if (balance >= items[index].Price)
            {
                IndexItem = index;
                isBuyItem = true;
            }
            else
            {
                Program.ChangeTextColor("Недостаточно средств или опыта");
                Console.ReadLine();
            }

        }

        public void Sell(float bal)
        {
            bool isWork = true;
            while (isWork)
            {
                Console.Clear();
                if (isBuyItem)
                {
                    Program.ChangeTextColor("Покупка Успешна!", ConsoleColor.Green);

                    isWork = false;
                    Console.ReadKey();
                    break;
                }
                Console.WriteLine("№  Название  Цена");
                for (int i = 0; i < items.Length; i++)
                {
                    Console.WriteLine((i + 1) + ". " + items[i].ItemName + " " + items[i].Price);
                }
                Console.WriteLine();
                Console.WriteLine("Если хотите подробнее узнать о товаре введите его номер");
                Console.WriteLine();
                Program.ChangeTextColor("0-Выход", ConsoleColor.Red);
                Console.WriteLine();
                Console.Write("Ввод: ");
                int index = 0;
                while (int.TryParse(Console.ReadLine(), out index) == false)
                {
                    Console.WriteLine("Ошибка. Пожалуйста попробуйте снова.");
                }
                index -= 1;
                if (index == -1)
                {
                    Console.Clear();
                    Console.WriteLine();
                    isWork = false;
                    break;
                }
                else if (index >= 0 & index <= items.Length)
                {
                    ItemInfo(index, bal);
                    Console.WriteLine("Нажмите Пробел чтобы вернутся\n\nНажмите Enter чтобы купить товар");
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.Enter:
                            ItemSell(bal, index);
                            continue;

                        default:
                            break;
                    }

                }

            }

        }
    }


}












