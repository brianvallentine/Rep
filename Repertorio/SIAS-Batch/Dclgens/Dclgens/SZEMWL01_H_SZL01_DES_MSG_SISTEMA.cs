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
    public class SZEMWL01_H_SZL01_DES_MSG_SISTEMA : VarBasis
    {
        /*"    49 H-SZL01-DES-MSG-SISTEMA-L      PIC S9(004) COMP*/
        public IntBasis H_SZL01_DES_MSG_SISTEMA_L { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"    49 H-SZL01-DES-MSG-SISTEMA-T      PIC X(500)*/
        public StringBasis H_SZL01_DES_MSG_SISTEMA_T { get; set; } = new StringBasis(new PIC("X", "500", "X(500)"), @"");
        /*"  10   H-SZL01-IND-ERRO-LOG           PIC S9(004) COMP*/
    }
}