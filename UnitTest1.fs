module Laboratory1

open NUnit.Framework
open Functions

[<SetUp>]
let Setup () = ()
let values = [|12; 220; 224; 644; 532; 1000; 2256|]
let results1 = [|60; 199980; 268800; 8027460; 5290740; 31875000; 57336240|]
let result2 = 870873746

[<TestFixture>]
type TestClass() =
    [<Test>]
    member this.``Test find triplet``() =
        for i=0 to values.Length-1 do
            assert (findTriplet (values[i]) = results1[i])

    [<Test>]
    member this.``Test tail recursion triplet``() =
        for i=0 to values.Length-1 do
            assert (recursionFind (values[i]) = results1[i])
            
    [<Test>]
    member this.``Test counter names``() =
        assert (counterNames = result2)
    
    [<Test>]
    member this.``Test map counter``() =
        assert (mapCounter = result2)
    
    [<Test>]
    member this.``Test recursion counter``() =
        assert (recursionCounter = result2)

    [<Test>]
    member this.``Test tail recursion counter``() =
        assert (tailRecursionCounter = result2)