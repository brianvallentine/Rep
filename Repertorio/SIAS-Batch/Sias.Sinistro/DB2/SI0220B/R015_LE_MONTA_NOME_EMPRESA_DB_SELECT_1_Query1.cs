using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0220B
{
    public class R015_LE_MONTA_NOME_EMPRESA_DB_SELECT_1_Query1 : QueryBasis<R015_LE_MONTA_NOME_EMPRESA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOME_EMPRESA
            INTO :EMPRESAS-NOME-EMPRESA
            FROM SEGUROS.EMPRESAS
            WHERE COD_EMPRESA = 0
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOME_EMPRESA
											FROM SEGUROS.EMPRESAS
											WHERE COD_EMPRESA = 0
											WITH UR";

            return query;
        }
        public string EMPRESAS_NOME_EMPRESA { get; set; }

        public static R015_LE_MONTA_NOME_EMPRESA_DB_SELECT_1_Query1 Execute(R015_LE_MONTA_NOME_EMPRESA_DB_SELECT_1_Query1 r015_LE_MONTA_NOME_EMPRESA_DB_SELECT_1_Query1)
        {
            var ths = r015_LE_MONTA_NOME_EMPRESA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R015_LE_MONTA_NOME_EMPRESA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R015_LE_MONTA_NOME_EMPRESA_DB_SELECT_1_Query1();
            var i = 0;
            dta.EMPRESAS_NOME_EMPRESA = result[i++].Value?.ToString();
            return dta;
        }

    }
}