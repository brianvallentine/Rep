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
    public class FCTITULO : VarBasis
    {
        /*"01  DCLFC-TITULO.*/
        public FCTITULO_DCLFC_TITULO DCLFC_TITULO { get; set; } = new FCTITULO_DCLFC_TITULO();

    }
}