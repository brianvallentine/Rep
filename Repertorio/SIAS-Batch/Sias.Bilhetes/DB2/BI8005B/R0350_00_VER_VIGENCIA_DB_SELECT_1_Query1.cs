using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI8005B
{
    public class R0350_00_VER_VIGENCIA_DB_SELECT_1_Query1 : QueryBasis<R0350_00_VER_VIGENCIA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATE(:WHOST-DTINIVIG)
            + :PRPFIDEL-QTD-MESES MONTHS - 1 DAY
            INTO :WHOST-DTTERVIG
            FROM SEGUROS.SISTEMAS
            WHERE IDE_SISTEMA = 'BI'
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT DATE('{this.WHOST_DTINIVIG}')
											+ {this.PRPFIDEL_QTD_MESES} MONTHS - 1 DAY
											FROM SEGUROS.SISTEMAS
											WHERE IDE_SISTEMA = 'BI'";

            return query;
        }
        public string WHOST_DTTERVIG { get; set; }
        public string PRPFIDEL_QTD_MESES { get; set; }
        public string WHOST_DTINIVIG { get; set; }

        public static R0350_00_VER_VIGENCIA_DB_SELECT_1_Query1 Execute(R0350_00_VER_VIGENCIA_DB_SELECT_1_Query1 r0350_00_VER_VIGENCIA_DB_SELECT_1_Query1)
        {
            var ths = r0350_00_VER_VIGENCIA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0350_00_VER_VIGENCIA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0350_00_VER_VIGENCIA_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_DTTERVIG = result[i++].Value?.ToString();
            return dta;
        }

    }
}