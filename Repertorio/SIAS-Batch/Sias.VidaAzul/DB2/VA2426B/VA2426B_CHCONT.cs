using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA2426B
{
    public class VA2426B_CHCONT : QueryBasis<VA2426B_CHCONT>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VA2426B_CHCONT() { IsCursor = true; }

        public VA2426B_CHCONT(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0HCON_APOLICE { get; set; }
        public string V0HCON_CODSUBES { get; set; }
        public string V0PROD_NOMPRODU { get; set; }
        public string V0HCON_NRPARCEL { get; set; }
        public string V0HCON_CODOPER { get; set; }
        public string V0HCON_DTMOVTO { get; set; }
        public string V0HCON_PRMTOTAL { get; set; }

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


        public override VA2426B_CHCONT OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VA2426B_CHCONT();
            var i = 0;

            dta.V0HCON_APOLICE = result[i++].Value?.ToString();
            dta.V0HCON_CODSUBES = result[i++].Value?.ToString();
            dta.V0PROD_NOMPRODU = result[i++].Value?.ToString();
            dta.V0HCON_NRPARCEL = result[i++].Value?.ToString();
            dta.V0HCON_CODOPER = result[i++].Value?.ToString();
            dta.V0HCON_DTMOVTO = result[i++].Value?.ToString();
            dta.V0HCON_PRMTOTAL = result[i++].Value?.ToString();

            return dta;
        }

    }
}