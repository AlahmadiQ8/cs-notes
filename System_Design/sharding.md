# Sharding

**Sharding** essentially means splitting things into small pieces and making them work together. 

# What can you scale using Sharding?

* Distributed Database
* Distributed Cache
* Distributed Hash Table
* Distributed Key-Value Stores

## Memchached

Source: https://www.linuxjournal.com/article/7451

**Memcached** is a high-performance, distributed caching system. it's commonly used to speed up dynamic Web applications by alleviating database load.


## Partitioning Function 

## Contsistent Hashing 

https://www.acodersjourney.com/system-design-interview-consistent-hashing/

Scenarios Where to Use Consistent Hashing
* You have a cluster of databases and you need to elastically scale them up or down based on traffic load. For example, add more servers during Christmas to handle the the extra traffic.
* You have a set of cache servers that need to elastically scale up or down based on traffic load.

Benefits of Consistent Hashing:
* Enables Elastic Scaling of cluster of database/cache servers
* Facilitates Replication and partitioning of data across servers
* Partitioning of data enables uniform distribution which relieves hot spots
* Points a-c enables higher availability of the system as a whole.
