using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0050B
{
    public class VP0050B_V0FUNCIOCEF : QueryBasis<VP0050B_V0FUNCIOCEF>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VP0050B_V0FUNCIOCEF() { IsCursor = true; }

        public VP0050B_V0FUNCIOCEF(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0FUNC_COD_SUREG { get; set; }
        public string V0FUNC_NRMATRIC { get; set; }

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


        public override VP0050B_V0FUNCIOCEF OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VP0050B_V0FUNCIOCEF();
            var i = 0;

            dta.V0FUNC_COD_SUREG = result[i++].Value?.ToString();
            dta.V0FUNC_NRMATRIC = result[i++].Value?.ToString();

            return dta;
        }

    }
}