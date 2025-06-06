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
    public class VG081_DCLVG_PARAM_RAMO_COMP : VarBasis
    {
        /*"    10 VG081-NUM-APOLICE    PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis VG081_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 VG081-COD-SUBGRUPO   PIC S9(4) USAGE COMP.*/
        public IntBasis VG081_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG081-COD-GRUPO-SUSEP       PIC S9(4) USAGE COMP.*/
        public IntBasis VG081_COD_GRUPO_SUSEP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG081-RAMO-EMISSOR   PIC S9(4) USAGE COMP.*/
        public IntBasis VG081_RAMO_EMISSOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG081-COD-MODALIDADE       PIC S9(4) USAGE COMP.*/
        public IntBasis VG081_COD_MODALIDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG081-DTH-INI-VIGENCIA       PIC X(10).*/
        public StringBasis VG081_DTH_INI_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VG081-COD-OPCAO-COBERTURA       PIC X(1).*/
        public StringBasis VG081_COD_OPCAO_COBERTURA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 VG081-NUM-IDADE-INICIAL       PIC S9(4) USAGE COMP.*/
        public IntBasis VG081_NUM_IDADE_INICIAL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG081-NUM-IDADE-FINAL       PIC S9(4) USAGE COMP.*/
        public IntBasis VG081_NUM_IDADE_FINAL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG081-VLR-PERC-PREMIO       PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis VG081_VLR_PERC_PREMIO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 VG081-COD-USUARIO    PIC X(8).*/
        public StringBasis VG081_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 VG081-DTH-ATUALIZACAO       PIC X(26).*/
        public StringBasis VG081_DTH_ATUALIZACAO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}