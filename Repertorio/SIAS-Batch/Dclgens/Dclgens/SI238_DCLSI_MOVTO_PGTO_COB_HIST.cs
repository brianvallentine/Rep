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
    public class SI238_DCLSI_MOVTO_PGTO_COB_HIST : VarBasis
    {
        /*"    10 SI238-NUM-SINISTRO   PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis SI238_NUM_SINISTRO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 SI238-OCORR-HISTORICO       PIC S9(4) USAGE COMP.*/
        public IntBasis SI238_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SI238-IDE-SISTEMA    PIC X(2).*/
        public StringBasis SI238_IDE_SISTEMA { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 SI238-COD-OPERACAO   PIC S9(4) USAGE COMP.*/
        public IntBasis SI238_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SI238-SEQ-SI-PGTO-COB-HIST       PIC S9(4) USAGE COMP.*/
        public IntBasis SI238_SEQ_SI_PGTO_COB_HIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SI238-NUM-ID-ENVIO   PIC S9(18) USAGE COMP.*/
        public IntBasis SI238_NUM_ID_ENVIO { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 SI238-SEQ-ID-ENVIO-HIST       PIC S9(4) USAGE COMP.*/
        public IntBasis SI238_SEQ_ID_ENVIO_HIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SI238-STA-ENVIO-MOVIMENTO       PIC X(2).*/
        public StringBasis SI238_STA_ENVIO_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 SI238-DTA-SI-ENVIO   PIC X(10).*/
        public StringBasis SI238_DTA_SI_ENVIO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SI238-DTA-SI-RETORNO-H       PIC X(10).*/
        public StringBasis SI238_DTA_SI_RETORNO_H { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SI238-DTA-EFETIVO-PGTO       PIC X(10).*/
        public StringBasis SI238_DTA_EFETIVO_PGTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SI238-COD-USUARIO    PIC X(8).*/
        public StringBasis SI238_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 SI238-COD-PROGRAMA   PIC X(10).*/
        public StringBasis SI238_COD_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SI238-DTH-CADASTRAMENTO       PIC X(26).*/
        public StringBasis SI238_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 SI238-SEQ-MOVTO-ARQH       PIC S9(4) USAGE COMP.*/
        public IntBasis SI238_SEQ_MOVTO_ARQH { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SI238-STA-MOVTO-HISTORICO       PIC X(2).*/
        public StringBasis SI238_STA_MOVTO_HISTORICO { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 SI238-QTD-RETORNO-ARQH       PIC S9(4) USAGE COMP.*/
        public IntBasis SI238_QTD_RETORNO_ARQH { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SI238-COD-EMPRESA    PIC S9(9) USAGE COMP.*/
        public IntBasis SI238_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
    }
}