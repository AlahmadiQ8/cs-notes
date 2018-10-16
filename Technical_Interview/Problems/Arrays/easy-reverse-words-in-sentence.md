## Problem 

```
Reverse words in a sentence
```

## Technique

- Reverse entire string
- then reverse each word

## Solution 

```typescript
function reverseWords(str: Array<string>) {
  if (!str || str.length == 0) return
  reverseArr(str)

  let i = 0
  while (i < str.length) {
    if (str[i] == ' ') {
      i++
    } else {
      let j = i
      while (j < str.length && str[j] !== ' ') {
        j++
      }
      reverseArr(str, i, j)
      i = j + 1
    }
  }
}

function reverseArr<T>(arr: Array<T>, i?: number, j?: number) {
  if (!arr || arr.length <= 1) return

  let left = i,
    right = j - 1
  if (left == null) {
    left = 0
    right = arr.length - 1
  }
  while (left < right) {
    swap(arr, left++, right--)
  }
}

function swap<T>(arr: Array<T>, i: number, j: number) {
  const temp = arr[i]
  arr[i] = arr[j]
  arr[j] = temp
}

const str = Array.from('  foo and test ')
reverseWords(str)
const res = str.join('')
res // test and foo
```
