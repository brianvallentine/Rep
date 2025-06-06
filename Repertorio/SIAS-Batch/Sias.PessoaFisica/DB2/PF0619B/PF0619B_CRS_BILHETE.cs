using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0619B
{
    public class PF0619B_CRS_BILHETE : QueryBasis<PF0619B_CRS_BILHETE>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public PF0619B_CRS_BILHETE() { IsCursor = true; }

        public PF0619B_CRS_BILHETE(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string DCLPROPOSTA_FIDELIZ_NUM_PROPOSTA_SIVPF { get; set; }
        public string DCLPROPOSTA_FIDELIZ_NUM_SICOB { get; set; }

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


        public override PF0619B_CRS_BILHETE OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new PF0619B_CRS_BILHETE();
            var i = 0;

            dta.DCLPROPOSTA_FIDELIZ_NUM_PROPOSTA_SIVPF = result[i++].Value?.ToString();
            dta.DCLPROPOSTA_FIDELIZ_NUM_SICOB = result[i++].Value?.ToString();

            return dta;
        }

    }
}