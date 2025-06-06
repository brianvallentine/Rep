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
    public class VG094_DCLVG_CARENCIA_MSG : VarBasis
    {
        /*"    10 VG094-SEQ-CARENCIA-MSG       PIC S9(9) USAGE COMP.*/
        public IntBasis VG094_SEQ_CARENCIA_MSG { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 VG094-IND-TIPO-MSG   PIC X(1).*/
        public StringBasis VG094_IND_TIPO_MSG { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 VG094-DES-CARENCIA-MSG.*/
        public VG094_VG094_DES_CARENCIA_MSG VG094_DES_CARENCIA_MSG { get; set; } = new VG094_VG094_DES_CARENCIA_MSG();

        public StringBasis VG094_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 VG094-DTH-ATUALIZACAO       PIC X(26).*/
        public StringBasis VG094_DTH_ATUALIZACAO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}