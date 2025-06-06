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
    public class VG143_DCLVG_DPS_PROPOSTA : VarBasis
    {
        /*"    10 VG143-NUM-PROPOSTA   PIC S9(18) USAGE COMP.*/
        public IntBasis VG143_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 VG143-NUM-CPF-CNPJ   PIC S9(18) USAGE COMP.*/
        public IntBasis VG143_NUM_CPF_CNPJ { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 VG143-SEQ-PRODUTO-DPS       PIC S9(9) USAGE COMP.*/
        public IntBasis VG143_SEQ_PRODUTO_DPS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 VG143-STA-DPS-PROPOSTA       PIC S9(4) USAGE COMP.*/
        public IntBasis VG143_STA_DPS_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG143-IND-TP-PESSOA  PIC X(1).*/
        public StringBasis VG143_IND_TP_PESSOA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 VG143-IND-TP-SEGURADO       PIC X(1).*/
        public StringBasis VG143_IND_TP_SEGURADO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 VG143-NUM-CERTIFICADO       PIC S9(18) USAGE COMP.*/
        public IntBasis VG143_NUM_CERTIFICADO { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 VG143-VLR-IS         PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis VG143_VLR_IS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 VG143-VLR-ACUMULO-IS       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis VG143_VLR_ACUMULO_IS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 VG143-COD-USUARIO    PIC X(8).*/
        public StringBasis VG143_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 VG143-NOM-PROGRAMA   PIC X(10).*/
        public StringBasis VG143_NOM_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VG143-DTH-CADASTRAMENTO       PIC X(26).*/
        public StringBasis VG143_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}