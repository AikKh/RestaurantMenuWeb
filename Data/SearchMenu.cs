namespace RestaurantMenuWeb.Data;

public class SearchMenu
{
    private readonly List<string> _dishes;

    public SearchMenu(Menu menu) =>
        _dishes = menu.Select(x => x.Name).ToList();

    public bool IsActive { get; set; } = false;

    public string[] Search(string input) =>
        _dishes.Where(name => name[..input.Length] == input).ToArray();
}
