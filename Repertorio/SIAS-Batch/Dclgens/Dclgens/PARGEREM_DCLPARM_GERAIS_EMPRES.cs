using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Dclgens
{
    public class PARGEREM_DCLPARM_GERAIS_EMPRES : VarBasis
    {
        /*"    10 PARGEREM-DIA-FATURAMENTO  PIC S9(4) USAGE COMP.*/
        public IntBasis PARGEREM_DIA_FATURAMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PARGEREM-SITUACAO-FATUR-AUT  PIC X(1).*/
        public StringBasis PARGEREM_SITUACAO_FATUR_AUT { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PARGEREM-DATA-ULT-FATURAMEN  PIC X(10).*/
        public StringBasis PARGEREM_DATA_ULT_FATURAMEN { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PARGEREM-COD-CORRETOR  PIC S9(9) USAGE COMP.*/
        public IntBasis PARGEREM_COD_CORRETOR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PARGEREM-PCCOMCOR    PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis PARGEREM_PCCOMCOR { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 PARGEREM-PCCOMADM    PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis PARGEREM_PCCOMADM { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 PARGEREM-MIN-VIDAS   PIC S9(9) USAGE COMP.*/
        public IntBasis PARGEREM_MIN_VIDAS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PARGEREM-VAL-MIN-FAT-IX  PIC S9(5)V9(5) USAGE COMP-3.*/
        public DoubleBasis PARGEREM_VAL_MIN_FAT_IX { get; set; } = new DoubleBasis(new PIC("S9", "5", "S9(5)V9(5)"), 5);
        /*"    10 PARGEREM-COD-MOEDA-FAT  PIC S9(4) USAGE COMP.*/
        public IntBasis PARGEREM_COD_MOEDA_FAT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PARGEREM-COD-USUARIO  PIC X(8).*/
        public StringBasis PARGEREM_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 PARGEREM-TIMESTAMP   PIC X(26).*/
        public StringBasis PARGEREM_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 PARGEREM-NUM-APOLICE  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis PARGEREM_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"*/
    }
}