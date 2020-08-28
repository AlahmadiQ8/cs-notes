- [Steps To Follow When Answering A Coding Problem](#steps-to-follow-when-answering-a-coding-problem)
  - [Misc](#misc)
  - [PreReq](#prereq)
  - [1. Example](#1-example)
  - [2. Solutions](#2-solutions)
  - [3. Test Cases](#3-test-cases)
  - [4. Code](#4-code)
  - [5. Verify](#5-verify)

# Steps To Follow When Answering A Coding Problem 

```
1. Define the Problem
2. Ask Questions to limit the scope to make it easier
3. ask on error possible inputs
4. to save time, you can add TODO for error handling
```

## Misc

- Do not jump straight to code
- Ask the interviewer to agree on a solution to code
- Take careful care of syntax (YES it matters)
- Heap: 
  - Insert/remove O(logn)
  - Max O(1) 

## PreReq

- Ask damn questions
- **Try to limit the scope of the question such that you can implement it on time**
- Clarify assumption

## 1. Example

- A basic example
- Make sure you clearly understand the problem & requirements
- Ask a lot of questions
- High level discussion
- Explain Concepts

Demo:
- How big is the size of the input?
- How big is the range of values?
- What kind of values are there? Are there negative numbers? Floating points?
  Will there be empty inputs?
- Are there duplicates within the input?
- What are some extreme cases of the input?
- How is the input stored? If you are given a dictionary of words, is it a list
  of strings or a trie?
  
## 2. Solutions 

- Start with a brute force solution
- Discuss solutions
- Trade offs / cons and pros 
- Time, space complexity

## 3. Test Cases 

- Edge cases
- Base cases 
- Regular cases 
- Be careful of circular or infinite loops 
  - Visited unvisited to solve this
  - Could use a hash to keep track of visited/unvisited
  - Recursion is often good
- Start with function definition with test cases to follow 
```
// case1
// case2 
// case3 
function foo(args)
```

## 4. Code

- Confirm function signature and return types
- Handle invalid input
- Use helper functions
- Communicate and state your assumptions early 

## 5. Verify 

- Start with regular case
- Check edge cases
