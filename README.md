# MesRecettesDbFirst

MesRecettesDbFirst est une application web ASP.NET Core (C#) qui implémente une base de données relationnelle pour la gestion de recettes culinaires, en utilisant l'approche Database-First avec Entity Framework Core.

## Fonctionnalités principales
- Affichage de la liste des recettes avec leurs types, origines et ingrédients associés
- Visualisation des détails de chaque recette
- Architecture MVC (Model-View-Controller)
- Utilisation d'Entity Framework Core (DB-First)

## Structure de la base de données
La base de données comprend les entités principales suivantes :
- **Recette** : Nom, instructions, température et temps de cuisson, type et origine, liste d'ingrédients
- **Ingredient** : Nom, quantité, unité de mesure
- **TypeAliment** : Catégorie de l'aliment (ex : viande, légume, etc.)
- **OrigineAliment** : Origine géographique ou culturelle
- **UniteDeMesure** : Unités pour les ingrédients (grammes, litres, etc.)

## Technologies utilisées
- ASP.NET Core 8.0
- Entity Framework Core 8 (SqlServer)
- Bootstrap 5 (pour le design)
- C#

## Prérequis
- .NET 8 SDK
- SQL Server LocalDB (ou autre instance SQL Server)

## Installation et lancement
1. **Cloner le dépôt**
   ```powershell
   git clone <url-du-repo>
   cd MesRecettesDbFirst
   ```
2. **Configurer la base de données**
   - Vérifiez la chaîne de connexion dans `MesRecettesDbFirst/appsettings.json` (clé `DefaultConnection`).
   - La base de données doit exister et être conforme au modèle DB-First.
3. **Restaurer les dépendances**
   ```powershell
   dotnet restore
   ```
4. **Lancer l'application**
   ```powershell
   dotnet run --project MesRecettesDbFirst/MesRecettesDbFirst.csproj
   ```
   L'application sera accessible sur `https://localhost:7280` ou `http://localhost:5053`.

## Structure du projet
- `Controllers/` : Contrôleurs MVC (ex : HomeController)
- `Models/` : Entités de la base de données
- `Data/` : DbContext Entity Framework
- `Views/` : Vues Razor (pages HTML dynamiques)
- `wwwroot/` : Fichiers statiques (CSS, JS, images)

## Personnalisation
- Pour ajouter des entités ou modifier le schéma, mettez à jour la base de données puis régénérez les modèles avec l'outil EF Core.

## Licence
Ce projet est open-source, sous licence MIT.
