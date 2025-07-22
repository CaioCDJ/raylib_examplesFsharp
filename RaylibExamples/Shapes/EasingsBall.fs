namespace RaylibExamples.Shapes

open System
open System.Numerics
open Raylib_cs
open RaylibExamples.Shared.Util
open RaylibExamples.Shared.Easinngs
open type Raylib_cs.Raylib

module EasingsBall =

    let run =
        let screenWidth = 800
        let screenHeight = 450

        InitWindow(screenWidth, screenHeight, "raylib [shapes] example - easings ball anim")

        let mutable ballPositionX = -100
        let mutable ballRadius = 20
        let mutable ballAlpha = 0f

        let mutable state = 0
        let mutable frameCounter = 0

        SetTargetFPS(60)

        while not (WindowShouldClose()) do

            match state with
            | 0 -> // Move ball position X with easing
                frameCounter <- frameCounter + 1
                let normalizedT = float32 frameCounter / 120f // Normalize the time over 120 frames
                ballPositionX <- int (EaseElasticOut(normalizedT, -100f, float32 screenWidth / 2.0f + 100f, 120f))

                if frameCounter >= 120 then
                    frameCounter <- 0
                    state <- 1
            | 1 -> // Increase ball radius with easing
                frameCounter <- frameCounter + 1
                let normalizedT = float32 frameCounter / 200f // Normalize the time over 200 frames
                ballRadius <- int (EaseElasticIn(normalizedT, 20f, 500f, 200f))

                if frameCounter >= 200 then
                    frameCounter <- 0
                    state <- 2
            | 2 -> // Change ball alpha with easing
                frameCounter <- frameCounter + 1
                let normalizedT = float32 frameCounter / 200f // Normalize the time over 200 frames
                ballAlpha <- easeCubicOut normalizedT 0.0f 1.0f 200.0f

                if frameCounter >= 200 then
                    frameCounter <- 0
                    state <- 3
            | 3 ->
                if C_bool(IsKeyPressed KeyboardKey.Enter) then
                    ballPositionX <- -100
                    ballRadius <- 20
                    ballAlpha <- 0f
                    state <- 0

            if C_bool(IsKeyPressed KeyboardKey.R) then
                frameCounter <- 0

            BeginDrawing()
            ClearBackground Color.RayWhite

            if state >= 2 then
                DrawRectangle(0, 0, screenWidth, screenHeight, Color.Green)

            DrawCircle(ballPositionX, 200, float32 ballRadius, Fade(Color.Red, 1.0f - ballAlpha))

            if state = 3 then
                DrawText("PRESS [ENTER] TO PLAY AGAIN", 240, 200, 20, Color.Black)

            EndDrawing()

        CloseWindow()
