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
    public class ARQSIVPF : VarBasis
    {
        /*"01  DCLARQUIVOS-SIVPF.*/
        public ARQSIVPF_DCLARQUIVOS_SIVPF DCLARQUIVOS_SIVPF { get; set; } = new ARQSIVPF_DCLARQUIVOS_SIVPF();

    }
}