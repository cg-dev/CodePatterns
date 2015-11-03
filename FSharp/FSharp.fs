module FSharp

#light  // Compiler directive that simplfies the syntax of the language

let square x = x * x // Defines a function called square which takes a single parameter and squares it. No need to define types as they are inferred.
let concat (x : string) y = x + " " + y

let numbers = [1 .. 10] //

let squares = List.map square numbers //

printfn "N^2 = %A"squares //

printfn "%s" (concat "Hello" "World!")

open System
Console.ReadKey(true)