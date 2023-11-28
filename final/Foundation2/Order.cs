using System;
using System.Collections.Generic;

public class Order
{
    private List<Product> products;
    private Customer customer;

    public Order(Customer customer)
    {
        this.customer = customer;
        products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        //Add a product to the order
        products.Add(product);
    }

    public decimal GetTotalPrice()
    {
        decimal totalPrice = 0;
        
        foreach (var product in products)
        {
            totalPrice += product.GetTotalPrice();
        }

        // Add shipping cost
        if (customer.IsUsaCustomer())
            totalPrice += 5;
        else
            totalPrice += 35;

        return totalPrice;
    }

    public string GetPackingLabel()
    {
        string label = "";
        
        foreach (var product in products)
        {
            label += $"Name: {product.Name}, Product ID: {product.ProductId}\n";
        }
        
        return label;
    }

    public string GetShippingLabel()
    {
        //Generate a shipping label with customer information
        return $"Customer: {customer.Name}\nAddress: {customer.GetAddressString()}";
    }
}