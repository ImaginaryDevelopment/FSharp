module PrimitiveExtensions

type System.Int32 with
    member this.IsEven = this % 2 = 0
