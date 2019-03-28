# HTTP2

## Resources: 

- [Google Developers](https://developers.google.com/web/fundamentals/performance/http2/)

## Summmary

- Make applications faster, simpler, and more robust
- The primary goals for HTTP/2 are to reduce latency by enabling full request 
  and response multiplexing, minimize protocol overhead via efficient 
  compression of HTTP header fields, and add support for request prioritization 
  and server push.

## Components

- Binary framing layer
- Streams, messages, and frames
- Request and response multiplexing
  - With HTTP/1.x, if the client wants to make multiple parallel requests to 
    improve performance, then multiple TCP connections must be used. This 
    behavior is a direct consequence of the HTTP/1.x delivery model, which 
    ensures that only one response can be delivered at a time (response queuing) 
    per connection. Worse, this also results in head-of-line blocking and 
    inefficient use of the underlying TCP connection.
  - The new binary framing layer in HTTP/2 removes these limitations, and 
    enables full request and response multiplexing, by allowing the client and 
    server to break down an HTTP message into independent frames, interleave 
    them, and then reassemble them on the other end.
- Stream prioritization
- One connection per origin
- Flow Control
- Header compression
  - Each HTTP transfer carries a set of headers that describe the transferred 
    resource and its properties. In HTTP/1.x, this metadata is always sent as 
    plain text and adds anywhere from 500–800 bytes of overhead per transfer, 
    and sometimes kilobytes more if HTTP cookies are being used. (See Measuring 
    and Controlling Protocol Overhead .) To reduce this overhead and improve 
    performance, HTTP/2 compresses request and response header metadata
