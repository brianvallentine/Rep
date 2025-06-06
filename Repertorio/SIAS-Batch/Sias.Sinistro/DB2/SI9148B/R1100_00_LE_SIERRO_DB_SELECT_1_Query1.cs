using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI9148B
{
    public class R1100_00_LE_SIERRO_DB_SELECT_1_Query1 : QueryBasis<R1100_00_LE_SIERRO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DES_ERRO
            INTO :SIERRO-DES-ERRO
            FROM SEGUROS.SI_ERRO
            WHERE COD_ERRO = :SIARDEVC-COD-ERRO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DES_ERRO
											FROM SEGUROS.SI_ERRO
											WHERE COD_ERRO = '{this.SIARDEVC_COD_ERRO}'";

            return query;
        }
        public string SIERRO_DES_ERRO { get; set; }
        public string SIARDEVC_COD_ERRO { get; set; }

        public static R1100_00_LE_SIERRO_DB_SELECT_1_Query1 Execute(R1100_00_LE_SIERRO_DB_SELECT_1_Query1 r1100_00_LE_SIERRO_DB_SELECT_1_Query1)
        {
            var ths = r1100_00_LE_SIERRO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1100_00_LE_SIERRO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1100_00_LE_SIERRO_DB_SELECT_1_Query1();
            var i = 0;
            dta.SIERRO_DES_ERRO = result[i++].Value?.ToString();
            return dta;
        }

    }
}