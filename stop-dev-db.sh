#!/bin/sh

CONTAINER_NAME='tichu-counter-db'

# shellcheck disable=SC2015
docker container stop "$CONTAINER_NAME"
