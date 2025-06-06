using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI1630B
{
    public class BI1630B_CUR_AGE : QueryBasis<BI1630B_CUR_AGE>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public BI1630B_CUR_AGE() { IsCursor = true; }

        public BI1630B_CUR_AGE(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string DCLAGENCIAS_CEF_COD_AGENCIA { get; set; }
        public string DCLMALHA_CEF_MALHACEF_COD_FONTE { get; set; }

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


        public override BI1630B_CUR_AGE OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new BI1630B_CUR_AGE();
            var i = 0;

            dta.DCLAGENCIAS_CEF_COD_AGENCIA = result[i++].Value?.ToString();
            dta.DCLMALHA_CEF_MALHACEF_COD_FONTE = result[i++].Value?.ToString();

            return dta;
        }

    }
}