using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.FC0038B
{
    public class FC0038B_V0FAIXACEP : QueryBasis<FC0038B_V0FAIXACEP>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public FC0038B_V0FAIXACEP() { IsCursor = true; }

        public FC0038B_V0FAIXACEP(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0FCEP_FAIXA { get; set; }
        public string V0FCEP_CEPINI { get; set; }
        public string V0FCEP_CEPFIM { get; set; }
        public string V0FCEP_DESC_FAIXA { get; set; }
        public string V0FCEP_CENTRALIZADOR { get; set; }

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


        public override FC0038B_V0FAIXACEP OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new FC0038B_V0FAIXACEP();
            var i = 0;

            dta.V0FCEP_FAIXA = result[i++].Value?.ToString();
            dta.V0FCEP_CEPINI = result[i++].Value?.ToString();
            dta.V0FCEP_CEPFIM = result[i++].Value?.ToString();
            dta.V0FCEP_DESC_FAIXA = result[i++].Value?.ToString();
            dta.V0FCEP_CENTRALIZADOR = result[i++].Value?.ToString();

            return dta;
        }

    }
}