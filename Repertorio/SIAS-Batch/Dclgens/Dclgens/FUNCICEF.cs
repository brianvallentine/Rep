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
    public class FUNCICEF : VarBasis
    {
        /*"01  DCLFUNCIONARIOS-CEF.*/
        public FUNCICEF_DCLFUNCIONARIOS_CEF DCLFUNCIONARIOS_CEF { get; set; } = new FUNCICEF_DCLFUNCIONARIOS_CEF();

    }
}