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
    public class VG088_DCLVG_GRUPO_COB_CS_ETARIA : VarBasis
    {
        /*"    10 VG088-SEQ-GRUPO-COBERTURA       PIC S9(9) USAGE COMP.*/
        public IntBasis VG088_SEQ_GRUPO_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 VG088-NUM-GARANTIA   PIC S9(4) USAGE COMP.*/
        public IntBasis VG088_NUM_GARANTIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG088-DTA-INI-VIGENCIA-GAR       PIC X(10).*/
        public StringBasis VG088_DTA_INI_VIGENCIA_GAR { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VG088-SEQ-FAIXA-CAP-SEGUR       PIC S9(4) USAGE COMP.*/
        public IntBasis VG088_SEQ_FAIXA_CAP_SEGUR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG088-SEQ-FAIXA-ETARIA       PIC S9(4) USAGE COMP.*/
        public IntBasis VG088_SEQ_FAIXA_ETARIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG088-DTA-INI-VIGENCIA       PIC X(10).*/
        public StringBasis VG088_DTA_INI_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VG088-PCT-COB-PREMIO       PIC S9(3)V9(5) USAGE COMP-3.*/
        public DoubleBasis VG088_PCT_COB_PREMIO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(5)"), 5);
        /*"    10 VG088-DTA-INI-VIGENCIA-GRUPO       PIC X(10).*/
        public StringBasis VG088_DTA_INI_VIGENCIA_GRUPO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VG088-DTA-FIM-VIGENCIA-GRUPO       PIC X(10).*/
        public StringBasis VG088_DTA_FIM_VIGENCIA_GRUPO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VG088-COD-USUARIO    PIC X(10).*/
        public StringBasis VG088_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VG088-DTH-ATUALIZACAO       PIC X(26).*/
        public StringBasis VG088_DTH_ATUALIZACAO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}