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
    public class SEGURHIS_DCLSEGURADOSVGAP_HIST : VarBasis
    {
        /*"    10 SEGURHIS-NUM-APOLICE  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis SEGURHIS_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 SEGURHIS-COD-SUBGRUPO  PIC S9(4) USAGE COMP.*/
        public IntBasis SEGURHIS_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SEGURHIS-NUM-ITEM    PIC S9(9) USAGE COMP.*/
        public IntBasis SEGURHIS_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SEGURHIS-COD-OPERACAO  PIC S9(4) USAGE COMP.*/
        public IntBasis SEGURHIS_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SEGURHIS-DATA-OPERACAO  PIC X(10).*/
        public StringBasis SEGURHIS_DATA_OPERACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SEGURHIS-HORA-OPERACAO  PIC X(8).*/
        public StringBasis SEGURHIS_HORA_OPERACAO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 SEGURHIS-DATA-MOVIMENTO  PIC X(10).*/
        public StringBasis SEGURHIS_DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SEGURHIS-OCORR-HISTORICO  PIC S9(4) USAGE COMP.*/
        public IntBasis SEGURHIS_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SEGURHIS-COD-SUBGRUPO-TRANS  PIC S9(4) USAGE COMP.*/
        public IntBasis SEGURHIS_COD_SUBGRUPO_TRANS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SEGURHIS-DATA-REFERENCIA  PIC X(10).*/
        public StringBasis SEGURHIS_DATA_REFERENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SEGURHIS-COD-USUARIO  PIC X(8).*/
        public StringBasis SEGURHIS_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 SEGURHIS-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis SEGURHIS_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SEGURHIS-COD-MOEDA-IMP  PIC S9(4) USAGE COMP.*/
        public IntBasis SEGURHIS_COD_MOEDA_IMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SEGURHIS-COD-MOEDA-PRM  PIC S9(4) USAGE COMP.*/
        public IntBasis SEGURHIS_COD_MOEDA_PRM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"*/
    }
}