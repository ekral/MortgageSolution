# Mortgage Solution

Solution obsahující výchozí kód pro práci s databází s pomocí databáze Sqlite a technologie ADO.NET.

1. Vytvořte zobrazení seznamu hypoték v desktopové aplikaci ve Frameworku Avalonia s využitím MVVM a Commandů. Využijte třídu ObservableCollection. Vyzkoušejte si jak vyvolání eventu PropertyChange, tak použití metod z rodičovské třídy ViewModelBase.
2. Vytvořte zjednodušenou verzi předcházející aplikace bez využití MVVM a Commandů ale s využitím eventů, ale také s využitím třídy ObservableCollection. Porovnejte výhody a nevýhody obou řešení.
3. Vytvořte zjednodušenou verzi aplikace s využitím MVVM a bindováním na metodu. Aplikace bude obsahovat tlačítko "Load" které načte hypotéky z databáze a zobrazí je v aplikace.
4. Použijte Entity Framework včetně migrací pro aplikaci. Vytvořte rozhraní IDatabaseService a dvě implementace DatabaseServiceEntityFramework a DatabaseServiceAdoNet.

Poznámky pro Entity Framework:
- Na školních počítačích použijte v terminálu příkaz  $env:Path = "D:\dotnet;C:\Users\ekral\\.dotnet\tools" kde změňte uživatelské jméno a případně cestu k souboru dotnet.exe.
- Návod pro Entity Framework: [Getting Started with EF Core](https://learn.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=netcore-cli#install-entity-framework-core)
