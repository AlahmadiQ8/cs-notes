## Problem 

*Link: https://www.geeksforgeeks.org/word-ladder-length-of-shortest-chain-to-reach-a-target-word/*

Given a dictionary, and two words ‘start’ and ‘target’ (both of same length).
Find length of the smallest chain from ‘start’ to ‘target’ if it exists, such
that adjacent words in the chain only differ by one character and each word in
the chain is a valid word i.e., it exists in the dictionary. It may be assumed
that the ‘target’ word exists in dictionary and length of all dictionary words
is same.

Example:

```
Input:  Dictionary = {POON, PLEE, SAME, POIE, PLEA, PLIE, POIN}
             start = TOON
             target = PLEA
Output: 7
Explanation: TOON - POON - POIN - POIE - PLIE - PLEE - PLEA
```

## Technique

- BFS

## Solution 

```javascript
function wordLadder(start, target, set) {
  const result = []
  const visited = new Set()
  const queu = [start]

  while (queu.length) {
    const cur = queu.pop()
    result.push(cur)
    if (cur == target) return result
    const neighbors = Array.from(set).filter(word => {
      return !visited.has(word) && diferByOne(cur, word)
    })
    queu.push(...neighbors)
    visited.add(cur)
  }

  return []
}


function diferByOne(w1, w2) {
  if (w1.length !== w2.length) return false;
  let diferCount = 0;
  for (let i = 0; i < w1.length; i++) {
    if (w1[i] !== w2[i]) diferCount++;
    if (diferCount > 1) return false;
  }
  return diferCount === 1;
}

const set = new Set(['POON', 'PLEE', 'SAME', 'POIE', 'PLEA', 'PLIE', 'POIN']);
wordLadder('TOON', 'PLEA', set) //?
```

```csharp
public int LadderLength(string beginWord, string endWord, IList<string> wordList)
{
    var visited = new HashSet<string>();
    var l = beginWord.Length;
    var allCombo = GetPreProcessedNeighbors();
    var queue = new Queue<(string, int)>();
    queue.Enqueue((beginWord, 0));
    visited.Add(beginWord);

    while (queue.Count > 0)
    {
        var (current, level) = queue.Dequeue();
        if (current == endWord) return level + 1;

        var unvisitedNeighbors = GetNeighbors(current).Where(n => !visited.Contains(n));
        foreach (var neighbor in unvisitedNeighbors)
            queue.Enqueue((neighbor, level + 1));
        visited.Add(current);
    }

    return 0;

    IList<string> GetNeighbors(string word)
    {
        var result = new List<string>();

        for (var i = 0; i < l; i++)
        {
            var newWord = word[..i] + "*" + word[(i + 1)..l];
            if (allCombo.ContainsKey(newWord)) result.AddRange(allCombo[newWord]);
        }

        return result;
    }

    IDictionary<string, IList<string>> GetPreProcessedNeighbors()
    {
        var allComboDict = new Dictionary<string, IList<string>>();
        foreach (var word in wordList)
        {
            for (var i = 0; i < l; i++)
            {
                var newWord = word[..i] + "*" + word[(i + 1)..l];
                if (!allComboDict.ContainsKey(newWord)) allComboDict[newWord] = new List<string>();
                allComboDict[newWord].Add(word);
            }
        }

        return allComboDict;
    }
}
```
