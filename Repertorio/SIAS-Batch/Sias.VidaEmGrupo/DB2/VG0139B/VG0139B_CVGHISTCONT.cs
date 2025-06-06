using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0139B
{
    public class VG0139B_CVGHISTCONT : QueryBasis<VG0139B_CVGHISTCONT>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VG0139B_CVGHISTCONT() { IsCursor = true; }

        public VG0139B_CVGHISTCONT(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string VG082_NUM_CERTIFICADO { get; set; }
        public string VG082_NUM_PARCELA { get; set; }
        public string VG082_NUM_TITULO { get; set; }
        public string VG082_OCORR_HISTORICO { get; set; }
        public string VG082_COD_GRUPO_SUSEP { get; set; }
        public string VG082_RAMO_EMISSOR { get; set; }
        public string VG082_COD_MODALIDADE { get; set; }
        public string VG082_COD_COBERTURA { get; set; }
        public string VG082_VLR_PREMIO_RAMO { get; set; }
        public string VG082_COD_USUARIO { get; set; }
        public string VG082_DTH_ATUALIZACAO { get; set; }

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


        public override VG0139B_CVGHISTCONT OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VG0139B_CVGHISTCONT();
            var i = 0;

            dta.VG082_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.VG082_NUM_PARCELA = result[i++].Value?.ToString();
            dta.VG082_NUM_TITULO = result[i++].Value?.ToString();
            dta.VG082_OCORR_HISTORICO = result[i++].Value?.ToString();
            dta.VG082_COD_GRUPO_SUSEP = result[i++].Value?.ToString();
            dta.VG082_RAMO_EMISSOR = result[i++].Value?.ToString();
            dta.VG082_COD_MODALIDADE = result[i++].Value?.ToString();
            dta.VG082_COD_COBERTURA = result[i++].Value?.ToString();
            dta.VG082_VLR_PREMIO_RAMO = result[i++].Value?.ToString();
            dta.VG082_COD_USUARIO = result[i++].Value?.ToString();
            dta.VG082_DTH_ATUALIZACAO = result[i++].Value?.ToString();

            return dta;
        }

    }
}