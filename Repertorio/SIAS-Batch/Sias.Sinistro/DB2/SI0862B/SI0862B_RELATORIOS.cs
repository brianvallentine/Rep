using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0862B
{
    public class SI0862B_RELATORIOS : QueryBasis<SI0862B_RELATORIOS>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0862B_RELATORIOS() { IsCursor = true; }

        public SI0862B_RELATORIOS(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string RELATORI_COD_USUARIO { get; set; }
        public string RELATORI_DATA_SOLICITACAO { get; set; }
        public string HOST_DATA_INICIAL { get; set; }
        public string HOST_DATA_FINAL { get; set; }
        public string HOST_RAMO_INICIAL { get; set; }
        public string HOST_CODSUBES_INICIAL { get; set; }
        public string HOST_APOLICE { get; set; }
        public string HOST_PRODUTO_INICIAL { get; set; }

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


        public override SI0862B_RELATORIOS OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0862B_RELATORIOS();
            var i = 0;

            dta.RELATORI_COD_USUARIO = result[i++].Value?.ToString();
            dta.RELATORI_DATA_SOLICITACAO = result[i++].Value?.ToString();
            dta.HOST_DATA_INICIAL = result[i++].Value?.ToString();
            dta.HOST_DATA_FINAL = result[i++].Value?.ToString();
            dta.HOST_RAMO_INICIAL = result[i++].Value?.ToString();
            dta.HOST_CODSUBES_INICIAL = result[i++].Value?.ToString();
            dta.HOST_APOLICE = result[i++].Value?.ToString();
            dta.HOST_PRODUTO_INICIAL = result[i++].Value?.ToString();

            return dta;
        }

    }
}