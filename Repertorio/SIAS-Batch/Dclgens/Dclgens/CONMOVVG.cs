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
    public class CONMOVVG : VarBasis
    {
        /*"01  DCLCONTROLE-MOVTO-VG.*/
        public CONMOVVG_DCLCONTROLE_MOVTO_VG DCLCONTROLE_MOVTO_VG { get; set; } = new CONMOVVG_DCLCONTROLE_MOVTO_VG();

    }
}