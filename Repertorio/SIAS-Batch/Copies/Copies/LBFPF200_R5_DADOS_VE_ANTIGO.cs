using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Copies
{
    public class LBFPF200_R5_DADOS_VE_ANTIGO : VarBasis
    {
        /*"        10    R5-DATA-ATUALIZACAO         PIC  9(008)*/
        public IntBasis R5_DATA_ATUALIZACAO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"        10    R5-QTDE-VIDAS-MODULO-1      PIC  9(004)*/
        public IntBasis R5_QTDE_VIDAS_MODULO_1 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"        10    R5-CAPITAL-MODULO-1         PIC  9(015)V99*/
        public DoubleBasis R5_CAPITAL_MODULO_1 { get; set; } = new DoubleBasis(new PIC("9", "15", "9(015)V99"), 2);
        /*"        10    R5-QTDE-VIDAS-MODULO-2      PIC  9(004)*/
        public IntBasis R5_QTDE_VIDAS_MODULO_2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"        10    R5-CAPITAL-MODULO-2         PIC  9(015)V99*/
        public DoubleBasis R5_CAPITAL_MODULO_2 { get; set; } = new DoubleBasis(new PIC("9", "15", "9(015)V99"), 2);
        /*"        10    R5-QTDE-VIDAS-MODULO-3      PIC  9(004)*/
        public IntBasis R5_QTDE_VIDAS_MODULO_3 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"        10    R5-CAPITAL-MODULO-3         PIC  9(015)V99*/
        public DoubleBasis R5_CAPITAL_MODULO_3 { get; set; } = new DoubleBasis(new PIC("9", "15", "9(015)V99"), 2);
        /*"        10       FILLER                   PIC  X(014)*/
        public StringBasis FILLER { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"");
        /*"     05       R5-DADOS-VE-NOVO  REDEFINES              R5-DADOS-VE-ANTIGO*/
    }
}