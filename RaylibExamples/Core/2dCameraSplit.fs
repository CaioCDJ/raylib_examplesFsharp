namespace RaylibExamples.Core

open System.Numerics
open Raylib_cs
open type Raylib_cs.Raylib


module CameraSpit2d =

    let PLAYER_SIZE: float32 = 40f

    let run =
        let screenWidth = 800
        let screenHeight = 440

        InitWindow(screenWidth, screenHeight, "raylib [core] example - 2d camera split screen")

        let mutable player1 = Rectangle(200f, 200f, PLAYER_SIZE, PLAYER_SIZE)
        let mutable player2 = Rectangle(250f, 200f, PLAYER_SIZE, PLAYER_SIZE)

        let mutable camera1 =
            Camera2D(Vector2(200.0f, 200.0f), Vector2(player1.X, player1.Y), 0.0f, 1.0f)

        let mutable camera2 =
            Camera2D(Vector2(200.0f, 200.0f), Vector2(player2.X, player2.Y), 0.0f, 1.0f)

        let screenCamera1: RenderTexture2D =
            LoadRenderTexture(screenWidth / 2, screenHeight)

        let screenCamera2: RenderTexture2D =
            LoadRenderTexture(screenWidth / 2, screenHeight)

        let splitScreenRect =
            Rectangle(0f, 0f, float32 (screenCamera1.Texture.Width), float32 (-screenCamera1.Texture.Height))

        SetTargetFPS(60)

        // Main game loop
        while not (WindowShouldClose()) do

            // ASWD Keyboard control
            if not (not (IsKeyDown(KeyboardKey.KEY_S))) then
                player1.Y <- player1.Y + 3.0f
            else if not (not (IsKeyDown(KeyboardKey.KEY_W))) then
                player1.Y <- player1.Y - 3.0f

            if not (not (IsKeyDown(KeyboardKey.KEY_D))) then
                player1.X <- player1.X + 3.0f
            else if not (not (IsKeyDown(KeyboardKey.KEY_A))) then
                player1.X <- player1.X - 3.0f

            if not (not (IsKeyDown(KeyboardKey.KEY_UP))) then
                player2.Y <- player2.Y - 3.0f
            else if not (not (IsKeyDown(KeyboardKey.KEY_DOWN))) then
                player2.Y <- player2.Y + 3.0f

            if not (not (IsKeyDown(KeyboardKey.KEY_RIGHT))) then
                player2.X <- player2.X + 3.0f
            else if not (not (IsKeyDown(KeyboardKey.KEY_LEFT))) then
                player2.X <- player2.X - 3.0f

            camera1.Target <- Vector2(player1.X, player1.Y)
            camera2.Target <- Vector2(player2.X, player2.Y)

            // Draw
            //----------------------------------------------------------------------------------

            BeginTextureMode(screenCamera1)
            ClearBackground(Color.RAYWHITE)

            BeginMode2D(camera1)


            for i in 0 .. screenWidth / int (PLAYER_SIZE) + 1 do
                DrawLineV(
                    Vector2(float32 (PLAYER_SIZE * float32 (i)), 0f),
                    Vector2(float32 (PLAYER_SIZE * float32 (i)), float32 (screenHeight)),
                    Color.LIGHTGRAY
                )

            for i in 0 .. screenHeight / int (PLAYER_SIZE) + 1 do
                DrawLineV(
                    Vector2(0f, float32 (PLAYER_SIZE * float32 (i))),
                    Vector2(float32 (screenWidth), float32 (PLAYER_SIZE * float32 (i))),
                    Color.LIGHTGRAY
                )

            for i in 0 .. screenWidth / int (PLAYER_SIZE) do
                for j in 0 .. screenHeight / int (PLAYER_SIZE) do
                    DrawText($"{i},{j}", 10 + int (PLAYER_SIZE) * i, 15 + int (PLAYER_SIZE) * j, 10, Color.LIGHTGRAY)


            DrawRectangleRec(player1, Color.RED)
            DrawRectangleRec(player2, Color.BLUE)
            EndMode2D()

            DrawRectangle(0, 0, GetScreenWidth() / 2, 30, Fade(Color.RAYWHITE, 0.0f))
            DrawText("PLAYER1: W/S/A/D to move", 10, 10, 10, Color.MAROON)

            EndTextureMode()

            BeginTextureMode(screenCamera2)
            ClearBackground(Color.RAYWHITE)

            BeginMode2D(camera2)

            for i in 0 .. screenWidth / int (PLAYER_SIZE) + 1 do
                DrawLineV(
                    Vector2(float32 (PLAYER_SIZE * float32 (i)), 0f),
                    Vector2(float32 (PLAYER_SIZE * float32 (i)), float32 (screenHeight)),
                    Color.LIGHTGRAY
                )

            for i in 0 .. screenHeight / int (PLAYER_SIZE) + 1 do
                DrawLineV(
                    Vector2(0f, float32 (PLAYER_SIZE * float32 (i))),
                    Vector2(float32 (screenWidth), float32 (PLAYER_SIZE * float32 (i))),
                    Color.LIGHTGRAY
                )

            for i in 0 .. screenWidth / int (PLAYER_SIZE) do
                for j in 0 .. screenHeight / int (PLAYER_SIZE) do
                    DrawText($"{i},{j}", 10 + int (PLAYER_SIZE) * i, 15 + int (PLAYER_SIZE) * j, 10, Color.LIGHTGRAY)

            DrawRectangleRec(player1, Color.RED)
            DrawRectangleRec(player2, Color.BLUE)

            EndMode2D()

            DrawRectangle(0, 0, GetScreenWidth() / 2, 30, Fade(Color.RAYWHITE, 0.6f))
            DrawText("PLAYER2: UP/DOWN/LEFT/RIGHT to move", 10, 10, 10, Color.DARKBLUE)

            EndTextureMode()

            BeginDrawing()

            ClearBackground(Color.BLACK)

            DrawTextureRec(screenCamera1.Texture, splitScreenRect, Vector2(0f, 0f), Color.WHITE)

            DrawTextureRec(
                screenCamera2.Texture,
                splitScreenRect,
                Vector2(float32 (screenWidth / 2), 0.0f),
                Color.WHITE
            )

            DrawRectangle(GetScreenWidth() / 2 - 2, 0, 4, GetScreenHeight(), Color.LIGHTGRAY)

            EndDrawing()

        UnloadRenderTexture(screenCamera1)
        UnloadRenderTexture(screenCamera2)
        CloseWindow()
