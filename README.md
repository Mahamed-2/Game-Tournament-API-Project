# Game Tournament API

Detta är min implementation av Game Tournament API-projektet för ASP.NET Core-kursen. Detta API låter arrangörer skapa och hantera turneringar samt schemalägga specifika matcher inom dessa turneringar. 

## Projektöversikt

Jag har byggt detta RESTful Web API med ASP.NET Core och Entity Framework Core. Jag har följt en "Clean-ish" arkitektur och separerat ansvarsområden i Controllers, Services och Data-lager.

### Implementerade Huvudfunktioner

* **CRUD-operationer:** Fullständiga funktioner för Create, Read, Update och Delete för både Tournaments (turneringar) och Games (matcher).
* **Datamodeller & Relationer:** * `Tournament`: Har en titel, beskrivning, max antal spelare och datum.
  * `Game`: Har en titel, tid och tillhör en `Tournament` (En-till-många-relation).
* **DTO-mönster:** Använder Data Transfer Objects (`Create`, `Update`, `Response`) för att frikoppla de interna databasmodellerna från API-kontrakten.
* **Validering:** Strikta valideringsregler med hjälp av Data Annotations (t.ex. minsta stränglängd) och anpassad validering för att säkerställa att datum inte sätts i dåtid.
* **Service-lager Integration:** All affärslogik och databasåtkomst är inkapslad i `ITournamentService` och `IGameService`.
* **Sökfunktion:** `GET /api/tournaments`-endpointen accepterar en valfri `?search=` query-parameter för att filtrera turneringar via titel.
* **JWT-säkerhet:** Implementerad JWT-autentisering. `DELETE`-endpoints för både Tournaments och Games är säkrade och kräver en giltig Bearer-token för åtkomst.

### Frivilliga Extra Krav (Bonus)

Jag utmanade mig själv att slutföra ett par av de extra kraven för att visa på en djupare förståelse för API-utveckling:

1. **Partiella uppdateringar med PATCH (3/5 ⭐):** Lade till en `[HttpPatch]`-endpoint i `TournamentsController` (`api/tournaments/{id}`). Genom att använda en specialdesignad `TournamentPatchDTO` där alla properties är nullable (valfria), kan API:t ta emot en uppdaterings-payload som bara innehåller de fält klienten vill ändra, och lämnar resten av befintlig data orörd.
