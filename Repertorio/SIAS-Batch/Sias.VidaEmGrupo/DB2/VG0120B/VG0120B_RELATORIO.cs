using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0120B
{
    public class VG0120B_RELATORIO : QueryBasis<VG0120B_RELATORIO>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VG0120B_RELATORIO() { IsCursor = true; }

        public VG0120B_RELATORIO(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string RELAT_IDSISTEM { get; set; }
        public string RELAT_CODRELAT { get; set; }
        public string RELAT_NUM_APOLICE { get; set; }
        public string RELAT_NUM_CERTIFIC { get; set; }
        public string RELAT_COD_SUBES { get; set; }
        public string RELAT_OPERACAO { get; set; }
        public string RELAT_SITUACAO { get; set; }

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


        public override VG0120B_RELATORIO OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VG0120B_RELATORIO();
            var i = 0;

            dta.RELAT_IDSISTEM = result[i++].Value?.ToString();
            dta.RELAT_CODRELAT = result[i++].Value?.ToString();
            dta.RELAT_NUM_APOLICE = result[i++].Value?.ToString();
            dta.RELAT_NUM_CERTIFIC = result[i++].Value?.ToString();
            dta.RELAT_COD_SUBES = result[i++].Value?.ToString();
            dta.RELAT_OPERACAO = result[i++].Value?.ToString();
            dta.RELAT_SITUACAO = result[i++].Value?.ToString();

            return dta;
        }

    }
}