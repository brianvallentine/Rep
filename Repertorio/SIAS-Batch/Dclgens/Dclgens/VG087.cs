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
    public class VG087 : VarBasis
    {
        /*"01  DCLVG-GRUPO-COBERTURA.*/
        public VG087_DCLVG_GRUPO_COBERTURA DCLVG_GRUPO_COBERTURA { get; set; } = new VG087_DCLVG_GRUPO_COBERTURA();

    }
}