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
    public class GEARDETA_DCLGE_AR_DETALHE : VarBasis
    {
        /*"    10 GEARDETA-NOM-ARQUIVO       PIC X(8).*/
        public StringBasis GEARDETA_NOM_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 GEARDETA-SEQ-GERACAO       PIC S9(9) USAGE COMP.*/
        public IntBasis GEARDETA_SEQ_GERACAO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GEARDETA-DTH-ANO-REFERENCIA       PIC S9(4) USAGE COMP.*/
        public IntBasis GEARDETA_DTH_ANO_REFERENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GEARDETA-DTH-MES-REFERENCIA       PIC S9(4) USAGE COMP.*/
        public IntBasis GEARDETA_DTH_MES_REFERENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GEARDETA-DTH-MOVIMENTO       PIC X(10).*/
        public StringBasis GEARDETA_DTH_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GEARDETA-DTH-GERACAO       PIC X(10).*/
        public StringBasis GEARDETA_DTH_GERACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GEARDETA-DTH-RECEPCAO       PIC X(10).*/
        public StringBasis GEARDETA_DTH_RECEPCAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GEARDETA-IND-MEIO-ENVIO       PIC X(1).*/
        public StringBasis GEARDETA_IND_MEIO_ENVIO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GEARDETA-STA-ENVIO-RECEPCAO       PIC X(1).*/
        public StringBasis GEARDETA_STA_ENVIO_RECEPCAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GEARDETA-COD-TIPO-ARQUIVO       PIC X(5).*/
        public StringBasis GEARDETA_COD_TIPO_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "5", "X(5)."), @"");
        /*"    10 GEARDETA-QTD-REG-PROCESSADO       PIC S9(9) USAGE COMP.*/
        public IntBasis GEARDETA_QTD_REG_PROCESSADO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GEARDETA-QTD-REG-REJEITADOS       PIC S9(9) USAGE COMP.*/
        public IntBasis GEARDETA_QTD_REG_REJEITADOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GEARDETA-QTD-REG-ACEITOS       PIC S9(9) USAGE COMP.*/
        public IntBasis GEARDETA_QTD_REG_ACEITOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GEARDETA-DTH-TIMESTAMP       PIC X(26).*/
        public StringBasis GEARDETA_DTH_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 GEARDETA-NOM-DATASET       PIC X(50).*/
        public StringBasis GEARDETA_NOM_DATASET { get; set; } = new StringBasis(new PIC("X", "50", "X(50)."), @"");
        /*"    10 GEARDETA-QTD-REG-INF       PIC S9(9) USAGE COMP.*/
        public IntBasis GEARDETA_QTD_REG_INF { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GEARDETA-IND-OPERACAO       PIC S9(4) USAGE COMP.*/
        public IntBasis GEARDETA_IND_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GEARDETA-COD-ULT-REGISTRO       PIC X(25).*/
        public StringBasis GEARDETA_COD_ULT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "25", "X(25)."), @"");
        /*"*/
    }
}