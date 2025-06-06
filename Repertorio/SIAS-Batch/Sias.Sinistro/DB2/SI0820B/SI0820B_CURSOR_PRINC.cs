using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0820B
{
    public class SI0820B_CURSOR_PRINC : QueryBasis<SI0820B_CURSOR_PRINC>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0820B_CURSOR_PRINC() { IsCursor = true; }

        public SI0820B_CURSOR_PRINC(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0AGEN_COD_ESCNEG { get; set; }
        public string V0CRED_COD_SUREG { get; set; }
        public string V0CRED_COD_AGENCIA { get; set; }
        public string V0CRED_CODOPER { get; set; }
        public string V0CRED_NUM_CONTRATO { get; set; }
        public string V0CRED_CONTRATO_DIGITO { get; set; }
        public string V0CRED_DTINIVIG { get; set; }
        public string V0CRED_DTTERVIG { get; set; }
        public string V0CRED_NUM_APOLICE { get; set; }
        public string V0CRED_VAL_PREMIO { get; set; }
        public string W_V0CRED_QTD_DIAS_VIGENCIA { get; set; }

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


        public override SI0820B_CURSOR_PRINC OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0820B_CURSOR_PRINC();
            var i = 0;

            dta.V0AGEN_COD_ESCNEG = result[i++].Value?.ToString();
            dta.V0CRED_COD_SUREG = result[i++].Value?.ToString();
            dta.V0CRED_COD_AGENCIA = result[i++].Value?.ToString();
            dta.V0CRED_CODOPER = result[i++].Value?.ToString();
            dta.V0CRED_NUM_CONTRATO = result[i++].Value?.ToString();
            dta.V0CRED_CONTRATO_DIGITO = result[i++].Value?.ToString();
            dta.V0CRED_DTINIVIG = result[i++].Value?.ToString();
            dta.V0CRED_DTTERVIG = result[i++].Value?.ToString();
            dta.V0CRED_NUM_APOLICE = result[i++].Value?.ToString();
            dta.V0CRED_VAL_PREMIO = result[i++].Value?.ToString();
            dta.W_V0CRED_QTD_DIAS_VIGENCIA = result[i++].Value?.ToString();

            return dta;
        }

    }
}