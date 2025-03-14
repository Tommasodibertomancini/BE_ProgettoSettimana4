USE GestioneSanzioni

INSERT INTO ANAGRAFICA (idanagrafica, Cognome, Nome, Indirizzo, Città, CAP, Cod_Fisc)
VALUES
(NEWID(), 'Rossi', 'Mario', 'Via Roma 10', 'Palermo', '90100', 'RSSMRA80A01H501U'),
(NEWID(), 'Bianchi', 'Laura', 'Via Milano 5', 'Palermo', '90100', 'BNCLRA85B51H501Q'),
(NEWID(), 'Verdi', 'Giovanni', 'Via Libertà 20', 'Palermo', '90100', 'VRDGVN70C01L726Z'),
(NEWID(), 'Neri', 'Sara', 'Via Napoli 30', 'Roma', '00100', 'NRISRA95D02L219H'),
(NEWID(), 'Gialli', 'Luca', 'Corso Italia 12', 'Napoli', '80100', 'GLLLCA92E03M345Y'),
(NEWID(), 'Azzurri', 'Anna', 'Via Venezia 8', 'Palermo', '90100', 'AZZANN78F04S842W'),
(NEWID(), 'Aranci', 'Paolo', 'Via Bologna 22', 'Palermo', '90100', 'ARNPLA82G05T631X'),
(NEWID(), 'Viola', 'Giulia', 'Via Bari 17', 'Bari', '70100', 'VLAGIA90H06B112Y'),
(NEWID(), 'Rosa', 'Francesca', 'Via Genova 9', 'Genova', '16100', 'RSFFRN89I07H832T'),
(NEWID(), 'Marrone', 'Davide', 'Via Verona 15', 'Palermo', '90100', 'MRRDVD85L08H671Q');

-- Popolamento Tabella TIPO_VIOLAZIONE

INSERT INTO TIPO_VIOLAZIONE (idviolazione, descrizione)
VALUES
(NEWID(), 'Eccesso di velocità'),
(NEWID(), 'Divieto di sosta'),
(NEWID(), 'Passaggio col rosso'),
(NEWID(), 'Guida senza cintura'),
(NEWID(), 'Sosta su posto per disabili'),
(NEWID(), 'Utilizzo del cellulare alla guida'),
(NEWID(), 'Mancato rispetto della precedenza'),
(NEWID(), 'Sosta in doppia fila'),
(NEWID(), 'Guida contromano'),
(NEWID(), 'Mancata revisione del veicolo');

SELECT * FROM ANAGRAFICA

-- Popolamento Tabella VERBALE

INSERT INTO VERBALE (idverbale, idanagrafica, idviolazione, DataViolazione, IndirizzoViolazione, Nominativo_Agente, DataTrascrizioneVerbale, Importo, DecurtamentoPunti)
VALUES
(NEWID(), (SELECT idanagrafica FROM ANAGRAFICA WHERE Cognome = 'Rossi' AND Nome = 'Mario'), (SELECT idviolazione FROM TIPO_VIOLAZIONE WHERE Descrizione = 'Eccesso di velocità'), CONVERT(datetime, '2023-01-01', 102), 'Via Torino 3', 'Giovanni Verdi', CONVERT(datetime, '2023-01-02', 102), 150.00, 3),
(NEWID(), (SELECT idanagrafica FROM ANAGRAFICA WHERE Cognome = 'Bianchi' AND Nome = 'Laura'), (SELECT idviolazione FROM TIPO_VIOLAZIONE WHERE Descrizione = 'Divieto di sosta'), CONVERT(datetime, '2023-01-03', 102), 'Via Milano 5', 'Paolo Neri', CONVERT(datetime, '2023-01-04', 102), 100.00, 1),
(NEWID(), (SELECT idanagrafica FROM ANAGRAFICA WHERE Cognome = 'Verdi' AND Nome = 'Giovanni'), (SELECT idviolazione FROM TIPO_VIOLAZIONE WHERE Descrizione = 'Passaggio col rosso'), CONVERT(datetime, '2023-01-05', 102), 'Via Libertà 20', 'Luigi Rossi', CONVERT(datetime, '2023-01-06', 102), 200.00, 4),
(NEWID(), (SELECT idanagrafica FROM ANAGRAFICA WHERE Cognome = 'Neri' AND Nome = 'Sara'), (SELECT idviolazione FROM TIPO_VIOLAZIONE WHERE Descrizione = 'Guida senza cintura'), CONVERT(datetime, '2023-01-07', 102), 'Via Napoli 30', 'Michele Bianchi', CONVERT(datetime, '2023-01-08', 102), 120.00, 2),
(NEWID(), (SELECT idanagrafica FROM ANAGRAFICA WHERE Cognome = 'Gialli' AND Nome = 'Luca'), (SELECT idviolazione FROM TIPO_VIOLAZIONE WHERE Descrizione = 'Sosta su posto per disabili'), CONVERT(datetime, '2023-01-09', 102), 'Corso Italia 12', 'Alessandro Verdi', CONVERT(datetime, '2023-01-10', 102), 180.00, 3),
(NEWID(), (SELECT idanagrafica FROM ANAGRAFICA WHERE Cognome = 'Azzurri' AND Nome = 'Anna'), (SELECT idviolazione FROM TIPO_VIOLAZIONE WHERE Descrizione = 'Utilizzo del cellulare alla guida'), CONVERT(datetime, '2023-01-11', 102), 'Via Venezia 8', 'Lorenzo Neri', CONVERT(datetime, '2023-01-12', 102), 160.00, 3),
(NEWID(), (SELECT idanagrafica FROM ANAGRAFICA WHERE Cognome = 'Aranci' AND Nome = 'Paolo'), (SELECT idviolazione FROM TIPO_VIOLAZIONE WHERE Descrizione = 'Mancato rispetto della precedenza'), CONVERT(datetime, '2023-01-13', 102), 'Via Bologna 22', 'Francesco Gialli', CONVERT(datetime, '2023-01-14', 102), 130.00, 2),
(NEWID(), (SELECT idanagrafica FROM ANAGRAFICA WHERE Cognome = 'Viola' AND Nome = 'Giulia'), (SELECT idviolazione FROM TIPO_VIOLAZIONE WHERE Descrizione = 'Sosta in doppia fila'), CONVERT(datetime, '2023-01-15', 102), 'Via Bari 17', 'Claudio Azzurri', CONVERT(datetime, '2023-01-16', 102), 140.00, 2),
(NEWID(), (SELECT idanagrafica FROM ANAGRAFICA WHERE Cognome = 'Rosa' AND Nome = 'Francesca'), (SELECT idviolazione FROM TIPO_VIOLAZIONE WHERE Descrizione = 'Guida contromano'), CONVERT(datetime, '2023-01-17', 102), 'Via Genova 9', 'Stefano Aranci', CONVERT(datetime, '2023-01-18', 102), 200.00, 4),
(NEWID(), (SELECT idanagrafica FROM ANAGRAFICA WHERE Cognome = 'Marrone' AND Nome = 'Davide'), (SELECT idviolazione FROM TIPO_VIOLAZIONE WHERE Descrizione = 'Mancata revisione del veicolo'), CONVERT(datetime, '2023-01-19', 102), 'Via Verona 15', 'Roberto Viola', CONVERT(datetime, '2023-01-20', 102), 110.00, 1),
(NEWID(), (SELECT idanagrafica FROM ANAGRAFICA WHERE Cognome = 'Rossi' AND Nome = 'Mario'), (SELECT idviolazione FROM TIPO_VIOLAZIONE WHERE Descrizione = 'Eccesso di velocità'), CONVERT(datetime, '2023-02-01', 102), 'Via Torino 3', 'Giovanni Verdi', CONVERT(datetime, '2023-02-02', 102), 150.00, 3),
(NEWID(), (SELECT idanagrafica FROM ANAGRAFICA WHERE Cognome = 'Bianchi' AND Nome = 'Laura'), (SELECT idviolazione FROM TIPO_VIOLAZIONE WHERE Descrizione = 'Divieto di sosta'), CONVERT(datetime, '2023-02-03', 102), 'Via Milano 5', 'Paolo Neri', CONVERT(datetime, '2023-02-04', 102), 100.00, 1),
(NEWID(), (SELECT idanagrafica FROM ANAGRAFICA WHERE Cognome = 'Verdi' AND Nome = 'Giovanni'), (SELECT idviolazione FROM TIPO_VIOLAZIONE WHERE Descrizione = 'Passaggio col rosso'), CONVERT(datetime, '2023-02-05', 102), 'Via Libertà 20', 'Luigi Rossi', CONVERT(datetime, '2023-02-06', 102), 200.00, 4),
(NEWID(), (SELECT idanagrafica FROM ANAGRAFICA WHERE Cognome = 'Neri' AND Nome = 'Sara'), (SELECT idviolazione FROM TIPO_VIOLAZIONE WHERE Descrizione = 'Guida senza cintura'), CONVERT(datetime, '2023-02-07', 102), 'Via Napoli 30', 'Michele Bianchi', CONVERT(datetime, '2023-02-08', 102), 120.00, 2),
(NEWID(), (SELECT idanagrafica FROM ANAGRAFICA WHERE Cognome = 'Gialli' AND Nome = 'Luca'), (SELECT idviolazione FROM TIPO_VIOLAZIONE WHERE Descrizione = 'Sosta su posto per disabili'), CONVERT(datetime, '2023-02-09', 102), 'Corso Italia 12', 'Alessandro Verdi', CONVERT(datetime, '2023-02-10', 102), 180.00, 3),
(NEWID(), (SELECT idanagrafica FROM ANAGRAFICA WHERE Cognome = 'Azzurri' AND Nome = 'Anna'), (SELECT idviolazione FROM TIPO_VIOLAZIONE WHERE Descrizione = 'Utilizzo del cellulare alla guida'), CONVERT(datetime, '2023-02-11', 102), 'Via Venezia 8', 'Lorenzo Neri', CONVERT(datetime, '2023-02-12', 102), 160.00, 3),
(NEWID(), (SELECT idanagrafica FROM ANAGRAFICA WHERE Cognome = 'Aranci' AND Nome = 'Paolo'), (SELECT idviolazione FROM TIPO_VIOLAZIONE WHERE Descrizione = 'Mancato rispetto della precedenza'), CONVERT(datetime, '2023-02-13', 102), 'Via Bologna 22', 'Francesco Gialli', CONVERT(datetime, '2023-02-14', 102), 130.00, 2),
(NEWID(), (SELECT idanagrafica FROM ANAGRAFICA WHERE Cognome = 'Viola' AND Nome = 'Giulia'), (SELECT idviolazione FROM TIPO_VIOLAZIONE WHERE Descrizione = 'Sosta in doppia fila'), CONVERT(datetime, '2023-02-15', 102), 'Via Bari 17', 'Claudio Azzurri', CONVERT(datetime, '2023-02-16', 102), 140.00, 2);

SELECT * FROM VERBALE