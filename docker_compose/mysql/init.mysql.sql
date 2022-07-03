create database IF NOT EXISTS vxtel;

use vxtel;

create table IF NOT EXISTS Tarifa (
    Id int not null AUTO_INCREMENT PRIMARY KEY,
    DddOrigem char(3) not null,
    DddDestino char(3) not null,
    Valor double not null
);

INSERT INTO Tarifa (DddOrigem, DddDestino, Valor) VALUES ( '011', '016', 1.9);
INSERT INTO Tarifa (DddOrigem, DddDestino, Valor) VALUES ( '016', '011', 2.9);
INSERT INTO Tarifa (DddOrigem, DddDestino, Valor) VALUES ( '011', '017', 1.7);
INSERT INTO Tarifa (DddOrigem, DddDestino, Valor) VALUES ( '017', '011', 2.7);
INSERT INTO Tarifa (DddOrigem, DddDestino, Valor) VALUES ( '011', '018', 0.9);
INSERT INTO Tarifa (DddOrigem, DddDestino, Valor) VALUES ( '018', '011', 1.9);

create table IF NOT EXISTS Produto (
    Id int not null AUTO_INCREMENT PRIMARY KEY,
    Nome varchar(50) not null,
    TempoContratado time not null,
    PercentualAcrescimo double not null,
    Valor double not null
);

INSERT INTO Produto (Nome, TempoContratado, PercentualAcrescimo, Valor) VALUES ('FaleMais 30', '00:30:00', 10, 20);
INSERT INTO Produto (Nome, TempoContratado, PercentualAcrescimo, Valor) VALUES ('FaleMais 60', '01:00:00', 10, 40);
INSERT INTO Produto (Nome, TempoContratado, PercentualAcrescimo, Valor) VALUES ('FaleMais 120', '02:00:00', 10, 80);