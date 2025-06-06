using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0860B
{
    public class R0330_00_SELECT_CBASICA_DB_SELECT_1_Query1 : QueryBasis<R0330_00_SELECT_CBASICA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOLICE,
            NUM_SINISTRO,
            NUM_BILHETE,
            OCORR_HISTORICO,
            NOME_BENEFICIARIO,
            ENDERECO,
            BAIRRO,
            CIDADE,
            SIGLA_UF,
            CEP,
            SIT_REGISTRO,
            DTMOVTO,
            DDD_BENEF_CBASICA,
            FONE_BENEF_CBASICA,
            OBS_BENEF_CBASICA,
            DATA_INDENIZACAO
            INTO
            :SINBENCB-NUM-APOLICE,
            :SINBENCB-NUM-SINISTRO,
            :SINBENCB-NUM-BILHETE,
            :SINBENCB-OCORR-HISTORICO,
            :SINBENCB-NOME-BENEFICIARIO,
            :SINBENCB-ENDERECO,
            :SINBENCB-BAIRRO,
            :SINBENCB-CIDADE,
            :SINBENCB-SIGLA-UF,
            :SINBENCB-CEP,
            :SINBENCB-SIT-REGISTRO,
            :SINBENCB-DTMOVTO,
            :SINBENCB-DDD-BENEF-CBASICA,
            :SINBENCB-FONE-BENEF-CBASICA,
            :SINBENCB-OBS-BENEF-CBASICA,
            :SINBENCB-DATA-INDENIZACAO
            FROM
            SEGUROS.SINI_BENEF_CBASICA
            WHERE
            SIT_REGISTRO = '1'
            AND NUM_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_APOLICE
							,
											NUM_SINISTRO
							,
											NUM_BILHETE
							,
											OCORR_HISTORICO
							,
											NOME_BENEFICIARIO
							,
											ENDERECO
							,
											BAIRRO
							,
											CIDADE
							,
											SIGLA_UF
							,
											CEP
							,
											SIT_REGISTRO
							,
											DTMOVTO
							,
											DDD_BENEF_CBASICA
							,
											FONE_BENEF_CBASICA
							,
											OBS_BENEF_CBASICA
							,
											DATA_INDENIZACAO
											FROM
											SEGUROS.SINI_BENEF_CBASICA
											WHERE
											SIT_REGISTRO = '1'
											AND NUM_SINISTRO = '{this.SINISHIS_NUM_APOL_SINISTRO}'";

            return query;
        }
        public string SINBENCB_NUM_APOLICE { get; set; }
        public string SINBENCB_NUM_SINISTRO { get; set; }
        public string SINBENCB_NUM_BILHETE { get; set; }
        public string SINBENCB_OCORR_HISTORICO { get; set; }
        public string SINBENCB_NOME_BENEFICIARIO { get; set; }
        public string SINBENCB_ENDERECO { get; set; }
        public string SINBENCB_BAIRRO { get; set; }
        public string SINBENCB_CIDADE { get; set; }
        public string SINBENCB_SIGLA_UF { get; set; }
        public string SINBENCB_CEP { get; set; }
        public string SINBENCB_SIT_REGISTRO { get; set; }
        public string SINBENCB_DTMOVTO { get; set; }
        public string SINBENCB_DDD_BENEF_CBASICA { get; set; }
        public string SINBENCB_FONE_BENEF_CBASICA { get; set; }
        public string SINBENCB_OBS_BENEF_CBASICA { get; set; }
        public string SINBENCB_DATA_INDENIZACAO { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }

        public static R0330_00_SELECT_CBASICA_DB_SELECT_1_Query1 Execute(R0330_00_SELECT_CBASICA_DB_SELECT_1_Query1 r0330_00_SELECT_CBASICA_DB_SELECT_1_Query1)
        {
            var ths = r0330_00_SELECT_CBASICA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0330_00_SELECT_CBASICA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0330_00_SELECT_CBASICA_DB_SELECT_1_Query1();
            var i = 0;
            dta.SINBENCB_NUM_APOLICE = result[i++].Value?.ToString();
            dta.SINBENCB_NUM_SINISTRO = result[i++].Value?.ToString();
            dta.SINBENCB_NUM_BILHETE = result[i++].Value?.ToString();
            dta.SINBENCB_OCORR_HISTORICO = result[i++].Value?.ToString();
            dta.SINBENCB_NOME_BENEFICIARIO = result[i++].Value?.ToString();
            dta.SINBENCB_ENDERECO = result[i++].Value?.ToString();
            dta.SINBENCB_BAIRRO = result[i++].Value?.ToString();
            dta.SINBENCB_CIDADE = result[i++].Value?.ToString();
            dta.SINBENCB_SIGLA_UF = result[i++].Value?.ToString();
            dta.SINBENCB_CEP = result[i++].Value?.ToString();
            dta.SINBENCB_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.SINBENCB_DTMOVTO = result[i++].Value?.ToString();
            dta.SINBENCB_DDD_BENEF_CBASICA = result[i++].Value?.ToString();
            dta.SINBENCB_FONE_BENEF_CBASICA = result[i++].Value?.ToString();
            dta.SINBENCB_OBS_BENEF_CBASICA = result[i++].Value?.ToString();
            dta.SINBENCB_DATA_INDENIZACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}