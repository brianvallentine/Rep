using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI2002B
{
    public class BI2002B_V0CBCONDEV : QueryBasis<BI2002B_V0CBCONDEV>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public BI2002B_V0CBCONDEV() { IsCursor = true; }

        public BI2002B_V0CBCONDEV(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string CBCONDEV_NUM_TITULO { get; set; }
        public string CBCONDEV_NUM_APOLICE { get; set; }
        public string CBCONDEV_NUM_ENDOSSO { get; set; }
        public string CBCONDEV_NUM_PARCELA { get; set; }
        public string CBCONDEV_NUM_CERTIFICADO { get; set; }
        public string CBCONDEV_NUM_MATRICULA { get; set; }
        public string CBCONDEV_COD_PRODUTO { get; set; }
        public string CBCONDEV_SIT_REGISTRO { get; set; }
        public string CBCONDEV_VAL_TITULO { get; set; }

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


        public override BI2002B_V0CBCONDEV OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new BI2002B_V0CBCONDEV();
            var i = 0;

            dta.CBCONDEV_NUM_TITULO = result[i++].Value?.ToString();
            dta.CBCONDEV_NUM_APOLICE = result[i++].Value?.ToString();
            dta.CBCONDEV_NUM_ENDOSSO = result[i++].Value?.ToString();
            dta.CBCONDEV_NUM_PARCELA = result[i++].Value?.ToString();
            dta.CBCONDEV_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.CBCONDEV_NUM_MATRICULA = result[i++].Value?.ToString();
            dta.CBCONDEV_COD_PRODUTO = result[i++].Value?.ToString();
            dta.CBCONDEV_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.CBCONDEV_VAL_TITULO = result[i++].Value?.ToString();

            return dta;
        }

    }
}