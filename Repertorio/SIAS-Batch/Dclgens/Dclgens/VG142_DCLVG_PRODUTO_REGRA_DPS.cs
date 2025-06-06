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
    public class VG142_DCLVG_PRODUTO_REGRA_DPS : VarBasis
    {
        /*"    10 VG142-SEQ-PRODUTO-DPS       PIC S9(9) USAGE COMP.*/
        public IntBasis VG142_SEQ_PRODUTO_DPS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 VG142-COD-PRODUTO    PIC S9(4) USAGE COMP.*/
        public IntBasis VG142_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG142-SEQ-DPS-REGRA  PIC S9(9) USAGE COMP.*/
        public IntBasis VG142_SEQ_DPS_REGRA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 VG142-SEQ-EMPRESA-DPS       PIC S9(9) USAGE COMP.*/
        public IntBasis VG142_SEQ_EMPRESA_DPS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 VG142-DTA-INI-VIGENCIA       PIC X(10).*/
        public StringBasis VG142_DTA_INI_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VG142-DTA-FIM-VIGENCIA       PIC X(10).*/
        public StringBasis VG142_DTA_FIM_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VG142-COD-USUARIO    PIC X(8).*/
        public StringBasis VG142_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 VG142-NOM-PROGRAMA   PIC X(10).*/
        public StringBasis VG142_NOM_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VG142-DTH-CADASTRAMENTO       PIC X(26).*/
        public StringBasis VG142_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}