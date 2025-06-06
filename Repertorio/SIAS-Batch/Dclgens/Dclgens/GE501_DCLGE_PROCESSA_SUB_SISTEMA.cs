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
    public class GE501_DCLGE_PROCESSA_SUB_SISTEMA : VarBasis
    {
        /*"    10 GE501-COD-IDE-SISTEMA       PIC X(2).*/
        public StringBasis GE501_COD_IDE_SISTEMA { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 GE501-COD-SUB-SISTEMA       PIC X(2).*/
        public StringBasis GE501_COD_SUB_SISTEMA { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 GE501-DES-SUB-SISTEMA       PIC X(100).*/
        public StringBasis GE501_DES_SUB_SISTEMA { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");
        /*"    10 GE501-IND-DISPONIBILIDADE       PIC X(1).*/
        public StringBasis GE501_IND_DISPONIBILIDADE { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GE501-DTA-MOV-ABERTO       PIC X(10).*/
        public StringBasis GE501_DTA_MOV_ABERTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE501-DTA-ULT-MOV-ABERTO       PIC X(10).*/
        public StringBasis GE501_DTA_ULT_MOV_ABERTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE501-DTA-PROX-MOV-ABERTO       PIC X(10).*/
        public StringBasis GE501_DTA_PROX_MOV_ABERTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE501-COD-USUARIO    PIC X(8).*/
        public StringBasis GE501_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 GE501-NOM-PROGRAMA   PIC X(30).*/
        public StringBasis GE501_NOM_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
        /*"    10 GE501-DTH-CADASTRAMENTO       PIC X(26).*/
        public StringBasis GE501_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 GE501-IND-ONLINE     PIC X(1).*/
        public StringBasis GE501_IND_ONLINE { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"*/
    }
}