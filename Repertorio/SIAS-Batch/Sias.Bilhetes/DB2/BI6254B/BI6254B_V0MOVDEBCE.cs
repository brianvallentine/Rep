using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI6254B
{
    public class BI6254B_V0MOVDEBCE : QueryBasis<BI6254B_V0MOVDEBCE>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public BI6254B_V0MOVDEBCE() { IsCursor = true; }

        public BI6254B_V0MOVDEBCE(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string MOVDEBCE_NUM_APOLICE { get; set; }
        public string MOVDEBCE_NUM_ENDOSSO { get; set; }
        public string MOVDEBCE_NUM_PARCELA { get; set; }
        public string MOVDEBCE_DATA_VENCIMENTO { get; set; }
        public string MOVDEBCE_VALOR_DEBITO { get; set; }
        public string MOVDEBCE_DIA_DEBITO { get; set; }
        public string VIND_DIADEB { get; set; }
        public string MOVDEBCE_NUM_CARTAO { get; set; }
        public string VIND_NUMCARTAO { get; set; }
        public string MOVDEBCE_STATUS_CARTAO { get; set; }
        public string VIND_STATUS { get; set; }

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


        public override BI6254B_V0MOVDEBCE OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new BI6254B_V0MOVDEBCE();
            var i = 0;

            dta.MOVDEBCE_NUM_APOLICE = result[i++].Value?.ToString();
            dta.MOVDEBCE_NUM_ENDOSSO = result[i++].Value?.ToString();
            dta.MOVDEBCE_NUM_PARCELA = result[i++].Value?.ToString();
            dta.MOVDEBCE_DATA_VENCIMENTO = result[i++].Value?.ToString();
            dta.MOVDEBCE_VALOR_DEBITO = result[i++].Value?.ToString();
            dta.MOVDEBCE_DIA_DEBITO = result[i++].Value?.ToString();
            dta.VIND_DIADEB = string.IsNullOrWhiteSpace(dta.MOVDEBCE_DIA_DEBITO) ? "-1" : "0";
            dta.MOVDEBCE_NUM_CARTAO = result[i++].Value?.ToString();
            dta.VIND_NUMCARTAO = string.IsNullOrWhiteSpace(dta.MOVDEBCE_NUM_CARTAO) ? "-1" : "0";
            dta.MOVDEBCE_STATUS_CARTAO = result[i++].Value?.ToString();
            dta.VIND_STATUS = string.IsNullOrWhiteSpace(dta.MOVDEBCE_STATUS_CARTAO) ? "-1" : "0";

            return dta;
        }

    }
}