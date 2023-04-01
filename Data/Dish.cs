using System.Diagnostics.CodeAnalysis;

namespace RestaurantMenuWeb.Data;

public readonly struct Dish
{
    public string Name { get; init; }
    public float Price { get; init; }
    public string Description { get; init; }

    public static bool operator ==(Dish left, Dish right) =>
        left.Equals(right);

    public static bool operator !=(Dish left, Dish right) =>
        !(left == right);
}
