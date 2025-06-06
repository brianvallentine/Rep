using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0005B
{
    public class R9998_00_VERIFICA_PEP_DB_SELECT_1_Query1 : QueryBasis<R9998_00_VERIFICA_PEP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.NUM_CPF_CNPJ
            INTO :VG131-NUM-CPF-CNPJ
            FROM SEGUROS.VG_PESSOA_PEPS A
            WHERE A.NUM_CPF_CNPJ = :VG131-NUM-CPF-CNPJ
            AND A.DTA_FIM_VIGENCIA IS NULL
            UNION ALL
            SELECT B.NUM_CPF_CNPJ
            INTO :VG132-NUM-CPF-CNPJ
            FROM SEGUROS.VG_PESSOA_PEPS B
            WHERE B.NUM_CPF_CNPJ = :VG132-NUM-CPF-CNPJ
            AND B.DTA_EXONERACAO IS NULL
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT A.NUM_CPF_CNPJ
											FROM SEGUROS.VG_PESSOA_PEPS A
											WHERE A.NUM_CPF_CNPJ = '{this.VG131_NUM_CPF_CNPJ}'
											AND A.DTA_FIM_VIGENCIA IS NULL
											UNION ALL
											SELECT B.NUM_CPF_CNPJ
											INTO '{this.VG132_NUM_CPF_CNPJ}'
											FROM SEGUROS.VG_PESSOA_PEPS B
											WHERE B.NUM_CPF_CNPJ = '{this.VG132_NUM_CPF_CNPJ}'
											AND B.DTA_EXONERACAO IS NULL
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string VG131_NUM_CPF_CNPJ { get; set; }
        public string VG132_NUM_CPF_CNPJ { get; set; }

        public static R9998_00_VERIFICA_PEP_DB_SELECT_1_Query1 Execute(R9998_00_VERIFICA_PEP_DB_SELECT_1_Query1 r9998_00_VERIFICA_PEP_DB_SELECT_1_Query1)
        {
            var ths = r9998_00_VERIFICA_PEP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R9998_00_VERIFICA_PEP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R9998_00_VERIFICA_PEP_DB_SELECT_1_Query1();
            var i = 0;
            dta.VG131_NUM_CPF_CNPJ = result[i++].Value?.ToString();
            return dta;
        }

    }
}