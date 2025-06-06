using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.FN0301B
{
    public class FN0301B_V1HISTORES : QueryBasis<FN0301B_V1HISTORES>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public FN0301B_V1HISTORES() { IsCursor = true; }

        public FN0301B_V1HISTORES(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V1HRES_NUMAPOL { get; set; }
        public string V1HRES_NRENDOS { get; set; }
        public string V1HRES_NRITEM { get; set; }
        public string V1HRES_OCORHIST { get; set; }
        public string V1HRES_CODRESSEG { get; set; }
        public string VIND_CODRESSEG { get; set; }
        public string V1HRES_RAMOFR { get; set; }
        public string V1HRES_PCTRSP { get; set; }
        public string V1HRES_PCTCOMRS { get; set; }

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


        public override FN0301B_V1HISTORES OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new FN0301B_V1HISTORES();
            var i = 0;

            dta.V1HRES_NUMAPOL = result[i++].Value?.ToString();
            dta.V1HRES_NRENDOS = result[i++].Value?.ToString();
            dta.V1HRES_NRITEM = result[i++].Value?.ToString();
            dta.V1HRES_OCORHIST = result[i++].Value?.ToString();
            dta.V1HRES_CODRESSEG = result[i++].Value?.ToString();
            dta.VIND_CODRESSEG = string.IsNullOrWhiteSpace(dta.V1HRES_CODRESSEG) ? "-1" : "0";
            dta.V1HRES_RAMOFR = result[i++].Value?.ToString();
            dta.V1HRES_PCTRSP = result[i++].Value?.ToString();
            dta.V1HRES_PCTCOMRS = result[i++].Value?.ToString();

            return dta;
        }

    }
}