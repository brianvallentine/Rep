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
    public class GE353_DCLGE_DNE_TRIAGEM : VarBasis
    {
        /*"    10 GE353-COD-INI-FAIXA-CEP  PIC X(8).*/
        public StringBasis GE353_COD_INI_FAIXA_CEP { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 GE353-COD-FIM-FAIXA-CEP  PIC X(8).*/
        public StringBasis GE353_COD_FIM_FAIXA_CEP { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 GE353-NOM-UNIDADE-OPER  PIC X(72).*/
        public StringBasis GE353_NOM_UNIDADE_OPER { get; set; } = new StringBasis(new PIC("X", "72", "X(72)."), @"");
        /*"    10 GE353-NOM-CENTRALIZADOR  PIC X(72).*/
        public StringBasis GE353_NOM_CENTRALIZADOR { get; set; } = new StringBasis(new PIC("X", "72", "X(72)."), @"");
        /*"    10 GE353-COD-REGIAO     PIC X(3).*/
        public StringBasis GE353_COD_REGIAO { get; set; } = new StringBasis(new PIC("X", "3", "X(3)."), @"");
        /*"    10 GE353-DTH-CADASTRAMENTO  PIC X(10).*/
        public StringBasis GE353_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
    }
}