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
    public class VG136_DCLVG_ACOPLADO_TITULO : VarBasis
    {
        /*"    10 VG136-IDE-SISTEMA    PIC X(2).*/
        public StringBasis VG136_IDE_SISTEMA { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 VG136-NUM-CERTIFICADO       PIC S9(18) USAGE COMP.*/
        public IntBasis VG136_NUM_CERTIFICADO { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 VG136-COD-PRODUTO    PIC S9(4) USAGE COMP.*/
        public IntBasis VG136_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG136-COD-PLANO      PIC S9(4) USAGE COMP.*/
        public IntBasis VG136_COD_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG136-NUM-SERIE      PIC S9(4) USAGE COMP.*/
        public IntBasis VG136_NUM_SERIE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG136-NUM-TITULO     PIC S9(9) USAGE COMP.*/
        public IntBasis VG136_NUM_TITULO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 VG136-STA-TITULO     PIC X(3).*/
        public StringBasis VG136_STA_TITULO { get; set; } = new StringBasis(new PIC("X", "3", "X(3)."), @"");
        /*"    10 VG136-COD-SUB-TITULO       PIC X(3).*/
        public StringBasis VG136_COD_SUB_TITULO { get; set; } = new StringBasis(new PIC("X", "3", "X(3)."), @"");
        /*"    10 VG136-DTA-INI-VIGENCIA       PIC X(10).*/
        public StringBasis VG136_DTA_INI_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VG136-DTA-FIM-VIGENCIA       PIC X(10).*/
        public StringBasis VG136_DTA_FIM_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VG136-DTH-CRIACAO    PIC X(26).*/
        public StringBasis VG136_DTH_CRIACAO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 VG136-DTA-INI-SORTEIO       PIC X(10).*/
        public StringBasis VG136_DTA_INI_SORTEIO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VG136-DTH-ATIVACAO   PIC X(26).*/
        public StringBasis VG136_DTH_ATIVACAO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 VG136-DTA-SUSPENSAO  PIC X(10).*/
        public StringBasis VG136_DTA_SUSPENSAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VG136-DTA-CADUCACAO  PIC X(10).*/
        public StringBasis VG136_DTA_CADUCACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VG136-COD-DV         PIC S9(4) USAGE COMP.*/
        public IntBasis VG136_COD_DV { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG136-VLR-MENSALIDADE       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis VG136_VLR_MENSALIDADE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 VG136-NUM-MOD-PLANO  PIC S9(4) USAGE COMP.*/
        public IntBasis VG136_NUM_MOD_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG136-DES-COMBINACAO       PIC X(20).*/
        public StringBasis VG136_DES_COMBINACAO { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        /*"    10 VG136-COD-USUARIO    PIC X(8).*/
        public StringBasis VG136_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 VG136-NOM-PROGRAMA   PIC X(10).*/
        public StringBasis VG136_NOM_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VG136-DTH-CADASTRAMENTO       PIC X(26).*/
        public StringBasis VG136_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}