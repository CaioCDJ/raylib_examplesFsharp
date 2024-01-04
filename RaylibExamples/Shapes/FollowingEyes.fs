namespace RaylibExamples.Shapes

open System
open System.Numerics
open Raylib_cs
open type Raylib_cs.Raylib

module FollowingEyes =

    let run =

        let screenWidth = 800
        let screenHeight = 450

        InitWindow(screenWidth, screenHeight, "raylib [shapes] example - following eyes")

        let mutable scleraLeftPosition =
            Vector2(float32 (GetScreenWidth()) / 2.0f - 100.0f, float32 (GetScreenHeight()) / 2f)

        let mutable scleraRightPosition =
            Vector2(float32 (GetScreenWidth()) / 2f + 100f, float32 (GetScreenHeight()) / 2f)

        let sleraRadius = 80f

        let mutable irisLeftPosition =
            Vector2(float32 (GetScreenWidth()) / 2f - 100f, float32 (GetScreenHeight()) / 2f)

        let mutable irisRightPosition =
            Vector2(float32 (GetScreenWidth()) / 2f + 100f, float32 (GetScreenHeight()) / 2f)

        let irisRadius = 24f

        let mutable angle = 0f
        let mutable dx = 0f
        let mutable dy = 0f
        let mutable dxx = 0f
        let mutable dyy = 0f

        SetTargetFPS(60)

        while not (WindowShouldClose()) do

            irisLeftPosition <- GetMousePosition()
            irisRightPosition <- GetMousePosition()

            if not (CheckCollisionPointCircle(irisLeftPosition, scleraLeftPosition, float32 (sleraRadius) - 20f)) then
                dx <- irisLeftPosition.X - scleraLeftPosition.X
                dy <- irisLeftPosition.Y - scleraLeftPosition.Y

                angle <- MathF.Atan2(dy, dx)

                dxx <- (sleraRadius - float32 (irisRadius)) * MathF.Cos(angle)
                dyy <- (sleraRadius - float32 (irisRadius)) * MathF.Sin(angle)

                irisLeftPosition.X <- scleraLeftPosition.X + dxx
                irisLeftPosition.Y <- scleraLeftPosition.Y + dyy

            if not (CheckCollisionPointCircle(irisRightPosition, scleraRightPosition, float32 (sleraRadius) - 20f)) then
                dx <- irisRightPosition.X - scleraRightPosition.X
                dy <- irisRightPosition.Y - scleraRightPosition.Y

                angle <- MathF.Atan2(dy, dx)

                dxx <- (sleraRadius - float32 (irisRadius)) * MathF.Cos(angle)
                dyy <- (sleraRadius - float32 (irisRadius)) * MathF.Sin(angle)

                irisRightPosition.X <- scleraRightPosition.X + dxx
                irisRightPosition.Y <- scleraRightPosition.Y + dyy


            BeginDrawing()

            ClearBackground(Color.RAYWHITE)

            DrawCircleV(scleraLeftPosition, sleraRadius, Color.LIGHTGRAY)
            DrawCircleV(irisLeftPosition, irisRadius, Color.BROWN)
            DrawCircleV(irisLeftPosition, 10f, Color.BLACK)

            DrawCircleV(scleraRightPosition, sleraRadius, Color.LIGHTGRAY)
            DrawCircleV(irisRightPosition, irisRadius, Color.DARKGREEN)
            DrawCircleV(irisRightPosition, 10f, Color.BLACK)

            DrawFPS(10, 10)

            EndDrawing()

        CloseWindow()
