using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0002B
{
    public class PF0002B_V0PRDSIVPF : QueryBasis<PF0002B_V0PRDSIVPF>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public PF0002B_V0PRDSIVPF() { IsCursor = true; }

        public PF0002B_V0PRDSIVPF(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0PRPF_CODSIVPF { get; set; }
        public string V0PRPF_CODPRODU { get; set; }

        public new void Open()
        {
            if (!IsProcedure)
                SetQuery(GetQueryEvent());
            base.Open();
        }


        public new bool Fetch()
        {
            if (!JustACursor)
            {
                var idx = CurrentIndex;
                Open();
                CurrentIndex = idx > -1 ? idx : 0;
            }

            return base.Fetch();
        }


        public override PF0002B_V0PRDSIVPF OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new PF0002B_V0PRDSIVPF();
            var i = 0;

            dta.V0PRPF_CODSIVPF = result[i++].Value?.ToString();
            dta.V0PRPF_CODPRODU = result[i++].Value?.ToString();

            return dta;
        }

    }
}