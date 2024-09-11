CREATE TABLE Albums
(
    Id serial PRIMARY KEY,
    Titre character varying,
    BandId integer,
    CONSTRAINT FK_Albums_Bands FOREIGN KEY (BandId) REFERENCES "Bands"("Id")
);