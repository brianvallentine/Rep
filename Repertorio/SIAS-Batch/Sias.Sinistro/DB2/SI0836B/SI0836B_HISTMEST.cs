using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0836B
{
    public class SI0836B_HISTMEST : QueryBasis<SI0836B_HISTMEST>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0836B_HISTMEST() { IsCursor = true; }

        public SI0836B_HISTMEST(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0HISTMEST_FONTE { get; set; }
        public string V0HISTMEST_PROTSINI { get; set; }
        public string V0HISTMEST_DAC { get; set; }
        public string V0HISTMEST_NUM_APOL_SINISTRO { get; set; }
        public string V0HISTMEST_NUM_APOLICE { get; set; }
        public string V0HISTMEST_OPERACAO { get; set; }
        public string V0HISTMEST_VAL_OPERACAO { get; set; }
        public string V0HISTMEST_NOMFAV { get; set; }

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


        public override SI0836B_HISTMEST OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0836B_HISTMEST();
            var i = 0;

            dta.V0HISTMEST_FONTE = result[i++].Value?.ToString();
            dta.V0HISTMEST_PROTSINI = result[i++].Value?.ToString();
            dta.V0HISTMEST_DAC = result[i++].Value?.ToString();
            dta.V0HISTMEST_NUM_APOL_SINISTRO = result[i++].Value?.ToString();
            dta.V0HISTMEST_NUM_APOLICE = result[i++].Value?.ToString();
            dta.V0HISTMEST_OPERACAO = result[i++].Value?.ToString();
            dta.V0HISTMEST_VAL_OPERACAO = result[i++].Value?.ToString();
            dta.V0HISTMEST_NOMFAV = result[i++].Value?.ToString();

            return dta;
        }

    }
}