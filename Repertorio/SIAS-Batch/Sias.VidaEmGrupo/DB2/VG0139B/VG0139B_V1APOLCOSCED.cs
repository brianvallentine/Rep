using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0139B
{
    public class VG0139B_V1APOLCOSCED : QueryBasis<VG0139B_V1APOLCOSCED>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VG0139B_V1APOLCOSCED() { IsCursor = true; }

        public VG0139B_V1APOLCOSCED(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V1COSP_CONGENER { get; set; }

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


        public override VG0139B_V1APOLCOSCED OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VG0139B_V1APOLCOSCED();
            var i = 0;

            dta.V1COSP_CONGENER = result[i++].Value?.ToString();

            return dta;
        }

    }
}