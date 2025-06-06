using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI5001B
{
    public class SI5001B_C01_MOVDEBCE : QueryBasis<SI5001B_C01_MOVDEBCE>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI5001B_C01_MOVDEBCE() { IsCursor = true; }

        public SI5001B_C01_MOVDEBCE(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string MOVDEBCE_NUM_APOLICE { get; set; }
        public string MOVDEBCE_NUM_ENDOSSO { get; set; }
        public string MOVDEBCE_NUM_PARCELA { get; set; }
        public string MOVDEBCE_COD_CONVENIO { get; set; }
        public string MOVDEBCE_COD_AGENCIA_DEB { get; set; }
        public string MOVDEBCE_OPER_CONTA_DEB { get; set; }
        public string MOVDEBCE_NUM_CONTA_DEB { get; set; }
        public string MOVDEBCE_DIG_CONTA_DEB { get; set; }
        public string MOVDEBCE_DATA_VENCIMENTO { get; set; }
        public string MOVDEBCE_DATA_MOVIMENTO { get; set; }
        public string MOVDEBCE_VALOR_DEBITO { get; set; }
        public string MOVDEBCE_VLR_CREDITO { get; set; }
        public string MOVDEBCE_SITUACAO_COBRANCA { get; set; }
        public string MOVDEBCE_COD_EMPRESA { get; set; }

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


        public override SI5001B_C01_MOVDEBCE OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI5001B_C01_MOVDEBCE();
            var i = 0;

            dta.MOVDEBCE_NUM_APOLICE = result[i++].Value?.ToString();
            dta.MOVDEBCE_NUM_ENDOSSO = result[i++].Value?.ToString();
            dta.MOVDEBCE_NUM_PARCELA = result[i++].Value?.ToString();
            dta.MOVDEBCE_COD_CONVENIO = result[i++].Value?.ToString();
            dta.MOVDEBCE_COD_AGENCIA_DEB = result[i++].Value?.ToString();
            dta.MOVDEBCE_OPER_CONTA_DEB = result[i++].Value?.ToString();
            dta.MOVDEBCE_NUM_CONTA_DEB = result[i++].Value?.ToString();
            dta.MOVDEBCE_DIG_CONTA_DEB = result[i++].Value?.ToString();
            dta.MOVDEBCE_DATA_VENCIMENTO = result[i++].Value?.ToString();
            dta.MOVDEBCE_DATA_MOVIMENTO = result[i++].Value?.ToString();
            dta.MOVDEBCE_VALOR_DEBITO = result[i++].Value?.ToString();
            dta.MOVDEBCE_VLR_CREDITO = result[i++].Value?.ToString();
            dta.MOVDEBCE_SITUACAO_COBRANCA = result[i++].Value?.ToString();
            dta.MOVDEBCE_COD_EMPRESA = result[i++].Value?.ToString();

            return dta;
        }

    }
}