using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0229B
{
    public class R1020_00_SELECT_CBCONDEV_DB_SELECT_1_Query1 : QueryBasis<R1020_00_SELECT_CBCONDEV_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT MAX(NUM_SEQUENCIA)
            INTO :CBCONDEV-NUM-SEQUENCIA:VIND-NRSEQ
            FROM SEGUROS.CB_CONTR_DEVPREMIO
            WHERE DATA_MOVIMENTO = :SISTEMAS-DATA-MOV-ABERTO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT MAX(NUM_SEQUENCIA)
											FROM SEGUROS.CB_CONTR_DEVPREMIO
											WHERE DATA_MOVIMENTO = '{this.SISTEMAS_DATA_MOV_ABERTO}'
											WITH UR";

            return query;
        }
        public string CBCONDEV_NUM_SEQUENCIA { get; set; }
        public string VIND_NRSEQ { get; set; }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }

        public static R1020_00_SELECT_CBCONDEV_DB_SELECT_1_Query1 Execute(R1020_00_SELECT_CBCONDEV_DB_SELECT_1_Query1 r1020_00_SELECT_CBCONDEV_DB_SELECT_1_Query1)
        {
            var ths = r1020_00_SELECT_CBCONDEV_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1020_00_SELECT_CBCONDEV_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1020_00_SELECT_CBCONDEV_DB_SELECT_1_Query1();
            var i = 0;
            dta.CBCONDEV_NUM_SEQUENCIA = result[i++].Value?.ToString();
            dta.VIND_NRSEQ = string.IsNullOrWhiteSpace(dta.CBCONDEV_NUM_SEQUENCIA) ? "-1" : "0";
            return dta;
        }

    }
}