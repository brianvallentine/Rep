using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.FN0301B
{
    public class FN0301B_V1AUTOAPOL : QueryBasis<FN0301B_V1AUTOAPOL>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public FN0301B_V1AUTOAPOL() { IsCursor = true; }

        public FN0301B_V1AUTOAPOL(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V1AUTO_FONTE { get; set; }
        public string V1AUTO_NRPROPOS { get; set; }
        public string V1AUTO_NRITEM { get; set; }
        public string V1AUTO_CDVEICL { get; set; }
        public string V1AUTO_ANOVEICL { get; set; }
        public string V1AUTO_ANOMOD { get; set; }
        public string V1AUTO_CHASSIS { get; set; }
        public string V1AUTO_COMBUST { get; set; }
        public string V1AUTO_PLACALET { get; set; }
        public string V1AUTO_PLACANR { get; set; }
        public string V1AUTO_PLACAUF { get; set; }

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


        public override FN0301B_V1AUTOAPOL OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new FN0301B_V1AUTOAPOL();
            var i = 0;

            dta.V1AUTO_FONTE = result[i++].Value?.ToString();
            dta.V1AUTO_NRPROPOS = result[i++].Value?.ToString();
            dta.V1AUTO_NRITEM = result[i++].Value?.ToString();
            dta.V1AUTO_CDVEICL = result[i++].Value?.ToString();
            dta.V1AUTO_ANOVEICL = result[i++].Value?.ToString();
            dta.V1AUTO_ANOMOD = result[i++].Value?.ToString();
            dta.V1AUTO_CHASSIS = result[i++].Value?.ToString();
            dta.V1AUTO_COMBUST = result[i++].Value?.ToString();
            dta.V1AUTO_PLACALET = result[i++].Value?.ToString();
            dta.V1AUTO_PLACANR = result[i++].Value?.ToString();
            dta.V1AUTO_PLACAUF = result[i++].Value?.ToString();

            return dta;
        }

    }
}