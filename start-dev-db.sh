#!/bin/sh

CONTAINER_NAME='tichu-counter-db'

# shellcheck disable=SC2015
docker container exists "$CONTAINER_NAME" && (docker start "$CONTAINER_NAME" || true) || docker run -d -p 3306:3306 --env="MYSQL_DATABASE=tichu_counter" --env="MYSQL_ROOT_PASSWORD=rootpw" --name "$CONTAINER_NAME" mysql:8.4
