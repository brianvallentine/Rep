using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI6017B
{
    public class BI6017B_CFAIXACEP : QueryBasis<BI6017B_CFAIXACEP>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public BI6017B_CFAIXACEP() { IsCursor = true; }

        public BI6017B_CFAIXACEP(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string GEFAICEP_FAIXA { get; set; }
        public string GEFAICEP_CEP_INICIAL { get; set; }
        public string GEFAICEP_CEP_FINAL { get; set; }
        public string GEFAICEP_DESCRICAO_FAIXA { get; set; }
        public string GEFAICEP_CENTRALIZADOR { get; set; }

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


        public override BI6017B_CFAIXACEP OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new BI6017B_CFAIXACEP();
            var i = 0;

            dta.GEFAICEP_FAIXA = result[i++].Value?.ToString();
            dta.GEFAICEP_CEP_INICIAL = result[i++].Value?.ToString();
            dta.GEFAICEP_CEP_FINAL = result[i++].Value?.ToString();
            dta.GEFAICEP_DESCRICAO_FAIXA = result[i++].Value?.ToString();
            dta.GEFAICEP_CENTRALIZADOR = result[i++].Value?.ToString();

            return dta;
        }

    }
}