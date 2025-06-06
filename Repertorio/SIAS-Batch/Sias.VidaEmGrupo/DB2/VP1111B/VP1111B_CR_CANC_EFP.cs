using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP1111B
{
    public class VP1111B_CR_CANC_EFP : QueryBasis<VP1111B_CR_CANC_EFP>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VP1111B_CR_CANC_EFP() { IsCursor = true; }

        public VP1111B_CR_CANC_EFP(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string EF150_NUM_OCORR_MOVTO { get; set; }
        public string EF150_NUM_CONTRATO_SEGUR { get; set; }
        public string EF150_NOM_ARQUIVO { get; set; }
        public string EF150_NUM_CONTR_TERC { get; set; }
        public string EF150_NUM_APOLICE { get; set; }
        public string EF150_COD_PRODUTO { get; set; }
        public string EF050_DTH_FIM_VIGENCIA { get; set; }
        public string EF150_DTH_ATUALIZACAO { get; set; }

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


        public override VP1111B_CR_CANC_EFP OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VP1111B_CR_CANC_EFP();
            var i = 0;

            dta.EF150_NUM_OCORR_MOVTO = result[i++].Value?.ToString();
            dta.EF150_NUM_CONTRATO_SEGUR = result[i++].Value?.ToString();
            dta.EF150_NOM_ARQUIVO = result[i++].Value?.ToString();
            dta.EF150_NUM_CONTR_TERC = result[i++].Value?.ToString();
            dta.EF150_NUM_APOLICE = result[i++].Value?.ToString();
            dta.EF150_COD_PRODUTO = result[i++].Value?.ToString();
            dta.EF050_DTH_FIM_VIGENCIA = result[i++].Value?.ToString();
            dta.EF150_DTH_ATUALIZACAO = result[i++].Value?.ToString();

            return dta;
        }

    }
}