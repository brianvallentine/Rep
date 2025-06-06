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
    public class GE374_DCLGE_CNAE_ATIVIDADE : VarBasis
    {
        /*"    10 GE374-COD-CNAE-ATIVIDADE       PIC X(7).*/
        public StringBasis GE374_COD_CNAE_ATIVIDADE { get; set; } = new StringBasis(new PIC("X", "7", "X(7)."), @"");
        /*"    10 GE374-DES-CNAE-ATIVIDADE       PIC X(200).*/
        public StringBasis GE374_DES_CNAE_ATIVIDADE { get; set; } = new StringBasis(new PIC("X", "200", "X(200)."), @"");
        /*"    10 GE374-DTH-CADASTRAMENTO       PIC X(10).*/
        public StringBasis GE374_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"*/
    }
}