namespace FSharpWpfMvvmTemplate.ViewModel

open System
open System.Collections.ObjectModel
open System.Windows
open System.Windows.Data
open System.Windows.Input
open System.ComponentModel
open Pm.UI.ViewModel

type MainWindowViewModel(resolver) =
    inherit ViewModelBase()
    let resolver = resolver
    let mutable frameSource = "IcdGemExplorer.xaml"  
    let codes = System.Collections.Generic.Dictionary<string,string>()
    member x.FrameSource 
        with get() = frameSource
        and set v = 
            frameSource <- v
            x.OnPropertyChanged "FrameSource"
//    member x.Resolve<'t> () = 
//        match typeof<'t>.Name with
//        | "IcdConverterViewModel" -> IcdConverterViewModel(codes) |> box
//        | "ExpenseItHomeViewModel" -> ExpenseItHomeViewModel() |> box
//        | _ as x -> failwithf "Unmatched dependency type %s" x
//        :?> 't
 