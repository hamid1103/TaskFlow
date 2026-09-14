# 0001 — Architectuurbeslissingen vastleggen

**Status:** Geaccepteerd
**Datum:** 2026-09-14
**Fase:** 1
**Doelen:** alle

## Context

Dit project loopt als Personal Development Activity (POA), dus wat beoordeeld wordt is
wat ik heb geleerd, niet alleen wat ik heb opgeleverd. Git laat zien wát er is
veranderd; het laat niet zien welke alternatieven ik heb afgewogen of waarom ik
ze heb verworpen. Over een project van deze lengte vergeet ik de redenering
achter vroege keuzes — en juist die vroege keuzes (state management,
offlinestrategie, authenticatie) zijn de keuzes waar ik straks verantwoording
over moet afleggen.

## Overwogen opties

### Optie A — Geen beslissingslogboek
Voordelen: geen overhead.
Nadelen: de redenering gaat verloren; het eindverslag moet uit het geheugen
worden gereconstrueerd, wat een opgepoetst verhaal oplevert in plaats van een
accuraat verhaal.

### Optie B — Redenering in commit messages
Voordelen: geen extra bestanden; automatisch van een tijdstempel voorzien.
Nadelen: maanden later niet terug te vinden; een commit message beschrijft een
wijziging, geen keuze tussen opties; een beslissing beslaat meestal veel commits.

### Optie C — ADR's als genummerde markdown-bestanden in de repo
Voordelen: staat onder versiebeheer naast de code; vindbaar; dwingt af dat de
afgewezen opties worden opgeschreven zolang ze nog vers zijn; direct bruikbaar
als bewijsmateriaal bij de PDA-beoordeling.
Nadelen: kleine doorlopende discipline; risico dat er over trivialiteiten wordt
gedocumenteerd.

## Beslissing

Gekozen voor optie C. ADR's staan in `docs/adr/` als genummerde
markdown-bestanden, volgens het lichte format van Michael Nygard. De drempel om
er één te schrijven staat beschreven in `README.md`, zodat het format niet
verwatert tot het loggen van elke packagekeuze.

## Gevolgen

**Positief:**
- De redenering wordt vastgelegd op het moment van beslissen in plaats van
  achteraf gereconstrueerd.
- Het eindverslag kan worden samengesteld uit materiaal dat er al ligt.
- Afgewezen opties blijven bewaard, en daar zit het grootste deel van het
  leerproces.

**Negatief / geaccepteerde afwegingen:**
- Een paar minuten schrijfwerk per belangrijke beslissing.
- Vraagt discipline om géén ADR's te schrijven over triviale keuzes.

**Wat mij hierop zou doen terugkomen:**
- Zodra ADR's achteraf worden geschreven om grondig over te komen, dienen ze hun
  doel niet meer en moet het format kleiner.
