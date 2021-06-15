pipeline {
    agent any
    stages {
        stage('Build') {
            steps {
                bat "dotnet restore --runtime win-x64 ${workspace}/TestAspNetCoreApplication.sln"
            }
        }
    }
}
