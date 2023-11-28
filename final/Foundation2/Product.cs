using System;
using System.Collections.Generic;

public class Product
{
    private string _name;
    private string _productId;
    private decimal _price;
    private int _quantity;

    public Product(string name, string productId, decimal price, int quantity)
    {
        this._name = name;
        this._productId = productId;
        this._price = price;
        this._quantity = quantity;
    }

    public decimal GetTotalPrice()
    {
        //Calculate the total price for a specific product
        return _price * _quantity;
    }

    public string Name { get { return _name; } }
    public string ProductId { get { return _productId; } }
}