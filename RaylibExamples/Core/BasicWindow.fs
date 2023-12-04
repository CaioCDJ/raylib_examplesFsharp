namespace RaylibExamples.Core

open System
open Raylib_cs

module basicWindow =

    let run () =

        let screenWidth = 800
        let screenHeight = 450

        Raylib.InitWindow(screenWidth, screenHeight, "Window Title")

        Raylib.SetTargetFPS(60)

        while not (Raylib.WindowShouldClose()) do

            Raylib.BeginDrawing()
            Raylib.ClearBackground(Color.RAYWHITE)

            Raylib.DrawText("I will not say hello world for the 100th time", 190, 200, 20, Color.MAGENTA)

            Raylib.EndDrawing()

        Raylib.CloseWindow()
