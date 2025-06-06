using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0812B
{
    public class SI0812B_TMESTSIN : QueryBasis<SI0812B_TMESTSIN>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0812B_TMESTSIN() { IsCursor = true; }

        public SI0812B_TMESTSIN(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string MEST_CODSUBES { get; set; }
        public string MEST_FONTE { get; set; }
        public string MEST_RAMO { get; set; }
        public string MEST_CODCAU { get; set; }
        public string MEST_APOL_SINI { get; set; }
        public string MEST_NRCERTIF { get; set; }
        public string MEST_IDTPSEGU { get; set; }
        public string HIST_VALPRI { get; set; }

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


        public override SI0812B_TMESTSIN OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0812B_TMESTSIN();
            var i = 0;

            dta.MEST_CODSUBES = result[i++].Value?.ToString();
            dta.MEST_FONTE = result[i++].Value?.ToString();
            dta.MEST_RAMO = result[i++].Value?.ToString();
            dta.MEST_CODCAU = result[i++].Value?.ToString();
            dta.MEST_APOL_SINI = result[i++].Value?.ToString();
            dta.MEST_NRCERTIF = result[i++].Value?.ToString();
            dta.MEST_IDTPSEGU = result[i++].Value?.ToString();
            dta.HIST_VALPRI = result[i++].Value?.ToString();

            return dta;
        }

    }
}