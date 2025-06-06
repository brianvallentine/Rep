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
    public class VG091_DCLVG_APOLICE_COB_GAR : VarBasis
    {
        /*"    10 VG091-NUM-APOLICE    PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis VG091_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 VG091-COD-SUBGRUPO   PIC S9(4) USAGE COMP.*/
        public IntBasis VG091_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG091-COD-PRODUTO    PIC S9(4) USAGE COMP.*/
        public IntBasis VG091_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG091-SEQ-GRUPO-COBERTURA       PIC S9(9) USAGE COMP.*/
        public IntBasis VG091_SEQ_GRUPO_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 VG091-NUM-GARANTIA   PIC S9(4) USAGE COMP.*/
        public IntBasis VG091_NUM_GARANTIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG091-DTA-INI-VIGENCIA-GAR       PIC X(10).*/
        public StringBasis VG091_DTA_INI_VIGENCIA_GAR { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VG091-IND-TIPO-COB-GAR       PIC X(2).*/
        public StringBasis VG091_IND_TIPO_COB_GAR { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 VG091-IND-PERIODO-FAT       PIC S9(4) USAGE COMP.*/
        public IntBasis VG091_IND_PERIODO_FAT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG091-COD-USUARIO    PIC X(10).*/
        public StringBasis VG091_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VG091-DTA-INI-VIGENCIA       PIC X(10).*/
        public StringBasis VG091_DTA_INI_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VG091-DTA-FIM-VIGENCIA       PIC X(10).*/
        public StringBasis VG091_DTA_FIM_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VG091-DTH-ATUALIZACAO       PIC X(26).*/
        public StringBasis VG091_DTH_ATUALIZACAO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 VG091-SEQ-CARENCIA   PIC S9(9) USAGE COMP.*/
        public IntBasis VG091_SEQ_CARENCIA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 VG091-SEQ-MSG-HINT   PIC S9(9) USAGE COMP.*/
        public IntBasis VG091_SEQ_MSG_HINT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"*/
    }
}