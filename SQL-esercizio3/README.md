# INSERIMENTO DI DATABASE NEL PROGETTO CREA IDEE

##  Descrizione del progetto fino ad ora

- Visualizzazione di elementi, contenuti in file JSON, in maniera random ma tramite scelte di selezione di gruppi di elementi (es: luogo, soggetto)
- Menu gestionale a fine delle scelte
- Possibilità di salvare o scartare i progetti ottenuti
- Possibilità di visualizzare ed eliminare tutti i progetti creati precedentemente
- I progetti possono essere salvati in inglese ed in italiano per il momento

## Possibili inserimenti del database

- Database per il salvataggio dei progetti
- Database illustrativo di tutti gli elementi presenti all'interno dell'app
- Database per creare un gioco a punti in base agli elementi random ottenuti (es punteggio se un animale e un luogo hanno una corrispondenza)

## Funzionamento database gioco

- Esiste una tabella con i dati degli animali e delle creature mitologiche
- Esiste una tabella dei luoghi con il loro meteo tipico

- Un `animale` o una `creatura mitologica` viene estratto/a come `soggetto`
- Viene creato un database contenente `id` e `nome` del soggetto
- Viene estratto un `luogo` 
- Il luogo viene aggiunto alla tabella
- Viene aggiunta la colonna `puntiLuogo`
- Se il `luogo estratto` è uguale al `luogo tipico` dell'animale i puntiLuogo verranno aumentati di un tot altrimenti saranno uguali a 0
- Viene estratta una condizione meteo
- Il meteo viene aggiunto alla tabella 
- Viene aggiunta la colonna `puntiMeteo`
- Se il meteo estratto è uguale al `meteo favorevole` dell'animale i puntiMeteo verranno aumentati di un tot altrimenti saranno uguali a 0
- Viene aggiunta la colonna `puntiAmbiente` 
- Se il meteo estratto è uguale al `meteo tipico` del luogo estratto i puntiAmbiente verranno aumentati di un tot altrimenti saranno uguali a 0
- Viene aggiunta la colonna `puntiTotali`

# Tabelle di sola lettura da creare tramite terminale

## Animale
- id: 
- nome:
- puntiRarita:
- luogo_tipico:
- punti_luogo_tipico:
- meteo_favorevole:
- punti_meteo_favorevole:

## CreaturaMitologica
- id:
- nome:
- luogo_tipico:
- punti_luogo_tipico:
- meteo_favorevole:
- punti_meteo_favorevole:

## Luogo
- id:
- nome:
- puntiLuogo:
- meteo_tipico:
- punti_meteo_tipico:

## Meteo
- id:
- nome:
- puntiMeteo:

# Tabella di inserimento (tramite le opzioni random ottenute e non tramite input utente) da modificare tramite codice C#

## CartaSoggetto
- id:
- nome:
- puntiRarita:
- puntiLuogo (fanno riferimento a luogo_tipico della tabella Animale/Creatura se la condizione è soddisfatta):
- puntiMeteo (fanno riferimento a meteo_favorevole della tabella Animale/Creatura se la condizione è soddisfatta):
- puntiAmbiente (fanno riferimento a meteo_tipico della tabella luogo di se la condizione è soddisfatta):
- puntiTotali (somma dei 3 punteggi precedenti + puntiRarita animale/creatura):