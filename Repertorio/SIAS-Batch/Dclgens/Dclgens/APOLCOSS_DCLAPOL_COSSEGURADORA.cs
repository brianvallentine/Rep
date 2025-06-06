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
    public class APOLCOSS_DCLAPOL_COSSEGURADORA : VarBasis
    {
        /*"    10 APOLCOSS-NUM-APOLICE  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis APOLCOSS_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 APOLCOSS-COD-COSSEGURADORA  PIC S9(4) USAGE COMP.*/
        public IntBasis APOLCOSS_COD_COSSEGURADORA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 APOLCOSS-RAMO-COBERTURA  PIC S9(4) USAGE COMP.*/
        public IntBasis APOLCOSS_RAMO_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 APOLCOSS-DATA-INIVIGENCIA  PIC X(10).*/
        public StringBasis APOLCOSS_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 APOLCOSS-DATA-TERVIGENCIA  PIC X(10).*/
        public StringBasis APOLCOSS_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 APOLCOSS-PCT-PART-COSSEGURO  PIC S9(4)V9(5) USAGE COMP-3.*/
        public DoubleBasis APOLCOSS_PCT_PART_COSSEGURO { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(4)V9(5)"), 5);
        /*"    10 APOLCOSS-PCT-COM-COSSEGURO  PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis APOLCOSS_PCT_COM_COSSEGURO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 APOLCOSS-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis APOLCOSS_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 APOLCOSS-TIMESTAMP   PIC X(26).*/
        public StringBasis APOLCOSS_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}