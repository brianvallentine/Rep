using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0601B
{
    public class R1900_CONSULTA_CARENCIA_DB_SELECT_1_Query1 : QueryBasis<R1900_CONSULTA_CARENCIA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DISTINCT
            STA_CARENCIA
            INTO :WS-TEM-CARENCIA
            FROM SEGUROS.VA_CAMPANHA_CARENCIA
            WHERE NUM_CPF_CNPJ = :DCLPESSOA-FISICA.CPF
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT DISTINCT
											STA_CARENCIA
											FROM SEGUROS.VA_CAMPANHA_CARENCIA
											WHERE NUM_CPF_CNPJ = '{this.CPF}'";

            return query;
        }
        public string WS_TEM_CARENCIA { get; set; }
        public string CPF { get; set; }

        public static R1900_CONSULTA_CARENCIA_DB_SELECT_1_Query1 Execute(R1900_CONSULTA_CARENCIA_DB_SELECT_1_Query1 r1900_CONSULTA_CARENCIA_DB_SELECT_1_Query1)
        {
            var ths = r1900_CONSULTA_CARENCIA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1900_CONSULTA_CARENCIA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1900_CONSULTA_CARENCIA_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_TEM_CARENCIA = result[i++].Value?.ToString();
            return dta;
        }

    }
}