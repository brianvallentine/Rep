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
    public class GE411_DCLGE_STA_REGISTRO_CARTAO : VarBasis
    {
        /*"    10 GE411-STA-REGISTRO   PIC X(1).*/
        public StringBasis GE411_STA_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GE411-DES-STATUS     PIC X(40).*/
        public StringBasis GE411_DES_STATUS { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"*/
    }
}