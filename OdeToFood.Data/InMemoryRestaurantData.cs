using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant{Id =1, Name="RAS 1", Location="Loc 1", Cuisine=CuisineType.Mexican},
                new Restaurant{Id =2, Name="RES 2", Location="Loc 2", Cuisine=CuisineType.Italian},
                new Restaurant{Id =3, Name="RIS 3", Location="Loc 3", Cuisine=CuisineType.Indian}
            };
        }
        public IEnumerable<Restaurant> GetRestaurantsByName(string name=null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.ToLower().StartsWith(name.ToLower())
                   orderby r.Name
                   select r;
        }

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
            if(restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;

                return restaurant;
            }
            return restaurant;
        }

        public int Commit()
        {
            return 0;
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            newRestaurant.Id = restaurants.Max(r => r.Id) + 1;
            restaurants.Add(newRestaurant);
            return newRestaurant;
        }

        public Restaurant Delete(int id)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == id);
            if(restaurant != null)
            {
                restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public int GetCountRestaurants()
        {
            return restaurants.Count;
        }
    }
}
