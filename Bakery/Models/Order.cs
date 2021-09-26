using System.Collections.Generic;

namespace Bakery.Models
{
  public class Order
  {
    public string Title { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public string DatePlaced { get; set; }
    public string DeliveryDate { get; set; }
    public int Id { get; }
    private static List<Order> _instances = new List<Order> {};

    public Order(string title, string description, int price, string datePlaced, string deliveryDate)
    {
      Title = title;
      Description = description;
      Price = price;
      DatePlaced = datePlaced;
      DeliveryDate = deliveryDate;
      _instances.Add(this);
      Id = _instances.Count;
    }

    public static List<Order> GetAll()
    {
      return _instances;
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }

    public static Order Find(int searchId)
    {
      return _instances[searchId-1];
    }
  }
}