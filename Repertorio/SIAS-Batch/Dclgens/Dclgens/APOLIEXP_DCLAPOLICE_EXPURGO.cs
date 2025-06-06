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
    public class APOLIEXP_DCLAPOLICE_EXPURGO : VarBasis
    {
        /*"    10 APOLIEXP-NUM-APOLICE  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis APOLIEXP_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 APOLIEXP-NUM-ITEM    PIC S9(9) USAGE COMP.*/
        public IntBasis APOLIEXP_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 APOLIEXP-ID-MESTRE-EXPURGO  PIC S9(4) USAGE COMP.*/
        public IntBasis APOLIEXP_ID_MESTRE_EXPURGO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 APOLIEXP-RAMO        PIC S9(4) USAGE COMP.*/
        public IntBasis APOLIEXP_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 APOLIEXP-SITUACAO-APOLICE  PIC S9(4) USAGE COMP.*/
        public IntBasis APOLIEXP_SITUACAO_APOLICE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 APOLIEXP-DATA-SITUACAO  PIC X(10).*/
        public StringBasis APOLIEXP_DATA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 APOLIEXP-COD-CLIENTE  PIC S9(9) USAGE COMP.*/
        public IntBasis APOLIEXP_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"*/
    }
}