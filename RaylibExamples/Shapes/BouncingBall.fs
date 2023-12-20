namespace RaylibExamples.Shapes

open System
open System.Numerics
open Raylib_cs
open type Raylib_cs.Raylib


module BouncingBall =
    let run =

        let screenWidth = 800
        let screenHeight = 450

        SetConfigFlags(ConfigFlags.FLAG_MSAA_4X_HINT)
        InitWindow(screenWidth, screenHeight, "raylib [shapes] example - bouncing ball")

        let mutable ballPosition =
            Vector2(float32 ((GetScreenWidth() / 2)), float32 (GetScreenHeight() / 2))

        let mutable ballSpeed = Vector2(5.0f, 4.0f)

        let ballRadius = 20

        let mutable pause = false
        let mutable frameCounter = 0

        SetTargetFPS(60)

        while not (WindowShouldClose()) do
            if not (not (IsKeyPressed(KeyboardKey.KEY_SPACE))) then
                pause <- not pause

            if not pause then
                ballPosition.X <- ballSpeed.X + ballPosition.X
                ballPosition.Y <- ballSpeed.Y + ballPosition.Y

                if
                    (ballPosition.X >= float32 (GetScreenWidth() - ballRadius))
                    || (ballPosition.X <= float32 (ballRadius))
                then
                    ballSpeed.X <- ballSpeed.X * -1.0f

                if
                    (ballPosition.Y >= float32 (GetScreenHeight() - ballRadius))
                    || (ballPosition.Y <= float32 (ballRadius))
                then
                    ballSpeed.Y <- ballSpeed.Y * -1.0f

            else
                frameCounter <- frameCounter + 1

            BeginDrawing()

            ClearBackground(Color.RAYWHITE)

            DrawCircleV(ballPosition, float32 (ballRadius), Color.MAROON)

            if pause && (0 = (frameCounter / 30) % 2) then
                DrawText("PAUSED", 350, 200, 30, Color.GRAY)

            EndDrawing()

        CloseWindow()
