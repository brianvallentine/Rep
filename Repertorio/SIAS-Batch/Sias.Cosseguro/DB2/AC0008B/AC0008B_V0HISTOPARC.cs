using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0008B
{
    public class AC0008B_V0HISTOPARC : QueryBasis<AC0008B_V0HISTOPARC>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public AC0008B_V0HISTOPARC() { IsCursor = true; }

        public AC0008B_V0HISTOPARC(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0HISP_NUM_APOL { get; set; }
        public string V0HISP_NRENDOS { get; set; }
        public string V0HISP_NRPARCEL { get; set; }
        public string V0HISP_OCORHIST { get; set; }
        public string V0HISP_OPERACAO { get; set; }
        public string V0HISP_DTMOVTO { get; set; }
        public string V0APOL_RAMO { get; set; }
        public string V0APOL_NUMBIL { get; set; }
        public string V0APOL_PCTCED { get; set; }
        public string V0APOL_QTCOSSEG { get; set; }

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


        public override AC0008B_V0HISTOPARC OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new AC0008B_V0HISTOPARC();
            var i = 0;

            dta.V0HISP_NUM_APOL = result[i++].Value?.ToString();
            dta.V0HISP_NRENDOS = result[i++].Value?.ToString();
            dta.V0HISP_NRPARCEL = result[i++].Value?.ToString();
            dta.V0HISP_OCORHIST = result[i++].Value?.ToString();
            dta.V0HISP_OPERACAO = result[i++].Value?.ToString();
            dta.V0HISP_DTMOVTO = result[i++].Value?.ToString();
            dta.V0APOL_RAMO = result[i++].Value?.ToString();
            dta.V0APOL_NUMBIL = result[i++].Value?.ToString();
            dta.V0APOL_PCTCED = result[i++].Value?.ToString();
            dta.V0APOL_QTCOSSEG = result[i++].Value?.ToString();

            return dta;
        }

    }
}