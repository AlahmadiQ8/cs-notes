## Problem

Link: https://leetcode.com/problems/valid-palindrome-ii/description/

Given a non-empty string s, you may delete at most one character. Judge whether
you can make it a palindrome.

**Example 1:**

```
Input: "aba"
Output: True
```

**Example 2:**

```
Input: "abca"
Output: True
```

Explanation: You could delete the character 'c'.

**Note**:

The string will only contain lowercase characters a-z. The maximum length of the string is 50000.

## Solution

```javascript
function validPalindrome(s) {
  for (let i = 0; i < s.length >> 1; i++) {
    if (s[i] != s[s.length - 1 - i]) {
      const j = s.length - 1 - i
      return isPalindrome(s, i + 1, j) || isPalindrome(s, i, j - 1)
    }
  }
  return true
}

function isPalindrome(s, i, j) {
  while (i < j) {
    if (s[i] !== s[j]) return false
    i++
    j--
  }
  return true
}
```
