# Javascript
- [Javascript](#javascript)
  - [How to use `call`, `bind`, and `apply`](#how-to-use-call-bind-and-apply)
  - [What is a `closure`?](#what-is-a-closure)
    - [Problem: `setTimeout` in a loop](#problem-settimeout-in-a-loop)
  - [Debounce Implementation](#debounce-implementation)
  - [Throttle Implementation](#throttle-implementation)
  - [Flatten Array](#flatten-array)
  - [Asynch, Await](#asynch-await)
  - [Event Delegation](#event-delegation)
  - [Explain how prototypal inheritance works?](#explain-how-prototypal-inheritance-works)
  - [What do you think of AMD vs CommonJS?](#what-do-you-think-of-amd-vs-commonjs)
  - [What is the difference between `undefined` and `null`?](#what-is-the-difference-between-undefined-and-null)
  - [Closures](#closures)
- [Frameworks](#frameworks)
- [Problems with Jquery?](#problems-with-jquery)

## How to use `call`, `bind`, and `apply` 

```javascript
function Point(x, y) {
  this.x = x
  this.y = y
}

function add(carry = 0) {
  return this.x + this.y + carry
}

Point.prototype.add = add

// call
const p = new Point(1, 6)
p.add() // 7
add.call(p) //
p.add(3) // 10
add.call(p, 3) // 10


// bind
const boundedAdd = add.bind(p)
boundedAdd() // 7
const boundedAdd10 = add.bind(p, 3)
boundedAdd10() // 10

// apply
add.apply(p) // 7
add.apply(p, [3]) // 10
```

## What is a `closure`? 

Function A returns a function B, and function B can access variables of function A, thus function B is called a closure.

```javascript
function A() {
  let a = 1
  function B() {
      console.log(a)
  }
  return B
}
```

### Problem: `setTimeout` in a loop
A classic interview question is using closures in loops to solve the problem of using var to define functions:

```javascript
for ( var i=1; i<=5; i++) {
    setTimeout( function timer() {
        console.log( i );
    }, i*1000 );
)
```

Three ways to solve the problem 

```javascript 
// closure
for (var i = 1; i <= 5; i++) {
  (function(j) {
    setTimeout(function timer() {
      console.log(j);
    }, j * 1000);
  })(i);
}

// setTimeout parameter
for ( var i=1; i<=5; i++) {
  setTimeout( function timer(j) {
    console.log( j );
  }, i*1000, i);
}

// let var
for (let i = 1; i <= 5; i++) {
  setTimeout(function timer() {
    console.log(i)
  }, i * 1000)
}
```

## Debounce Implementation

```javascript
function debounce(func, wait) {
  let timeout
  return function(...args) {
    const context = this
    clearTimeout(timeout)
    timeout = setTimeout(() => func.apply(context, args), wait)
  }
}
```

## Throttle Implementation

```javascript
// ignoring last run
const throttle = (func, limit) => {
  let inThrottle
  return function() {
    const args = arguments
    const context = this
    if (!inThrottle) {
      func.apply(context, args)
      inThrottle = true
      setTimeout(() => (inThrottle = false), limit)
    }
  }
}

// including last run
const throttle = (func, limit) => {
  let lastFunc
  let lastRan
  return function() {
    const context = this
    const args = arguments
    if (!lastRan) {
      func.apply(context, args)
      lastRan = Date.now()
    } else {
      clearTimeout(lastFunc)
      lastFunc = setTimeout(function() {
        if (Date.now() - lastRan >= limit) {
          func.apply(context, args)
          lastRan = Date.now()
        }
      }, limit - (Date.now() - lastRan))
    }
  }
}
```

## Flatten Array 

```javascript
const flattenDeep = arr =>
  Array.isArray(arr)
    ? arr.reduce((a, b) => [...a, ...flattenDeep(b)], [])
    : [arr]

flattenDeep([1, [[2], [3, [4]], 5]]) 
```

## Asynch, Await

async function will return a Promise:

```javascript
async function test() {
  return '1'
}
console.log(test()) // -> Promise {<resolved>: "1"}

function sleep() {
  return new Promise(resolve => {
    setTimeout(() => {
      console.log('finish')
      resolve('sleep')
    }, 2000)
  })
}
async function test() {
  let value = await sleep()
  console.log('object')
}
test()
```

You can think of async as wrapping a function using `Promise.resolve()`.

## Event Delegation

Event delegation is a technique involving adding event listeners to a parent
element instead of adding them to the descendant elements. The listener will
fire whenever the event is triggered on the descendant elements due to event
bubbling up the DOM. The benefits of this technique are:

- Memory footprint goes down because only one single handler is needed on the
  parent element, rather than having to attach event handlers on each
  descendant.
- There is no need to unbind the handler from elements that are removed and to
  bind the event for new elements.

*References*

- https://davidwalsh.name/event-delegate
- https://stackoverflow.com/questions/1687296/what-is-dom-event-delegation

## Explain how prototypal inheritance works? 

- https://github.com/getify/You-Dont-Know-JS/blob/master/this%20%26%20object%20prototypes/ch5.md

## What do you think of AMD vs CommonJS?

- **AMD (Asynchronous Module Definition):** used for browsers. verbose syntax.
- **CommonJS:** used for nodejs.

## What is the difference between `undefined` and `null`?

- `undefined`: 
  - when a variable is declared and undefined, it is assigned `undefined`
  - when a function doesn't return anything, it returns undefined by default
- `null`: 
  - will have to be explicitly assigned to a variable. 
  - represents no value

```javascript
let a = null
let b = undefined
a == b   // true
a === b  // false
typeof a // "object"
typeof b // "undefined"
```

## Closures



# Frameworks

# Problems with Jquery?

- You can easily write code that has deeply coupled data logic and view.
- Can has unnecessary re-renders compared to other frameworks that leverage
  virtual dom such as react and vue
- It is just a library and best practices and patterns are left for users. this
  is not good for large teams 
