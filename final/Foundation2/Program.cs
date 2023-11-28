using System;

class Program
{
    static void Main(string[] args)
    {
        //Create addresses
        Address usaAddress = new Address("678 Main St", "Cityville", "CA", "USA");
        Address nonUsaAddress = new Address("1st St", "Iloilo City", "IL", "Philippines");

        //Create customers
        Customer usaCustomer = new Customer("Miguel Marquez", usaAddress);
        Customer nonUsaCustomer = new Customer("Juan Alonzo", nonUsaAddress);

        //Create products
        Product product1 = new Product("Laptop", "P001", 800, 2);
        Product product2 = new Product("Desktop", "P002", 300, 1);
        Product product3 = new Product("Keyboard", "P003", 30, 3);

        //Create orders
        Order order1 = new Order(usaCustomer);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Order order2 = new Order(nonUsaCustomer);
        order2.AddProduct(product2);
        order2.AddProduct(product3);

        //Display packing label, shipping label, and total price for each order
        Console.WriteLine("Order 1:");
        DisplayOrderDetails(order1);

        Console.WriteLine("\nOrder 2:");
        DisplayOrderDetails(order2);
    }
    public static void DisplayOrderDetails(Order order)
    {
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order.GetPackingLabel());

        Console.WriteLine("\nShipping Label:");
        Console.WriteLine(order.GetShippingLabel());

        Console.WriteLine($"\nTotal Price: ${order.GetTotalPrice()}\n");
    }
}