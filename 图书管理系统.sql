/*==============================================================*/
/* Database name:  TSGLXT                                       */
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     2012/6/4 13:37:25                            */
/*==============================================================*/


drop database TSGLXT
go

/*==============================================================*/
/* Database: TSGLXT                                             */
/*==============================================================*/
create database TSGLXT
go

use TSGLXT
go

/*==============================================================*/
/* Table: CBS                                                   */
/*==============================================================*/
create table CBS (
   ID_CBS               int                  identity,
   CBSMC                varchar(100)         not null,
   LXR                  varchar(20)          null,
   LXDH                 varchar(15)          null,
   LXDZ                 varchar(100)         null,
   constraint PK_CBS primary key (ID_CBS)
)
go

/*==============================================================*/
/* Table: TSFL                                                  */
/*==============================================================*/
create table TSFL (
   TSFLBM               varchar(30)          not null,
   TSFLMC               varchar(100)         not null,
   constraint PK_TSFL primary key (TSFLBM)
)
go

/*==============================================================*/
/* Table: TuShu                                                 */
/*==============================================================*/
create table TuShu (
   ISBN                 char(10)             not null,
   TSFLBM               varchar(30)          not null,
   ID_CBS               int                  not null,
   TSMC                 varchar(200)         not null,
   TSZZ                 varchar(100)         not null,
   TSJG                 decimal              not null,
   CBRQ                 datetime             not null,
   constraint PK_TUSHU primary key (ISBN)
)
go

alter table TuShu
   add constraint FK_TUSHU_REFERENCE_TSFL foreign key (TSFLBM)
      references TSFL (TSFLBM)
go

alter table TuShu
   add constraint FK_TUSHU_REFERENCE_CBS foreign key (ID_CBS)
      references CBS (ID_CBS)
go

