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
    public class CODERRBI : VarBasis
    {
        /*"01  DCLCOD-ERROS-BILHETE.*/
        public CODERRBI_DCLCOD_ERROS_BILHETE DCLCOD_ERROS_BILHETE { get; set; } = new CODERRBI_DCLCOD_ERROS_BILHETE();

    }
}