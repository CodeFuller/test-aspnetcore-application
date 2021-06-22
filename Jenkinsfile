@Library('controlupdevops') _

pipeline {
    agent any
    stages {
        stage('Build Docker Image') {
            script {
                def builds = get_version.all("core-cucatalog-service")
                builds.each { item ->
                    println("Detected build: '${item}'")
                }
                error("Terminating the build")
            }
        }
    }
}
