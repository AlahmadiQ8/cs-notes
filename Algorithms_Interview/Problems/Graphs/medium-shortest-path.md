## Problem 

You wrote a trendy new messaging app, MeshMessage, to get around flaky cell
phone coverage.

Instead of routing texts through cell towers, your app sends messages via the
phones of nearby users, passing each message along from one phone to the next
until it reaches the intended recipient. (Don't worry—the messages are encrypted
while they're in transit.)

Some friends have been using your service, and they're complaining that it takes
a long time for messages to get delivered. After some preliminary debugging, you
suspect messages might not be taking the most direct route from the sender to
the recipient.

Given information about active users on the network, find the shortest route for
a message from one user (the sender) to another (the recipient). Return an array
of users that make up this route.

Your network information takes the form of an object where keys are usernames
and values are arrays of other users nearby:

```javascript
const network = {
  'Min'     : ['William', 'Jayden', 'Omar'],
  'William' : ['Min', 'Noam'],
  'Jayden'  : ['Min', 'Amelia', 'Ren', 'Noam'],
  'Ren'     : ['Jayden', 'Omar'],
  'Amelia'  : ['Jayden', 'Adam', 'Miguel'],
  'Adam'    : ['Amelia', 'Miguel', 'Sofia', 'Lucas'],
  'Miguel'  : ['Amelia', 'Adam', 'Liam', 'Nathan'],
  'Noam'    : ['Nathan', 'Jayden', 'William'],
  'Omar'    : ['Ren', 'Min', 'Scott'],
  ...
};
```

For the network above, a message from `Jayden` to `Adam` should have this route:

```javascript
['Jayden', 'Amelia', 'Adam']
```


## Technique

- dijkstra algorithm

## Solution 

```javascript
function bfsGetPath(graph, startNode, endNode) {
  if (graph[startNode] == null || graph[endNode] == null) throw new Error("OMG")
  if (startNode == endNode) return [startNode]

  const queue = [startNode]
  const dist = { [startNode]: 0 }
  const visited = new Set();
  for (const key of Object.keys(graph)) {
    if (key !== startNode) {
      dist[key] = Number.POSITIVE_INFINITY
    }
  }

  const parents = { [startNode]: null }

  while (queue.length) {
    const cur = queue.shift()
    for (const ne of graph[cur]) {
      if (!visited.has(ne)) {
        if (1 + dist[cur] < dist[ne]) {
          parents[ne] = cur
          dist[ne] = 1 + dist[cur]
        }
        queue.push(ne)
      }
    }
    visited.add(cur)
  }
  
  if (parents[endNode] == null) return null

  const result = []
  let cur = endNode
  while (cur) {
    result.unshift(cur)
    cur = parents[cur]
  }
  
  return result;
}

// Tests
const graph = {
  'a': ['b', 'c', 'd'],
  'b': ['a', 'd'],
  'c': ['a', 'e'],
  'd': ['a', 'b'],
  'e': ['c'],
  'f': ['g'],
  'g': ['f']
};

let desc = 'two hop path 1';
let actual = bfsGetPath(graph, 'a', 'e');
let expected = ['a', 'c', 'e'];
assertDeepEqual(actual, expected, desc);

desc = 'two hop path 2';
actual = bfsGetPath(graph, 'd', 'c');
expected = ['d', 'a', 'c'];
assertDeepEqual(actual, expected, desc);

desc = 'one hop path 1';
actual = bfsGetPath(graph, 'a', 'c');
expected = ['a', 'c'];
assertDeepEqual(actual, expected, desc);

desc = 'one hop path 2';
actual = bfsGetPath(graph, 'f', 'g');
expected = ['f', 'g'];
assertDeepEqual(actual, expected, desc);

desc = 'one hop path 3';
actual = bfsGetPath(graph, 'g', 'f');
expected = ['g', 'f'];
assertDeepEqual(actual, expected, desc);

desc = 'zero hop path';
actual = bfsGetPath(graph, 'a', 'a');
expected = ['a'];
assertDeepEqual(actual, expected, desc);

desc = 'no path';
actual = bfsGetPath(graph, 'a', 'f');
expected = null;
assertDeepEqual(actual, expected, desc);

desc = 'start node not present';
assertThrowsError(() => {
  bfsGetPath(graph, 'h', 'a');
}, desc);

desc = 'end node not present';
assertThrowsError(() => {
  bfsGetPath(graph, 'a', 'h');
}, desc);

function assertDeepEqual(a, b, desc) {
  const aStr = JSON.stringify(a);
  const bStr = JSON.stringify(b);
  if (aStr !== bStr) {
    console.log(`${desc} ... FAIL: ${aStr} != ${bStr}`);
  } else {
    console.log(`${desc} ... PASS`);
  }
}

function assertThrowsError(func, desc) {
  try {
    func();
    console.log(`${desc} ... FAIL`);
  } catch (e) {
    console.log(`${desc} ... PASS`);
  }
}
```
