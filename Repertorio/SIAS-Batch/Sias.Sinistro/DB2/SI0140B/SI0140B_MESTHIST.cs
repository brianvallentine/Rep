using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0140B
{
    public class SI0140B_MESTHIST : QueryBasis<SI0140B_MESTHIST>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0140B_MESTHIST() { IsCursor = true; }

        public SI0140B_MESTHIST(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0MEST_FONTE { get; set; }
        public string V0MEST_RAMO { get; set; }
        public string V0MEST_CODCAU { get; set; }
        public string V0MEST_SITUACAO { get; set; }
        public string V0SINI_DESCAU { get; set; }
        public string V0MEST_NUM_APOLICE { get; set; }
        public string V0MEST_NUM_APOL_SINISTRO { get; set; }
        public string V0AUTO1_NUM_ITEM { get; set; }
        public string V0HIST_VAL_OPERACAO { get; set; }
        public string V1SIST_DTMOVABE { get; set; }
        public string V1SIST_DTCURRENT { get; set; }

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


        public override SI0140B_MESTHIST OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0140B_MESTHIST();
            var i = 0;

            dta.V0MEST_FONTE = result[i++].Value?.ToString();
            dta.V0MEST_RAMO = result[i++].Value?.ToString();
            dta.V0MEST_CODCAU = result[i++].Value?.ToString();
            dta.V0MEST_SITUACAO = result[i++].Value?.ToString();
            dta.V0SINI_DESCAU = result[i++].Value?.ToString();
            dta.V0MEST_NUM_APOLICE = result[i++].Value?.ToString();
            dta.V0MEST_NUM_APOL_SINISTRO = result[i++].Value?.ToString();
            dta.V0AUTO1_NUM_ITEM = result[i++].Value?.ToString();
            dta.V0HIST_VAL_OPERACAO = result[i++].Value?.ToString();
            dta.V1SIST_DTMOVABE = result[i++].Value?.ToString();
            dta.V1SIST_DTCURRENT = result[i++].Value?.ToString();

            return dta;
        }

    }
}