using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0600B
{
    public class PF0600B_CSUBGVGA : QueryBasis<PF0600B_CSUBGVGA>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public PF0600B_CSUBGVGA() { IsCursor = true; }

        public PF0600B_CSUBGVGA(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string SUBGVGAP_NUM_APOLICE { get; set; }
        public string SUBGVGAP_DATA_INIVIGENCIA { get; set; }
        public string SUBGVGAP_COD_SUBGRUPO { get; set; }
        public string PRODUVG_NOME_PRODUTO { get; set; }
        public string PRODUVG_PERI_PAGAMENTO { get; set; }
        public string SUBGVGAP_OPCAO_CONJUGE { get; set; }

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


        public override PF0600B_CSUBGVGA OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new PF0600B_CSUBGVGA();
            var i = 0;

            dta.SUBGVGAP_NUM_APOLICE = result[i++].Value?.ToString();
            dta.SUBGVGAP_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.SUBGVGAP_COD_SUBGRUPO = result[i++].Value?.ToString();
            dta.PRODUVG_NOME_PRODUTO = result[i++].Value?.ToString();
            dta.PRODUVG_PERI_PAGAMENTO = result[i++].Value?.ToString();
            dta.SUBGVGAP_OPCAO_CONJUGE = result[i++].Value?.ToString();

            return dta;
        }

    }
}