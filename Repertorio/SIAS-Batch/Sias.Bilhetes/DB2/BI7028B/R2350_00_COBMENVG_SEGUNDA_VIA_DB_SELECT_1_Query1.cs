using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI7028B
{
    public class R2350_00_COBMENVG_SEGUNDA_VIA_DB_SELECT_1_Query1 : QueryBasis<R2350_00_COBMENVG_SEGUNDA_VIA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT JDE
            INTO :COBMENVG-JDE
            FROM SEGUROS.COBRANCA_MENS_VGAP
            WHERE NUM_APOLICE = :WHOST-NRAPOLICE
            AND CODSUBES = :COBMENVG-CODSUBES
            AND IDFORM = 'A4'
            AND COD_OPERACAO = 4
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT JDE
											FROM SEGUROS.COBRANCA_MENS_VGAP
											WHERE NUM_APOLICE = '{this.WHOST_NRAPOLICE}'
											AND CODSUBES = '{this.COBMENVG_CODSUBES}'
											AND IDFORM = 'A4'
											AND COD_OPERACAO = 4";

            return query;
        }
        public string COBMENVG_JDE { get; set; }
        public string COBMENVG_CODSUBES { get; set; }
        public string WHOST_NRAPOLICE { get; set; }

        public static R2350_00_COBMENVG_SEGUNDA_VIA_DB_SELECT_1_Query1 Execute(R2350_00_COBMENVG_SEGUNDA_VIA_DB_SELECT_1_Query1 r2350_00_COBMENVG_SEGUNDA_VIA_DB_SELECT_1_Query1)
        {
            var ths = r2350_00_COBMENVG_SEGUNDA_VIA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2350_00_COBMENVG_SEGUNDA_VIA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2350_00_COBMENVG_SEGUNDA_VIA_DB_SELECT_1_Query1();
            var i = 0;
            dta.COBMENVG_JDE = result[i++].Value?.ToString();
            return dta;
        }

    }
}