namespace RaylibExamples.Core

open System.Numerics
open Raylib_cs
open type Raylib_cs.Raylib
open RaylibExamples.Shared.Util

module CameraFree3d = 

  let run =  
      let screenWidth = 800
      let screenHeight = 450

      InitWindow(screenWidth, screenHeight, "raylib [core] example - 3d camera free")


      let mutable camera = Camera3D()
      camera.Position <- Vector3(10.0f, 10.0f, 10.0f)
      camera.Target <- Vector3(0.0f, 0.0f, 0.0f)
      camera.Up <- Vector3(0.0f, 1.0f, 0.0f)
      camera.FovY <- 45.0f
      camera.Projection <- CameraProjection.Perspective

      let cubePosition = Vector3(0.0f, 0.0f, 0.0f)

      DisableCursor()

      SetTargetFPS(60)

      while not (WindowShouldClose()) do

        UpdateCamera(&camera, CameraMode.Free)

        if C_bool(IsKeyPressed(KeyboardKey.Z)) then
          camera.Target <- Vector3(0f,0f,0f)
        

        BeginDrawing()

        ClearBackground(Color.RayWhite)
    
        BeginMode3D(camera)

        DrawCube(cubePosition, 2.0f,2f,2f,Color.Red)
        DrawCubeWires(cubePosition, 2.0f,2f,2f,Color.Maroon)

        EndMode3D()

        DrawRectangle( 10, 10, 320, 93, Fade(Color.SkyBlue, 0.5f));
        DrawRectangleLines( 10, 10, 320, 93, Color.Blue);

        DrawText("Free camera default controls:", 20, 20, 10, Color.Black);
        DrawText("- Mouse Wheel to Zoom in-out", 40, 40, 10, Color.DarkGray);
        DrawText("- Mouse Wheel Pressed to Pan", 40, 60, 10, Color.DarkGray);
        DrawText("- Z to zoom to (0, 0, 0)", 40, 80, 10, Color.DarkGray);

        EndDrawing();

      CloseWindow()
