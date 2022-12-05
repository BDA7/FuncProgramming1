module Laboratory1

open NUnit.Framework
open Functions

[<SetUp>]
let Setup () = ()

[<TestFixture>]
type TestClass() =
    [<Test>]
    member this.Test1() =
        assert (findTriplet (12) = 60)
        assert (recursionFind (12) = 60)
        assert (findTriplet (644) = 8027460)
        assert (recursionFind (644) = 8027460)
        assert (findTriplet (1000) = 31875000)
        assert (recursionFind (1000) = 31875000)
        assert (findTriplet (2256) = 57336240)
        assert (recursionFind (2256) = 57336240)
        Assert.Pass()

    [<Test>]
    member this.Test2() =
        assert (mapCounter = 870873746)
        assert (counterNames = 870873746)
        assert (recursionCounter = 870873746)
        assert (tailRecursionCounter = 870873746)
        Assert.Pass()
