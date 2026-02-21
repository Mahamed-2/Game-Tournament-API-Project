# Game Tournament API

This is my implementation of the Game Tournament API project for the ASP.NET Core module. This API allows organizers to create and manage game tournaments and schedule specific games within those tournaments. 

## Project Overview

I built this RESTful Web API using ASP.NET Core and Entity Framework Core with an SQLite database. I've followed the "Clean-ish" architecture, separating concerns into Controllers, Services, and Data layers.

### Key Features Implemented

*   **CRUD Operations:** Full Create, Read, Update, and Delete capabilities for both Tournaments and Games.
*   **Data Models & Relationships:**
    *   `Tournament`: Has a title, description, max players, and date.
    *   `Game`: Has a title, time, and belongs to a `Tournament` (One-to-Many relationship).
*   **DTO Pattern:** Used Data Transfer Objects (`Create`, `Update`, `Response`) to decouple the internal database models from the API contracts.
*   **Validation:** Added strict validation rules using Data Annotations (e.g., minimum string lengths) and a custom `FutureDateAttribute` to ensure dates aren't set in the past.
*   **Service Layer Integration:** All business logic and database access are encapsulated within `ITournamentService` and `IGameService`.
*   **Search Functionality:** The `GET /api/tournaments` endpoint accepts an optional `?search=` query parameter to filter tournaments by title.
*   **JWT Security:** Implemented JWT authentication. The `DELETE` endpoints for both Tournaments and Games are secured and require a valid Bearer token to access.

### Extra Requirements (Bonus Implementations)

I challenged myself to complete a couple of the extra requirements to demonstrate a deeper understanding of building APIs:

1.  **Partial Updates with PATCH (3/5 Stars):** 
    Added an `[HttpPatch]` endpoint to `TournamentsController` (`api/tournaments/{id}`). Using a specially designed `TournamentPatchDTO` where all properties are nullable, the API can accept an update payload that only contains the fields the client wants to change, leaving the rest of the existing data intact.
2.  **Rate Limiting (2/5 Stars):**
    Configured `System.Threading.RateLimiting` in `Program.cs` to prevent abuse of the API. I applied an `[EnableRateLimiting("PostPolicy")]` attribute specifically to the `POST` endpoints. This restricts clients to maximum 3 requests per 10-second window before returning a `429 Too Many Requests` status.

## How to Run the Project

1.  **Clone the repository:**
    ```bash
    git clone https://github.com/Mahamed-2/Game-Tournament-API-Project.git
    cd Game-Tournament-API-Project/TournamentApi
    ```

2.  **Restore dependencies and build:**
    ```bash
    dotnet restore
    dotnet build
    ```

3.  **Run the application:**
    ```bash
    dotnet run
    ```

4.  **Explore the API:**
    Once running, you can navigate to `http://localhost:<port>/swagger` in your browser to interact with the API endpoints using the Swagger UI.

### Testing Authentication

To test the secured `DELETE` endpoints, you can fetch a JWT token from the `POST /api/auth/login` endpoint using the hardcoded test credentials:
* **Username:** `M2`
* **Password:** `bestteachers`

Paste the returned token into the "Authorize" button at the top of the Swagger UI using the format `Bearer <your_token>`.

---


