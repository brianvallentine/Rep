using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0402B
{
    public class PF0402B_HIST_PROP_FIDELIZ : QueryBasis<PF0402B_HIST_PROP_FIDELIZ>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public PF0402B_HIST_PROP_FIDELIZ() { IsCursor = true; }

        public PF0402B_HIST_PROP_FIDELIZ(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string PROPFIDH_DATA_SITUACAO { get; set; }
        public string PROPFIDH_SIT_PROPOSTA { get; set; }

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


        public override PF0402B_HIST_PROP_FIDELIZ OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new PF0402B_HIST_PROP_FIDELIZ();
            var i = 0;

            dta.PROPFIDH_DATA_SITUACAO = result[i++].Value?.ToString();
            dta.PROPFIDH_SIT_PROPOSTA = result[i++].Value?.ToString();

            return dta;
        }

    }
}