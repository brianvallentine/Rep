using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0851B
{
    public class SI0851B_RELATORIO : QueryBasis<SI0851B_RELATORIO>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0851B_RELATORIO() { IsCursor = true; }

        public SI0851B_RELATORIO(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0REL_PERI_INICIAL { get; set; }
        public string V0REL_PERI_FINAL { get; set; }
        public string V0REL_NUM_APOLICE { get; set; }
        public string V0REL_DATA_SOLICITACAO { get; set; }
        public string V0REL_CODUSU { get; set; }

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


        public override SI0851B_RELATORIO OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0851B_RELATORIO();
            var i = 0;

            dta.V0REL_PERI_INICIAL = result[i++].Value?.ToString();
            dta.V0REL_PERI_FINAL = result[i++].Value?.ToString();
            dta.V0REL_NUM_APOLICE = result[i++].Value?.ToString();
            dta.V0REL_DATA_SOLICITACAO = result[i++].Value?.ToString();
            dta.V0REL_CODUSU = result[i++].Value?.ToString();

            return dta;
        }

    }
}