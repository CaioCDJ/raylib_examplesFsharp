namespace RaylibExamples.Core

open System.Numerics
open Raylib_cs
open type Raylib_cs.Raylib

module InputMouse =
    let run =
        let screenWidth = 800
        let screenHeight = 450

        InitWindow(screenWidth, screenHeight, "raylib [core] example - mouse input")

        let mutable ballPosition = Vector2(-100.0f, -100.0f)
        let mutable ballColor = Color.DarkBlue

        SetTargetFPS(60)

        while not (WindowShouldClose()) do
            ballPosition <- GetMousePosition()

            if not (not (IsMouseButtonPressed(MouseButton.Left))) then
                ballColor <- Color.Maroon
            else if not (not (IsMouseButtonDown(MouseButton.Middle))) then
                ballColor <- Color.Lime
            else if not (not (IsMouseButtonDown(MouseButton.Right))) then
                ballColor <- Color.DarkBlue
            else if not (not (IsMouseButtonDown(MouseButton.Side))) then
                ballColor <- Color.Purple
            else if not (not (IsMouseButtonDown(MouseButton.Extra))) then
                ballColor <- Color.Yellow
            else if not (not (IsMouseButtonDown(MouseButton.Forward))) then
                ballColor <- Color.Orange
            else if not (not (IsMouseButtonDown(MouseButton.Back))) then
                ballColor <- Color.Beige

            BeginDrawing()

            ClearBackground(Color.RayWhite)

            DrawCircleV(ballPosition, 40f, ballColor)

            DrawText("move ball with mouse and click mouse button to change color", 10, 10, 20, Color.DarkGray)
            EndDrawing()

        CloseWindow()
