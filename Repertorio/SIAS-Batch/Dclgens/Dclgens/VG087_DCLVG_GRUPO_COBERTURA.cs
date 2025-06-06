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
    public class VG087_DCLVG_GRUPO_COBERTURA : VarBasis
    {
        /*"    10 VG087-SEQ-GRUPO-COBERTURA       PIC S9(9) USAGE COMP.*/
        public IntBasis VG087_SEQ_GRUPO_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 VG087-NOM-GRUPO-COBERTURA       PIC X(100).*/
        public StringBasis VG087_NOM_GRUPO_COBERTURA { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");
        /*"    10 VG087-DES-GRUPO-COBERTURA.*/
        public VG087_VG087_DES_GRUPO_COBERTURA VG087_DES_GRUPO_COBERTURA { get; set; } = new VG087_VG087_DES_GRUPO_COBERTURA();

        public StringBasis VG087_IND_CONJUGE { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 VG087-COD-USUARIO    PIC X(10).*/
        public StringBasis VG087_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VG087-DTH-ATUALIZACAO       PIC X(26).*/
        public StringBasis VG087_DTH_ATUALIZACAO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}