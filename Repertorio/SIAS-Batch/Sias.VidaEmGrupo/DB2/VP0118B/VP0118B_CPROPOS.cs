using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0118B
{
    public class VP0118B_CPROPOS : QueryBasis<VP0118B_CPROPOS>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VP0118B_CPROPOS() { IsCursor = true; }

        public VP0118B_CPROPOS(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0PROP_NRCERTIF { get; set; }
        public string V0PROP_OCORHIST { get; set; }
        public string V0PROP_CODCLIEN { get; set; }
        public string V0PROP_APOLICE { get; set; }

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


        public override VP0118B_CPROPOS OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VP0118B_CPROPOS();
            var i = 0;

            dta.V0PROP_NRCERTIF = result[i++].Value?.ToString();
            dta.V0PROP_OCORHIST = result[i++].Value?.ToString();
            dta.V0PROP_CODCLIEN = result[i++].Value?.ToString();
            dta.V0PROP_APOLICE = result[i++].Value?.ToString();

            return dta;
        }

    }
}