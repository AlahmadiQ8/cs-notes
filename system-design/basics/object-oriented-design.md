# Object Oriented Design

## Resources 

- Cracking The Coding Interview 

## How to Approach Object-Oriented Design Questions 

### Step 1: Handle Ambiguity

- The Six Ws: `Who`, `What`, `Where`, `When`, `How`, and `Why`

### Defind the Core Objects

For example, suppose we are asked to do the object-oriented design for a
restaurant. Our core objects might be things like `Table`, `Guest`, `Party`,
`Order`, `Meal`, `Employee`, `Server`, and `Host`.

### Step 3: Analyze Relationships

For example, in the restaurant question, we may come up with the following
design:

- `Party` should have an array of `Guests`.
- `Server` and `Host` inherit from `Employee`. 
- Each `Table` has one `Party`, but each `Party` may have multiple `Tables`.
- There is one `Host` for the `Restaurunt`.

### Step 4: Investigate Actions

For example, a Party walks into the Restaurant, and a Guest requests a Table
from the Host. The Host looks up the Reservation and, if it exists, assigns the
Party to a Table. Otherwise, the Party is added to the end of the list. When a
Party leaves, the Table is freed and assigned to a new Party in the list.

## Design Patterns


