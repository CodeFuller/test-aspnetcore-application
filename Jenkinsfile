pipeline {
    agent any
    stages {
        stage('Build') {
            steps {
                bat "dotnet restore ${workspace}/TestAspNetCoreApplication.sln --runtime win-x64"
                bat "dotnet build ${workspace}/TestAspNetCoreApplication.sln --configuration Release --no-restore"
            }
        }
        stage('Test') {
            steps {
                bat "dotnet test ${workspace}/TestAspNetCoreApplication.sln --configuration Release --no-build --logger \"trx;LogFileName=TestAspNetCoreApplication.trx\""
                mstest testResultsFile:"**/*.trx", keepLongStdio: true
            }
        }
        stage('Publish') {
            steps {
                bat "dotnet publish ${workspace}/src/TestAspNetCoreApplication/TestAspNetCoreApplication.csproj --configuration Release --runtime win-x64"
            }
        }
    }
}
