module FSharp.Charting
open System.Windows.Forms
open FSharp.Charting

type FSharp.Charting.ChartTypes.GenericChart with 
    member this.CreateForm ()= 
        let frm = new Form(Visible = true, TopMost = true, Width = 700, Height = 500, WindowState=FormWindowState.Maximized)
        let ctl = new FSharp.Charting.ChartTypes.ChartControl(this, Dock = DockStyle.Fill)
        frm.Controls.Add(ctl)
        frm.Show()
        ctl.Focus() |> ignore
        frm
