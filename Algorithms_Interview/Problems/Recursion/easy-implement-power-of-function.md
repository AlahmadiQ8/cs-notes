## Problem

```
Power Function: Implement a function to calculate X^N. Both X and N can be positiveor negative. You can assume that overflow doesn't happen.

Must be in O(log(N))​ time
```

## Notes

- 

## Technique

| Complexity | Big O |
|------------|-------|
| Time       | O(log(n))  |
<!-- | Space      | O( )  | -->

## Solution

```csharp
public double Pow(int x, int n) {
    if (x == 0 && n < 0) throw new ArgumentException();

    var result = PositivePow(x, n);

    if (n < 0) result = 1 / result;
    if (x < 0 && n % 2 != 0) result *= -1;

    return result;
}

public double PositivePow(int x, int n) {
    if (n == 0) return 1;
    if (n == 1) return x;

    var result = PositivePow(x, n / 2) * PositivePow(x, n / 2);
    if (n % 2 == 0) return result;
    return x * result;
}

public override void Test()
{
    Pow(2, 5).Should().Be(32);
}
```
