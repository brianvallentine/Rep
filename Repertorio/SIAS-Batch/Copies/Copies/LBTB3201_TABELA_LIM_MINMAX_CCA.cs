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
    public class LBTB3201_TABELA_LIM_MINMAX_CCA : VarBasis
    {
        /*"  10 FCCA01 PIC X(34) VALUE    '30.000,00        500.000,00       '*/
        public StringBasis FCCA01 { get; set; } = new StringBasis(new PIC("X", "34", "X(34)"), @"30.000,00        500.000,00       ");
        /*"  10 FCCA02 PIC X(34) VALUE    '                                  '*/
        public StringBasis FCCA02 { get; set; } = new StringBasis(new PIC("X", "34", "X(34)"), @"                                  ");
        /*"  10 FCCA03 PIC X(34) VALUE    '5.000,00         20% COB BASICA   '*/
        public StringBasis FCCA03 { get; set; } = new StringBasis(new PIC("X", "34", "X(34)"), @"5.000,00         20% COB BASICA   ");
        /*"  10 FCCA04 PIC X(34) VALUE    '                                  '*/
        public StringBasis FCCA04 { get; set; } = new StringBasis(new PIC("X", "34", "X(34)"), @"                                  ");
        /*"  10 FCCA05 PIC X(34) VALUE    '                                  '*/
        public StringBasis FCCA05 { get; set; } = new StringBasis(new PIC("X", "34", "X(34)"), @"                                  ");
        /*"  10 FCCA06 PIC X(34) VALUE    '5.000,00         150.000,00       '*/
        public StringBasis FCCA06 { get; set; } = new StringBasis(new PIC("X", "34", "X(34)"), @"5.000,00         150.000,00       ");
        /*"  10 FCCA07 PIC X(34) VALUE    '5.000,00         500.000,00       '*/
        public StringBasis FCCA07 { get; set; } = new StringBasis(new PIC("X", "34", "X(34)"), @"5.000,00         500.000,00       ");
        /*"  10 FCCA08 PIC X(34) VALUE    '5.000,00         500.000,00       '*/
        public StringBasis FCCA08 { get; set; } = new StringBasis(new PIC("X", "34", "X(34)"), @"5.000,00         500.000,00       ");
        /*"  10 FCCA09 PIC X(34) VALUE    '2.000,00         50.000,00        '*/
        public StringBasis FCCA09 { get; set; } = new StringBasis(new PIC("X", "34", "X(34)"), @"2.000,00         50.000,00        ");
        /*"  10 FCCA10 PIC X(34) VALUE    '10% COB BASICA   50% COB BASICA   '*/
        public StringBasis FCCA10 { get; set; } = new StringBasis(new PIC("X", "34", "X(34)"), @"10% COB BASICA   50% COB BASICA   ");
        /*"  10 FCCA11 PIC X(34) VALUE    '5.000,00         20% COB BASICA   '*/
        public StringBasis FCCA11 { get; set; } = new StringBasis(new PIC("X", "34", "X(34)"), @"5.000,00         20% COB BASICA   ");
        /*"  10 FCCA12 PIC X(34) VALUE    '5.000,00         20% COB BASICA   '*/
        public StringBasis FCCA12 { get; set; } = new StringBasis(new PIC("X", "34", "X(34)"), @"5.000,00         20% COB BASICA   ");
        /*"  10 FCCA13 PIC X(34) VALUE    '10% COB BASICA   100.000,00       '*/
        public StringBasis FCCA13 { get; set; } = new StringBasis(new PIC("X", "34", "X(34)"), @"10% COB BASICA   100.000,00       ");
        /*"  10 FCCA14 PIC X(34) VALUE    '2.000,00         10% COB BASICA   '*/
        public StringBasis FCCA14 { get; set; } = new StringBasis(new PIC("X", "34", "X(34)"), @"2.000,00         10% COB BASICA   ");
        /*"  10 FCCA15 PIC X(34) VALUE    '10% COB BASICA   30%  COB BASICA  '*/
        public StringBasis FCCA15 { get; set; } = new StringBasis(new PIC("X", "34", "X(34)"), @"10% COB BASICA   30%  COB BASICA  ");
        /*"  10 FCCA16 PIC X(34) VALUE    '20.000,00        150.000,00       '*/
        public StringBasis FCCA16 { get; set; } = new StringBasis(new PIC("X", "34", "X(34)"), @"20.000,00        150.000,00       ");
        /*"  10 FCCA17 PIC X(34) VALUE    '5.000,00         1.500.000,00     '*/
        public StringBasis FCCA17 { get; set; } = new StringBasis(new PIC("X", "34", "X(34)"), @"5.000,00         1.500.000,00     ");
        /*"  10 FCCA18 PIC X(34) VALUE    '5.000,00         1.500.000,00     '*/
        public StringBasis FCCA18 { get; set; } = new StringBasis(new PIC("X", "34", "X(34)"), @"5.000,00         1.500.000,00     ");
        /*"  10 FCCA19 PIC X(34) VALUE    '5.000,00         1.500.000,00     '*/
        public StringBasis FCCA19 { get; set; } = new StringBasis(new PIC("X", "34", "X(34)"), @"5.000,00         1.500.000,00     ");
        /*"  10 FCCA20 PIC X(34) VALUE    '                                  '*/
        public StringBasis FCCA20 { get; set; } = new StringBasis(new PIC("X", "34", "X(34)"), @"                                  ");
        /*" 07   FILLER              REDEFINES TABELA-LIM-MINMAX-CCA*/
    }
}