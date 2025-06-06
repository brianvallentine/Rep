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
    public class LBTB3201_TABELA_LIM_MINMAX_CCAT : VarBasis
    {
        /*"  10 FCCAT01 PIC X(34) VALUE    '30.000,00        500.000,00      '*/
        public StringBasis FCCAT01 { get; set; } = new StringBasis(new PIC("X", "34", "X(34)"), @"30.000,00        500.000,00      ");
        /*"  10 FCCAT02 PIC X(34) VALUE    '                                 '*/
        public StringBasis FCCAT02 { get; set; } = new StringBasis(new PIC("X", "34", "X(34)"), @"                                 ");
        /*"  10 FCCAT03 PIC X(34) VALUE    '5.000,00         20% COB BASICA  '*/
        public StringBasis FCCAT03 { get; set; } = new StringBasis(new PIC("X", "34", "X(34)"), @"5.000,00         20% COB BASICA  ");
        /*"  10 FCCAT04 PIC X(34) VALUE    '                                 '*/
        public StringBasis FCCAT04 { get; set; } = new StringBasis(new PIC("X", "34", "X(34)"), @"                                 ");
        /*"  10 FCCAT05 PIC X(34) VALUE    '                                 '*/
        public StringBasis FCCAT05 { get; set; } = new StringBasis(new PIC("X", "34", "X(34)"), @"                                 ");
        /*"  10 FCCAT06 PIC X(34) VALUE    '5.000,00         150.000,00      '*/
        public StringBasis FCCAT06 { get; set; } = new StringBasis(new PIC("X", "34", "X(34)"), @"5.000,00         150.000,00      ");
        /*"  10 FCCAT07 PIC X(34) VALUE    '5.000,00         500.000,00      '*/
        public StringBasis FCCAT07 { get; set; } = new StringBasis(new PIC("X", "34", "X(34)"), @"5.000,00         500.000,00      ");
        /*"  10 FCCAT08 PIC X(34) VALUE    '5.000,00         500.000,00      '*/
        public StringBasis FCCAT08 { get; set; } = new StringBasis(new PIC("X", "34", "X(34)"), @"5.000,00         500.000,00      ");
        /*"  10 FCCAT09 PIC X(34) VALUE    '2.000,00         50.000,00       '*/
        public StringBasis FCCAT09 { get; set; } = new StringBasis(new PIC("X", "34", "X(34)"), @"2.000,00         50.000,00       ");
        /*"  10 FCCAT10 PIC X(34) VALUE    '10% COB BASICA   50% COB BASICA  '*/
        public StringBasis FCCAT10 { get; set; } = new StringBasis(new PIC("X", "34", "X(34)"), @"10% COB BASICA   50% COB BASICA  ");
        /*"  10 FCCAT11 PIC X(34) VALUE    '5.000,00         20% COB BASICA  '*/
        public StringBasis FCCAT11 { get; set; } = new StringBasis(new PIC("X", "34", "X(34)"), @"5.000,00         20% COB BASICA  ");
        /*"  10 FCCAT12 PIC X(34) VALUE    '5.000,00         20% COB BASICA  '*/
        public StringBasis FCCAT12 { get; set; } = new StringBasis(new PIC("X", "34", "X(34)"), @"5.000,00         20% COB BASICA  ");
        /*"  10 FCCAT13 PIC X(34) VALUE    '10% COB BASICA   100.000,00      '*/
        public StringBasis FCCAT13 { get; set; } = new StringBasis(new PIC("X", "34", "X(34)"), @"10% COB BASICA   100.000,00      ");
        /*"  10 FCCAT14 PIC X(34) VALUE    '2.000,00         10% COB BASICA  '*/
        public StringBasis FCCAT14 { get; set; } = new StringBasis(new PIC("X", "34", "X(34)"), @"2.000,00         10% COB BASICA  ");
        /*"  10 FCCAT15 PIC X(34) VALUE    '10% COB BASICA   30%  COB BASICA '*/
        public StringBasis FCCAT15 { get; set; } = new StringBasis(new PIC("X", "34", "X(34)"), @"10% COB BASICA   30%  COB BASICA ");
        /*"  10 FCCAT16 PIC X(34) VALUE    '20.000,00        150.000,00      '*/
        public StringBasis FCCAT16 { get; set; } = new StringBasis(new PIC("X", "34", "X(34)"), @"20.000,00        150.000,00      ");
        /*"  10 FCCAT17 PIC X(34) VALUE    '5.000,00         1.500.000,00    '*/
        public StringBasis FCCAT17 { get; set; } = new StringBasis(new PIC("X", "34", "X(34)"), @"5.000,00         1.500.000,00    ");
        /*"  10 FCCAT18 PIC X(34) VALUE    '5.000,00         1.500.000,00    '*/
        public StringBasis FCCAT18 { get; set; } = new StringBasis(new PIC("X", "34", "X(34)"), @"5.000,00         1.500.000,00    ");
        /*"  10 FCCAT19 PIC X(34) VALUE    '5.000,00         1.500.000,00    '*/
        public StringBasis FCCAT19 { get; set; } = new StringBasis(new PIC("X", "34", "X(34)"), @"5.000,00         1.500.000,00    ");
        /*"  10 FCCAT20 PIC X(34) VALUE    '                                 '*/
        public StringBasis FCCAT20 { get; set; } = new StringBasis(new PIC("X", "34", "X(34)"), @"                                 ");
        /*" 07   FILLER              REDEFINES TABELA-LIM-MINMAX-CCAT*/
    }
}