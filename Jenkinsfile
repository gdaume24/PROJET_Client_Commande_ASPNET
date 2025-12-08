pipeline {
    agent any

    environment {
        ACR_NAME = "monregistryazure"
        IMAGE_NAME = "myapp-api"
        AZ_RESOURCE_GROUP = "mon-resource-group"
        AZ_WEBAPP_NAME = "myapp-api-webapp"
        ACR_LOGIN_SERVER = "${ACR_NAME}.azurecr.io"
    }

    stages {

        stage('Checkout') {
            steps {
                echo "🔍 Récupération du code source"
                checkout scm
            }
        }

        stage('Restore + Build .NET') {
            steps {
                echo "⚙️ Build .NET API"
                sh 'dotnet restore'
                sh 'dotnet build --configuration Release'
                sh 'dotnet publish -c Release -o out'
            }
        }

        stage('Docker Build') {
            steps {
                echo "🐳 Construction de l’image Docker .NET API"
                sh "docker build -t ${ACR_LOGIN_SERVER}/${IMAGE_NAME}:latest ."
            }
        }

        stage('Login ACR') {
            steps {
                echo "🔐 Connexion à Azure Container Registry"
                withCredentials([usernamePassword(credentialsId: 'azure-acr-creds', usernameVariable: 'AZ_USER', passwordVariable: 'AZ_PASS')]) {
                    sh "echo ${AZ_PASS} | docker login ${ACR_LOGIN_SERVER} -u ${AZ_USER} --password-stdin"
                }
            }
        }

        stage('Docker Push') {
            steps {
                echo "📤 Push de l'image API dans l'ACR"
                sh "docker push ${ACR_LOGIN_SERVER}/${IMAGE_NAME}:latest"
            }
        }

        stage('Deploy to Azure') {
            steps {
                echo "🚀 Déploiement de l'API sur Azure Web App"
                sh """
                    az webapp config container set \
                      --name ${AZ_WEBAPP_NAME} \
                      --resource-group ${AZ_RESOURCE_GROUP} \
                      --docker-custom-image-name ${ACR_LOGIN_SERVER}/${IMAGE_NAME}:latest \
                      --docker-registry-server-url https://${ACR_LOGIN_SERVER}
                """

                sh """
                    az webapp restart \
                      --name ${AZ_WEBAPP_NAME} \
                      --resource-group ${AZ_RESOURCE_GROUP}
                """
            }
        }
    }

    post {
        success { echo "🎉 API déployée avec succès !" }
        failure { echo "❌ Erreur dans le déploiement API" }
    }
}
