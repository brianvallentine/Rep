using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0506B
{
    public class VA0506B_V0FUNDO : QueryBasis<VA0506B_V0FUNDO>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VA0506B_V0FUNDO() { IsCursor = true; }

        public VA0506B_V0FUNDO(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string FUNCOMVA_CODIGO_PRODUTO { get; set; }
        public string FUNCOMVA_NUM_CERTIFICADO { get; set; }
        public string FUNCOMVA_NUM_TERMO { get; set; }
        public string FUNCOMVA_SITUACAO { get; set; }
        public string FUNCOMVA_COD_OPERACAO { get; set; }
        public string FUNCOMVA_COD_FONTE { get; set; }
        public string FUNCOMVA_COD_AGENCIA { get; set; }
        public string FUNCOMVA_COD_CLIENTE { get; set; }
        public string FUNCOMVA_NUM_MATRI_VENDEDOR { get; set; }
        public string FUNCOMVA_VAL_BASICO_VG { get; set; }
        public string FUNCOMVA_VAL_BASICO_AP { get; set; }
        public string FUNCOMVA_VAL_COMISSAO_VG { get; set; }
        public string FUNCOMVA_VAL_COMISSAO_AP { get; set; }
        public string FUNCOMVA_DATA_QUITACAO { get; set; }
        public string FUNCOMVA_PCCOMIND { get; set; }
        public string FUNCOMVA_PCCOMGER { get; set; }
        public string FUNCOMVA_PCCOMSUP { get; set; }
        public string FUNCOMVA_DATA_MOVIMENTO { get; set; }
        public string FUNCOMVA_NUM_APOLICE { get; set; }
        public string VIND_NULL01 { get; set; }
        public string FUNCOMVA_COD_SUBGRUPO { get; set; }
        public string VIND_NULL02 { get; set; }
        public string FUNCOMVA_NUM_ENDOSSO { get; set; }
        public string VIND_NULL03 { get; set; }
        public string FUNCOMVA_NUM_TITULO { get; set; }
        public string VIND_NULL04 { get; set; }
        public string FUNCOMVA_NUM_PARCELA { get; set; }
        public string VIND_NULL05 { get; set; }

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


        public override VA0506B_V0FUNDO OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VA0506B_V0FUNDO();
            var i = 0;

            dta.FUNCOMVA_CODIGO_PRODUTO = result[i++].Value?.ToString();
            dta.FUNCOMVA_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.FUNCOMVA_NUM_TERMO = result[i++].Value?.ToString();
            dta.FUNCOMVA_SITUACAO = result[i++].Value?.ToString();
            dta.FUNCOMVA_COD_OPERACAO = result[i++].Value?.ToString();
            dta.FUNCOMVA_COD_FONTE = result[i++].Value?.ToString();
            dta.FUNCOMVA_COD_AGENCIA = result[i++].Value?.ToString();
            dta.FUNCOMVA_COD_CLIENTE = result[i++].Value?.ToString();
            dta.FUNCOMVA_NUM_MATRI_VENDEDOR = result[i++].Value?.ToString();
            dta.FUNCOMVA_VAL_BASICO_VG = result[i++].Value?.ToString();
            dta.FUNCOMVA_VAL_BASICO_AP = result[i++].Value?.ToString();
            dta.FUNCOMVA_VAL_COMISSAO_VG = result[i++].Value?.ToString();
            dta.FUNCOMVA_VAL_COMISSAO_AP = result[i++].Value?.ToString();
            dta.FUNCOMVA_DATA_QUITACAO = result[i++].Value?.ToString();
            dta.FUNCOMVA_PCCOMIND = result[i++].Value?.ToString();
            dta.FUNCOMVA_PCCOMGER = result[i++].Value?.ToString();
            dta.FUNCOMVA_PCCOMSUP = result[i++].Value?.ToString();
            dta.FUNCOMVA_DATA_MOVIMENTO = result[i++].Value?.ToString();
            dta.FUNCOMVA_NUM_APOLICE = result[i++].Value?.ToString();
            dta.VIND_NULL01 = string.IsNullOrWhiteSpace(dta.FUNCOMVA_NUM_APOLICE) ? "-1" : "0";
            dta.FUNCOMVA_COD_SUBGRUPO = result[i++].Value?.ToString();
            dta.VIND_NULL02 = string.IsNullOrWhiteSpace(dta.FUNCOMVA_COD_SUBGRUPO) ? "-1" : "0";
            dta.FUNCOMVA_NUM_ENDOSSO = result[i++].Value?.ToString();
            dta.VIND_NULL03 = string.IsNullOrWhiteSpace(dta.FUNCOMVA_NUM_ENDOSSO) ? "-1" : "0";
            dta.FUNCOMVA_NUM_TITULO = result[i++].Value?.ToString();
            dta.VIND_NULL04 = string.IsNullOrWhiteSpace(dta.FUNCOMVA_NUM_TITULO) ? "-1" : "0";
            dta.FUNCOMVA_NUM_PARCELA = result[i++].Value?.ToString();
            dta.VIND_NULL05 = string.IsNullOrWhiteSpace(dta.FUNCOMVA_NUM_PARCELA) ? "-1" : "0";

            return dta;
        }

    }
}