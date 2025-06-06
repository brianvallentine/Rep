using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0820B
{
    public class AC0820B_V0COSHISTPRE : QueryBasis<AC0820B_V0COSHISTPRE>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public AC0820B_V0COSHISTPRE() { IsCursor = true; }

        public AC0820B_V0COSHISTPRE(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0CHSP_NUM_APOL { get; set; }
        public string V0CHSP_NRENDOS { get; set; }
        public string V0CHSP_NRPARCEL { get; set; }
        public string V0CHSP_OCORHIST { get; set; }
        public string V0CHSP_DTMOVTO { get; set; }
        public string V0CHSP_OPERACAO { get; set; }
        public string V0CHSP_PRM_TAR { get; set; }
        public string V0CHSP_VAL_DESC { get; set; }
        public string V0CHSP_VLPRMLIQ { get; set; }
        public string V0CHSP_VLADIFRA { get; set; }
        public string V0CHSP_VLCOMIS { get; set; }
        public string V0CHSP_VLPRMTOT { get; set; }

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


        public override AC0820B_V0COSHISTPRE OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new AC0820B_V0COSHISTPRE();
            var i = 0;

            dta.V0CHSP_NUM_APOL = result[i++].Value?.ToString();
            dta.V0CHSP_NRENDOS = result[i++].Value?.ToString();
            dta.V0CHSP_NRPARCEL = result[i++].Value?.ToString();
            dta.V0CHSP_OCORHIST = result[i++].Value?.ToString();
            dta.V0CHSP_DTMOVTO = result[i++].Value?.ToString();
            dta.V0CHSP_OPERACAO = result[i++].Value?.ToString();
            dta.V0CHSP_PRM_TAR = result[i++].Value?.ToString();
            dta.V0CHSP_VAL_DESC = result[i++].Value?.ToString();
            dta.V0CHSP_VLPRMLIQ = result[i++].Value?.ToString();
            dta.V0CHSP_VLADIFRA = result[i++].Value?.ToString();
            dta.V0CHSP_VLCOMIS = result[i++].Value?.ToString();
            dta.V0CHSP_VLPRMTOT = result[i++].Value?.ToString();

            return dta;
        }

    }
}