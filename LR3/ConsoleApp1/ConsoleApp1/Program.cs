using System;

struct Product
{
    public string Name;
    public int Price;
    public int Stock;

    public Product(string name, int price, int stock)
    {
        Name = name;
        Price = price;
        Stock = stock;
    }
}