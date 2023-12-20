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

            ClearBackground(Color.RAYWHITE)


            DrawText("some basic shapes available on raylib", 20, 20, 20, Color.DARKGRAY)

            // Circle shapes and lines
            DrawCircle(screenWidth / 5, 120, 35f, Color.DARKBLUE)
            DrawCircleGradient(screenWidth / 5, 220, 60f, Color.GREEN, Color.SKYBLUE)
            DrawCircleLines(screenWidth / 5, 340, 80f, Color.DARKBLUE)


            // Rectangle shapes and lines
            DrawRectangle(screenWidth / 4 * 2 - 60, 100, 120, 60, Color.RED)
            DrawRectangleGradientH(screenWidth / 4 * 2 - 90, 170, 180, 130, Color.MAROON, Color.GOLD)
            DrawRectangleLines(screenWidth / 4 * 2 - 40, 320, 80, 60, Color.ORANGE) // NOTE: Uses QUADS internally, not lines


            DrawTriangle(
                Vector2(float32 (screenWidth / 4 * 3), 80.0f),
                Vector2(float32 (screenWidth / 4 * 3 - 60), 150.0f),
                Vector2(float32 (screenWidth / 4 * 3 + 60), 150.0f),
                Color.VIOLET
            )

            DrawTriangleLines(
                Vector2(float32 (screenWidth / 4 * 3), 160.0f),
                Vector2(float32 (screenWidth / 4 * 3 - 20), 230.0f),
                Vector2(float32 (screenWidth / 4 * 3 + 20), 230.0f),
                Color.DARKBLUE
            )

            DrawPoly(Vector2(float32 (screenWidth / 4 * 3), 330.0f), 6, 80.0f, rotation, Color.BROWN)
            DrawPolyLines(Vector2(float32 (screenWidth / 4 * 3), 330f), 6, 90f, rotation, Color.BROWN)
            DrawPolyLinesEx(Vector2(float32 (screenWidth / 4 * 3), 330.0f), 6, 85f, rotation, 6f, Color.BEIGE)

            DrawLine(18, 42, (screenWidth - 18), 42, Color.BLACK)
            EndDrawing()

        CloseWindow()
