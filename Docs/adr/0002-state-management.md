# 0002 — State management met Riverpod

**Status:** Voorgesteld
**Datum:** JJJJ-MM-DD
**Fase:** 4
**Doelen:** D1, D3

> **Concept.** Riverpod staat al in het PDA-plan, dus de uitkomst ligt vooraf
> vast — maar schrijf de vergelijking *vóór* fase 4, zolang je nog met een
> buitenstaandersblik naar de alternatieven kijkt. Een ADR waarvan de
> optiesectie neerkomt op "dat stond in het plan" is waardeloos bij een
> beoordeling. Vul elke optie in nadat je de documentatie ervan daadwerkelijk
> hebt gelezen, verwijder daarna deze notitie en zet de status op Geaccepteerd.

## Context

TaskFlow heeft state nodig die losse widgets overleeft: de ingelogde gebruiker
en diens token, de lijst met taken/gewoontes, de synchronisatiestatus, en de
loading- en error-state van elke netwerkaanroep. Lokale `setState` kan dit niet
uitdrukken zonder callbacks en data door meerdere widgetlagen heen door te geven.

Randvoorwaarden die specifiek zijn voor dit project:
- Professioneel state management leren is een expliciet leerdoel (D3), dus de
  keuze moet neigen naar wat in de praktijk gangbaar is, niet naar wat het
  snelst werkend te krijgen is.
- Dezelfde oplossing moet zowel async data uit de API aankunnen (fase 4) als uit
  de lokale database (fase 5), inclusief het offlinegeval waarin beide spelen.
- State-logica moet testbaar zijn zonder widgets te mounten (D5).

## Overwogen opties

### Optie A — `setState` + `InheritedWidget`
Voordelen:
Nadelen:

### Optie B — Provider
Voordelen:
Nadelen:

### Optie C — Riverpod
Voordelen:
Nadelen:

### Optie D — Bloc / flutter_bloc
Voordelen:
Nadelen:

## Beslissing

<In te vullen. Benoem wat er daadwerkelijk wordt gekozen, en zeg expliciet dat
het leerdoel onderdeel is van de onderbouwing — dat is in een PDA-context een
legitiem argument, maar alleen als je het uitschrijft in plaats van verstopt.>

## Gevolgen

**Positief:**
-

**Negatief / geaccepteerde afwegingen:**
-

**Wat mij hierop zou doen terugkomen:**
-

## Laagindeling die hieruit volgt

Schets de resulterende structuur zodra de keuze vaststaat, bijvoorbeeld:

```
UI (widgets)
  ↓ watcht
Providers / notifiers        ← state, hier geen HTTP of SQL
  ↓ roept aan
Repositories                 ← bepaalt lokaal vs. remote, synchronisatieregels
  ↓ roept aan
API-client  |  drift-database
```
