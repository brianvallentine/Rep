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
    public class VG084_DCLVG_COMPL_SICAQWEB : VarBasis
    {
        /*"    10 VG084-NUM-CERTIFICADO       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis VG084_NUM_CERTIFICADO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 VG084-COD-OPERADOR   PIC X(10).*/
        public StringBasis VG084_COD_OPERADOR { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VG084-NUM-CORRESP-CX-AQUI       PIC S9(9) USAGE COMP.*/
        public IntBasis VG084_NUM_CORRESP_CX_AQUI { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 VG084-IND-TP-CORRESP-SICAQ       PIC S9(4) USAGE COMP.*/
        public IntBasis VG084_IND_TP_CORRESP_SICAQ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG084-DTA-CONTRATACAO       PIC X(10).*/
        public StringBasis VG084_DTA_CONTRATACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VG084-HRA-CONTRATACAO       PIC X(8).*/
        public StringBasis VG084_HRA_CONTRATACAO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 VG084-NUM-PROPOSTA-SICAQ       PIC S9(9) USAGE COMP.*/
        public IntBasis VG084_NUM_PROPOSTA_SICAQ { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 VG084-IND-ORIGEM-PROPOSTA       PIC X(5).*/
        public StringBasis VG084_IND_ORIGEM_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "5", "X(5)."), @"");
        /*"    10 VG084-NOM-PROGRAMA   PIC X(8).*/
        public StringBasis VG084_NOM_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 VG084-DTH-CADASTRAMENTO       PIC X(26).*/
        public StringBasis VG084_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}