# Charge les variables du fichier .env s'il existe
if (Test-Path .env) {
    Get-Content .env | ForEach-Object {
        # Ignore les commentaires et les lignes vides
        if ($_ -match '^[^#=]+=[^=]+') {
            $name, $value = $_.Split('=', 2)
            [Environment]::SetEnvironmentVariable($name, $value, "Process")
        }
    }
}

# Lance l'application
dotnet run