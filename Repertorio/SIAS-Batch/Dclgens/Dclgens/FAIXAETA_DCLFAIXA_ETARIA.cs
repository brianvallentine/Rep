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
    public class FAIXAETA_DCLFAIXA_ETARIA : VarBasis
    {
        /*"    10 FAIXAETA-NUM-APOLICE  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis FAIXAETA_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 FAIXAETA-COD-SUBGRUPO  PIC S9(4) USAGE COMP.*/
        public IntBasis FAIXAETA_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FAIXAETA-FAIXA       PIC S9(4) USAGE COMP.*/
        public IntBasis FAIXAETA_FAIXA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FAIXAETA-IDADE-INICIAL  PIC S9(4) USAGE COMP.*/
        public IntBasis FAIXAETA_IDADE_INICIAL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FAIXAETA-IDADE-FINAL  PIC S9(4) USAGE COMP.*/
        public IntBasis FAIXAETA_IDADE_FINAL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FAIXAETA-TAXA-VG     PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis FAIXAETA_TAXA_VG { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 FAIXAETA-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis FAIXAETA_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FAIXAETA-DATA-INIVIGENCIA  PIC X(10).*/
        public StringBasis FAIXAETA_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 FAIXAETA-DATA-TERVIGENCIA  PIC X(10).*/
        public StringBasis FAIXAETA_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"*/
    }
}