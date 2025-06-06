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
    public class SINILT01_DCLSINI_LOTERICO01 : VarBasis
    {
        /*"    10 SINILT01-COD-LOT-FENAL  PIC S9(9) USAGE COMP.*/
        public IntBasis SINILT01_COD_LOT_FENAL { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SINILT01-NUM-APOLICE  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis SINILT01_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 SINILT01-NUM-APOL-SINISTRO  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis SINILT01_NUM_APOL_SINISTRO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 SINILT01-NUM-CONTROLE-FENAL  PIC S9(9) USAGE COMP.*/
        public IntBasis SINILT01_NUM_CONTROLE_FENAL { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SINILT01-COD-LOT-CEF  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis SINILT01_COD_LOT_CEF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 SINILT01-COD-CLIENTE  PIC S9(9) USAGE COMP.*/
        public IntBasis SINILT01_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SINILT01-SITUACAO    PIC X(1).*/
        public StringBasis SINILT01_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SINILT01-DATA-GERA-MOV  PIC X(10).*/
        public StringBasis SINILT01_DATA_GERA_MOV { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SINILT01-COD-ORIGEM-AVISO  PIC X(1).*/
        public StringBasis SINILT01_COD_ORIGEM_AVISO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SINILT01-DTINIVIG    PIC X(10).*/
        public StringBasis SINILT01_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SINILT01-TIMESTAMP   PIC X(26).*/
        public StringBasis SINILT01_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 SINILT01-COD-COBERTURA  PIC S9(4) USAGE COMP.*/
        public IntBasis SINILT01_COD_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"*/
    }
}