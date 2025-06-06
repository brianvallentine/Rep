using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0133B
{
    public class SI0133B_V1PARCELA : QueryBasis<SI0133B_V1PARCELA>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0133B_V1PARCELA() { IsCursor = true; }

        public SI0133B_V1PARCELA(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string PARCEL_NRPARCEL { get; set; }
        public string PARCEL_SITUACAO { get; set; }
        public string PARCEL_OCORHIST { get; set; }
        public string PARCEL_NUM_APOL { get; set; }
        public string PARCEL_NRENDOS { get; set; }

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


        public override SI0133B_V1PARCELA OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0133B_V1PARCELA();
            var i = 0;

            dta.PARCEL_NRPARCEL = result[i++].Value?.ToString();
            dta.PARCEL_SITUACAO = result[i++].Value?.ToString();
            dta.PARCEL_OCORHIST = result[i++].Value?.ToString();
            dta.PARCEL_NUM_APOL = result[i++].Value?.ToString();
            dta.PARCEL_NRENDOS = result[i++].Value?.ToString();

            return dta;
        }

    }
}