
## Problem

```
You​ ​are​ ​given​ ​stock​ ​prices​ ​and​ ​the​ ​corresponding​ ​day​
​of​ ​each​ ​stock​ ​price.​ ​For​ ​example:

(32,​ ​1),​ ​(45,​ ​1),​ ​(37,2),​ ​(42,3)..

Here​ ​32​ ​is​ ​the​ ​price​ ​and​ ​1​ ​is​ ​the​ ​day​ ​of​ ​the​
​price. Say​ ​you​ ​are​ ​given​ ​these​ ​prices​ ​as​ ​an​ ​input​ ​stream.​ ​You​ ​should​ ​provide​ ​a​ ​function​ ​for

The​ ​user​ ​to​ ​input​ ​a​ ​stock​ ​price​ ​and​ ​day.​ ​Your​
​system​ ​should​ ​be​ ​able​ ​to​ ​tell the​ ​maximum​ ​stock​ ​price​ ​in​ ​the​ ​last​ ​3​ ​days.
```

## Notes

- Calculating the max is O(n)
- We could improve it to O(1)

## Solution

```csharp
var stock = new StockPriceWithTime(3);
stock.AddPrice(30, 1);
Console.WriteLine(stock.Max()); // 30
stock.AddPrice(40, 3);
Console.WriteLine(stock.Max()); // 40
stock.AddPrice(25, 6);
Console.WriteLine(stock.Max()); // 25
stock.AddPrice(50, 7);
Console.WriteLine(stock.Max()); // 50

interface IStockPriceWithTime
{
    void AddPrice(int price, int day);

    int Max();
}

class StockPriceWithTime : IStockPriceWithTime
{
    private readonly LinkedList<(int price, int day)> _queue = new();
    private readonly int _window;

    public StockPriceWithTime(int window)
    {
        _window = window;
    }

    public void AddPrice(int price, int day)
    {
        var lastDay = day - _window + 1;
        while (_queue.Count > 0 && _queue.First?.Value.day < lastDay)
            _queue.RemoveFirst();

        _queue.AddLast((price, day));
    }

    public int Max()
    {
        return _queue.Select(i => i.price).Max();
    }
}
```
