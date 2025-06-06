using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0711S
{
    public class VG0711S_COBER491 : QueryBasis<VG0711S_COBER491>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VG0711S_COBER491() { IsCursor = true; }

        public VG0711S_COBER491(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string VG087_NOM_GRUPO_COBERTURA { get; set; }
        public string VG087_IND_CONJUGE { get; set; }
        public string VGARANTI_NUM_GARANTIA { get; set; }
        public string VGARANTI_DES_GARANTIA { get; set; }
        public string VG085_NUM_FAIXA_INICIAL { get; set; }
        public string VG085_NUM_FAIXA_FINAL { get; set; }
        public string VG086_VLR_FAIXA_CS_INICIAL { get; set; }
        public string VG086_VLR_FAIXA_CS_FINAL { get; set; }
        public string VG088_PCT_COB_PREMIO { get; set; }
        public string VG088_DTA_INI_VIGENCIA_GRUPO { get; set; }
        public string VG088_DTA_FIM_VIGENCIA_GRUPO { get; set; }
        public string VG091_DES_COB_CARENCIA { get; set; }

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


        public override VG0711S_COBER491 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VG0711S_COBER491();
            var i = 0;

            dta.VG087_NOM_GRUPO_COBERTURA = result[i++].Value?.ToString();
            dta.VG087_IND_CONJUGE = result[i++].Value?.ToString();
            dta.VGARANTI_NUM_GARANTIA = result[i++].Value?.ToString();
            dta.VGARANTI_DES_GARANTIA = result[i++].Value?.ToString();
            dta.VG085_NUM_FAIXA_INICIAL = result[i++].Value?.ToString();
            dta.VG085_NUM_FAIXA_FINAL = result[i++].Value?.ToString();
            dta.VG086_VLR_FAIXA_CS_INICIAL = result[i++].Value?.ToString();
            dta.VG086_VLR_FAIXA_CS_FINAL = result[i++].Value?.ToString();
            dta.VG088_PCT_COB_PREMIO = result[i++].Value?.ToString();
            dta.VG088_DTA_INI_VIGENCIA_GRUPO = result[i++].Value?.ToString();
            dta.VG088_DTA_FIM_VIGENCIA_GRUPO = result[i++].Value?.ToString();
            dta.VG091_DES_COB_CARENCIA = result[i++].Value?.ToString();

            return dta;
        }

    }
}