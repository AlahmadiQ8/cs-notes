Find the size of an array without using `length` property 

## Technique

- We try the following indexes and see which and which doesn't throw
  an exception
- If it doesn't throw at `8` but throws at `16`, then the array size is
  is between `8` to `16`

```
*  *    *        *         *      *
1  2    4        8         |      16
```
