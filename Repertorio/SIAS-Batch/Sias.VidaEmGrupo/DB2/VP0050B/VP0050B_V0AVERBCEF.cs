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
    public class VP0050B_V0AVERBCEF : QueryBasis<VP0050B_V0AVERBCEF>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VP0050B_V0AVERBCEF() { IsCursor = true; }

        public VP0050B_V0AVERBCEF(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0AVER_NRMATRIC { get; set; }
        public string V0AVER_VAL_AVERB { get; set; }
        public string V0AVER_TPMOVTO { get; set; }

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


        public override VP0050B_V0AVERBCEF OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VP0050B_V0AVERBCEF();
            var i = 0;

            dta.V0AVER_NRMATRIC = result[i++].Value?.ToString();
            dta.V0AVER_VAL_AVERB = result[i++].Value?.ToString();
            dta.V0AVER_TPMOVTO = result[i++].Value?.ToString();

            return dta;
        }

    }
}