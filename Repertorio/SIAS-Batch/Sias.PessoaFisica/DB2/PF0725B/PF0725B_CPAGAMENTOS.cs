using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0725B
{
    public class PF0725B_CPAGAMENTOS : QueryBasis<PF0725B_CPAGAMENTOS>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public PF0725B_CPAGAMENTOS() { IsCursor = true; }

        public PF0725B_CPAGAMENTOS(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string PARCEHIS_NUM_APOLICE { get; set; }
        public string W_PARC_ENDO { get; set; }
        public string PARCEHIS_DATA_MOVIMENTO { get; set; }
        public string PARCEHIS_COD_OPERACAO { get; set; }
        public string PARCEHIS_PRM_TOTAL { get; set; }
        public string BILHETE_NUM_BILHETE { get; set; }
        public string BILHETE_RAMO { get; set; }

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


        public override PF0725B_CPAGAMENTOS OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new PF0725B_CPAGAMENTOS();
            var i = 0;

            dta.PARCEHIS_NUM_APOLICE = result[i++].Value?.ToString();
            dta.W_PARC_ENDO = result[i++].Value?.ToString();
            dta.PARCEHIS_DATA_MOVIMENTO = result[i++].Value?.ToString();
            dta.PARCEHIS_COD_OPERACAO = result[i++].Value?.ToString();
            dta.PARCEHIS_PRM_TOTAL = result[i++].Value?.ToString();
            dta.BILHETE_NUM_BILHETE = result[i++].Value?.ToString();
            dta.BILHETE_RAMO = result[i++].Value?.ToString();

            return dta;
        }

    }
}