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
    public class VG133_DCLVG_ESTIPULANTE_VINCULO : VarBasis
    {
        /*"    10 VG133-NUM-APOLICE    PIC S9(18) USAGE COMP.*/
        public IntBasis VG133_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 VG133-COD-SUBGRUPO   PIC S9(4) USAGE COMP.*/
        public IntBasis VG133_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG133-NUM-CNPJ       PIC S9(18) USAGE COMP.*/
        public IntBasis VG133_NUM_CNPJ { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 VG133-SEQ-ESTIP-VINC       PIC S9(4) USAGE COMP.*/
        public IntBasis VG133_SEQ_ESTIP_VINC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG133-STA-ATIVO      PIC X(1).*/
        public StringBasis VG133_STA_ATIVO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 VG133-COD-USUARIO    PIC X(8).*/
        public StringBasis VG133_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 VG133-NOM-PROGRAMA   PIC X(10).*/
        public StringBasis VG133_NOM_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VG133-DTH-CADASTRAMENTO       PIC X(26).*/
        public StringBasis VG133_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 VG133-DTH-ATUALIZACAO       PIC X(26).*/
        public StringBasis VG133_DTH_ATUALIZACAO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
    }
}