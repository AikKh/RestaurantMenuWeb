using System.Text.Json;
using System.Diagnostics;
using System.Collections;

namespace RestaurantMenuWeb.Data;

public sealed class Menu : IMenu, IEnumerable<Dish>
{
    private readonly List<Dish> _dishes;

    public Menu(string? name = null)
    {
        Name = name;

        _dishes = new();
        if (name is not null)
            _dishes = GetBaseMenu(name);
    }

    public string? Name { get; init; }

    #region Add, Get, Delete

    public void AddDish(Dish dish) =>
        _dishes.Add(dish);

    public void RemoveDishAt(int index) =>
        _dishes.RemoveAt(index);

    public TResult[] Select<TResult>(Func<Dish, TResult> func) =>
        _dishes.Select(func).ToArray();

    #endregion

    private static List<Dish> GetBaseMenu(string menuName)
    {
        using StreamReader r = new($"MenusJson\\{menuName}.json");
        string json = r.ReadToEnd();

        return JsonSerializer.Deserialize<List<Dish>>(json) ?? new();
    }

    public override string ToString()
    {
        string text = $"Menu:\n";

        foreach (Dish dish in _dishes)
        {
            text += $"\t{dish.Name} - {dish.Price}";
            if (dish.Description.Length > 0)
                text += $"\n\t{dish.Description}\n";
            text += "\n";
        }
        return text;
    }

    public IEnumerator<Dish> GetEnumerator()
    {
        foreach (Dish dish in _dishes)
            yield return dish;
    }

    IEnumerator IEnumerable.GetEnumerator() =>
        GetEnumerator();
}
