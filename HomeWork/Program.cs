using System;
using System.Collections.Concurrent;
namespace HomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            ComputerClub computerClub = new ComputerClub();
            computerClub.Work();


        }
        public static void ChangeTextColor(string text, ConsoleColor color = ConsoleColor.Red, bool isEnter = true, int BeforeY = 0, int AfterY = 0)
        {
            ConsoleColor fcolor = Console.ForegroundColor;
            if (BeforeY == 0 & AfterY == 0)
            {

                Console.ForegroundColor = color;
                if (isEnter)
                    Console.WriteLine(text);
                else
                    Console.Write(text);


                Console.ForegroundColor = fcolor;
            }
            else
            {
                Console.SetCursorPosition(0, BeforeY);
                Console.ForegroundColor = color;
                if (isEnter)
                    Console.WriteLine(text);
                else
                    Console.Write(text); Console.ForegroundColor = fcolor;
                Console.SetCursorPosition(0, AfterY);
            }

        }
        public static void ChangeBackGroundColor(bool isEnter, string text, ConsoleColor bcolor = ConsoleColor.Red)
        {
            ConsoleColor originalBackColor = Console.BackgroundColor;
            Console.BackgroundColor = bcolor;
            if (isEnter)
                Console.Write(text);
            else
                Console.WriteLine(text);

            Console.BackgroundColor = originalBackColor;
        }
    }
    class ComputerClub
    {
        public ComputerClub()
        {
            balance = 0;
            _numberOfComputers = 11;
            for (int i = 1; i < _numberOfComputers; i++)
            {
                _computers.Add(new Computer());
            }
        }
        private List<Computer> _computers = new List<Computer>();
        private List<Client> _clients = new List<Client>();
        private int _numberOfComputers;
        public int balance { get; private set; }
        public void Work()
        {
            int numberOfClient = 0;
            bool isWork = true;
            while (isWork)
            {
                Console.Clear();
                Console.WriteLine("Добро Пожаловать в симулятор компьютерного клуба!\n\n1 - Стойка Администратора" +
                    "\n\n2 - Магазин Компьютеров");
                Program.ChangeTextColor("\n0 - Выход");
                Console.Write("\nВвод: ");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        bool admWork = true;
                        while (admWork)
                        {
                            Console.Clear();
                            Random rand = new Random();
                            _clients.Add(new Client(rand.Next(10, 31)));
                            Console.WriteLine($"Ваш баланс: {balance}\n\nУ вас новый клиент! Он хочет занять компьтер на {_clients[numberOfClient].DesiredMinutes} минут");
                            for (int i = 0; i < _computers.Count; i++)
                            {
                                if (_computers[i].isTaken)
                                    Program.ChangeTextColor(i + 1 + ". ", isEnter: false);
                                else
                                    Program.ChangeTextColor(i + 1 + ". ", ConsoleColor.Green, isEnter: false);

                                _computers[i].ShowInfo();
                            }
                            int userInput;
                            Program.ChangeTextColor("\n0-Выход\n");
                            Console.WriteLine("Выберите номер компьютера для своего клиента\n");
                            Console.Write("Введите номер компьютера: ");
                            if (int.TryParse(Console.ReadLine(), out userInput))
                            {
                                if (userInput == 0)
                                    admWork = false;

                                if (userInput-- <= _computers.Count && userInput >= 0)
                                {
                                    if (_computers[userInput].isTaken == false)
                                    {
                                        _computers[userInput].BecomeTaken(_clients[numberOfClient]);
                                        balance += _computers[userInput].PricePerMinute * _clients[numberOfClient].DesiredMinutes;
                                    }
                                    else
                                    {
                                        Program.ChangeTextColor("\nВы попытались посадить клиента за уже занятый компьютер он разозлился и ушел");
                                        Console.ReadKey();
                                    }


                                }
                            }
                            else
                            {
                                Program.ChangeTextColor("\nНеверный ввод. Повторите снова.");
                                Console.ReadKey();
                            }

                            numberOfClient++;
                            for (int i = 0; i < _computers.Count; i++)
                                _computers[i].SpendOneMinute();

                        }
                        break;
                    case ConsoleKey.D2:
                        bool ShopIsWork = true;
                        while (ShopIsWork)
                        {
                            Console.Clear();
                            Console.WriteLine("Вас приветствует магазин компьютеров!\nВыберите номер компьютера который хотели бы улучшить");
                            for (int i = 0; i < _computers.Count; i++)
                                Console.WriteLine($"{i + 1}. Уровень Компьютера: {_computers[i].PricePerMinute / 10}");

                            Program.ChangeTextColor("\n0-Выход");
                            Console.Write("\nВвод: ");
                            int computerToUpdate;
                            if (int.TryParse(Console.ReadLine(), out computerToUpdate))
                            {
                                if (computerToUpdate == 0)
                                    ShopIsWork = false;

                                if (computerToUpdate-- <= _computers.Count && computerToUpdate >= 0)
                                {
                                    int LvlOfComputer = _computers[computerToUpdate].PricePerMinute / 10;
                                    int PriceToUpdate = LvlOfComputer * 1000;
                                    Console.Clear();
                                    Console.WriteLine($"Улучшение компьютера будет стоить: {PriceToUpdate}\n\nВаш баланс: {balance}");

                                    Console.WriteLine("\nНажмите Enter чтобы купить улучшение, нажмите Пробел чтобы вернуться в " +
                                        "Mеню Магазина");
                                    switch (Console.ReadKey().Key)
                                    {
                                        case ConsoleKey.Enter:
                                            Console.Clear();
                                            if (balance >= PriceToUpdate)
                                            {
                                                balance -= PriceToUpdate;
                                                _computers[computerToUpdate].ComputerUpdate(432821);

                                                Program.ChangeTextColor("Покупка Успешна!", ConsoleColor.Green);
                                                Console.ReadKey();
                                            }
                                            else
                                            {
                                                Program.ChangeTextColor("Ошибка! На вашем счету нехватает средств!");
                                                Console.ReadKey();
                                            }
                                            break;


                                    }
                                }
                            }
                            else
                            {
                                Program.ChangeTextColor("\nНеверный ввод. Повторите снова.");
                                Console.ReadKey();
                            }
                        }
                        break;
                    case ConsoleKey.D0:
                        isWork = false;
                        break;

                }
            }
        }

    }
    class Computer
    {

        public Computer()
        {
            ComputerLvl = 1;
            PricePerMinute = 10;
            _minutesRemaining = 0;
        }
        private Client _client;
        public int ComputerLvl { get; private set; }
        private int _minutesRemaining;
        public bool isTaken { get { return _minutesRemaining > 0; } private set { isTaken = value; } }
        public int PricePerMinute { get; private set; }

        public void ComputerUpdate(int password)
        {
            if (password == 432821)
            {
                ComputerLvl++;
                PricePerMinute = ComputerLvl * 10;
            }
        }
        public void ShowInfo()
        {
            if (isTaken)
                Console.WriteLine($"Компьютер занят осталось {_minutesRemaining}");
            else
                Console.WriteLine($"Компьютер свободен Цена: {PricePerMinute}");


        }
        public void SpendOneMinute()
        {
            _minutesRemaining--;
        }
        public void BecomeTaken(Client client)
        {
            _client = client;
            _minutesRemaining = _client.DesiredMinutes;
        }
        public void BecomeEmpty()
        {
            _client = null;
        }
    }
    class Client
    {
        public int DesiredMinutes { get; private set; }
        public Client(int desiredMinutes)
        {
            DesiredMinutes = desiredMinutes;
        }
    }

}
