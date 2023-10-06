# Minimal .NET -> WebAssembly via NativeAOT-LLVM

This repo contains two examples.

## Prerequisites

 * .NET 8 SDK
 * To run the output on the command line, get [wasmtime](https://wasmtime.dev/) and put it on your PATH

## ConsoleApp

The default "Hello World" app

To build:

 * `cd ConsoleApp`
 * `dotnet build` (note: takes a few mins on the first run to acquire the SDKs, but is fast after)
 * You now have `bin/Debug/net8.0/wasi-wasm/publish/ConsoleApp.wasm`

To run:

 * `wasmtime bin/Debug/net8.0/wasi-wasm/publish/ConsoleApp.wasm`

## StandaloneLibrary

This produces a wasm module with an export called `add` you can invoke from some host environment.

To build:

 * `cd StandaloneLibrary`
 * `dotnet build`
 * You now have `bin/Debug/net8.0/wasi-wasm/publish/StandaloneLibrary.wasm`
 
Note that this is a "reactor" module, i.e., one with imports and exports but no entrypoint. So to run code from it, you have to call a named export and pass whatever parameters it wants, e.g., to run on the CLI:

 * `wasmtime bin/Debug/net8.0/wasi-wasm/publish/StandaloneLibrary.wasm --invoke add 123 456`
 * `wasmtime bin/Debug/net8.0/wasi-wasm/publish/StandaloneLibrary.wasm --invoke subtract 123 456`

... but more commonly, reactor modules are consumed by some hosting environment such as a web server that makes calls to your module's exports.
