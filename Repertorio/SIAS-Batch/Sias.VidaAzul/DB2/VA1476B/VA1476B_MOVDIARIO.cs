using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA1476B
{
    public class VA1476B_MOVDIARIO : QueryBasis<VA1476B_MOVDIARIO>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VA1476B_MOVDIARIO() { IsCursor = true; }

        public VA1476B_MOVDIARIO(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string MOVIMVGA_NUM_CERTIFICADO { get; set; }
        public string MOVIMVGA_COD_OPERACAO { get; set; }
        public string MOVIMVGA_OCORR_ENDERECO { get; set; }
        public string MOVIMVGA_NUM_APOLICE { get; set; }
        public string MOVIMVGA_COD_SUBGRUPO { get; set; }
        public string WHOST_TIPO_MOVIMENTO { get; set; }
        public string WS_COD_PRODUTO { get; set; }

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


        public override VA1476B_MOVDIARIO OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VA1476B_MOVDIARIO();
            var i = 0;

            dta.MOVIMVGA_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.MOVIMVGA_COD_OPERACAO = result[i++].Value?.ToString();
            dta.MOVIMVGA_OCORR_ENDERECO = result[i++].Value?.ToString();
            dta.MOVIMVGA_NUM_APOLICE = result[i++].Value?.ToString();
            dta.MOVIMVGA_COD_SUBGRUPO = result[i++].Value?.ToString();
            dta.WHOST_TIPO_MOVIMENTO = result[i++].Value?.ToString();
            dta.WS_COD_PRODUTO = result[i++].Value?.ToString();

            return dta;
        }

    }
}