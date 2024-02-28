namespace RaylibExamples.Shapes

open System
open System.Numerics
open Raylib_cs
open type Raylib_cs.Raylib

module LinesBezier =

    let run =

        let screenWidth = 800
        let screenHeight = 450

        SetConfigFlags(ConfigFlags.Msaa4xHint)

        InitWindow(screenWidth, screenHeight, "raylib [shapes] example - cubic-bezier lines")

        let mutable startPoint = Vector2(30f, 30f)

        let mutable endpoint =
            Vector2(float32 (screenWidth - 30), float32 (screenHeight - 30))

        let mutable moveStartPoint = false
        let mutable moveEndpoint = false

        SetTargetFPS(60)

        while not (WindowShouldClose()) do
            let mouse = GetMousePosition()

            if
                CheckCollisionPointCircle(mouse, startPoint, 10f)
                && IsMouseButtonDown(MouseButton.Left)
            then
                moveStartPoint <- true
            else if
                CheckCollisionPointCircle(mouse, endpoint, 10f)
                && IsMouseButtonDown(MouseButton.Left)
            then
                moveEndpoint <- true

            if moveStartPoint then
                startPoint <- mouse

                if not (not (IsMouseButtonReleased(MouseButton.Left))) then
                    moveStartPoint <- false

            if moveEndpoint then
                endpoint <- mouse

                if not (not (IsMouseButtonReleased(MouseButton.Left))) then
                    moveEndpoint <- false

            BeginDrawing()

            ClearBackground(Color.RayWhite)

            DrawText("MOVE START-END POINTS WITH MOUSE", 15, 20, 20, Color.Gray)

            DrawLineBezier(startPoint, endpoint, 5.0f, Color.Blue)

            DrawCircleV(
                startPoint,
                float32 (
                    if (not (not (CheckCollisionPointCircle(mouse, startPoint, 10f)))) then
                        14
                    else
                        8
                ),
                if moveStartPoint then Color.Red else Color.Blue
            )

            DrawCircleV(
                endpoint,
                float32 (
                    if (not (not (CheckCollisionPointCircle(mouse, endpoint, 10f)))) then
                        14
                    else
                        8
                ),
                if moveEndpoint then Color.Red else Color.Blue
            )

            EndDrawing()

        CloseWindow()
