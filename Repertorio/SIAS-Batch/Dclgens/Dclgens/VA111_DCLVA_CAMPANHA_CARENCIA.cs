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
    public class VA111_DCLVA_CAMPANHA_CARENCIA : VarBasis
    {
        /*"    10 VA111-NUM-CPF-CNPJ   PIC S9(14)V USAGE COMP-3.*/
        public DoubleBasis VA111_NUM_CPF_CNPJ { get; set; } = new DoubleBasis(new PIC("S9", "14", "S9(14)V"), 0);
        /*"    10 VA111-STA-CARENCIA   PIC X(1).*/
        public StringBasis VA111_STA_CARENCIA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 VA111-COD-USUARIO    PIC X(8).*/
        public StringBasis VA111_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 VA111-DTH-INCLUSAO   PIC X(26).*/
        public StringBasis VA111_DTH_INCLUSAO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}