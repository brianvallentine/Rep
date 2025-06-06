using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0202B
{
    public class SI0202B_YYY : QueryBasis<SI0202B_YYY>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0202B_YYY() { IsCursor = true; }

        public SI0202B_YYY(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string RALCHEDO_AGE_CENTRAL_PROD01 { get; set; }
        public string SINISHIS_OCORR_HISTORICO { get; set; }
        public string SINISHIS_DATA_MOVIMENTO { get; set; }

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


        public override SI0202B_YYY OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0202B_YYY();
            var i = 0;

            dta.RALCHEDO_AGE_CENTRAL_PROD01 = result[i++].Value?.ToString();
            dta.SINISHIS_OCORR_HISTORICO = result[i++].Value?.ToString();
            dta.SINISHIS_DATA_MOVIMENTO = result[i++].Value?.ToString();

            return dta;
        }

    }
}