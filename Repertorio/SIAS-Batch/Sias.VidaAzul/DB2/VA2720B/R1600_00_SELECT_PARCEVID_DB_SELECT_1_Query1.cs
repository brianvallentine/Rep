using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA2720B
{
    public class R1600_00_SELECT_PARCEVID_DB_SELECT_1_Query1 : QueryBasis<R1600_00_SELECT_PARCEVID_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COUNT(*)
            INTO :WHOST-COUNT
            FROM SEGUROS.PARCELAS_VIDAZUL
            WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO
            AND SIT_REGISTRO IN ( ' ' , '0' )
            AND DATA_VENCIMENTO < :SISTEMAS-DATA-MOV-ABERTO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COUNT(*)
											FROM SEGUROS.PARCELAS_VIDAZUL
											WHERE NUM_CERTIFICADO = '{this.PROPOVA_NUM_CERTIFICADO}'
											AND SIT_REGISTRO IN ( ' ' 
							, '0' )
											AND DATA_VENCIMENTO < '{this.SISTEMAS_DATA_MOV_ABERTO}'";

            return query;
        }
        public string WHOST_COUNT { get; set; }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }

        public static R1600_00_SELECT_PARCEVID_DB_SELECT_1_Query1 Execute(R1600_00_SELECT_PARCEVID_DB_SELECT_1_Query1 r1600_00_SELECT_PARCEVID_DB_SELECT_1_Query1)
        {
            var ths = r1600_00_SELECT_PARCEVID_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1600_00_SELECT_PARCEVID_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1600_00_SELECT_PARCEVID_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_COUNT = result[i++].Value?.ToString();
            return dta;
        }

    }
}