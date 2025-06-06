using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GECPB100
{
    public class GECPB100_C06 : QueryBasis<GECPB100_C06>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public GECPB100_C06() { IsCursor = true; }

        public GECPB100_C06(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string GE536_COD_EMPRESA { get; set; }
        public string GE538_DES_EMPRESA { get; set; }
        public string GE551_COD_ORIGEM { get; set; }
        public string GE538_DES_ORIGEM { get; set; }
        public string GE551_COD_LOTE_G { get; set; }
        public string C06_STA_CONSUMO { get; set; }
        public string GE562_DES_MSG_ERRO { get; set; }
        public string VIND_DES_MSG_ERRO { get; set; }
        public string GE552_NOM_EXTERNO_ARQUIVO { get; set; }
        public string C06_QTD { get; set; }

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


        public override GECPB100_C06 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new GECPB100_C06();
            var i = 0;

            dta.GE536_COD_EMPRESA = result[i++].Value?.ToString();
            dta.GE538_DES_EMPRESA = result[i++].Value?.ToString();
            dta.GE551_COD_ORIGEM = result[i++].Value?.ToString();
            dta.GE538_DES_ORIGEM = result[i++].Value?.ToString();
            dta.GE551_COD_LOTE_G = result[i++].Value?.ToString();
            dta.C06_STA_CONSUMO = result[i++].Value?.ToString();
            dta.GE562_DES_MSG_ERRO = result[i++].Value?.ToString();
            dta.VIND_DES_MSG_ERRO = string.IsNullOrWhiteSpace(dta.GE562_DES_MSG_ERRO) ? "-1" : "0";
            dta.GE552_NOM_EXTERNO_ARQUIVO = result[i++].Value?.ToString();
            dta.C06_QTD = result[i++].Value?.ToString();

            return dta;
        }

    }
}