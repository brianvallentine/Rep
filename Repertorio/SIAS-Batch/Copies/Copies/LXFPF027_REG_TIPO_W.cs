using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Copies
{
    public class LXFPF027_REG_TIPO_W : VarBasis
    {
        /*"      05  RSW-TIPO-REG            PIC X(001)*/
        public StringBasis RSW_TIPO_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"      05  RSW-NUM-PROPOSTA        PIC 9(014)*/
        public IntBasis RSW_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
        /*"      05  RSW-TIPO-PESSOA         PIC 9(002)*/
        public IntBasis RSW_TIPO_PESSOA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
        /*"      05  RSW-NUM-CPF-CNPJ        PIC 9(014)*/
        public IntBasis RSW_NUM_CPF_CNPJ { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
        /*"      05  RSW-NOM-RAZAO-SOCIAL    PIC X(030)*/
        public StringBasis RSW_NOM_RAZAO_SOCIAL { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
        /*"      05  RSW-VL-FATURA-ANUAL     PIC 9(010)*/
        public IntBasis RSW_VL_FATURA_ANUAL { get; set; } = new IntBasis(new PIC("9", "10", "9(010)"));
        /*"      05  RSW-TIPO-ENDERECO       PIC 9(001)*/
        public IntBasis RSW_TIPO_ENDERECO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
        /*"      05  RSW-ENDERECO            PIC X(050)*/
        public StringBasis RSW_ENDERECO { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"");
        /*"      05  RSW-BAIRRO              PIC X(030)*/
        public StringBasis RSW_BAIRRO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
        /*"      05  RSW-CIDADE              PIC X(035)*/
        public StringBasis RSW_CIDADE { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @"");
        /*"      05  RSW-UF                  PIC X(002)*/
        public StringBasis RSW_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
        /*"      05  RSW-CEP                 PIC 9(008)*/
        public IntBasis RSW_CEP { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"      05  RSW-INDIC-PEP           PIC X(001)*/
        public StringBasis RSW_INDIC_PEP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"      05  RSW-TIPO-PEP            PIC X(001)*/
        public StringBasis RSW_TIPO_PEP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"      05  RSW-DT-ENQUAD-PEP       PIC X(008)*/
        public StringBasis RSW_DT_ENQUAD_PEP { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"      05  RSW-VINCULO             PIC X(002)*/
        public StringBasis RSW_VINCULO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
        /*"      05  RSW-PARTIC-SOCIETARIA   PIC 9(003)*/
        public IntBasis RSW_PARTIC_SOCIETARIA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
        /*"      05  RSW-ORIGEM-RECURSOS     PIC 9(002)*/
        public IntBasis RSW_ORIGEM_RECURSOS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
        /*"      05  RSW-DESC-ORIG-RECURSOS  PIC X(030)*/
        public StringBasis RSW_DESC_ORIG_RECURSOS { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
        /*"      05  RSW-TIPO-VINCULO        PIC X(002)*/
        public StringBasis RSW_TIPO_VINCULO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
        /*"      05  RSW-FILLER              PIC X(054)*/
        public StringBasis RSW_FILLER { get; set; } = new StringBasis(new PIC("X", "54", "X(054)"), @"");
        /*"*/
    }
}