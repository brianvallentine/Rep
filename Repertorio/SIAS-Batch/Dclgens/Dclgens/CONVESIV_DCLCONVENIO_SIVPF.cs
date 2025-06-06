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
    public class CONVESIV_DCLCONVENIO_SIVPF : VarBasis
    {
        /*"    10 CONVESIV-SIGLA-ARQUIVO  PIC X(8).*/
        public StringBasis CONVESIV_SIGLA_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 CONVESIV-DESCR-ARQUIVO  PIC X(60).*/
        public StringBasis CONVESIV_DESCR_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "60", "X(60)."), @"");
        /*"*/
    }
}