using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0910S
{
    public class EM0910S_AUPROPCOMPL : QueryBasis<EM0910S_AUPROPCOMPL>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public EM0910S_AUPROPCOMPL() { IsCursor = true; }

        public EM0910S_AUPROPCOMPL(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string AU085_COD_FONTE { get; set; }
        public string AU085_NUM_PROPOSTA { get; set; }
        public string AU085_NUM_ITEM { get; set; }
        public string AU085_COD_PARCEIRO { get; set; }
        public string AU085_COD_PONTO_VENDA { get; set; }
        public string AU085_NUM_CPF_OPERADOR { get; set; }
        public string AU085_STA_RENOVACAO_AUT { get; set; }
        public string AU085_STA_ENVIO_SMS { get; set; }
        public string AU085_STA_ENVIO_EMAIL { get; set; }
        public string AU085_NUM_TOKEN_PGTO { get; set; }
        public string VIND_TOKEN { get; set; }
        public string AU085_IND_FORMA_PAGTO_AD { get; set; }

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


        public override EM0910S_AUPROPCOMPL OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new EM0910S_AUPROPCOMPL();
            var i = 0;

            dta.AU085_COD_FONTE = result[i++].Value?.ToString();
            dta.AU085_NUM_PROPOSTA = result[i++].Value?.ToString();
            dta.AU085_NUM_ITEM = result[i++].Value?.ToString();
            dta.AU085_COD_PARCEIRO = result[i++].Value?.ToString();
            dta.AU085_COD_PONTO_VENDA = result[i++].Value?.ToString();
            dta.AU085_NUM_CPF_OPERADOR = result[i++].Value?.ToString();
            dta.AU085_STA_RENOVACAO_AUT = result[i++].Value?.ToString();
            dta.AU085_STA_ENVIO_SMS = result[i++].Value?.ToString();
            dta.AU085_STA_ENVIO_EMAIL = result[i++].Value?.ToString();
            dta.AU085_NUM_TOKEN_PGTO = result[i++].Value?.ToString();
            dta.VIND_TOKEN = string.IsNullOrWhiteSpace(dta.AU085_NUM_TOKEN_PGTO) ? "-1" : "0";
            dta.AU085_IND_FORMA_PAGTO_AD = result[i++].Value?.ToString();

            return dta;
        }

    }
}