## ASSIGNMENT

Si tirano 5 dadi 

Lo scopo è avere più facce possibili con indicato lo stesso numero

> ad esempio se ho cinque su 2 dadi posso ritirare gli altri 3 dadi un'altra volta

Si può decidere di rilanciare i dadi per cui vogliamo tentare un numero diverso

<details>

<summary> Schema </summary>

```mermaid

flowchart TD
    A[Lancio 5 Dadi] --> B{Vuoi rilanciare dei dadi?}
    B -- si --> C[Quali?]
    C --> D[Rilancio dadi scelti]
    D --> E
    B -- No ----> E[Fine]

    F[Regole] --> G[1-Si lanciano 5 dadi]
    F --> H[2-Lo scopo è avere più numeri uguali sui dadi]
    F --> I[3-Si può decidere di lanciare dei dadi una seconda volta]

```



</details>