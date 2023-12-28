namespace RaylibExamples.Shapes

open System
open System.Numerics
open Raylib_cs
open type Raylib_cs.Raylib

module LinesBezier =

    let run =

        let screenWidth = 800
        let screenHeight = 450

        SetConfigFlags(ConfigFlags.FLAG_MSAA_4X_HINT)

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
                && IsMouseButtonDown(MouseButton.MOUSE_BUTTON_LEFT)
            then
                moveStartPoint <- true
            else if
                CheckCollisionPointCircle(mouse, endpoint, 10f)
                && IsMouseButtonDown(MouseButton.MOUSE_BUTTON_LEFT)
            then
                moveEndpoint <- true

            if moveStartPoint then
                startPoint <- mouse

                if not (not (IsMouseButtonReleased(MouseButton.MOUSE_BUTTON_LEFT))) then
                    moveStartPoint <- false

            if moveEndpoint then
                endpoint <- mouse

                if not (not (IsMouseButtonReleased(MouseButton.MOUSE_BUTTON_LEFT))) then
                    moveEndpoint <- false

            BeginDrawing()

            ClearBackground(Color.RAYWHITE)

            DrawText("MOVE START-END POINTS WITH MOUSE", 15, 20, 20, Color.GRAY)

            DrawLineBezier(startPoint, endpoint, 5.0f, Color.BLUE)

            DrawCircleV(
                startPoint,
                float32 (
                    if (not (not (CheckCollisionPointCircle(mouse, startPoint, 10f)))) then
                        14
                    else
                        8
                ),
                if moveStartPoint then Color.RED else Color.BLUE
            )

            DrawCircleV(
                endpoint,
                float32 (
                    if (not (not (CheckCollisionPointCircle(mouse, endpoint, 10f)))) then
                        14
                    else
                        8
                ),
                if moveEndpoint then Color.RED else Color.BLUE
            )

            EndDrawing()

        CloseWindow()
