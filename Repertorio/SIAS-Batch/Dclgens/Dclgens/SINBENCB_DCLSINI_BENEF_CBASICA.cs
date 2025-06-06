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
    public class SINBENCB_DCLSINI_BENEF_CBASICA : VarBasis
    {
        /*"    10 SINBENCB-NUM-APOLICE  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis SINBENCB_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 SINBENCB-NUM-SINISTRO  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis SINBENCB_NUM_SINISTRO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 SINBENCB-NUM-BILHETE  PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis SINBENCB_NUM_BILHETE { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 SINBENCB-OCORR-HISTORICO  PIC S9(4) USAGE COMP.*/
        public IntBasis SINBENCB_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINBENCB-DTMOVTO     PIC X(10).*/
        public StringBasis SINBENCB_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SINBENCB-NOME-BENEFICIARIO  PIC X(40).*/
        public StringBasis SINBENCB_NOME_BENEFICIARIO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 SINBENCB-ENDERECO    PIC X(40).*/
        public StringBasis SINBENCB_ENDERECO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 SINBENCB-BAIRRO      PIC X(20).*/
        public StringBasis SINBENCB_BAIRRO { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        /*"    10 SINBENCB-CIDADE      PIC X(20).*/
        public StringBasis SINBENCB_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        /*"    10 SINBENCB-SIGLA-UF    PIC X(2).*/
        public StringBasis SINBENCB_SIGLA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 SINBENCB-CEP         PIC S9(9) USAGE COMP.*/
        public IntBasis SINBENCB_CEP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SINBENCB-SIT-REGISTRO  PIC X(1).*/
        public StringBasis SINBENCB_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SINBENCB-DDD-BENEF-CBASICA  PIC S9(4) USAGE COMP.*/
        public IntBasis SINBENCB_DDD_BENEF_CBASICA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SINBENCB-FONE-BENEF-CBASICA  PIC S9(9) USAGE COMP.*/
        public IntBasis SINBENCB_FONE_BENEF_CBASICA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SINBENCB-OBS-BENEF-CBASICA  PIC X(40).*/
        public StringBasis SINBENCB_OBS_BENEF_CBASICA { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 SINBENCB-DATA-INDENIZACAO  PIC X(10).*/
        public StringBasis SINBENCB_DATA_INDENIZACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SINBENCB-NUM-CPF     PIC S9(11)V USAGE COMP-3.*/
        public DoubleBasis SINBENCB_NUM_CPF { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(11)V"), 0);
        /*"*/
    }
}