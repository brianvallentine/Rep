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
    public class V1ENDOSS : VarBasis
    {
        /*"01  DCLV1ENDOSSO.*/
        public V1ENDOSS_DCLV1ENDOSSO DCLV1ENDOSSO { get; set; } = new V1ENDOSS_DCLV1ENDOSSO();

    }
}