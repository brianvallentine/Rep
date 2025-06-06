using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GECPB100
{
    public class R0000_00_PRINCIPAL_DB_SELECT_1_Query1 : QueryBasis<R0000_00_PRINCIPAL_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DTA_MOV_ABERTO,
            DTA_ULT_MOV_ABERTO
            INTO :GE501-DTA-MOV-ABERTO,
            :GE501-DTA-ULT-MOV-ABERTO
            FROM SIUS.GE_PROCESSA_SUB_SISTEMA
            WHERE COD_IDE_SISTEMA = 'GE'
            AND COD_SUB_SISTEMA = 'CP'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DTA_MOV_ABERTO
							,
											DTA_ULT_MOV_ABERTO
											FROM SIUS.GE_PROCESSA_SUB_SISTEMA
											WHERE COD_IDE_SISTEMA = 'GE'
											AND COD_SUB_SISTEMA = 'CP'
											WITH UR";

            return query;
        }
        public string GE501_DTA_MOV_ABERTO { get; set; }
        public string GE501_DTA_ULT_MOV_ABERTO { get; set; }

        public static R0000_00_PRINCIPAL_DB_SELECT_1_Query1 Execute(R0000_00_PRINCIPAL_DB_SELECT_1_Query1 r0000_00_PRINCIPAL_DB_SELECT_1_Query1)
        {
            var ths = r0000_00_PRINCIPAL_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0000_00_PRINCIPAL_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0000_00_PRINCIPAL_DB_SELECT_1_Query1();
            var i = 0;
            dta.GE501_DTA_MOV_ABERTO = result[i++].Value?.ToString();
            dta.GE501_DTA_ULT_MOV_ABERTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}