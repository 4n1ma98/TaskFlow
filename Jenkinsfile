pipeline {
    agent any

    stages {
        stage('Checkout') {
            steps {
                git branch: 'main',
                    url: 'https://github.com/4n1ma98/TaskFlow.git',
                    credentialsId: '4d557b37-b11e-4327-9bee-22df3da8e7dd'
            }
        }

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
