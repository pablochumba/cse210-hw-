using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Address usaAddress = new Address("742 Evergreen Terrace", "Springfield", "IL", "USA");
        Address internationalAddress = new Address("221B Baker Street", "London", "Greater London", "United Kingdom");

        Customer customerOne = new Customer("Homer Simpson", usaAddress);
        Customer customerTwo = new Customer("Sherlock Holmes", internationalAddress);

        Order orderOne = new Order(customerOne);
        orderOne.AddProduct(new Product("Wireless Mouse", "WM-101", 24.99m, 2));
        orderOne.AddProduct(new Product("Mechanical Keyboard", "MK-205", 79.50m, 1));
        orderOne.AddProduct(new Product("USB-C Hub", "UH-330", 34.75m, 1));

        Order orderTwo = new Order(customerTwo);
        orderTwo.AddProduct(new Product("Notebook Set", "NS-410", 12.25m, 3));
        orderTwo.AddProduct(new Product("Desk Lamp", "DL-515", 46.80m, 1));

        List<Order> orders = new List<Order> { orderOne, orderTwo };

        int orderNumber = 1;
        foreach (Order order in orders)
        {
            Console.WriteLine($"Order {orderNumber}");
            Console.WriteLine("Packing Label:");
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine();
            Console.WriteLine("Shipping Label:");
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine();
            Console.WriteLine($"Total Price: ${order.CalculateTotalCost():0.00}");
            Console.WriteLine(new string('-', 40));
            Console.WriteLine();
            orderNumber++;
        }
    }
}
