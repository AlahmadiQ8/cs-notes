# Closest Element to X in Sorted Array

Given Sorted array, find the target, if not found, find the closest.

## Techniques

- Record and Move on

```csharp
public int FindClosestElement(double[] arr, double target) {
    if (arr == null || arr.Length == 0) return -1;

    var low = 0;
    var high = arr.Length - 1;
    var result = -1;
    var minDiff = double.MaxValue;

    while (low <= high) {
        var mid = low + (high - low) / 2;
        var currDiff = Math.Abs(arr[mid] - target);
        if (currDiff < minDiff) {
            result = mid;
            minDiff = currDiff;
        }
        if (arr[mid] > target) high = mid - 1;
        else if (arr[mid] < target) low = mid + 1;
    }

    return result;
}

public override void Test()
{
    FindClosestElement(new double[] {1, 2, 4, 5, 7, 8, 9}, 2.5).Should().Be(1);
}
```
