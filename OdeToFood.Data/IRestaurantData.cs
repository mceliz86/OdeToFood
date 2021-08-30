using OdeToFood.Core;
using System.Collections.Generic;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetById(int id);
        Restaurant Update(Restaurant updatedRestaurant);
        int Commit();
        Restaurant Add(Restaurant newRestaurant);
        Restaurant Delete(int id);
        int GetCountRestaurants();
    }
}
