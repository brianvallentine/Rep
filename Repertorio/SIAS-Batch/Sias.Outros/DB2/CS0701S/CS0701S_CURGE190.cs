using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.CS0701S
{
    public class CS0701S_CURGE190 : QueryBasis<CS0701S_CURGE190>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public CS0701S_CURGE190() { IsCursor = true; }

        public CS0701S_CURGE190(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string GE190_COD_PARAMETRO { get; set; }
        public string GE190_COD_PRODUTO { get; set; }
        public string GE190_STA_PARAMETRO { get; set; }
        public string GE190_NOM_CLASSE_PARAM { get; set; }
        public string GE190_COD_SISTEMA { get; set; }
        public string GE190_DTA_INI_VIGENCA { get; set; }
        public string GE190_DTA_FIM_VIGENCIA { get; set; }
        public string GE190_DES_PARAMETRO { get; set; }
        public string GE190_IND_TP_PARAMETRO { get; set; }
        public string GE190_VLR_PARAMETRO { get; set; }
        public string GE190_VLR_PARAM_INT { get; set; }
        public string GE190_PCT_PARAMETRO { get; set; }
        public string GE190_VLR_PARAM_TAXA { get; set; }
        public string GE190_DTA_PARAMETRO { get; set; }
        public string GE190_VLR_PARAM_REDUZIDO { get; set; }
        public string GE190_VLR_PARAM_EXTENDIDO { get; set; }

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


        public override CS0701S_CURGE190 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new CS0701S_CURGE190();
            var i = 0;

            dta.GE190_COD_PARAMETRO = result[i++].Value?.ToString();
            dta.GE190_COD_PRODUTO = result[i++].Value?.ToString();
            dta.GE190_STA_PARAMETRO = result[i++].Value?.ToString();
            dta.GE190_NOM_CLASSE_PARAM = result[i++].Value?.ToString();
            dta.GE190_COD_SISTEMA = result[i++].Value?.ToString();
            dta.GE190_DTA_INI_VIGENCA = result[i++].Value?.ToString();
            dta.GE190_DTA_FIM_VIGENCIA = result[i++].Value?.ToString();
            dta.GE190_DES_PARAMETRO = result[i++].Value?.ToString();
            dta.GE190_IND_TP_PARAMETRO = result[i++].Value?.ToString();
            dta.GE190_VLR_PARAMETRO = result[i++].Value?.ToString();
            dta.GE190_VLR_PARAM_INT = result[i++].Value?.ToString();
            dta.GE190_PCT_PARAMETRO = result[i++].Value?.ToString();
            dta.GE190_VLR_PARAM_TAXA = result[i++].Value?.ToString();
            dta.GE190_DTA_PARAMETRO = result[i++].Value?.ToString();
            dta.GE190_VLR_PARAM_REDUZIDO = result[i++].Value?.ToString();
            dta.GE190_VLR_PARAM_EXTENDIDO = result[i++].Value?.ToString();

            return dta;
        }

    }
}