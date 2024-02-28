namespace RaylibExamples.Core

open System.Numerics
open Raylib_cs
open type Raylib_cs.Raylib

// not working

module camera3dFree =

    let run =

        let screenWidth = 800
        let screenHeight = 450

        InitWindow(screenWidth, screenHeight, "raylib [core] example - 3d camera free")

        let mutable camera =
            Camera3D(
                Vector3(10.0f, 10.0f, 10.0f),
                Vector3(0.0f, 0.0f, 0.0f),
                Vector3(0.0f, 1.0f, 0.0f),
                45.0f,
                CameraProjection.Perspective
            )

        let cubePosition = Vector3(0.0f, 0.0f, 0.0f)

        // DisableCursor()

        SetTargetFPS(60)

        while not (WindowShouldClose()) do
            UpdateCamera(ref camera, CameraMode.Free)

            if not (not (IsKeyPressed(KeyboardKey.Z))) then
                camera.Target <- Vector3(0.0f, 0.0f, 0.0f)

            BeginDrawing()
            ClearBackground(Color.RayWhite)

            BeginMode3D(camera)

            DrawCube(cubePosition, 2.0f, 2.0f, 2.0f, Color.Red)
            DrawCubeWires(cubePosition, 2.0f, 2.0f, 2.0f, Color.Maroon)

            DrawGrid(10, 1.0f)

            EndMode3D()

            DrawRectangle(10, 10, 320, 133, ColorAlpha(Color.SkyBlue, 0.5f))
            DrawRectangleLines(10, 10, 320, 133, Color.Blue)

            DrawText("Free camera default controls:", 20, 20, 10, Color.Black)
            DrawText("- Mouse Wheel to Zoom in-out", 40, 40, 10, Color.DarkGray)
            DrawText("- Mouse Wheel Pressed to Pan", 40, 60, 10, Color.DarkGray)
            DrawText("- Alt + Mouse Wheel Pressed to Rotate", 40, 80, 10, Color.DarkGray)
            DrawText("- Alt + Ctrl + Mouse Wheel Pressed for Smooth Zoom", 40, 100, 10, Color.DarkGray)
            DrawText("- Z to zoom to (0, 0, 0)", 40, 120, 10, Color.DarkGray)

            EndDrawing()

        CloseWindow()
