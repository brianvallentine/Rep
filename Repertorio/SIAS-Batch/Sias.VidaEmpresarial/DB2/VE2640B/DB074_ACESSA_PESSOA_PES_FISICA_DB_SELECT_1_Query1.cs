using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE2640B
{
    public class DB074_ACESSA_PESSOA_PES_FISICA_DB_SELECT_1_Query1 : QueryBasis<DB074_ACESSA_PESSOA_PES_FISICA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.COD_PESSOA
            INTO :PESSOFIS-COD-PESSOA
            FROM SEGUROS.PESSOA A,
            SEGUROS.PESSOA_FISICA B
            WHERE A.COD_PESSOA = B.COD_PESSOA
            AND A.NOME_PESSOA = :PESSOA-NOME-PESSOA
            AND B.CPF = :PESSOFIS-CPF
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT A.COD_PESSOA
											FROM SEGUROS.PESSOA A
							,
											SEGUROS.PESSOA_FISICA B
											WHERE A.COD_PESSOA = B.COD_PESSOA
											AND A.NOME_PESSOA = '{this.PESSOA_NOME_PESSOA}'
											AND B.CPF = '{this.PESSOFIS_CPF}'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string PESSOFIS_COD_PESSOA { get; set; }
        public string PESSOA_NOME_PESSOA { get; set; }
        public string PESSOFIS_CPF { get; set; }

        public static DB074_ACESSA_PESSOA_PES_FISICA_DB_SELECT_1_Query1 Execute(DB074_ACESSA_PESSOA_PES_FISICA_DB_SELECT_1_Query1 dB074_ACESSA_PESSOA_PES_FISICA_DB_SELECT_1_Query1)
        {
            var ths = dB074_ACESSA_PESSOA_PES_FISICA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override DB074_ACESSA_PESSOA_PES_FISICA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new DB074_ACESSA_PESSOA_PES_FISICA_DB_SELECT_1_Query1();
            var i = 0;
            dta.PESSOFIS_COD_PESSOA = result[i++].Value?.ToString();
            return dta;
        }

    }
}