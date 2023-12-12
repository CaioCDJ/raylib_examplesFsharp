namespace RaylibExamples.Core

open System.Numerics
open Raylib_cs
open type Raylib_cs.Raylib

module CameraMode3d =
    let run =
        let screenWidth = 800
        let screenHeight = 450
        InitWindow(screenWidth, screenHeight, "raylib [core] example - 3d camera mode")

        let mutable camera =
            Camera3D(
                Vector3(10.0f, 10.0f, 10.0f),
                Vector3(0.0f, 0.0f, 0.0f),
                Vector3(0.0f, 1.0f, 0.0f),
                45.0f,
                CameraProjection.CAMERA_PERSPECTIVE
            )

        let cubePosition = Vector3(0.0f, 0.0f, 0.0f)

        SetTargetFPS(60)

        while not (WindowShouldClose()) do
            BeginDrawing()
            ClearBackground(Color.RAYWHITE)
            BeginMode3D(camera)

            DrawCube(cubePosition, 2.0f, 2.0f, 2.0f, Color.RED)
            DrawCubeWires(cubePosition, 2.0f, 2.0f, 2.0f, Color.MAROON)

            DrawGrid(10, 1.0f)
            EndMode3D()

            DrawText("Welcome to the third dimension!", 10, 40, 20, Color.DARKGRAY)

            DrawFPS(10, 10)

            EndDrawing()

        CloseWindow()
