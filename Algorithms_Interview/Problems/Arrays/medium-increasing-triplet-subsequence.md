## Problem

https://leetcode.com/problems/increasing-triplet-subsequence/

```
Given an unsorted array return whether an increasing subsequence of length 3 exists or not in the array.

Formally the function should:

Return true if there exists i, j, k
such that arr[i] < arr[j] < arr[k] given 0 ≤ i < j < k ≤ n-1 else return false.
Note: Your algorithm should run in O(n) time complexity and O(1) space complexity.

Example 1:

Input: [1,2,3,4,5]
Output: true
Example 2:

Input: [5,4,3,2,1]
Output: false
```

## Solution I - Brute Force

| Complexity | Big O |
|------------|-------|
| Time       | O(N^2)  |
| Space      | O(1)  |

```csharp
public bool IncreasingTriplet(int[] nums) {
    if (nums.Length < 3) return false;
    
    var i = 0;
    var j = 1;
    var k = 2;
    while (i < nums.Length - 2) {
        if (j >= nums.Length - 1) {
            i++;
            j = i + 1;
            k = i + 2;
        } else if (k >= nums.Length) {
            j++; 
            k = j + 1;
        }else if (nums[i] >= nums[j]) {
            j++;
            k++;
        } else if (nums[j] >= nums[k]) {
            k++;
        } else return true;
    }
    
    return false;
}

// Recursive
public bool IncreasingTriplet(int[] nums) {
    if (nums.Length < 3) return false;

    return Helper(0, 1, 2);

    bool Helper(int index, int lo, int hi) {
        if (index >= nums.Length - 2) return false;

        if (lo >= nums.Length - 1) return Helper(index + 1, index + 2, index + 3);
        if (hi >= nums.Length) return Helper(index, lo + 1, lo + 2);

        if (nums[index] >= nums[lo]) return Helper(index, lo + 1, hi + 1);
        if (nums[lo] >= nums[hi]) return Helper(index, lo, hi + 1);

        return true;
    }
}
```



## Solution II - Optimized (Linear Scan)

```csharp
public bool IncreasingTriplet(int[] nums) {
    if (nums.Length < 3) return false;x
    
    var firstMin = int.MaxValue;
    var secondMin = int.MaxValue;
    
    foreach (var val in nums) {
        if (val <= firstMin) firstMin = val;
        else if (val <= secondMin) secondMin = val;
        else return true;
    }
    
    return false;
}
```


# DO BRUTE FORCE USING RECURSION
