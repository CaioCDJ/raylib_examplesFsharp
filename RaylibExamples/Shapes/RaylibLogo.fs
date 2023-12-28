namespace RaylibExamples.Shapes

open System
open System.Numerics
open Raylib_cs
open type Raylib_cs.Raylib

module Rayliblogo =

    let run =

        let screenWidth = 800
        let screenHeight = 450
        InitWindow(screenWidth, screenHeight, "raylib [shapes] example - raylib logo using shapes")

        SetTargetFPS(60)

        while not (WindowShouldClose()) do

            BeginDrawing()

            ClearBackground(Color.RAYWHITE)

            DrawRectangle(screenWidth / 2 - 128, screenHeight / 2 - 128, 256, 256, Color.BLACK)
            DrawRectangle(screenWidth / 2 - 112, screenHeight / 2 - 112, 224, 224, Color.RAYWHITE)
            DrawText("raylib", screenWidth / 2 - 44, screenHeight / 2 + 48, 50, Color.BLACK)

            DrawText("this is NOT a texture!", 350, 170, 10, Color.GRAY)

            EndDrawing()

        CloseWindow()
