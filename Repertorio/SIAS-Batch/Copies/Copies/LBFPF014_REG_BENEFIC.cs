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
    public class LBFPF014_REG_BENEFIC : VarBasis
    {
        /*"     10  R4-TIPO-REG                 PIC  X(001)*/
        public StringBasis R4_TIPO_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"     10  R4-NUM-PROPOSTA             PIC  9(014)*/
        public IntBasis R4_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
        /*"     10  R4-NOME                     PIC  X(040)*/
        public StringBasis R4_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
        /*"     10  R4-DATA-NASCIMENTO          PIC  9(008)*/
        public IntBasis R4_DATA_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"     10  R4-CGC-CPF                  PIC  9(014)*/
        public IntBasis R4_CGC_CPF { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
        /*"     10  R4-SEXO                     PIC  9(001)*/
        public IntBasis R4_SEXO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
        /*"     10  R4-ESTADO-CIVIL             PIC  9(001)*/
        public IntBasis R4_ESTADO_CIVIL { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
        /*"     10  R4-GRAU-PARENTESCO          PIC  9(001)*/
        public IntBasis R4_GRAU_PARENTESCO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
        /*"     10  R4-PCT-FGB                  PIC  9(003)V99*/
        public DoubleBasis R4_PCT_FGB { get; set; } = new DoubleBasis(new PIC("9", "3", "9(003)V99"), 2);
        /*"     10  R4-PCT-PECULIO              PIC  9(003)V99*/
        public DoubleBasis R4_PCT_PECULIO { get; set; } = new DoubleBasis(new PIC("9", "3", "9(003)V99"), 2);
        /*"     10  R4-PCT-PENSAO               PIC  9(003)V99*/
        public DoubleBasis R4_PCT_PENSAO { get; set; } = new DoubleBasis(new PIC("9", "3", "9(003)V99"), 2);
        /*"     10  R4-PCT-PARTICIP             PIC  9(003)V99*/
        public DoubleBasis R4_PCT_PARTICIP { get; set; } = new DoubleBasis(new PIC("9", "3", "9(003)V99"), 2);
        /*"     10  R4-QTDE-TITULOS             PIC  9(003)*/
        public IntBasis R4_QTDE_TITULOS { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
        /*"     10  R4-DESCR-PARENTESCO         PIC  X(030)*/
        public StringBasis R4_DESCR_PARENTESCO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
        /*"     10  R4-NOM-MAE                  PIC  X(040)*/
        public StringBasis R4_NOM_MAE { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
        /*"     10  R4-NUM-CART                 PIC  9(015)*/
        public IntBasis R4_NUM_CART { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
        /*"     10  FILLER                      PIC  X(112)*/
        public StringBasis FILLER { get; set; } = new StringBasis(new PIC("X", "112", "X(112)"), @"");
        /*"*/
    }
}