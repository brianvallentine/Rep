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
    public class APOLICOR : VarBasis
    {
        /*"01  DCLAPOLICE-CORRETOR.*/
        public APOLICOR_DCLAPOLICE_CORRETOR DCLAPOLICE_CORRETOR { get; set; } = new APOLICOR_DCLAPOLICE_CORRETOR();

    }
}