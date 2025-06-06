using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GECPB101
{
    public class GECPB101_C01 : QueryBasis<GECPB101_C01>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public GECPB101_C01() { IsCursor = true; }

        public GECPB101_C01(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string WS_HOST_DTA_LOTE { get; set; }
        public string GE536_COD_ORIGEM { get; set; }
        public string GE536_COD_EVENTO { get; set; }
        public string GE537_NUM_IDLG { get; set; }
        public string GE543_NUM_SINISTRO { get; set; }
        public string GE543_NUM_APOLICE { get; set; }
        public string GE536_COD_CHAVE_NEGOCIO { get; set; }
        public string GE547_VLR_COBRAR_PAGAR { get; set; }
        public string GE537_DTA_MOVIMENTO { get; set; }
        public string GE547_DTA_COBRAR_PAGAR { get; set; }
        public string WS_HOST_DES_FORMA { get; set; }
        public string WS_HOST_DES_TIPO_MOV { get; set; }
        public string WS_HOST_DES_STA_PROCES { get; set; }
        public string GE577_COD_RETORNO_ARQ_H { get; set; }
        public string GE576_DES_RETORNO_ARQ_H { get; set; }
        public string GE541_NOM_EXTERNO_ARQUIVO { get; set; }
        public string GE554_NOM_EXTERNO_ARQUIVO { get; set; }

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


        public override GECPB101_C01 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new GECPB101_C01();
            var i = 0;

            dta.WS_HOST_DTA_LOTE = result[i++].Value?.ToString();
            dta.GE536_COD_ORIGEM = result[i++].Value?.ToString();
            dta.GE536_COD_EVENTO = result[i++].Value?.ToString();
            dta.GE537_NUM_IDLG = result[i++].Value?.ToString();
            dta.GE543_NUM_SINISTRO = result[i++].Value?.ToString();
            dta.GE543_NUM_APOLICE = result[i++].Value?.ToString();
            dta.GE536_COD_CHAVE_NEGOCIO = result[i++].Value?.ToString();
            dta.GE547_VLR_COBRAR_PAGAR = result[i++].Value?.ToString();
            dta.GE537_DTA_MOVIMENTO = result[i++].Value?.ToString();
            dta.GE547_DTA_COBRAR_PAGAR = result[i++].Value?.ToString();
            dta.WS_HOST_DES_FORMA = result[i++].Value?.ToString();
            dta.WS_HOST_DES_TIPO_MOV = result[i++].Value?.ToString();
            dta.WS_HOST_DES_STA_PROCES = result[i++].Value?.ToString();
            dta.GE577_COD_RETORNO_ARQ_H = result[i++].Value?.ToString();
            dta.GE576_DES_RETORNO_ARQ_H = result[i++].Value?.ToString();
            dta.GE541_NOM_EXTERNO_ARQUIVO = result[i++].Value?.ToString();
            dta.GE554_NOM_EXTERNO_ARQUIVO = result[i++].Value?.ToString();

            return dta;
        }

    }
}