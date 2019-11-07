namespace Examples.GameOfLife

module Main =
    open Avalonia.Controls
    open Avalonia.FuncUI.DSL
    open Avalonia.Layout
    open Avalonia.Threading
    open System
    open Elmish
    
    type State =
        { board : BoardMatrix
          evolutionRunning : bool }
        
    let initialState() =
        { board = BoardMatrix.constructBlank(50, 50)
          evolutionRunning = true }, Cmd.none

    type Msg =
    | BoardMsg of Board.Msg   
    | StartEvolution
    | StopEvolution

    let timer (state: State) =
        let sub (dispatch: Msg -> 'a) =
            let invoke() =
                Board.Evolve |> BoardMsg |> dispatch
                true
                    
            DispatcherTimer.Run(Func<bool>(invoke), TimeSpan.FromSeconds 1.0)
            ()
        Cmd.ofSub sub
    
    let update (msg: Msg) (state: State) : State * Cmd<_>=
        match msg with
        | StartEvolution -> { state with evolutionRunning = true }, Cmd.none
        | StopEvolution -> { state with evolutionRunning = false }, Cmd.none
        | BoardMsg msg ->
            match msg with
            | Board.Evolve ->
                if state.evolutionRunning then
                   { state with board = Board.update msg state.board }, Cmd.none
                else
                    state, Cmd.none
            | _ -> { state with board = Board.update msg state.board }, Cmd.none
    
    let view (state: State) (dispatch: Msg -> unit) =
        DockPanel.create [
            DockPanel.children [
                Button.create [
                    Button.isVisible state.evolutionRunning
                    Button.dock Dock.Bottom
                    Button.background "green"
                    Button.onClick (fun _ -> StartEvolution |> dispatch)
                    Button.content "start"
                ]                
                Button.create [
                    Button.isVisible (not state.evolutionRunning)
                    Button.dock Dock.Bottom
                    Button.background "red"
                    Button.onClick (fun _ -> StopEvolution |> dispatch)
                    Button.content "stop"
                ]
                Board.view state.board (BoardMsg >> dispatch ) 
            ]
        ]       