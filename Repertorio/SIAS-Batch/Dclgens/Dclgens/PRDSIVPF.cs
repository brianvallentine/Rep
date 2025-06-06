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
    public class PRDSIVPF : VarBasis
    {
        /*"01  DCLPRODUTOS-SIVPF.*/
        public PRDSIVPF_DCLPRODUTOS_SIVPF DCLPRODUTOS_SIVPF { get; set; } = new PRDSIVPF_DCLPRODUTOS_SIVPF();

    }
}