﻿module Examples.ChordParser.ChordParserView

open System
open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Controls.ApplicationLifetimes
open Avalonia.FuncUI.Components
open Avalonia.Layout
open Avalonia.Media
open Avalonia.Controls
open Avalonia.FuncUI.DSL
open Avalonia.FuncUI.Types
open Avalonia.FuncUI
open ChordParser

type Model = 
    { 
        InputChordChart: string
        OutputChordChart: Result<string, string> 
        Transpose: int
        Accidental: string
        UCase: bool
    }

let initModel = 
    { 
        InputChordChart = 
#if DEBUG
            "(Bmaj7) Ooo Gustens,    you just (A#) so  (G)\n" +
            "Dang   (Dmin7 /G) Baaad."
#else
            ""
#endif
        OutputChordChart = Ok ""
        Transpose = 0
        Accidental = "b"
        UCase = false
    }

let cmp () = Component (fun ctx ->
    let model = ctx.useState (initModel, true)

    let setInputChart input = 
        model.Set { model.Current with InputChordChart = input }

    let parseChart () = 
        { model.Current with 
            OutputChordChart = 
                ChordParser.App.tryProcessText 
                    model.Current.Transpose model.Current.Accidental model.Current.UCase model.Current.InputChordChart }
        |> model.Set

    let transposeUp () = 
        if model.Current.Transpose < 11 then 
            { model.Current with Transpose = model.Current.Transpose + 1 } |> model.Set
            parseChart ()

    let transposeDown () = 
        if model.Current.Transpose > -11 then 
            { model.Current with Transpose = model.Current.Transpose - 1 } |> model.Set
            parseChart ()
    
    Grid.create [
        Grid.rowDefinitions "20, *"
        Grid.columnDefinitions "*, 80, *"
        Grid.children [
            // Row labels
            TextBlock.create [
                TextBlock.text "Input Chord Chart"
                Grid.column 0
            ]
            TextBlock.create [
                TextBlock.text "Output Chord Chart"
                Grid.column 2
            ]

            // Row: inputs
            // Input Chord Chart
            TextBox.create [
                TextBox.text model.Current.InputChordChart
                TextBox.onTextChanged (fun txt -> setInputChart txt)
                Grid.column 0
                Grid.row 1
            ]

            // Middle Column (Settings)
            StackPanel.create [
                Grid.column 1
                Grid.row 1

                StackPanel.children [
                    Button.create [
                        Button.content "▲"
                        Button.width 20
                        Button.onClick (fun e -> transposeUp ())
                    ]

                    TextBlock.create [
                        TextBlock.text (string model.Current.Transpose)
                        TextBlock.horizontalAlignment HorizontalAlignment.Center
                    ]

                    Button.create [
                        Button.content "▼"
                        Button.width 20
                        Button.onClick (fun e -> transposeDown ())
                    ]
                ]
            ]

            // Output Chord Chart
            TextBox.create [
                TextBox.text 
                    <|  match model.Current.OutputChordChart with
                        | Ok output -> output
                        | Error err -> err
                TextBox.verticalAlignment VerticalAlignment.Stretch
                TextBox.isReadOnly true
                Grid.column 2
                Grid.row 1
            ]

        ]
    ]
    :> IView
)
