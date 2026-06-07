pipeline {
    agent any

    stages {

        stage('Restore') {
            steps {
                sh 'dotnet restore Api_TaskFlow.sln'
            }
        }

        stage('Build') {
            steps {
                sh 'dotnet build Api_TaskFlow.sln --configuration Release'
            }
        }

        stage('Docker Build & Deploy') {
            steps {
                sh 'docker-compose build'
                sh 'docker-compose up -d'
            }
        }
    }
}