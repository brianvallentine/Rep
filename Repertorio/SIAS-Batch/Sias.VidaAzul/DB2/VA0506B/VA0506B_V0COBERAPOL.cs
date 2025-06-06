using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0506B
{
    public class VA0506B_V0COBERAPOL : QueryBasis<VA0506B_V0COBERAPOL>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VA0506B_V0COBERAPOL() { IsCursor = true; }

        public VA0506B_V0COBERAPOL(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string APOLICOB_RAMO_COBERTURA { get; set; }
        public string APOLICOB_PCT_COBERTURA { get; set; }

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


        public override VA0506B_V0COBERAPOL OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VA0506B_V0COBERAPOL();
            var i = 0;

            dta.APOLICOB_RAMO_COBERTURA = result[i++].Value?.ToString();
            dta.APOLICOB_PCT_COBERTURA = result[i++].Value?.ToString();

            return dta;
        }

    }
}