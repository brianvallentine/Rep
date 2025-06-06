using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0503B
{
    public class GE0503B_V0BANCO : QueryBasis<GE0503B_V0BANCO>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public GE0503B_V0BANCO() { IsCursor = true; }

        public GE0503B_V0BANCO(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string OD001_NUM_PESSOA { get; set; }
        public string OD001_DTH_CADASTRAMENTO { get; set; }
        public string OD001_NUM_DV_PESSOA { get; set; }
        public string OD001_IND_PESSOA { get; set; }
        public string OD001_STA_INF_INTEGRA { get; set; }
        public string OD009_SEQ_CONTA_BANCARIA { get; set; }
        public string OD009_DTH_CADASTRAMENTO { get; set; }
        public string OD009_STA_CONTA { get; set; }
        public string OD009_COD_BANCO { get; set; }
        public string OD009_COD_AGENCIA { get; set; }
        public string OD009_IND_CONTA_BANCARIA { get; set; }
        public string OD009_NUM_CONTA { get; set; }
        public string OD009_NUM_DV_CONTA { get; set; }
        public string VIND_NULL01 { get; set; }
        public string OD009_NUM_OPERACAO_CONTA { get; set; }
        public string VIND_NULL02 { get; set; }

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


        public override GE0503B_V0BANCO OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new GE0503B_V0BANCO();
            var i = 0;

            dta.OD001_NUM_PESSOA = result[i++].Value?.ToString();
            dta.OD001_DTH_CADASTRAMENTO = result[i++].Value?.ToString();
            dta.OD001_NUM_DV_PESSOA = result[i++].Value?.ToString();
            dta.OD001_IND_PESSOA = result[i++].Value?.ToString();
            dta.OD001_STA_INF_INTEGRA = result[i++].Value?.ToString();
            dta.OD009_SEQ_CONTA_BANCARIA = result[i++].Value?.ToString();
            dta.OD009_DTH_CADASTRAMENTO = result[i++].Value?.ToString();
            dta.OD009_STA_CONTA = result[i++].Value?.ToString();
            dta.OD009_COD_BANCO = result[i++].Value?.ToString();
            dta.OD009_COD_AGENCIA = result[i++].Value?.ToString();
            dta.OD009_IND_CONTA_BANCARIA = result[i++].Value?.ToString();
            dta.OD009_NUM_CONTA = result[i++].Value?.ToString();
            dta.OD009_NUM_DV_CONTA = result[i++].Value?.ToString();
            dta.VIND_NULL01 = string.IsNullOrWhiteSpace(dta.OD009_NUM_DV_CONTA) ? "-1" : "0";
            dta.OD009_NUM_OPERACAO_CONTA = result[i++].Value?.ToString();
            dta.VIND_NULL02 = string.IsNullOrWhiteSpace(dta.OD009_NUM_OPERACAO_CONTA) ? "-1" : "0";

            return dta;
        }

    }
}