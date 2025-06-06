using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI7401B
{
    public class BI7401B_V0RELATORI : QueryBasis<BI7401B_V0RELATORI>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public BI7401B_V0RELATORI() { IsCursor = true; }

        public BI7401B_V0RELATORI(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string RELATORI_DATA_SOLICITACAO { get; set; }
        public string RELATORI_IDE_SISTEMA { get; set; }
        public string RELATORI_COD_RELATORIO { get; set; }
        public string RELATORI_QUANTIDADE { get; set; }
        public string RELATORI_RAMO_EMISSOR { get; set; }
        public string RELATORI_NUM_APOLICE { get; set; }
        public string RELATORI_NUM_TITULO { get; set; }
        public string RELATORI_SIT_REGISTRO { get; set; }
        public string RELATORI_IND_PREV_DEFINIT { get; set; }
        public string RELATORI_IND_ANAL_RESUMO { get; set; }

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


        public override BI7401B_V0RELATORI OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new BI7401B_V0RELATORI();
            var i = 0;

            dta.RELATORI_DATA_SOLICITACAO = result[i++].Value?.ToString();
            dta.RELATORI_IDE_SISTEMA = result[i++].Value?.ToString();
            dta.RELATORI_COD_RELATORIO = result[i++].Value?.ToString();
            dta.RELATORI_QUANTIDADE = result[i++].Value?.ToString();
            dta.RELATORI_RAMO_EMISSOR = result[i++].Value?.ToString();
            dta.RELATORI_NUM_APOLICE = result[i++].Value?.ToString();
            dta.RELATORI_NUM_TITULO = result[i++].Value?.ToString();
            dta.RELATORI_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.RELATORI_IND_PREV_DEFINIT = result[i++].Value?.ToString();
            dta.RELATORI_IND_ANAL_RESUMO = result[i++].Value?.ToString();

            return dta;
        }

    }
}