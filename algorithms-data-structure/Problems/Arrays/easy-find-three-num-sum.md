https://leetcode.com/problems/3sum/

Given an array nums of n integers, are there elements a, b, c in nums such that a + b + c = 0? Find all unique triplets in the array which gives the sum of zero.

**Note:**

The solution set must not contain duplicate triplets.

**Example:**

```
Given array nums = [-1, 0, 1, 2, -1, -4],

A solution set is:
[
  [-1, 0, 1],
  [-1, -1, 2]
]
```

## Technique

- Sliding Window - similar to finding two numbers equal to sum in sorted array 

## Solution 

```javascript
// Brute Force
function threeSum(nums) {
  nums.sort((a, b) => a - b)

  const result = []
  for (let i = 0; i < nums.length - 2; i++) {
    if (i == 0 || (i > 0 && nums[i] != nums[i - 1])) {
      let lo = i + 1
      let hi = nums.length - 1
      const sum = 0 - nums[i]

      while (lo < hi) {
        if (nums[lo] + nums[hi] == sum) {
          result.push([nums[i], nums[lo], nums[hi]])
          while (lo < hi && nums[lo] == nums[lo + 1]) lo++
          while (lo < hi && nums[hi] == nums[hi - 1]) hi--
          lo++
          hi--
        } else if (nums[lo] + nums[hi] < sum) lo++
        else hi--
      }
    }
  }
  return result
}
```

```csharp
public IList<IList<int>> ThreeSum(int[] nums)
{
    if (nums.Length < 3) return new List<IList<int>>();
    
    Array.Sort(nums);

    var result = new List<IList<int>>();
    for (var i = 0; i < nums.Length - 2; i++)
    {
        if (i != 0 && nums[i] == nums[i - 1]) continue;

        var lo = i + 1;
        var hi = nums.Length - 1;
        var sum = 0 - nums[i];
        while (lo < hi)
        {
            if (nums[lo] + nums[hi] < sum) lo++;
            else if (nums[lo] + nums[hi] > sum) hi--;
            else
            {
                result.Add(new List<int> {nums[i], nums[lo], nums[hi]});
                while (lo < hi && nums[lo] == nums[lo + 1]) lo++;
                while (lo < hi && nums[hi] == nums[hi - 1]) hi--;
                lo++;
                hi--;
            }
        }
    }

    return result;
}
```
