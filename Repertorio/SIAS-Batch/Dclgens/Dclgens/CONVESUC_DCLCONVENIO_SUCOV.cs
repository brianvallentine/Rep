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
    public class CONVESUC_DCLCONVENIO_SUCOV : VarBasis
    {
        /*"    10 CONVESUC-COD-CONVENIO  PIC S9(9) USAGE COMP.*/
        public IntBasis CONVESUC_COD_CONVENIO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 CONVESUC-NOME-CONVENIO  PIC X(30).*/
        public StringBasis CONVESUC_NOME_CONVENIO { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
        /*"    10 CONVESUC-VERSAO-LAYOUT  PIC S9(4) USAGE COMP.*/
        public IntBasis CONVESUC_VERSAO_LAYOUT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CONVESUC-NSA-CONVENIO  PIC S9(4) USAGE COMP.*/
        public IntBasis CONVESUC_NSA_CONVENIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"*/
    }
}