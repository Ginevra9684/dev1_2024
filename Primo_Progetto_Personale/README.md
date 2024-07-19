## IDEA
- Creare un'app che dia consigli su cosa progettare sia in 2d che 3d ed eventualmente dica quali oggetti/soggetti prendere come reference

<details>
<summary>Definizioni utili per la progettazione</summary>

- Quali elementi possono essere creati:
1. Ambienti
2. Oggetti
3. Soggetti

- I soggetti possono essere:
1. Persone
2. Creature
3. Animali

- In quali contesti possono essere rappresentati:
1. Fantasy
2. Horror
3. Steampank
4. Adventure
5. Sci-fi

- I disegni 2D possono essere realizzati con le seguenti tecniche:

1. Matita
2. Carboncino
3. Acquarelli
4. Tempere
5. Colori ad olio
6. Gessetti


</details>

## Target

Chiunque voglia disegnare o creare un progetto 3D ma non ha una consegna precisa e non delle idee da cui partire

# Funzionalità

- L'app chiede all'utente se vuole creare un'ambientazione, un soggetto o entrambi.
- Per la sola AMBIENTAZIONE sceglierà, in maniera RANDOM e da un FILE ESTERNO, un luogo specifico.
- Per il SOGGETTO chiederà all'utente se ha delle PREFERENZE (umano, animale, creatura).
- Se l'utente non ha preferenze, il computer chiederà se l'utente desidera UN SOLO soggetto o UNA COPPIA di soggetti (umano, animale/creatura)
- L'app chiede se l'utente necessita di un TEMA di riferimento
- L'app chiede se il progetto sarà in 2D o 3D
- Per il 2D l'app chiede se l'tente necessita di una TECNICA di esecuzione
- L'app in coclusione suggerisce qualche sito dove poter pubblicare il proprio lavoro

# Passaggi

- [ ] Creare un file Json contenente le ambientazioni
- [ ] Creare un file Json contenente vari animali
- [ ] Creare un file Json contenente creature mitologiche
- [ ] Creare un file Json contenente vari temi
- [ ] Creare un file Json contenente le possibili tecniche
- [ ] Scrivere il menu principale di scelta
- [ ] Aggiungere il sottomenu dell'ambientazione
- [ ] - estrarre il luogo dal file Json
- [ ] Aggiungere il sottomenu del soggetto
- [ ] - sottomenu scelta autonoma
- [ ] - - estrazione soggetto da un file Json
- [ ] - scelta uno o due soggetti
- [ ] - - estrazione da file Json
- [ ] Scelta tema
- [ ] Input 2D 0 3D
- [ ] Tecnica di disegno 2D
- [ ] Chiusura del programma

```mermaid
stateDiagram-v2
    state if_state <<choice>>
    state if_state2 <<choice>>
    state if_state3 <<choice>>
    state if_state4 <<choice>>
    state if_state5 <<choice>>
    state if_state6 <<choice>>
    state if_state7 <<choice>>
    CREA_IDEE --> Scelta
    Scelta --> Ambientazione?
    Scelta --> Soggetto?
    Scelta --> Ambientazione_e_Soggetto?
    Ambientazione? --> Luogo_Specifico 
    Soggetto? --> Preferenza?\n(umano/animale/creatura)
    Preferenza?\n(umano/animale/creatura) --> if_state
    if_state --> Scelta_Manuale\nun_solo_soggetto : if risposta = si
    Scelta_Manuale\nun_solo_soggetto --> if_state6
    if_state6 --> Tema? : if scelta != creatura
    if_state6 --> Creatura_Mitologica_o\nPropria_Creazione? : if scelta = creatura
    Creatura_Mitologica_o\nPropria_Creazione? --> if_state7
    if_state7 --> Creatura_Mitologica\nRandom : if scelta = 1
    Creatura_Mitologica\nRandom --> Tema?
    if_state7 --> Quantità_Animali_per\nCreazione? : if scelta = 2
    Quantità_Animali_per\nCreazione? --> Lista_Animali_Random
    Lista_Animali_Random --> Tema?
    if_state --> Scelta_Soggetto_Unico_o\nDoppio_Soggetto : if risposta = no
    Scelta_Soggetto_Unico_o\nDoppio_Soggetto --> if_state2
    if_state2 --> Soggetto_Random : if risposta = 1
    if_state2 --> Soggetto_Umano_+\nSoggetto_Random : if risposta = 2
    Ambientazione_e_Soggetto? --> Luogo_Specifico
    Luogo_Specifico --> Preferenza?\n(umano/animale/creatura) : if ambientazione e soggetto
    Luogo_Specifico --> Tema? : if ambientazione
    Soggetto_Random --> Tema?
    Soggetto_Umano_+\nSoggetto_Random --> Tema? : if Random != creatura mitologica
    Tema? --> if_state3
    if_state3 --> Tema_Random : if risposta = si
    if_state3 --> 2D_o_3D : if risposta = no
    2D_o_3D --> if_state4
    if_state4 --> Tecnica? : if risposta = 2D
    if_state4 --> FINE : if risposta = 3D
    Tema_Random --> 2D_o_3D
    Tecnica? --> if_state5
    if_state5 --> Tecnica_Random : if risposta = si
    if_state5 --> FINE : if risposta = no
    Tecnica_Random --> FINE
```
<details>
<summary> Implementazioni </summary>

- [ ] Visione grafica con Spectre.Console
- [ ] Front End con Html e Css
- [ ] Stampa tabella finale con tutte le scelte
- [ ] Restart del ciclo a fine programma per più progetti
- [ ] Aggiunta opzioni come caratteristiche e personalità dei personaggi, materiali degli oggetti

</details>