using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0065B
{
    public class CB0065B_V0MOVDEBCE : QueryBasis<CB0065B_V0MOVDEBCE>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public CB0065B_V0MOVDEBCE() { IsCursor = true; }

        public CB0065B_V0MOVDEBCE(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string MOVDEBCE_NUM_APOLICE { get; set; }
        public string MOVDEBCE_NUM_ENDOSSO { get; set; }
        public string MOVDEBCE_NUM_PARCELA { get; set; }
        public string MOVDEBCE_SITUACAO_COBRANCA { get; set; }
        public string MOVDEBCE_DATA_VENCIMENTO { get; set; }
        public string MOVDEBCE_VALOR_DEBITO { get; set; }
        public string MOVDEBCE_COD_AGENCIA_DEB { get; set; }
        public string MOVDEBCE_OPER_CONTA_DEB { get; set; }
        public string MOVDEBCE_NUM_CONTA_DEB { get; set; }
        public string MOVDEBCE_DIG_CONTA_DEB { get; set; }
        public string APOLICES_ORGAO_EMISSOR { get; set; }
        public string ENDOSSOS_COD_PRODUTO { get; set; }

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


        public override CB0065B_V0MOVDEBCE OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new CB0065B_V0MOVDEBCE();
            var i = 0;

            dta.MOVDEBCE_NUM_APOLICE = result[i++].Value?.ToString();
            dta.MOVDEBCE_NUM_ENDOSSO = result[i++].Value?.ToString();
            dta.MOVDEBCE_NUM_PARCELA = result[i++].Value?.ToString();
            dta.MOVDEBCE_SITUACAO_COBRANCA = result[i++].Value?.ToString();
            dta.MOVDEBCE_DATA_VENCIMENTO = result[i++].Value?.ToString();
            dta.MOVDEBCE_VALOR_DEBITO = result[i++].Value?.ToString();
            dta.MOVDEBCE_COD_AGENCIA_DEB = result[i++].Value?.ToString();
            dta.MOVDEBCE_OPER_CONTA_DEB = result[i++].Value?.ToString();
            dta.MOVDEBCE_NUM_CONTA_DEB = result[i++].Value?.ToString();
            dta.MOVDEBCE_DIG_CONTA_DEB = result[i++].Value?.ToString();
            dta.APOLICES_ORGAO_EMISSOR = result[i++].Value?.ToString();
            dta.ENDOSSOS_COD_PRODUTO = result[i++].Value?.ToString();

            return dta;
        }

    }
}