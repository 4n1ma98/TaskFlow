FROM jenkins/jenkins:lts

USER root
RUN apt-get update && \
    apt-get install -y docker.io docker-compose && \
    groupmod -g 1001 docker && \
    usermod -aG docker jenkins

USER jenkins
