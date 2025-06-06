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
    public class VGFOLLOW : VarBasis
    {
        /*"01  DCLVG-FOLLOW-UP.*/
        public VGFOLLOW_DCLVG_FOLLOW_UP DCLVG_FOLLOW_UP { get; set; } = new VGFOLLOW_DCLVG_FOLLOW_UP();

    }
}