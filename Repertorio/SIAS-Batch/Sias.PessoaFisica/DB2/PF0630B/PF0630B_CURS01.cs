using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0630B
{
    public class PF0630B_CURS01 : QueryBasis<PF0630B_CURS01>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public PF0630B_CURS01() { IsCursor = true; }

        public PF0630B_CURS01(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string PRDSIVPF_COD_PRODUTO_SIVPF { get; set; }
        public string SICFAIRC_NUM_SICOB_INI { get; set; }
        public string SICFAIRC_NUM_SICOB_FIM { get; set; }

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


        public override PF0630B_CURS01 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new PF0630B_CURS01();
            var i = 0;

            dta.PRDSIVPF_COD_PRODUTO_SIVPF = result[i++].Value?.ToString();
            dta.SICFAIRC_NUM_SICOB_INI = result[i++].Value?.ToString();
            dta.SICFAIRC_NUM_SICOB_FIM = result[i++].Value?.ToString();

            return dta;
        }

    }
}