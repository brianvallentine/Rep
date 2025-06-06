using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI2010B
{
    public class SI2010B_V1HISTMEST : QueryBasis<SI2010B_V1HISTMEST>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI2010B_V1HISTMEST() { IsCursor = true; }

        public SI2010B_V1HISTMEST(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string SINISHIS_NOME_FAVORECIDO { get; set; }
        public string SINISMES_NUM_APOLICE { get; set; }
        public string SINISMES_NUM_APOL_SINISTRO { get; set; }
        public string SINISHIS_COD_PRODUTO { get; set; }
        public string SINISHIS_VAL_OPERACAO { get; set; }
        public string SINISHIS_COD_OPERACAO { get; set; }
        public string SINISMES_SIT_REGISTRO { get; set; }
        public string SINISHIS_COD_PREST_SERVICO { get; set; }
        public string SINISHIS_TIPO_FAVORECIDO { get; set; }
        public string SINISHIS_FONTE_PAGAMENTO { get; set; }
        public string SINISHIS_OCORR_HISTORICO { get; set; }

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


        public override SI2010B_V1HISTMEST OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI2010B_V1HISTMEST();
            var i = 0;

            dta.SINISHIS_NOME_FAVORECIDO = result[i++].Value?.ToString();
            dta.SINISMES_NUM_APOLICE = result[i++].Value?.ToString();
            dta.SINISMES_NUM_APOL_SINISTRO = result[i++].Value?.ToString();
            dta.SINISHIS_COD_PRODUTO = result[i++].Value?.ToString();
            dta.SINISHIS_VAL_OPERACAO = result[i++].Value?.ToString();
            dta.SINISHIS_COD_OPERACAO = result[i++].Value?.ToString();
            dta.SINISMES_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.SINISHIS_COD_PREST_SERVICO = result[i++].Value?.ToString();
            dta.SINISHIS_TIPO_FAVORECIDO = result[i++].Value?.ToString();
            dta.SINISHIS_FONTE_PAGAMENTO = result[i++].Value?.ToString();
            dta.SINISHIS_OCORR_HISTORICO = result[i++].Value?.ToString();

            return dta;
        }

    }
}