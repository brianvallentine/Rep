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
    public class LBTB3101_TABELA_LIM_MINMAX : VarBasis
    {
        /*"  10 FILLE1 PIC X(34) VALUE     '30.000,00        1.000.000,00     '*/
        public StringBasis FILLE1 { get; set; } = new StringBasis(new PIC("X", "34", "X(34)"), @"30.000,00        1.000.000,00     ");
        /*"  10 FILLE2 PIC X(34) VALUE     '                                  '*/
        public StringBasis FILLE2 { get; set; } = new StringBasis(new PIC("X", "34", "X(34)"), @"                                  ");
        /*"  10 FILLE3 PIC X(34) VALUE     '5.000,00         20% COB BASICA   '*/
        public StringBasis FILLE3 { get; set; } = new StringBasis(new PIC("X", "34", "X(34)"), @"5.000,00         20% COB BASICA   ");
        /*"  10 FILLE4 PIC X(34) VALUE     '                                  '*/
        public StringBasis FILLE4 { get; set; } = new StringBasis(new PIC("X", "34", "X(34)"), @"                                  ");
        /*"  10 FILLE5 PIC X(34) VALUE     '                                  '*/
        public StringBasis FILLE5 { get; set; } = new StringBasis(new PIC("X", "34", "X(34)"), @"                                  ");
        /*"  10 FILLE6 PIC X(34) VALUE     '5.000,00         300.000,00       '*/
        public StringBasis FILLE6 { get; set; } = new StringBasis(new PIC("X", "34", "X(34)"), @"5.000,00         300.000,00       ");
        /*"  10 FILLE7 PIC X(34) VALUE     '5.000,00         200.000,00       '*/
        public StringBasis FILLE7 { get; set; } = new StringBasis(new PIC("X", "34", "X(34)"), @"5.000,00         200.000,00       ");
        /*"  10 FILLE8 PIC X(34) VALUE     '5.000,00         200.000,00       '*/
        public StringBasis FILLE8 { get; set; } = new StringBasis(new PIC("X", "34", "X(34)"), @"5.000,00         200.000,00       ");
        /*"  10 FILLE9 PIC X(34) VALUE     '2.000,00         50.000,00        '*/
        public StringBasis FILLE9 { get; set; } = new StringBasis(new PIC("X", "34", "X(34)"), @"2.000,00         50.000,00        ");
        /*"  10 FILL10 PIC X(34) VALUE     '10% COB BASICA   50% COB BASICA   '*/
        public StringBasis FILL10_1 { get; set; } = new StringBasis(new PIC("X", "34", "X(34)"), @"10% COB BASICA   50% COB BASICA   ");
        /*"  10 FILL11 PIC X(34) VALUE     '5.000,00         60.000,00        '*/
        public StringBasis FILL11_1 { get; set; } = new StringBasis(new PIC("X", "34", "X(34)"), @"5.000,00         60.000,00        ");
        /*"  10 FILL12 PIC X(34) VALUE     '5.000,00         20% COB BASICA   '*/
        public StringBasis FILL12_1 { get; set; } = new StringBasis(new PIC("X", "34", "X(34)"), @"5.000,00         20% COB BASICA   ");
        /*"  10 FILL13 PIC X(34) VALUE     '10% COB BASICA   500.000,00       '*/
        public StringBasis FILL13_1 { get; set; } = new StringBasis(new PIC("X", "34", "X(34)"), @"10% COB BASICA   500.000,00       ");
        /*"  10 FILL14 PIC X(34) VALUE     '2.000,00         10% COB BASICA   '*/
        public StringBasis FILL14_1 { get; set; } = new StringBasis(new PIC("X", "34", "X(34)"), @"2.000,00         10% COB BASICA   ");
        /*"  10 FILL15 PIC X(34) VALUE     '10% COB BASICA   30%  COB BASICA  '*/
        public StringBasis FILL15_1 { get; set; } = new StringBasis(new PIC("X", "34", "X(34)"), @"10% COB BASICA   30%  COB BASICA  ");
        /*"  10 FILL16 PIC X(34) VALUE     '20.000,00        150.000,00       '*/
        public StringBasis FILL16_1 { get; set; } = new StringBasis(new PIC("X", "34", "X(34)"), @"20.000,00        150.000,00       ");
        /*"  10 FILL17 PIC X(34) VALUE     '5.000,00         200.000,00       '*/
        public StringBasis FILL17_1 { get; set; } = new StringBasis(new PIC("X", "34", "X(34)"), @"5.000,00         200.000,00       ");
        /*"  10 FILL18 PIC X(34) VALUE     '5.000,00         200.000,00       '*/
        public StringBasis FILL18_1 { get; set; } = new StringBasis(new PIC("X", "34", "X(34)"), @"5.000,00         200.000,00       ");
        /*"  10 FILL19 PIC X(34) VALUE     '5.000,00         200.000,00       '*/
        public StringBasis FILL19_1 { get; set; } = new StringBasis(new PIC("X", "34", "X(34)"), @"5.000,00         200.000,00       ");
        /*"  10 FILL20 PIC X(34) VALUE     '                                  '*/
        public StringBasis FILL20_1 { get; set; } = new StringBasis(new PIC("X", "34", "X(34)"), @"                                  ");
        /*" 07   TABELA-LIM-MINMAX-R REDEFINES TABELA-LIM-MINMAX*/
    }
}