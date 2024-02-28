namespace RaylibExamples.Core

open System.Numerics
open Raylib_cs
open type Raylib_cs.Raylib

module InputKeys =
    let run =
        let screenWidth = 800
        let screenHeight = 450

        InitWindow(screenWidth, screenHeight, "raylib [core] example - keyboard input")

        let mutable ballPosition =
            Vector2(float32 (screenWidth / 2), float32 (screenHeight / 2))

        SetTargetFPS(60)

        while not (WindowShouldClose()) do
            if not (not (IsKeyDown(KeyboardKey.Right))) then
                ballPosition.X <- ballPosition.X + 2.0f

            if not (not (IsKeyDown(KeyboardKey.Left))) then
                ballPosition.X <- ballPosition.X - 2.0f

            if not (not (IsKeyDown(KeyboardKey.Up))) then
                ballPosition.Y <- ballPosition.Y - 2.0f

            if not (not (IsKeyDown(KeyboardKey.Down))) then
                ballPosition.Y <- ballPosition.Y + 2.0f

            BeginDrawing()

            ClearBackground(Color.RayWhite)

            DrawText("move the ball with arrow keys", 10, 10, 20, Color.DarkGray)

            DrawCircleV(ballPosition, 50f, Color.Maroon)

            EndDrawing()

        CloseWindow()
