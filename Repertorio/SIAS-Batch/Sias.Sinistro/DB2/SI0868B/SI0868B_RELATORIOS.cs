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
    public class SI0868B_RELATORIOS : QueryBasis<SI0868B_RELATORIOS>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0868B_RELATORIOS() { IsCursor = true; }

        public SI0868B_RELATORIOS(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string RELATORI_COD_USUARIO { get; set; }
        public string RELATORI_DATA_SOLICITACAO { get; set; }
        public string RELATORI_PERI_FINAL { get; set; }
        public string RELATORI_RAMO_EMISSOR { get; set; }

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


        public override SI0868B_RELATORIOS OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0868B_RELATORIOS();
            var i = 0;

            dta.RELATORI_COD_USUARIO = result[i++].Value?.ToString();
            dta.RELATORI_DATA_SOLICITACAO = result[i++].Value?.ToString();
            dta.RELATORI_PERI_FINAL = result[i++].Value?.ToString();
            dta.RELATORI_RAMO_EMISSOR = result[i++].Value?.ToString();

            return dta;
        }

    }
}