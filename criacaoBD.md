-- Tipos de utilizador
create table tiposUtilizador
(
    "idTipoUtilizador" serial
        constraint tiposUtilizador_pk
        primary key,
    email varchar(100) not null,
    password varchar(100) not null,
    name varchar(100)
    
);
alter table tiposUtilizador owner to es2;

create unique index tiposutilizador_idtipoutilizador_uindex
    on tiposUtilizador ("idTipoUtilizador");

-- Utilizadores
create table utilizadores
(
    "idUtilizador" serial
        constraint utilizadores_pk
        primary key,
    primeiroNome varchar(100) not null,
    ultimoNome varchar(100) not null,
    email varchar(100) not null,
    password varchar(100) not null,
    nome varchar(100),
    dataNascimento date,
    "id_tipoUtilizador" integer
        constraint tipos_utilizadores_idtipoutilizador_fk
        references tiposUtilizador
        on delete cascade
);
alter table utilizadores owner to es2;

create unique index utilizadores_idutilizador_uindex
    on utilizadores ("idUtilizador");

-- Ativos
create table ativos
(
    "idAtivo" serial
        constraint ativos_pk
        primary key,
    duracaoMeses int not null,
    impost int not null,
    nome varchar(100),
    dataInicio DATE NOT NULL DEFAULT CURRENT_DATE,
    "id_utilizador" integer
        constraint ativos_utilizadores_idutilizador_fk
        references utilizadores
        on delete cascade
);
alter table ativos owner to es2;

create unique index ativos_idativos_uindex
    on ativos ("idAtivo");


-- Movimentos
create table movimentos
(
    "idMovimento" serial
        constraint movimentos_pk
        primary key,
    valor float not null,
    taxa int not null,
    data DATE NOT NULL DEFAULT CURRENT_DATE,
    "id_ativo" integer
        constraint movimentos_ativos_idativo_fk
        references ativos
        on delete cascade
);
alter table movimentos owner to es2;

create unique index movimentos_idmovimentos_uindex
    on movimentos ("idMovimento");



-- Imoveis
create table imoveis
(
    "idImovel" serial
        constraint imoveis_pk
        primary key,
    designacao varchar(100) not null,
    localizacao varchar(100) not null,
    valorDoImovel float not null,
    valorDeRenda float not null,
    valorMensalCondominio float not null,
    valorAnualDespesas float not null
);
alter table imoveis owner to es2;

create unique index imoveis_idimovel_uindex
    on imoveis ("idImovel");


-- Contas bancárias
create table contas
(
    "idConta" serial
        constraint conta_pk
        primary key,
    banco varchar(100) not null,
    nome varchar(100) not null,
    numConta varchar(100) not null
);
alter table contas owner to es2;

create unique index contas_idconta_uindex
    on contas ("idConta");


-- Depositos A Praso
create table depositosAPraso
(
    "idDeposito" serial
        constraint deposito_pk
        primary key,
    valor float not null,
    montanteAplicado varchar(100) not null,
    taxaJuroAnual int not null,
    "id_conta" integer
        constraint depositos_conta_idconta_fk
            references contas
            on delete cascade
);
alter table depositosAPraso owner to es2;

create unique index depositos_iddeposito_uindex
    on depositosAPraso ("idDeposito");


-- Titulares de contas bancarias
create table titulares
(
    "idTitular" serial
        constraint titular_pk
            primary key,
    primeiroNome varchar(100) not null,
    ultimoNome varchar(100) not null,
    email varchar(100) not null,
    "id_conta" integer
        constraint titulares_conta_idconta_fk
            references contas
            on delete cascade
);
alter table titulares owner to es2;

create unique index titulares_idtitular_uindex
    on titulares ("idTitular");


-- Fundo de investimento
create table fundoInvestimento
(
    "idFundo" serial
        constraint fundo_pk
            primary key,
    nome varchar(100) not null,
    montanteInvestido float not null,
    taxaJuro int not null
);
alter table fundoInvestimento owner to es2;

create unique index fundoinvestimento_idFundo_uindex
    on fundoInvestimento ("idFundo");


-- Taxa aplicada ao fundo de investimento mensalmente
create table taxaAplicada
(
    "idTaxa" serial
        constraint taxa_pk
            primary key,
    mes int not null,
    taxa int not null,
    "id_Fundo" integer
        constraint taxa_fundo_idfundo_fk
            references fundoInvestimento
            on delete cascade
);
alter table taxaAplicada owner to es2;

create unique index taxaaplicada_idtaxa_uindex
    on taxaAplicada ("idTaxa");
