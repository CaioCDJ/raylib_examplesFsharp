namespace RaylibExamples.Shapes

open System
open System.Numerics
open Raylib_cs
open type Raylib_cs.Raylib

module RayliblogoAnimation =

    let run =

        let screenWidth = 800
        let screenHeight = 450
        InitWindow(screenWidth, screenHeight, "raylib [shapes] example - raylib logo animation")

        let logoPositionX = screenWidth / 2 - 128
        let logoPositionY = screenHeight / 2 - 128

        let mutable frameCounter = 0
        let mutable lettersCount = 0

        let mutable topSideRecWitdh = 16
        let mutable leftSideRecHeight = 16

        let mutable bottomSideRecWitdh = 16
        let mutable rightSideRecHeight = 16

        let mutable state = 0
        let mutable alpha = 1.0f

        SetTargetFPS(60)

        while not (WindowShouldClose()) do

            match state with
            | 0 ->
                frameCounter <- frameCounter + 1

                if frameCounter = 120 then
                    state <- 1
                    frameCounter <- 0
            | 1 ->
                topSideRecWitdh <- topSideRecWitdh + 4
                leftSideRecHeight <- leftSideRecHeight + 4

                if topSideRecWitdh = 256 then
                    state <- 2
            | 2 ->
                bottomSideRecWitdh <- bottomSideRecWitdh + 4
                rightSideRecHeight <- rightSideRecHeight + 4

                if bottomSideRecWitdh = 256 then
                    state <- 3
            | 3 ->
                frameCounter <- frameCounter + 1

                if frameCounter / 2 <> 0 then
                    lettersCount <- lettersCount + 1
                    frameCounter <- 0

                if lettersCount >= 10 then
                    alpha <- alpha - 0.02f

                    if alpha < 0.0f then
                        alpha <- 0.0f
                        state <- 4
            | 4 ->
                if not (not (IsKeyPressed(KeyboardKey.KEY_R))) then
                    frameCounter <- 0
                    lettersCount <- 0
                    topSideRecWitdh <- 16
                    leftSideRecHeight <- 16
                    bottomSideRecWitdh <- 16
                    rightSideRecHeight <- 16
                    alpha <- 1.0f
                    state <- 0

            BeginDrawing()

            ClearBackground(Color.RAYWHITE)

            match state with
            | 0 ->
                if (frameCounter / 15 % 2) <> 0 then
                    DrawRectangle(logoPositionX, logoPositionY, 16, 16, Color.BLACK)
            | 1 ->
                DrawRectangle(logoPositionX, logoPositionY, topSideRecWitdh, 16, Color.BLACK)
                DrawRectangle(logoPositionX, logoPositionY, 16, leftSideRecHeight, Color.BLACK)
            | 2 ->
                DrawRectangle(logoPositionX, logoPositionY, topSideRecWitdh, 16, Color.BLACK)
                DrawRectangle(logoPositionX, logoPositionY, 16, leftSideRecHeight, Color.BLACK)

                DrawRectangle(logoPositionX + 240, logoPositionY, 16, rightSideRecHeight, Color.BLACK)
                DrawRectangle(logoPositionX, logoPositionY + 240, bottomSideRecWitdh, 16, Color.BLACK)
            | 3 ->
                DrawRectangle(logoPositionX, logoPositionY, topSideRecWitdh, 16, Fade(Color.BLACK, alpha))
                DrawRectangle(logoPositionX, logoPositionY + 16, 16, leftSideRecHeight - 32, Fade(Color.BLACK, alpha))

                DrawRectangle(
                    logoPositionX + 240,
                    logoPositionY + 16,
                    16,
                    rightSideRecHeight - 32,
                    Fade(Color.BLACK, alpha)
                )

                DrawRectangle(logoPositionX, logoPositionY + 240, bottomSideRecWitdh, 16, Fade(Color.BLACK, alpha))

                DrawRectangle(
                    GetScreenWidth() / 2 - 112,
                    GetScreenHeight() / 2 - 112,
                    224,
                    224,
                    Fade(Color.RAYWHITE, alpha)
                )

                DrawText("Raylib", GetScreenWidth() / 2 - 44, GetScreenHeight() / 2 + 48, 50, Fade(Color.BLACK, alpha))

            | 4 -> DrawText("[R] REPLAY", 340, 200, 20, Color.GRAY)

            EndDrawing()

        CloseWindow()
