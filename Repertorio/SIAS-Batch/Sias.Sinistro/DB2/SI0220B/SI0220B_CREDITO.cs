using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0220B
{
    public class SI0220B_CREDITO : QueryBasis<SI0220B_CREDITO>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0220B_CREDITO() { IsCursor = true; }

        public SI0220B_CREDITO(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string APOLICRE_PROPRIET { get; set; }
        public string APOLICRE_CGCCPF { get; set; }
        public string APOLICRE_NUM_FATURA { get; set; }
        public string APOLICRE_DATA_INIVIGENCIA { get; set; }
        public string APOLICRE_TIMESTAMP { get; set; }

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


        public override SI0220B_CREDITO OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0220B_CREDITO();
            var i = 0;

            dta.APOLICRE_PROPRIET = result[i++].Value?.ToString();
            dta.APOLICRE_CGCCPF = result[i++].Value?.ToString();
            dta.APOLICRE_NUM_FATURA = result[i++].Value?.ToString();
            dta.APOLICRE_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.APOLICRE_TIMESTAMP = result[i++].Value?.ToString();

            return dta;
        }

    }
}