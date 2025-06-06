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
    public class VG096 : VarBasis
    {
        /*"01  DCLVG-MOVTO-PRESTAMISTA.*/
        public VG096_DCLVG_MOVTO_PRESTAMISTA DCLVG_MOVTO_PRESTAMISTA { get; set; } = new VG096_DCLVG_MOVTO_PRESTAMISTA();

    }
}