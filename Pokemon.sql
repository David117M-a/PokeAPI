CREATE DATABASE Pokemon;
Use Pokemon;

CREATE TABLE Pokedex(
ID_Pokedex int not null primary key,
nombrePokemon varchar(50) not null,
alturaMetros float not null,
categoria varchar(50) not null,
pesoKg float not null,
habilidad varchar(50) not null,
sexo varchar(2) not null,
tipo varchar(50) not null,
debilidad varchar(100) not null
);

CREATE TABLE Entrenadores(
ID_Entrenadores int not null identity(1, 1) primary key,
username varchar(50) not null,
fullname varchar(100) not null,
email varchar(100) not null,
userPass varchar(100) not null
);

INSERT INTO Pokedex VALUES (001, 'Bulbasaur', 0.7, 'Semilla', 6.9, 'Espesura', 'HM', 'Planta, Veneno', 'Fuego, Psíquico, Volador, Hielo');
INSERT INTO Pokedex VALUES (004, 'Charmander', 0.5, 'Lagartija', 8.5, 'Mar Llamas', 'HM', 'Fuego', 'Agua, Tierra, Roca');
INSERT INTO Pokedex VALUES (007, 'Squirtle', 0.5, 'Tortuguita', 9.0, 'Torrente', 'HM', 'Agua', 'Planta, Eléctrico');
INSERT INTO Pokedex VALUES (010, 'Caterpie', 0.3, 'Gusano', 2.9, 'Polvo Escudo', 'HM', 'Bicho', 'Fuego, Volador, Roca');
INSERT INTO Pokedex VALUES (013, 'Weedle', 0.3, 'Oruga', 3.2, 'Polvo Escudo', 'HM', 'Bicho, Veneno', 'Fuego, Psíquico, Volador, Roca');
INSERT INTO Pokedex VALUES (016, 'Pidgey', 0.3, 'Pajarito', 1.8, 'Vista Lince, Tumbos', 'HM', 'Normal, Volador', 'Eléctrico, Hielo, Roca');
INSERT INTO Pokedex VALUES (019, 'Rattata', 0.3, 'Ratón', 3.5, 'Fuga, Agallas', 'HM', 'Normal', 'Lucha');
INSERT INTO Pokedex VALUES (021, 'Spearow', 0.3, 'Pajarito', 2.0, 'Vista Lince', 'HM', 'Normal, Volador', 'Eléctrico, Hielo, Roca');
INSERT INTO Pokedex VALUES (023, 'Ekans', 2.0, 'Serpiente', 6.9, 'Mudar, Intimidación', 'HM', 'Veneno', 'Psíquico, Tierra');
INSERT INTO Pokedex VALUES (025, 'Pikachu', 0.4, 'Ratón', 6.0, 'Electricidad, Estática', 'HM', 'Eléctrico', 'Tierra');
INSERT INTO Pokedex VALUES (027, 'Sandshrew', 0.6, 'Ratón', 12.0, 'Velo Arena', 'HM', 'Tierra', 'Agua, Planta, Hielo');
INSERT INTO Pokedex VALUES (029, 'Nidoran', 0.4, 'Pin Veneno', 7.0, 'Punto Tóxico, Rivalidad', 'HM', 'Veneno', 'Psíquico, Tierra');

INSERT INTO Entrenadores (username, fullname, email, userPass) VALUES ('David115Master', 'Ángel David Alanís Carreón', 'ing.angeldavid@outlook.com', '12345');

CREATE TABLE Equipos(
ID_Equipos int not null identity(1, 1) primary key,
nombreEquipo varchar(100) not null,
entrenador int not null,
primerPokemon int not null,
segundoPokemon int not null,
tercerPokemon int not null,
cuartoPokemon int not null,
quintoPokemon int not null,
sextoPokemon int not null,
CONSTRAINT Fk_Entrenador FOREIGN KEY (entrenador) REFERENCES Entrenadores (ID_Entrenadores) ON DELETE CASCADE,
CONSTRAINT Fk_PrimerPokemon FOREIGN KEY (primerPokemon) REFERENCES Pokedex (ID_Pokedex),
CONSTRAINT Fk_SegundoPokemon FOREIGN KEY (segundoPokemon) REFERENCES Pokedex (ID_Pokedex),
CONSTRAINT Fk_TercerPokemon FOREIGN KEY (tercerPokemon) REFERENCES Pokedex (ID_Pokedex),
CONSTRAINT Fk_CuartoPokemon FOREIGN KEY (cuartoPokemon) REFERENCES Pokedex (ID_Pokedex),
CONSTRAINT Fk_QuintoPokemon FOREIGN KEY (quintoPokemon) REFERENCES Pokedex (ID_Pokedex),
CONSTRAINT Fk_SextoPokemon FOREIGN KEY (sextoPokemon) REFERENCES Pokedex (ID_Pokedex)
);

INSERT INTO Equipos (nombreEquipo, entrenador, primerPokemon, segundoPokemon, tercerPokemon, cuartoPokemon, quintoPokemon, sextoPokemon) 
VALUES ('Equipo Ruby', 1, 001, 004, 007, 010, 013, 016);

SELECT * FROM Equipos