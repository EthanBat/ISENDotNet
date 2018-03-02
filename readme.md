# Prérequis
* Installer Visual Studio Code    
* Installer Dotnet Core SDK & Runtime : https://www.microsoft.com/net/download/core    

# Préparatifs
`mkdir Isen.DotNet`     
`cd Isen.DotNet`     
`git init`     
`touch .gitignore`     
`touch readme.md`     
`code .`     

# Création de l'espace de travail
## Création d'un projet console
Depuis le dossier Isen.DotNet :  
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
Prendre en compte les modifs (**mais pas les ajouts de fichiers**) au moment du commit (donc faire un add et un commit en même temps :  
`git commit -a -m "updated readme"`  

## Création d'un projet librairie
Depuis le dossier Isen.DotNet :  
`mkdir Isen.DotNet.Library`  
`cd Isen.DotNet.Library`  
`dotnet new classlib`  

## Ajout de la librairie en référence du projet console
Depuis le dossier du projet Console :  
`dotnet add reference ..\Isen.DotNet.Library\Isen.DotNet.Library.csproj`  
Coder la classe Hello.  
Dans le Program.cs, ajouter le using, et appeler la classe Hello.  

## Création d'une solution et ajout des projets
Depuis le dossier racine  
Créer le fichier solution : `dotnet new sln`  
Ajouter le projet librairie :
`dotnet sln add Isen.DotNet.Library\Isen.DotNet.Library.csproj`  
Ajouter le projet console :  
`dotnet sln add Isen.DotNet.ConsoleApp\Isen.DotNet.ConsoleApp.csproj`  
Commit git :   
`git add .`  
`git commit -m "Console, lib, solution"`  

## Ajout d'un projet de test
*TDD = Test Driven Development*  
Depuis le dossier racine :  
`mkdir Isen.DotNet.Tests && cd Isen.DotNet.Tests`  
Créer le projet de tests
`dotnet new xunit`  
Ajouter ce projet à la solution (depuis le dossier racine)
`dotnet sln add Isen.DotNet.Tests\Isen.DotNet.Tests.csproj`  
Depuis le dossier du projet de tests :  
 `dotnet add reference ..\Isen.DotNet.Library\Isen.DotNet.Library.csproj`  
 Commit git (penser à se remettre dans le dossier racine)  
`git add .`  
`git commit -m "Test project"`  

## Push du projet sur un repo remote
Créer un projet sur le serveur Git de votre choix (GitHub, GitLab, interne ISEN...)  
L'url de mon repo est https://gitlab.com/moi/mon-projet.git  
`git remote add origin https://gitlab.com/moi/mon-projet.git`  
Push, en indiquant que master correspond à origin/master  
`git push -u origin master`  

## Ajout d'un tag Git
Créer le tag dans le repo local  
`git tag v0.1`  
Pusher le tag dans le remote repo  
`git push origin v0.1`  

# Ajout d'un modèle
## Types Person et City
Dans le projet Library :  
* Créer un dossier Models/Implementation
* Créer un classe `Person` :
  * `Id` (int)
  * `Name` (string)
  * `FirstName` (string)
  * `LastName` (string)
  * `BirthDate` (DateTime)
* Créer une classe `City` : 
  * `Id` (int)
  * `Name` (string)

## Refactoring : extraction d'un BaseModel
Les classes Person et City ont une partie de leur logique commune.  
Extraire ce qui est commun dans une classe abtraite `BaseModel`.  
La classe de base sera dans le dossier Models/Base.  

# Ajout de Repositories
## CityRepository
A la racine du projet Library, créer un dossier `Repositories/InMemory`  
Ajouter une classe `InMemoryCityRepository`  
Extraire l'interface de ce repo dans `Repositories/Interfaces/IInMemoryCityRepository.cs`  

## Refactoring interface : extraire IBaseRepository
Déplacer les 3 méthodes de l'interface vers IBaseRepository  

## Refactoring Repository
* Créer la classe abstraite Repositories/Base/_BaseRepository.cs  
* Déplacer la logique de CityRepository vers cette classe  

## Appliquer au modele Person
* Dupliquer ICityRepository vers IPersonRepository et adapter ce qui doit l'être.  
* Dupliquer InMemoryCityRepository afin de créer InMemoryPersonRepository.  

## Ajouter une méthode de requête (Find)
Dans `IBaseRepository<T>` et `BaseRepository<T>`, ajouter une méthode Find, qui prendra une fonction de filtrage en paramètre.  

# CRUD
* C = Create
* R = Read
* U = Update
* D = Delete

## Ajout du Delete
Dans `IBaseRepository<T>` et `BaseRepository<T>`, ajouter 2 méthodes :
* Delete(int id)
* Delete(T model)
Ajouter les méthodes `DeleteRange` suivantes:
* DeleteRange(IEnumerable<T> models)
  * Usage: `repo.DeleteRange(new List<T> {p1, p2 ,p3});`
* DeleteRange(params T[] models)
  * Usage: `repo.DeleteRange(p1, p2,p3);`

## Ajout de l'Update
Au niveau du BaseModel, ajouter une propriété `IsNew`  
Dans `BaseInMemoryRepository`, ajouter une méthode `NewId()`, qui renverra le prochain id disponible.  
Dans l'interface `_IBaseRepository`, ajouter la méthode `void Update(T model)`  
Dans `BaseRepository`, ajouter la méthode `void Update(T model)` (abstraite)  
Dans `BaseInMemoryRepository` , overrider et implémenter la méthode Update.  
Dans `IBaseRepository` et `BaseRepository`, ajouter les méthodes `UpdaeRange` suivantes:
* UpdateRange(IEnumerable<T> models)
  * Usage: `repo.UpdateRange(new List<T> {p1, p2 ,p3});`
* DeleteRange(params T[] models)
  * Usage: `repo.UpdateRange(p1, p2,p3);`

# Projet Asp.Net Core MVC
## Création du projet
Créer du dossier du projet. Depuis le dossier racine:
`mkdir Isen.DotNet.Web && cd Isen.DotNet.Web`
Ajouter un projet de type MVC :
`dotnet new mvc`
Référencer la librairie :
`dotnet add reference ..\Isen.DotNet.Library\Isen.DotNet.Library.csproj` 
Ajouter le projet web à la solution (depuis la racine de la solution) :
`dotnet sln add Isen.DotNet.Web\Isen.DotNet.Web.csproj`
Compiler / exécuter :
`dotnet run`
Ouvrir le navigateur :
`http://localhost:5000`

## Découvrir et nettoyer les vues
Localiser les fichiers qui correspondent aux actions Index, About et Contact de la vue home.
Vider ces vues.
Ecrire le nom et l'url de la vue dans chacune des 3 actions.

## Configurer la minification js et css
A la racine du projet web, il y a un fichier bundleconfig.json
Pour que la minification se fasse au build/run :
`dotnet add package BuildBundlerMinifier`

## Eléments de syntaxe Razor (moteur de templating)
Dans Home/Index.cshtml, créer une liste C# des URL.
Itérer pour afficher ces URL dans la grid Bootstrap.
Pour afficher les erreurs cshtml détaillées :
`set ASPNETCORE_ENVIRONMENT=Development` puis `dotnet run`
Pour revenir au mode production  :
`set ASPNETCORE_ENVIRONMENT=Production`

## Vues imbriquées / Injections de vues
Views/Shared/_Layout.cshtml est le template de toutes les pages.
Les actions sont injectées au niveau de `@RenderBody`

### Extraire le footer
Créer dans le dossier `Views/Shared` un fichier `_Footer.cshtml`
Localiser le contenu du footer dans Layout et le couper/coller vers Footer.
Remplacer par un appel à ce footer avec `@Html.Partial("_Footer)`.

## Extraire le menu
Créer dans `Views/Shared` un fichier _Nav.cshtml
Identifier le html correspondant au menu bootstrap
Déplacer vers `_Nav`
Injecter `_Nav` dans `_Layout`

## Vues particulières et conventions
### _Layout
`_Layout` n'est **pas** appelée par convention. Elle est appelée par `_ViewStart.cshtml`
ViewStart est appelée par convention de nommage, avant chaque chargement de vue.
Ajouter du contenu dans ViewStart et voir où il tombe.

### ViewImports
`_ViewImports` permet de regrouper des @using utilisés par le C# embarqué dans les vues.

### Layout alternatif
Créer un nouveau fichier de Layout (dupliquer _Layout et l'appeler _LayoutEmpty.cshtml).
Conserver la structure HTML, les imports CSS et JS, mais retirer toute la mise en forme et le menu.
Modifier la vue About afin qu'elle utilise _LayoutEmpty.

## Manipulation du menu Bootstrap
Dans le fichier `_Nav.cshtml`, ajouter les éléments suivants (en dropdown) :
* Villes
  * Toutes...
  * Nouvelle...  
Ne pas mettre du lien pour l'instant, mettre # à la place des liens.
Adapter un menu issu du site Bootstrap 3.3 (https://getbootstrap.com/docs/3.3/).