using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0648B
{
    public class PF0648B_OBTER_DATA_CREDITO : QueryBasis<PF0648B_OBTER_DATA_CREDITO>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public PF0648B_OBTER_DATA_CREDITO() { IsCursor = true; }

        public PF0648B_OBTER_DATA_CREDITO(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string HISCONPA_DATA_MOVIMENTO { get; set; }

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


        public override PF0648B_OBTER_DATA_CREDITO OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new PF0648B_OBTER_DATA_CREDITO();
            var i = 0;

            dta.HISCONPA_DATA_MOVIMENTO = result[i++].Value?.ToString();

            return dta;
        }

    }
}