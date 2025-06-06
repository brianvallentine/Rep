using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0031B
{
    public class R4150_00_LE_ANALISTA_DB_SELECT_1_Query1 : QueryBasis<R4150_00_LE_ANALISTA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_USUARIO
            INTO :SIANAROD-COD-USUARIO
            FROM SEGUROS.SI_ANALISTA_RODIZI
            WHERE COD_FONTE = :WS-FONTE-ANT
            AND NUM_PROTOCOLO_SINI = :WS-PROTOCOLO-ANT
            AND DAC_PROTOCOLO_SINI = :WS-DAC-ANT
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_USUARIO
											FROM SEGUROS.SI_ANALISTA_RODIZI
											WHERE COD_FONTE = '{this.WS_FONTE_ANT}'
											AND NUM_PROTOCOLO_SINI = '{this.WS_PROTOCOLO_ANT}'
											AND DAC_PROTOCOLO_SINI = '{this.WS_DAC_ANT}'";

            return query;
        }
        public string SIANAROD_COD_USUARIO { get; set; }
        public string WS_PROTOCOLO_ANT { get; set; }
        public string WS_FONTE_ANT { get; set; }
        public string WS_DAC_ANT { get; set; }

        public static R4150_00_LE_ANALISTA_DB_SELECT_1_Query1 Execute(R4150_00_LE_ANALISTA_DB_SELECT_1_Query1 r4150_00_LE_ANALISTA_DB_SELECT_1_Query1)
        {
            var ths = r4150_00_LE_ANALISTA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R4150_00_LE_ANALISTA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R4150_00_LE_ANALISTA_DB_SELECT_1_Query1();
            var i = 0;
            dta.SIANAROD_COD_USUARIO = result[i++].Value?.ToString();
            return dta;
        }

    }
}