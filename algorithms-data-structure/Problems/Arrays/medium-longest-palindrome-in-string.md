## Problem 

```
Find the longest palindrome in a string. Example

"abbababaab" ==> "babab"
```

## Technique

- Go through every index and in between and expand and compare to
  longest 

| Complexity | Big O  |
| ---------- | ------ |
| Time       | O(n^2) |
| Space      | O(1)   |

## Solution 

```javascript
function longestPalindrome(str) {
  if (!str || str.length <= 1) return str
  
  let longest = "" 
  for (let i = 0; i < str.length; i++) {
    const palindromeAtI = getPalindrome(str, i, false)
    if (palindromeAtI.length > longest.length) {
      longest = palindromeAtI
    }
    const palindromeAfterI = getPalindrome(str, i, true)
    if (palindromeAfterI.length > longest.length) {
      longest = palindromeAfterI
    }
  }

  return longest
}

function getPalindrome(str, i, isMiddle) {
  if (i == 0 && !isMiddle) return str[0]
  if (i == str.length - 1) return str[str.length - 1]

  let ans = isMiddle ? "" : str[i]
  let left = isMiddle ? i : i - 1
  let right = i + 1

  while (left >= 0 && right < str.length && str[left] == str[right]) {
    ans = str[left] + ans + str[right]
    left--
    right++
  }
  return ans
}

longestPalindrome('cbbd') //?
```
