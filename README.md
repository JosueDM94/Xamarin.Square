# Xamarin.Square
[![Build Status](https://dev.azure.com/JosueDM94/Xamarin.Square/_apis/build/status/JosueDM94.Xamarin.Square?branchName=master)](https://dev.azure.com/JosueDM94/Xamarin.Square/_build/latest?definitionId=4&branchName=master)

Xamarin.Android and Xamarin.iOS bindings for the various https://github.com/square libraries

This repository is based on https://github.com/mattleibow/square-bindings to keep updating or adding Square Libraries

## How to build
```
sh bootstrapper.sh --target nuget
```

*OPTIONS*
- externals     Download external (native) libraries
- libs          Build the code
- nuget         Create nuget packages
- samples       Build samples
- fast          Shortcut for nuget
- default       Shortcut for all previous steps

## Libraries
Bound:

  - **OkHttp3** - https://github.com/square/okhttp3  
    An HTTP+SPDY client for Android and Java applications  
   | [binding][1] | [sample][11] | [NuGet][21] |  
 - **OkIO** - https://github.com/square/okio  
   A modern I/O API for Java  
   | [binding][2] | [sample][11] | [NuGet][22] |  

[1]:  https://github.com/JosueDM94/Xamarin.Square/tree/master/binding/Square.OkHttp
[2]:  https://github.com/JosueDM94/Xamarin.Square/tree/master/binding/Square.OkIO
[11]:  https://github.com/JosueDM94/Xamarin.Square/tree/master/sample/OkHttp3Sample
[21]: https://www.nuget.org/packages/Xamarin.Square.OkHttp3
[22]: https://www.nuget.org/packages/Xamarin.Square.OkIO
