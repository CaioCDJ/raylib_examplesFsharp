namespace RaylibExamples.Audio

open System.Numerics
open Raylib_cs
open type Raylib_cs.Raylib
open RaylibExamples.Shared.Util
open Raylib_cs

module PlayingSoundMultipleTimes =

    let mutable currentSound = 0
    let MAX_SOUNDS = 10

    let run =

        let screenWidth = 800
        let screenHeight = 440

        InitWindow(screenWidth, screenHeight, "raylib [audio] example - playing sound multiple times")

        InitAudioDevice()

        let mutable sounds = Array.zeroCreate MAX_SOUNDS
        sounds[0] <- LoadSound "./resources/audio/sound.wav"

        for i in 1..MAX_SOUNDS-1 do
            sounds[i] <- LoadSoundAlias sounds[0]

        while not (C_bool(WindowShouldClose())) do
            if C_bool(IsKeyPressed KeyboardKey.Space) then
                PlaySound sounds[currentSound]
                currentSound <- currentSound + 1

                if currentSound >= MAX_SOUNDS then
                    currentSound <- 0

            BeginDrawing()

            ClearBackground Color.RayWhite

            DrawText("Press SPACE to PLAY a WAV sound!", 200, 180, 20, Color.LightGray)

            EndDrawing()

        for i in 1..MAX_SOUNDS-1 do
            UnloadSoundAlias sounds[i]

        UnloadSound sounds[0]

        CloseAudioDevice()
        CloseWindow()
