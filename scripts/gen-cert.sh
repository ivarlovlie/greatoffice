#!/bin/bash

set -Eeuo pipefail

NAME=${1-""}
SUBJECT="/CN=greatoffice-dev-certs\/emailAddress=admin@greatoffice.life/C=NO"

if [ -z "$NAME" ]; then
  echo "Year is not specified, defaulting to current year"
  NAME=$(date +%Y)
fi

if [ -f "$NAME.pfx" ]; then
  echo "$NAME.pfx exists, exiting"
  exit 0
fi
openssl genrsa -out $NAME.key
openssl req -nodes -new -subj $SUBJECT -in $NAME.key -out $NAME.csr
openssl req -nodes -x509 -subj $SUBJECT -newkey rsa:2048 -keyout key.pem -out cert.pem -days 365
openssl x509 -req -days 365 -in $NAME.csr -signkey key.pem -out $NAME.crt
openssl pkcs12 -export -out $NAME.pfx -inkey key.pem -in $NAME.crt

echo "Your cert is at $NAME.pfx"
