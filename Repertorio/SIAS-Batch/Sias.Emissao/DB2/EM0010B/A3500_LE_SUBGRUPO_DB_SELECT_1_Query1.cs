using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0010B
{
    public class A3500_LE_SUBGRUPO_DB_SELECT_1_Query1 : QueryBasis<A3500_LE_SUBGRUPO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT OPCAO_CORRETAGEM
            INTO :SUB-OPC-CORRETAGEM
            FROM SEGUROS.V1SUBGRUPO
            WHERE NUM_APOLICE = :ENDO-NUM-APOLICE
            AND COD_SUBGRUPO = :ENDO-CODSUBES
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT OPCAO_CORRETAGEM
											FROM SEGUROS.V1SUBGRUPO
											WHERE NUM_APOLICE = '{this.ENDO_NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.ENDO_CODSUBES}'
											WITH UR";

            return query;
        }
        public string SUB_OPC_CORRETAGEM { get; set; }
        public string ENDO_NUM_APOLICE { get; set; }
        public string ENDO_CODSUBES { get; set; }

        public static A3500_LE_SUBGRUPO_DB_SELECT_1_Query1 Execute(A3500_LE_SUBGRUPO_DB_SELECT_1_Query1 a3500_LE_SUBGRUPO_DB_SELECT_1_Query1)
        {
            var ths = a3500_LE_SUBGRUPO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override A3500_LE_SUBGRUPO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new A3500_LE_SUBGRUPO_DB_SELECT_1_Query1();
            var i = 0;
            dta.SUB_OPC_CORRETAGEM = result[i++].Value?.ToString();
            return dta;
        }

    }
}