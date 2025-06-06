using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0124B
{
    public class R7111_00_CONSULTA_DEVOL_PARC_DB_SELECT_1_Query1 : QueryBasis<R7111_00_CONSULTA_DEVOL_PARC_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COUNT(*)
            INTO :WS-QTD-PARC-SR
            FROM SEGUROS.RELATORIOS
            WHERE NUM_CERTIFICADO = :V0PROP-NRCERTIF
            AND NUM_PARCELA = :WS-NUM-PARCELA
            AND NUM_COPIAS = '8'
            AND SIT_REGISTRO = '0'
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT COUNT(*)
											FROM SEGUROS.RELATORIOS
											WHERE NUM_CERTIFICADO = '{this.V0PROP_NRCERTIF}'
											AND NUM_PARCELA = '{this.WS_NUM_PARCELA}'
											AND NUM_COPIAS = '8'
											AND SIT_REGISTRO = '0'
											WITH UR";

            return query;
        }
        public string WS_QTD_PARC_SR { get; set; }
        public string V0PROP_NRCERTIF { get; set; }
        public string WS_NUM_PARCELA { get; set; }

        public static R7111_00_CONSULTA_DEVOL_PARC_DB_SELECT_1_Query1 Execute(R7111_00_CONSULTA_DEVOL_PARC_DB_SELECT_1_Query1 r7111_00_CONSULTA_DEVOL_PARC_DB_SELECT_1_Query1)
        {
            var ths = r7111_00_CONSULTA_DEVOL_PARC_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R7111_00_CONSULTA_DEVOL_PARC_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R7111_00_CONSULTA_DEVOL_PARC_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_QTD_PARC_SR = result[i++].Value?.ToString();
            return dta;
        }

    }
}