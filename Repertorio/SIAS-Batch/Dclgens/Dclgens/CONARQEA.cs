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
    public class CONARQEA : VarBasis
    {
        /*"01  DCLCONT-ARQUIVOS-EA.*/
        public CONARQEA_DCLCONT_ARQUIVOS_EA DCLCONT_ARQUIVOS_EA { get; set; } = new CONARQEA_DCLCONT_ARQUIVOS_EA();

    }
}