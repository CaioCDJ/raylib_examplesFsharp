namespace RaylibExamples.Core

open System
open type Raylib_cs.Raylib

module basicWindow =

    let run () =

        let screenWidth = 800
        let screenHeight = 450

        InitWindow(screenWidth, screenHeight, "Window Title")

        SetTargetFPS(60)

        while not (WindowShouldClose()) do

            BeginDrawing()
            ClearBackground(Raylib_cs.Color.RayWhite)

            DrawText("I will not say hello world for the 100th time", 190, 200, 20, Raylib_cs.Color.Magenta)

            EndDrawing()

        CloseWindow()
