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
    public class HISCONPA : VarBasis
    {
        /*"01  DCLHIST-CONT-PARCELVA.*/
        public HISCONPA_DCLHIST_CONT_PARCELVA DCLHIST_CONT_PARCELVA { get; set; } = new HISCONPA_DCLHIST_CONT_PARCELVA();

    }
}