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
    public class CEPFXFIL_DCLCEPFAIXAFILIAL : VarBasis
    {
        /*"    10 CEPFXFIL-FONTE       PIC S9(4) USAGE COMP.*/
        public IntBasis CEPFXFIL_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CEPFXFIL-DATA-INI-VIGENCIA  PIC X(10).*/
        public StringBasis CEPFXFIL_DATA_INI_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 CEPFXFIL-DATA-TER-VIGENCIA  PIC X(10).*/
        public StringBasis CEPFXFIL_DATA_TER_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 CEPFXFIL-SEQ-FAIXA   PIC S9(9) USAGE COMP.*/
        public IntBasis CEPFXFIL_SEQ_FAIXA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 CEPFXFIL-COD-EMPRESA  PIC S9(4) USAGE COMP.*/
        public IntBasis CEPFXFIL_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CEPFXFIL-CEP-INICIAL  PIC S9(9) USAGE COMP.*/
        public IntBasis CEPFXFIL_CEP_INICIAL { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 CEPFXFIL-CEP-FINAL   PIC S9(9) USAGE COMP.*/
        public IntBasis CEPFXFIL_CEP_FINAL { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 CEPFXFIL-TIMESTAMP   PIC X(26).*/
        public StringBasis CEPFXFIL_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}