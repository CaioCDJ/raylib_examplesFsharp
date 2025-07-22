namespace RaylibExamples.Core

open System.Numerics
open Raylib_cs
open type Raylib_cs.Raylib
open RaylibExamples.Shared.Util

module _3dCameraSplitScreen =

    let run =

        let screenWidth = 800
        let screenHeight = 440

        InitWindow(screenWidth, screenHeight, "raylib [core] example - 3d camera split screen")


        let mutable cameraPlayer1 = Camera3D()
        cameraPlayer1.FovY <- 45.0f
        cameraPlayer1.Up <- Vector3(0.0f, 1.0f, 0.0f)
        cameraPlayer1.Target <- Vector3(0.0f, 1.0f, 0.0f)
        cameraPlayer1.Position <- Vector3(0.0f, 1f, -3.0f)

        let screenPlayer1 = LoadRenderTexture(screenWidth / 2, screenHeight)

        let mutable cameraPlayer2 = Camera3D()
        cameraPlayer2.FovY <- 45.0f
        cameraPlayer2.Up <- Vector3(0.0f, 1.0f, 0.0f)
        cameraPlayer2.Target <- Vector3(0.0f, 3.0f, 0.0f)
        cameraPlayer2.Position <- Vector3(-3.0f, 3f, 0.0f)

        let screenPlayer2 = LoadRenderTexture(screenWidth / 2, screenHeight)

        let splitScreenRect =
            Rectangle(0f, 0f, float32 screenPlayer1.Texture.Width, float32 -screenPlayer1.Texture.Height)


        let count = 5
        let spacing = 4

        SetTargetFPS 60

        let range = [ (-count * spacing) .. spacing .. (count * spacing) ]
        
        while not (C_bool(WindowShouldClose())) do
            let offsetThisFrame = 10f * GetFrameTime()

            if C_bool(IsKeyDown KeyboardKey.W) then
                cameraPlayer1.Position.Z <- cameraPlayer1.Position.Z + offsetThisFrame
                cameraPlayer1.Target.Z <- cameraPlayer1.Target.Z + offsetThisFrame
            else if C_bool(IsKeyDown KeyboardKey.S) then
                cameraPlayer1.Position.Z <- cameraPlayer1.Position.Z - offsetThisFrame
                cameraPlayer1.Target.Z <- cameraPlayer1.Target.Z - offsetThisFrame

            if C_bool(IsKeyDown KeyboardKey.Up) then
                cameraPlayer2.Position.X <- cameraPlayer2.Position.X + offsetThisFrame
                cameraPlayer2.Target.X <- cameraPlayer2.Target.X + offsetThisFrame
            else if C_bool(IsKeyDown KeyboardKey.Down) then
                cameraPlayer2.Position.X <- cameraPlayer2.Position.X - offsetThisFrame
                cameraPlayer2.Target.X <- cameraPlayer2.Target.X - offsetThisFrame

            BeginTextureMode screenPlayer1
            ClearBackground Color.SkyBlue
            BeginMode3D cameraPlayer1

            DrawPlane(Vector3(0f, 0f, 0f), Vector2(50f, 50f), Color.Beige)

            for x_c in range do
                for z_c in range do
                    let x = float32 x_c
                    let z = float32 z_c
                    DrawCube(Vector3(x, 1.5f, z), 1f, 1f, 1f, Color.Lime)
                    DrawCube(Vector3(x, 0.5f, z), 0.25f, 1f, 0.25f, Color.Brown)

            DrawCube(cameraPlayer1.Position, 1f, 1f, 1f, Color.Red)
            DrawCube(cameraPlayer2.Position, 1f, 1f, 1f, Color.Blue)

            EndMode3D()

            DrawRectangle(0, 0, GetScreenWidth() / 2, 40, Fade(Color.RayWhite, 0.8f))
            DrawText("PLAYER 1: W/S to move", 10, 10, 20, Color.Maroon)

            EndTextureMode()
          
            BeginTextureMode screenPlayer2
            ClearBackground Color.SkyBlue
            BeginMode3D cameraPlayer2

            DrawPlane(Vector3(0f, 0f, 0f), Vector2(50f, 50f), Color.Beige)

            for x_c in range do
                for z_c in range do
                    let x = float32 x_c
                    let z = float32 z_c
                    DrawCube(Vector3(x, 1.5f, z), 1f, 1f, 1f, Color.Lime)
                    DrawCube(Vector3(x, 0.5f, z), 0.25f, 1f, 0.25f, Color.Brown)

            DrawCube(cameraPlayer1.Position, 1f, 1f, 1f, Color.Red)
            DrawCube(cameraPlayer2.Position, 1f, 1f, 1f, Color.Blue)

            EndMode3D()

            DrawRectangle(0, 0, GetScreenWidth() / 2, 40, Fade(Color.RayWhite, 0.8f))
            DrawText("PLAYER 2 UP/DOWM to move", 10, 10, 20, Color.DarkBlue)

            EndTextureMode()


            BeginDrawing()
            ClearBackground Color.Black

            DrawTextureRec(screenPlayer1.Texture, splitScreenRect, Vector2(0f, 0f), Color.White)
            DrawTextureRec(screenPlayer2.Texture, splitScreenRect, Vector2(float32 (screenWidth / 2), 0f), Color.White)

            EndDrawing()

        UnloadRenderTexture screenPlayer1
        UnloadRenderTexture screenPlayer2
        CloseWindow()
