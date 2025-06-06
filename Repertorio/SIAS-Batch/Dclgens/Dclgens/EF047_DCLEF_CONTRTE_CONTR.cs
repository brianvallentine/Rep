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
    public class EF047_DCLEF_CONTRTE_CONTR : VarBasis
    {
        /*"    10 EF047-NUM-CONTRATO   PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis EF047_NUM_CONTRATO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 EF047-COD-PESSOA-CONTRTE  PIC S9(9) USAGE COMP.*/
        public IntBasis EF047_COD_PESSOA_CONTRTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 EF047-NOM-ARQUIVO    PIC X(8).*/
        public StringBasis EF047_NOM_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"*/
    }
}