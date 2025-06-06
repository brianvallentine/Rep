using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0267B
{
    public class VG0267B_CHISTCOB1 : QueryBasis<VG0267B_CHISTCOB1>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VG0267B_CHISTCOB1() { IsCursor = true; }

        public VG0267B_CHISTCOB1(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0HIST_NRCERTIF { get; set; }
        public string V0HIST_NRPARCEL { get; set; }

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


        public override VG0267B_CHISTCOB1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VG0267B_CHISTCOB1();
            var i = 0;

            dta.V0HIST_NRCERTIF = result[i++].Value?.ToString();
            dta.V0HIST_NRPARCEL = result[i++].Value?.ToString();

            return dta;
        }

    }
}