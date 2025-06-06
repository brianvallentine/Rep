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
    public class VG080_DCLVG_PARAM_RAMO_CONJ : VarBasis
    {
        /*"    10 VG080-NUM-APOLICE    PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis VG080_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 VG080-COD-SUBGRUPO   PIC S9(4) USAGE COMP.*/
        public IntBasis VG080_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG080-COD-GRUPO-SUSEP       PIC S9(4) USAGE COMP.*/
        public IntBasis VG080_COD_GRUPO_SUSEP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG080-RAMO-EMISSOR   PIC S9(4) USAGE COMP.*/
        public IntBasis VG080_RAMO_EMISSOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG080-COD-MODALIDADE       PIC S9(4) USAGE COMP.*/
        public IntBasis VG080_COD_MODALIDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG080-DTH-INI-VIGENCIA       PIC X(10).*/
        public StringBasis VG080_DTH_INI_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VG080-DTH-TER-VIGENCIA       PIC X(10).*/
        public StringBasis VG080_DTH_TER_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VG080-VLR-FATOR-RAMO       PIC S9(2)V9(5) USAGE COMP-3.*/
        public DoubleBasis VG080_VLR_FATOR_RAMO { get; set; } = new DoubleBasis(new PIC("S9", "2", "S9(2)V9(5)"), 5);
        /*"    10 VG080-COD-USUARIO    PIC X(8).*/
        public StringBasis VG080_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 VG080-DTH-ATUALIZACAO       PIC X(26).*/
        public StringBasis VG080_DTH_ATUALIZACAO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}