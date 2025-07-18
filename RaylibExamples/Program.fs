﻿open Raylib_cs
open RaylibExamples
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
                       "2d Camera Split screen"
                       "3d camera first person"
                       "3d camera free"
                       "3d Camera Mode"
                       "Input keys"
                       "Input Mouse"
                       "Input Multi Touch" 
                       "go back"
                       |]
                )

            match example with
            | "Basic Window" -> Core.basicWindow.run ()
            | "Basic Screen Manager" -> Core.BasicScreenManager.Main()
            | "2d camera" -> Core.Camera2dDemo.run ()
            | "2d Camera Split Screen" -> Core.CameraSpit2d.run
            | "3d camera first person"-> Core._3dCameraFirstPerson.run
            | "3d Camera Mode" -> Core.CameraMode3d.run
            | "3d camera free"-> Core.CameraFree3d.run
            | "Input keys" -> Core.InputKeys.run
            | "Input Mouse" -> Core.InputMouse.run
            | "Input Multi Touch" -> Core.InputMultitouch.run
            | _ |"go back"-> ()
        | "Shapes" ->
            let example =
                gemMenu (
                    "Select the example",
                    [| "Basic Shapes"
                       "Bouncing ball"
                       "Raylib Logo"
                       "Raylib Logo Animations"
                       "colors Palette"
                       "Rectangle Scaling"
                       "lines bezier"
                       "Collision Area" 
                       "Following Eyes"
                       "go back"
                       |]
                )

            match example with
            | "Basic Shapes" -> Shapes.BasicShapes.run
            | "Bouncing ball" -> Shapes.BouncingBall.run
            | "colors Palette" -> Shapes.ColorsPalette.run
            | "Raylib Logo" -> Shapes.Rayliblogo.run
            | "Raylib Logo Animations" -> Shapes.RayliblogoAnimation.run
            | "Rectangle Scaling" -> Shapes.RetangleScaling.run
            | "lines bezier" -> Shapes.LinesBezier.run
            | "Collision Area" -> Shapes.CollisionArea.run
            |"Following Eyes" -> Shapes.FollowingEyes.run 
            | _ |"go back"-> ()
        | _ -> ()

    0
