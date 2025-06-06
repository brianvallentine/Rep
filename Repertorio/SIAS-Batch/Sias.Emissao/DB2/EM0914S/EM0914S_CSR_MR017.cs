using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0914S
{
    public class EM0914S_CSR_MR017 : QueryBasis<EM0914S_CSR_MR017>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public EM0914S_CSR_MR017() { IsCursor = true; }

        public EM0914S_CSR_MR017(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string MR017_COD_FONTE { get; set; }
        public string MR017_NUM_PROPOSTA { get; set; }
        public string MR017_NUM_ITEM { get; set; }
        public string MR017_NUM_SUB_ITEM { get; set; }
        public string MR017_COD_RUBRICA { get; set; }
        public string MR017_COD_SUB_RUBRICA { get; set; }
        public string MR017_PCT_DESC_COBERTURA { get; set; }
        public string MR017_PCT_DESC_CORRETOR { get; set; }
        public string MR017_PCT_BONUS_RENOV { get; set; }
        public string MR017_COD_BENEFICIARIO { get; set; }
        public string WSNULL_COD_EMP { get; set; }
        public string MR017_DES_CLAUSULA_BENEF { get; set; }
        public string WSNULL_DES_EMP { get; set; }

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


        public override EM0914S_CSR_MR017 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new EM0914S_CSR_MR017();
            var i = 0;

            dta.MR017_COD_FONTE = result[i++].Value?.ToString();
            dta.MR017_NUM_PROPOSTA = result[i++].Value?.ToString();
            dta.MR017_NUM_ITEM = result[i++].Value?.ToString();
            dta.MR017_NUM_SUB_ITEM = result[i++].Value?.ToString();
            dta.MR017_COD_RUBRICA = result[i++].Value?.ToString();
            dta.MR017_COD_SUB_RUBRICA = result[i++].Value?.ToString();
            dta.MR017_PCT_DESC_COBERTURA = result[i++].Value?.ToString();
            dta.MR017_PCT_DESC_CORRETOR = result[i++].Value?.ToString();
            dta.MR017_PCT_BONUS_RENOV = result[i++].Value?.ToString();
            dta.MR017_COD_BENEFICIARIO = result[i++].Value?.ToString();
            dta.WSNULL_COD_EMP = string.IsNullOrWhiteSpace(dta.MR017_COD_BENEFICIARIO) ? "-1" : "0";
            dta.MR017_DES_CLAUSULA_BENEF = result[i++].Value?.ToString();
            dta.WSNULL_DES_EMP = string.IsNullOrWhiteSpace(dta.MR017_DES_CLAUSULA_BENEF) ? "-1" : "0";

            return dta;
        }

    }
}