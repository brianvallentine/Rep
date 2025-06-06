using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB1260B
{
    public class CB1260B_C0PARCELAS : QueryBasis<CB1260B_C0PARCELAS>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public CB1260B_C0PARCELAS() { IsCursor = true; }

        public CB1260B_C0PARCELAS(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string PARCELAS_NUM_APOLICE { get; set; }
        public string PARCELAS_NUM_ENDOSSO { get; set; }
        public string PARCELAS_NUM_TITULO { get; set; }
        public string PARCELAS_NUM_PARCELA { get; set; }
        public string PARCEHIS_DATA_VENCIMENTO { get; set; }
        public string PARCEHIS_PRM_TOTAL { get; set; }
        public string ENDOSSOS_COD_PRODUTO { get; set; }
        public string ENDOSSOS_DATA_INIVIGENCIA { get; set; }
        public string ENDOSSOS_DATA_TERVIGENCIA { get; set; }
        public string ENDOSSOS_QTD_PARCELAS { get; set; }
        public string ENDOSSOS_TIPO_ENDOSSO { get; set; }

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


        public override CB1260B_C0PARCELAS OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new CB1260B_C0PARCELAS();
            var i = 0;

            dta.PARCELAS_NUM_APOLICE = result[i++].Value?.ToString();
            dta.PARCELAS_NUM_ENDOSSO = result[i++].Value?.ToString();
            dta.PARCELAS_NUM_TITULO = result[i++].Value?.ToString();
            dta.PARCELAS_NUM_PARCELA = result[i++].Value?.ToString();
            dta.PARCEHIS_DATA_VENCIMENTO = result[i++].Value?.ToString();
            dta.PARCEHIS_PRM_TOTAL = result[i++].Value?.ToString();
            dta.ENDOSSOS_COD_PRODUTO = result[i++].Value?.ToString();
            dta.ENDOSSOS_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.ENDOSSOS_DATA_TERVIGENCIA = result[i++].Value?.ToString();
            dta.ENDOSSOS_QTD_PARCELAS = result[i++].Value?.ToString();
            dta.ENDOSSOS_TIPO_ENDOSSO = result[i++].Value?.ToString();

            return dta;
        }

    }
}