namespace RaylibExamples.Shared

open Raylib_cs

module Util =
  let C_bool (con: CBool):bool = not (not (con))
