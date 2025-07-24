namespace RaylibExamples.Audio

open System.Numerics
open Raylib_cs
open type Raylib_cs.Raylib
open RaylibExamples.Shared.Util
open Raylib_cs

module MusicPlaying =

    let run =

        let screenWidth = 800
        let screenHeight = 440

        InitWindow(screenWidth, screenHeight, "raylib [audio] example - music playing (streaming)")

        InitAudioDevice()

        let mutable music = LoadMusicStream "./resources/audio/country.mp3"
        
        PlayMusicStream music

        let mutable timePlayed = 0.f
        let mutable pause = false

        SetTargetFPS 60
        
        let music_length = GetMusicTimeLength music

        while not (C_bool(WindowShouldClose())) do
          UpdateMusicStream music

          if C_bool( IsKeyPressed KeyboardKey.Space) then
            StopMusicStream music
            PlayMusicStream music

          if C_bool( IsKeyPressed KeyboardKey.P) then
            pause <- true
            if pause then PauseMusicStream music
            else ResumeMusicStream music

          timePlayed <- GetMusicTimePlayed(music) / music_length
          
          if timePlayed > 1.0f then timePlayed <- 1f

          BeginDrawing()

          ClearBackground Color.RayWhite
            
          
          DrawText("MUSIC SHOULD BE PLAYING!", 255, 150, 20,Color.LightGray);

          DrawRectangle(200, 200, 400, 12, Color.LightGray);
          DrawRectangle(200, 200, int(timePlayed*400.0f), 12, Color.Maroon);
          DrawRectangleLines(200, 200, 400, 12, Color.Gray);

          DrawText("PRESS SPACE TO RESTART MUSIC", 215, 250, 20, Color.LightGray);
          DrawText("PRESS P TO PAUSE/RESUME MUSIC", 208, 280, 20, Color.LightGray);

          EndDrawing()
      
        UnloadMusicStream music
        CloseAudioDevice()
        CloseWindow()
