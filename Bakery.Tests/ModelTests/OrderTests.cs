using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Bakery.Models;

namespace Bakery.Tests
{
  [TestClass]
  public class OrderTests : IDisposable
  {

    public void Dispose()
    {
      Order.ClearAll();
    }
    
    [TestMethod]
    public void OrderConstructor_CreatesInstanceOfOrder_Order()
    {
      Order newOrder = new Order("Test Title", "Test Description", 130, "Test Date Placed", "Test Delivery Date");
      Assert.AreEqual(typeof(Order), newOrder.GetType());
    }

    [TestMethod]
    public void GetDescription_ReturnsDescription_String()
    {
      string title = "Weekly Thursday Order";
      string description = "6 Challahs";
      int price = 24;
      string datePlaced = "Friday, September 24, 2021";
      string deliveryDate = "Thursday, September 30, 2021";
      Order newOrder = new Order(title, description, price, datePlaced, deliveryDate);
      string result = newOrder.Description;
      Assert.AreEqual(description, result);
    }

    [TestMethod]
    public void SetDescription_SetDescription_String()
    {
      string title = "Weekly Thursday Order";
      string description = "6 Challahs";
      int price = 24;
      string datePlaced = "Friday, September 24, 2021";
      string deliveryDate = "Thursday, September 30, 2021";
      Order newOrder = new Order(title, description, price, datePlaced, deliveryDate);
      string updatedDescription = "6 challahs & 4 dozen rugelach";
      newOrder.Description = updatedDescription;
      string result = newOrder.Description;
      Assert.AreEqual(updatedDescription, result);
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyList_OrderList()
    {
      List<Order> newList = new List<Order> {};
      List<Order> result = Order.GetAll();
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsOrders_OrderList()
    {
      string title01 = "Weekly Thursday Order";
      string description01 = "6 challahs";
      int price01 = 24;
      string datePlaced01 = "Friday, September 24, 2021";
      string deliveryDate01 = "Thursday, September 30, 2021";
      string title02 = "One time Pesach order";
      string description02 = "100 coconut macaroons, 100 chocolate dipped coconut macaroons, 100 chocolate macaroons, 25 boxed matzah toffee";
      int price02 = 500;
      string datePlaced02 = "Monday, March 1, 2021";
      string deliveryDate02 = "Wednesday, March 24, 2021";
      Order newOrder1 = new Order(title01, description01, price01, datePlaced01, deliveryDate01);
      Order newOrder2 = new Order(title02, description02, price02, datePlaced02, deliveryDate02);
      List<Order> newList = new List<Order> { newOrder1, newOrder2 };
      List<Order> result = Order.GetAll();
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetId_OrdersInstantiateWithAnIdAndGetterReturns_Int()
    {
      string title = "Weekly Thursday Order";
      string description = "6 Challahs";
      int price = 24;
      string datePlaced = "Friday, September 24, 2021";
      string deliveryDate = "Thursday, September 30, 2021";
      Order newOrder = new Order(title, description, price, datePlaced, deliveryDate);
      int result = newOrder.Id;
      Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectOrder_Order()
    {
      string title01 = "Weekly Thursday Order";
      string description01 = "6 challahs";
      int price01 = 24;
      string datePlaced01 = "Friday, September 24, 2021";
      string deliveryDate01 = "Thursday, September 30, 2021";
      string title02 = "One time Pesach order";
      string description02 = "100 coconut macaroons, 100 chocolate dipped coconut macaroons, 100 chocolate macaroons, 25 boxed matzah toffee";
      int price02 = 500;
      string datePlaced02 = "Monday, March 1, 2021";
      string deliveryDate02 = "Wednesday, March 24, 2021";
      Order newOrder1 = new Order(title01, description01, price01, datePlaced01, deliveryDate01);
      Order newOrder2 = new Order(title02, description02, price02, datePlaced02, deliveryDate02);
      Order result = Order.Find(2);
      Assert.AreEqual(newOrder2, result);
    }
  }
}