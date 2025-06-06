using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0104B
{
    public class SI0104B_HISTMEST : QueryBasis<SI0104B_HISTMEST>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0104B_HISTMEST() { IsCursor = true; }

        public SI0104B_HISTMEST(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V1HISTMEST_NUM_SINISTRO { get; set; }
        public string V1HISTMEST_NUM_APOLICE { get; set; }
        public string V1HISTMEST_PROTSINI { get; set; }
        public string V1HISTMEST_SDOPAGBT { get; set; }
        public string V1HISTMEST_CODSUBES { get; set; }
        public string V1HISTMEST_NRCERTIF { get; set; }
        public string V1HISTMEST_IDTPSEGU { get; set; }
        public string V1HISTMEST_MODALIDA { get; set; }
        public string V1HISTMEST_SIGLUNIM { get; set; }
        public string V1HISTMEST_VLCRUZAD { get; set; }
        public string V1HISTMEST_DTMOVTO { get; set; }
        public string V1HISTMEST_FONTE { get; set; }
        public string V1HISTMEST_RAMO { get; set; }
        public string V1HISTMEST_NOME { get; set; }
        public string V1HISTMEST_DAC { get; set; }

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


        public override SI0104B_HISTMEST OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0104B_HISTMEST();
            var i = 0;

            dta.V1HISTMEST_NUM_SINISTRO = result[i++].Value?.ToString();
            dta.V1HISTMEST_NUM_APOLICE = result[i++].Value?.ToString();
            dta.V1HISTMEST_PROTSINI = result[i++].Value?.ToString();
            dta.V1HISTMEST_SDOPAGBT = result[i++].Value?.ToString();
            dta.V1HISTMEST_CODSUBES = result[i++].Value?.ToString();
            dta.V1HISTMEST_NRCERTIF = result[i++].Value?.ToString();
            dta.V1HISTMEST_IDTPSEGU = result[i++].Value?.ToString();
            dta.V1HISTMEST_MODALIDA = result[i++].Value?.ToString();
            dta.V1HISTMEST_SIGLUNIM = result[i++].Value?.ToString();
            dta.V1HISTMEST_VLCRUZAD = result[i++].Value?.ToString();
            dta.V1HISTMEST_DTMOVTO = result[i++].Value?.ToString();
            dta.V1HISTMEST_FONTE = result[i++].Value?.ToString();
            dta.V1HISTMEST_RAMO = result[i++].Value?.ToString();
            dta.V1HISTMEST_NOME = result[i++].Value?.ToString();
            dta.V1HISTMEST_DAC = result[i++].Value?.ToString();

            return dta;
        }

    }
}