using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0200B
{
    public class GE0200B_C01_GEACODIR : QueryBasis<GE0200B_C01_GEACODIR>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public GE0200B_C01_GEACODIR() { IsCursor = true; }

        public GE0200B_C01_GEACODIR(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string GEACODIR_DTH_REFERENCIA { get; set; }
        public string GEACODIR_COD_EMPRESA { get; set; }
        public string GEACODIR_COD_TIPO_MOVIMENTO { get; set; }
        public string GEACODIR_COD_FONTE { get; set; }
        public string GEACODIR_RAMO_EMISSOR { get; set; }
        public string GEACODIR_COD_MODALIDADE { get; set; }
        public string GEACODIR_COD_PRODUTO { get; set; }
        public string GEACODIR_NUM_CENTRO_CUSTO { get; set; }
        public string GEACODIR_IND_EVENTO { get; set; }
        public string GEACODIR_QTD_APURADA { get; set; }
        public string GEACODIR_NOM_PROGRAMA { get; set; }
        public string GEACODIR_COD_USUARIO { get; set; }

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


        public override GE0200B_C01_GEACODIR OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new GE0200B_C01_GEACODIR();
            var i = 0;

            dta.GEACODIR_DTH_REFERENCIA = result[i++].Value?.ToString();
            dta.GEACODIR_COD_EMPRESA = result[i++].Value?.ToString();
            dta.GEACODIR_COD_TIPO_MOVIMENTO = result[i++].Value?.ToString();
            dta.GEACODIR_COD_FONTE = result[i++].Value?.ToString();
            dta.GEACODIR_RAMO_EMISSOR = result[i++].Value?.ToString();
            dta.GEACODIR_COD_MODALIDADE = result[i++].Value?.ToString();
            dta.GEACODIR_COD_PRODUTO = result[i++].Value?.ToString();
            dta.GEACODIR_NUM_CENTRO_CUSTO = result[i++].Value?.ToString();
            dta.GEACODIR_IND_EVENTO = result[i++].Value?.ToString();
            dta.GEACODIR_QTD_APURADA = result[i++].Value?.ToString();
            dta.GEACODIR_NOM_PROGRAMA = result[i++].Value?.ToString();
            dta.GEACODIR_COD_USUARIO = result[i++].Value?.ToString();

            return dta;
        }

    }
}