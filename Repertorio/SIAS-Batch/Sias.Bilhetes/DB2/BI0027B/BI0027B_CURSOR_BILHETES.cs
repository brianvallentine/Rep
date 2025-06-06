using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0027B
{
    public class BI0027B_CURSOR_BILHETES : QueryBasis<BI0027B_CURSOR_BILHETES>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public BI0027B_CURSOR_BILHETES() { IsCursor = true; }

        public BI0027B_CURSOR_BILHETES(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string BILHETE_NUM_BILHETE { get; set; }
        public string BILHETE_NUM_APOLICE { get; set; }
        public string BILHETE_DATA_QUITACAO { get; set; }
        public string BILHETE_SITUACAO { get; set; }
        public string CLIENTES_NOME_RAZAO { get; set; }
        public string CLIENTES_CGCCPF { get; set; }
        public string CLIENTES_COD_CLIENTE { get; set; }
        public string ENDERECO_DDD { get; set; }
        public string ENDERECO_TELEFONE { get; set; }
        public string RCAPS_VAL_RCAP { get; set; }
        public string RCAPS_NUM_RCAP { get; set; }
        public string RCAPS_NUM_PROPOSTA { get; set; }
        public string RCAPS_DATA_MOVIMENTO { get; set; }
        public string RCAPCOMP_NUM_AVISO_CREDITO { get; set; }
        public string RCAPCOMP_DATA_RCAP { get; set; }
        public string CONVERSI_COD_PRODUTO_SIVPF { get; set; }
        public string WS_HOST_PRODU { get; set; }

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


        public override BI0027B_CURSOR_BILHETES OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new BI0027B_CURSOR_BILHETES();
            var i = 0;

            dta.BILHETE_NUM_BILHETE = result[i++].Value?.ToString();
            dta.BILHETE_NUM_APOLICE = result[i++].Value?.ToString();
            dta.BILHETE_DATA_QUITACAO = result[i++].Value?.ToString();
            dta.BILHETE_SITUACAO = result[i++].Value?.ToString();
            dta.CLIENTES_NOME_RAZAO = result[i++].Value?.ToString();
            dta.CLIENTES_CGCCPF = result[i++].Value?.ToString();
            dta.CLIENTES_COD_CLIENTE = result[i++].Value?.ToString();
            dta.ENDERECO_DDD = result[i++].Value?.ToString();
            dta.ENDERECO_TELEFONE = result[i++].Value?.ToString();
            dta.RCAPS_VAL_RCAP = result[i++].Value?.ToString();
            dta.RCAPS_NUM_RCAP = result[i++].Value?.ToString();
            dta.RCAPS_NUM_PROPOSTA = result[i++].Value?.ToString();
            dta.RCAPS_DATA_MOVIMENTO = result[i++].Value?.ToString();
            dta.RCAPCOMP_NUM_AVISO_CREDITO = result[i++].Value?.ToString();
            dta.RCAPCOMP_DATA_RCAP = result[i++].Value?.ToString();
            dta.CONVERSI_COD_PRODUTO_SIVPF = result[i++].Value?.ToString();
            dta.WS_HOST_PRODU = result[i++].Value?.ToString();

            return dta;
        }

    }
}