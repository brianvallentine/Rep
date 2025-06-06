using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0106B
{
    public class VG0106B_V1FATURCONT : QueryBasis<VG0106B_V1FATURCONT>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VG0106B_V1FATURCONT() { IsCursor = true; }

        public VG0106B_V1FATURCONT(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V1FATC_NUM_APOL { get; set; }
        public string V1FATC_COD_SUBG { get; set; }
        public string V1FATC_DATA_REFER { get; set; }

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


        public override VG0106B_V1FATURCONT OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VG0106B_V1FATURCONT();
            var i = 0;

            dta.V1FATC_NUM_APOL = result[i++].Value?.ToString();
            dta.V1FATC_COD_SUBG = result[i++].Value?.ToString();
            dta.V1FATC_DATA_REFER = result[i++].Value?.ToString();

            return dta;
        }

    }
}