using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0105B
{
    public class VP0105B_TFUNCIOCEF : QueryBasis<VP0105B_TFUNCIOCEF>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VP0105B_TFUNCIOCEF() { IsCursor = true; }

        public VP0105B_TFUNCIOCEF(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string FSUREG { get; set; }
        public string FCOD_UNIDADE { get; set; }
        public string FNOME_UNIDADE { get; set; }
        public string FMATRICULA { get; set; }
        public string FNOME_FUNC { get; set; }
        public string SNUM_CERTIFICADO { get; set; }
        public string SNUM_ITEM { get; set; }
        public string SOCORR_HISTORICO { get; set; }

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


        public override VP0105B_TFUNCIOCEF OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VP0105B_TFUNCIOCEF();
            var i = 0;

            dta.FSUREG = result[i++].Value?.ToString();
            dta.FCOD_UNIDADE = result[i++].Value?.ToString();
            dta.FNOME_UNIDADE = result[i++].Value?.ToString();
            dta.FMATRICULA = result[i++].Value?.ToString();
            dta.FNOME_FUNC = result[i++].Value?.ToString();
            dta.SNUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.SNUM_ITEM = result[i++].Value?.ToString();
            dta.SOCORR_HISTORICO = result[i++].Value?.ToString();

            return dta;
        }

    }
}