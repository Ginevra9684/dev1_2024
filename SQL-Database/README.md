# COMANDI

- PER CREARE UNA TABELLA

```sql
CREATE TABLE prodotti (
    id INTEGER,
    nome TEXT
);
```

- PER AGGIUNGERE A UNA TABELLA

```sql
ALTER TABLE prodotti ADD COLUMN prezzo_finale REAL;
```

- PER FARE UN INSERIMENTO 

```sql
INSERT INTO utenti VALUES (1, 'Mario');
```

- PER VISUALIZZARE 

```sql
SELECT * FROM table_name;
```

- PER VISUALIZZARE IN ORDINE ALFABETICO DISCENDENTE

```SQL
SELECT * FROM utenti ORDER BY nome DESC;
```

- CERCHIAMO UN PRODOTTO CON PREZZO MAGGIORE DI 10

```SQL
SELECT * FROM prodotti WHERE prezzo_finale > 10;
```

- CERCHIAMO RECORD CON CAMPI MANCANTI

```SQL
SELECT * FROM prodotti WHERE prezzo_finale IS NULL;
```

- AGGIORNARE UN VALORE A SECONDA DI UN CAMPO

```SQL
UPDATE prodotti SET prezzo_finale = 20 WHERE nome = 'banane';
```

- ELIMINARE UN RECORD CON WHERE 

```sql
DELETE FROM prodotti WHERE prezzo_finale <10;
```

- ELIMINARE UNA TABELLA 

```sql
DROP TABLE table_name;
```

- CREA TABELLA CON ID CATEGORIA COME CHIAVE PRIMARIA

```sql
CREATE TABLE categorie (
    id_categoria INTEGER PRIMARY KEY,
    nome TEXT NOT NULL,
    descrizione TEXT
);
```

- TABELLA CON JOIN

```sql
CREATE TABLE prodotti (
    id_prodotto INTEGER PRIMARY KEY,
    nome TEXT NOT NULL,
    prezzo REAL,
    id_categoria INTEGER,
    FOREIGN KEY (id_categoria) REFERENCES categorie (id_categoria)
);
```

- INSERIMENTO DI UN PRODOTTO ASSOCIATO AD UNA CATEGORIA 

```sql
INSERT INTO prodotti (nome, prezzo, id_categoria)
VALUES ('Laptop', 1000, 2);
```

- INSERIMENTO DI UNA CATEGORIA

```sql
INSERT INTO categorie (nome, descrizione)
VALUES ('Smart Home', 'Prodotti per la casa intelligente');
```

- JOIN

```sql
SELECT * FROM prodotti JOIN categorie ON prodotti.id_categoria = categorie.id_categoria;
```

- RAGRUPPARE I DATI IN BASE A UNA COLONNA 

```sql
SELECT * FROM table_name GROUP BY column_name;
```

- RINOMINARE LE COLONNE

```sql
SELECT prodotti.nome AS prodotto, prodotti.prezzo AS prezzo, categorie.nome AS categoria FROM prodotti JOIN categorie ON prodotti.id_categoria = categorie.id_categoria;
```

```sql
.headers on
.mode column
.mode html
```