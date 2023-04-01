using System.Collections.Generic;
using System.Collections.Immutable;

namespace RestaurantMenuWeb.Data;

public  class Order : List<Dish>
{
    private static Order? instance;

    protected Order() : base() { }

    public static Order Instance => instance ??= new Order();


    public float Total => (float)Math.Round(this.Select(dish => dish.Price).Sum(), 2);

    public Dictionary<Dish, int> GetQuantityOfDishes()
    {
        if (Count <= 0)
            return new();

        Dictionary<Dish, int> dict = new();

        foreach (var dish in this)
        {
            if (dict.ContainsKey(dish))
            {
                dict[dish]++;
                continue;
            }
            dict.Add(dish, 1);
        }

        return dict;
    }


}