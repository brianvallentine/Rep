using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG9521B
{
    public class VG9521B_C01_GECLIMOV : QueryBasis<VG9521B_C01_GECLIMOV>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VG9521B_C01_GECLIMOV() { IsCursor = true; }

        public VG9521B_C01_GECLIMOV(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string GECLIMOV_TIPO_MOVIMENTO { get; set; }
        public string GECLIMOV_DATA_ULT_MANUTEN { get; set; }
        public string GECLIMOV_NOME_RAZAO { get; set; }
        public string VIND_NOME_RAZAO { get; set; }
        public string GECLIMOV_TIPO_PESSOA { get; set; }
        public string VIND_TIPO_PESSOA { get; set; }
        public string GECLIMOV_IDE_SEXO { get; set; }
        public string VIND_IDE_SEXO { get; set; }
        public string GECLIMOV_ESTADO_CIVIL { get; set; }
        public string VIND_EST_CIVIL { get; set; }
        public string GECLIMOV_OCORR_ENDERECO { get; set; }
        public string VIND_OCORR_END { get; set; }
        public string GECLIMOV_ENDERECO { get; set; }
        public string VIND_ENDERECO { get; set; }
        public string GECLIMOV_BAIRRO { get; set; }
        public string VIND_BAIRRO { get; set; }
        public string GECLIMOV_CIDADE { get; set; }
        public string VIND_CIDADE { get; set; }
        public string GECLIMOV_SIGLA_UF { get; set; }
        public string VIND_SIGLA_UF { get; set; }
        public string GECLIMOV_CEP { get; set; }
        public string VIND_CEP { get; set; }
        public string GECLIMOV_DDD { get; set; }
        public string VIND_DDD { get; set; }
        public string GECLIMOV_TELEFONE { get; set; }
        public string VIND_TELEFONE { get; set; }
        public string GECLIMOV_FAX { get; set; }
        public string VIND_FAX { get; set; }
        public string GECLIMOV_OCORR_HIST { get; set; }
        public string GECLIMOV_CGCCPF { get; set; }
        public string VIND_CGCCPF { get; set; }
        public string GECLIMOV_DATA_NASCIMENTO { get; set; }
        public string VIND_DTNASC { get; set; }

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


        public override VG9521B_C01_GECLIMOV OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VG9521B_C01_GECLIMOV();
            var i = 0;

            dta.GECLIMOV_TIPO_MOVIMENTO = result[i++].Value?.ToString();
            dta.GECLIMOV_DATA_ULT_MANUTEN = result[i++].Value?.ToString();
            dta.GECLIMOV_NOME_RAZAO = result[i++].Value?.ToString();
            dta.VIND_NOME_RAZAO = string.IsNullOrWhiteSpace(dta.GECLIMOV_NOME_RAZAO) ? "-1" : "0";
            dta.GECLIMOV_TIPO_PESSOA = result[i++].Value?.ToString();
            dta.VIND_TIPO_PESSOA = string.IsNullOrWhiteSpace(dta.GECLIMOV_TIPO_PESSOA) ? "-1" : "0";
            dta.GECLIMOV_IDE_SEXO = result[i++].Value?.ToString();
            dta.VIND_IDE_SEXO = string.IsNullOrWhiteSpace(dta.GECLIMOV_IDE_SEXO) ? "-1" : "0";
            dta.GECLIMOV_ESTADO_CIVIL = result[i++].Value?.ToString();
            dta.VIND_EST_CIVIL = string.IsNullOrWhiteSpace(dta.GECLIMOV_ESTADO_CIVIL) ? "-1" : "0";
            dta.GECLIMOV_OCORR_ENDERECO = result[i++].Value?.ToString();
            dta.VIND_OCORR_END = string.IsNullOrWhiteSpace(dta.GECLIMOV_OCORR_ENDERECO) ? "-1" : "0";
            dta.GECLIMOV_ENDERECO = result[i++].Value?.ToString();
            dta.VIND_ENDERECO = string.IsNullOrWhiteSpace(dta.GECLIMOV_ENDERECO) ? "-1" : "0";
            dta.GECLIMOV_BAIRRO = result[i++].Value?.ToString();
            dta.VIND_BAIRRO = string.IsNullOrWhiteSpace(dta.GECLIMOV_BAIRRO) ? "-1" : "0";
            dta.GECLIMOV_CIDADE = result[i++].Value?.ToString();
            dta.VIND_CIDADE = string.IsNullOrWhiteSpace(dta.GECLIMOV_CIDADE) ? "-1" : "0";
            dta.GECLIMOV_SIGLA_UF = result[i++].Value?.ToString();
            dta.VIND_SIGLA_UF = string.IsNullOrWhiteSpace(dta.GECLIMOV_SIGLA_UF) ? "-1" : "0";
            dta.GECLIMOV_CEP = result[i++].Value?.ToString();
            dta.VIND_CEP = string.IsNullOrWhiteSpace(dta.GECLIMOV_CEP) ? "-1" : "0";
            dta.GECLIMOV_DDD = result[i++].Value?.ToString();
            dta.VIND_DDD = string.IsNullOrWhiteSpace(dta.GECLIMOV_DDD) ? "-1" : "0";
            dta.GECLIMOV_TELEFONE = result[i++].Value?.ToString();
            dta.VIND_TELEFONE = string.IsNullOrWhiteSpace(dta.GECLIMOV_TELEFONE) ? "-1" : "0";
            dta.GECLIMOV_FAX = result[i++].Value?.ToString();
            dta.VIND_FAX = string.IsNullOrWhiteSpace(dta.GECLIMOV_FAX) ? "-1" : "0";
            dta.GECLIMOV_OCORR_HIST = result[i++].Value?.ToString();
            dta.GECLIMOV_CGCCPF = result[i++].Value?.ToString();
            dta.VIND_CGCCPF = string.IsNullOrWhiteSpace(dta.GECLIMOV_CGCCPF) ? "-1" : "0";
            dta.GECLIMOV_DATA_NASCIMENTO = result[i++].Value?.ToString();
            dta.VIND_DTNASC = string.IsNullOrWhiteSpace(dta.GECLIMOV_DATA_NASCIMENTO) ? "-1" : "0";

            return dta;
        }

    }
}