using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0141B
{
    public class VA0141B_V0VG082 : QueryBasis<VA0141B_V0VG082>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VA0141B_V0VG082() { IsCursor = true; }

        public VA0141B_V0VG082(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string VG082_NUM_CERTIFICADO { get; set; }
        public string VG082_NUM_PARCELA { get; set; }
        public string VG082_RAMO_EMISSOR { get; set; }
        public string VG082_VLR_PREMIO_RAMO { get; set; }

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


        public override VA0141B_V0VG082 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VA0141B_V0VG082();
            var i = 0;

            dta.VG082_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.VG082_NUM_PARCELA = result[i++].Value?.ToString();
            dta.VG082_RAMO_EMISSOR = result[i++].Value?.ToString();
            dta.VG082_VLR_PREMIO_RAMO = result[i++].Value?.ToString();

            return dta;
        }

    }
}