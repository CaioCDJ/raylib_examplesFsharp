namespace RaylibExamples.Core

open type Raylib_cs.Raylib
open Raylib_cs
open type System.Numerics.Vector2

module Camera2dDemo =

    // let MaxBuilldings = 100
    let MaxBuilldings = 100

    let run () =

        let screenWidth = 800
        let screenHeight = 450

        InitWindow(screenWidth, screenHeight, "raylib [core] example - 2d camera")

        let mutable player = Rectangle(400.0f, 280.0f, 40.0f, 40.0f)

        let buildings = Array.zeroCreate<Raylib_cs.Rectangle> MaxBuilldings
        let buildColors = Array.zeroCreate<Color> MaxBuilldings

        let mutable spacing = 0

        for i in 0 .. MaxBuilldings - 1 do
            buildings.[i].Width <- float32 (GetRandomValue(50, 200))
            buildings.[i].Height <- float32 (GetRandomValue(100, 800))
            buildings.[i].Y <- float32 (float32 (screenHeight) - 130.0f - buildings[i].Height)
            buildings.[i].X <- float32 (-6000 + spacing)

            spacing <- spacing + int buildings.[i].Width

            buildColors[i] <-
                new Color(GetRandomValue(200, 240), GetRandomValue(200, 240), GetRandomValue(200, 250), 255)

        let mutable camera =
            Camera2D(
                System.Numerics.Vector2(player.X + 20.0f, player.Y + 20.0f),
                System.Numerics.Vector2(player.X + 20.0f, player.Y + 20.0f),
                0.0f,
                1.0f
            )

        SetTargetFPS(60)

        while not (WindowShouldClose()) do

            if not (not (IsKeyDown(KeyboardKey.KEY_RIGHT))) then
                player.X <- player.X + 2.0f
            elif not (not (IsKeyDown(KeyboardKey.KEY_LEFT))) then
                player.X <- player.X - 2.0f

            camera.Target <- System.Numerics.Vector2(player.X + 20.0f, player.Y + 20.0f)

            if not (not (IsKeyDown(KeyboardKey.KEY_A))) then
                camera.Rotation <- camera.Rotation + 1.0f
            elif not (not (IsKeyDown(KeyboardKey.KEY_S))) then
                camera.Rotation <- camera.Rotation - 1.0f

            match camera.Rotation with
            | var when var > 40.0f -> camera.Rotation <- 40.0f
            | var when var < 40.0f -> camera.Rotation <- -40.0f

            camera.Zoom <- float32 (camera.Zoom + (GetMouseWheelMove() * 0.05f))
            //
            // match camera.Zoom with
            // | var when var > 3.0f -> camera.Zoom <- 3.0f
            // | var when var < 0.1f -> camera.Zoom <- 0.1f
            //

            if (camera.Zoom > 3.0f) then
                camera.Zoom <- 3.0f
            else if camera.Zoom < 0.1f then
                camera.Zoom <- 0.1f

            if not (not (IsKeyDown(KeyboardKey.KEY_R))) then
                camera.Zoom <- 1.0f
                camera.Zoom <- 0.0f

            BeginDrawing()

            ClearBackground(Color.BLACK)

            BeginMode2D(camera)

            DrawRectangle(-6000, 320, 13000, 800, Color.DARKGRAY)

            for i in 0 .. (MaxBuilldings - 1) do
                printfn "%d" i
                DrawRectangleRec(buildings.[i], buildColors.[i])

            DrawRectangleRec(player, Color.RED)

            // DrawRectangle(int (camera.Target.X, -500, 1, int (screenHeight * 4), Color.GREEN))
            DrawRectangle(int (camera.Target.X), -500, 1, int (screenHeight * 4), Color.GREEN)

            DrawLine(
                int (-screenWidth * 10),
                int (camera.Target.Y),
                int (screenWidth * 10),
                int camera.Target.Y,
                Color.GREEN
            )

            EndMode2D()

            DrawText("SCREEN AREA", 640, 10, 20, Color.RED)

            DrawRectangle(0, 0, int (screenWidth), 5, Color.RED)

            DrawRectangle(0, 0, screenWidth, 5, Color.RED)
            DrawRectangle(0, 5, 5, screenHeight - 10, Color.RED)
            DrawRectangle(screenWidth - 5, 5, 5, screenHeight - 10, Color.RED)
            DrawRectangle(0, screenHeight - 5, screenWidth, 5, Color.RED)

            DrawRectangle(10, 10, 250, 113, ColorAlpha(Color.SKYBLUE, 0.5f))
            DrawRectangleLines(10, 10, 250, 113, Color.BLUE)

            DrawText("Free 2d camera controls:", 20, 20, 10, Color.BLACK)
            DrawText("- Right/Left to move Offset", 40, 40, 10, Color.DARKGRAY)
            DrawText("- Mouse Wheel to Zoom in-out", 40, 60, 10, Color.DARKGRAY)
            DrawText("- A / S to Rotate", 40, 80, 10, Color.DARKGRAY)
            DrawText("- R to reset Zoom and Rotation", 40, 100, 10, Color.DARKGRAY)

            EndDrawing()
