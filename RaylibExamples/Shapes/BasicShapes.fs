namespace RaylibExamples.Shapes

open System
open System.Numerics
open Raylib_cs
open type Raylib_cs.Raylib

module BasicShapes =
    let run =

        let screenWidth = 800
        let screenHeight = 450

        InitWindow(screenWidth, screenHeight, "raylib [shapes] example - basic shapes drawing")

        let mutable rotation: float32 = 0.0f

        SetTargetFPS(60)

        while not (WindowShouldClose()) do
            rotation <- rotation + 2.0f

            BeginDrawing()

            ClearBackground(Color.RayWhite)


            DrawText("some basic shapes available on raylib", 20, 20, 20, Color.DarkGray)

            // Circle shapes and lines
            DrawCircle(screenWidth / 5, 120, 35f, Color.DarkBlue)
            DrawCircleGradient(screenWidth / 5, 220, 60f, Color.Green, Color.SkyBlue)
            DrawCircleLines(screenWidth / 5, 340, 80f, Color.DarkBlue)


            // Rectangle shapes and lines
            DrawRectangle(screenWidth / 4 * 2 - 60, 100, 120, 60, Color.Red)
            DrawRectangleGradientH(screenWidth / 4 * 2 - 90, 170, 180, 130, Color.Maroon, Color.Gold)
            DrawRectangleLines(screenWidth / 4 * 2 - 40, 320, 80, 60, Color.Orange) // NOTE: Uses QUADS internally, not lines

            DrawTriangle(
                Vector2(float32 (screenWidth / 4 * 3), 80.0f),
                Vector2(float32 (screenWidth / 4 * 3 - 60), 150.0f),
                Vector2(float32 (screenWidth / 4 * 3 + 60), 150.0f),
                Color.Violet
            )

            DrawTriangleLines(
                Vector2(float32 (screenWidth / 4 * 3), 160.0f),
                Vector2(float32 (screenWidth / 4 * 3 - 20), 230.0f),
                Vector2(float32 (screenWidth / 4 * 3 + 20), 230.0f),
                Color.DarkBlue
            )

            DrawPoly(Vector2(float32 (screenWidth / 4 * 3), 330.0f), 6, 80.0f, rotation, Color.Brown)
            DrawPolyLines(Vector2(float32 (screenWidth / 4 * 3), 330f), 6, 90f, rotation, Color.Brown)
            DrawPolyLinesEx(Vector2(float32 (screenWidth / 4 * 3), 330.0f), 6, 85f, rotation, 6f, Color.Beige)

            DrawLine(18, 42, (screenWidth - 18), 42, Color.Black)
            EndDrawing()

        CloseWindow()
