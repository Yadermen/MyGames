using System;



namespace Items
{
    public class Item
    {
      
    
        
        public Item(string itemName, int itemPrice, float factor)
        {
            ItemName = itemName;
            ItemPrice = itemPrice;
            Factor = factor;
        }
        public string ItemName { get; private set; }
        public int ItemPrice { get; private set; }
        public float Factor { get; private set; }
    }
}

