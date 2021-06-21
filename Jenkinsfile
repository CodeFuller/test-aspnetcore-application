pipeline {
    agent any
    stages {
        stage('Build Docker Image') {
            steps {
                script {
                    def hasFailedTests = true
                    try {
                        sh (
                            script: "docker cp cucatalog-test-results-${env.BUILD_VERSION}:/build/success.flg ${flgFileName}",
                            label: "Check Tests Results"
                        )
                    } catch (Exception e) {
                        hasFailedTests = false
                    }

                    if (hasFailedTests) {
                        error("Some test(s) have failed")
                    }

                    bat "docker build --target build -t test-aspnetcore-application-test-results -f ${workspace}/src/TestAspNetCoreApplication/Dockerfile ."
                    bat "docker create -ti --name test-results test-aspnetcore-application-test-results"
                    bat "docker cp test-results:/project/tests/TestAspNetCoreApplication.IntegrationTests/TestResults/TestAspNetCoreApplication.trx ${workspace_tmp}/TestAspNetCoreApplication.IntegrationTests.trx"
                    bat "docker rm -fv test-results"
                    mstest testResultsFile:"${workspace_tmp}/TestAspNetCoreApplication.IntegrationTests.trx", failOnError: true, keepLongStdio: true

                    bat "docker cp test-results:/success.flg ${workspace_tmp}/TestAspNetCoreApplication.IntegrationTests.trx"

                    bat "docker build -t test-aspnetcore-application:latest -f ${workspace}/src/TestAspNetCoreApplication/Dockerfile ."
                }
            }
        }
    }
}
