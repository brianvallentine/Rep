using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0853B
{
    public class VG0853B_CDEBANT : QueryBasis<VG0853B_CDEBANT>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VG0853B_CDEBANT() { IsCursor = true; }

        public VG0853B_CDEBANT(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string HISLANCT_NUM_CERTIFICADO { get; set; }
        public string HISLANCT_NUM_PARCELA { get; set; }
        public string HISLANCT_OCORR_HISTORICOCTA { get; set; }
        public string HISLANCT_COD_AGENCIA_DEBITO { get; set; }
        public string HISLANCT_OPE_CONTA_DEBITO { get; set; }
        public string HISLANCT_NUM_CONTA_DEBITO { get; set; }
        public string HISLANCT_DIG_CONTA_DEBITO { get; set; }
        public string HISLANCT_DATA_VENCIMENTO { get; set; }
        public string HISLANCT_PRM_TOTAL { get; set; }
        public string HISLANCT_TIPLANC { get; set; }
        public string HISLANCT_OCORR_HISTORICO { get; set; }
        public string HISLANCT_CODCONV { get; set; }
        public string HISLANCT_CODRET { get; set; }

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


        public override VG0853B_CDEBANT OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VG0853B_CDEBANT();
            var i = 0;

            dta.HISLANCT_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.HISLANCT_NUM_PARCELA = result[i++].Value?.ToString();
            dta.HISLANCT_OCORR_HISTORICOCTA = result[i++].Value?.ToString();
            dta.HISLANCT_COD_AGENCIA_DEBITO = result[i++].Value?.ToString();
            dta.HISLANCT_OPE_CONTA_DEBITO = result[i++].Value?.ToString();
            dta.HISLANCT_NUM_CONTA_DEBITO = result[i++].Value?.ToString();
            dta.HISLANCT_DIG_CONTA_DEBITO = result[i++].Value?.ToString();
            dta.HISLANCT_DATA_VENCIMENTO = result[i++].Value?.ToString();
            dta.HISLANCT_PRM_TOTAL = result[i++].Value?.ToString();
            dta.HISLANCT_TIPLANC = result[i++].Value?.ToString();
            dta.HISLANCT_OCORR_HISTORICO = result[i++].Value?.ToString();
            dta.HISLANCT_CODCONV = result[i++].Value?.ToString();
            dta.HISLANCT_CODRET = result[i++].Value?.ToString();

            return dta;
        }

    }
}