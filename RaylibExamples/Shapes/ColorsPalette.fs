namespace RaylibExamples.Shapes

open System
open System.Numerics
open Raylib_cs
open type Raylib_cs.Raylib


module ColorsPalette =

    let MAX_COLORS_COUNT = 21

    let run =

        let screenWidth = 800
        let screenHeight = 450
        InitWindow(screenWidth, screenHeight, "raylib [shapes] example - colors palette")

        let colors =
            [| Color.DarkGray
               Color.Maroon
               Color.Orange
               Color.DarkGreen
               Color.DarkBlue
               Color.DarkPurple
               Color.DarkBrown
               Color.Gray
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
               Color.Beige |]

        let colorsName =
            [| "DARKGRAY"
               "MAROON"
               "ORANGE"
               "DARKGREEN"
               "DARKBLUE"
               "DARKPURPLE"
               "DARKBROWN"
               "GRAY"
               "RED"
               "GOLD"
               "LIME"
               "BLUE"
               "VIOLET"
               "BROWN"
               "LIGHTGRAY"
               "PINK"
               "YELLOW"
               "GREEN"
               "SKYBLUE"
               "PURPLE"
               "BEIGE" |]

        let mutable colorsRecs: Rectangle array =
            Array.zeroCreate<Rectangle> (MAX_COLORS_COUNT)


        for i in 0 .. MAX_COLORS_COUNT - 1 do
            colorsRecs[i].X <- 20.0f + 100.0f * float32 (i % 7) + 10.0f * float32 (i % 7)
            colorsRecs[i].Y <- 80.0f + 100.0f * float32 (i / 7) + 10.0f * float32 (i / 7)
            colorsRecs[i].Width <- 100.0f
            colorsRecs[i].Height <- 100.0f

        let mutable colorsSlate: int array = Array.zeroCreate<int> (MAX_COLORS_COUNT)

        let mutable mousePoint = Vector2(0f, 0f)

        SetTargetFPS(60)

        while not (WindowShouldClose()) do
            mousePoint <- GetMousePosition()

            for i in 0 .. MAX_COLORS_COUNT - 1 do
                if not (not (CheckCollisionPointRec(mousePoint, colorsRecs[i]))) then
                    colorsSlate.[i] <- 1
                else
                    colorsSlate.[i] <- 0

            BeginDrawing()

            DrawText("raylib colors palette", 28, 42, 20, Color.Black)
            DrawText("press SPACE to see all colors", GetScreenWidth() - 180, GetScreenHeight() - 40, 10, Color.Gray)

            for i in 0 .. MAX_COLORS_COUNT - 1 do
                DrawRectangleRec(colorsRecs[i], Fade(colors.[i], (if colorsSlate.[i] <> 0 then 0.6f else 1.0f)))

                if not (not (IsKeyDown(KeyboardKey.Space))) || colorsSlate.[i] <> 0 then
                    DrawRectangle(
                        int colorsRecs.[i].X,
                        int (colorsRecs.[i].Y + colorsRecs.[i].Height - 26.0f),
                        int colorsRecs.[i].Width,
                        20,
                        Color.Black
                    )

                    DrawRectangleLinesEx(colorsRecs.[i], 6f, Fade(Color.Black, 0.3f))

                    DrawText(
                        colorsName.[i],
                        int (
                            colorsRecs.[i].X + colorsRecs.[i].Width
                            - float32 (MeasureText(colorsName.[i], 10))
                            - 12.0f
                        ),
                        int (colorsRecs.[i].Y + colorsRecs.[i].Height - 20f),
                        10,
                        colors.[i]
                    )

            EndDrawing()

        CloseWindow()
