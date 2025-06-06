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
    public class R9998_00_VERIFICA_PEP_DB_SELECT_2_Query1 : QueryBasis<R9998_00_VERIFICA_PEP_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT 'S'
            INTO :WS-PEP-AVALIADO
            FROM SEGUROS.VG_ANDAMENTO_PROP
            WHERE NUM_CERTIFICADO = :VG078-NUM-CERTIFICADO
            AND DES_ANDAMENTO LIKE '%CLIENTE PEP%'
            FETCH FIRST 1 ROW ONLY
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT 'S'
											FROM SEGUROS.VG_ANDAMENTO_PROP
											WHERE NUM_CERTIFICADO = '{this.VG078_NUM_CERTIFICADO}'
											AND DES_ANDAMENTO LIKE '%CLIENTE PEP%'
											FETCH FIRST 1 ROW ONLY
											WITH UR";

            return query;
        }
        public string WS_PEP_AVALIADO { get; set; }
        public string VG078_NUM_CERTIFICADO { get; set; }

        public static R9998_00_VERIFICA_PEP_DB_SELECT_2_Query1 Execute(R9998_00_VERIFICA_PEP_DB_SELECT_2_Query1 r9998_00_VERIFICA_PEP_DB_SELECT_2_Query1)
        {
            var ths = r9998_00_VERIFICA_PEP_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R9998_00_VERIFICA_PEP_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R9998_00_VERIFICA_PEP_DB_SELECT_2_Query1();
            var i = 0;
            dta.WS_PEP_AVALIADO = result[i++].Value?.ToString();
            return dta;
        }

    }
}