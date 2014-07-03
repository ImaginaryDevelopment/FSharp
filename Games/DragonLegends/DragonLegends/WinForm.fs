module WinForm
open System.Drawing
open System.Windows.Forms

let RunWinForm() =
    use form =
            let temp = new Form(MinimumSize = new Size(80,80))
            temp.Resize.Add(fun _ -> temp.Invalidate())
            let brush = new SolidBrush(Color.SkyBlue)
            temp.Paint.Add( fun e-> 
                let width,height = temp.Width-54, temp.Height-54
                e.Graphics.FillPie(brush,32,32,width,height,0,290))
            temp
    Application.Run(form)
