# TaskFlow — Projectdocumentatie

Documentatie bij de Personal Development Activity (PDA): het bouwen van
**TaskFlow**, een taak-/gewoontetracker, als Flutter-app met een zelfgebouwde
ASP.NET Core-backend.

Git legt vast *wat* er is veranderd. Deze documenten leggen vast *waarom* het is
veranderd en *wat ik ervan heb geleerd* — en daar draait de PDA-beoordeling
uiteindelijk om.

## Structuur

| Pad | Wat erin staat | Hoe vaak |
|---|---|---|
| `leerdoelen.md` | Leerdoelen, wat "behaald" betekent per doel, zelfevaluatie | Eenmalig opgesteld, maandelijks herzien |
| `fasen.md` | De 7 projectfasen, scope en status | Bijwerken bij start/afronding van een fase |
| `logboek/` | Gedateerde werksessie-notities | Elke sessie, of een wekelijkse samenvatting |
| `adr/` | Architecture Decision Records — één per belangrijke beslissing | Zodra er een echte keuze wordt gemaakt |
| `voortgang/` | Screenshots en schermopnames van de app door de tijd heen | Einde van elke fase, of bij zichtbare wijzigingen |

## Werkafspraken

1. **Het logboek mág slordig zijn.** Opsommingen, typefouten, halve zinnen.
   Zodra notities aanvoelen als opstellen, worden ze niet meer geschreven.
2. **Schrijf de ADR vóór of tijdens het beslissen,** niet achteraf. De afgewezen
   opties opschrijven is precies het punt; achteraf reconstrueren levert fictie op.
3. **Verwijs terug naar de leerdoelen.** Logboeknotities en ADR's verwijzen naar
   doel-ID's (`D1`–`D5`), zodat het eindverslag zichzelf schrijft vanuit het spoor
   dat je hebt achtergelaten.
4. **Commit documentatie samen met de code die erbij hoort.** Bij voorkeur in
   dezelfde commit — dan sluiten de tijdstempels vanzelf aan op de git-historie.

## Eindresultaat

Aan het einde van het project wordt het eindverslag samengesteld uit:
de zelfevaluatie in `leerdoelen.md` + de ADR's (onderbouwing) + hoogtepunten uit
het logboek (worsteling en leerproces) + `voortgang/` (visueel bewijs).
Niets hoeft achteraf uit het geheugen gereconstrueerd te worden.
