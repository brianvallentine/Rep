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
    public class VG096_DCLVG_MOVTO_PRESTAMISTA : VarBasis
    {
        /*"    10 VG096-NUM-CERTIFICADO       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis VG096_NUM_CERTIFICADO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 VG096-NUM-PARCELA    PIC S9(4) USAGE COMP.*/
        public IntBasis VG096_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG096-DTA-VENCIMENTO       PIC X(10).*/
        public StringBasis VG096_DTA_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VG096-VLR-PARCELA    PIC S9(11)V9(2) USAGE COMP-3.*/
        public DoubleBasis VG096_VLR_PARCELA { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(11)V9(2)"), 2);
        /*"    10 VG096-STA-REGISTRO   PIC X(1).*/
        public StringBasis VG096_STA_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 VG096-COD-IDLG       PIC X(40).*/
        public StringBasis VG096_COD_IDLG { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 VG096-COD-RETORNO    PIC S9(4) USAGE COMP.*/
        public IntBasis VG096_COD_RETORNO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG096-DES-RETORNO    PIC X(60).*/
        public StringBasis VG096_DES_RETORNO { get; set; } = new StringBasis(new PIC("X", "60", "X(60)."), @"");
        /*"    10 VG096-COD-CONVENIO   PIC S9(4) USAGE COMP.*/
        public IntBasis VG096_COD_CONVENIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG096-NUM-BANCO-DEBITO       PIC S9(4) USAGE COMP.*/
        public IntBasis VG096_NUM_BANCO_DEBITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG096-NUM-AGENCIA-DEBITO       PIC S9(4) USAGE COMP.*/
        public IntBasis VG096_NUM_AGENCIA_DEBITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG096-NUM-CONTA-DEBITO       PIC S9(9) USAGE COMP.*/
        public IntBasis VG096_NUM_CONTA_DEBITO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 VG096-NOM-PROGRAMA   PIC X(10).*/
        public StringBasis VG096_NOM_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VG096-DTH-ATUALIZACAO       PIC X(26).*/
        public StringBasis VG096_DTH_ATUALIZACAO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 VG096-DTA-PROXIMA-COBRANCA       PIC X(10).*/
        public StringBasis VG096_DTA_PROXIMA_COBRANCA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VG096-DTA-ENVIO-RELATORIO       PIC X(10).*/
        public StringBasis VG096_DTA_ENVIO_RELATORIO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"*/
    }
}