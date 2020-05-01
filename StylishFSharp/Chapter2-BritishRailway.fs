// 1 mile = 1760 yards = 80 chains
// 1 chain = 22 yards
// 1 yard = 0.9144 meter

namespace StylishFSharp.Chapter2

open System

type MilesYards = MilesYards of wholeMiles : int * yeards : int with
    static member Zero = MilesYards(0, 0)
    static member (+) (a : MilesYards, b : MilesYards) =
        match a, b with
        | MilesYards(am, ay), MilesYards(bm, by) ->
            let totalMiles = am + bm
            let totalYards = ay + by
            let extraMiles = totalYards / 1760 |> int
            let remainingYards = totalYards - (extraMiles * 1760)

            MilesYards(totalMiles + extraMiles, remainingYards)

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


type MilesChains = MilesChains of wholeMiles : int * chains : int with
    static member Zero = MilesChains(0, 0)
    static member (+) (a : MilesChains, b : MilesChains) =
        match a, b with
        | MilesChains(am, ac), MilesChains(bm, bc) ->
            let totalMiles = am + bm
            let totalChains = ac + bc
            let extraMiles = totalChains / 80 |> int
            let remainingChains = totalChains - (extraMiles * 80)

            MilesChains(totalMiles + extraMiles, remainingChains)

module MilesChains =

    let fromMilesChains ( wholeMiles : int, chains : int ) : MilesChains =
        if wholeMiles < 0 then
            raise <| ArgumentOutOfRangeException("wholeMiles", "Must be >= 0")
        if chains < 0 || chains >= 80 then
            raise <| ArgumentOutOfRangeException("chains", "Must be >= 0 and < 80")
        MilesChains(wholeMiles, chains)
            
    let toDecimalMiles (MilesChains(wholeMiles, chains)) : float =
        (float wholeMiles) + ((float chains) / 80.)
