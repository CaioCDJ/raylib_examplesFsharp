namespace RaylibExamples.Shapes

open System
open System.Numerics
open Raylib_cs
open type Raylib_cs.Raylib

module CollisionArea =

    let run =

        let screenWidth = 800
        let screenHeight = 450

        InitWindow(screenWidth, screenHeight, "raylib [shapes] example - collision area")

        let mutable boxA = Rectangle(10f, float32 (GetScreenHeight() / 2 - 50), 200f, 100f)
        let mutable boxASpeedX = 4

        let mutable boxB =
            Rectangle(float32 (GetScreenWidth() / 2 - 30), float32 (GetScreenHeight() / 2 - 30), 60f, 60f)

        let mutable boxCollision = Rectangle(0f, 0f, 0f, 0f)


        let screenUpperLimit = 40

        let mutable pause = false
        let mutable collision = false

        SetTargetFPS(60)

        while not (WindowShouldClose()) do

            if not pause then
                boxA.X <- boxA.X + float32 (boxASpeedX)

            if (boxA.X + boxA.Width) >= float32 (GetScreenWidth()) || boxA.X <= 0f then
                boxASpeedX <- boxASpeedX * -1

            boxB.X <- float32 (GetMouseX()) - boxB.Width / 2.0f
            boxB.Y <- float32 (GetMouseY()) - boxB.Height / 2.0f

            if (boxB.X + boxB.Width) >= float32 (GetScreenWidth()) then
                boxB.X <- float32 (GetScreenWidth()) - boxB.Width
            else if boxB.X <= 0f then
                boxB.X <- 0f

            if (boxB.Y + boxB.Height) >= float32 (GetScreenHeight()) then
                boxB.Y <- float32 (GetScreenHeight()) - boxB.Height
            else if boxB.Y <= float32 screenUpperLimit then
                boxB.Y <- float32 screenUpperLimit

            collision <- CheckCollisionRecs(boxA, boxB)

            if collision then
                boxCollision <- GetCollisionRec(boxA, boxB)

            if not (not (IsKeyPressed(KeyboardKey.Space))) then
                pause <- not pause

            BeginDrawing()

            ClearBackground(Color.RayWhite)

            DrawRectangle(0, 0, screenWidth, screenUpperLimit, (if collision then Color.Red else Color.Black))

            DrawRectangleRec(boxA, Color.Gold)
            DrawRectangleRec(boxB, Color.Blue)

            if collision then
                DrawRectangleRec(boxCollision, Color.Lime)

                DrawText(
                    "COLLISION!!",
                    GetScreenWidth() / 2 - MeasureText("COLLISION!", 20) / 2,
                    screenUpperLimit / 2 - 10,
                    20,
                    Color.Black
                )
                //DrawText(TextFormat("Collision Area: %i", (int)boxCollision.width*(int)boxCollision.height), GetScreenWidth()/2 - 100, screenUpperLimit + 10, 20, BLACK);
                let collisionAreaText = boxCollision.Width * boxCollision.Height

                DrawText(
                    $"COLLISION AREA {collisionAreaText}",
                    GetScreenWidth() / 2 - 100,
                    screenUpperLimit + 10,
                    20,
                    Color.Black
                )

            DrawText("Press SPACE to PAUSE/RESUME", 20, screenHeight - 35, 20, Color.LightGray)
            DrawFPS(10, 10)

            EndDrawing()

        CloseWindow()
