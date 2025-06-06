using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA2513B
{
    public class VA2513B_CMSG : QueryBasis<VA2513B_CMSG>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VA2513B_CMSG() { IsCursor = true; }

        public VA2513B_CMSG(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0MENS_APOLICE { get; set; }
        public string V0MENS_CODSUBES { get; set; }
        public string V0MENS_CODOPER { get; set; }
        public string V0MENS_JDE { get; set; }
        public string V0MENS_JDL { get; set; }

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


        public override VA2513B_CMSG OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VA2513B_CMSG();
            var i = 0;

            dta.V0MENS_APOLICE = result[i++].Value?.ToString();
            dta.V0MENS_CODSUBES = result[i++].Value?.ToString();
            dta.V0MENS_CODOPER = result[i++].Value?.ToString();
            dta.V0MENS_JDE = result[i++].Value?.ToString();
            dta.V0MENS_JDL = result[i++].Value?.ToString();

            return dta;
        }

    }
}