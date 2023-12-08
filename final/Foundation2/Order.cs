public class Order
{
    private List<Product> products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        products = new List<Product>();
    }

    public void addProduct(Product product)
    {
        products.Add(product);
    }

    public double calculateTotalPrice()
    {
        double totalPrice = 0;
        foreach (var product in products)
        {
            totalPrice += product.calculatePrice();
        }
        totalPrice += _customer.getShippingCost();

        return totalPrice;
    }

    public string getPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (var product in products)
        {
            label += $"{product.getName()} ({product.getProductId()})\n";
        }
        return label;
    }

    public string getShippingLabel()
    {
        return $"Shipping Label:\n{_customer.getName()}\n{_customer.getAddress()}";
    }

}