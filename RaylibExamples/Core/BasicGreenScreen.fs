namespace RaylibExamples.Core

open Raylib_cs

type GameScreen =
    | Logo = 0
    | Title = 1
    | Gameplay = 2
    | Ending = 3

type BasicScreenManager() =
    static member Main() =
        let screenWidth = 800
        let screenHeight = 450

        Raylib.InitWindow(screenWidth, screenHeight, "raylib [core] example - basic screen manager")

        let mutable currentScreen = GameScreen.Logo

        let framesCounter = ref 0

        Raylib.SetTargetFPS(60)

        while not (Raylib.WindowShouldClose()) do
            match currentScreen with
            | GameScreen.Logo ->
                framesCounter := !framesCounter + 1

                if !framesCounter > 120 then
                    currentScreen <- GameScreen.Title
            | GameScreen.Title ->
                if Raylib.IsKeyPressed(KeyboardKey.Enter) || Raylib.IsGestureDetected(Gesture.Tap) then
                    currentScreen <- GameScreen.Gameplay
            | GameScreen.Gameplay ->
                if Raylib.IsKeyPressed(KeyboardKey.Enter) || Raylib.IsGestureDetected(Gesture.Tap) then
                    currentScreen <- GameScreen.Ending
            | GameScreen.Ending ->
                if Raylib.IsKeyPressed(KeyboardKey.Enter) || Raylib.IsGestureDetected(Gesture.Tap) then
                    currentScreen <- GameScreen.Title
            | _ -> ()

            Raylib.BeginDrawing()

            Raylib.ClearBackground(Color.RayWhite)

            match currentScreen with
            | GameScreen.Logo ->
                Raylib.DrawText("LOGO SCREEN", 20, 20, 40, Color.LightGray)
                Raylib.DrawText("WAIT for 2 SECONDS...", 290, 220, 20, Color.Gray)
            | GameScreen.Title ->
                Raylib.DrawRectangle(0, 0, screenWidth, screenHeight, Color.Green)
                Raylib.DrawText("TITLE SCREEN", 20, 20, 40, Color.DarkGreen)
                Raylib.DrawText("PRESS ENTER or TAP to JUMP to GAMEPLAY SCREEN", 120, 220, 20, Color.DarkGreen)
            | GameScreen.Gameplay ->
                Raylib.DrawRectangle(0, 0, screenWidth, screenHeight, Color.Purple)
                Raylib.DrawText("GAMEPLAY SCREEN", 20, 20, 40, Color.Maroon)
                Raylib.DrawText("PRESS ENTER or TAP to JUMP to ENDING SCREEN", 130, 220, 20, Color.Maroon)
            | GameScreen.Ending ->
                Raylib.DrawRectangle(0, 0, screenWidth, screenHeight, Color.Blue)
                Raylib.DrawText("ENDING SCREEN", 20, 20, 40, Color.DarkBlue)
                Raylib.DrawText("PRESS ENTER or TAP to RETURN to TITLE SCREEN", 120, 220, 20, Color.DarkBlue)
            | _ -> ()

            Raylib.EndDrawing()

        Raylib.CloseWindow()
