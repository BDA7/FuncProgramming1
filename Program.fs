module Program =
    open Functions
 
    [<EntryPoint>]
    let main argv =
        printfn "Project Euler 9"
        printfn $"Default func result: %i{findTriplet (1000)}"
        printfn $"Tail recursive func result: %i{recursionFind (1000)}"
        printfn "Project Euler 22"
        printfn $"Default func result: %i{counterNames}"
        printfn $"Recursive func result: %i{recursionCounter}"
        printfn $"Tail recursive func result: %i{tailRecursionCounter}"
        printfn $"Map func result: %i{mapCounter}"

        0
