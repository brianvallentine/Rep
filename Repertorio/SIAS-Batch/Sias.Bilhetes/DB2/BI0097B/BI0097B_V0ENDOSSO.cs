using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0097B
{
    public class BI0097B_V0ENDOSSO : QueryBasis<BI0097B_V0ENDOSSO>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public BI0097B_V0ENDOSSO() { IsCursor = true; }

        public BI0097B_V0ENDOSSO(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string ENDOSSOS_NUM_APOLICE { get; set; }
        public string WSHOST_COUNT { get; set; }
        public string VIND_COUNT { get; set; }
        public string PARCEHIS_DATA_VENCIMENTO { get; set; }

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


        public override BI0097B_V0ENDOSSO OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new BI0097B_V0ENDOSSO();
            var i = 0;

            dta.ENDOSSOS_NUM_APOLICE = result[i++].Value?.ToString();
            dta.WSHOST_COUNT = result[i++].Value?.ToString();
            dta.VIND_COUNT = string.IsNullOrWhiteSpace(dta.WSHOST_COUNT) ? "-1" : "0";
            dta.PARCEHIS_DATA_VENCIMENTO = result[i++].Value?.ToString();

            return dta;
        }

    }
}