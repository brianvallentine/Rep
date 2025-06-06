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
    public class VG104_DCLVG_CRITICA_PROPOSTA_HIST : VarBasis
    {
        /*"    10 VG104-NUM-CERTIFICADO       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis VG104_NUM_CERTIFICADO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 VG104-SEQ-CRITICA    PIC S9(4) USAGE COMP.*/
        public IntBasis VG104_SEQ_CRITICA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG104-DTH-CADASTRAMENTO       PIC X(26).*/
        public StringBasis VG104_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 VG104-IND-TP-PROPOSTA       PIC X(2).*/
        public StringBasis VG104_IND_TP_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 VG104-COD-MSG-CRITICA       PIC S9(4) USAGE COMP.*/
        public IntBasis VG104_COD_MSG_CRITICA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG104-NUM-CPF-CNPJ   PIC S9(18) USAGE COMP.*/
        public IntBasis VG104_NUM_CPF_CNPJ { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 VG104-NUM-PROPOSTA   PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis VG104_NUM_PROPOSTA { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 VG104-VLR-IS         PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis VG104_VLR_IS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 VG104-VLR-PREMIO     PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis VG104_VLR_PREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 VG104-DTA-OCORRENCIA       PIC X(10).*/
        public StringBasis VG104_DTA_OCORRENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VG104-DTA-RCAP       PIC X(10).*/
        public StringBasis VG104_DTA_RCAP { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VG104-STA-CRITICA    PIC X(1).*/
        public StringBasis VG104_STA_CRITICA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 VG104-DES-COMPLEMENTAR.*/
        public VG104_VG104_DES_COMPLEMENTAR VG104_DES_COMPLEMENTAR { get; set; } = new VG104_VG104_DES_COMPLEMENTAR();

        public StringBasis VG104_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 VG104-NOM-PROGRAMA   PIC X(10).*/
        public StringBasis VG104_NOM_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"*/
    }
}