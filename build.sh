#!/bin/bash

FG_RED="\x1b[0;31m"
FG_MAIN=$FG_RED
FG_BLUE="\x1b[0;34m"
FG_RESET="\x1b[0m"

PROMPT="["$FG_MAIN"CINNABAR"$FG_RESET"]"

log () {
  echo -e "$PROMPT ["$FG_BLUE"INFO"$FG_RESET"] $@"
}
log_error () {
  echo -e "$PROMPT ["$FG_RED"ERROR"$FG_RESET"] $@"
}

cd Cinnabar

dotnet --version > /dev/null 2>&1
if [ $? -ne 0 ]; then
  log_error "dotnet sdk not installed"
fi


log "Restoring"
dotnet restore

log "Building"
dotnet publish --configuration Release

cd ./bin/Release/net8.0/publish

log "Running"
sleep 2
./Cinnabar
