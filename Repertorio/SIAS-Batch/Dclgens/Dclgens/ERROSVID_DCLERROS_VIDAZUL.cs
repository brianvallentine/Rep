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
    public class ERROSVID_DCLERROS_VIDAZUL : VarBasis
    {
        /*"    10 ERROSVID-COD-ERRO    PIC S9(4) USAGE COMP.*/
        public IntBasis ERROSVID_COD_ERRO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 ERROSVID-DESCR-ERRO  PIC X(60).*/
        public StringBasis ERROSVID_DESCR_ERRO { get; set; } = new StringBasis(new PIC("X", "60", "X(60)."), @"");
        /*"    10 ERROSVID-COD-ERRO-SIVPF       PIC S9(9) USAGE COMP.*/
        public IntBasis ERROSVID_COD_ERRO_SIVPF { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 ERROSVID-IND-TIPO-ERRO       PIC X(3).*/
        public StringBasis ERROSVID_IND_TIPO_ERRO { get; set; } = new StringBasis(new PIC("X", "3", "X(3)."), @"");
        /*"*/
    }
}