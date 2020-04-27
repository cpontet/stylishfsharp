// 1 mile = 1760 yards
// 1 chain = 22 yards
// 1 yard = 0.9144 meter

// DONE: 1. Handle negative values 
// TODO: 2. Chains
// TODO: 3. Monoid

namespace StylishFSharp

open System

type MilesYards = MilesYards of wholeMiles : int * yeards : int

module MilesYards =

    let fromMilesPointYards (milesPointYards : float) : MilesYards =
        if milesPointYards < 0.0 then
            raise <| ArgumentOutOfRangeException("milesPointYards", "Must be >= 0.0")

        let wholeMiles = milesPointYards |> floor |> int
        let fraction = milesPointYards - float(wholeMiles)
        if fraction > 0.1759 then
            raise <| ArgumentOutOfRangeException("milesPointYards", "Fracional part must be <= 0.1759")
        
        let yards = fraction * 10_000. |> round |> int
        MilesYards(wholeMiles, yards)

    let toDecimalMiles (milesYards : MilesYards) : float =
        match milesYards with
        | MilesYards(wholeMiles, yards) ->
            (float wholeMiles) + ((float yards) / 1760.)
