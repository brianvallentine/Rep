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
    public class GE576_DCLGE_RETORNO_ARQ_H_SAP : VarBasis
    {
        /*"    10 GE576-COD-RETORNO-ARQ-H       PIC X(6).*/
        public StringBasis GE576_COD_RETORNO_ARQ_H { get; set; } = new StringBasis(new PIC("X", "6", "X(6)."), @"");
        /*"    10 GE576-IND-TIPO-RETORNO       PIC S9(4) USAGE COMP.*/
        public IntBasis GE576_IND_TIPO_RETORNO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE576-DES-RETORNO-ARQ-H.*/
        public GE576_GE576_DES_RETORNO_ARQ_H GE576_DES_RETORNO_ARQ_H { get; set; } = new GE576_GE576_DES_RETORNO_ARQ_H();

        public StringBasis GE576_STA_COD_RETORNO_ARQ_H { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"*/
    }
}