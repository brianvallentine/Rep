using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0065B
{
    public class R0120_00_MONTA_EMPRESA_DB_SELECT_1_Query1 : QueryBasis<R0120_00_MONTA_EMPRESA_DB_SELECT_1_Query1>
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

        public static R0120_00_MONTA_EMPRESA_DB_SELECT_1_Query1 Execute(R0120_00_MONTA_EMPRESA_DB_SELECT_1_Query1 r0120_00_MONTA_EMPRESA_DB_SELECT_1_Query1)
        {
            var ths = r0120_00_MONTA_EMPRESA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0120_00_MONTA_EMPRESA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0120_00_MONTA_EMPRESA_DB_SELECT_1_Query1();
            var i = 0;
            dta.EMPRESAS_NOME_EMPRESA = result[i++].Value?.ToString();
            return dta;
        }

    }
}