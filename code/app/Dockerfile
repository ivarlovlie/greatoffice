FROM registry.hub.docker.com/library/node:lts-buster-slim AS builder
WORKDIR .
COPY package.json .
RUN npm i
COPY . .
RUN npm run build
FROM registry.hub.docker.com/library/node:lts-buster-slim
USER node:node
WORKDIR .
COPY --from=builder --chown=node:node build build
COPY --from=builder --chown=node:node node_modules node_modules
COPY --chown=node:node package.json .
CMD ["node","build"]