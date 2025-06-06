using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0810B
{
    public class AC0810B_C01_COSHISPR : QueryBasis<AC0810B_C01_COSHISPR>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public AC0810B_C01_COSHISPR() { IsCursor = true; }

        public AC0810B_C01_COSHISPR(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string COSHISPR_COD_EMPRESA { get; set; }
        public string COSHISPR_COD_CONGENERE { get; set; }
        public string COSHISPR_NUM_APOLICE { get; set; }
        public string COSHISPR_NUM_ENDOSSO { get; set; }
        public string COSHISPR_NUM_PARCELA { get; set; }
        public string COSHISPR_OCORR_HISTORICO { get; set; }
        public string COSHISPR_COD_OPERACAO { get; set; }
        public string COSHISPR_DATA_MOVIMENTO { get; set; }
        public string COSHISPR_TIPO_SEGURO { get; set; }

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


        public override AC0810B_C01_COSHISPR OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new AC0810B_C01_COSHISPR();
            var i = 0;

            dta.COSHISPR_COD_EMPRESA = result[i++].Value?.ToString();
            dta.COSHISPR_COD_CONGENERE = result[i++].Value?.ToString();
            dta.COSHISPR_NUM_APOLICE = result[i++].Value?.ToString();
            dta.COSHISPR_NUM_ENDOSSO = result[i++].Value?.ToString();
            dta.COSHISPR_NUM_PARCELA = result[i++].Value?.ToString();
            dta.COSHISPR_OCORR_HISTORICO = result[i++].Value?.ToString();
            dta.COSHISPR_COD_OPERACAO = result[i++].Value?.ToString();
            dta.COSHISPR_DATA_MOVIMENTO = result[i++].Value?.ToString();
            dta.COSHISPR_TIPO_SEGURO = result[i++].Value?.ToString();

            return dta;
        }

    }
}