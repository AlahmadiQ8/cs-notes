# Tips

- Do not Prematurely optimize
- **Always discuss Trade-offs (Pros & Cons)**

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

# Scalable Web Application

- Single Server
- Vertical Scaling (increasing ram, HDD etc)
- Horizontal Scaling (multiple Servers)

# Multiple Servers

- Load balancers to multiple servers (not very efficient) cuz they have to
  communicate with each other
- Better way: Distrubuted cache, distributed storage, distributed web server

![](./Cloud-Environment.png)

# Approaching System Design Interviews

- Types

1. Open Ended Service (facebook, instagram, Uber, tinyUrl)
2. Specific System (load balancer, API Rate Limiter, Task Scheduler)
3. Object Oriented Design (Chess Game, Parking Lot)

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

# Uber/Lyft System Design

## Features

1. Save User & Drive Profiles
2. Hail Ride

## Use Cases

| Rider               | Driver                |
| ------------------- | --------------------- |
| Request Ride        | Accept/Reject Request |
| Get ETA             | Pick up passenger     |
| Ride to Destination | Drive                 |
|                     | End Ride              |

## Store 

- Rider State
  - Not Riding
  - Requesting
  - Waiting 
  - Riding
- Driver State
  - Waiting
  - Requesting
  - Picking up
  - Driving
- Ride 

## High LEvel Design 

**Assumptions**: Backend Design for millions of users 

![](./Uber_High_Level_Design_1_.png)
