using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GECPB100
{
    public class GECPB100_C12 : QueryBasis<GECPB100_C12>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public GECPB100_C12() { IsCursor = true; }

        public GECPB100_C12(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string GE541_DTA_GERACAO_ARQ { get; set; }
        public string C12_QTD { get; set; }

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


        public override GECPB100_C12 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new GECPB100_C12();
            var i = 0;

            dta.GE541_DTA_GERACAO_ARQ = result[i++].Value?.ToString();
            dta.C12_QTD = result[i++].Value?.ToString();

            return dta;
        }

    }
}