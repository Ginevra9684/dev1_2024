## ASSIGNMENT

Creare una console app per simulare un gioco di dadi

- Sia il giocatore sia il computer lanciano due dadi a ogni turno

- Chi ottiene la somma più alta vince

- Ogni giocatore ha 100 punti in partenza

- Al perdente vengono sottratti punti per una quantità pari alla differenza tra il lancio di dadi del vincitore e del perdente

> Ad esempio se il computer lancia 6 ed il giocatore umano lancia 12 al computer vengono sottratti 6 punti dal punteggio di 100 aggiornando il punteggio a 94

- Il primo che termina i punti fa finire il gioco

> ##TO DO## Implementare la persistenza dei dati

<details>
<summary>Schema</summary>

```mermaid

stateDiagram-v2
    [Gioco_di_Dadi] --> Computer
    [Gioco_di_Dadi] --> Player
    Computer --> Lancio_dei_Dadi
    Player --> Lancio_dei_Dadi
    Lancio_dei_Dadi --> Player_Perde_Punti : Dadi Computer > Dadi Player
    Lancio_dei_Dadi --> Computer_Perde_Punti : Dadi Player > Dadi Computer
    Player_Perde_Punti --> Lancio_dei_Dadi
    Computer_Perde_Punti --> Lancio_dei_Dadi
    Player_Perde_Punti --> Player_Perde_Gioco : Punti = 0
    Computer_Perde_Punti --> Computer_Perde_Gioco : Punti = 0 
```
</details>