module WinForm

open System.Drawing
open System.Windows.Forms

open Shapes
type System.Drawing.Graphics with
    member x.DrawRect pen (left:int<X>,top:int<Y>) (width:int<X>) (height:int<Y>) =
        x.DrawRectangle(pen,int(left),int(top),int(width),int(height))

let draw (g:System.Drawing.Graphics) (ds:DrawableShape) =
    
    match ds.Shape with
    | Rectangle(x,y) -> 
        use brush = new SolidBrush(ds.Color)
        use pen = new Pen(brush)
        
        g.DrawRect pen ds.TopLeft x y
    | Circle(radius) -> ()
    //| _ -> ()
let RunWinForm (shapes:Shapes.DrawableShape list) =
    use form =
            let temp = new Form(MinimumSize = new Size(80,80))
            temp.Resize.Add(fun _ -> temp.Invalidate())
            let brush = new SolidBrush(Color.SkyBlue)
            temp.Paint.Add( fun e-> 
                                let width,height = temp.Width-54, temp.Height-54
                                e.Graphics.FillPie(brush,32,32,width,height,0,290)
                                shapes |> List.iter (fun s -> draw e.Graphics s)
                )
            temp
    Application.Run(form)
