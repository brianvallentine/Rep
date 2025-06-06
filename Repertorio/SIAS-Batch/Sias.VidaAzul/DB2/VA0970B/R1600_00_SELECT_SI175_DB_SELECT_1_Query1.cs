using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0970B
{
    public class R1600_00_SELECT_SI175_DB_SELECT_1_Query1 : QueryBasis<R1600_00_SELECT_SI175_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            NUM_APOL_SINISTRO ,
            OCORR_HISTORICO ,
            COD_OPERACAO ,
            NUM_OCORR_MOVTO
            INTO
            :SI175-NUM-APOL-SINISTRO ,
            :SI175-OCORR-HISTORICO ,
            :SI175-COD-OPERACAO ,
            :SI175-NUM-OCORR-MOVTO
            FROM
            SEGUROS.SI_PESS_SINISTRO
            WHERE
            NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO
            AND OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO
            AND COD_OPERACAO IN
            (1181,1182,1183,1184,1004,1001,1002)
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											NUM_APOL_SINISTRO 
							,
											OCORR_HISTORICO 
							,
											COD_OPERACAO 
							,
											NUM_OCORR_MOVTO
											FROM
											SEGUROS.SI_PESS_SINISTRO
											WHERE
											NUM_APOL_SINISTRO = '{this.SINISHIS_NUM_APOL_SINISTRO}'
											AND OCORR_HISTORICO = '{this.SINISHIS_OCORR_HISTORICO}'
											AND COD_OPERACAO IN
											(1181
							,1182
							,1183
							,1184
							,1004
							,1001
							,1002)";

            return query;
        }
        public string SI175_NUM_APOL_SINISTRO { get; set; }
        public string SI175_OCORR_HISTORICO { get; set; }
        public string SI175_COD_OPERACAO { get; set; }
        public string SI175_NUM_OCORR_MOVTO { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }
        public string SINISHIS_OCORR_HISTORICO { get; set; }

        public static R1600_00_SELECT_SI175_DB_SELECT_1_Query1 Execute(R1600_00_SELECT_SI175_DB_SELECT_1_Query1 r1600_00_SELECT_SI175_DB_SELECT_1_Query1)
        {
            var ths = r1600_00_SELECT_SI175_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1600_00_SELECT_SI175_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1600_00_SELECT_SI175_DB_SELECT_1_Query1();
            var i = 0;
            dta.SI175_NUM_APOL_SINISTRO = result[i++].Value?.ToString();
            dta.SI175_OCORR_HISTORICO = result[i++].Value?.ToString();
            dta.SI175_COD_OPERACAO = result[i++].Value?.ToString();
            dta.SI175_NUM_OCORR_MOVTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}