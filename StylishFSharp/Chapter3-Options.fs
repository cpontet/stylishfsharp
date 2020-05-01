namespace StylishFSharp.Chapter3

module Delivery =

    type Delivery =
        | AsBilling
        | Physical of string
        | Download
        | ClickAndCollect of int

    type BillingDetails = {
        name : string
        billing : string
        delivery : Delivery
    }
    
    let tryDeliveryLabel (billingDetails : BillingDetails) =
        match billingDetails.delivery with
            | AsBilling -> billingDetails.billing |> Some
            | Physical address -> address |> Some
            | Download -> None
            | ClickAndCollect storeId -> sprintf "Store : %i"  storeId |> Some
            |> Option.map (fun address -> sprintf "%s\n%s" billingDetails.name address )

    let deliveryLabels (billingDetails : BillingDetails seq) =
        billingDetails |> Seq.choose tryDeliveryLabel

    let collectionFor (storeId : int) (billingDetails : BillingDetails seq) =
        billingDetails 
        |> Seq.choose (fun d -> 
            match d.delivery with
            | ClickAndCollect s when s = storeId -> Some d
            | _ -> None
        )

    let myOrder = {
        name = "Kit Eason"
        billing = "112 Fibonnaci Street\nErewhon\n35813"
        delivery = AsBilling
    }

    let hisOrder = {
        name = "John Doe"
        billing = "314 Pi Avenue\nErewhon\n15926"
        delivery = Physical "16 Planck Parkway\nErewhon\62291"
    }

    let herOrder = {
        name = "Jane Smith"
        billing = "9 Gravity Road\nErewhon\n80665"
        delivery = Download
    }

    let thisOrder = {
        name = "William Jones"
        billing = "18 Wherever Street\nSomewhereTown\n456343"
        delivery = ClickAndCollect 1
    }

    let yourOrder = {
        name = "Alison Chan"
        billing = "885 Electric Avenue\nSomewhereTown\4434234"
        delivery = ClickAndCollect 2
    }

    let theirOrder = {
        name = "Pana Okpik"
        billing = "299 Relativity Drive\nSomewhereTown\n23423"
        delivery = ClickAndCollect 2
    }

    // [ myOrder; hisOrder; herOrder; thisOrder; ] |> deliveryLabels;;
    [ myOrder; hisOrder; herOrder; thisOrder; yourOrder; theirOrder; ] |> collectionFor 2  |> Seq.iter (printfn "%A" );;
