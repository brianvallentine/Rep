using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0139B
{
    public class VA0139B_CHISTCTBL : QueryBasis<VA0139B_CHISTCTBL>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VA0139B_CHISTCTBL() { IsCursor = true; }

        public VA0139B_CHISTCTBL(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0HCTB_SITUACAO { get; set; }
        public string V0HCTB_NUM_APOLICE { get; set; }
        public string V0HCTB_CODSUBES { get; set; }
        public string V0HCTB_FONTE { get; set; }
        public string V0HCTB_PRMVG { get; set; }
        public string V0HCTB_PRMAP { get; set; }
        public string V0HCTB_CODOPER { get; set; }
        public string V0HCTB_NRCERTIF { get; set; }
        public string V0HCTB_NRPARCEL { get; set; }
        public string V0HCTB_NRTIT { get; set; }
        public string V0HCTB_OCORHIST { get; set; }
        public string V0HCTB_DTMOVTO { get; set; }

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


        public override VA0139B_CHISTCTBL OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VA0139B_CHISTCTBL();
            var i = 0;

            dta.V0HCTB_SITUACAO = result[i++].Value?.ToString();
            dta.V0HCTB_NUM_APOLICE = result[i++].Value?.ToString();
            dta.V0HCTB_CODSUBES = result[i++].Value?.ToString();
            dta.V0HCTB_FONTE = result[i++].Value?.ToString();
            dta.V0HCTB_PRMVG = result[i++].Value?.ToString();
            dta.V0HCTB_PRMAP = result[i++].Value?.ToString();
            dta.V0HCTB_CODOPER = result[i++].Value?.ToString();
            dta.V0HCTB_NRCERTIF = result[i++].Value?.ToString();
            dta.V0HCTB_NRPARCEL = result[i++].Value?.ToString();
            dta.V0HCTB_NRTIT = result[i++].Value?.ToString();
            dta.V0HCTB_OCORHIST = result[i++].Value?.ToString();
            dta.V0HCTB_DTMOVTO = result[i++].Value?.ToString();

            return dta;
        }

    }
}