using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.SPBVG017
{
    public class SPBVG017_SPBVG017_EC001 : QueryBasis<SPBVG017_SPBVG017_EC001>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SPBVG017_SPBVG017_EC001() { IsCursor = true; }

        public SPBVG017_SPBVG017_EC001(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string A_NUM_PROPOSTA { get; set; }
        public string A_NUM_CPF_CNPJ { get; set; }
        public string A_DTH_CADASTRAMENTO { get; set; }
        public string C_COD_PRODUTO { get; set; }
        public string A_STA_DPS_PROPOSTA { get; set; }
        public string B_DES_DPS_PROPOSTA { get; set; }
        public string A_IND_TP_PESSOA { get; set; }
        public string A_IND_TP_SEGURADO { get; set; }
        public string A_NUM_CERTIFICADO { get; set; }
        public string A_VLR_IS { get; set; }
        public string A_VLR_ACUMULO_IS { get; set; }
        public string A_COD_USUARIO { get; set; }
        public string A_NOM_PROGRAMA { get; set; }

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


        public override SPBVG017_SPBVG017_EC001 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SPBVG017_SPBVG017_EC001();
            var i = 0;

            dta.A_NUM_PROPOSTA = result[i++].Value?.ToString();
            dta.A_NUM_CPF_CNPJ = result[i++].Value?.ToString();
            dta.A_DTH_CADASTRAMENTO = result[i++].Value?.ToString();
            dta.C_COD_PRODUTO = result[i++].Value?.ToString();
            dta.A_STA_DPS_PROPOSTA = result[i++].Value?.ToString();
            dta.B_DES_DPS_PROPOSTA = result[i++].Value?.ToString();
            dta.A_IND_TP_PESSOA = result[i++].Value?.ToString();
            dta.A_IND_TP_SEGURADO = result[i++].Value?.ToString();
            dta.A_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.A_VLR_IS = result[i++].Value?.ToString();
            dta.A_VLR_ACUMULO_IS = result[i++].Value?.ToString();
            dta.A_COD_USUARIO = result[i++].Value?.ToString();
            dta.A_NOM_PROGRAMA = result[i++].Value?.ToString();

            return dta;
        }

    }
}