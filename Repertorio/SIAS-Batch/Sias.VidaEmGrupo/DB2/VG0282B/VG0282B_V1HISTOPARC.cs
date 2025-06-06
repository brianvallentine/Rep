using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0282B
{
    public class VG0282B_V1HISTOPARC : QueryBasis<VG0282B_V1HISTOPARC>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VG0282B_V1HISTOPARC() { IsCursor = true; }

        public VG0282B_V1HISTOPARC(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V1HISP_OPERACAO { get; set; }
        public string V1HISP_DTMOVTO { get; set; }
        public string V1HISP_VLPRMLIQ { get; set; }
        public string V1HISP_DTQITBCO { get; set; }
        public string VIND_DTQITBCO { get; set; }

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


        public override VG0282B_V1HISTOPARC OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VG0282B_V1HISTOPARC();
            var i = 0;

            dta.V1HISP_OPERACAO = result[i++].Value?.ToString();
            dta.V1HISP_DTMOVTO = result[i++].Value?.ToString();
            dta.V1HISP_VLPRMLIQ = result[i++].Value?.ToString();
            dta.V1HISP_DTQITBCO = result[i++].Value?.ToString();
            dta.VIND_DTQITBCO = string.IsNullOrWhiteSpace(dta.V1HISP_DTQITBCO) ? "-1" : "0";

            return dta;
        }

    }
}