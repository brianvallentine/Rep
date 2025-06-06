using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0103B
{
    public class SI0103B_HISTMEST : QueryBasis<SI0103B_HISTMEST>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0103B_HISTMEST() { IsCursor = true; }

        public SI0103B_HISTMEST(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V1HISTMEST_NUM_APOLICE { get; set; }
        public string V1HISTMEST_NUM_SINISTRO { get; set; }
        public string V1HISTMEST_CODSUBES { get; set; }
        public string V1HISTMEST_NRCERTIF { get; set; }
        public string V1HISTMEST_IDTPSEGU { get; set; }
        public string V1HISTMEST_PCPARTIC { get; set; }
        public string V1HISTMEST_DATORR { get; set; }
        public string V1HISTMEST_PCTRES { get; set; }
        public string V1HISTMEST_FONTE { get; set; }
        public string V1HISTMEST_RAMO { get; set; }
        public string V1HISTMEST_COD_MOEDA_SINI { get; set; }
        public string V1HISTMEST_DTMOVTO { get; set; }

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


        public override SI0103B_HISTMEST OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0103B_HISTMEST();
            var i = 0;

            dta.V1HISTMEST_NUM_APOLICE = result[i++].Value?.ToString();
            dta.V1HISTMEST_NUM_SINISTRO = result[i++].Value?.ToString();
            dta.V1HISTMEST_CODSUBES = result[i++].Value?.ToString();
            dta.V1HISTMEST_NRCERTIF = result[i++].Value?.ToString();
            dta.V1HISTMEST_IDTPSEGU = result[i++].Value?.ToString();
            dta.V1HISTMEST_PCPARTIC = result[i++].Value?.ToString();
            dta.V1HISTMEST_DATORR = result[i++].Value?.ToString();
            dta.V1HISTMEST_PCTRES = result[i++].Value?.ToString();
            dta.V1HISTMEST_FONTE = result[i++].Value?.ToString();
            dta.V1HISTMEST_RAMO = result[i++].Value?.ToString();
            dta.V1HISTMEST_COD_MOEDA_SINI = result[i++].Value?.ToString();
            dta.V1HISTMEST_DTMOVTO = result[i++].Value?.ToString();

            return dta;
        }

    }
}