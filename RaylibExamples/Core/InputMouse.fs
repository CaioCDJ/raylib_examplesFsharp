namespace RaylibExamples.Core

open System.Numerics
open Raylib_cs
open type Raylib_cs.Raylib

module InputMouse =
    let run =
        let screenWidth = 800
        let screenHeight = 450

        InitWindow(screenWidth, screenHeight, "raylib [core] example - mouse input")

        let mutable ballPosition = Vector2(-100.0f, -100.0f)
        let mutable ballColor = Color.DARKBLUE

        SetTargetFPS(60)

        while not (WindowShouldClose()) do
            ballPosition <- GetMousePosition()

            if not (not (IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))) then
                ballColor <- Color.MAROON
            else if not (not (IsMouseButtonDown(MouseButton.MOUSE_BUTTON_MIDDLE))) then
                ballColor <- Color.LIME
            else if not (not (IsMouseButtonDown(MouseButton.MOUSE_BUTTON_RIGHT))) then
                ballColor <- Color.DARKBLUE
            else if not (not (IsMouseButtonDown(MouseButton.MOUSE_BUTTON_SIDE))) then
                ballColor <- Color.PURPLE
            else if not (not (IsMouseButtonDown(MouseButton.MOUSE_BUTTON_EXTRA))) then
                ballColor <- Color.YELLOW
            else if not (not (IsMouseButtonDown(MouseButton.MOUSE_BUTTON_FORWARD))) then
                ballColor <- Color.ORANGE
            else if not (not (IsMouseButtonDown(MouseButton.MOUSE_BUTTON_BACK))) then
                ballColor <- Color.BEIGE

            BeginDrawing()

            ClearBackground(Color.RAYWHITE)

            DrawCircleV(ballPosition, 40f, ballColor)

            DrawText("move ball with mouse and click mouse button to change color", 10, 10, 20, Color.DARKGRAY)
            EndDrawing()

        CloseWindow()
