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
    public class OD002_DCLOD_PESSOA_FISICA : VarBasis
    {
        /*"    10 OD002-NUM-PESSOA     PIC S9(9) USAGE COMP.*/
        public IntBasis OD002_NUM_PESSOA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 OD002-NUM-CPF        PIC S9(9) USAGE COMP.*/
        public IntBasis OD002_NUM_CPF { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 OD002-NUM-DV-CPF     PIC S9(4) USAGE COMP.*/
        public IntBasis OD002_NUM_DV_CPF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 OD002-NOM-PESSOA.*/
        public OD002_OD002_NOM_PESSOA OD002_NOM_PESSOA { get; set; } = new OD002_OD002_NOM_PESSOA();

        public StringBasis OD002_DTH_NASCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 OD002-STA-SEXO       PIC X(1).*/
        public StringBasis OD002_STA_SEXO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 OD002-IND-ESTADO-CIVIL       PIC X(1).*/
        public StringBasis OD002_IND_ESTADO_CIVIL { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 OD002-STA-PESSOA     PIC X(1).*/
        public StringBasis OD002_STA_PESSOA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 OD002-NOM-TRATAMENTO       PIC X(15).*/
        public StringBasis OD002_NOM_TRATAMENTO { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
        /*"    10 OD002-COD-UF         PIC X(2).*/
        public StringBasis OD002_COD_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 OD002-NUM-MUNICIPIO  PIC S9(9) USAGE COMP.*/
        public IntBasis OD002_NUM_MUNICIPIO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 OD002-NUM-INSC-SOCIAL       PIC S9(10)V USAGE COMP-3.*/
        public DoubleBasis OD002_NUM_INSC_SOCIAL { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V"), 0);
        /*"    10 OD002-NUM-DV-INSC-SOCIAL       PIC S9(4) USAGE COMP.*/
        public IntBasis OD002_NUM_DV_INSC_SOCIAL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 OD002-NUM-GRAU-INSTRUCAO       PIC S9(4) USAGE COMP.*/
        public IntBasis OD002_NUM_GRAU_INSTRUCAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 OD002-NOM-REDUZIDO   PIC X(25).*/
        public StringBasis OD002_NOM_REDUZIDO { get; set; } = new StringBasis(new PIC("X", "25", "X(25)."), @"");
        /*"    10 OD002-COD-CBO        PIC X(10).*/
        public StringBasis OD002_COD_CBO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 OD002-NOM-PRIMEIRO   PIC X(25).*/
        public StringBasis OD002_NOM_PRIMEIRO { get; set; } = new StringBasis(new PIC("X", "25", "X(25)."), @"");
        /*"    10 OD002-NOM-ULTIMO     PIC X(25).*/
        public StringBasis OD002_NOM_ULTIMO { get; set; } = new StringBasis(new PIC("X", "25", "X(25)."), @"");
        /*"*/
    }
}