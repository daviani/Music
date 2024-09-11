CREATE TABLE Bands (
                         Id serial PRIMARY KEY,
                         Names varchar(255) NOT NULL,
                         Status varchar(20),
                         FormedIn integer,
                         Genre varchar(255),
                         CountryOfOrigin varchar(255),
                         AlbumIds integer[]
);
