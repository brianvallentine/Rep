using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.FC0105B
{
    public class FC0105B_C01_CURSOR1 : QueryBasis<FC0105B_C01_CURSOR1>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public FC0105B_C01_CURSOR1() { IsCursor = true; }

        public FC0105B_C01_CURSOR1(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string FC239_NUM_PLANO { get; set; }
        public string FC239_IDE_CLIENTE { get; set; }
        public string FC239_COD_RAMO { get; set; }
        public string FC239_NUM_MOD_PLANO { get; set; }
        public string FC239_QTD_DIAS_CANCELA { get; set; }

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


        public override FC0105B_C01_CURSOR1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new FC0105B_C01_CURSOR1();
            var i = 0;

            dta.FC239_NUM_PLANO = result[i++].Value?.ToString();
            dta.FC239_IDE_CLIENTE = result[i++].Value?.ToString();
            dta.FC239_COD_RAMO = result[i++].Value?.ToString();
            dta.FC239_NUM_MOD_PLANO = result[i++].Value?.ToString();
            dta.FC239_QTD_DIAS_CANCELA = result[i++].Value?.ToString();

            return dta;
        }

    }
}