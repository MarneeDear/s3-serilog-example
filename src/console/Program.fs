// Learn more about F# at http://fsharp.org

open System
open Serilog

[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"
    let logger = new LoggerConfiguration()
    logger.WriteTo.Console() |> ignore //writing to console works

    logger.WriteTo.File("D:\\myapp.log", rollingInterval = RollingInterval.Minute) |> ignore //writing to file works

    //writing to S3 does not work
    //No errors are produced
    //No request is see on the buket
    logger.WriteTo.AmazonS3("log.txt", "mister-logging", Amazon.RegionEndpoint.USWest2, "REDACTED", "REDACTED/REDACTED") |> ignore

    Log.Logger <- logger.CreateLogger()
    Log.Information("Hello, Serilog")
    0 // return an integer exit code
