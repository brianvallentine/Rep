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
    public class VG097_DCLVG_ACOPLADO_PRESTAMISTA : VarBasis
    {
        /*"    10 VG097-NUM-CERTIFICADO       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis VG097_NUM_CERTIFICADO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 VG097-COD-PRODUTO    PIC S9(4) USAGE COMP.*/
        public IntBasis VG097_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG097-COD-ACOPLADO   PIC S9(4) USAGE COMP.*/
        public IntBasis VG097_COD_ACOPLADO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG097-NUM-ARQ-PROPOSTA       PIC S9(9) USAGE COMP.*/
        public IntBasis VG097_NUM_ARQ_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 VG097-DES-ACOPLADO   PIC X(60).*/
        public StringBasis VG097_DES_ACOPLADO { get; set; } = new StringBasis(new PIC("X", "60", "X(60)."), @"");
        /*"    10 VG097-DTA-INI-VIGENCIA       PIC X(10).*/
        public StringBasis VG097_DTA_INI_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VG097-DTA-FIM-VIGENCIA       PIC X(10).*/
        public StringBasis VG097_DTA_FIM_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VG097-STA-REGISTRO   PIC X(1).*/
        public StringBasis VG097_STA_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 VG097-NOM-PROGRAMA   PIC X(10).*/
        public StringBasis VG097_NOM_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VG097-DTH-ATUALIZACAO       PIC X(26).*/
        public StringBasis VG097_DTH_ATUALIZACAO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}