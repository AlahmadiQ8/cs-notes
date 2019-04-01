# CAP Theorem

Any Distributed system is a tradofe of three aspects: 

- **Consistency:** All nodes see the same data at the same time. Consistency is 
  achieved by updating several nodes before allowing further reads.
- **Availability:** Every request gets a response on success/failure. 
  Availability is achieved by replicating the data across different servers.
- **Partition Tolrence:** he system continues to work despite message loss or 
  partial failure
  partition(s)

# ACID

- **Atomic** - Everything in the write/update succeeds or the entire operation is rolled back
- **Consistent** - The database will never be in a state where two reads to the same DB get different value.
- **Isolated** - Operations cannot interfere with each other.
- **Durable** - Completed operations are persisted, even if the machine restarts, etc.

# BASE

- **B**asic **A**vailability
- **S**oft State
- **E**ventual Consistency


**Where is it ok to have Eventual Consistency?** Let’s say you are storing blog posts. Let’s say author A updated their post. It is probably ok to show some users an older version of the blog post (let’s say 5 minutes older) while all copies of the distributed database get updated. We rather the posts be available all the time.

**Where would you want Consistency?** Let’s say you are storing user passwords. If a user changes their password, you don’t want the old password to work anywhere, even for a few minutes after the change! This calls for consistency.
