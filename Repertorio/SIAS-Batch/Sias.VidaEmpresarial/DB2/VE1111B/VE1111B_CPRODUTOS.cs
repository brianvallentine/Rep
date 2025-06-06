using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE1111B
{
    public class VE1111B_CPRODUTOS : QueryBasis<VE1111B_CPRODUTOS>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VE1111B_CPRODUTOS() { IsCursor = true; }

        public VE1111B_CPRODUTOS(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string PRODUVG_NUM_APOLICE { get; set; }
        public string PRODUVG_COD_SUBGRUPO { get; set; }
        public string PRODUVG_COD_PRODUTO { get; set; }
        public string PRODUVG_PERI_PAGAMENTO { get; set; }
        public string PRODUVG_NOME_PRODUTO { get; set; }

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


        public override VE1111B_CPRODUTOS OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VE1111B_CPRODUTOS();
            var i = 0;

            dta.PRODUVG_NUM_APOLICE = result[i++].Value?.ToString();
            dta.PRODUVG_COD_SUBGRUPO = result[i++].Value?.ToString();
            dta.PRODUVG_COD_PRODUTO = result[i++].Value?.ToString();
            dta.PRODUVG_PERI_PAGAMENTO = result[i++].Value?.ToString();
            dta.PRODUVG_NOME_PRODUTO = result[i++].Value?.ToString();

            return dta;
        }

    }
}