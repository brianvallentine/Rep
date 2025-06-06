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
    public class OD003_DCLOD_PESSOA_JURIDICA : VarBasis
    {
        /*"    10 OD003-NUM-PESSOA     PIC S9(9) USAGE COMP.*/
        public IntBasis OD003_NUM_PESSOA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 OD003-NUM-CNPJ       PIC S9(9) USAGE COMP.*/
        public IntBasis OD003_NUM_CNPJ { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 OD003-NUM-FILIAL     PIC S9(4) USAGE COMP.*/
        public IntBasis OD003_NUM_FILIAL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 OD003-NUM-DV-CNPJ    PIC S9(4) USAGE COMP.*/
        public IntBasis OD003_NUM_DV_CNPJ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 OD003-NOM-RAZAO-SOCIAL.*/
        public OD003_OD003_NOM_RAZAO_SOCIAL OD003_NOM_RAZAO_SOCIAL { get; set; } = new OD003_OD003_NOM_RAZAO_SOCIAL();

        public StringBasis OD003_STA_PESSOA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 OD003-NUM-RAMO-ATIVIDADE  PIC S9(9) USAGE COMP.*/
        public IntBasis OD003_NUM_RAMO_ATIVIDADE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 OD003-DTH-FUNDACAO   PIC X(10).*/
        public StringBasis OD003_DTH_FUNDACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 OD003-NOM-FANTASIA   PIC X(100).*/
        public StringBasis OD003_NOM_FANTASIA { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");
        /*"    10 OD003-NOM-SIGLA-PESSOA  PIC X(40).*/
        public StringBasis OD003_NOM_SIGLA_PESSOA { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 OD003-NUM-INSC-ESTADUAL  PIC S9(14)V USAGE COMP-3.*/
        public DoubleBasis OD003_NUM_INSC_ESTADUAL { get; set; } = new DoubleBasis(new PIC("S9", "14", "S9(14)V"), 0);
        /*"    10 OD003-NUM-INSC-MUNICIPAL  PIC S9(14)V USAGE COMP-3.*/
        public DoubleBasis OD003_NUM_INSC_MUNICIPAL { get; set; } = new DoubleBasis(new PIC("S9", "14", "S9(14)V"), 0);
        /*"    10 OD003-COD-UF         PIC X(2).*/
        public StringBasis OD003_COD_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 OD003-NUM-MUNICIPIO  PIC S9(9) USAGE COMP.*/
        public IntBasis OD003_NUM_MUNICIPIO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 OD003-COD-CNAE       PIC X(20).*/
        public StringBasis OD003_COD_CNAE { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        /*"    10 OD003-NUM-SOCIOS     PIC S9(4) USAGE COMP.*/
        public IntBasis OD003_NUM_SOCIOS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 OD003-STA-FRANQUIA   PIC X(1).*/
        public StringBasis OD003_STA_FRANQUIA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 OD003-IND-FINALIDADE  PIC X(1).*/
        public StringBasis OD003_IND_FINALIDADE { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"*/
    }
}