using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0130B
{
    public class VG0130B_RELATORIO : QueryBasis<VG0130B_RELATORIO>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VG0130B_RELATORIO() { IsCursor = true; }

        public VG0130B_RELATORIO(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string R_IDSISTEM { get; set; }
        public string R_CODRELAT { get; set; }
        public string R_NUM_APOLICE { get; set; }
        public string R_CODSUBES { get; set; }
        public string R_OPERACAO { get; set; }
        public string R_DATA_REFERENCIA { get; set; }
        public string R_SITUACAO { get; set; }
        public string R_PERI_RENOVACAO { get; set; }
        public string R_PCT_AUMENTO { get; set; }
        public string R_CODUSU { get; set; }
        public string R_CORRECAO { get; set; }

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


        public override VG0130B_RELATORIO OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VG0130B_RELATORIO();
            var i = 0;

            dta.R_IDSISTEM = result[i++].Value?.ToString();
            dta.R_CODRELAT = result[i++].Value?.ToString();
            dta.R_NUM_APOLICE = result[i++].Value?.ToString();
            dta.R_CODSUBES = result[i++].Value?.ToString();
            dta.R_OPERACAO = result[i++].Value?.ToString();
            dta.R_DATA_REFERENCIA = result[i++].Value?.ToString();
            dta.R_SITUACAO = result[i++].Value?.ToString();
            dta.R_PERI_RENOVACAO = result[i++].Value?.ToString();
            dta.R_PCT_AUMENTO = result[i++].Value?.ToString();
            dta.R_CODUSU = result[i++].Value?.ToString();
            dta.R_CORRECAO = result[i++].Value?.ToString();

            return dta;
        }

    }
}