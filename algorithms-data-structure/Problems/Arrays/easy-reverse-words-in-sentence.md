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

```csharp
public void ReverseWords(char[] words)
{
    Array.Reverse(words);
    for (var i = 0; i < words.Length; i++)
    {
        if (words[i] == ' ') continue;

        var j = GetEndOfWord(words, i);
        while (i < j)
            Swap(words, i++, j--);
        i = j + 1;
    }
}

private int GetEndOfWord(IList<char> wordsList, int i)
{
    var j = i;
    while (j + 1 < wordsList.Count && wordsList[j + 1] != ' ') j++;
    return j;
}

void Swap(IList<char> arr, int i, int j)
{
    var buf = arr[i];
    arr[i] = arr[j];
    arr[j] = buf;
}

public void Test()
{
    var input = "one two  three".ToCharArray();
    ReverseWords(input);
    Console.WriteLine(input.ToConcatenated());
}
```
