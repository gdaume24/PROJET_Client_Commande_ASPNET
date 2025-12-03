# 1. Obtient le chemin absolu du répertoire où se trouve le script (db)
$ScriptDir = Split-Path -Parent $MyInvocation.MyCommand.Definition

# 2. Définit le chemin absolu du fichier .env
# Assurez-vous que le chemin est correct depuis $ScriptDir (ex: 'db/../src/WebApi/.env')
$RelativeEnv = Join-Path $ScriptDir '../src/WebApi/.env'
$EnvFilePath = Resolve-Path $RelativeEnv

# 3. Se déplace dans le répertoire du script
cd $ScriptDir

docker compose down -v
# 4. Exécute la commande avec le chemin absolu du fichier .env
docker compose --env-file $EnvFilePath up -d