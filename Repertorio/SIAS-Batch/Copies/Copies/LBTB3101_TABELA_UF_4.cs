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
    public class LBTB3101_TABELA_UF_4 : VarBasis
    {
        /*"  10 FILL01 PIC X(30) VALUE '01AL ALAGOAS'*/
        public StringBasis FILL01_0 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"01AL ALAGOAS");
        /*"  10 FILL02 PIC X(30) VALUE '01AM AMAZONAS'*/
        public StringBasis FILL02_0 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"01AM AMAZONAS");
        /*"  10 FILL03 PIC X(30) VALUE '01BA BAHIA'*/
        public StringBasis FILL03_0 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"01BA BAHIA");
        /*"  10 FILL04 PIC X(30) VALUE '02DF DISTRITO FEDERAL'*/
        public StringBasis FILL04_0 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"02DF DISTRITO FEDERAL");
        /*"  10 FILL05 PIC X(30) VALUE '01CE CEARA'*/
        public StringBasis FILL05_0 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"01CE CEARA");
        /*"  10 FILL06 PIC X(30) VALUE '03ES ESPIRITO SANTO'*/
        public StringBasis FILL06_0 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"03ES ESPIRITO SANTO");
        /*"  10 FILL07 PIC X(30) VALUE '02MS MATO GROSSO DO SUL'*/
        public StringBasis FILL07_0 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"02MS MATO GROSSO DO SUL");
        /*"  10 FILL08 PIC X(30) VALUE '02GO GOIANIA    '*/
        public StringBasis FILL08_0 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"02GO GOIANIA    ");
        /*"  10 FILL09 PIC X(30) VALUE '01MA MARANHAO'*/
        public StringBasis FILL09_0 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"01MA MARANHAO");
        /*"  10 FILL10 PIC X(30) VALUE '02MT MATO GROSSO'*/
        public StringBasis FILL10_0 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"02MT MATO GROSSO");
        /*"  10 FILL11 PIC X(30) VALUE '03MG BELO HORIZONTE'*/
        public StringBasis FILL11_0 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"03MG BELO HORIZONTE");
        /*"  10 FILL12 PIC X(30) VALUE '01PA PARA'*/
        public StringBasis FILL12_0 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"01PA PARA");
        /*"  10 FILL13 PIC X(30) VALUE '01PB PARAIBA'*/
        public StringBasis FILL13_0 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"01PB PARAIBA");
        /*"  10 FILL14 PIC X(30) VALUE '04PR PARANA'*/
        public StringBasis FILL14_0 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"04PR PARANA");
        /*"  10 FILL15 PIC X(30) VALUE '01PE PERNAMBUCO'*/
        public StringBasis FILL15_0 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"01PE PERNAMBUCO");
        /*"  10 FILL16 PIC X(30) VALUE '01PI PIAUI     '*/
        public StringBasis FILL16_0 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"01PI PIAUI     ");
        /*"  10 FILL17 PIC X(30) VALUE '01RN RIO GRANDE DO NORTE'*/
        public StringBasis FILL17_0 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"01RN RIO GRANDE DO NORTE");
        /*"  10 FILL18 PIC X(30) VALUE '04RS RIO G DO SUL'*/
        public StringBasis FILL18_0 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"04RS RIO G DO SUL");
        /*"  10 FILL19 PIC X(30) VALUE '03RJ RIO DE JANEIRO'*/
        public StringBasis FILL19_0 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"03RJ RIO DE JANEIRO");
        /*"  10 FILL20 PIC X(30) VALUE '04SC SANTA CATARINA'*/
        public StringBasis FILL20_0 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"04SC SANTA CATARINA");
        /*"  10 FILL21 PIC X(30) VALUE '03SP SAO PAULO'*/
        public StringBasis FILL21_0 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"03SP SAO PAULO");
        /*"  10 FILL22 PIC X(30) VALUE '01SE SERGIPE '*/
        public StringBasis FILL22_0 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"01SE SERGIPE ");
        /*"  10 FILL23 PIC X(30) VALUE '01TO TOCANTINS   '*/
        public StringBasis FILL23_0 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"01TO TOCANTINS   ");
        /*"  10 FILL24 PIC X(30) VALUE '                 '*/
        public StringBasis FILL24_0 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"                 ");
        /*"  10 FILL25 PIC X(30) VALUE '          '*/
        public StringBasis FILL25_0 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"          ");
        /*"  10 FILL26 PIC X(30) VALUE '            '*/
        public StringBasis FILL26_0 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"            ");
        /*"  10 FILL27 PIC X(30) VALUE '            '*/
        public StringBasis FILL27_0 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"            ");
        /*"  10 FILL28 PIC X(30) VALUE '            '*/
        public StringBasis FILL28_0 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"            ");
        /*"  10 FILL29 PIC X(30) VALUE '            '*/
        public StringBasis FILL29_0 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"            ");
        /*"  10 FILL30 PIC X(30) VALUE '01AC ACRE     '*/
        public StringBasis FILL30_0 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"01AC ACRE     ");
        /*"  10 FILL31 PIC X(30) VALUE '01AP AMAPA    '*/
        public StringBasis FILL31_0 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"01AP AMAPA    ");
        /*"  10 FILL32 PIC X(30) VALUE '01RO RONDONIA '*/
        public StringBasis FILL32_0 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"01RO RONDONIA ");
        /*"  10 FILL33 PIC X(30) VALUE '01RR ROROIMA  '*/
        public StringBasis FILL33_0 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"01RR ROROIMA  ");
        /*"  10 FILL34 PIC X(30) VALUE '            '*/
        public StringBasis FILL34_0 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"            ");
        /*"  10 FILL35 PIC X(30) VALUE '            '*/
        public StringBasis FILL35_0 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"            ");
        /*"01 TABELA-UF-4-R REDEFINES TABELA-UF-4*/
    }
}