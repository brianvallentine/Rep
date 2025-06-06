using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI7028B
{
    public class BI7028B_CRELAT : QueryBasis<BI7028B_CRELAT>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public BI7028B_CRELAT() { IsCursor = true; }

        public BI7028B_CRELAT(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string RELATORI_COD_OPERACAO { get; set; }
        public string RELATORI_COD_USUARIO { get; set; }
        public string RELATORI_COD_RELATORIO { get; set; }
        public string RELATORI_DATA_SOLICITACAO { get; set; }
        public string RELATORI_NUM_ENDOSSO { get; set; }
        public string BILHETE_DATA_QUITACAO { get; set; }
        public string BILHETE_NUM_APOLICE { get; set; }
        public string BILHETE_NUM_BILHETE { get; set; }
        public string BILHETE_COD_CLIENTE { get; set; }
        public string BILHETE_OCORR_ENDERECO { get; set; }
        public string BILHETE_RAMO { get; set; }
        public string BILHETE_FONTE { get; set; }
        public string BILHETE_DATA_MOVIMENTO { get; set; }
        public string PROPOFID_COD_PRODUTO_SIVPF { get; set; }
        public string PROPOFID_ORIGEM_PROPOSTA { get; set; }
        public string PROPOFID_COD_PESSOA { get; set; }
        public string PROPOFID_DIA_DEBITO { get; set; }
        public string PROPOFID_AGECTADEB { get; set; }
        public string PROPOFID_OPRCTADEB { get; set; }
        public string PROPOFID_NUMCTADEB { get; set; }
        public string PROPOFID_DIGCTADEB { get; set; }
        public string PROPOFID_NOME_CONVENENTE { get; set; }
        public string PROPOFID_VAL_PAGO { get; set; }
        public string PROPOFID_CGC_CONVENENTE { get; set; }
        public string BILHETE_OPC_COBERTURA { get; set; }
        public string PROPOFID_OPCAOPAG { get; set; }
        public string WS_CURSOR_FORMAPAG { get; set; }
        public string WS_CURSOR_VLIOF { get; set; }
        public string WS_CURSOR_VLPREMIO_LIQ { get; set; }

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


        public override BI7028B_CRELAT OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new BI7028B_CRELAT();
            var i = 0;

            dta.RELATORI_COD_OPERACAO = result[i++].Value?.ToString();
            dta.RELATORI_COD_USUARIO = result[i++].Value?.ToString();
            dta.RELATORI_COD_RELATORIO = result[i++].Value?.ToString();
            dta.RELATORI_DATA_SOLICITACAO = result[i++].Value?.ToString();
            dta.RELATORI_NUM_ENDOSSO = result[i++].Value?.ToString();
            dta.BILHETE_DATA_QUITACAO = result[i++].Value?.ToString();
            dta.BILHETE_NUM_APOLICE = result[i++].Value?.ToString();
            dta.BILHETE_NUM_BILHETE = result[i++].Value?.ToString();
            dta.BILHETE_COD_CLIENTE = result[i++].Value?.ToString();
            dta.BILHETE_OCORR_ENDERECO = result[i++].Value?.ToString();
            dta.BILHETE_RAMO = result[i++].Value?.ToString();
            dta.BILHETE_FONTE = result[i++].Value?.ToString();
            dta.BILHETE_DATA_MOVIMENTO = result[i++].Value?.ToString();
            dta.PROPOFID_COD_PRODUTO_SIVPF = result[i++].Value?.ToString();
            dta.PROPOFID_ORIGEM_PROPOSTA = result[i++].Value?.ToString();
            dta.PROPOFID_COD_PESSOA = result[i++].Value?.ToString();
            dta.PROPOFID_DIA_DEBITO = result[i++].Value?.ToString();
            dta.PROPOFID_AGECTADEB = result[i++].Value?.ToString();
            dta.PROPOFID_OPRCTADEB = result[i++].Value?.ToString();
            dta.PROPOFID_NUMCTADEB = result[i++].Value?.ToString();
            dta.PROPOFID_DIGCTADEB = result[i++].Value?.ToString();
            dta.PROPOFID_NOME_CONVENENTE = result[i++].Value?.ToString();
            dta.PROPOFID_VAL_PAGO = result[i++].Value?.ToString();
            dta.PROPOFID_CGC_CONVENENTE = result[i++].Value?.ToString();
            dta.BILHETE_OPC_COBERTURA = result[i++].Value?.ToString();
            dta.PROPOFID_OPCAOPAG = result[i++].Value?.ToString();
            dta.WS_CURSOR_FORMAPAG = result[i++].Value?.ToString();
            dta.WS_CURSOR_VLIOF = result[i++].Value?.ToString();
            dta.WS_CURSOR_VLPREMIO_LIQ = result[i++].Value?.ToString();

            return dta;
        }

    }
}