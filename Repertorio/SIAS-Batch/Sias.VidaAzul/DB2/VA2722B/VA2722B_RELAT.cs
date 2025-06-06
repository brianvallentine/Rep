using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA2722B
{
    public class VA2722B_RELAT : QueryBasis<VA2722B_RELAT>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VA2722B_RELAT() { IsCursor = true; }

        public VA2722B_RELAT(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string RELATORI_DATA_SOLICITACAO { get; set; }
        public string RELATORI_COD_RELATORIO { get; set; }
        public string RELATORI_PERI_INICIAL { get; set; }
        public string RELATORI_PERI_FINAL { get; set; }
        public string RELATORI_DATA_REFERENCIA { get; set; }
        public string RELATORI_NUM_APOLICE { get; set; }
        public string RELATORI_NUM_CERTIFICADO { get; set; }
        public string RELATORI_SIT_REGISTRO { get; set; }

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


        public override VA2722B_RELAT OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VA2722B_RELAT();
            var i = 0;

            dta.RELATORI_DATA_SOLICITACAO = result[i++].Value?.ToString();
            dta.RELATORI_COD_RELATORIO = result[i++].Value?.ToString();
            dta.RELATORI_PERI_INICIAL = result[i++].Value?.ToString();
            dta.RELATORI_PERI_FINAL = result[i++].Value?.ToString();
            dta.RELATORI_DATA_REFERENCIA = result[i++].Value?.ToString();
            dta.RELATORI_NUM_APOLICE = result[i++].Value?.ToString();
            dta.RELATORI_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.RELATORI_SIT_REGISTRO = result[i++].Value?.ToString();

            return dta;
        }

    }
}