#!/bin/bash
set -ev

TAG=$1
DOCKER_USERNAME=$2
DOCKER_PASSWORD=$3
DOCKER_IMAGE_NAME="dotnetgeek/shariff-backend-dotnet"

IFS='.' read -r -a tag_array <<< "$TAG"
MAJOR="${tag_array[0]//v}"
MINOR=${tag_array[1]}
BUILD=${tag_array[2]}
SEMVER="$MAJOR.$MINOR.$BUILD"

rm -rf artifacts

cd src
# Create publish artifact
dotnet publish -o ../artifacts -c Release -f netcoreapp1.0  

cd ..
# Build the Docker images
docker build -t $DOCKER_IMAGE_NAME:$SEMVER .
docker tag $DOCKER_IMAGE_NAME:$SEMVER $DOCKER_IMAGE_NAME:latest

# Login to Docker Hub and upload images
docker login -u="$DOCKER_USERNAME" -p="$DOCKER_PASSWORD"
docker push $DOCKER_IMAGE_NAME:$SEMVER
docker push $DOCKER_IMAGE_NAME:latest