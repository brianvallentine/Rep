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
    public class GE409_DCLGE_DES_RETORNO_CIELO : VarBasis
    {
        /*"    10 GE409-COD-MOVIMENTO  PIC X(2).*/
        public StringBasis GE409_COD_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 GE409-COD-RETORNO    PIC X(3).*/
        public StringBasis GE409_COD_RETORNO { get; set; } = new StringBasis(new PIC("X", "3", "X(3)."), @"");
        /*"    10 GE409-DES-COD-RETORNO.*/
        public GE409_GE409_DES_COD_RETORNO GE409_DES_COD_RETORNO { get; set; } = new GE409_GE409_DES_COD_RETORNO();

    }
}