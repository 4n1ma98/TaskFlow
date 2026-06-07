pipeline {
    agent {
        docker {
            image 'mcr.microsoft.com/dotnet/sdk:8.0'
            args '-v /var/run/docker.sock:/var/run/docker.sock'
        }
    }

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

		stage('Debug') {
			steps {
				sh 'which docker || true'
				sh 'which docker-compose || true'
				sh 'docker --version || true'
				sh 'docker-compose --version || true'
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
