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
    public class R2200_00_SELECT_SINISHIS_DB_SELECT_1_Query1 : QueryBasis<R2200_00_SELECT_SINISHIS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            VALUE(SUM(A.VAL_OPERACAO),0) AS VAL_ATU_MONET
            INTO
            :SINISHIS-VAL-OPERACAO
            FROM
            SEGUROS.SINISTRO_HISTORICO A
            WHERE
            NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO
            AND COD_OPERACAO = 1201
            AND NOME_FAVORECIDO = :SINISHIS-NOME-FAVORECIDO
            AND OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO
            AND NOT EXISTS (
            SELECT NUM_APOL_SINISTRO
            FROM SEGUROS.SINISTRO_HISTORICO B
            WHERE B.NUM_APOL_SINISTRO = A.NUM_APOL_SINISTRO
            AND B.COD_OPERACAO = A.COD_OPERACAO + 10
            AND B.OCORR_HISTORICO = A.OCORR_HISTORICO)
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											VALUE(SUM(A.VAL_OPERACAO)
							,0) AS VAL_ATU_MONET
											FROM
											SEGUROS.SINISTRO_HISTORICO A
											WHERE
											NUM_APOL_SINISTRO = '{this.SINISHIS_NUM_APOL_SINISTRO}'
											AND COD_OPERACAO = 1201
											AND NOME_FAVORECIDO = '{this.SINISHIS_NOME_FAVORECIDO}'
											AND OCORR_HISTORICO = '{this.SINISHIS_OCORR_HISTORICO}'
											AND NOT EXISTS (
											SELECT NUM_APOL_SINISTRO
											FROM SEGUROS.SINISTRO_HISTORICO B
											WHERE B.NUM_APOL_SINISTRO = A.NUM_APOL_SINISTRO
											AND B.COD_OPERACAO = A.COD_OPERACAO + 10
											AND B.OCORR_HISTORICO = A.OCORR_HISTORICO)";

            return query;
        }
        public string SINISHIS_VAL_OPERACAO { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }
        public string SINISHIS_NOME_FAVORECIDO { get; set; }
        public string SINISHIS_OCORR_HISTORICO { get; set; }

        public static R2200_00_SELECT_SINISHIS_DB_SELECT_1_Query1 Execute(R2200_00_SELECT_SINISHIS_DB_SELECT_1_Query1 r2200_00_SELECT_SINISHIS_DB_SELECT_1_Query1)
        {
            var ths = r2200_00_SELECT_SINISHIS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2200_00_SELECT_SINISHIS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2200_00_SELECT_SINISHIS_DB_SELECT_1_Query1();
            var i = 0;
            dta.SINISHIS_VAL_OPERACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}