# Dev-logboek

Eén bestand per sessie (of per week), met de naam `JJJJ-MM-DD.md`. Kopieer
`TEMPLATE.md`.

## Afspraken

- **Vijf minuten, aan het eind van de sessie, zolang het vers is.** Niet de
  volgende ochtend.
- **Opsommingen, geen proza.** Niemand beoordeelt het schrijfwerk.
- Vermeld doel-ID's (`D1`–`D5`), zodat notities terug te voeren zijn op
  `../leerdoelen.md`.
- Is er uit een sessie een beslissing voortgekomen? Dan komt die in een ADR in
  `../adr/`, en verwijst de logboeknotitie daar alleen naar.
- Is er een week voorbijgegaan zonder notities? Schrijf dan één wekelijkse
  samenvatting in plaats van vijf verzonnen dagnotities achteraf.

## Voorbeeldnotitie

Bewust rommelig — dit is het niveau van afwerking om op te mikken.

```markdown
# 2026-09-20

**Fase:** 1 — Flutter-omgeving + basisvaardigheden
**Doelen geraakt:** D1
**Tijdsbesteding:** ±3u

## Waar ik aan heb gewerkt
- SDK + Android-emulator draaiend
- Counter-app opnieuw opgebouwd vanaf nul, zonder spieken
- Ingelezen in het constraints-model

## Wat ik heb geleerd
- Constraints gaan omlaag, sizes gaan omhoog, de parent bepaalt de positie.
  Verklaart het grootste deel van mijn layoutverwarring tot nu toe.
- Hot reload behoudt state, hot restart niet. Zat een "bug" te debuggen die
  gewoon oude state was.

## Wat me in de war bracht / tijd heeft gekost
- ±45 min kwijt aan een unbounded-height error in een Column > ListView.
  Expanded loste het op, maar ik snap maar half waarom — later op terugkomen.
- Nog steeds onduidelijk wanneer een Key echt nodig is.

## Volgende stap
- Layoutoefeningen, daarna de schermen van TaskFlow schetsen
```
