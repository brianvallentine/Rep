using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0124B
{
    public class CB0124B_C1_PARC_SRETORNO : QueryBasis<CB0124B_C1_PARC_SRETORNO>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public CB0124B_C1_PARC_SRETORNO() { IsCursor = true; }

        public CB0124B_C1_PARC_SRETORNO(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string WS_NUM_PARC_SR { get; set; }
        public string WS_VLR_PARC_SR { get; set; }

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


        public override CB0124B_C1_PARC_SRETORNO OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new CB0124B_C1_PARC_SRETORNO();
            var i = 0;

            dta.WS_NUM_PARC_SR = result[i++].Value?.ToString();
            dta.WS_VLR_PARC_SR = result[i++].Value?.ToString();

            return dta;
        }

    }
}