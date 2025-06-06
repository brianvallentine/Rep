using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0120B
{
    public class R0050_00_PROCESSA_DB_SELECT_1_Query1 : QueryBasis<R0050_00_PROCESSA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT TIPO_COBRANCA
            INTO :APOLCOBR-TIPO-COBRANCA
            FROM SEGUROS.APOLICE_COBRANCA
            WHERE NUM_APOLICE = :V1EDIA-NUM-APOL
            AND NUM_ENDOSSO = 0
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT TIPO_COBRANCA
											FROM SEGUROS.APOLICE_COBRANCA
											WHERE NUM_APOLICE = '{this.V1EDIA_NUM_APOL}'
											AND NUM_ENDOSSO = 0
											WITH UR";

            return query;
        }
        public string APOLCOBR_TIPO_COBRANCA { get; set; }
        public string V1EDIA_NUM_APOL { get; set; }

        public static R0050_00_PROCESSA_DB_SELECT_1_Query1 Execute(R0050_00_PROCESSA_DB_SELECT_1_Query1 r0050_00_PROCESSA_DB_SELECT_1_Query1)
        {
            var ths = r0050_00_PROCESSA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0050_00_PROCESSA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0050_00_PROCESSA_DB_SELECT_1_Query1();
            var i = 0;
            dta.APOLCOBR_TIPO_COBRANCA = result[i++].Value?.ToString();
            return dta;
        }

    }
}