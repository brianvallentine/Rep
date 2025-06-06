using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0078B
{
    public class BI0078B_CBILRENOV : QueryBasis<BI0078B_CBILRENOV>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public BI0078B_CBILRENOV() { IsCursor = true; }

        public BI0078B_CBILRENOV(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string BILHETE_NUM_BILHETE { get; set; }
        public string BILCOBER_COD_PRODUTO { get; set; }
        public string BILCOBER_VAL_MAX_COBER_BAS { get; set; }
        public string PARAMGER_COD_EMPRESA_CAP { get; set; }

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


        public override BI0078B_CBILRENOV OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new BI0078B_CBILRENOV();
            var i = 0;

            dta.BILHETE_NUM_BILHETE = result[i++].Value?.ToString();
            dta.BILCOBER_COD_PRODUTO = result[i++].Value?.ToString();
            dta.BILCOBER_VAL_MAX_COBER_BAS = result[i++].Value?.ToString();
            dta.PARAMGER_COD_EMPRESA_CAP = result[i++].Value?.ToString();

            return dta;
        }

    }
}