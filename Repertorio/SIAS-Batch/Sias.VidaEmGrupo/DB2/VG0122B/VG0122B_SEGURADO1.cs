using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0122B
{
    public class VG0122B_SEGURADO1 : QueryBasis<VG0122B_SEGURADO1>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VG0122B_SEGURADO1() { IsCursor = true; }

        public VG0122B_SEGURADO1(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string SEGURAVG_NUM_APOL { get; set; }
        public string SEGURAVG_COD_SUBG { get; set; }
        public string SEGURAVG_COD_CLI { get; set; }
        public string SEGURAVG_NUM_CERT { get; set; }
        public string SEGURAVG_DAC_CERT { get; set; }
        public string SEGURAVG_TIPO_SEG { get; set; }
        public string SEGURAVG_NUM_ITEM { get; set; }
        public string SEGURAVG_OCORR_HI { get; set; }
        public string SEGURAVG_EST_CIVIL { get; set; }
        public string SEGURAVG_IDE_SEXO { get; set; }
        public string SEGURAVG_MATRICULA { get; set; }
        public string SEGURAVG_DT_INIVI { get; set; }
        public string SEGURAVG_SIT_REG { get; set; }
        public string SEGURAVG_DT_NASCI { get; set; }
        public string CLIENTE_COD_CLI { get; set; }
        public string CLIENTE_NOME_RAZAO { get; set; }
        public string CLIENTE_CGC_CPF { get; set; }

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


        public override VG0122B_SEGURADO1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VG0122B_SEGURADO1();
            var i = 0;

            dta.SEGURAVG_NUM_APOL = result[i++].Value?.ToString();
            dta.SEGURAVG_COD_SUBG = result[i++].Value?.ToString();
            dta.SEGURAVG_COD_CLI = result[i++].Value?.ToString();
            dta.SEGURAVG_NUM_CERT = result[i++].Value?.ToString();
            dta.SEGURAVG_DAC_CERT = result[i++].Value?.ToString();
            dta.SEGURAVG_TIPO_SEG = result[i++].Value?.ToString();
            dta.SEGURAVG_NUM_ITEM = result[i++].Value?.ToString();
            dta.SEGURAVG_OCORR_HI = result[i++].Value?.ToString();
            dta.SEGURAVG_EST_CIVIL = result[i++].Value?.ToString();
            dta.SEGURAVG_IDE_SEXO = result[i++].Value?.ToString();
            dta.SEGURAVG_MATRICULA = result[i++].Value?.ToString();
            dta.SEGURAVG_DT_INIVI = result[i++].Value?.ToString();
            dta.SEGURAVG_SIT_REG = result[i++].Value?.ToString();
            dta.SEGURAVG_DT_NASCI = result[i++].Value?.ToString();
            dta.CLIENTE_COD_CLI = result[i++].Value?.ToString();
            dta.CLIENTE_NOME_RAZAO = result[i++].Value?.ToString();
            dta.CLIENTE_CGC_CPF = result[i++].Value?.ToString();

            return dta;
        }

    }
}