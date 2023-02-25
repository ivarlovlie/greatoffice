#!/usr/bin/env bash

set -Eueo pipefail

CURRENT_DEV_VERSION=$(cat .version-dev)
CURRENT_DEV_VERSION_INT=${CURRENT_DEV_VERSION//[!0-9]/}
CURRENT_VERSION=$(cat .version)
CURRENT_VERSION_INT=${CURRENT_VERSION//[!0-9]/}
if [ ${1-prod} == "dev" ]; then
  NEW_VERSION="v$((CURRENT_DEV_VERSION_INT + 1))-dev"
  OLD_VERSION=$CURRENT_DEV_VERSION
else
  NEW_VERSION="v$((CURRENT_VERSION_INT + 1))"
  OLD_VERSION=$CURRENT_VERSION
fi
IMAGE_NAME="greatoffice/server"
HUB_NAME="dr.ivar.systems/greatoffice/server"

# Check for uncommited changes and optionally commit them
if [ "$(git status --untracked-files=no --porcelain)" ]; then
  echo "Unclean git tree! press CTRL+C to exit or press ENTER to commit and push to the default branch"
  read -n 1

  read -p "Enter commit message: " COMMIT_MESSAGE
  git add ..
  git commit --quiet -m "$COMMIT_MESSAGE"
fi

if [ ${1-prod} == "dev" ]; then
  echo $NEW_VERSION >|.version-dev
  git add .version-dev
else
  echo $NEW_VERSION >|.version
  git add .version
fi

echo "Starting build of $HUB_NAME:$NEW_VERSION at $(date -u)..."
echo

# Put version.txt inside of server
pushd src/wwwroot
echo "$NEW_VERSION" >version.txt
git add version.txt
popd

git commit --quiet -m "chore(release): Bump version"

read -p "Do you want to tag this build? (y/n) " -n 1 -r
echo
if [[ $REPLY =~ ^[Yy]$ ]]; then
  read -p "Enter tag message (can be empty): " TAG_MESSAGE
  git tag -am "$TAG_MESSAGE" $NEW_VERSION
fi

read -p "Do you want to push the latest commits and tags to origin? (y/n) " -n 1 -r
echo
if [[ $REPLY =~ ^[Yy]$ ]]; then
  echo "Pushing latest changes to remotes..."
  echo
  git push --quiet --follow-tags
fi

# Build docker image
echo "Building docker image"
echo

docker build -t $IMAGE_NAME:$NEW_VERSION .

docker tag $IMAGE_NAME:$NEW_VERSION $HUB_NAME:$NEW_VERSION

if [ ${1-prod} == "dev" ]; then
  docker tag $IMAGE_NAME:$NEW_VERSION $HUB_NAME:latest-dev
fi
if [ ${1-prod} == "prod" ]; then
  docker tag $IMAGE_NAME:$NEW_VERSION $HUB_NAME:latest
fi

# Optionally push images to docker registry
echo "Press CTRL+C to exit or press ENTER to push docker image to registry"
read -n 1
docker push $HUB_NAME:$NEW_VERSION

if [ ${1-prod} == "dev" ]; then
  docker push $HUB_NAME:latest-dev
fi

if [ ${1-prod} == "prod" ]; then
  docker push $HUB_NAME:latest
fi
