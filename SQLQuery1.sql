DROP TABLE Pezzi
DROP TABLE CasaAste

CREATE TABLE CasaAste(
IDCasa int identity primary key,
Nome varchar(50) not null,
AnnoFondazione int not null
)

CREATE TABLE Pezzi(
IDPezzo int identity primary key,
Nome varchar(50) not null,
Descrizione text,
Tipologia varchar(50) not null,
AnnoPezzo int,
IDCasa int foreign key references CasaAste(IDCasa)
)

INSERT INTO CasaAste(Nome,AnnoFondazione) VALUES('Tomioka',1999)
INSERT INTO CasaAste(Nome,AnnoFondazione) VALUES('Kamado',2005)
INSERT INTO CasaAste(Nome,AnnoFondazione) VALUES('Vi Britannia',1999)
INSERT INTO CasaAste(Nome,AnnoFondazione) VALUES('Kozuki',2000)
INSERT INTO CasaAste(Nome,AnnoFondazione) VALUES('Sumeragi',2003)

INSERT INTO Pezzi(Nome,Descrizione,Tipologia,AnnoPezzo,IDCasa) VALUES('Giyu','Best spadaccino che non è morto','Spada periodo Edo',1800,1)
INSERT INTO Pezzi(Nome,Descrizione,Tipologia,AnnoPezzo,IDCasa) VALUES('Tanjiro','Protagonista che finisce peggio di Giyu','Cassa Antica',1800,2)
INSERT INTO Pezzi(Nome,Descrizione,Tipologia,AnnoPezzo,IDCasa) VALUES('Nezuko','Sorella del protagonista','Kimono periodo Edo',1800,2)
INSERT INTO Pezzi(Nome,Descrizione,Tipologia,AnnoPezzo,IDCasa) VALUES('Lelouch','Best personaggio ever che meritava una fine migliore infatti hanno fatto un film per sistemare','Casco Antico',1900,3)
INSERT INTO Pezzi(Nome,Descrizione,Tipologia,AnnoPezzo,IDCasa) VALUES('Kozuki','Best persoaggio femminile dopo C.C.','Robottone grande',2030,4)