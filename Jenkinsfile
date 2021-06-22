@Library('controlupdevops') _

pipeline {
    agent any
    parameters {
        choice(name: 'environment', choices: ['dev','qa','stg','prod'], description: 'choose environment')
        extendedChoice bindings: '', description: '',
            multiSelectDelimiter: ',', name: 'buildnumber', quoteValue: false, saveJSONParameterToFile: false, type: 'PT_SINGLE_SELECT',
            value: '0.0.1.5,0.0.1.6,0.0.1.10-preview', visibleItemCount: 20
    }
    stages {
        stage('Build Docker Image') {
            steps {
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
}
