@echo off

.paket\paket.bootstrapper.exe

.paket\paket.exe restore
if errorlevel 1 (
  exit /b %errorlevel%
)

fake run build.fsx %*