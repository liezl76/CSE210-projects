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
    private string name;
    private string productId;
    private decimal price;
    private int quantity;

    public Product(string name, string productId, decimal price, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.price = price;
        this.quantity = quantity;
    }

    public decimal GetTotalPrice()
    {
        //Calculate the total price for a specific product
        return price * quantity;
    }

    public string Name { get { return name; } }
    public string ProductId { get { return productId; } }
}

public class Customer
{
    private string name;
    private Address address;

    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    public bool IsUsaCustomer()
    {
        return address.IsUsaAddress();
    }

    public string Name { get { return name; } }

    public string GetAddressString()
    {
        //Get a formatted string representation of the customer's address
        return address.ToString();
    }
}

public class Address
{
    private string streetAddress;
    private string city;
    private string state;
    private string country;

    public Address(string streetAddress, string city, string state, string country)
    {
        this.streetAddress = streetAddress;
        this.city = city;
        this.state = state;
        this.country = country;
    }

    public bool IsUsaAddress()
    {
        // Check if the address is in the USA
        return country == "USA";
    }

    public override string ToString()
    {
        // Get a formatted string representation of the address
        return $"{streetAddress}, {city}, {state}, {country}";
    }
}