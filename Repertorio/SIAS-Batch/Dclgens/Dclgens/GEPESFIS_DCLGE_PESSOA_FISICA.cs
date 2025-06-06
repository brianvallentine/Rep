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
    public class GEPESFIS_DCLGE_PESSOA_FISICA : VarBasis
    {
        /*"    10 GEPESFIS-COD-PESSOA  PIC S9(9) USAGE COMP.*/
        public IntBasis GEPESFIS_COD_PESSOA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GEPESFIS-NUM-CPF     PIC S9(11)V USAGE COMP-3.*/
        public DoubleBasis GEPESFIS_NUM_CPF { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(11)V"), 0);
        /*"    10 GEPESFIS-DTH-NASCIMENTO  PIC X(10).*/
        public StringBasis GEPESFIS_DTH_NASCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GEPESFIS-STA-SEXO    PIC X(1).*/
        public StringBasis GEPESFIS_STA_SEXO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GEPESFIS-NOM-PRIMEIRO-NOME  PIC X(20).*/
        public StringBasis GEPESFIS_NOM_PRIMEIRO_NOME { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        /*"    10 GEPESFIS-NOM-ULTIMO-NOME  PIC X(20).*/
        public StringBasis GEPESFIS_NOM_ULTIMO_NOME { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        /*"    10 GEPESFIS-IND-ESTADO-CIVIL  PIC X(1).*/
        public StringBasis GEPESFIS_IND_ESTADO_CIVIL { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GEPESFIS-COD-RG      PIC X(20).*/
        public StringBasis GEPESFIS_COD_RG { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        /*"    10 GEPESFIS-NOM-ORGAO-EXPED-RG  PIC X(10).*/
        public StringBasis GEPESFIS_NOM_ORGAO_EXPED_RG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GEPESFIS-COD-UF-ORGAO-EXPED  PIC X(2).*/
        public StringBasis GEPESFIS_COD_UF_ORGAO_EXPED { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 GEPESFIS-DTH-EXPED-RG  PIC X(10).*/
        public StringBasis GEPESFIS_DTH_EXPED_RG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GEPESFIS-COD-CBO     PIC S9(9) USAGE COMP.*/
        public IntBasis GEPESFIS_COD_CBO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GEPESFIS-DTH-CADASTRAMENTO  PIC X(26).*/
        public StringBasis GEPESFIS_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}