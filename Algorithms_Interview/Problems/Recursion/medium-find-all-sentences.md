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


```csharp
public bool WordBreak(string s, IList<string> wordDict)
{
    if (wordDict.Count == 0) return false;
    if (s.Length == 0) return false;
    var wordDictSet = new HashSet<string>(wordDict);
    var memo = new State[s.Length];
    Array.Fill(memo, State.NotVisited);
    return Helper(0);

    bool Helper(int start)
    {
        if (start == s.Length) return true;
        if (memo[start] == State.NotFound) return false;

        for (var i = start; i < s.Length; i++)
        {
            var candidate = s[start..(i + 1)];
            if (wordDictSet.Contains(candidate))
            {
                if (Helper(i + 1)) return true;
                memo[i + 1] = State.NotFound;
            }
        }

        return false;
    }
}

public override void Test()
{
    WordBreak("leetcode", new List<string> {"leet", "code"}).Should().BeTrue();
    WordBreak("leetcddode", new List<string> {"leet", "code"}).Should().BeFalse();
    WordBreak("", new List<string> {"leet", "code"}).Should().BeFalse();
    WordBreak("asdfsdf", new List<string>()).Should().BeFalse();
    WordBreak("aaaaaaa", new List<string> {"aaaa", "aaa"}).Should().BeTrue();
}
```
