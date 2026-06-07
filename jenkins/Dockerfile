FROM jenkins/jenkins:lts

USER root

RUN apt-get update && \
    apt-get install -y wget gnupg apt-transport-https docker.io docker-compose

RUN groupmod -g 1001 docker || true
RUN usermod -aG docker jenkins

USER root