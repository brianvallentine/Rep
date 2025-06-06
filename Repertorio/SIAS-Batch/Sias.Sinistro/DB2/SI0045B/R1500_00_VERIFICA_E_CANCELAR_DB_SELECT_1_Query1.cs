using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0045B
{
    public class R1500_00_VERIFICA_E_CANCELAR_DB_SELECT_1_Query1 : QueryBasis<R1500_00_VERIFICA_E_CANCELAR_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOL_SINISTRO
            INTO :SINISHIS-NUM-APOL-SINISTRO
            FROM SEGUROS.SINISTRO_HISTORICO
            WHERE NUM_APOL_SINISTRO = :SINISMES-NUM-APOL-SINISTRO
            AND COD_OPERACAO IN (1001,1002,1003,1004,1009,
            1081,1082,1083,1084,
            1181,1182,1183,1184)
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_APOL_SINISTRO
											FROM SEGUROS.SINISTRO_HISTORICO
											WHERE NUM_APOL_SINISTRO = '{this.SINISMES_NUM_APOL_SINISTRO}'
											AND COD_OPERACAO IN (1001
							,1002
							,1003
							,1004
							,1009
							,
											1081
							,1082
							,1083
							,1084
							,
											1181
							,1182
							,1183
							,1184)
											WITH UR";

            return query;
        }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }
        public string SINISMES_NUM_APOL_SINISTRO { get; set; }

        public static R1500_00_VERIFICA_E_CANCELAR_DB_SELECT_1_Query1 Execute(R1500_00_VERIFICA_E_CANCELAR_DB_SELECT_1_Query1 r1500_00_VERIFICA_E_CANCELAR_DB_SELECT_1_Query1)
        {
            var ths = r1500_00_VERIFICA_E_CANCELAR_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1500_00_VERIFICA_E_CANCELAR_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1500_00_VERIFICA_E_CANCELAR_DB_SELECT_1_Query1();
            var i = 0;
            dta.SINISHIS_NUM_APOL_SINISTRO = result[i++].Value?.ToString();
            return dta;
        }

    }
}