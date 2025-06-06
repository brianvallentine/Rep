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
    public class GESISFUN_GESISFUN_DES_FUNCAO : VarBasis
    {
        /*"       49 GESISFUN-DES-FUNCAO-LEN  PIC S9(4) USAGE COMP.*/
        public IntBasis GESISFUN_DES_FUNCAO_LEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"       49 GESISFUN-DES-FUNCAO-TEXT  PIC X(500).*/
        public StringBasis GESISFUN_DES_FUNCAO_TEXT { get; set; } = new StringBasis(new PIC("X", "500", "X(500)."), @"");
        /*"    10 GESISFUN-COD-GRUPO-FUNCAO  PIC S9(4) USAGE COMP.*/
    }
}