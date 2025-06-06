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
    public class BENEFICI_DCLBENEFICIARIOS : VarBasis
    {
        /*"    10 BENEFICI-NUM-APOLICE       PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis BENEFICI_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 BENEFICI-COD-SUBGRUPO       PIC S9(4) USAGE COMP.*/
        public IntBasis BENEFICI_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 BENEFICI-NUM-CERTIFICADO       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis BENEFICI_NUM_CERTIFICADO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 BENEFICI-DAC-CERTIFICADO       PIC X(1).*/
        public StringBasis BENEFICI_DAC_CERTIFICADO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 BENEFICI-NUM-BENEFICIARIO       PIC S9(4) USAGE COMP.*/
        public IntBasis BENEFICI_NUM_BENEFICIARIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 BENEFICI-NOME-BENEFICIARIO       PIC X(40).*/
        public StringBasis BENEFICI_NOME_BENEFICIARIO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 BENEFICI-GRAU-PARENTESCO       PIC X(10).*/
        public StringBasis BENEFICI_GRAU_PARENTESCO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 BENEFICI-PCT-PART-BENEFICIA       PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis BENEFICI_PCT_PART_BENEFICIA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 BENEFICI-DATA-INIVIGENCIA       PIC X(10).*/
        public StringBasis BENEFICI_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 BENEFICI-DATA-TERVIGENCIA       PIC X(10).*/
        public StringBasis BENEFICI_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 BENEFICI-COD-USUARIO       PIC X(8).*/
        public StringBasis BENEFICI_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 BENEFICI-COD-EMPRESA       PIC S9(9) USAGE COMP.*/
        public IntBasis BENEFICI_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 BENEFICI-DTA-NASCIMENTO       PIC X(10).*/
        public StringBasis BENEFICI_DTA_NASCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 BENEFICI-NOM-MAE     PIC X(40).*/
        public StringBasis BENEFICI_NOM_MAE { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 BENEFICI-NUM-CPF     PIC S9(11)V USAGE COMP-3.*/
        public DoubleBasis BENEFICI_NUM_CPF { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(11)V"), 0);
        /*"    10 BENEFICI-NUM-CARTEIRINHA       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis BENEFICI_NUM_CARTEIRINHA { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"*/
    }
}