## Problem 

```
Consider the following dictionary 
{ i, like, sam, sung, samsung, mobile, ice, 
  cream, icecream, man, go, mango}

Input: "ilikesamsungmobile"
Output: i like sam sung mobile
        i like samsung mobile

Input: "ilikeicecreamandmango"
Output: i like ice cream and man go
        i like ice cream and mango
        i like icecream and man go
        i like icecream and mango
```

## Technique

- Recursion (Obviously)


| Complexity | Big O                            |
| ---------- | -------------------------------- |
| Time       | Exponential, quite poor actually |
| Space      |                                  |

## Solution

```javascript
class Word {
  constructor(str, start, end) {
    this.str = str
    this.start = start
    this.end = end
  }
}

function findSentence(str, dict, sentence, i) {
  if (i >= str.length) {
    console.log(sentence.join(' '))
    return
  }

  const words = findAllWordsFromIndex(str, dict, i)

  for (const word of words) {
    sentence.push(word.str)
    findSentence(str, dict, sentence, word.end + 1)
    sentence.pop()
  }
}

function findAllWordsFromIndex(str, dict, i) {
  const words = []
  let j = i
  for (let j = i; j < str.length; j++) {
    const slice = str.substring(i, j + 1)
    if (dict.has(slice)) {
      words.push(new Word(slice, i, j))
    }
  }
  return words
}

const str = "ilikeicecreamandmango"
const dict = new Set([
  'i',
  'like',
  "and",
  'sam',
  'sung',
  'samsung',
  'mobile',
  'ice',
  'cream',
  'icecream',
  'man',
  'go',
  'mango',
])
findSentence(str, dict, [], 0)
// i like ice cream and man go​​​​​​​​​​​​​
// ​​​​​i like ice cream and mango​​​​​​​​​​​​​
// ​​​​​i like icecream and man go​​​​​​​​​​​​​
// ​​​​​i like icecream and mango​​​​​
```
