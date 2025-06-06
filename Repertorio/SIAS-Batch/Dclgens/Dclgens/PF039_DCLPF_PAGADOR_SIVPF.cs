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
    public class PF039_DCLPF_PAGADOR_SIVPF : VarBasis
    {
        /*"    10 PF039-NUM-CGC-CPF    PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis PF039_NUM_CGC_CPF { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 PF039-NOM-PAGADOR    PIC X(40).*/
        public StringBasis PF039_NOM_PAGADOR { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 PF039-DTH-NASCIMENTO  PIC X(10).*/
        public StringBasis PF039_DTH_NASCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PF039-NUM-TELEFONE   PIC X(11).*/
        public StringBasis PF039_NUM_TELEFONE { get; set; } = new StringBasis(new PIC("X", "11", "X(11)."), @"");
    }
}