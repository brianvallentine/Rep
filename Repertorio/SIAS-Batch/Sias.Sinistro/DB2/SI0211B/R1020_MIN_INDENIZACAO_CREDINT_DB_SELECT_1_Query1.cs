using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0211B
{
    public class R1020_MIN_INDENIZACAO_CREDINT_DB_SELECT_1_Query1 : QueryBasis<R1020_MIN_INDENIZACAO_CREDINT_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MIN(A.DATA_MOVIMENTO), '9999-12-31' )
            INTO :HOST-MIN-DATA-MOVIMENTO
            FROM SEGUROS.SINISTRO_HISTORICO A,
            SEGUROS.GE_OPERACAO B
            WHERE A.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO
            AND B.FUNCAO_OPERACAO = 'IND'
            AND A.COD_OPERACAO = B.COD_OPERACAO
            AND B.IDE_SISTEMA = 'SI'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(MIN(A.DATA_MOVIMENTO)
							, '9999-12-31' )
											FROM SEGUROS.SINISTRO_HISTORICO A
							,
											SEGUROS.GE_OPERACAO B
											WHERE A.NUM_APOL_SINISTRO = '{this.SINISHIS_NUM_APOL_SINISTRO}'
											AND B.FUNCAO_OPERACAO = 'IND'
											AND A.COD_OPERACAO = B.COD_OPERACAO
											AND B.IDE_SISTEMA = 'SI'";

            return query;
        }
        public string HOST_MIN_DATA_MOVIMENTO { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }

        public static R1020_MIN_INDENIZACAO_CREDINT_DB_SELECT_1_Query1 Execute(R1020_MIN_INDENIZACAO_CREDINT_DB_SELECT_1_Query1 r1020_MIN_INDENIZACAO_CREDINT_DB_SELECT_1_Query1)
        {
            var ths = r1020_MIN_INDENIZACAO_CREDINT_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1020_MIN_INDENIZACAO_CREDINT_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1020_MIN_INDENIZACAO_CREDINT_DB_SELECT_1_Query1();
            var i = 0;
            dta.HOST_MIN_DATA_MOVIMENTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}