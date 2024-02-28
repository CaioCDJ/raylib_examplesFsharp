namespace RaylibExamples.Shared

module Easinngs =

    let EaseLinearNone (t: float32, b: float32, c: float32, d: float32) = (c * t / d + b)

    let EaseLinearIn (t: float32, b: float32, c: float32, d: float32) = (c * t / d + b)

    let EaseLinearOut (t: float32, b: float32, c: float32, d: float32) = (c * t / d + b)

    let EaseLinearInOut (t: float32, b: float32, c: float32, d: float32) = (c * t / d + b)
