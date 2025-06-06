using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0031B
{
    public class VG0031B_V0SUBGRUPO : QueryBasis<VG0031B_V0SUBGRUPO>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VG0031B_V0SUBGRUPO() { IsCursor = true; }

        public VG0031B_V0SUBGRUPO(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0SUBG_NUM_APOL { get; set; }
        public string V0SUBG_COD_SUBG { get; set; }

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


        public override VG0031B_V0SUBGRUPO OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VG0031B_V0SUBGRUPO();
            var i = 0;

            dta.V0SUBG_NUM_APOL = result[i++].Value?.ToString();
            dta.V0SUBG_COD_SUBG = result[i++].Value?.ToString();

            return dta;
        }

    }
}