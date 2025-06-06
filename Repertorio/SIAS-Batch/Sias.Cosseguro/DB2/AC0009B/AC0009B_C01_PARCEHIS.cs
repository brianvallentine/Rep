using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0009B
{
    public class AC0009B_C01_PARCEHIS : QueryBasis<AC0009B_C01_PARCEHIS>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public AC0009B_C01_PARCEHIS() { IsCursor = true; }

        public AC0009B_C01_PARCEHIS(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string PARCEHIS_NUM_APOLICE { get; set; }
        public string PARCEHIS_NUM_ENDOSSO { get; set; }
        public string PARCEHIS_NUM_PARCELA { get; set; }
        public string PARCEHIS_DATA_MOVIMENTO { get; set; }
        public string PARCEHIS_COD_OPERACAO { get; set; }
        public string PARCEHIS_OCORR_HISTORICO { get; set; }
        public string PARCEHIS_PRM_TARIFARIO { get; set; }
        public string PARCEHIS_VAL_DESCONTO { get; set; }
        public string PARCEHIS_ADICIONAL_FRACIO { get; set; }
        public string PARCEHIS_DATA_QUITACAO { get; set; }
        public string VIND_DAT_QTBC { get; set; }
        public string PARCEHIS_COD_EMPRESA { get; set; }
        public string VIND_COD_EMPR { get; set; }
        public string APOLICES_TIPO_SEGURO { get; set; }

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


        public override AC0009B_C01_PARCEHIS OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new AC0009B_C01_PARCEHIS();
            var i = 0;

            dta.PARCEHIS_NUM_APOLICE = result[i++].Value?.ToString();
            dta.PARCEHIS_NUM_ENDOSSO = result[i++].Value?.ToString();
            dta.PARCEHIS_NUM_PARCELA = result[i++].Value?.ToString();
            dta.PARCEHIS_DATA_MOVIMENTO = result[i++].Value?.ToString();
            dta.PARCEHIS_COD_OPERACAO = result[i++].Value?.ToString();
            dta.PARCEHIS_OCORR_HISTORICO = result[i++].Value?.ToString();
            dta.PARCEHIS_PRM_TARIFARIO = result[i++].Value?.ToString();
            dta.PARCEHIS_VAL_DESCONTO = result[i++].Value?.ToString();
            dta.PARCEHIS_ADICIONAL_FRACIO = result[i++].Value?.ToString();
            dta.PARCEHIS_DATA_QUITACAO = result[i++].Value?.ToString();
            dta.VIND_DAT_QTBC = string.IsNullOrWhiteSpace(dta.PARCEHIS_DATA_QUITACAO) ? "-1" : "0";
            dta.PARCEHIS_COD_EMPRESA = result[i++].Value?.ToString();
            dta.VIND_COD_EMPR = string.IsNullOrWhiteSpace(dta.PARCEHIS_COD_EMPRESA) ? "-1" : "0";
            dta.APOLICES_TIPO_SEGURO = result[i++].Value?.ToString();

            return dta;
        }

    }
}