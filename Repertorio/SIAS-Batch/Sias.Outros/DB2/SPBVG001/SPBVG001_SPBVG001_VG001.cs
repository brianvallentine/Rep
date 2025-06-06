using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.SPBVG001
{
    public class SPBVG001_SPBVG001_VG001 : QueryBasis<SPBVG001_SPBVG001_VG001>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SPBVG001_SPBVG001_VG001() { IsCursor = true; }

        public SPBVG001_SPBVG001_VG001(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string VG103_NUM_CERTIFICADO { get; set; }
        public string VG103_SEQ_CRITICA { get; set; }
        public string VG103_IND_TP_PROPOSTA { get; set; }
        public string VG103_COD_MSG_CRITICA { get; set; }
        public string VG102_DES_MSG_CRITICA { get; set; }
        public string VG102_DES_ABREV_MSG_CRITICA { get; set; }
        public string VG103_NUM_CPF_CNPJ { get; set; }
        public string VG103_NUM_PROPOSTA { get; set; }
        public string VG103_VLR_IS { get; set; }
        public string VG103_VLR_PREMIO { get; set; }
        public string VG103_DTA_OCORRENCIA { get; set; }
        public string VG103_DTA_RCAP { get; set; }
        public string VG103_STA_CRITICA { get; set; }
        public string VG099_DES_STA_CRITICA { get; set; }
        public string VG103_DES_COMPLEMENTAR { get; set; }
        public string VG103_COD_USUARIO { get; set; }
        public string VG103_NOM_PROGRAMA { get; set; }
        public string VG103_DTH_CADASTRAMENTO { get; set; }
        public string VG102_IND_ALCADA { get; set; }

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


        public override SPBVG001_SPBVG001_VG001 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SPBVG001_SPBVG001_VG001();
            var i = 0;

            dta.VG103_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.VG103_SEQ_CRITICA = result[i++].Value?.ToString();
            dta.VG103_IND_TP_PROPOSTA = result[i++].Value?.ToString();
            dta.VG103_COD_MSG_CRITICA = result[i++].Value?.ToString();
            dta.VG102_DES_MSG_CRITICA = result[i++].Value?.ToString();
            dta.VG102_DES_ABREV_MSG_CRITICA = result[i++].Value?.ToString();
            dta.VG103_NUM_CPF_CNPJ = result[i++].Value?.ToString();
            dta.VG103_NUM_PROPOSTA = result[i++].Value?.ToString();
            dta.VG103_VLR_IS = result[i++].Value?.ToString();
            dta.VG103_VLR_PREMIO = result[i++].Value?.ToString();
            dta.VG103_DTA_OCORRENCIA = result[i++].Value?.ToString();
            dta.VG103_DTA_RCAP = result[i++].Value?.ToString();
            dta.VG103_STA_CRITICA = result[i++].Value?.ToString();
            dta.VG099_DES_STA_CRITICA = result[i++].Value?.ToString();
            dta.VG103_DES_COMPLEMENTAR = result[i++].Value?.ToString();
            dta.VG103_COD_USUARIO = result[i++].Value?.ToString();
            dta.VG103_NOM_PROGRAMA = result[i++].Value?.ToString();
            dta.VG103_DTH_CADASTRAMENTO = result[i++].Value?.ToString();
            dta.VG102_IND_ALCADA = result[i++].Value?.ToString();

            return dta;
        }

    }
}