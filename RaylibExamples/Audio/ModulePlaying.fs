namespace RaylibExamples.Audio

open System.Numerics
open Raylib_cs
open type Raylib_cs.Raylib
open RaylibExamples.Shared.Util
open Raylib_cs

module ModulePlaying =

    type CircleWave =
        { mutable position: Vector2
          mutable radius: float32
          mutable alpha: float32
          mutable speed: float32
          mutable color: Color }

    let defaultCircleWave () =
        { position = Vector2(0.0f, 0.0f)
          radius = 0.0f
          alpha = 0f
          speed = 0.0f
          color = Color.Black }
        : CircleWave

    let run =

        let screenWidth = 800
        let screenHeight = 440

        InitWindow(screenWidth, screenHeight, "raylib [audio] example - module playing (streaming)")

        InitAudioDevice()

        let colors =
            [ Color.Orange
              Color.Red
              Color.Gold
              Color.Lime
              Color.Blue
              Color.Violet
              Color.Brown
              Color.LightGray
              Color.Pink
              Color.Yellow
              Color.Green
              Color.SkyBlue
              Color.Purple
              Color.Beige ]

        let mutable circles = Array.init 64 (fun _ -> defaultCircleWave ())

        for item in circles do
            item.radius <- float32 (GetRandomValue(10, 40))
            item.position.X <- float32 (GetRandomValue(int item.radius, screenWidth - int item.radius))
            item.position.Y <- float32 (GetRandomValue(int item.radius, screenHeight - int item.radius))
            item.speed <- float32 (GetRandomValue(1, 1000)) / 2000.0f
            item.color <- colors[GetRandomValue(0, 13)]

        let mutable music = LoadMusicStream "./resources/audio/mini1111.xm"

        music.Looping <- false

        let mutable pitch: float32 = 1.0f

        PlayMusicStream music

        let mutable timePlayed = 0.0f

        let mutable pause = false

        SetTargetFPS 60

        let music_length = GetMusicTimeLength music

        while not (C_bool(WindowShouldClose())) do

            UpdateMusicStream music

            if C_bool(IsKeyPressed KeyboardKey.Space) then
                StopMusicStream music
                PlayMusicStream music


            if C_bool(IsKeyPressed KeyboardKey.P) then

                pause <- not pause

                if pause then
                    PauseMusicStream music
                else
                    ResumeMusicStream music


            if C_bool(IsKeyPressed KeyboardKey.Down) then
                pitch <- pitch - 0.1f

            else if C_bool(IsKeyPressed KeyboardKey.Up) then
                pitch <- pitch + 0.1f

            SetMusicPitch(music, pitch)

            timePlayed <- GetMusicTimePlayed(music) / music_length * float32 screenWidth - 40f

            for item in circles do
                item.alpha <- item.alpha + item.speed
                item.radius <- item.radius + item.speed * 10f

                if item.alpha > 1f then
                    item.speed <- item.speed * -1f

                if item.alpha <= 0.0f then
                    item.radius <- float32 (GetRandomValue(10, 40))
                    item.position.X <- float32 (GetRandomValue(int item.radius, screenWidth - int item.radius))
                    item.position.Y <- float32 (GetRandomValue(int item.radius, screenHeight - int item.radius))
                    item.speed <- float32 (GetRandomValue(1, 1000)) / 20000f
                    item.color <- colors[GetRandomValue(0, 13)]

            BeginDrawing()

            ClearBackground Color.RayWhite

            for item in circles do
                DrawCircleV(item.position, item.radius, Fade(item.color, item.alpha))

            DrawRectangle(20, screenHeight - 20 - 12, screenWidth - 40, 12, Color.LightGray)
            DrawRectangle(20, screenHeight - 20 - 12, (int) timePlayed, 12, Color.Maroon)
            DrawRectangleLines(20, screenHeight - 20 - 12, screenWidth - 40, 12, Color.Gray)

            // Draw help instructions
            DrawRectangle(20, 20, 425, 145, Color.White)
            DrawRectangleLines(20, 20, 425, 145, Color.Gray)
            DrawText("PRESS SPACE TO RESTART MUSIC", 40, 40, 20, Color.Black)
            DrawText("PRESS P TO PAUSE/RESUME", 40, 70, 20, Color.Black)
            DrawText("PRESS UP/DOWN TO CHANGE SPEED", 40, 100, 20, Color.Black)
            DrawText($"SPEED:  {pitch}", 40, 130, 20, Color.Maroon)

            EndDrawing()


        UnloadMusicStream music
        CloseAudioDevice()
        CloseWindow()
