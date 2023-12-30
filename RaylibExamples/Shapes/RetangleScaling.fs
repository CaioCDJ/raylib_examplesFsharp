namespace RaylibExamples.Shapes

open System
open System.Numerics
open Raylib_cs
open type Raylib_cs.Raylib

module RetangleScaling =

    let MOUSE_SCALE_MARK_SIZE = 12f

    let run =

        let screenWidth = 800
        let screenHeight = 450
        InitWindow(screenWidth, screenHeight, "raylib [shapes] example - rectangle scaling mouse")

        let mutable rectangle = Rectangle(100f, 100f, 200f, 80f)

        let mutable mousePosition = Vector2(0f, 0f)

        let mutable mouseScaleReady = false
        let mutable mouseScaleMode = false

        SetTargetFPS(60)

        while not (WindowShouldClose()) do
            mousePosition <- GetMousePosition()

            if
                not (
                    not (
                        CheckCollisionPointRec(
                            mousePosition,
                            Rectangle(
                                rectangle.X + rectangle.Width - MOUSE_SCALE_MARK_SIZE,
                                rectangle.Y + rectangle.Height - MOUSE_SCALE_MARK_SIZE,
                                MOUSE_SCALE_MARK_SIZE,
                                MOUSE_SCALE_MARK_SIZE
                            )
                        )
                    )
                )
            then
                mouseScaleReady <- true

                if not (not (IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))) then
                    mouseScaleMode <- true
            else
                mouseScaleReady <- false

            if mouseScaleMode then
                mouseScaleReady <- true

                rectangle.Width <- mousePosition.X - rectangle.X
                rectangle.Height <- mousePosition.Y - rectangle.Height

                if rectangle.Width < MOUSE_SCALE_MARK_SIZE then
                    rectangle.Width <- MOUSE_SCALE_MARK_SIZE

                if rectangle.Height < MOUSE_SCALE_MARK_SIZE then
                    rectangle.Height <- MOUSE_SCALE_MARK_SIZE

                if rectangle.Width > float32 (GetScreenWidth()) - rectangle.X then
                    rectangle.Width <- float32 (GetScreenWidth()) - rectangle.X

                if rectangle.Height > float32 (GetScreenHeight()) - rectangle.Y then
                    rectangle.Height <- float32 (GetScreenHeight()) - rectangle.Y

                if not (not (IsMouseButtonReleased(MouseButton.MOUSE_BUTTON_LEFT))) then
                    mouseScaleMode <- false


            BeginDrawing()

            ClearBackground(Color.RAYWHITE)

            DrawText("Scale rectangle dragging from bottom-right corner!", 10, 10, 20, Color.GRAY)

            DrawRectangleRec(rectangle, Fade(Color.GREEN, 0.5f))

            if mouseScaleReady then
                DrawRectangleLinesEx(rectangle, 1f, Color.RED)

                DrawTriangle(
                    Vector2((rectangle.X + rectangle.Width - MOUSE_SCALE_MARK_SIZE), (rectangle.Y + rectangle.Height)),
                    Vector2((rectangle.X + rectangle.Width), (rectangle.Y + rectangle.Height)),
                    Vector2((rectangle.X + rectangle.Width), (rectangle.Y + rectangle.Height - MOUSE_SCALE_MARK_SIZE)),
                    Color.RED
                )

            EndDrawing()

        CloseWindow()
