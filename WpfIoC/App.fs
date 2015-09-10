module MainApp

open System
open System.Windows
open System.Windows.Controls
open System.Windows.Markup
open FSharpWpfMvvmTemplate.ViewModel
open Pm.UI.ViewModel

// Create the View and bind it to the View Model
let mainWindowViewModel = Application.LoadComponent(
                             new System.Uri("/App;component/mainwindow.xaml", UriKind.Relative)) :?> Window
let compositionRoot<'a> () = 
    let codes = System.Collections.Generic.Dictionary<string,string>()
    match typeof<'a>.Name with
        | "IcdConverterViewModel" -> IcdConverterViewModel(codes) |> box
        | "ExpenseItHomeViewModel" -> ExpenseItHomeViewModel() |> box
        | _ as x -> failwithf "Unmatched dependency type %s" x
        :?> 'a
    
mainWindowViewModel.DataContext <- new MainWindowViewModel(compositionRoot) 

// Application Entry point
[<STAThread>]
[<EntryPoint>]
let main(_) = (new Application()).Run(mainWindowViewModel)