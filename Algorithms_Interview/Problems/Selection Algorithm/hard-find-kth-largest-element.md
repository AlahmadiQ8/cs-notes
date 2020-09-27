## Problem

https://leetcode.com/problems/kth-largest-element-in-an-array/


Find the kth largest element in an unsorted array. Note that it is the kth
largest element in the sorted order, not the kth distinct element.

Examples:

```
Input: [3,2,1,5,6,4] and k = 2
Output: 5

Input: [3,2,3,1,2,4,5,5,6] and k = 4
Output: 4
```

**Note:** You may assume k is always valid, 1 ≤ k ≤ array's length.


# Technique

- Selection Algoriothm or DNF 

| Complexity | Big O                       |
| ---------- | --------------------------- |
| Time       | O(n)on average O(n^2) worst |
| Space      | O(n)                        |

```javascript
/**
 * @param {number[]} nums
 * @param {number} k
 * @return {number}
 */
function findKthLargest(nums, k) {
  
  return helper(nums, 0, nums.length - 1, nums.length - k);
};

function helper(arr, start, end, targetIndex) {
  if (end < start) return null

  const pivot = getRandomInt(start, end)
  const result = selectionAlgorithm(arr, start, end, pivot)

  if (result === targetIndex) return arr[result]
  if (result < targetIndex) return helper(arr, result + 1, end, targetIndex)
  return helper(arr, start, result - 1, targetIndex)
}

function selectionAlgorithm(arr, start, end, pivot) {
  swap(arr, start, pivot)
  let less = start
  for (let i = start + 1; i <= end; i++) {
    if (arr[i] <= arr[start]) 
      swap(arr, ++less, i)
  }
  swap(arr, start, less)
  return less
}


function getRandomInt(start, end) {
  return Math.floor(Math.random() * (end - start + 1)) + start
}


function swap(arr, i, j) {
  let temp = arr[i]
  arr[i] = arr[j]
  arr[j] = temp
}

const arr = () => [5, 6, 4, 7, 3, 8, 2, 9, 1]
expect(findKthLargest(arr(), 1)).to.eq(9) 
expect(findKthLargest(arr(), 2)).to.eq(8) 
expect(findKthLargest(arr(), 3)).to.eq(7) 
expect(findKthLargest(arr(), 4)).to.eq(6) 
expect(findKthLargest(arr(), 5)).to.eq(5) 
expect(findKthLargest(arr(), 6)).to.eq(4) 
expect(findKthLargest(arr(), 7)).to.eq(3) 
expect(findKthLargest(arr(), 8)).to.eq(2) 
expect(findKthLargest(arr(), 9)).to.eq(1) 
```


```csharp
public int FindKthLargest(int[] nums, int k)
{
    var rand = new Random();
    return FindKthLargestHelper(0, nums.Length - 1);

    int FindKthLargestHelper(int start, int end)
    {
        var randomIndex = rand.Next(start, end + 1);
        var pivotIndex = Parition(start, end, randomIndex);
        if (pivotIndex < k - 1) return FindKthLargestHelper(pivotIndex + 1, end);
        if (pivotIndex > k - 1) return FindKthLargestHelper(start, pivotIndex - 1);
        return nums[pivotIndex];
    }

    int Parition(int start, int end, int pivotIndex)
    {
        Swap(nums, start, pivotIndex);
        var less = start;
        for (var i = start + 1; i <= end; i++)
        {
            if (nums[i] >= nums[start]) Swap(nums, ++less, i);
        }

        Swap(nums, less, start);
        return less;
    }
}

public override void Test()
{
    FindKthLargest(new[] {3, 2, 1, 5, 6, 4}, 2).Should().Be(5);
}
```
