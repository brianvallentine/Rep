using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.RE0002S
{
    public class RE0002S_C01_MRAPOITE : QueryBasis<RE0002S_C01_MRAPOITE>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public RE0002S_C01_MRAPOITE() { IsCursor = true; }

        public RE0002S_C01_MRAPOITE(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string MRAPOITE_NUM_ITEM { get; set; }
        public string MRAPOITE_NUM_VERSAO { get; set; }
        public string MRAPOITE_PCT_DESC_FIDEL { get; set; }

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


        public override RE0002S_C01_MRAPOITE OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new RE0002S_C01_MRAPOITE();
            var i = 0;

            dta.MRAPOITE_NUM_ITEM = result[i++].Value?.ToString();
            dta.MRAPOITE_NUM_VERSAO = result[i++].Value?.ToString();
            dta.MRAPOITE_PCT_DESC_FIDEL = result[i++].Value?.ToString();

            return dta;
        }

    }
}