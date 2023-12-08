using System;
//2
class Program
{
    static void Main(string[] args)
    {

        Product product1 = new Product("Samsung Galaxy S23", "SM-GS23-2005136", 299.99, 1);
        Product product2 = new Product("Hi-chew(50 units)", "HC12563", 10, 1);
        Product product3 = new Product("Utah Flag", "UF24865", 20, 1);
        Address address1 = new Address("1532 Adam AVE", "Provo", "Utah", "USA");
        Customer customer1 = new Customer("Richard Thomas", address1);
        Order order1 = new Order(customer1);
        order1.addProduct(product1);
        order1.addProduct(product2);
        order1.addProduct(product3);
        Console.WriteLine("Order 1");
        Console.WriteLine(order1.getPackingLabel());
        Console.WriteLine(order1.getShippingLabel());
        Console.WriteLine($"\nTotal Price: ${order1.calculateTotalPrice()}");


        Product product4 = new Product("Play Station 5 Slim, 1 TB", "SONYPS5-156471TB", 499.99, 1);
        Product product5 = new Product("DualSense wireless Controller", "DSWC-SONYPS5-1532678", 69.00, 1);
        Address address2 = new Address("Central St", "Perez", "San Jose", "Costa Rica");
        Customer customer2 = new Customer("Owen Morales", address2);
        Order order2 = new Order(customer2);
        order2.addProduct(product4);
        order2.addProduct(product5);
        Console.WriteLine("\nOrder 2");
        Console.WriteLine(order2.getPackingLabel());
        Console.WriteLine(order2.getShippingLabel());
        Console.WriteLine($"\nTotal Price: ${order2.calculateTotalPrice()}");




    }
}