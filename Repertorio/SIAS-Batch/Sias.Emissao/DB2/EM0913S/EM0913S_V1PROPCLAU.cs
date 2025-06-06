using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0913S
{
    public class EM0913S_V1PROPCLAU : QueryBasis<EM0913S_V1PROPCLAU>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public EM0913S_V1PROPCLAU() { IsCursor = true; }

        public EM0913S_V1PROPCLAU(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string PROPOCLA_COD_EMPRESA { get; set; }
        public string PROPOCLA_RAMO_COBERTURA { get; set; }
        public string PROPOCLA_MODALI_COBERTURA { get; set; }
        public string PROPOCLA_COD_COBERTURA { get; set; }
        public string PROPOCLA_DATA_INIVIGENCIA { get; set; }
        public string PROPOCLA_DATA_TERVIGENCIA { get; set; }
        public string PROPOCLA_NUM_ITEM { get; set; }
        public string PROPOCLA_COD_CLAUSULA { get; set; }
        public string PROPOCLA_LIMITE_INDENIZA_IX { get; set; }
        public string PROPOCLA_TIPO_CLAUSULA { get; set; }

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


        public override EM0913S_V1PROPCLAU OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new EM0913S_V1PROPCLAU();
            var i = 0;

            dta.PROPOCLA_COD_EMPRESA = result[i++].Value?.ToString();
            dta.PROPOCLA_RAMO_COBERTURA = result[i++].Value?.ToString();
            dta.PROPOCLA_MODALI_COBERTURA = result[i++].Value?.ToString();
            dta.PROPOCLA_COD_COBERTURA = result[i++].Value?.ToString();
            dta.PROPOCLA_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.PROPOCLA_DATA_TERVIGENCIA = result[i++].Value?.ToString();
            dta.PROPOCLA_NUM_ITEM = result[i++].Value?.ToString();
            dta.PROPOCLA_COD_CLAUSULA = result[i++].Value?.ToString();
            dta.PROPOCLA_LIMITE_INDENIZA_IX = result[i++].Value?.ToString();
            dta.PROPOCLA_TIPO_CLAUSULA = result[i++].Value?.ToString();

            return dta;
        }

    }
}