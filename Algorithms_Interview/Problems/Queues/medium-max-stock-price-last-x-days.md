
## Problem

```
You​ ​are​ ​given​ ​stock​ ​prices​ ​and​ ​the​ ​corresponding​ ​day​ 
​of​ ​each​ ​stock​ ​price.​ ​For​ ​example:

(32,​ ​1),​ ​(45,​ ​1),​ ​(37,2),​ ​(42,3)..

Here​ ​32​ ​is​ ​the​ ​price​ ​and​ ​1​ ​is​ ​the​ ​day​ ​of​ ​the​ 
​price. Say​ ​you​ ​are​ ​given​ ​these​ ​prices​ ​as​ ​an​ ​input​ ​stream.​ ​You​ ​should​ ​provide​ ​a​ ​function​ ​for

The​ ​user​ ​to​ ​input​ ​a​ ​stock​ ​price​ ​and​ ​day.​ ​Your​ 
​system​ ​should​ ​be​ ​able​ ​to​ ​tell the​ ​maximum​ ​stock​ ​price​ ​in​ ​the​ ​last​ ​3​ ​days.
```

## Notes

- Calculating the max is O(n)
- We could improve it to O(1)

## Solution

```javascript
class Price {
  constructor(price, day) {
    this.price = price
    this.day = day
  }
} 

class StockPriceWithTime {
  constructor(windowSize) {
    this.queue = []
    this.size = windowSize
    this.max = Number.NEGATIVE_INFINITY 
  }

  _getLast() {
    return this.queue[this.queue.length - 1]
  }

  addPrice(price, day) {
    const lastDay = (day - this.size) + 1
    while (this.queue.length != 0 && this._getLast().day < lastDay) {
      this.queue.pop()
    }
    this.queue.unshift(new Price(price, day))
  }

  getMax() {
    return Math.max(...this.queue.map(val => val.price))
  }
}

const obj = new StockPriceWithTime(3)
obj.addPrice(30, 1)
expect(obj.getMax()).to.equal(30)
obj.addPrice(40, 3)
expect(obj.getMax()).to.equal(40)
obj.addPrice(25, 6)
expect(obj.getMax()).to.equal(25)
obj.addPrice(50, 7)
expect(obj.getMax()).to.equal(50)
```
