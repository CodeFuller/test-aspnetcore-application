pipeline {
    agent any
    stages {
        stage('Build Docker Image') {
            steps {
                bat "docker build --target build -t test-aspnetcore-application-test-results -f ${workspace}/src/TestAspNetCoreApplication/Dockerfile ."
                bat "docker create -ti --name test-results test-aspnetcore-application-test-results"
                bat "docker cp test-results:/project/tests/TestAspNetCoreApplication.IntegrationTests/TestResults/TestAspNetCoreApplication.trx ${workspace_tmp}/TestAspNetCoreApplication.IntegrationTests.trx"
                bat "docker rm -fv test-results"
                mstest testResultsFile:"${workspace_tmp}/TestAspNetCoreApplication.IntegrationTests.trx", keepLongStdio: true

                bat "docker build -t test-aspnetcore-application:latest -f ${workspace}/src/TestAspNetCoreApplication/Dockerfile ."
            }
        }
    }
}
