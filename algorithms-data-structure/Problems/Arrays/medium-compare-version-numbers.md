# Problem 

https://leetcode.com/problems/compare-version-numbers/

Compare two version numbers version1 and version2. If `version1 > version2`
return `1`; if `version1 < version2` return `-1`;otherwise return `0`.

You may assume that the version strings are non-empty and contain only digits
and the `.` character.

The `.` character does not represent a decimal point and is used to separate
number sequences.

For instance, `2.5` is not "two and a half" or "half way to version three", it
is the fifth second-level revision of the second first-level revision.

You may assume the default revision number for each level of a version number to
be `0`. For example, version number `3.4` has a revision number of `3` and `4`
for its first and second level revision number. Its third and fourth level
revision number are both `0`.

**Examples:**

```
Input: version1 = "0.1", version2 = "1.1"
Output: -1

Input: version1 = "1.0.1", version2 = "1"
Output: 1

Input: version1 = "7.5.2.4", version2 = "7.5.3"
Output: -1

Input: version1 = "1.01", version2 = "1.001"
Output: 0
Explanation: Ignoring leading zeroes, both “01” and “001" represent the same number “1”

Input: version1 = "1.0", version2 = "1.0.0"
Output: 0
Explanation: The first version number does not have a third level revision number, which means its third level revision number is default to "0"
```

**Note:**

Version strings are composed of numeric strings separated by dots . and this
numeric strings may have leading zeroes. Version strings do not start or end
with dots, and they will not be two consecutive dots.

# Solution 

```javascript
/**
 * @param {string} version1
 * @param {string} version2
 * @return {number}
 */
function compareVersion(version1, version2) {
  if (version1 == null || version2 == null) return null;

  const v1Splitted = version1.split('.').map(v => parseInt(v));
  const v2Splitted = version2.split('.').map(v => parseInt(v)); 
  
  let i;
  for (i = 0; i < Math.min(v1Splitted.length, v2Splitted.length); i++) {
    if (v1Splitted[i] > v2Splitted[i]) return 1;
    if (v1Splitted[i] < v2Splitted[i]) return -1;
  }

  if (v1Splitted.length == v2Splitted.length) return 0

  while (i < v1Splitted.length) {
    if (v1Splitted[i++] !== 0) return 1
  }
  while (i < v2Splitted.length) {
    if (v2Splitted[i++] !== 0) return -1
  }

  return 0;
}
```
