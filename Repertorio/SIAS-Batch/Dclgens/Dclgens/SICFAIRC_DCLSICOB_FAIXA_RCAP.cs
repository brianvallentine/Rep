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
    public class SICFAIRC_DCLSICOB_FAIXA_RCAP : VarBasis
    {
        /*"    10 SICFAIRC-NUM-SICOB-INI  PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis SICFAIRC_NUM_SICOB_INI { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 SICFAIRC-NUM-SICOB-FIM  PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis SICFAIRC_NUM_SICOB_FIM { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 SICFAIRC-COD-PRODUTO  PIC S9(4) USAGE COMP.*/
        public IntBasis SICFAIRC_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SICFAIRC-DESCR-FAIXA  PIC X(50).*/
        public StringBasis SICFAIRC_DESCR_FAIXA { get; set; } = new StringBasis(new PIC("X", "50", "X(50)."), @"");
        /*"    10 SICFAIRC-COD-CEDENTE  PIC S9(4) USAGE COMP.*/
        public IntBasis SICFAIRC_COD_CEDENTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SICFAIRC-TIMESTAMP   PIC X(26).*/
        public StringBasis SICFAIRC_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 SICFAIRC-COD-RAMO    PIC S9(4) USAGE COMP.*/
        public IntBasis SICFAIRC_COD_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SICFAIRC-COD-VERSAO  PIC S9(4) USAGE COMP.*/
        public IntBasis SICFAIRC_COD_VERSAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
    }
}