# Visuele voortgang

Screenshots en schermopnames van de app door de tijd heen. Dit is het materiaal
dat het in een presentatie doet — een publiek dat je code niet gaat lezen,
begrijpt een rij screenshots van maart tot november meteen.

## Naamgeving

```
JJJJ-MM-DD-fase<n>-<korte-omschrijving>.png
JJJJ-MM-DD-fase<n>-<korte-omschrijving>.mp4
```

Voorbeeld: `2026-11-03-fase5-offline-sync-vliegtuigmodus.mp4`

## Wanneer vastleggen

- Aan het einde van elke fase (verplicht)
- Zodra de UI zichtbaar verandert
- Vóór een ingrijpende refactor of herontwerp — de "voor"-situatie is daarna weg
- Alles wat zich alleen in beweging bewijst: offline sync, loading states,
  redirects bij authenticatie, animaties

## Releases taggen

Koppel betekenisvolle momenten aan een annotated git-tag, zodat het beeld en de
staat van de code op elkaar aansluiten:

```
git tag -a v0.1-eerste-api-call -m "App leest taken uit eigen backend"
git push origin v0.1-eerste-api-call
```

Voorgestelde tags: `v0.1-eerste-api-call` · `v0.2-auth-werkend` ·
`v0.3-offline-bruikbaar` · `v0.4-tests-groen` · `v1.0-pda-afgerond`

## Overzicht

| Datum | Fase | Bestand | Wat het laat zien |
|---|---|---|---|
| | | | |

## Let op bestandsgrootte

Houd opnames kort (10–30 s) en gecomprimeerd. Gaan video's de repo opblazen,
haal ze er dan uit en link ernaar, in plaats van halverwege het project alsnog
naar git-lfs te grijpen.
