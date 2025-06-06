using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Copies
{
    public class LBTB3201_TABELA_UF : VarBasis
    {
        /*"     10 FILL01 PIC X(30) VALUE '02AL ALAGOAS'*/
        public StringBasis FILL01 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"02AL ALAGOAS");
        /*"     10 FILL02 PIC X(30) VALUE '01AM AMAZONAS'*/
        public StringBasis FILL02 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"01AM AMAZONAS");
        /*"     10 FILL03 PIC X(30) VALUE '02BA BAHIA'*/
        public StringBasis FILL03 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"02BA BAHIA");
        /*"     10 FILL04 PIC X(30) VALUE '03DF DISTRITO FEDERAL'*/
        public StringBasis FILL04 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"03DF DISTRITO FEDERAL");
        /*"     10 FILL05 PIC X(30) VALUE '02CE CEARA'*/
        public StringBasis FILL05 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"02CE CEARA");
        /*"     10 FILL06 PIC X(30) VALUE '04ES ESPIRITO SANTO'*/
        public StringBasis FILL06 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"04ES ESPIRITO SANTO");
        /*"     10 FILL07 PIC X(30) VALUE '03MS MATO GROSSO DO SUL'*/
        public StringBasis FILL07 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"03MS MATO GROSSO DO SUL");
        /*"     10 FILL08 PIC X(30) VALUE '03GO GOIANIA    '*/
        public StringBasis FILL08 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"03GO GOIANIA    ");
        /*"     10 FILL09 PIC X(30) VALUE '02MA MARANHAO'*/
        public StringBasis FILL09 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"02MA MARANHAO");
        /*"     10 FILL10 PIC X(30) VALUE '03MT MATO GROSSO'*/
        public StringBasis FILL10 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"03MT MATO GROSSO");
        /*"     10 FILL11 PIC X(30) VALUE '04MG BELO HORIZONTE'*/
        public StringBasis FILL11 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"04MG BELO HORIZONTE");
        /*"     10 FILL12 PIC X(30) VALUE '01PA PARA'*/
        public StringBasis FILL12 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"01PA PARA");
        /*"     10 FILL13 PIC X(30) VALUE '02PB PARAIBA'*/
        public StringBasis FILL13 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"02PB PARAIBA");
        /*"     10 FILL14 PIC X(30) VALUE '05PR PARANA'*/
        public StringBasis FILL14 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"05PR PARANA");
        /*"     10 FILL15 PIC X(30) VALUE '02PE PERNAMBUCO'*/
        public StringBasis FILL15 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"02PE PERNAMBUCO");
        /*"     10 FILL16 PIC X(30) VALUE '02PI PIAUI     '*/
        public StringBasis FILL16 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"02PI PIAUI     ");
        /*"     10 FILL17 PIC X(30) VALUE '02RN RIO GRANDE DO NORTE'*/
        public StringBasis FILL17 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"02RN RIO GRANDE DO NORTE");
        /*"     10 FILL18 PIC X(30) VALUE '05RS RIO G DO SUL'*/
        public StringBasis FILL18 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"05RS RIO G DO SUL");
        /*"     10 FILL19 PIC X(30) VALUE '04RJ RIO DE JANEIRO'*/
        public StringBasis FILL19 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"04RJ RIO DE JANEIRO");
        /*"     10 FILL20 PIC X(30) VALUE '05SC SANTA CATARINA'*/
        public StringBasis FILL20 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"05SC SANTA CATARINA");
        /*"     10 FILL21 PIC X(30) VALUE '04SP SAO PAULO'*/
        public StringBasis FILL21 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"04SP SAO PAULO");
        /*"     10 FILL22 PIC X(30) VALUE '02SE SERGIPE '*/
        public StringBasis FILL22 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"02SE SERGIPE ");
        /*"     10 FILL23 PIC X(30) VALUE '01TO TOCANTINS   '*/
        public StringBasis FILL23 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"01TO TOCANTINS   ");
        /*"     10 FILL24 PIC X(30) VALUE '                 '*/
        public StringBasis FILL24 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"                 ");
        /*"     10 FILL25 PIC X(30) VALUE '          '*/
        public StringBasis FILL25 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"          ");
        /*"     10 FILL26 PIC X(30) VALUE '            '*/
        public StringBasis FILL26 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"            ");
        /*"     10 FILL27 PIC X(30) VALUE '            '*/
        public StringBasis FILL27 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"            ");
        /*"     10 FILL28 PIC X(30) VALUE '            '*/
        public StringBasis FILL28 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"            ");
        /*"     10 FILL29 PIC X(30) VALUE '            '*/
        public StringBasis FILL29 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"            ");
        /*"     10 FILL30 PIC X(30) VALUE '01AC ACRE     '*/
        public StringBasis FILL30 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"01AC ACRE     ");
        /*"     10 FILL31 PIC X(30) VALUE '01AP AMAPA    '*/
        public StringBasis FILL31 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"01AP AMAPA    ");
        /*"     10 FILL32 PIC X(30) VALUE '01RO RONDONIA '*/
        public StringBasis FILL32 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"01RO RONDONIA ");
        /*"     10 FILL33 PIC X(30) VALUE '01RR ROROIMA  '*/
        public StringBasis FILL33 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"01RR ROROIMA  ");
        /*"     10 FILL34 PIC X(30) VALUE '            '*/
        public StringBasis FILL34 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"            ");
        /*"     10 FILL35 PIC X(30) VALUE '            '*/
        public StringBasis FILL35 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"            ");
        /*"01 TABELA-UF-R REDEFINES TABELA-UF*/
    }
}