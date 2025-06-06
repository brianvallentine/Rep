using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0851B
{
    public class SI0851B_LOTERICO : QueryBasis<SI0851B_LOTERICO>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0851B_LOTERICO() { IsCursor = true; }

        public SI0851B_LOTERICO(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0MEST_NUM_APOLICE { get; set; }
        public string V0MEST_NUM_APOL_SINISTRO { get; set; }
        public string V0MEST_SITUACAO { get; set; }
        public string V0MEST_DATORR { get; set; }
        public string V0MEST_DATCMD { get; set; }
        public string V0SLOT_COD_LOT_FENAL { get; set; }
        public string V0SLOT_COD_LOT_CEF { get; set; }
        public string V0CLI_NOME_RAZAO { get; set; }
        public string V0END_SIGLA_UF { get; set; }

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


        public override SI0851B_LOTERICO OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0851B_LOTERICO();
            var i = 0;

            dta.V0MEST_NUM_APOLICE = result[i++].Value?.ToString();
            dta.V0MEST_NUM_APOL_SINISTRO = result[i++].Value?.ToString();
            dta.V0MEST_SITUACAO = result[i++].Value?.ToString();
            dta.V0MEST_DATORR = result[i++].Value?.ToString();
            dta.V0MEST_DATCMD = result[i++].Value?.ToString();
            dta.V0SLOT_COD_LOT_FENAL = result[i++].Value?.ToString();
            dta.V0SLOT_COD_LOT_CEF = result[i++].Value?.ToString();
            dta.V0CLI_NOME_RAZAO = result[i++].Value?.ToString();
            dta.V0END_SIGLA_UF = result[i++].Value?.ToString();

            return dta;
        }

    }
}