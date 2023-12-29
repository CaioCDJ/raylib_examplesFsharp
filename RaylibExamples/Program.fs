open Raylib_cs
open RaylibExamples.Core
open Spectre.Console
open System

let coreMenu string =
    let CoreChoices = new SelectionPrompt<string>()

    CoreChoices.AddChoices(
        [| "Basic Window"
           "Basic Screen Manager"
           "2d camera"
           "2d Camera Split Screen"
           "3d Camera Mode"
           "Input keys"
           "Input Mouse" |]
    )

    let res = AnsiConsole.Prompt(CoreChoices)
    res

let shapesMenu string =
    let shapesChoices = new SelectionPrompt<string>()

    shapesChoices.AddChoices([| "Basic Shapes"; "Bouncing ball"; "colors Palette"; "lines bezier" |])

    let res = AnsiConsole.Prompt(shapesChoices)
    res


[<EntryPoint>]
let main int =
    let mutable running = true

    while running do
        Console.Clear()

        let mutable choices = new SelectionPrompt<string>()

        choices.Title <- "Select the Raylib category of example:"
        choices.AddChoices([| "Core"; "Shapes"; "Exit" |]) |> ignore

        let mainMenuOption = AnsiConsole.Prompt(choices)
        printf $"{mainMenuOption}"

        match mainMenuOption with
        | "Exit" ->
            Environment.Exit(0)
            0
        | "Core" ->
            let example = coreMenu ()

            match example with
            | "Basic Window" -> RaylibExamples.Core.basicWindow.run ()
            | "Basic Screen Manager" -> RaylibExamples.Core.BasicScreenManager.Main()
            | "2d camera" -> RaylibExamples.Core.Camera2dDemo.run ()
            | "2d Camera Split Screen" -> RaylibExamples.Core.CameraSpit2d.run
            | "3d Camera Mode" -> RaylibExamples.Core.CameraMode3d.run
            | "Input keys" -> RaylibExamples.Core.InputKeys.run
            | "Input Mouse" -> RaylibExamples.Core.InputMouse.run

            0
        | "Shapes" ->
            let example = shapesMenu ()

            match example with
            | "Basic Shapes" -> RaylibExamples.Shapes.BasicShapes.run
            | "Bouncing ball" -> RaylibExamples.Shapes.BouncingBall.run
            | "colors Palette" -> RaylibExamples.Shapes.ColorsPalette.run
            | "lines bezier" -> RaylibExamples.Shapes.LinesBezier.run
            0
        0
    0
