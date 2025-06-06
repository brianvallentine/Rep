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
    public class SIARDEVC : VarBasis
    {
        /*"01  DCLSI-AR-DETALHE-VC.*/
        public SIARDEVC_DCLSI_AR_DETALHE_VC DCLSI_AR_DETALHE_VC { get; set; } = new SIARDEVC_DCLSI_AR_DETALHE_VC();

    }
}