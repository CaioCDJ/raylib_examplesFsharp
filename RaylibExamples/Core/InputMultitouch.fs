namespace RaylibExamples.Core

open System.Numerics
open Raylib_cs
open type Raylib_cs.Raylib

module InputMultitouch =
    let MAX_TOUCH_POINTS = 10

    let run =
        let screenWidth = 800
        let screenHeight = 450

        InitWindow(screenWidth, screenHeight, "raylib [core] example - input multitouch")

        let mutable touchPositions: Vector2 array =
            Array.zeroCreate<Vector2> (MAX_TOUCH_POINTS)


        SetTargetFPS(60)

        while not (WindowShouldClose()) do
            let mutable tCount: int = GetTouchPointCount()

            if tCount > MAX_TOUCH_POINTS then
                tCount <- MAX_TOUCH_POINTS

            for i in 0 .. tCount - 1 do
                touchPositions.[i] = GetTouchPosition(i)

            BeginDrawing()

            ClearBackground(Color.RAYWHITE)

            for i in 0 .. tCount - 1 do
                if touchPositions.[i].X > 0f && touchPositions.[i].Y > 0f then
                    DrawCircleV(touchPositions.[i], 34f, Color.ORANGE)

                    DrawText(
                        $"{i}",
                        int (touchPositions.[i].X - 10f),
                        int (touchPositions.[i].Y - 70f),
                        40,
                        Color.BLACK
                    )

            DrawText("touch the screen at multiple locations to get multiple balls", 10, 10, 20, Color.DARKGRAY)

            EndDrawing()

        CloseWindow()
