namespace RaylibExamples.Shared

open System

module Easinngs =

    let EaseLinearNone (t: float32, b: float32, c: float32, d: float32) = c * t / d + b

    let EaseLinearIn (t: float32, b: float32, c: float32, d: float32) = c * t / d + b

    let EaseLinearOut (t: float32, b: float32, c: float32, d: float32) = c * t / d + b

    let EaseLinearInOut (t: float32, b: float32, c: float32, d: float32) = c * t / d + b

    let EaseElasticOut (t: float32, b: float32, c: float32, d: float32) =
        printfn $"{t} - {b} - {c} -  {d}"
        
        if t = 0.0f then
            b
        elif t / d = 1.0f then
            b + c
        else
            let p = d * 0.3f
            let a = c
            let s = p / 4.0f
            a * (2.0f ** (-10.0f * t)) * sin((t * d - s) * 2.0f * float32 Math.PI / p) + c + b


    let EaseElasticIn (t: float32, b: float32, c: float32, d: float32) =

        if t = 0f then
            b
        else if t / d = 1f then
            b + c
        else
            let p = d * 0.3f
            let a = c
            let s = p / 4f

            let postFix = a * (2.0f ** (10.0f * (t - 1.0f)))
            -(postFix * sin ((t * d - s) * (2.0f * float32 Math.PI) / p)) + b

    let easeCubicOut (t: float32) (b: float32) (c: float32) (d: float32) =
        c * ((t / d - 1.0f) * (t / d - 1.0f) * (t / d - 1.0f) + 1.0f) + b
