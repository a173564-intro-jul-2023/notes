FROM ubuntu:20.04 as build
RUN apt-get update && apt-get install && apt-get install -y build-essential
WORKDIR /app
COPY src/hello.c /app/
RUN gcc -o hello -static hello.c

FROM alpine:3.18.2 as final
WORKDIR /app/
COPY --from=build /app/hello ./
ENTRYPOINT [ "/app/hello" ]