// See https://aka.ms/new-console-template for more information







public class Product
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public float Price { get; set; }
    public List<Order> Orders { get; set; }
}
