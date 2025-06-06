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
    public class SITRATEM_DCLSI_TRAB_TEMP01 : VarBasis
    {
        /*"    10 SITRATEM-DTH-ANO-REFERENCIA  PIC S9(4) USAGE COMP.*/
        public IntBasis SITRATEM_DTH_ANO_REFERENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SITRATEM-DTH-MES-REFERENCIA  PIC S9(4) USAGE COMP.*/
        public IntBasis SITRATEM_DTH_MES_REFERENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SITRATEM-DTH-SEMANA-REF  PIC S9(4) USAGE COMP.*/
        public IntBasis SITRATEM_DTH_SEMANA_REF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SITRATEM-DTH-MOVIMENTO  PIC X(10).*/
        public StringBasis SITRATEM_DTH_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SITRATEM-NUM-APOLICE  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis SITRATEM_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 SITRATEM-COD-FONTE   PIC S9(4) USAGE COMP.*/
        public IntBasis SITRATEM_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SITRATEM-COD-PRODUTO  PIC S9(4) USAGE COMP.*/
        public IntBasis SITRATEM_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SITRATEM-RAMO        PIC S9(4) USAGE COMP.*/
        public IntBasis SITRATEM_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SITRATEM-GRUPO-CAUSAS  PIC X(20).*/
        public StringBasis SITRATEM_GRUPO_CAUSAS { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        /*"    10 SITRATEM-QTD-SIN-AVISADOS  PIC S9(9) USAGE COMP.*/
        public IntBasis SITRATEM_QTD_SIN_AVISADOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SITRATEM-VLR-SIN-AVISADOS  PIC S9(11)V9(2) USAGE COMP-3.*/
        public DoubleBasis SITRATEM_VLR_SIN_AVISADOS { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(11)V9(2)"), 2);
        /*"    10 SITRATEM-QTD-SIN-PAGOS  PIC S9(9) USAGE COMP.*/
        public IntBasis SITRATEM_QTD_SIN_PAGOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SITRATEM-VLR-SIN-PAGOS  PIC S9(11)V9(2) USAGE COMP-3.*/
        public DoubleBasis SITRATEM_VLR_SIN_PAGOS { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(11)V9(2)"), 2);
        /*"    10 SITRATEM-QTD-SIN-CANCELADOS  PIC S9(9) USAGE COMP.*/
        public IntBasis SITRATEM_QTD_SIN_CANCELADOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SITRATEM-VLR-SIN-CANCELADOS  PIC S9(11)V9(2) USAGE COMP-3*/
        public DoubleBasis SITRATEM_VLR_SIN_CANCELADOS { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(11)V9(2)"), 2);
        /*"    10 SITRATEM-QTD-SIN-PENDENTE  PIC S9(9) USAGE COMP.*/
        public IntBasis SITRATEM_QTD_SIN_PENDENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SITRATEM-VLR-SIN-PENDENTE  PIC S9(11)V9(2) USAGE COMP-3.*/
        public DoubleBasis SITRATEM_VLR_SIN_PENDENTE { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(11)V9(2)"), 2);
        /*"    10 SITRATEM-COD-FILIAL  PIC S9(4) USAGE COMP.*/
        public IntBasis SITRATEM_COD_FILIAL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SITRATEM-NOME-FILIAL  PIC X(40).*/
        public StringBasis SITRATEM_NOME_FILIAL { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 SITRATEM-SIGLA-FILIAL  PIC X(10).*/
        public StringBasis SITRATEM_SIGLA_FILIAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"*/
    }
}