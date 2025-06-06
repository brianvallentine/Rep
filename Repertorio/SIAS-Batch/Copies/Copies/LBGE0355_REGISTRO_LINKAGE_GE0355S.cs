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
    public class LBGE0355_REGISTRO_LINKAGE_GE0355S : VarBasis
    {
        /*"  03   LK-GE355-IN-BANCO               PIC  9(003)*/
        public IntBasis LK_GE355_IN_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
        /*"  03   LK-GE355-IN-MOEDA               PIC  9(001)*/
        public IntBasis LK_GE355_IN_MOEDA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
        /*"  03   LK-GE355-IN-VLR-BOLETO          PIC  9(012)V99*/
        public DoubleBasis LK_GE355_IN_VLR_BOLETO { get; set; } = new DoubleBasis(new PIC("9", "12", "9(012)V99"), 2);
        /*"  03   LK-GE355-IN-NOSSO-NUMERO        PIC  9(018)*/
        public IntBasis LK_GE355_IN_NOSSO_NUMERO { get; set; } = new IntBasis(new PIC("9", "18", "9(018)"));
        /*"  03   LK-GE355-IN-DATA-VENCIMENTO     PIC  X(010)*/
        public StringBasis LK_GE355_IN_DATA_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"  03   LK-GE355-IN-COD-BENEFICIARIO    PIC  X(020)*/
        public StringBasis LK_GE355_IN_COD_BENEFICIARIO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
        /*"  03   LK-GE355-OUT-COD-BARRA          PIC  X(044)*/
        public StringBasis LK_GE355_OUT_COD_BARRA { get; set; } = new StringBasis(new PIC("X", "44", "X(044)"), @"");
        /*"  03   LK-GE355-OUT-DESENHO-BARRA      PIC  X(112)*/
        public StringBasis LK_GE355_OUT_DESENHO_BARRA { get; set; } = new StringBasis(new PIC("X", "112", "X(112)"), @"");
        /*"  03   LK-GE355-OUT-LINHA-DIGITAVEL    PIC  X(054)*/
        public StringBasis LK_GE355_OUT_LINHA_DIGITAVEL { get; set; } = new StringBasis(new PIC("X", "54", "X(054)"), @"");
        /*"  03   LK-GE355-OUT-FATOR-VENCIMENTO   PIC  9(004)*/
        public IntBasis LK_GE355_OUT_FATOR_VENCIMENTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"  03   LK-GE355-OUT-COD-RETORNO        PIC  X(001)*/
        public StringBasis LK_GE355_OUT_COD_RETORNO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"  03   LK-GE355-OUT-MENSAGEM*/
        public LBGE0355_LK_GE355_OUT_MENSAGEM LK_GE355_OUT_MENSAGEM { get; set; } = new LBGE0355_LK_GE355_OUT_MENSAGEM();

    }
}