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
    public class GE419 : VarBasis
    {
        /*"01  DCLGE-MOVTO-TRIBUTO.*/
        public GE419_DCLGE_MOVTO_TRIBUTO DCLGE_MOVTO_TRIBUTO { get; set; } = new GE419_DCLGE_MOVTO_TRIBUTO();

    }
}