module Functions

open System

let pythagoreanTriplets top =
    [ for m in 1..top do
          for n in 1 .. m - 1 do
              let a = m * m - n * n
              let b = 2 * m * n
              let c = m * m + n * n
              yield [ a; b; c ] ]

let multiplyList list = List.fold (*) 1 list

let findTriplet sum =
    pythagoreanTriplets sum
    |> List.find (fun [ a; b; c ] -> a + b + c = sum)
    |> multiplyList

let public recursionFind (sum: int) =
    let rec findA (a: int, sum: int) =
        let rec findB (b: int, sum: int) =
            let c: int = sum - a - b

            if (float (a) ** 2.0 + float (b) ** 2.0) = float (c) ** 2.0 then
                (a * b * c)
            else if (b < 0) then
                0
            else
                findB (b - 1, sum)

        let resultForB = findB (sum - a, sum)

        if (resultForB > 0) then resultForB
        else if (a < 0) then 0
        else findA (a - 1, sum)

    findA (sum - 1, sum)


// Project Euler 22
let private readArray =
    let text =
        IO.File.ReadAllText(__SOURCE_DIRECTORY__ + @"/" + "names.txt")

    let words = text.Split(',') |> Array.sort
    words


let private getAsciiValue (chr: char) =
    if chr = 'A' then 1
    elif chr = 'B' then 2
    elif chr = 'C' then 3
    elif chr = 'D' then 4
    elif chr = 'E' then 5
    elif chr = 'F' then 6
    elif chr = 'G' then 7
    elif chr = 'H' then 8
    elif chr = 'I' then 9
    elif chr = 'J' then 10
    elif chr = 'K' then 11
    elif chr = 'L' then 12
    elif chr = 'M' then 13
    elif chr = 'N' then 14
    elif chr = 'O' then 15
    elif chr = 'P' then 16
    elif chr = 'Q' then 17
    elif chr = 'R' then 18
    elif chr = 'S' then 19
    elif chr = 'T' then 20
    elif chr = 'U' then 21
    elif chr = 'V' then 22
    elif chr = 'W' then 23
    elif chr = 'X' then 24
    elif chr = 'Y' then 25
    elif chr = 'Z' then 26
    else 0


let public counterNames =
    let mutable allCounter = 0
    let rArray = readArray

    for i = 0 to rArray.Length - 1 do
        let mutable charValueCounter = 0

        let chooseStr =
            rArray[i] |> String.map Char.ToUpper

        chooseStr
        |> Seq.iter (fun x -> charValueCounter <- charValueCounter + getAsciiValue (x))

        charValueCounter <- charValueCounter * i
        allCounter <- charValueCounter + allCounter

    allCounter

let private scoreGoal (index: int, stringUsed: String) =
    let summaryChars =
        stringUsed
        |> String.map Char.ToUpper
        |> Seq.sumBy (fun x -> getAsciiValue (x))
    // |> Seq.map (fun x -> getAsciiValue (x))
    // |> Seq.sum

    (summaryChars * index)

let public mapCounter =
    let arr = readArray

    let summary =
        Seq.init arr.Length (fun x -> scoreGoal (x, arr[x]))
        |> Seq.sum

    summary

let public recursionCounter =
    let arr = readArray

    let stringReader (str: String, n: int) =
        let rec score i =
            if (i < 0) then
                0
            else
                getAsciiValue (str[i]) + score (i - 1)

        score (n)

    let rec valueRec len =
        if (len < 0) then
            0
        else
            len
            * stringReader (arr[ len ].ToUpper(), arr[len].Length - 1)
            + valueRec (len - 1)

    valueRec (arr.Length - 1)


let public tailRecursionCounter =
    let arr = readArray

    let rec scoreTail (idx: int, sum: int) =
        if (idx < 0) then
            sum
        else
            scoreTail (idx - 1, sum + scoreGoal (idx, arr[idx]))

    scoreTail (arr.Length - 1, 0)
