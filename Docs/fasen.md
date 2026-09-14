# Projectfasen

Elke fase bouwt voort op de vorige. Samen dekken ze alle onderdelen van het
leerdoel. Statuswaarden: `niet gestart` · `bezig` · `afgerond`.

| # | Fase | Doelen | Status | Gestart | Afgerond |
|---|---|---|---|---|---|
| 1 | Flutter-omgeving + basisvaardigheden | D1 | bezig | 2026-09-14 | |
| 2 | REST API met authenticatie (.NET) | D2, D4 | niet gestart | | |
| 3 | Flutter UI en navigatie | D1 | niet gestart | | |
| 4 | API-koppeling + state management (Riverpod) | D2, D3 | niet gestart | | |
| 5 | Lokale opslag / offline-ondersteuning (SQLite via drift) | D4 | niet gestart | | |
| 6 | Unit- en widgettests | D5 | niet gestart | | |
| 7 | CI/CD-pipeline en documentatie | D5 | niet gestart | | |

---

## Fase 1 — Flutter-omgeving en basisvaardigheden

**Doelen:** D1

**Scope:** werkende toolchain (SDK, editor, emulator/device, debugger, hot
reload). Basis van de taal Dart. Kleine wegwerp-widgets om gevoel te krijgen bij
de widget tree en het constraints-model.

**Op te leveren**
- [ ] Werkende lokale dev-omgeving, beschreven in de `README.md` in de docs folder
- [ ] Repo-skelet met een vastgestelde mapstructuur
- [ ] Notities over Dart-concepten die afwijken van talen die ik al ken

**Afrondingscriterium:** ik kan een scherm vanaf nul opbouwen en een
layoutprobleem debuggen zonder een tutorial ernaast.

---

## Fase 2 — REST API met authenticatie (.NET)

**Doelen:** D2, D4

**Scope:** ASP.NET Core-project. Datamodel voor taken/gewoontes. CRUD-endpoints.
Persistentie met migrations. Registratie en login met JWT; beveiligde endpoints.
Swagger om alles handmatig te kunnen verkennen.

**Op te leveren**
- [ ] Draaiende API met gedocumenteerde endpoints
- [ ] Databaseschema + migrations
- [ ] Werkende authenticatieflow, geverifieerd via Swagger of een HTTP-client
- [ ] ADR: datamodel en vorm van de API
- [ ] ADR: aanpak van authenticatie

**Afrondingscriterium:** elk endpoint dat de app nodig gaat hebben bestaat en is
handmatig aanroepbaar, met authenticatie afgedwongen.

---

## Fase 3 — Flutter UI en navigatie

**Doelen:** D1

**Scope:** echte schermen op basis van lokale mockdata: takenlijst, taakdetail,
aanmaken/bewerken, gewoonteoverzicht, instellingen. Routing, theming,
herbruikbare componenten.

**Op te leveren**
- [ ] Doorklikbare app op mockdata
- [ ] Gedeelde componenten-/themalaag
- [ ] ADR: aanpak van routing
- [ ] Screenshots in `voortgang/`

**Afrondingscriterium:** de app is end-to-end doorklikbaar zonder dat er iets aan
het netwerk hangt.

---

## Fase 4 — API-koppeling en state management

**Doelen:** D2, D3

**Scope:** mockdata vervangen door de echte backend. Riverpod voor
applicatiestate. Datalaag met repositories. Loading- en error-states consistent
afgehandeld. Tokens opslaan en meesturen; in- en uitloggen stuurt de navigatie.

**Op te leveren**
- [ ] App draait volledig tegen de lokale backend
- [ ] Gelaagde structuur: UI → providers → repositories → API-client
- [ ] Consistente afhandeling van loading en errors
- [ ] ADR: state management en laagindeling
- [ ] Logboeknotitie over de lastigste integratiebug

**Afrondingscriterium:** inloggen, taak aanmaken, zien dat die serverzijde
bewaard blijft, app herstarten, taak staat er nog.

---

## Fase 5 — Lokale opslag en offline-ondersteuning

**Doelen:** D4

**Scope:** SQLite via drift. Local-first lezen. Schrijfacties in de wachtrij
zolang er geen verbinding is, en synchroniseren zodra die terug is. Een
onderbouwde keuze voor conflictafhandeling.

**Op te leveren**
- [ ] Lokaal schema + migrations
- [ ] Synchronisatiemechanisme
- [ ] ADR: offlinestrategie en conflictafhandeling
- [ ] Schermopname in `voortgang/` van gebruik in vliegtuigmodus

**Afrondingscriterium:** bruikbaar met het netwerk uit; wijzigingen worden
verwerkt zodra de verbinding terug is.

---

## Fase 6 — Unit- en widgettests

**Doelen:** D5

**Scope:** unit tests voor businesslogica en synchronisatieregels. Widgettests
voor de belangrijkste schermen. Fakes/mocks voor API en database. Tests voor de
.NET-kant. Waar nodig refactoren om code testbaar te maken.

**Op te leveren**
- [ ] Lokaal draaiende testsuite
- [ ] Coverage-rapportage
- [ ] Logboeknotitie over wat het testen blootlegde in het ontwerp

**Afrondingscriterium:** de tests vangen een bewust geïntroduceerde regressie.

---

## Fase 7 — CI/CD-pipeline en documentatie

**Doelen:** D5

**Scope:** pipeline die bij elke push bouwt en test. Build-artifact wordt
opgeleverd. Projectdocumentatie afgerond. Zelfevaluatie ingevuld. Eindverslag.

**Op te leveren**
- [ ] Werkende CI-pipeline
- [ ] Build-artifact uit de pipeline
- [ ] Volledige `README.md` in de root (installatie, architectuur, hoe te draaien)
- [ ] Zelfevaluatie in `leerdoelen.md` ingevuld
- [ ] Eindverslag / presentatie voor de PDA

**Afrondingscriterium:** iemand anders kan de repo clonen, de README volgen en
beide helften van het project draaien.
