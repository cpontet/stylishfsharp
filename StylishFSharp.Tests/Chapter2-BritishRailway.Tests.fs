namespace StylishFSharp.Chapter2

open System
open Xunit
open FsUnit.Xunit
open StylishFSharp.Chapter2

module MilesYardsTests =

    let ShouldEqual(milesYards : MilesYards, wholeMiles : int, yards : int) =
        match milesYards with
        | MilesYards(m, y) ->
            m |> should equal wholeMiles 
            y |> should equal yards

    [<Fact>]
    let ``0 point 0 is 0 miles and 0 yards`` () =
        let milesYards = MilesYards.fromMilesPointYards(0.0) 
        ShouldEqual(milesYards, 0, 0)

    [<Fact>]
    let ``1 point 1759 is 1 mile and 1759 yards`` () =
        let milesYards = MilesYards.fromMilesPointYards(1.1759) 
        ShouldEqual(milesYards, 1, 1759)

    [<Fact>]
    let ``Yard fraction cannot be 1760 or more`` () =
        (fun() -> MilesYards.fromMilesPointYards(1.1760) |> ignore) |> should throw typeof<ArgumentOutOfRangeException>

    [<Fact>]
    let ``Negative value is not valid`` () =
        (fun() -> MilesYards.fromMilesPointYards(-1.0) |> ignore) |> should throw typeof<ArgumentOutOfRangeException>
    
    [<Fact>]
    let ``1 mile 880 yards is 1 and a half miles`` () =
        let milesYards = MilesYards.fromMilesPointYards(1.0880) 
        let decimalMiles = MilesYards.toDecimalMiles(milesYards)
        Assert.Equal(1.5, decimalMiles)

    [<Fact>]
    let ``MilesYards monoid zero`` () =
        Assert.True(MilesYards.Zero + MilesYards.Zero = MilesYards.Zero)

    [<Fact>]
    let ``MilesYards monoid identity`` () =
        Assert.True(MilesYards.Zero + MilesYards.fromMilesPointYards(1.0880) = MilesYards.fromMilesPointYards(1.0880))

    [<Fact>]
    let ``1 mile 880 yards plus 1 mile 880 yards equals 3 miles`` () =
        Assert.True(MilesYards.fromMilesPointYards(1.0880) + MilesYards.fromMilesPointYards(1.0880) = MilesYards.fromMilesPointYards(3.0))

    [<Fact>]
    let ``1 mile 1759 yards plus 1 yard equals 2 miles`` () =
        Assert.True(MilesYards.fromMilesPointYards(1.1759) + MilesYards.fromMilesPointYards(0.0001) = MilesYards.fromMilesPointYards(2.0))

    [<Fact>]
    let ``Monoid associativity`` () =
        Assert.True(
        ((MilesYards.fromMilesPointYards(1.0001) + MilesYards.fromMilesPointYards(1.0002)) + MilesYards.fromMilesPointYards(1.0003))
            = 
            (MilesYards.fromMilesPointYards(1.0001) + (MilesYards.fromMilesPointYards(1.0002) + MilesYards.fromMilesPointYards(1.0003)))
        )

module MilesChainsTests =

    [<Fact>]
    let ``80 chaines equal 1 mile`` () =
        Assert.True(MilesChains.fromMilesChains(0, 30) + MilesChains.fromMilesChains(0, 50) = MilesChains.fromMilesChains(1, 0))

    [<Fact>]
    let ``120 chaines equal 1 and a half mile`` () =
        let milesChains = MilesChains.fromMilesChains(0, 70) + MilesChains.fromMilesChains(0, 50)
        let decimalMiles = MilesChains.toDecimalMiles(milesChains)
        decimalMiles |> should equal 1.5

    [<Fact>]
    let ``MilesChains monoid identity`` () =
        Assert.True(MilesChains.fromMilesChains(1, 1) + MilesChains.Zero = MilesChains.fromMilesChains(1, 1))

    [<Fact>]
    let ``Negative wholeMiles value is not valid for MilesChains`` () =
        (fun() -> MilesChains.fromMilesChains(-1, 0) |> ignore) |> should throw typeof<ArgumentOutOfRangeException>

    [<Fact>]
    let ``Negative chains value is not valid for MilesChains`` () =
        (fun() -> MilesChains.fromMilesChains(0, -1) |> ignore) |> should throw typeof<ArgumentOutOfRangeException>

    [<Fact>]
    let ``80 chains value is not valid for MilesChains`` () =
        (fun() -> MilesChains.fromMilesChains(0, 80) |> ignore) |> should throw typeof<ArgumentOutOfRangeException>
    