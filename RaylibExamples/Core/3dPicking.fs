namespace RaylibExamples.Core

open System.Numerics
open Raylib_cs
open type Raylib_cs.Raylib
open RaylibExamples.Shared.Util

module _3dPicking =

    let run =

        let screenWidth = 800
        let screenHeight = 440

        InitWindow(screenWidth, screenHeight, "raylib [core] example - 3d picking")

        let mutable camera = Camera3D()
        camera.Position <- Vector3(10.0f, 10.0f, 10.0f)
        camera.Target <- Vector3(0.0f, 0.0f, 0.0f)
        camera.Up <- Vector3(0.0f, 1.0f, 0.0f)
        camera.FovY <- 45.0f
        camera.Projection <- CameraProjection.Perspective

        let cubePosition = Vector3(0.0f, 1.0f, 0.0f)
        let cubeSize = Vector3(2.0f, 2.0f, 2.f)

        let mutable ray = Ray()

        let mutable rayCollision = RayCollision()

        printfn $"{ray.Position.X}"
        SetTargetFPS 60
        
        while not (C_bool(WindowShouldClose())) do
            if C_bool(IsCursorHidden()) then
                UpdateCamera(&camera, CameraMode.FirstPerson)

            if C_bool(IsMouseButtonPressed MouseButton.Right) then
                if C_bool(IsCursorHidden()) then
                    EnableCursor()
                else
                    DisableCursor()

            if C_bool(IsMouseButtonPressed MouseButton.Left) then

                if not (C_bool rayCollision.Hit) then
                    ray <- GetScreenToWorldRay(GetMousePosition(), camera)

                    rayCollision <-
                        GetRayCollisionBox(
                            ray,
                            BoundingBox(
                                Vector3(
                                    cubePosition.X - cubeSize.X / 2f,
                                    cubePosition.Y - cubeSize.Y / 2f,
                                    cubePosition.Z - cubeSize.Z / 2f
                                ),
                                Vector3(
                                    cubePosition.X + cubeSize.X / 2f,
                                    cubePosition.Y + cubeSize.Y / 2f,
                                    cubePosition.Z + cubeSize.Z / 2f
                                )
                            )
                        )
                else
                    rayCollision.Hit <- CBool.op_Implicit false

            BeginDrawing()
            ClearBackground Color.RayWhite

            BeginMode3D camera
            
            if C_bool rayCollision.Hit then
                DrawCube(cubePosition, cubeSize.X, cubeSize.Y, cubeSize.Z, Color.Red)
                DrawCubeWires(cubePosition, cubePosition.X, cubePosition.Y, cubePosition.Z, Color.Maroon)

                DrawCubeWires(cubePosition, cubeSize.X + 0.2f, cubeSize.Y + 0.2f, cubeSize.Z + 0.2f, Color.Green)
            else
                DrawCube(cubePosition, cubeSize.X, cubeSize.Y, cubeSize.Z, Color.Gray)
                DrawCubeWires(cubePosition, cubeSize.X, cubeSize.Y, cubeSize.Z, Color.DarkGray)
            
            DrawRay(ray, Color.Maroon)
            DrawGrid(10, 1f)
            EndMode3D()

            DrawText("Try clicking on the box with your mouse!", 240, 10, 20, Color.DarkGray)

            if C_bool rayCollision.Hit then
                DrawText(
                    "BOX SELECTED",
                    (screenWidth - MeasureText("BOX SELECTED", 30)) / 2,
                    int (float32 screenHeight * 0.1f),
                    30,
                    Color.Green
                )

            DrawText("Right click mouse to toggle camera controls", 10, 430, 10, Color.Gray)

            DrawFPS(10, 10)

            EndDrawing()

        CloseWindow()
