using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0134B
{
    public class R1102_00_SELECT_SEGURADO_DB_SELECT_1_Query1 : QueryBasis<R1102_00_SELECT_SEGURADO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT CODIGO_CH1_REC1
            INTO :SIHABIT2-CODIGO-CH1-REC1
            FROM SEGUROS.SINISTRO_HABIT2
            WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO
            AND COD_OPERACAO = :SINISHIS-COD-OPERACAO
            AND OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT CODIGO_CH1_REC1
											FROM SEGUROS.SINISTRO_HABIT2
											WHERE NUM_APOL_SINISTRO = '{this.SINISHIS_NUM_APOL_SINISTRO}'
											AND COD_OPERACAO = '{this.SINISHIS_COD_OPERACAO}'
											AND OCORR_HISTORICO = '{this.SINISHIS_OCORR_HISTORICO}'
											WITH UR";

            return query;
        }
        public string SIHABIT2_CODIGO_CH1_REC1 { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }
        public string SINISHIS_OCORR_HISTORICO { get; set; }
        public string SINISHIS_COD_OPERACAO { get; set; }

        public static R1102_00_SELECT_SEGURADO_DB_SELECT_1_Query1 Execute(R1102_00_SELECT_SEGURADO_DB_SELECT_1_Query1 r1102_00_SELECT_SEGURADO_DB_SELECT_1_Query1)
        {
            var ths = r1102_00_SELECT_SEGURADO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1102_00_SELECT_SEGURADO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1102_00_SELECT_SEGURADO_DB_SELECT_1_Query1();
            var i = 0;
            dta.SIHABIT2_CODIGO_CH1_REC1 = result[i++].Value?.ToString();
            return dta;
        }

    }
}