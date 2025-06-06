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
    public class GE637_DCLGE_PESSOA_PEPS : VarBasis
    {
        /*"    10 GE637-SEQ-PEPS       PIC S9(9) USAGE COMP.*/
        public IntBasis GE637_SEQ_PEPS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE637-IND-TIPO-REGISTRO       PIC X(1).*/
        public StringBasis GE637_IND_TIPO_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GE637-COD-PESSOA-PEP       PIC S9(9) USAGE COMP.*/
        public IntBasis GE637_COD_PESSOA_PEP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE637-NUM-CPF-CNPJ   PIC S9(18) USAGE COMP.*/
        public IntBasis GE637_NUM_CPF_CNPJ { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 GE637-IND-TP-PESSOA  PIC X(1).*/
        public StringBasis GE637_IND_TP_PESSOA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GE637-NOM-PESSOA     PIC X(60).*/
        public StringBasis GE637_NOM_PESSOA { get; set; } = new StringBasis(new PIC("X", "60", "X(60)."), @"");
        /*"    10 GE637-NOM-ORGAO-PUB  PIC X(40).*/
        public StringBasis GE637_NOM_ORGAO_PUB { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 GE637-NOM-CARGO      PIC X(30).*/
        public StringBasis GE637_NOM_CARGO { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
        /*"    10 GE637-COD-PESSOA-PEP-RELAC       PIC S9(9) USAGE COMP.*/
        public IntBasis GE637_COD_PESSOA_PEP_RELAC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE637-DTA-INI-VIG    PIC X(10).*/
        public StringBasis GE637_DTA_INI_VIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE637-DTA-FIM-VIG    PIC X(10).*/
        public StringBasis GE637_DTA_FIM_VIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE637-NOM-TIT-RELAC  PIC X(60).*/
        public StringBasis GE637_NOM_TIT_RELAC { get; set; } = new StringBasis(new PIC("X", "60", "X(60)."), @"");
        /*"    10 GE637-DTH-CADASTRAMENTO       PIC X(26).*/
        public StringBasis GE637_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}