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
    public class GEPESJUR_DCLGE_PESSOA_JURIDICA : VarBasis
    {
        /*"    10 GEPESJUR-COD-PESSOA  PIC S9(9) USAGE COMP.*/
        public IntBasis GEPESJUR_COD_PESSOA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GEPESJUR-NUM-CNPJ    PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis GEPESJUR_NUM_CNPJ { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 GEPESJUR-NOM-FANTASIA  PIC X(40).*/
        public StringBasis GEPESJUR_NOM_FANTASIA { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 GEPESJUR-NOM-SIGLA-PESSOA  PIC X(10).*/
        public StringBasis GEPESJUR_NOM_SIGLA_PESSOA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GEPESJUR-COD-EXTERNO  PIC X(10).*/
        public StringBasis GEPESJUR_COD_EXTERNO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GEPESJUR-DTH-CADASTRAMENTO  PIC X(26).*/
        public StringBasis GEPESJUR_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}