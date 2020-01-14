using DutchTreat.Data.Entities;
using System.Collections.Generic;

namespace DutchTreat.Data
{
    public interface IDutchRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByCategory(string category);
        bool SaveAll();
        IEnumerable<Order> GetAllOrders(bool includeItems);
        Order GetOrderById(string username, int id);
        IEnumerable<Order> GetAllOrdersByUser(string username, bool includeItems);
        void AddEntity(object model);
        
    }
}