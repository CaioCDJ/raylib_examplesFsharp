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
            if not (not (IsKeyDown(KeyboardKey.KEY_RIGHT))) then
                ballPosition.X <- ballPosition.X + 2.0f

            if not (not (IsKeyDown(KeyboardKey.KEY_LEFT))) then
                ballPosition.X <- ballPosition.X - 2.0f

            if not (not (IsKeyDown(KeyboardKey.KEY_UP))) then
                ballPosition.Y <- ballPosition.Y - 2.0f

            if not (not (IsKeyDown(KeyboardKey.KEY_DOWN))) then
                ballPosition.Y <- ballPosition.Y + 2.0f

            BeginDrawing()

            ClearBackground(Color.RAYWHITE)

            DrawText("move the ball with arrow keys", 10, 10, 20, Color.DARKGRAY)

            DrawCircleV(ballPosition, 50f, Color.MAROON)

            EndDrawing()

        CloseWindow()
