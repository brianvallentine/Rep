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
    public class VG130_DCLVG_PLANO_SUBGRUPO : VarBasis
    {
        /*"    10 VG130-COD-EMPRESA-SIVPF       PIC S9(4) USAGE COMP.*/
        public IntBasis VG130_COD_EMPRESA_SIVPF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG130-COD-PRODUTO-SIVPF       PIC S9(4) USAGE COMP.*/
        public IntBasis VG130_COD_PRODUTO_SIVPF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG130-COD-PRODUTO    PIC S9(4) USAGE COMP.*/
        public IntBasis VG130_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG130-COD-OPCAO-COBER       PIC X(1).*/
        public StringBasis VG130_COD_OPCAO_COBER { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 VG130-IND-PERIOD-PGTO       PIC S9(4) USAGE COMP.*/
        public IntBasis VG130_IND_PERIOD_PGTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG130-IND-OPCAO-CONJUGE       PIC X(1).*/
        public StringBasis VG130_IND_OPCAO_CONJUGE { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 VG130-COD-TIPO-ASSISTENCIA       PIC S9(4) USAGE COMP.*/
        public IntBasis VG130_COD_TIPO_ASSISTENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG130-NUM-APOLICE    PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis VG130_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 VG130-COD-SUBGRUPO   PIC S9(4) USAGE COMP.*/
        public IntBasis VG130_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG130-DTA-INI-VIGENCIA       PIC X(10).*/
        public StringBasis VG130_DTA_INI_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VG130-DTA-FIM-VIGENCIA       PIC X(10).*/
        public StringBasis VG130_DTA_FIM_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VG130-STA-REGISTRO   PIC X(1).*/
        public StringBasis VG130_STA_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 VG130-COD-USUARIO    PIC X(8).*/
        public StringBasis VG130_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 VG130-DTH-CADASTRAMENTO       PIC X(26).*/
        public StringBasis VG130_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 VG130-DTH-ATUALIZACAO       PIC X(26).*/
        public StringBasis VG130_DTH_ATUALIZACAO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
    }
}