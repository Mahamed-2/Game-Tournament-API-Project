
# Game Tournament API

![.NET](https://img.shields.io/badge/.NET-ASP.NET%20Core-purple)
![Entity Framework](https://img.shields.io/badge/ORM-Entity%20Framework%20Core-blue)
![Database](https://img.shields.io/badge/Database-SQLite-green)
![Architecture](https://img.shields.io/badge/Architecture-Clean--ish-orange)
![Status](https://img.shields.io/badge/Status-Completed-success)
![License](https://img.shields.io/badge/License-MIT-lightgrey)

Detta är min implementation av Game Tournament API-projektet för ASP.NET Core-modulen. Detta API gör det möjligt för arrangörer att skapa och hantera spelturneringar samt schemalägga specifika matcher inom dessa turneringar.

## Projektöversikt

Jag byggde detta RESTful Web API med ASP.NET Core och Entity Framework Core med en SQLite-databas. Jag har följt en "Clean-ish"-arkitektur och separerat ansvarsområden i Controllers-, Services- och Data-lager.

### Implementerade huvudfunktioner

* **CRUD-operationer:** Fullständiga Create-, Read-, Update- och Delete-funktioner för både Tournaments och Games.
* **Datamodeller och relationer:**
  * `Tournament`: Har en titel, beskrivning, max antal spelare och datum.
  * `Game`: Har en titel, tid och tillhör en `Tournament` (en-till-många-relation).
* **DTO-mönster:** Använde Data Transfer Objects (`Create`, `Update`, `Response`) för att frikoppla de interna databasmodellerna från API-kontrakten.
* **Validering:** Lade till strikta valideringsregler med hjälp av Data Annotations (t.ex. minsta stränglängd) och ett anpassat `FutureDateAttribute` för att säkerställa att datum inte sätts i dåtid.
* **Integration av service-lager:** All affärslogik och databasåtkomst är inkapslad i `ITournamentService` och `IGameService`.
* **Sökfunktion:** `GET /api/tournaments`-endpointen accepterar en valfri `?search=` query-parameter för att filtrera turneringar via titel.
* **JWT-säkerhet:** Implementerade JWT-autentisering. `DELETE`-endpoints för både Tournaments och Games är skyddade och kräver en giltig Bearer-token för åtkomst.

### Extra krav (bonusimplementationer)

Jag utmanade mig själv att slutföra några av de extra kraven för att visa en djupare förståelse för att bygga API:er:

1. **Partiella uppdateringar med PATCH (3/5 stjärnor):**  
   Lade till en `[HttpPatch]`-endpoint i `TournamentsController` (`api/tournaments/{id}`). Genom att använda en specialdesignad `TournamentPatchDTO` där alla egenskaper är nullable kan API:t ta emot en uppdateringspayload som endast innehåller de fält klienten vill ändra, medan resten av befintlig data lämnas oförändrad.

2. **Rate Limiting (2/5 stjärnor):**  
   Konfigurerade `System.Threading.RateLimiting` i `Program.cs` för att förhindra missbruk av API:t. Jag applicerade ett `[EnableRateLimiting("PostPolicy")]`-attribut specifikt på `POST`-endpoints. Detta begränsar klienter till maximalt 3 förfrågningar per 10-sekundersfönster innan statuskoden `429 Too Many Requests` returneras.

## Hur du kör projektet

1. **Klona repot:**
   ```bash
   git clone https://github.com/Mahamed-2/Game-Tournament-API-Project.git
   cd Game-Tournament-API-Project/TournamentApi
````

2. **Återställ beroenden och bygg:**

   ```bash
   dotnet restore
   dotnet build
   ```

3. **Kör applikationen:**

   ```bash
   dotnet run
   ```

4. **Utforska API:t:**
   När applikationen körs kan du navigera till `http://localhost:<port>/swagger` i din webbläsare för att interagera med API-endpoints via Swagger UI.

### Testa autentisering

För att testa de skyddade `DELETE`-endpointsen kan du hämta en JWT-token från `POST /api/auth/login`-endpointen med följande hårdkodade testuppgifter:

* **Användarnamn:** `M2`
* **Lösenord:** `bestteachers`

Klistra in den returnerade token i knappen "Authorize" högst upp i Swagger UI med formatet `Bearer <your_token>`.


