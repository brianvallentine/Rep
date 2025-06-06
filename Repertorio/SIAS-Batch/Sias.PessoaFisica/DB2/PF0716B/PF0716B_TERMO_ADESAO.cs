using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0716B
{
    public class PF0716B_TERMO_ADESAO : QueryBasis<PF0716B_TERMO_ADESAO>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public PF0716B_TERMO_ADESAO() { IsCursor = true; }

        public PF0716B_TERMO_ADESAO(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string TERMOADE_NUM_TERMO { get; set; }
        public string TERMOADE_NUM_APOLICE { get; set; }
        public string TERMOADE_COD_SUBGRUPO { get; set; }
        public string MOVIMVGA_DATA_MOVIMENTO { get; set; }
        public string MOVIMVGA_DATA_OPERACAO { get; set; }
        public string MOVIMVGA_COD_OPERACAO { get; set; }
        public string MOVIMVGA_SIT_REGISTRO { get; set; }
        public string PROPOFID_SIT_PROPOSTA { get; set; }
        public string PROPOFID_NUM_PROPOSTA_SIVPF { get; set; }
        public string PROPOFID_NUM_IDENTIFICACAO { get; set; }
        public string PROPOFID_COD_EMPRESA_SIVPF { get; set; }
        public string PROPOFID_COD_PRODUTO_SIVPF { get; set; }

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


        public override PF0716B_TERMO_ADESAO OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new PF0716B_TERMO_ADESAO();
            var i = 0;

            dta.TERMOADE_NUM_TERMO = result[i++].Value?.ToString();
            dta.TERMOADE_NUM_APOLICE = result[i++].Value?.ToString();
            dta.TERMOADE_COD_SUBGRUPO = result[i++].Value?.ToString();
            dta.MOVIMVGA_DATA_MOVIMENTO = result[i++].Value?.ToString();
            dta.MOVIMVGA_DATA_OPERACAO = result[i++].Value?.ToString();
            dta.MOVIMVGA_COD_OPERACAO = result[i++].Value?.ToString();
            dta.MOVIMVGA_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.PROPOFID_SIT_PROPOSTA = result[i++].Value?.ToString();
            dta.PROPOFID_NUM_PROPOSTA_SIVPF = result[i++].Value?.ToString();
            dta.PROPOFID_NUM_IDENTIFICACAO = result[i++].Value?.ToString();
            dta.PROPOFID_COD_EMPRESA_SIVPF = result[i++].Value?.ToString();
            dta.PROPOFID_COD_PRODUTO_SIVPF = result[i++].Value?.ToString();

            return dta;
        }

    }
}