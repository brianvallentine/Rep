using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0015B
{
    public class R0553_00_LE_V0FUNCIOCEF_DB_SELECT_1_Query1 : QueryBasis<R0553_00_LE_V0FUNCIOCEF_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            COD_AGENCIA,
            OPERACAO_CONTA,
            NUM_CONTA,
            DIG_CONTA
            INTO
            :V0FUNCI-COD-AGENCIA,
            :V0FUNCI-OPERACAO-CONTA,
            :V0FUNCI-NUM-CONTA,
            :V0FUNCI-DIG-CONTA
            FROM SEGUROS.V0FUNCIOCEF
            WHERE
            NUM_MATRICULA = :V0FUNCI-NUM-MATRICULA
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											COD_AGENCIA
							,
											OPERACAO_CONTA
							,
											NUM_CONTA
							,
											DIG_CONTA
											FROM SEGUROS.V0FUNCIOCEF
											WHERE
											NUM_MATRICULA = '{this.V0FUNCI_NUM_MATRICULA}'";

            return query;
        }
        public string V0FUNCI_COD_AGENCIA { get; set; }
        public string V0FUNCI_OPERACAO_CONTA { get; set; }
        public string V0FUNCI_NUM_CONTA { get; set; }
        public string V0FUNCI_DIG_CONTA { get; set; }
        public string V0FUNCI_NUM_MATRICULA { get; set; }

        public static R0553_00_LE_V0FUNCIOCEF_DB_SELECT_1_Query1 Execute(R0553_00_LE_V0FUNCIOCEF_DB_SELECT_1_Query1 r0553_00_LE_V0FUNCIOCEF_DB_SELECT_1_Query1)
        {
            var ths = r0553_00_LE_V0FUNCIOCEF_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0553_00_LE_V0FUNCIOCEF_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0553_00_LE_V0FUNCIOCEF_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0FUNCI_COD_AGENCIA = result[i++].Value?.ToString();
            dta.V0FUNCI_OPERACAO_CONTA = result[i++].Value?.ToString();
            dta.V0FUNCI_NUM_CONTA = result[i++].Value?.ToString();
            dta.V0FUNCI_DIG_CONTA = result[i++].Value?.ToString();
            return dta;
        }

    }
}