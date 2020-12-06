# Google's ProtoBuf
This is a solution to serialize and deserialize objects. It is used by Google and pretends to be a standard to deal with unmanaged serial data (files, sockets, pipes...). Since this is a hot-topic in IO, I had to take a look.

In this repository I am performing a very basic example with a benchmark.

## Results

The IO speed is below-average.

My hard-drive has a maximum reading capability for about 750Mb/s, using ProtoBuf I was able to read in a struct at a rate of 31Mb per second (in release build). I tried serializing lists and arrays but I could not speed up the reading.

One work around would be separating the reading and the struct generation in threads.

On the good side, it is very easy to use, safe, and space efficient (unlike XML serialization). Definetly something to consider to speed up the development process for a heavy IO project.