using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0094B
{
    public class BI0094B_C3_EXP_PRD : QueryBasis<BI0094B_C3_EXP_PRD>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public BI0094B_C3_EXP_PRD() { IsCursor = true; }

        public BI0094B_C3_EXP_PRD(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string BILHETE_NUM_BILHETE { get; set; }
        public string ENDOSSOS_COD_PRODUTO { get; set; }

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


        public override BI0094B_C3_EXP_PRD OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new BI0094B_C3_EXP_PRD();
            var i = 0;

            dta.BILHETE_NUM_BILHETE = result[i++].Value?.ToString();
            dta.ENDOSSOS_COD_PRODUTO = result[i++].Value?.ToString();

            return dta;
        }

    }
}