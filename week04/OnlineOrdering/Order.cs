using System.Collections.Generic;
using System.Text;

class Order
{
    private readonly List<Product> _products = new List<Product>();
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
    }

    public Customer GetCustomer()
    {
        return _customer;
    }

    public void SetCustomer(Customer customer)
    {
        _customer = customer;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public decimal CalculateTotalCost()
    {
        decimal productTotal = 0m;

        foreach (Product product in _products)
        {
            productTotal += product.CalculateTotalCost();
        }

        decimal shippingCost = _customer.LivesInUSA() ? 5m : 35m;
        return productTotal + shippingCost;
    }

    public string GetPackingLabel()
    {
        StringBuilder builder = new StringBuilder();

        foreach (Product product in _products)
        {
            builder.AppendLine($"{product.GetName()} ({product.GetProductId()})");
        }

        return builder.ToString().TrimEnd();
    }

    public string GetShippingLabel()
    {
        return $"{_customer.GetName()}\n{_customer.GetAddress().GetFormattedAddress()}";
    }
}
