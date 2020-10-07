# Tips

- Do not Prematurely optimize
- **Always discuss Trade-offs (Pros & Cons)**
- Common things to ask if requierement is needed
  - Optimize based on read heavy of write heavy 
  - High Availibiltiy (most standard functional reqruerement)
  - Eventual consistency is OKAY or not? or it has to be real time 
  - Real time
  - Analytics
- **Traffic estimates**
  - reads, writes per day and second
  - storage for one year
  - memory storage for cach: use 80/20 rule
  - bandwidth
- When to use NoSQL
  - No critical transaction requiring multiple entities (ACIDity )
  - No joins and relationships
  - need to easily distribute accross 
  - large amount of data with little or no structure
- Concurency Issues

# Steps Based on CTCI
- Step 1: Scope the problem
- Step 2: Make reasonable assumptions
- Step 3: Draw the major componenst
- Step 4: Identify key issues
  - Is there any single point of failure in our system? What are we doing to
    mitigate it?
  - Do we have enough replicas of the data so that if we lose a few servers we
    can still serve our users?
  - How are we monitoring the performance of our service? Do we get alerts
    whenever critical components fail or their performance degrades?
- Step 5: Redesign for key issues 

# Considiration

- **Failures:** Any part of a system can fail. You need to plan for many of
  these failures
- **Availibility & Reliability**
- **Read-heavy vs. Write-heavy:** If Write-heavy, we could consider queing the
  writes 
- **Security**


## Steps

1. **F**: Define 2-3 core **Features**, list out specifications, features and
   use cases
2. **U**: Use Cases
3. **S**: What to **Store** (not DB Model)
4. **H**: **High Level** Design
5. **B**: Back-of-the-envelope estimation to identify key issues and bottlenecks
6. **D**: **Detailed** Design to address key issues

Additional steps: 

- 2.3 - Draw a state machine
- 3.5 - Keep Scalibility in mind

