using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0014B
{
    public class VG0014B_ACOPLADO : QueryBasis<VG0014B_ACOPLADO>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VG0014B_ACOPLADO() { IsCursor = true; }

        public VG0014B_ACOPLADO(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string WS_COD_PRODUTO { get; set; }
        public string WS_COD_PLANO { get; set; }
        public string WS_NUM_SERIE { get; set; }
        public string WS_NUM_TITULO { get; set; }
        public string WS_STA_TITULO { get; set; }
        public string WS_COD_SUB_TITULO { get; set; }
        public string WS_DTH_ATIVACAO { get; set; }
        public string WS_DTA_CADUCACAO { get; set; }
        public string WS_DTH_CRIACAO { get; set; }
        public string WS_DTA_FIM_VIGENCIA { get; set; }
        public string WS_DTA_INI_SORTEIO { get; set; }
        public string WS_DTA_INI_VIGENCIA { get; set; }
        public string WS_DTA_SUSPENSAO { get; set; }
        public string WS_COD_DV { get; set; }
        public string WS_VLR_MENSALIDADE { get; set; }
        public string WS_COD_DOC_PARCEIRO_P { get; set; }
        public string WS_NUM_MOD_PLANO { get; set; }
        public string WS_DES_COMBINACAO { get; set; }
        public string WS_IDE_SISTEMA { get; set; }

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


        public override VG0014B_ACOPLADO OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VG0014B_ACOPLADO();
            var i = 0;

            dta.WS_COD_PRODUTO = result[i++].Value?.ToString();
            dta.WS_COD_PLANO = result[i++].Value?.ToString();
            dta.WS_NUM_SERIE = result[i++].Value?.ToString();
            dta.WS_NUM_TITULO = result[i++].Value?.ToString();
            dta.WS_STA_TITULO = result[i++].Value?.ToString();
            dta.WS_COD_SUB_TITULO = result[i++].Value?.ToString();
            dta.WS_DTH_ATIVACAO = result[i++].Value?.ToString();
            dta.WS_DTA_CADUCACAO = result[i++].Value?.ToString();
            dta.WS_DTH_CRIACAO = result[i++].Value?.ToString();
            dta.WS_DTA_FIM_VIGENCIA = result[i++].Value?.ToString();
            dta.WS_DTA_INI_SORTEIO = result[i++].Value?.ToString();
            dta.WS_DTA_INI_VIGENCIA = result[i++].Value?.ToString();
            dta.WS_DTA_SUSPENSAO = result[i++].Value?.ToString();
            dta.WS_COD_DV = result[i++].Value?.ToString();
            dta.WS_VLR_MENSALIDADE = result[i++].Value?.ToString();
            dta.WS_COD_DOC_PARCEIRO_P = result[i++].Value?.ToString();
            dta.WS_NUM_MOD_PLANO = result[i++].Value?.ToString();
            dta.WS_DES_COMBINACAO = result[i++].Value?.ToString();
            dta.WS_IDE_SISTEMA = result[i++].Value?.ToString();

            return dta;
        }

    }
}