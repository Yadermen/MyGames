using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Works
{
    public class Job
    {
        protected string jobName;
        protected float salary;
        protected float expSalary;
        protected float price;
        protected float expPrice;
        
        public string JobName { get { return jobName; } }
        public float Salary { get { return salary; } }
        public float ExpSalary { get { return expSalary; } }
        public float Price { get { return price; } }
        public float ExpPrice { get { return expPrice; } }
        

            
            
        

       

    }

    public class GarbageCollector : Job
    {
        Random rand = new Random();
        public GarbageCollector()
        {
            jobName = "Сборщик мусора";
            salary = 10;
            expSalary = rand.Next(1, 4);
            price = 0;
            expPrice = 0;
        }
    }
    public class Security : Job
    {
        Random rand = new Random();
        public Security()
        {
            jobName = "Охраник";
            salary = 20;
            expSalary = rand.Next(2, 5);
            price = 40;
            expPrice = 10;
        }

    }
    public class Salesman : Job
    {
        Random rand = new Random();
        public Salesman()
        {
            jobName = "Продавец-консультант";
            salary = 40;
            expSalary = rand.Next(4, 7);
            price = 80;
            expPrice = 15;
        }
    }
    public class Manager : Job
    {
        Random rand = new Random();
        public Manager()
        {
            jobName = "Менеджер";
            salary = 80;
            expSalary = rand.Next(6, 9);
            price = 160;
            expPrice = 30;
        }
    }
    public class Director : Job
    {
        Random rand = new Random();
        public Director()
        {
            jobName = "Директор магазина";
            salary = 160;
            expSalary = rand.Next(8, 11);
            price = 320;
            expPrice = 45;
        }
    }
    public class CEO : Job
    {
        Random rand = new Random();
        public CEO()
        {
            jobName = "Генеральный директор";
            salary = 320;
            expSalary = rand.Next(10, 13);
            price = 640;
            expPrice = 65;
        }
    }
    public class SmallBusinessman : Job
    {
        Random rand = new Random();
        public SmallBusinessman()
        {
            jobName = "Малый бизнесмен";
            salary = 640;
            expSalary = rand.Next(12, 15);
            price = 1280;
            expPrice = 90;
        }
    }
    public class AverageBusinessman : Job
    {
        Random rand = new Random();
        public AverageBusinessman()
        {
            jobName = "Средний бизнесмен";
            salary = 10;
            expSalary = rand.Next(14, 17);
            price = 2560;
            expPrice = 120;
        }
    }
    public class BigBusinessman : Job
    {
        Random rand = new Random();
        public BigBusinessman()
        {
            jobName = "Крупный бизнесмен";
            salary = 2560;
            expSalary = rand.Next(16, 19);
            price = 5120;
            expPrice = 130;
        }
    }
    public class Mer : Job
    {
        Random rand = new Random();
        public Mer()
        {
            jobName = "Мер";
            salary = 5120;
            expSalary = rand.Next(18, 21);
            price = 10240;
            expPrice = 150;
        }
    }
    public class Official : Job
    {
        Random rand = new Random();
        public Official()
        {
            jobName = "Чиновник";
            salary = 10240;
            expSalary = rand.Next(20, 23);
            price = 20480;
            expPrice = 170;
        }
    }
    public class Deputy : Job
    {
        Random rand = new Random();
        public Deputy()
        {
            jobName = "Депутат";
            salary = 20480;
            expSalary = rand.Next(22, 25);
            price = 40960;
            expPrice = 200;
        }
    }
    public class VicePresident : Job
    {
        Random rand = new Random();
        public VicePresident()
        {
            jobName = "Вице-Президент";
            salary = 40960;
            expSalary = rand.Next(24, 26);
            price = 81920;
            expPrice = 250;
        }
    }
    public class President : Job
    {
        Random rand = new Random();
        public President()
        {
            jobName = "Призедент";
            salary = 81920;
            expSalary = rand.Next(1, 4);
            price = 163840;
            expPrice = 500;
        }
    }

}
