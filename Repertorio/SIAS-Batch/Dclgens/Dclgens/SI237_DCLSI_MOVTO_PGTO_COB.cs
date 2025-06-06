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
    public class SI237_DCLSI_MOVTO_PGTO_COB : VarBasis
    {
        /*"    10 SI237-NUM-SINISTRO   PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis SI237_NUM_SINISTRO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 SI237-OCORR-HISTORICO       PIC S9(4) USAGE COMP.*/
        public IntBasis SI237_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SI237-IDE-SISTEMA    PIC X(2).*/
        public StringBasis SI237_IDE_SISTEMA { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 SI237-COD-OPERACAO   PIC S9(4) USAGE COMP.*/
        public IntBasis SI237_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SI237-NUM-ID-ENVIO   PIC S9(18) USAGE COMP.*/
        public IntBasis SI237_NUM_ID_ENVIO { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 SI237-SEQ-ID-ENVIO-HIST       PIC S9(4) USAGE COMP.*/
        public IntBasis SI237_SEQ_ID_ENVIO_HIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SI237-STA-ENVIO-MOVIMENTO       PIC X(2).*/
        public StringBasis SI237_STA_ENVIO_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 SI237-DTA-SI-ENVIO   PIC X(10).*/
        public StringBasis SI237_DTA_SI_ENVIO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SI237-DTA-SI-RETORNO-H       PIC X(10).*/
        public StringBasis SI237_DTA_SI_RETORNO_H { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SI237-DTA-EFETIVO-PGTO       PIC X(10).*/
        public StringBasis SI237_DTA_EFETIVO_PGTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SI237-COD-USUARIO    PIC X(8).*/
        public StringBasis SI237_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 SI237-COD-PROGRAMA   PIC X(10).*/
        public StringBasis SI237_COD_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SI237-DTH-CADASTRAMENTO       PIC X(26).*/
        public StringBasis SI237_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 SI237-SEQ-MOVTO-ARQH       PIC S9(4) USAGE COMP.*/
        public IntBasis SI237_SEQ_MOVTO_ARQH { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SI237-STA-MOVTO-HISTORICO       PIC X(2).*/
        public StringBasis SI237_STA_MOVTO_HISTORICO { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 SI237-QTD-RETORNO-ARQH       PIC S9(4) USAGE COMP.*/
        public IntBasis SI237_QTD_RETORNO_ARQH { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SI237-COD-EMPRESA    PIC S9(9) USAGE COMP.*/
        public IntBasis SI237_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"*/
    }
}