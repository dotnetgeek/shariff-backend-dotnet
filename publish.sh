#!/bin/bash
set -ev

SEMVER=$1
DOCKER_USERNAME=$2
DOCKER_PASSWORD=$3
DOCKER_IMAGE_NAME="dotnetgeek/shariff-backend-dotnet"

rm -rf artifacts

cd src
# Create publish artifact
dotnet publish -o ../artifacts -c Release -f netcoreapp1.0  

# Build the Docker images
docker build -t $DOCKER_IMAGE_NAME:$SEMVER .
docker tag $DOCKER_IMAGE_NAME:$SEMVER $DOCKER_IMAGE_NAME:latest

# Login to Docker Hub and upload images
docker login -u="$DOCKER_USERNAME" -p="$DOCKER_PASSWORD"
docker push $DOCKER_IMAGE_NAME:$SEMVER
docker push $DOCKER_IMAGE_NAME:latest