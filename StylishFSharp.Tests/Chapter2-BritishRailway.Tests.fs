
module MilesYardsTests

open System
open Xunit
open FsUnit.Xunit
open StylishFSharp

let ShouldEqual(milesYards : MilesYards, wholeMiles : int, yards : int) =
    match milesYards with
    | MilesYards(m, y) ->
        m |> should equal wholeMiles 
        y |> should equal yards

[<Fact>]
let ``0.0 is 0 miles and 0 yards`` () =
    let milesYards = MilesYards.fromMilesPointYards(0.0) 
    ShouldEqual(milesYards, 0, 0)

[<Fact>]
let ``1.1759 is 1 mile and 1759 yards`` () =
    let milesYards = MilesYards.fromMilesPointYards(1.1759) 
    ShouldEqual(milesYards, 1, 1759)

[<Fact>]
let ``Yard fraction cannot be 1760 or more`` () =
    (fun() -> MilesYards.fromMilesPointYards(1.1760) |> ignore) |> should throw typeof<ArgumentOutOfRangeException>

[<Fact>]
let ``Negative value is not valid`` () =
    (fun() -> MilesYards.fromMilesPointYards(-1.0) |> ignore) |> should throw typeof<ArgumentOutOfRangeException>
    
[<Fact>]
let ``1.0880 is 1.5 miles`` () =
    let milesYards = MilesYards.fromMilesPointYards(1.0880) 
    let decimalMiles = MilesYards.toDecimalMiles(milesYards)
    Assert.Equal(1.5, decimalMiles)

 