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
    public class FAIXASAL_DCLFAIXA_SALARIAL : VarBasis
    {
        /*"    10 FAIXASAL-NUM-APOLICE  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis FAIXASAL_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 FAIXASAL-COD-SUBGRUPO  PIC S9(4) USAGE COMP.*/
        public IntBasis FAIXASAL_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FAIXASAL-FAIXA       PIC S9(4) USAGE COMP.*/
        public IntBasis FAIXASAL_FAIXA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FAIXASAL-SALARIO-INICIAL  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis FAIXASAL_SALARIO_INICIAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 FAIXASAL-SALARIO-FINAL  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis FAIXASAL_SALARIO_FINAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 FAIXASAL-TAXA-VG     PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis FAIXASAL_TAXA_VG { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 FAIXASAL-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis FAIXASAL_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"*/
    }
}