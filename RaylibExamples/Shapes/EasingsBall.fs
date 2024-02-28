namespace RaylibExamples.Shapes

open System
open System.Numerics
open Raylib_cs
open type Raylib_cs.Raylib

module EasingsBall =

    let run =

        let screenWidth = 800
        let screenHeight = 450

        InitWindow(screenWidth, screenHeight, "raylib [shapes] example - easings ball anim")

        let mutable ballPositionX = -100
        let mutable ballRadius = 20
        let mutable ballAlpha = 0f

        let mutable state = 0
        let mutable frameCounter = 0

        SetTargetFPS(60)

        while not (WindowShouldClose()) do
            if state = 0 then
                frameCounter <- frameCounter + 1
        // ballRadius = (int)Easings.EaseElasticIn(framesCounter, 20, 500, 200);

        CloseWindow()
