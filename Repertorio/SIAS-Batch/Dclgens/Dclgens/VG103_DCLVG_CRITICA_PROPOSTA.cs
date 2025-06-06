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
    public class VG103_DCLVG_CRITICA_PROPOSTA : VarBasis
    {
        /*"    10 VG103-NUM-CERTIFICADO       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis VG103_NUM_CERTIFICADO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 VG103-SEQ-CRITICA    PIC S9(4) USAGE COMP.*/
        public IntBasis VG103_SEQ_CRITICA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG103-IND-TP-PROPOSTA       PIC X(2).*/
        public StringBasis VG103_IND_TP_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 VG103-COD-MSG-CRITICA       PIC S9(4) USAGE COMP.*/
        public IntBasis VG103_COD_MSG_CRITICA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG103-NUM-CPF-CNPJ   PIC S9(18) USAGE COMP.*/
        public IntBasis VG103_NUM_CPF_CNPJ { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 VG103-NUM-PROPOSTA   PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis VG103_NUM_PROPOSTA { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 VG103-VLR-IS         PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis VG103_VLR_IS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 VG103-VLR-PREMIO     PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis VG103_VLR_PREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 VG103-DTA-OCORRENCIA       PIC X(10).*/
        public StringBasis VG103_DTA_OCORRENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VG103-DTA-RCAP       PIC X(10).*/
        public StringBasis VG103_DTA_RCAP { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VG103-STA-CRITICA    PIC X(1).*/
        public StringBasis VG103_STA_CRITICA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 VG103-DES-COMPLEMENTAR.*/
        public VG103_VG103_DES_COMPLEMENTAR VG103_DES_COMPLEMENTAR { get; set; } = new VG103_VG103_DES_COMPLEMENTAR();

        public StringBasis VG103_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 VG103-NOM-PROGRAMA   PIC X(10).*/
        public StringBasis VG103_NOM_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VG103-DTH-CADASTRAMENTO       PIC X(26).*/
        public StringBasis VG103_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}