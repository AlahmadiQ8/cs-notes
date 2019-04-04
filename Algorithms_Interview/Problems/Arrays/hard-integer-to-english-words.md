# Problem 

https://leetcode.com/problems/integer-to-english-words/

Convert a non-negative integer to its english words representation. Given input
is guaranteed to be less than 2^31 - 1.

**Example 1**

```
Input: 123
Output: "One Hundred Twenty Three"
```

**Example 2**

```
Input: 12345
Output: "Twelve Thousand Three Hundred Forty Five"
```


**Example 3**

```
Input: 1234567
Output: "One Million Two Hundred Thirty Four Thousand Five Hundred Sixty Seven"
```


**Example 4**

```
Input: 1234567891
Output: "One Billion Two Hundred Thirty Four Million Five Hundred Sixty Seven Thousand Eight Hundred Ninety One"
```

# Solution

```javascript
const ones = num => {
  const ONES = {
    1: 'One',
    2: 'Two',
    3: 'Three',
    4: 'Four',
    5: 'Five',
    6: 'Six',
    7: 'Seven',
    8: 'Eight',
    9: 'Nine'
  };
  if (ONES[num] != null) return ONES[num];
  return '';
};

const TWO_LESS_THAN_20 = {
  10: 'Ten',
  11: 'Eleven',
  12: 'Twelve',
  13: 'Thirteen',
  14: 'Fourteen',
  15: 'Fifteen',
  16: 'Sixteen',
  17: 'Seventeen',
  18: 'Eighteen',
  19: 'Nineteen'
};

const TEN = {
  2: 'Twenty',
  3: 'Thirty',
  4: 'Forty',
  5: 'Fifty',
  6: 'Sixty',
  7: 'Seventy',
  8: 'Eighty',
  9: 'Ninety'
};

const ANDS = ['', 'Thousand', 'Million', 'Billion'];

function two(num) {
  if (num == 0) return '';
  if (num < 10) return ones(num);
  if (num < 20) return TWO_LESS_THAN_20[num];

  const tenner = Math.floor(num / 10);
  const rest = num - tenner * 10;
  if (rest != 0) return TEN[tenner] + ' ' + ones(rest);

  return TEN[tenner];
}

function three(num) {
  const hundred = Math.floor(num / 100);
  const rest = num - hundred * 100;

  if (hundred !== 0 && rest !== 0) {
    ones(hundred) + ' Hundred ' + two(rest); //?
    return ones(hundred) + ' Hundred ' + two(rest);
  }

  if (hundred == 0 && rest !== 0) {
    return two(rest);
  }

  if (hundred != 0 && rest == 0) {
    return ones(hundred) + ' Hundred';
  }

  return '';
}

function numberToWords(num) {
  if (num == 0) return 'Zero';
  let result = [];
  let i = 0;
  while (num) {
    const threePack = Math.floor(num % 1000);
    if (three(threePack)) {
      result.unshift([three(threePack), ANDS[i]].join(' '));
    }
    num = Math.floor(num / 1000);
    i++;
  }
  return result
    .filter(Boolean)
    .join(' ')
    .trim();
}
```
