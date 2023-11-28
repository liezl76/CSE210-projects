using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        // Create addresses
        Address usaAddress = new Address("678 Main St", "Cityville", "CA", "USA");
        Address nonUsaAddress = new Address("1st St", "Iloilo City", "IL", "Philippines");

        // Create customers
        Customer usaCustomer = new Customer("Miguel Marquez", usaAddress);
        Customer nonUsaCustomer = new Customer("Juan Alonzo", nonUsaAddress);

        // Create products
        Product product1 = new Product("Laptop", "P001", 800, 2);
        Product product2 = new Product("Printer", "P002", 150, 1);
        Product product3 = new Product("Mouse", "P003", 20, 3);

        // Create orders
        Order order1 = new Order(usaCustomer);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Order order2 = new Order(nonUsaCustomer);
        order2.AddProduct(product2);
        order2.AddProduct(product3);

        // Display packing label, shipping label, and total price for each order
        Console.WriteLine("Order 1:");
        DisplayOrderDetails(order1);

        Console.WriteLine("\nOrder 2:");
        DisplayOrderDetails(order2);
    }

    static void DisplayOrderDetails(Order order)
    {
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order.GetPackingLabel());

        Console.WriteLine("\nShipping Label:");
        Console.WriteLine(order.GetShippingLabel());

        Console.WriteLine($"\nTotal Price: ${order.GetTotalPrice()}\n");
    }
}

public class Order
{
    private List<Product> products;
    private Customer customer;

    public Order(Customer customer)
    {
        this.customer = customer;
        this.products = new List<Product>();
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

public class Customer
{
    private string _name;
    private Address _address;

    public Customer(string name, Address address)
    {
        this._name = name;
        this._address = address;
    }

    public bool IsUsaCustomer()
    {
        return _address.IsUsaAddress();
    }

    public string Name { get { return _name; } }

    public string GetAddressString()
    {
        //Get a formatted string representation of the customer's address
        return _address.ToString();
    }
}

public class Address
{
    private string _streetAddress;
    private string _city;
    private string _state;
    private string _country;

    public Address(string streetAddress, string city, string state, string country)
    {
        this._streetAddress = streetAddress;
        this._city = city;
        this._state = state;
        this._country = country;
    }

    public bool IsUsaAddress()
    {
        // Check if the address is in the USA
        return _country == "USA";
    }

    public override string ToString()
    {
        // Get a formatted string representation of the address
        return $"{_streetAddress}, {_city}, {_state}, {_country}";
    }
}