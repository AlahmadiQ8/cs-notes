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
- [Explain what a single page app is](#explain-what-a-single-page-app-is)
- [OWASP Top 10](#owasp-top-10)
  - [1. Injection](#1-injection)
  - [2. Broken Authentication](#2-broken-authentication)
  - [3. Sensitive Data Exposure](#3-sensitive-data-exposure)
  - [4. XML External Entities (XEE)](#4-xml-external-entities-xee)
  - [5. Broken Access Control](#5-broken-access-control)
  - [6. Security Misconfiguration](#6-security-misconfiguration)
  - [7. Cross-Site Scripting](#7-cross-site-scripting)
  - [8. Insecure Deserialization](#8-insecure-deserialization)
  - [9. Using Components With Known Vulnerabilities](#9-using-components-with-known-vulnerabilities)
  - [10. Insufficient Logging And Monitoring](#10-insufficient-logging-and-monitoring)

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

# Explain what a single page app is 

**Answer**
- Web apps tend to be highly interactive and dynamic
- Client-side rendering is used instead. 
  - The browser loads the initial page from the server, along with the scripts (frameworks, libraries, app code) and stylesheets required for the whole app. 
  - When the user navigates to other pages, a page refresh is not triggered. 
  - The URL of the page is updated via the HTML5 History API.
  - New data required for the new page, usually in JSON format, is retrieved by the browser via AJAX requests to the server.

**Pros**
- The app feels more responsive and users do not see the flash between page navigations due to full-page refreshes.
- Fewer HTTP requests are made to the server, as the same assets do not have to be downloaded again for each page load.
- Clear separation of the concerns between the client and the server; you can easily build new clients for different platforms (e.g. mobile, chatbots, smart watches) without having to modify the server code. You can also modify the technology stack on the client and server independently, as long as the API contract is not broken.

**Cons**
- Heavier initial page load due to the loading of framework, app code, and assets required for multiple pages.
- There's an additional step to be done on your server which is to configure it to route all requests to a single entry point and allow client-side routing to take over from there.
- SPAs are reliant on JavaScript to render content, but not all search engines execute JavaScript during crawling, and they may see empty content on your page. This inadvertently hurts the Search Engine Optimization (SEO) of your app. However, most of the time, when you are building apps, SEO is not the most important factor, as not all the content needs to be indexable by search engines. To overcome this, you can either server-side render your app or use services such as Prerender to "render your javascript in a browser, save the static HTML, and return that to the crawlers".

# OWASP Top 10

*Resource: https://www.cloudflare.com/learning/security/threats/owasp-top-10/*

## 1. Injection

Injection attacks happen when untrusted data is sent to a code interpreter through a form input or some other data submission to a web application. For example, an attacker could enter SQL database code into a form that expects a plaintext username. If that form input is not properly secured, this would result in that SQL code being executed. This is known as an SQL injection attack.

Injection attacks can be prevented by validating and/or sanitizing user-submitted data. (Validation means rejecting suspicious-looking data, while sanitization refers to cleaning up the suspicious-looking parts of the data.) In addition, a database admin can set controls to minimize the amount of information an injection attack can expose.

## 2. Broken Authentication

Vulnerabilities in authentication (login) systems can give attackers access to user accounts and even the ability to compromise an entire system using an admin account. For example, an attacker can take a list containing thousands of known username/password combinations obtained during a data breach and use a script to try all those combinations on a login system to see if there are any that work.

Some strategies to mitigate authentication vulnerabilities are requiring 2-factor authentication (2FA) as well as limiting or delaying repeated login attempts using rate limiting.

## 3. Sensitive Data Exposure

If web applications don’t protect sensitive data such as financial information and passwords, attackers can gain access to that data and sell or utilize it for nefarious purposes. One popular method for stealing sensitive information is using a man-in-the-middle attack.

Data exposure risk can be minimized by encrypting all sensitive data as well as disabling the caching* of any sensitive information. Additionally, web application developers should take care to ensure that they are not unnecessarily storing any sensitive data.

*Caching is the practice of temporarily storing data for re-use. For example, web browsers will often cache webpages so that if a user revisits thosepages within a fixed time span, the browser does not have to fetch the pages from the web.

## 4. XML External Entities (XEE)

This is an attack against a web application that parses XML* input. This input can reference an external entity, attempting to exploit a vulnerability in the parser. An ‘external entity’ in this context refers to a storage unit, such as a hard drive. An XML parser can be duped into sending data to an unauthorized external entity, which can pass sensitive data directly to an attacker.

The best ways to prevent XEE attacks are to have web applications accept a less complex type of data, such as JSON**, or at the very least to patch XML parsers and disable the use of external entities in an XML application.

## 5. Broken Access Control

Access control refers a system that controls access to information or functionality. Broken access controls allow attackers to bypass authorization and perform tasks as though they were privileged users such as administrators. For example a web application could allow a user to change which account they are logged in as simply by changing part of a url, without any other verification.

Access controls can be secured by ensuring that a web application uses authorization tokens* and sets tight controls on them.

## 6. Security Misconfiguration

Security misconfiguration is the most common vulnerability on the list, and is often the result of using default configurations or displaying excessively verbose errors. For instance, an application could show a user overly-descriptive errors which may reveal vulnerabilities in the application. This can be mitigated by removing any unused features in the code and ensuring that error messages are more general.

## 7. Cross-Site Scripting

Cross-site scripting vulnerabilities occur when web applications allow users to add custom code into a url path or onto a website that will be seen by other users. This vulnerability can be exploited to run malicious JavaScript code on a victim’s browser. For example, an attacker could send an email to a victim that appears to be from a trusted bank, with a link to that bank’s website. This link could have some malicious JavaScript code tagged onto the end of the url. If the bank’s site is not properly protected against cross-site scripting, then that malicious code will be run in the victim’s web browser when they click on the link.

Mitigation strategies for cross-site scripting include escaping untrusted HTTP requests as well as validating and/or sanitizing user-generated content. Using modern web development frameworks like ReactJS and Ruby on Rails also provides some built-in cross-site scripting protection.

## 8. Insecure Deserialization

This threat targets the many web applications which frequently serialize and deserialize data. Serialization means taking objects from the application code and converting them into a format that can be used for another purpose, such as storing the data to disk or streaming it. Deserialization is just the opposite: converting serialized data back into objects the application can use. Serialization is sort of like packing furniture away into boxes before a move, and deserialization is like unpacking the boxes and assembling the furniture after the move. An insecure deserialization attack is like having the movers tamper with the contents of the boxes before they are unpacked.

An insecure deserialization exploit is the result of deserializing data from untrusted sources, and can result in serious consequences like DDoS attacks and remote code execution attacks. While steps can be taken to try and catch attackers, such as monitoring deserialization and implementing type checks, the only sure way to protect against insecure deserialization attacks is to prohibit the deserialization of data from untrusted sources.

## 9. Using Components With Known Vulnerabilities

Many modern web developers use components such as libraries and frameworks in their web applications. These components are pieces of software that help developers avoid redundant work and provide needed functionality; common example include front-end frameworks like React and smaller libraries that used to add share icons or a/b testing. Some attackers look for vulnerabilities in these components which they can then use to orchestrate attacks. Some of the more popular components are used on hundreds of thousands of websites; an attacker finding a security hole in one of these components could leave hundreds of thousands of sites vulnerable to exploit.

Component developers often offer security patches and updates to plug up known vulnerabilities, but web application developers don’t always have the patched or most-recent versions of components running on their applications. To minimize the risk of running components with known vulnerabilities, developers should remove unused components from their projects, as well as ensuring that they are receiving components from a trusted source and ensuring they are up to date.

## 10. Insufficient Logging And Monitoring

Many web applications are not taking enough steps to detect data breaches. The average discovery time for a breach is around 200 days after it has happened. This gives attackers a lot of time to cause damage before there is any response. OWASP recommends that web developers should implement logging and monitoring as well as incident response plans to ensure that they are made aware of attacks on their applications.
