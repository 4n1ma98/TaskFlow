pipeline {
    agent any

    stages {

        stage('Docker Build & Deploy') {
            steps {
                sh 'docker compose build'
                sh 'docker compose up -d'
            }
        }

    }
}