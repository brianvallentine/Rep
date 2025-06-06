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
    public class VG139_DCLVG_ACOPLADO_ERRO : VarBasis
    {
        /*"    10 VG139-IDE-SISTEMA    PIC X(2).*/
        public StringBasis VG139_IDE_SISTEMA { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 VG139-NUM-CERTIFICADO       PIC S9(18) USAGE COMP.*/
        public IntBasis VG139_NUM_CERTIFICADO { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 VG139-COD-PRODUTO    PIC S9(4) USAGE COMP.*/
        public IntBasis VG139_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG139-COD-PLANO      PIC S9(4) USAGE COMP.*/
        public IntBasis VG139_COD_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG139-SEQ-ERRO       PIC S9(4) USAGE COMP.*/
        public IntBasis VG139_SEQ_ERRO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG139-COD-SQLCODE    PIC S9(4) USAGE COMP.*/
        public IntBasis VG139_COD_SQLCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG139-COD-ERRO       PIC S9(9) USAGE COMP.*/
        public IntBasis VG139_COD_ERRO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 VG139-DES-ERRO.*/
        public VG139_VG139_DES_ERRO VG139_DES_ERRO { get; set; } = new VG139_VG139_DES_ERRO();

        public VG139_VG139_DES_ACAO VG139_DES_ACAO { get; set; } = new VG139_VG139_DES_ACAO();

        public StringBasis VG139_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 VG139-NOM-PROGRAMA   PIC X(10).*/
        public StringBasis VG139_NOM_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VG139-DTH-CADASTRAMENTO       PIC X(26).*/
        public StringBasis VG139_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}