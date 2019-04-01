# Load Balancer

![](/System_Design/load-balancer.png)

Benefits: 
- Improved response time 
- Improved fault tolerence
- Hides internal servers (security?)

Scheduling algorthims: 
- HTTP requests (REST API)
- Stateless App Servers
- Shortlived connections

Algorthims: 

1. Round Robin
2. Random (not very good)
3. Weighted Round Robin
4. Geographin location / Response Time Up/down status / Capibilities
5. # of live connections 

## Balancing for stateful app (Persistence)

Pros of stateless: 
- Easier to scale 
- Easier for failover management

Cons of statesless: 
- Roundtrip time
- Eventual consistency (think booking site for example)

Persistence Strategies
- IP Address - Layer 4 LB
- Session ID (Cookies, or SSL Certificate) - later 7 LB
