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
    public class GE562_DCLGE_DET_ARQ_G_SAP_ERRO : VarBasis
    {
        /*"    10 GE562-COD-LOTE-G     PIC X(24).*/
        public StringBasis GE562_COD_LOTE_G { get; set; } = new StringBasis(new PIC("X", "24", "X(24)."), @"");
        /*"    10 GE562-COD-ORIGEM     PIC X(4).*/
        public StringBasis GE562_COD_ORIGEM { get; set; } = new StringBasis(new PIC("X", "4", "X(4)."), @"");
        /*"    10 GE562-SEQ-REGISTRO-LOTE-G       PIC S9(9) USAGE COMP.*/
        public IntBasis GE562_SEQ_REGISTRO_LOTE_G { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE562-COD-ERRO-ARQ-G       PIC S9(4) USAGE COMP.*/
        public IntBasis GE562_COD_ERRO_ARQ_G { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE562-DES-MSG-ERRO.*/
        public GE562_GE562_DES_MSG_ERRO GE562_DES_MSG_ERRO { get; set; } = new GE562_GE562_DES_MSG_ERRO();

    }
}