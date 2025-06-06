using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0812B
{
    public class VA0812B_V1AGENCEF : QueryBasis<VA0812B_V1AGENCEF>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VA0812B_V1AGENCEF() { IsCursor = true; }

        public VA0812B_V1AGENCEF(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V1ACEF_COD_AGENCIA { get; set; }
        public string V1MCEF_COD_FONTE { get; set; }

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


        public override VA0812B_V1AGENCEF OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VA0812B_V1AGENCEF();
            var i = 0;

            dta.V1ACEF_COD_AGENCIA = result[i++].Value?.ToString();
            dta.V1MCEF_COD_FONTE = result[i++].Value?.ToString();

            return dta;
        }

    }
}