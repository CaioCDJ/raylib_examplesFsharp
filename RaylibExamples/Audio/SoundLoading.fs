namespace RaylibExamples.Audio

open System.Numerics
open Raylib_cs
open type Raylib_cs.Raylib
open RaylibExamples.Shared.Util
open Raylib_cs

module SoundLoading =

    let run =

        let screenWidth = 800
        let screenHeight = 440

        InitWindow(screenWidth, screenHeight, "raylib [audio] example - sound loading and playing")

        InitAudioDevice()

        let fxWav = LoadSound "./resources/audio/sound.wav"
        let fxOgg = LoadSound "./resources/audio/target.ogg"

        SetTargetFPS 60

        while not (C_bool(WindowShouldClose())) do
        
          if C_bool( IsKeyPressed KeyboardKey.Space) then
              PlaySound fxWav

          if C_bool( IsKeyPressed KeyboardKey.Enter) then
            PlaySound fxOgg


          BeginDrawing()

          ClearBackground Color.RayWhite

          DrawText("Press SPACE to PLAY the WAV sound!", 200, 180, 20, Color.LightGray)
          DrawText("Press ENTER to PLAY the OGG sound!", 200, 220, 20, Color.LightGray)

          EndDrawing()
        
        UnloadSound fxWav
        UnloadSound fxOgg

        CloseAudioDevice()
        CloseWindow()


