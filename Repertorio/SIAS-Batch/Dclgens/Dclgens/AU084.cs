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
    public class AU084 : VarBasis
    {
        /*"01  DCLAU-APOLICE-COMPL.*/
        public AU084_DCLAU_APOLICE_COMPL DCLAU_APOLICE_COMPL { get; set; } = new AU084_DCLAU_APOLICE_COMPL();

    }
}