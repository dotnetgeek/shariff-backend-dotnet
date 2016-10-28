#!/bin/bash
set -ev

dotnet restore
cd tests/
dotnet test
cd ../src/
dotnet build -c Release