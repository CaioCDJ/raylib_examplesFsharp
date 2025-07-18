namespace RaylibExamples.Core

open System.Numerics
open Raylib_cs
open type Raylib_cs.Raylib
open RaylibExamples.Shared.Util

module _3dCameraFirstPerson =

    let max_columns = 20

    let run =

        let screenWidth = 800
        let screenHeight = 440

        InitWindow(screenWidth, screenHeight, "raylib [core] example - 3d camera first person")

        let mutable camera = Camera3D()
        camera.Position <- Vector3(0.0f, 0.2f, 4.0f)
        camera.Target <- Vector3(0.0f, 2.0f, 0.0f)
        camera.Up <- Vector3(0.0f, 1.0f, 0.0f)
        camera.FovY <- 60.0f
        camera.Projection <- CameraProjection.Perspective

        let mutable cameraMode = CameraMode.FirstPerson

        //let heights = []
        let heights = Array.create max_columns 0.0f

        let positions = Array.create max_columns (Vector3(0f, 0f, 0f))

        let colors = Array.create max_columns (Color(0, 0, 0, 0))

        for i in 0 .. (max_columns - 1) do
            heights[i] <- float32 (GetRandomValue(1, 12))

            positions[i] <-
                Vector3(float32 (GetRandomValue(-15, 15)), heights[i] / 2.0f, float32 (GetRandomValue(-15, 15)))

            colors[i] <- Color(GetRandomValue(20, 255), GetRandomValue(20, 255), 30, 255)

        DisableCursor()

        SetTargetFPS 60

        while not (C_bool(WindowShouldClose())) do
            if C_bool(IsKeyDown(KeyboardKey.One)) then
                cameraMode <- CameraMode.Free
                camera.Up <- Vector3(0f, 1.0f, 0f)

            if C_bool(IsKeyDown(KeyboardKey.Two)) then
                cameraMode <- CameraMode.FirstPerson
                camera.Up <- Vector3(0f, 1.0f, 0f)

            if C_bool(IsKeyDown(KeyboardKey.Three)) then
                cameraMode <- CameraMode.ThirdPerson
                camera.Up <- Vector3(0f, 1.0f, 0f)

            if C_bool(IsKeyDown(KeyboardKey.One)) then
                cameraMode <- CameraMode.Orbital
                camera.Up <- Vector3(0f, 1.0f, 0f)

            if C_bool(IsKeyDown(KeyboardKey.P)) then
                if camera.Projection = CameraProjection.Perspective then
                    cameraMode <- CameraMode.ThirdPerson

                    camera.Position <- Vector3(0f, 2.0f, -100.0f)
                    camera.Target <- Vector3(0f, 2.0f, 0f)
                    camera.Up <- Vector3(0f, 1f, 0f)
                    camera.Projection <- CameraProjection.Orthographic
                    camera.FovY <- 20.0f
                    CameraYaw(&camera, float32 (-135) * DEG2RAD, true)
                else if camera.Projection = CameraProjection.Orthographic then
                    cameraMode <- CameraMode.ThirdPerson
                    camera.Position <- Vector3(0f, 2f, 10.0f)
                    camera.Target <- Vector3(0f, 2.0f, 0f)
                    camera.Up <- Vector3(0f, 1f, 0f)
                    camera.Projection <- CameraProjection.Perspective
                    camera.FovY <- 60.0f

            UpdateCamera(&camera, cameraMode)

            BeginDrawing()

            ClearBackground Color.RayWhite

            BeginMode3D camera

            DrawPlane(Vector3(0f, 0f, 0f), Vector2(32.0f, 32.0f), Color.LightGray)
            DrawCube(Vector3(-16f, 2.5f, 0.0f), 1f, 5f, 32f, Color.Blue)
            DrawCube(Vector3(16f, 2.5f, 0f), 1f, 5f, 32f, Color.Lime)
            DrawCube(Vector3(0f, 2.5f, 16f), 32f, 5f, 1f, Color.Gold)

            for i in 0 .. max_columns - 1 do
                DrawCube(positions[i], 2.0f, heights[i], 2.0f, colors[i])
                DrawCubeWires(positions[i], 2.0f, heights[i], 2.0f, Color.Maroon)

            if cameraMode = CameraMode.ThirdPerson then
                DrawCube(camera.Target, 0.5f, 0.5f, 0.5f, Color.Purple)
                DrawCubeWires(camera.Target, 0.5f, 0.5f, 0.5f, Color.DarkPurple)

            EndMode3D()

            DrawRectangle(5, 5, 330, 100, Fade(Color.SkyBlue, 0.5f))
            DrawRectangleLines(5, 5, 330, 100, Color.Blue)

            DrawText("Camera controls:", 15, 15, 10, Color.Black)
            DrawText("- Move keys: W, A, S, D, Space, Left-Ctrl", 15, 30, 10, Color.Black)
            DrawText("- Look around: arrow keys or mouse", 15, 45, 10, Color.Black)
            DrawText("- Camera mode keys: 1, 2, 3, 4", 15, 60, 10, Color.Black)
            DrawText("- Zoom keys: num-plus, num-minus or mouse scroll", 15, 75, 10, Color.Black)
            DrawText("- Camera projection key: P", 15, 90, 10, Color.Black)

            DrawRectangle(600, 5, 195, 100, Fade(Color.SkyBlue, 0.5f))
            DrawRectangleLines(600, 5, 195, 100, Color.Blue)

            DrawText("Camera status:", 610, 15, 10, Color.Black)

            let txt_msg: string =
                match cameraMode with
                | CameraMode.Free -> "FREE"
                | CameraMode.FirstPerson -> "FIRST_PERSON"
                | CameraMode.ThirdPerson -> "THIRD_PERSON"
                | CameraMode.Orbital -> "ORBITAL"
                | _ -> "Custom"

            DrawText($"- Mode: {txt_msg}", 610, 30, 10, Color.Black)

            let projection_txt =
                match camera.Projection with
                | CameraProjection.Orthographic -> "ORTHOGRAPHIC"
                | CameraProjection.Perspective -> "PERSPECTIVE"
          
            DrawText($"- Projection: {projection_txt}",610,45,10,Color.Black)
        
            DrawText($"- Position: ({camera.Position.X}, {camera.Position.Y}, {camera.Position.Z}", 610, 60, 10, Color.Black);
            DrawText($"- Target: {camera.Target.X}, {camera.Target.Y}, {camera.Target.Z}", 610, 75, 10,Color.Black);
            DrawText($"- Up: {camera.Up.X}, {camera.Up.Y}, {camera.Up.Z}", 610, 90, 10, Color.Black);

            EndDrawing()

        CloseWindow()
