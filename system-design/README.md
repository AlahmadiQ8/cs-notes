# Steps Based on CTCI

1. Scope the problem
  - Design 2-4 core features
  - Degine use cases
2. Make reasonable assumptions
3. What to store (not db model)
4. Draw the major components (high level design)
5. Identify key issues
  - Consistency requirements
  - Is there any single point of failure in our system? What are we doing to
    mitigate it?
  - Do we have enough replicas of the data so that if we lose a few servers we
    can still serve our users?
  - How are we monitoring the performance of our service? Do we get alerts
    whenever critical components fail or their performance degrades?
6. Step 5: Redesign for key issues
