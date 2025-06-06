using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0469B
{
    public class VA0469B_TRELAT : QueryBasis<VA0469B_TRELAT>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VA0469B_TRELAT() { IsCursor = true; }

        public VA0469B_TRELAT(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string RELATORI_NUM_APOLICE { get; set; }
        public string RELATORI_NUM_ENDOSSO { get; set; }
        public string RELATORI_COD_SUBGRUPO { get; set; }
        public string RELATORI_COD_USUARIO { get; set; }
        public string RELATORI_COD_OPERACAO { get; set; }
        public string RELATORI_NUM_CERTIFICADO { get; set; }
        public string RELATORI_NUM_PARCELA { get; set; }
        public string RELATORI_SIT_REGISTRO { get; set; }
        public string RELATORI_NUM_ORDEM { get; set; }
        public string RELATORI_QUANTIDADE { get; set; }
        public string RELATORI_MES_REFERENCIA { get; set; }
        public string RELATORI_ANO_REFERENCIA { get; set; }
        public string RELATORI_ORGAO_EMISSOR { get; set; }
        public string RELATORI_NUM_SINISTRO { get; set; }
        public string RELATORI_NUM_COPIAS { get; set; }
        public string RELATORI_DATA_SOLICITACAO { get; set; }
        public string RELATORI_NUM_APOL_LIDER { get; set; }

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


        public override VA0469B_TRELAT OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VA0469B_TRELAT();
            var i = 0;

            dta.RELATORI_NUM_APOLICE = result[i++].Value?.ToString();
            dta.RELATORI_NUM_ENDOSSO = result[i++].Value?.ToString();
            dta.RELATORI_COD_SUBGRUPO = result[i++].Value?.ToString();
            dta.RELATORI_COD_USUARIO = result[i++].Value?.ToString();
            dta.RELATORI_COD_OPERACAO = result[i++].Value?.ToString();
            dta.RELATORI_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.RELATORI_NUM_PARCELA = result[i++].Value?.ToString();
            dta.RELATORI_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.RELATORI_NUM_ORDEM = result[i++].Value?.ToString();
            dta.RELATORI_QUANTIDADE = result[i++].Value?.ToString();
            dta.RELATORI_MES_REFERENCIA = result[i++].Value?.ToString();
            dta.RELATORI_ANO_REFERENCIA = result[i++].Value?.ToString();
            dta.RELATORI_ORGAO_EMISSOR = result[i++].Value?.ToString();
            dta.RELATORI_NUM_SINISTRO = result[i++].Value?.ToString();
            dta.RELATORI_NUM_COPIAS = result[i++].Value?.ToString();
            dta.RELATORI_DATA_SOLICITACAO = result[i++].Value?.ToString();
            dta.RELATORI_NUM_APOL_LIDER = result[i++].Value?.ToString();

            return dta;
        }

    }
}