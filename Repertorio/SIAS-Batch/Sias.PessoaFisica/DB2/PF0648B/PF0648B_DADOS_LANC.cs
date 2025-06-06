using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0648B
{
    public class PF0648B_DADOS_LANC : QueryBasis<PF0648B_DADOS_LANC>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public PF0648B_DADOS_LANC() { IsCursor = true; }

        public PF0648B_DADOS_LANC(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string HISLANCT_PRM_TOTAL { get; set; }
        public string HISLANCT_DATA_VENCIMENTO { get; set; }
        public string HISLANCT_COD_AGENCIA_DEBITO { get; set; }

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


        public override PF0648B_DADOS_LANC OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new PF0648B_DADOS_LANC();
            var i = 0;

            dta.HISLANCT_PRM_TOTAL = result[i++].Value?.ToString();
            dta.HISLANCT_DATA_VENCIMENTO = result[i++].Value?.ToString();
            dta.HISLANCT_COD_AGENCIA_DEBITO = result[i++].Value?.ToString();

            return dta;
        }

    }
}