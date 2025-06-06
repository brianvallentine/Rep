using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0003B
{
    public class R0600_00_VERIFICA_TIPO_ENDS_DB_SELECT_1_Query1 : QueryBasis<R0600_00_VERIFICA_TIPO_ENDS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT TIPO_ENDOSSO
            INTO :WHOST-TIPO-ENDS
            FROM SEGUROS.ENDOSSOS
            WHERE NUM_APOLICE = :PARCEHIS-NUM-APOLICE
            AND NUM_ENDOSSO = :PARCEHIS-ENDOS-CANCELA
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT TIPO_ENDOSSO
											FROM SEGUROS.ENDOSSOS
											WHERE NUM_APOLICE = '{this.PARCEHIS_NUM_APOLICE}'
											AND NUM_ENDOSSO = '{this.PARCEHIS_ENDOS_CANCELA}'";

            return query;
        }
        public string WHOST_TIPO_ENDS { get; set; }
        public string PARCEHIS_ENDOS_CANCELA { get; set; }
        public string PARCEHIS_NUM_APOLICE { get; set; }

        public static R0600_00_VERIFICA_TIPO_ENDS_DB_SELECT_1_Query1 Execute(R0600_00_VERIFICA_TIPO_ENDS_DB_SELECT_1_Query1 r0600_00_VERIFICA_TIPO_ENDS_DB_SELECT_1_Query1)
        {
            var ths = r0600_00_VERIFICA_TIPO_ENDS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0600_00_VERIFICA_TIPO_ENDS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0600_00_VERIFICA_TIPO_ENDS_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_TIPO_ENDS = result[i++].Value?.ToString();
            return dta;
        }

    }
}