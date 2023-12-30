open Raylib_cs
open RaylibExamples.Core
open Spectre.Console
open System

let gemMenu (title: string, choices: array<string>) =
    let mutable ask = new SelectionPrompt<string>()
    ask.AddChoices(choices) |> ignore
    ask.Title <- title
    AnsiConsole.Prompt(ask)

[<EntryPoint>]
let main Void =
    let mutable running = true

    while running do
        Console.Clear()

        AnsiConsole.Write(new Rule())

        let mutable mainMenuOption =
            gemMenu ("Select the Raylib category of example:", [| "Core"; "Shapes"; "Exit" |])

        match mainMenuOption with
        | "Exit" -> Environment.Exit(0)
        | "Core" ->
            let example =
                gemMenu (
                    "Select the example",
                    [| "Basic Window"
                       "Basic Screen Manager"
                       "2d camera"
                       "2d Camera Split Screen"
                       "3d Camera Mode"
                       "Input keys"
                       "Input Mouse"
                       "Input Multi Touch" |]
                )

            match example with
            | "Basic Window" -> RaylibExamples.Core.basicWindow.run ()
            | "Basic Screen Manager" -> RaylibExamples.Core.BasicScreenManager.Main()
            | "2d camera" -> RaylibExamples.Core.Camera2dDemo.run ()
            | "2d Camera Split Screen" -> RaylibExamples.Core.CameraSpit2d.run
            | "3d Camera Mode" -> RaylibExamples.Core.CameraMode3d.run
            | "Input keys" -> RaylibExamples.Core.InputKeys.run
            | "Input Mouse" -> RaylibExamples.Core.InputMouse.run
            | "Input Multi Touch" -> RaylibExamples.Core.InputMultitouch.run
            | _ -> ()
        | "Shapes" ->
            let example =
                gemMenu (
                    "Select the example",
                    [| "Basic Shapes"
                       "Bouncing ball"
                       "Raylib Logo"
                       "Raylib Logo Animations"
                       "colors Palette"
                       "lines bezier"
                       "Rectangle Scaling" |]
                )

            match example with
            | "Basic Shapes" -> RaylibExamples.Shapes.BasicShapes.run
            | "Bouncing ball" -> RaylibExamples.Shapes.BouncingBall.run
            | "colors Palette" -> RaylibExamples.Shapes.ColorsPalette.run
            | "Raylib Logo" -> RaylibExamples.Shapes.Rayliblogo.run
            | "Raylib Logo Animations" -> RaylibExamples.Shapes.RayliblogoAnimation.run
            | "Rectangle Scaling" -> RaylibExamples.Shapes.RetangleScaling.run
            | "lines bezier" -> RaylibExamples.Shapes.LinesBezier.run
            | _ -> ()
        | _ -> ()

    0
