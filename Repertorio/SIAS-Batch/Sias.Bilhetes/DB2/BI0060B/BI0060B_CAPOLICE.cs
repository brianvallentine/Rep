using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0060B
{
    public class BI0060B_CAPOLICE : QueryBasis<BI0060B_CAPOLICE>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public BI0060B_CAPOLICE() { IsCursor = true; }

        public BI0060B_CAPOLICE(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string APOLICES_NUM_BILHETE { get; set; }
        public string APOLICES_COD_CLIENTE { get; set; }
        public string ENDOSSOS_COD_FONTE { get; set; }
        public string ENDOSSOS_OCORR_ENDERECO { get; set; }
        public string ENDOSSOS_AGE_RCAP { get; set; }
        public string TITFEDCA_NRSORTEIO { get; set; }
        public string APOLICES_COD_PRODUTO { get; set; }

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


        public override BI0060B_CAPOLICE OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new BI0060B_CAPOLICE();
            var i = 0;

            dta.APOLICES_NUM_BILHETE = result[i++].Value?.ToString();
            dta.APOLICES_COD_CLIENTE = result[i++].Value?.ToString();
            dta.ENDOSSOS_COD_FONTE = result[i++].Value?.ToString();
            dta.ENDOSSOS_OCORR_ENDERECO = result[i++].Value?.ToString();
            dta.ENDOSSOS_AGE_RCAP = result[i++].Value?.ToString();
            dta.TITFEDCA_NRSORTEIO = result[i++].Value?.ToString();
            dta.APOLICES_COD_PRODUTO = result[i++].Value?.ToString();

            return dta;
        }

    }
}