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
    public class PRODUVG : VarBasis
    {
        /*"01  DCLPRODUTOS-VG.*/
        public PRODUVG_DCLPRODUTOS_VG DCLPRODUTOS_VG { get; set; } = new PRODUVG_DCLPRODUTOS_VG();

    }
}