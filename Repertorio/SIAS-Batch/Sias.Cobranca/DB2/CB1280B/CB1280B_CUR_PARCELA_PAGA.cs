using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB1280B
{
    public class CB1280B_CUR_PARCELA_PAGA : QueryBasis<CB1280B_CUR_PARCELA_PAGA>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public CB1280B_CUR_PARCELA_PAGA() { IsCursor = true; }

        public CB1280B_CUR_PARCELA_PAGA(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string CBAPOVIG_NUM_APOLICE { get; set; }
        public string CBAPOVIG_NUM_ENDOSSO { get; set; }
        public string CBAPOVIG_NUM_PARCELA { get; set; }

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


        public override CB1280B_CUR_PARCELA_PAGA OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new CB1280B_CUR_PARCELA_PAGA();
            var i = 0;

            dta.CBAPOVIG_NUM_APOLICE = result[i++].Value?.ToString();
            dta.CBAPOVIG_NUM_ENDOSSO = result[i++].Value?.ToString();
            dta.CBAPOVIG_NUM_PARCELA = result[i++].Value?.ToString();

            return dta;
        }

    }
}