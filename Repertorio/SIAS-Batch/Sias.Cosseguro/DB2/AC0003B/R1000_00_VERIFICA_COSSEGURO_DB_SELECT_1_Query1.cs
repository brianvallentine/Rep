using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0003B
{
    public class R1000_00_VERIFICA_COSSEGURO_DB_SELECT_1_Query1 : QueryBasis<R1000_00_VERIFICA_COSSEGURO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COUNT(*)
            INTO :WHOST-QTDE-CONG
            FROM SEGUROS.ORDEM_COSSEGCED
            WHERE NUM_APOLICE = :ENDOSSOS-NUM-APOLICE
            AND NUM_ENDOSSO = :ENDOSSOS-NUM-ENDOSSO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COUNT(*)
											FROM SEGUROS.ORDEM_COSSEGCED
											WHERE NUM_APOLICE = '{this.ENDOSSOS_NUM_APOLICE}'
											AND NUM_ENDOSSO = '{this.ENDOSSOS_NUM_ENDOSSO}'";

            return query;
        }
        public string WHOST_QTDE_CONG { get; set; }
        public string ENDOSSOS_NUM_APOLICE { get; set; }
        public string ENDOSSOS_NUM_ENDOSSO { get; set; }

        public static R1000_00_VERIFICA_COSSEGURO_DB_SELECT_1_Query1 Execute(R1000_00_VERIFICA_COSSEGURO_DB_SELECT_1_Query1 r1000_00_VERIFICA_COSSEGURO_DB_SELECT_1_Query1)
        {
            var ths = r1000_00_VERIFICA_COSSEGURO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1000_00_VERIFICA_COSSEGURO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1000_00_VERIFICA_COSSEGURO_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_QTDE_CONG = result[i++].Value?.ToString();
            return dta;
        }

    }
}