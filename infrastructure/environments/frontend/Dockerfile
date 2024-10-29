FROM node:23-alpine3.19
WORKDIR /frontapp

COPY ./apps/frontend/ .
RUN npm install
ENTRYPOINT [ "npm", "run", "dev" ]
