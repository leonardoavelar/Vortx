create database IF NOT EXISTS vxtel;

use vxtel;

create table IF NOT EXISTS Tarifa (
    Id int not null AUTO_INCREMENT PRIMARY KEY,
    DddOrigem char(3) not null,
    DddDestino char(3) not null,
    Valor double not null
);

create table IF NOT EXISTS Cliente (
    Id int not null AUTO_INCREMENT PRIMARY KEY,
    Nome varchar(100) not null,
    Documento varchar(14) not null
);

create table IF NOT EXISTS TelefoneCliente(
    Id int not null AUTO_INCREMENT PRIMARY KEY,
    IdCliente int not null,
    Ddd char(3) not null,
    Telefone bigint not null,
    FOREIGN KEY (IdCliente)
        REFERENCES Cliente(Id)
        ON DELETE CASCADE
);

create table IF NOT EXISTS Produto (
    Id int not null AUTO_INCREMENT PRIMARY KEY,
    Nome varchar(50) not null,
    TempoContratado time not null,
    PercentualAcrescimo double not null,
    Valor double not null
);

create table IF NOT EXISTS Contrato (
    Id int not null AUTO_INCREMENT PRIMARY KEY,
    IdCliente int not null,
    IdProduto int not null,
    DataContratacao datetime not null,
    FOREIGN KEY (IdCliente)
        REFERENCES Cliente(Id)
        ON DELETE CASCADE,
    FOREIGN KEY (IdProduto)
        REFERENCES Produto(Id)
        ON DELETE CASCADE
);

create table IF NOT EXISTS Chamada (
    Id int not null AUTO_INCREMENT PRIMARY KEY,
    IdCliente int not null,
    DddOrigem char(3) not null,
    TelefoneOrigem bigint not null,
    DddDestino char(3) not null,
    TelefoneDestino bigint not null,
    DataChamada datetime not null,
    Situacao smallint not null,
    DataHoraInicio datetime null,
    DataHoraFim datetime null,
    TempoDuracao time null,
    Valor double null,
    FOREIGN KEY (IdCliente)
        REFERENCES Cliente(Id)
        ON DELETE CASCADE
);

create table IF NOT EXISTS Consumo (
    Id int not null AUTO_INCREMENT PRIMARY KEY,
    IdCliente int not null,
    TempoTotal time not null,
    Valor double not null,
    FOREIGN KEY (IdCliente)
        REFERENCES Cliente(Id)
        ON DELETE CASCADE
);