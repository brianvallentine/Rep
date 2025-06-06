using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.PR0100B
{
    public class PR0100B_V1CODOPER : QueryBasis<PR0100B_V1CODOPER>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public PR0100B_V1CODOPER() { IsCursor = true; }

        public PR0100B_V1CODOPER(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string TCODOPER_OPERACAO { get; set; }
        public string TCODOPER_DESOPR { get; set; }
        public string TCODOPER_TIPROC { get; set; }
        public string TCODOPER_ARENVOLV { get; set; }

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


        public override PR0100B_V1CODOPER OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new PR0100B_V1CODOPER();
            var i = 0;

            dta.TCODOPER_OPERACAO = result[i++].Value?.ToString();
            dta.TCODOPER_DESOPR = result[i++].Value?.ToString();
            dta.TCODOPER_TIPROC = result[i++].Value?.ToString();
            dta.TCODOPER_ARENVOLV = result[i++].Value?.ToString();

            return dta;
        }

    }
}