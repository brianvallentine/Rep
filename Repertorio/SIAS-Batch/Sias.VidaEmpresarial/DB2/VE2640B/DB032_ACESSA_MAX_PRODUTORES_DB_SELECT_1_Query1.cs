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
    public class DB032_ACESSA_MAX_PRODUTORES_DB_SELECT_1_Query1 : QueryBasis<DB032_ACESSA_MAX_PRODUTORES_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(COD_PRODUTOR),0)
            INTO :PRODUTOR-COD-PRODUTOR
            FROM SEGUROS.PRODUTORES
            WHERE NUM_MATRICULA = :FUNCICEF-NUM-MATRICULA
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(COD_PRODUTOR)
							,0)
											FROM SEGUROS.PRODUTORES
											WHERE NUM_MATRICULA = '{this.FUNCICEF_NUM_MATRICULA}'";

            return query;
        }
        public string PRODUTOR_COD_PRODUTOR { get; set; }
        public string FUNCICEF_NUM_MATRICULA { get; set; }

        public static DB032_ACESSA_MAX_PRODUTORES_DB_SELECT_1_Query1 Execute(DB032_ACESSA_MAX_PRODUTORES_DB_SELECT_1_Query1 dB032_ACESSA_MAX_PRODUTORES_DB_SELECT_1_Query1)
        {
            var ths = dB032_ACESSA_MAX_PRODUTORES_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override DB032_ACESSA_MAX_PRODUTORES_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new DB032_ACESSA_MAX_PRODUTORES_DB_SELECT_1_Query1();
            var i = 0;
            dta.PRODUTOR_COD_PRODUTOR = result[i++].Value?.ToString();
            return dta;
        }

    }
}