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
    public class ADPROGRA : VarBasis
    {
        /*"01  DCLAD-PROGRAMA.*/
        public ADPROGRA_DCLAD_PROGRAMA DCLAD_PROGRAMA { get; set; } = new ADPROGRA_DCLAD_PROGRAMA();

    }
}