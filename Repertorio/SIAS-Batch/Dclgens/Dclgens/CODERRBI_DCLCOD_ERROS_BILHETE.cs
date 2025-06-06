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
    public class CODERRBI_DCLCOD_ERROS_BILHETE : VarBasis
    {
        /*"    10 CODERRBI-COD-ERRO    PIC S9(4) USAGE COMP.*/
        public IntBasis CODERRBI_COD_ERRO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CODERRBI-DESCR-ERRO  PIC X(60).*/
        public StringBasis CODERRBI_DESCR_ERRO { get; set; } = new StringBasis(new PIC("X", "60", "X(60)."), @"");
        /*"    10 CODERRBI-TIPO-ERRO   PIC X(1).*/
        public StringBasis CODERRBI_TIPO_ERRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 CODERRBI-COD-ERRO-SIVPF  PIC S9(4) USAGE COMP.*/
        public IntBasis CODERRBI_COD_ERRO_SIVPF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"*/
    }
}