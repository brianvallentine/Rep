using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0868B
{
    public class SI0868B_C01_FONTES : QueryBasis<SI0868B_C01_FONTES>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0868B_C01_FONTES() { IsCursor = true; }

        public SI0868B_C01_FONTES(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string FONTES_COD_FONTE { get; set; }
        public string FONTES_NOME_FONTE { get; set; }

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


        public override SI0868B_C01_FONTES OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0868B_C01_FONTES();
            var i = 0;

            dta.FONTES_COD_FONTE = result[i++].Value?.ToString();
            dta.FONTES_NOME_FONTE = result[i++].Value?.ToString();

            return dta;
        }

    }
}