using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0617B
{
    public class PF0617B_DTHBILHETE : QueryBasis<PF0617B_DTHBILHETE>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public PF0617B_DTHBILHETE() { IsCursor = true; }

        public PF0617B_DTHBILHETE(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string WS_DTH_BILHETE { get; set; }

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


        public override PF0617B_DTHBILHETE OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new PF0617B_DTHBILHETE();
            var i = 0;

            dta.WS_DTH_BILHETE = result[i++].Value?.ToString();

            return dta;
        }

    }
}