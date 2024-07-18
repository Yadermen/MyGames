using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Works;

namespace Items
{
    public class Item
    {

       
        protected string itemName;
        protected float price;
        protected float factor;
        public string ItemName { get { return itemName; } }
        public float Price { get { return price; } }
        public float Factor { get { return factor; } }
    }
    public class Nothing : Item {
        public Nothing()
        {
            itemName = "Нету";
        }
        }


    public class Bag : Item
    {      
        public Bag()
        {
            itemName = "Сумка";
            price = 100;
            factor = 1.1f;
        }
    }

    public class Wallet : Item
    {
        public Wallet()
        {
            itemName = "Кошелек";
            price = 500;
            factor = 1.2f;
        }
    }
    public class Watch : Item
    {
        public Watch()
        {
            itemName = "Часы";
            price = 2500;
            factor = 1.3f;
        }
    }
    public class ButtonTelephone : Item
    {
        public ButtonTelephone()
        {
            itemName = "Кнопочный телефон";
            price = 5000;
            factor = 1.4f;
        }
    }
    public class Suit : Item
    {
        public Suit()
        {
            itemName = "Деловой костюм";
            price = 15000;
            factor = 1.5f;
        }
    }
    public class Apartment : Item
    {
        public Apartment()
        {
            itemName = "Студия на окраине";
            price = 20000;
            factor = 1.6f;
        }
    }
    public class Phone : Item
    {
        public Phone()
        {
            itemName = "Смартфон";
            price = 25000;
            factor = 1.7f;
        }
    }
    public class Laptop : Item
    {
        public Laptop()
        {
            itemName = "Ноутбук";
            price = 35000;
            factor = 1.8f;
        }
    }
    public class Moped : Item
    {
        public Moped()
        {
            itemName = "Мопед";
            price = 40000;
            factor = 1.9f;
        }
    }
    public class Garage : Item
    {
        public Garage()
        {
            itemName = "Гараж";
            price = 50000;
            factor = 2.0f;
        }
    }
    public class Assistant : Item
    {
        public Assistant()
        {
            itemName = "Личный Помощник";
            price = 75000;
            factor = 2.1f;
        }
    }
    public class Car : Item
    {
        public Car()
        {
            itemName = "Машина";
            price = 100000;
            factor = 2.2f;
        }
    }
    public class Computer : Item
    {
        public Computer()
        {
            itemName = "Компьютер";
            price = 150000;
            factor = 2.3f;
        }
    }
    public class BigApartment : Item
    {
        public BigApartment()
        {
            itemName = "Квартира в центре";
            price = 250000;
            factor = 2.4f;
        }
    }
    public class Yacht : Item
    {
        public Yacht()
        {
            itemName = "Яхта";
            price = 500000;
            factor = 2.5f;
        }
    }
    public class Helicopter : Item
    {
        public Helicopter()
        {
            itemName = "Вертолет";
            price = 1000000;
            factor = 2.6f;
        }
    }
     public class Mansion : Item
    {
        public Mansion()
        {
            itemName = "Особняк";
            price = 10000000;
            factor = 10f;
        }
    }
}









