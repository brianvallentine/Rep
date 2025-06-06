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
    public class GE552_DCLGE_CONTROL_ARQ_G_SAP : VarBasis
    {
        /*"    10 GE552-COD-LOTE-G     PIC X(24).*/
        public StringBasis GE552_COD_LOTE_G { get; set; } = new StringBasis(new PIC("X", "24", "X(24)."), @"");
        /*"    10 GE552-COD-ORIGEM     PIC X(4).*/
        public StringBasis GE552_COD_ORIGEM { get; set; } = new StringBasis(new PIC("X", "4", "X(4)."), @"");
        /*"    10 GE552-DTA-GERACAO-ARQ       PIC X(10).*/
        public StringBasis GE552_DTA_GERACAO_ARQ { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE552-QTD-REGISTRO   PIC S9(9) USAGE COMP.*/
        public IntBasis GE552_QTD_REGISTRO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE552-NOM-EXTERNO-ARQUIVO       PIC X(50).*/
        public StringBasis GE552_NOM_EXTERNO_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "50", "X(50)."), @"");
        /*"*/
    }
}