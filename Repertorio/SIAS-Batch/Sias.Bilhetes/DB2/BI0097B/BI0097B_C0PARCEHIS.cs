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
    public class BI0097B_C0PARCEHIS : QueryBasis<BI0097B_C0PARCEHIS>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public BI0097B_C0PARCEHIS() { IsCursor = true; }

        public BI0097B_C0PARCEHIS(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string PARCEHIS_NUM_APOLICE { get; set; }
        public string PARCEHIS_NUM_ENDOSSO { get; set; }
        public string PARCEHIS_NUM_PARCELA { get; set; }

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


        public override BI0097B_C0PARCEHIS OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new BI0097B_C0PARCEHIS();
            var i = 0;

            dta.PARCEHIS_NUM_APOLICE = result[i++].Value?.ToString();
            dta.PARCEHIS_NUM_ENDOSSO = result[i++].Value?.ToString();
            dta.PARCEHIS_NUM_PARCELA = result[i++].Value?.ToString();

            return dta;
        }

    }
}