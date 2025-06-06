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
    public class GE284_GE284_DES_FUNCAO_SISTEMA : VarBasis
    {
        /*"       49 GE284-DES-FUNCAO-SISTEMA-LEN  PIC S9(4) USAGE COMP.*/
        public IntBasis GE284_DES_FUNCAO_SISTEMA_LEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"       49 GE284-DES-FUNCAO-SISTEMA-TEXT  PIC X(300).*/
        public StringBasis GE284_DES_FUNCAO_SISTEMA_TEXT { get; set; } = new StringBasis(new PIC("X", "300", "X(300)."), @"");
        /*"    10 GE284-COD-USUARIO    PIC X(8).*/
    }
}