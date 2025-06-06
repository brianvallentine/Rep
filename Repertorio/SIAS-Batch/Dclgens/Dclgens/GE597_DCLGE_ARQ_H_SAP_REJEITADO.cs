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
    public class GE597_DCLGE_ARQ_H_SAP_REJEITADO : VarBasis
    {
        /*"    10 GE597-NOM-EXTERNO-ARQUIVO       PIC X(50).*/
        public StringBasis GE597_NOM_EXTERNO_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "50", "X(50)."), @"");
        /*"    10 GE597-NUM-NSA-SAP    PIC S9(9) USAGE COMP.*/
        public IntBasis GE597_NUM_NSA_SAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE597-SEQ-REGISTRO   PIC S9(9) USAGE COMP.*/
        public IntBasis GE597_SEQ_REGISTRO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE597-DES-REJEICAO.*/
        public GE597_GE597_DES_REJEICAO GE597_DES_REJEICAO { get; set; } = new GE597_GE597_DES_REJEICAO();

        public StringBasis GE597_STA_REJEICAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GE597-DTH-ATUALIZACAO       PIC X(26).*/
        public StringBasis GE597_DTH_ATUALIZACAO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}