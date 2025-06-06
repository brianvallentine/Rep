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
    public class COVSIVPF_DCLCONVENIO_SIVPF : VarBasis
    {
        /*"    10 SIGLA-ARQUIVO        PIC X(8).*/
        public StringBasis SIGLA_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 DESCR-ARQUIVO        PIC X(20).*/
        public StringBasis DESCR_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        /*"*/
    }
}