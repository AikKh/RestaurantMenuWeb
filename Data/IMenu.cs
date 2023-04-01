namespace RestaurantMenuWeb.Data;

public interface IMenu
{
    string? Name { get; init; }

    void AddDish(Dish dish);

    void RemoveDishAt(int index);

    TResult[] Select<TResult>(Func<Dish, TResult> func);
}
