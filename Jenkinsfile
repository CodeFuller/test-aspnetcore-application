pipeline {
    agent any
    stages {
        stage('Build') {
            steps {
                bat "dotnet restore --runtime win-x64 ${workspace}/TestAspNetCoreApplication.sln"
                bat "dotnet build --configuration Release --no-restore ${workspace}/TestAspNetCoreApplication.sln"
            }
        }
        stage('Test') {
            steps {
                bat "dotnet test --configuration Release --no-build ${workspace}/TestAspNetCoreApplication.sln"
                mstest testResultsFile:"**/*.trx", keepLongStdio: true
            }
        }
        stage('Publish') {
            steps {
                bat "dotnet publish --configuration Release --runtime win-x64 ${workspace}/src/TestAspNetCoreApplication/TestAspNetCoreApplication.csproj"
            }
        }
    }
}
