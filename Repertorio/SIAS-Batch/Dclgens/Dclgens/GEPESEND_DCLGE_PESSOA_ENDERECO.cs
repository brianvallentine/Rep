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
    public class GEPESEND_DCLGE_PESSOA_ENDERECO : VarBasis
    {
        /*"    10 GEPESEND-COD-PESSOA  PIC S9(9) USAGE COMP.*/
        public IntBasis GEPESEND_COD_PESSOA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GEPESEND-SEQ-ENDERECO  PIC S9(4) USAGE COMP.*/
        public IntBasis GEPESEND_SEQ_ENDERECO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GEPESEND-IND-ENDERECO  PIC X(1).*/
        public StringBasis GEPESEND_IND_ENDERECO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GEPESEND-NOM-LOGRADOURO  PIC X(40).*/
        public StringBasis GEPESEND_NOM_LOGRADOURO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 GEPESEND-NUM-IMOVEL  PIC X(10).*/
        public StringBasis GEPESEND_NUM_IMOVEL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GEPESEND-DES-COMPLEMENTO  PIC X(40).*/
        public StringBasis GEPESEND_DES_COMPLEMENTO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 GEPESEND-NOM-BAIRRO  PIC X(30).*/
        public StringBasis GEPESEND_NOM_BAIRRO { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
        /*"    10 GEPESEND-NOM-CIDADE  PIC X(40).*/
        public StringBasis GEPESEND_NOM_CIDADE { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 GEPESEND-NUM-CEP     PIC X(10).*/
        public StringBasis GEPESEND_NUM_CEP { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GEPESEND-COD-UF      PIC X(2).*/
        public StringBasis GEPESEND_COD_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 GEPESEND-STA-ENDERECO  PIC X(1).*/
        public StringBasis GEPESEND_STA_ENDERECO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GEPESEND-DTH-CADASTRAMENTO  PIC X(26).*/
        public StringBasis GEPESEND_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
    }
}