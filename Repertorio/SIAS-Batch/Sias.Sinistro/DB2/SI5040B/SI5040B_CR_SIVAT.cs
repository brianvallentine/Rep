using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI5040B
{
    public class SI5040B_CR_SIVAT : QueryBasis<SI5040B_CR_SIVAT>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI5040B_CR_SIVAT() { IsCursor = true; }

        public SI5040B_CR_SIVAT(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string CA_IDENT_MOV { get; set; }
        public string CHEQUEMI_TIPO_MOVIMENTO { get; set; }
        public string CHEQUEMI_COD_FONTE { get; set; }
        public string CHEQUEMI_NUM_DOCUMENTO { get; set; }
        public string CHEQUEMI_NOME_FAVORECIDO { get; set; }
        public string CHEQUEMI_VAL_CHEQUE { get; set; }
        public string CHEQUEMI_NUM_CHEQUE_INTERNO { get; set; }
        public string CHEQUEMI_DIG_CHEQUE_INTERNO { get; set; }
        public string CHEQUEMI_PRACA_PAGAMENTO { get; set; }
        public string CHEQUEMI_DATA_LANCAMENTO { get; set; }
        public string RALCHEDO_NUM_DOCUMENTO { get; set; }
        public string RALCHEDO_AGENCIA_CONTRATO { get; set; }
        public string RALCHEDO_AGE_CENTRAL_PROD01 { get; set; }
        public string RALCHEDO_OCORR_HISTORICO { get; set; }
        public string SINISHIS_COD_PRODUTO { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }

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


        public override SI5040B_CR_SIVAT OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI5040B_CR_SIVAT();
            var i = 0;

            dta.CA_IDENT_MOV = result[i++].Value?.ToString();
            dta.CHEQUEMI_TIPO_MOVIMENTO = result[i++].Value?.ToString();
            dta.CHEQUEMI_COD_FONTE = result[i++].Value?.ToString();
            dta.CHEQUEMI_NUM_DOCUMENTO = result[i++].Value?.ToString();
            dta.CHEQUEMI_NOME_FAVORECIDO = result[i++].Value?.ToString();
            dta.CHEQUEMI_VAL_CHEQUE = result[i++].Value?.ToString();
            dta.CHEQUEMI_NUM_CHEQUE_INTERNO = result[i++].Value?.ToString();
            dta.CHEQUEMI_DIG_CHEQUE_INTERNO = result[i++].Value?.ToString();
            dta.CHEQUEMI_PRACA_PAGAMENTO = result[i++].Value?.ToString();
            dta.CHEQUEMI_DATA_LANCAMENTO = result[i++].Value?.ToString();
            dta.RALCHEDO_NUM_DOCUMENTO = result[i++].Value?.ToString();
            dta.RALCHEDO_AGENCIA_CONTRATO = result[i++].Value?.ToString();
            dta.RALCHEDO_AGE_CENTRAL_PROD01 = result[i++].Value?.ToString();
            dta.RALCHEDO_OCORR_HISTORICO = result[i++].Value?.ToString();
            dta.SINISHIS_COD_PRODUTO = result[i++].Value?.ToString();
            dta.SINISHIS_NUM_APOL_SINISTRO = result[i++].Value?.ToString();

            return dta;
        }

    }
}