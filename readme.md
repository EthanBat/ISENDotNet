# Prérequis
* Installer Visual Studio Code
* Installer Dotnet Core SDK & Runtime :

https://www.microsoft.com/net/download/core


# Préparatifs
`mkdir Isen.DotNet`  
`cd Isen.DotNet`  
`git init`  
`touch .gitignore`  
`touch readme.md`  
`code .`


# Création de l'espace de travail
## Création d'un projet console
`mkdir Isen.DotNet.ConsoleApp`  
`cd Isen.DotNet.ConsoleApp`  
`dotnet new console`  
`dotnet run`

## Commit Git
Depuis la racine du projet : 
Etat des fichiers (non trackés) : `git status`  
Tracker les fichiers : `git add .`
Ils sont maintenant suivis : `git status`
Commit : `git commit -m "Initial commit"`
`git commit -a -m "updated readme"`