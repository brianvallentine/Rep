using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0868B
{
    public class SI0868B_CAUSAS : QueryBasis<SI0868B_CAUSAS>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0868B_CAUSAS() { IsCursor = true; }

        public SI0868B_CAUSAS(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string SINISCAU_COD_CAUSA { get; set; }
        public string SINISCAU_RAMO_EMISSOR { get; set; }
        public string SINISCAU_DESCR_CAUSA { get; set; }

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


        public override SI0868B_CAUSAS OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0868B_CAUSAS();
            var i = 0;

            dta.SINISCAU_COD_CAUSA = result[i++].Value?.ToString();
            dta.SINISCAU_RAMO_EMISSOR = result[i++].Value?.ToString();
            dta.SINISCAU_DESCR_CAUSA = result[i++].Value?.ToString();

            return dta;
        }

    }
}