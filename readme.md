# Google's ProtoBuf
This is a solution to serialize and deserialize objects. It is used by Google and pretends to be a standard to deal with unmanaged serial data (files, sockets, pipes...). Since this is a hot-topic in IO, I had to take a look.

In this repository I am performing a very basic example with a benchmark.

## Results

The IO speed is NOT amazing, yet it was very fast. It was not what I was expecting.

My hard-drive has a maximum reading capability for about 400Mb/s, using ProtoBuf I was able to read in a struct at a rate of 30Mb per second. I tried serializing lists and arrays but I could not speed up the reading.

On the good side, it is VERY easy to use and space efficient (unlike XML serialization). Definetly something to consider to speed up the development process for a heavy IO project.