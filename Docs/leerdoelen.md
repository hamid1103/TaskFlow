# Leerdoelen

**Project:** TaskFlow — taak-/gewoontetracker (Flutter-app + zelfgebouwde ASP.NET Core-backend)
**Kader:** Personal Development Activity (PDA)
**Startdatum:** 2026-09-14
**Beoogde afronding:** JJJJ-MM-DD

## Overkoepelend doel

Flutter en Dart leren door een applicatie end-to-end te bouwen — van backend tot
geteste, werkende app — en daarmee praktijkgerichte ervaring opdoen die direct
aansluit bij vaardigheden die relevant zijn voor mijn toekomstige werk als
developer.

---

## D1 — Flutter- en Dart-fundamentals

De taal en het framework goed genoeg begrijpen om een niet-triviale app te bouwen
en te doorgronden, zonder de structuur uit tutorials over te nemen.

**Deelvaardigheden**
- [ ] Dart als taal: null safety, async/await, `Future` vs. `Stream`, records, sealed classes/pattern matching
- [ ] Widget tree: stateless vs. stateful, build-lifecycle, keys en wanneer die uitmaken
- [ ] Layout: het constraints-model (constraints gaan omlaag, sizes gaan omhoog), flex, scrollen
- [ ] Navigatie en routing, inclusief geneste routes
- [ ] Theming en responsive/adaptive layout
- [ ] Zelfstandig documentatie van packages op pub.dev lezen en toepassen

**Behaald betekent:** ik kan uitleggen *waarom* een rebuild plaatsvindt en waar
state hoort te leven, en kan een layout- of rebuild-probleem debuggen zonder
trial-and-error.

**Bewijs:** fase 1 en 3 · logboeknotities · structuur van `lib/`

---

## D2 — Een eigen API bouwen en koppelen

Beide kanten van de lijn in eigen beheer: de backend ontwerpen, die vervolgens
vanuit de client aanspreken, en alles opvangen wat daartussen mis kan gaan.

**Deelvaardigheden**
- [ ] REST API-ontwerp in ASP.NET Core: resources, HTTP-methodes, statuscodes, DTO's vs. entities
- [ ] Persistentielaag (EF Core of alternatief) met migrations
- [ ] Foutafhandeling, validatie en consistente foutresponses
- [ ] HTTP-clientlaag in Dart: serialisatie, timeouts, retries, foutvertaling
- [ ] Debuggen over de grens heen — weten of een bug client- of serverkant zit
- [x] API-documentatie (OpenAPI/Swagger)

**Behaald betekent:** de Flutter-app praat met mijn eigen draaiende backend, en
storingen (geen netwerk, 401, 500, ongeldige payload) leiden tot verstandig
gedrag in de UI in plaats van een crash.

**Bewijs:** fase 2 en 4 · ADR's over API-ontwerp · backend-repo/map

---

## D3 — Professioneel state management (Riverpod)

Voorbij `setState` komen, naar een gestructureerde en testbare aanpak van
applicatiestate.

**Deelvaardigheden**
- [ ] Soorten providers en wanneer je welke gebruikt
- [ ] Async state: loading / data / error overal expliciet afgehandeld
- [ ] Dependency injection en provider overrides
- [ ] UI, state en datalaag scheiden met duidelijke grenzen
- [ ] Onnodige rebuilds voorkomen; lifecycle en disposal van providers begrijpen
- [ ] State-logica testen los van widgets

**Behaald betekent:** state leeft buiten widgets, loading- en error-states worden
volgens één consistent patroon afgehandeld, en ik kan de laagindeling aan iemand
anders verantwoorden.

**Bewijs:** fase 4 · ADR over state management · logboeknotities

---

## D4 — Authenticatie en lokale opslag

De twee functionaliteiten die in vrijwel elke app echte architectuurkeuzes
afdwingen.

**Deelvaardigheden**
- [ ] Authenticatie in ASP.NET Core: registratie, login, tokens uitgeven (JWT), endpoints beveiligen
- [ ] Tokens afhandelen in de client: veilig opslaan, meesturen, verlopen/refreshen
- [ ] Navigatie op basis van authenticatie (ingelogd vs. uitgelogd)
- [ ] Lokale database met SQLite via drift: schema, queries, migrations
- [ ] Offline-ondersteuning: local-first lezen, schrijfacties in de wachtrij, synchroniseren bij herstel van verbinding
- [ ] Omgaan met conflicten wanneer lokale en server-state uiteenlopen
- [ ] Begrijpen wat je juist *niet* aan de clientkant opslaat

**Behaald betekent:** ik kan de app gebruiken met het netwerk uit, en wijzigingen
worden verwerkt zodra de verbinding terug is.

**Bewijs:** fase 2 en 5 · ADR's over authenticatie en offline sync · opnames in `voortgang/`

---

## D5 — Geautomatiseerd testen en opleveren

Werk opleveren dat verifieerbaar is, niet alleen demonstreerbaar.

**Deelvaardigheden**
- [ ] Unit tests voor Dart-businesslogica
- [ ] Widget tests: pumpen, finders, interactie
- [ ] Mocks/fakes voor de API- en databaselaag
- [ ] Tests voor de .NET-backend
- [ ] Code schrijven die überhaupt testbaar is (naden, injectie)
- [ ] CI-pipeline: automatisch builden en testen bij elke push
- [ ] Build-/release-artifacts die uit de pipeline rollen
- [ ] Projectdocumentatie die goed genoeg is om iemand anders het te laten draaien

**Behaald betekent:** een groene pipeline bij elke push, met tests die een
regressie daadwerkelijk zouden vangen in plaats van alleen te controleren dát er
widgets bestaan.

**Bewijs:** fase 6 en 7 · CI-configuratie · coverage-rapportage

---

## Zelfevaluatie

Maandelijks en bij afronding invullen. Schaal: 1 = geen werkende kennis,
2 = lukt met voortdurend naslagwerk, 3 = zelfstandig toepasbaar,
4 = kan de keuzes uitleggen en verdedigen, 5 = zou het kunnen onderwijzen.

| Doel | Start | Halverwege | Eind | Toelichting |
|---|---|---|---|---|
| D1 Flutter- en Dart-fundamentals | | | | |
| D2 Eigen API + koppeling | | | | |
| D3 State management (Riverpod) | | | | |
| D4 Authenticatie + lokale opslag | | | | |
| D5 Testen + CI/CD | | | | |

## Bekende hiaten / openstaande vragen

Doorlopende lijst met dingen die ik nog niet weet. Elk punt is kandidaat voor een
logboeknotitie of een GitHub-issue zodra ik het heb uitgezocht.

- 

## Buiten scope

Expliciet *geen* onderdeel van deze PDA, hier vastgelegd zodat scope creep een
bewuste keuze blijft:

- Publiceren in app stores
- Productiehosting / infrastructuur buiten de CI-pipeline om
- Samenwerkingsfunctionaliteit voor meerdere gebruikers
- Push notifications
