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
    public class VG079 : VarBasis
    {
        /*"01  DCLVG-PESS-PARCELA.*/
        public VG079_DCLVG_PESS_PARCELA DCLVG_PESS_PARCELA { get; set; } = new VG079_DCLVG_PESS_PARCELA();

    }
}