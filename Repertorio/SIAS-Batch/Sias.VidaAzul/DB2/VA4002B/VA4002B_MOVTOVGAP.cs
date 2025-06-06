using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA4002B
{
    public class VA4002B_MOVTOVGAP : QueryBasis<VA4002B_MOVTOVGAP>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VA4002B_MOVTOVGAP() { IsCursor = true; }

        public VA4002B_MOVTOVGAP(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string MOVIMVGA_NUM_CERTIFICADO { get; set; }
        public string MOVIMVGA_COD_OPERACAO { get; set; }
        public string MOVIMVGA_DATA_AVERBACAO { get; set; }
        public string WDATA_AVERBACAO { get; set; }
        public string MOVIMVGA_DATA_INCLUSAO { get; set; }
        public string WDATA_INCLUSAO { get; set; }
        public string MOVIMVGA_DATA_NASCIMENTO { get; set; }
        public string WDATA_NASCIMENTO { get; set; }
        public string MOVIMVGA_DATA_REFERENCIA { get; set; }
        public string WDATA_REFERENCIA { get; set; }

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


        public override VA4002B_MOVTOVGAP OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VA4002B_MOVTOVGAP();
            var i = 0;

            dta.MOVIMVGA_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.MOVIMVGA_COD_OPERACAO = result[i++].Value?.ToString();
            dta.MOVIMVGA_DATA_AVERBACAO = result[i++].Value?.ToString();
            dta.WDATA_AVERBACAO = string.IsNullOrWhiteSpace(dta.MOVIMVGA_DATA_AVERBACAO) ? "-1" : "0";
            dta.MOVIMVGA_DATA_INCLUSAO = result[i++].Value?.ToString();
            dta.WDATA_INCLUSAO = string.IsNullOrWhiteSpace(dta.MOVIMVGA_DATA_INCLUSAO) ? "-1" : "0";
            dta.MOVIMVGA_DATA_NASCIMENTO = result[i++].Value?.ToString();
            dta.WDATA_NASCIMENTO = string.IsNullOrWhiteSpace(dta.MOVIMVGA_DATA_NASCIMENTO) ? "-1" : "0";
            dta.MOVIMVGA_DATA_REFERENCIA = result[i++].Value?.ToString();
            dta.WDATA_REFERENCIA = string.IsNullOrWhiteSpace(dta.MOVIMVGA_DATA_REFERENCIA) ? "-1" : "0";

            return dta;
        }

    }
}