using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0145B
{
    public class R2500_00_INSERT_PARCEVID_DB_SELECT_1_Query1 : QueryBasis<R2500_00_INSERT_PARCEVID_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT OPCAO_PAGAMENTO
            INTO :OPCPAGVI-OPCAO-PAGAMENTO
            FROM SEGUROS.OPCAO_PAG_VIDAZUL
            WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT OPCAO_PAGAMENTO
											FROM SEGUROS.OPCAO_PAG_VIDAZUL
											WHERE NUM_CERTIFICADO = '{this.PROPOVA_NUM_CERTIFICADO}'";

            return query;
        }
        public string OPCPAGVI_OPCAO_PAGAMENTO { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }

        public static R2500_00_INSERT_PARCEVID_DB_SELECT_1_Query1 Execute(R2500_00_INSERT_PARCEVID_DB_SELECT_1_Query1 r2500_00_INSERT_PARCEVID_DB_SELECT_1_Query1)
        {
            var ths = r2500_00_INSERT_PARCEVID_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2500_00_INSERT_PARCEVID_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2500_00_INSERT_PARCEVID_DB_SELECT_1_Query1();
            var i = 0;
            dta.OPCPAGVI_OPCAO_PAGAMENTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}