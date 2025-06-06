using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0602B
{
    public class PF0602B_CCBO : QueryBasis<PF0602B_CCBO>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public PF0602B_CCBO() { IsCursor = true; }

        public PF0602B_CCBO(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string DCLCBO_CBO_COD_CBO { get; set; }
        public string DCLCBO_CBO_DESCR_CBO { get; set; }

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


        public override PF0602B_CCBO OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new PF0602B_CCBO();
            var i = 0;

            dta.DCLCBO_CBO_COD_CBO = result[i++].Value?.ToString();
            dta.DCLCBO_CBO_DESCR_CBO = result[i++].Value?.ToString();

            return dta;
        }

    }
}