using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0709B
{
    public class PF0709B_CPROPOSTA : QueryBasis<PF0709B_CPROPOSTA>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public PF0709B_CPROPOSTA() { IsCursor = true; }

        public PF0709B_CPROPOSTA(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string DCLCOBER_HIST_VIDAZUL_NUM_CERTIFICADO { get; set; }
        public string PROPOFID_NUM_IDENTIFICACAO { get; set; }
        public string PROPOFID_COD_EMPRESA_SIVPF { get; set; }
        public string PROPOFID_COD_PRODUTO_SIVPF { get; set; }
        public string DCLCOBER_HIST_VIDAZUL_NUM_PARCELA { get; set; }
        public string DCLCOBER_HIST_VIDAZUL_DATA_VENCIMENTO { get; set; }
        public string DCLCOBER_HIST_VIDAZUL_OPCAO_PAGAMENTO { get; set; }
        public string DCLCOBER_HIST_VIDAZUL_SIT_REGISTRO { get; set; }

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


        public override PF0709B_CPROPOSTA OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new PF0709B_CPROPOSTA();
            var i = 0;

            dta.DCLCOBER_HIST_VIDAZUL_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.PROPOFID_NUM_IDENTIFICACAO = result[i++].Value?.ToString();
            dta.PROPOFID_COD_EMPRESA_SIVPF = result[i++].Value?.ToString();
            dta.PROPOFID_COD_PRODUTO_SIVPF = result[i++].Value?.ToString();
            dta.DCLCOBER_HIST_VIDAZUL_NUM_PARCELA = result[i++].Value?.ToString();
            dta.DCLCOBER_HIST_VIDAZUL_DATA_VENCIMENTO = result[i++].Value?.ToString();
            dta.DCLCOBER_HIST_VIDAZUL_OPCAO_PAGAMENTO = result[i++].Value?.ToString();
            dta.DCLCOBER_HIST_VIDAZUL_SIT_REGISTRO = result[i++].Value?.ToString();

            return dta;
        }

    }
}