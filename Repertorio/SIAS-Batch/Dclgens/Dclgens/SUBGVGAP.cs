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
    public class SUBGVGAP : VarBasis
    {
        /*"01  DCLSUBGRUPOS-VGAP.*/
        public SUBGVGAP_DCLSUBGRUPOS_VGAP DCLSUBGRUPOS_VGAP { get; set; } = new SUBGVGAP_DCLSUBGRUPOS_VGAP();

    }
}