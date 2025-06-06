using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0816B
{
    public class VG0816B_CVGRAMOCOMP : QueryBasis<VG0816B_CVGRAMOCOMP>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VG0816B_CVGRAMOCOMP() { IsCursor = true; }

        public VG0816B_CVGRAMOCOMP(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string VG081_NUM_APOLICE { get; set; }
        public string VG081_COD_SUBGRUPO { get; set; }
        public string VG081_COD_GRUPO_SUSEP { get; set; }
        public string VG081_RAMO_EMISSOR { get; set; }
        public string VG081_COD_MODALIDADE { get; set; }
        public string VG081_DTH_INI_VIGENCIA { get; set; }
        public string VG081_COD_OPCAO_COBERTURA { get; set; }
        public string VG081_NUM_IDADE_INICIAL { get; set; }
        public string VG081_NUM_IDADE_FINAL { get; set; }
        public string VG081_VLR_PERC_PREMIO { get; set; }
        public string VG081_COD_USUARIO { get; set; }
        public string VG081_DTH_ATUALIZACAO { get; set; }

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


        public override VG0816B_CVGRAMOCOMP OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VG0816B_CVGRAMOCOMP();
            var i = 0;

            dta.VG081_NUM_APOLICE = result[i++].Value?.ToString();
            dta.VG081_COD_SUBGRUPO = result[i++].Value?.ToString();
            dta.VG081_COD_GRUPO_SUSEP = result[i++].Value?.ToString();
            dta.VG081_RAMO_EMISSOR = result[i++].Value?.ToString();
            dta.VG081_COD_MODALIDADE = result[i++].Value?.ToString();
            dta.VG081_DTH_INI_VIGENCIA = result[i++].Value?.ToString();
            dta.VG081_COD_OPCAO_COBERTURA = result[i++].Value?.ToString();
            dta.VG081_NUM_IDADE_INICIAL = result[i++].Value?.ToString();
            dta.VG081_NUM_IDADE_FINAL = result[i++].Value?.ToString();
            dta.VG081_VLR_PERC_PREMIO = result[i++].Value?.ToString();
            dta.VG081_COD_USUARIO = result[i++].Value?.ToString();
            dta.VG081_DTH_ATUALIZACAO = result[i++].Value?.ToString();

            return dta;
        }

    }
}