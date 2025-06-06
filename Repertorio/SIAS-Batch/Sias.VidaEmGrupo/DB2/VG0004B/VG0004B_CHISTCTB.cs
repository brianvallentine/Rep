using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0004B
{
    public class VG0004B_CHISTCTB : QueryBasis<VG0004B_CHISTCTB>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VG0004B_CHISTCTB() { IsCursor = true; }

        public VG0004B_CHISTCTB(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string HISCONPA_NUM_CERTIFICADO { get; set; }
        public string HISCONPA_NUM_PARCELA { get; set; }
        public string HISCONPA_NUM_TITULO { get; set; }
        public string HISCONPA_NUM_APOLICE { get; set; }
        public string HISCONPA_COD_SUBGRUPO { get; set; }
        public string HISCONPA_NUM_ENDOSSO { get; set; }
        public string HISCONPA_COD_OPERACAO { get; set; }
        public string HISCONPA_DTFATUR { get; set; }
        public string VIND_DTFATUR { get; set; }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }

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


        public override VG0004B_CHISTCTB OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VG0004B_CHISTCTB();
            var i = 0;

            dta.HISCONPA_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.HISCONPA_NUM_PARCELA = result[i++].Value?.ToString();
            dta.HISCONPA_NUM_TITULO = result[i++].Value?.ToString();
            dta.HISCONPA_NUM_APOLICE = result[i++].Value?.ToString();
            dta.HISCONPA_COD_SUBGRUPO = result[i++].Value?.ToString();
            dta.HISCONPA_NUM_ENDOSSO = result[i++].Value?.ToString();
            dta.HISCONPA_COD_OPERACAO = result[i++].Value?.ToString();
            dta.HISCONPA_DTFATUR = result[i++].Value?.ToString();
            dta.VIND_DTFATUR = string.IsNullOrWhiteSpace(dta.HISCONPA_DTFATUR) ? "-1" : "0";
            dta.SISTEMAS_DATA_MOV_ABERTO = result[i++].Value?.ToString();

            return dta;
        }

    }
}