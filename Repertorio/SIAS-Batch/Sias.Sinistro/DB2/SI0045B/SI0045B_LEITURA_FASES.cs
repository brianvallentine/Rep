using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0045B
{
    public class SI0045B_LEITURA_FASES : QueryBasis<SI0045B_LEITURA_FASES>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0045B_LEITURA_FASES() { IsCursor = true; }

        public SI0045B_LEITURA_FASES(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string SIREFAEV_COD_FASE { get; set; }
        public string SIREFAEV_DATA_INIVIG_REFAEV { get; set; }
        public string SIREFAEV_IND_ALTERACAO_FASE { get; set; }

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


        public override SI0045B_LEITURA_FASES OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0045B_LEITURA_FASES();
            var i = 0;

            dta.SIREFAEV_COD_FASE = result[i++].Value?.ToString();
            dta.SIREFAEV_DATA_INIVIG_REFAEV = result[i++].Value?.ToString();
            dta.SIREFAEV_IND_ALTERACAO_FASE = result[i++].Value?.ToString();

            return dta;
        }

    }
}