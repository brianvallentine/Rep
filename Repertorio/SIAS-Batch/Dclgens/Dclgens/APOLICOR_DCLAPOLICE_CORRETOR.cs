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
    public class APOLICOR_DCLAPOLICE_CORRETOR : VarBasis
    {
        /*"    10 APOLICOR-NUM-APOLICE  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis APOLICOR_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 APOLICOR-RAMO-COBERTURA  PIC S9(4) USAGE COMP.*/
        public IntBasis APOLICOR_RAMO_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 APOLICOR-MODALI-COBERTURA  PIC S9(4) USAGE COMP.*/
        public IntBasis APOLICOR_MODALI_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 APOLICOR-COD-CORRETOR  PIC S9(9) USAGE COMP.*/
        public IntBasis APOLICOR_COD_CORRETOR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 APOLICOR-COD-SUBGRUPO  PIC S9(4) USAGE COMP.*/
        public IntBasis APOLICOR_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 APOLICOR-DATA-INIVIGENCIA  PIC X(10).*/
        public StringBasis APOLICOR_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 APOLICOR-DATA-TERVIGENCIA  PIC X(10).*/
        public StringBasis APOLICOR_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 APOLICOR-PCT-PART-CORRETOR  PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis APOLICOR_PCT_PART_CORRETOR { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 APOLICOR-PCT-COM-CORRETOR  PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis APOLICOR_PCT_COM_CORRETOR { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 APOLICOR-TIPO-COMISSAO  PIC X(1).*/
        public StringBasis APOLICOR_TIPO_COMISSAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 APOLICOR-IND-CORRETOR-PRIN  PIC X(1).*/
        public StringBasis APOLICOR_IND_CORRETOR_PRIN { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 APOLICOR-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis APOLICOR_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 APOLICOR-TIMESTAMP   PIC X(26).*/
        public StringBasis APOLICOR_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 APOLICOR-COD-USUARIO  PIC X(8).*/
        public StringBasis APOLICOR_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"*/
    }
}