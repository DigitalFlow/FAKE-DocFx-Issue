#r "paket: groupref Main //"
#load "./.fake/build.fsx/intellisense.fsx"

open Fake.Core
open Fake.Core.TargetOperators
open Fake.IO.Globbing.Operators
open Fake.IO.FileSystemOperators
open Fake.DotNet
open Fake.DotNet.Testing.OpenCover
open Fake.Testing
open Fake.IO
open Fake.Documentation

//Project config
let projectName = "DocFX Repro"

Target.create "DocFx" (fun _ ->
    DocFx.metadata (fun p -> 
     { p with 
             ConfigFile = "docs" @@ "docfx.json"
     })

    DocFx.build (fun p -> 
     { p with 
         OutputFolder = "build" @@ "docs"
         ConfigFile = "docs" @@ "docfx.json"    
     })
)

// start build
Target.runOrDefaultWithArguments "DocFx"
